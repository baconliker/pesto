using System;
using System.Collections.Generic;
using System.Data;

namespace ColinBaker.Pesto.Models.Results
{
    class NationResults : Results
    {
        public NationResults(Competition competition)
        {
            this.Competition = competition;
        }

        public override void Generate(ResultsGenerationOptions options)
        {
            Services.SettingsStore store = new Services.SettingsStore();

            if (string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationName) || string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationKey))
            {
                throw new ResultsGenerationException("Bytescout Spreadsheet registration details not set. Please set these details in the Options screen.");
            }

            NationResultsGenerationOptions specificOptions = options as NationResultsGenerationOptions;

            // Compile a list of the tasks we want to generate
            List<Task> tasksToGenerate = new List<Task>();

            foreach (int i in specificOptions.TaskNumbers)
            {
                foreach (Task task in this.Competition.Tasks)
                {
                    if (task.Number == i)
                    {
                        tasksToGenerate.Add(task);
                        break;
                    }
                }
            }

            // Compile list of all aircraft class codes to be used
            List<string> aircraftClassCodes = new List<string>();
            foreach (NationDefinition nationDefinition in this.Competition.NationDefinitions)
            {
                aircraftClassCodes.Add(nationDefinition.AircraftClass.Code);
            }

            // Make sure all task results have been generated and are loaded
            foreach (Task task in tasksToGenerate)
            {
                foreach (TaskResults results in task.Results)
                {
                    if (aircraftClassCodes.Contains(results.AircraftClass.Code))
                    {
                        if (!results.Loaded)
                        {
                            if (results.Exists())
                            {
                                try
                                {
                                    results.Load();
                                }
                                catch
                                {
                                    throw new ResultsGenerationException(string.Format("Unable to load results for task {0}, class {1}.", task.Number, results.AircraftClass.Code));
                                }
                            }
                            else
                            {
                                throw new ResultsGenerationException(string.Format("Results have not yet been generated for task {0}, class {1}.", task.Number, results.AircraftClass.Code));
                            }
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(this.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.Country).ColumnName))
            {
                throw new ResultsGenerationException("Country mapping not set.");
            }

            DataTable nationData = new DataTable();

            nationData.Columns.Add(Results.CreateColumn("Nation", typeof(string), Column.ColumnType.Country, Column.ColumnAlignment.Left));

            foreach (Task task in tasksToGenerate)
            {
                DataColumn taskColumn = Results.CreateColumn(string.Format("Task {0} - {1}", task.Number, task.Name), typeof(int), Column.ColumnType.Score, Column.ColumnAlignment.Right);
                taskColumn.ExtendedProperties["DisplayName"] = string.Format("Task {0}\n{1}\n{2:dd MMM}", task.Number, (task.AbbreviatedName.Length > 0 ? task.AbbreviatedName : task.Name), this.Published);
                taskColumn.DefaultValue = 0;
                nationData.Columns.Add(taskColumn);
            }

            foreach (NationDefinition nationDefinition in this.Competition.NationDefinitions)
            {
                GenerateClass(nationDefinition.AircraftClass.Code, tasksToGenerate, nationDefinition.NumberWhoScore, nationData);
            }

            DataColumn totalColumn = AddTotalScoreColumn(nationData);

            // Sort default view by the total score column
            nationData.DefaultView.Sort = "[" + totalColumn.ColumnName + "] DESC, Nation ASC";

            AddPositionColumn(nationData.DefaultView, totalColumn.ColumnName);

            // Compare against existing data (from previous generation) and copy across column extended properties
            if (this.Data != null)
            {
                CopyColumnProperties(this.Data, nationData, false);
            }

            this.Data = nationData;

            this.Published = DateTime.Now;

            this.Loaded = true;
        }

        public override void Load()
        {
            this.Competition.Repository.LoadNationResults(this);
            this.Loaded = true;
        }

        public override void Save()
        {
            this.Competition.Repository.SaveNationResults(this);
        }

        public override void Publish()
        {
            Services.ResultsPublisher publisher = new Services.ResultsPublisher(this.Competition.Repository.FilePath);
            publisher.PublishNationResults();
        }

        public override string GetPublishedFilePath()
        {
            Services.ResultsPublisher publisher = new Services.ResultsPublisher(this.Competition.Repository.FilePath);
            return publisher.GetPublishedNationResultsFilePath();
        }

        public override bool Exists()
        {
            return this.Competition.Repository.NationResultsExists();
        }

        public DateTime Published { get; set; }

        public System.Data.DataTable Data { get; set; }

        public int FontSize { get; set; }

        public Competition Competition { get; set; }

        private void GenerateClass(string aircraftClassCode, List<Task> tasksToGenerate, int noWhoScoreInTask, DataTable teamData)
        {
            AircraftClass aircraftClass = null;

            foreach (AircraftClass ac in this.Competition.AircraftClasses)
            {
                if (string.Compare(ac.Code, aircraftClassCode, true) == 0)
                {
                    aircraftClass = ac;
                    break;
                }
            }

            if (aircraftClass == null)
            {
                throw new ResultsGenerationException(string.Format("Aircraft class {0} does not exist in this competition.", aircraftClassCode));
            }

            GenerateClassTasks(aircraftClass, tasksToGenerate, noWhoScoreInTask, teamData);
        }

        private void GenerateClassTasks(AircraftClass aircraftClass, List<Task> tasksToGenerate, int noWhoScoreInTask, DataTable nationData)
        {
            using (DataTable pilotData = this.Competition.PilotsSpreadsheet.GetData(aircraftClass.Code))
            {
                Results.CheckResultDataContainsMappedColumns(pilotData, this.Competition.PilotsSpreadsheet, aircraftClass);

                DataColumn pilotPilotNumberColumn = pilotData.Columns[this.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.PilotNumber).ColumnName];
                DataColumn pilotCountryColumn = pilotData.Columns[this.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.Country).ColumnName];

                using (DataView pilotView = new DataView(pilotData, "", "[" + pilotPilotNumberColumn.ColumnName + "]", DataViewRowState.CurrentRows))
                {
                    using (DataView nationView = new DataView(nationData, "", "Nation", DataViewRowState.CurrentRows))
                    {
                        // Add teams to results

                        foreach (DataRow pilotRow in pilotData.Rows)
                        {
                            string teamName = Convert.ToString(pilotRow[pilotCountryColumn.ColumnName]);

                            if (!string.IsNullOrEmpty(teamName))
                            {
                                int teamRecordIndex = nationView.Find(teamName);

                                if (teamRecordIndex == -1)
                                {
                                    DataRow newTeamRow = nationData.Rows.Add();

                                    newTeamRow["Nation"] = teamName;
                                }
                            }
                        }

                        // Add task scores to results

                        foreach (Task task in tasksToGenerate)
                        {
                            Dictionary<string, int> taskTeamPilotCounts = new Dictionary<string, int>();

                            foreach (TaskResults taskResults in task.Results)
                            {
                                if (taskResults.AircraftClass.Code == aircraftClass.Code)
                                {
                                    DataTable taskData = taskResults.Data;
                                    DataColumn taskScoreColumn = taskData.Columns[task.ScoringSpreadsheet.GetMapping(Column.ColumnType.Score).ColumnName];
                                    DataColumn taskPilotNumberColumn = taskData.Columns[task.ScoringSpreadsheet.GetMapping(Column.ColumnType.PilotNumber).ColumnName];

                                    using (DataView taskDataView = new DataView(taskData, "", "[" + taskScoreColumn.ColumnName + "] DESC", DataViewRowState.CurrentRows))
                                    {
                                        foreach (DataRowView taskRow in taskDataView)
                                        {
                                            int pilotNumber = Convert.ToInt32(taskRow[taskPilotNumberColumn.ColumnName]);
                                            int pilotScore = Convert.ToInt32(taskRow[taskScoreColumn.ColumnName]);

                                            // Find pilot so we can get his team name

                                            int pilotRecordIndex = pilotView.Find(pilotNumber);

                                            string teamName = Convert.ToString(pilotView[pilotRecordIndex][pilotCountryColumn.ColumnName]);

                                            if (!string.IsNullOrEmpty(teamName))
                                            {
                                                // Check if pilot scores for the team in this task

                                                if (taskTeamPilotCounts.ContainsKey(teamName))
                                                {
                                                    taskTeamPilotCounts[teamName]++;
                                                }
                                                else
                                                {
                                                    taskTeamPilotCounts.Add(teamName, 1);
                                                }

                                                if (taskTeamPilotCounts[teamName] <= noWhoScoreInTask)
                                                {
                                                    // Add pilot score to team results

                                                    int teamRecordIndex = nationView.Find(teamName);

                                                    nationView[teamRecordIndex][task.Number] = Convert.ToInt32(nationView[teamRecordIndex][task.Number]) + pilotScore;
                                                }
                                            }
                                        }
                                    }

                                    break;
                                }
                            }






                            //TaskResults classResults = null;

                            //// Check if we have results for this task/class combination
                            //// TODO: Get this from task definition?
                            //foreach (TaskResults tr in task.Results)
                            //{
                            //    if (string.Compare(tr.AircraftClass.Code, aircraftClass.Code, true) == 0)
                            //    {
                            //        classResults = tr;
                            //        break;
                            //    }
                            //}
                            
                            //if (classResults != null)
                            //{
                            //    Dictionary<string, int> taskTeamPilotCounts = new Dictionary<string, int>();

                            //    for (int classIndex = 0; classIndex < task.Results.AircraftClasses.Count; classIndex++)
                            //    {
                            //        if (string.Compare(task.Results.AircraftClasses[classIndex].AircraftClass.Code, classResults.AircraftClass.Code, true) == 0)
                            //        {
                            //            DataTable taskData = task.Results.AircraftClasses[classIndex].Data;
                            //            DataColumn taskScoreColumn = taskData.Columns[task.ScoringSpreadsheet.GetMapping(Column.ColumnType.Score).ColumnName];
                            //            DataColumn taskPilotNumberColumn = taskData.Columns[task.ScoringSpreadsheet.GetMapping(Column.ColumnType.PilotNumber).ColumnName];

                            //            using (DataView taskDataView = new DataView(taskData, "", "[" + taskScoreColumn.ColumnName + "] DESC", DataViewRowState.CurrentRows))
                            //            {
                            //                foreach (DataRowView taskRow in taskDataView)
                            //                {
                            //                    int pilotNumber = Convert.ToInt32(taskRow[taskPilotNumberColumn.ColumnName]);
                            //                    int pilotScore = Convert.ToInt32(taskRow[taskScoreColumn.ColumnName]);

                            //                    // Find pilot so we can get his team name

                            //                    int pilotRecordIndex = pilotView.Find(pilotNumber);

                            //                    string teamName = Convert.ToString(pilotView[pilotRecordIndex][pilotTeamNameColumn.ColumnName]);

                            //                    if (!string.IsNullOrEmpty(teamName))
                            //                    {
                            //                        // Check if pilot scores for the team in this task

                            //                        if (taskTeamPilotCounts.ContainsKey(teamName))
                            //                        {
                            //                            taskTeamPilotCounts[teamName]++;
                            //                        }
                            //                        else
                            //                        {
                            //                            taskTeamPilotCounts.Add(teamName, 1);
                            //                        }

                            //                        if (taskTeamPilotCounts[teamName] <= noWhoScoreInTask)
                            //                        {
                            //                            // Add pilot score to team results

                            //                            int teamRecordIndex = teamView.Find(teamName);

                            //                            teamView[teamRecordIndex][task.Number] = Convert.ToInt32(teamView[teamRecordIndex][task.Number]) + pilotScore;
                            //                        }
                            //                    }
                            //                }
                            //            }

                            //            break;
                            //        }
                            //    }
                            //}



                        }
                    }
                }
            }
        }
    }
}
