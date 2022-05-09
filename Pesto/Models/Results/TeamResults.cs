using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Results
{
    class TeamResults : Results
    {
        private const int m_minTeamSize = 8;
        private const int m_noWhoScoreInTask = 3;

        public TeamResults(Competition competition, AircraftClass aircraftClass)
        {
            this.Competition = competition;

			this.AircraftClass = aircraftClass;
        }

		public override void Generate(ResultsGenerationOptions options)
		{
            Services.SettingsStore store = new Services.SettingsStore();

            if (string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationName) || string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationKey))
            {
                throw new ResultsGenerationException("Bytescout Spreadsheet registration details not set. Please set these details in the Options screen.");
            }

            TeamResultsGenerationOptions specificOptions = options as TeamResultsGenerationOptions;

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

            // Make sure all task results have been generated and are loaded
            foreach (Task task in tasksToGenerate)
            {
                foreach (TaskResults results in task.Results)
                {
                    if (results.AircraftClass.Code == this.AircraftClass.Code)
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
                                    throw new ResultsGenerationException(string.Format("Unable to load results for task {0}.", task.Number));
                                }
                            }
                            else
                            {
                                throw new ResultsGenerationException(string.Format("Results have not yet been generated for task {0}.", task.Number));
                            }
                        }

                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(this.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.TeamName).ColumnName))
			{
				throw new ResultsGenerationException("Team name mapping not set.");
			}

            GenerateClass(tasksToGenerate);

            this.Published = DateTime.Now;

            this.Loaded = true;
		}

        public override void Load()
        {
            this.Competition.Repository.LoadTeamResults(this);
            this.Loaded = true;
        }

        public override void Save()
        {
            this.Competition.Repository.SaveTeamResults(this);
        }

        public override void Publish()
        {
            Services.ResultsPublisher publisher = new Services.ResultsPublisher(this.Competition.Repository.FilePath);
            publisher.PublishTeamResults(this);
        }

        public override string GetPublishedFilePath()
        {
            Services.ResultsPublisher publisher = new Services.ResultsPublisher(this.Competition.Repository.FilePath);
            return publisher.GetPublishedTeamResultsFilePath(this);
        }

        public override bool Exists()
        {
            return this.Competition.Repository.TeamResultsExists(this);
        }

        public DateTime Published { get; set; }

        public AircraftClass AircraftClass { get; set; }

        public System.Data.DataTable Data { get; set; }

        public int FontSize { get; set; }

        public Competition Competition { get; set; }

        private void GenerateClass(List<Task> tasksToGenerate)
        {
            using (DataTable pilotData = this.Competition.PilotsSpreadsheet.GetData(this.AircraftClass.Code))
            {
                if (pilotData.Rows.Count < m_minTeamSize)
                {
                    throw new ResultsGenerationException("Less than 8 pilots found for class " + this.AircraftClass.Code + " (" + this.AircraftClass.Description + ")");
                }

                Results.CheckResultDataContainsMappedColumns(pilotData, this.Competition.PilotsSpreadsheet, this.AircraftClass);

                DataColumn pilotPilotNumberColumn = pilotData.Columns[this.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.PilotNumber).ColumnName];
                DataColumn pilotTeamNameColumn = pilotData.Columns[this.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.TeamName).ColumnName];

                using (DataView pilotView = new DataView(pilotData, "", "[" + pilotPilotNumberColumn.ColumnName + "]", DataViewRowState.CurrentRows))
                {
                    DataTable teamData = new DataTable();

                    teamData.Columns.Add(Results.CreateColumn("Team Name", typeof(string), Column.ColumnType.TeamName, Column.ColumnAlignment.Left));

                    using (DataView teamView = new DataView(teamData, "", "[Team Name]", DataViewRowState.CurrentRows))
                    {
                        // Add teams to results

                        foreach (DataRow pilotRow in pilotData.Rows)
                        {
                            string teamName = Convert.ToString(pilotRow[pilotTeamNameColumn.ColumnName]);

                            if (!string.IsNullOrEmpty(teamName))
                            {
                                int teamRecordIndex = teamView.Find(teamName);

                                if (teamRecordIndex == -1)
                                {
                                    DataRow newTeamRow = teamData.Rows.Add();

                                    newTeamRow["Team Name"] = teamName;
                                }
                            }
                        }

                        // Add task scores to results

                        foreach (Task task in tasksToGenerate)
                        {
                            Dictionary<string, int> taskTeamPilotCounts = new Dictionary<string, int>();

                            foreach (TaskResults taskResults in task.Results)
                            {
                                if (taskResults.AircraftClass == this.AircraftClass)
                                {
                                    DataColumn taskColumn = Results.CreateColumn(string.Format("Task {0} - {1}", task.Number, task.Name), typeof(int), Column.ColumnType.Score, Column.ColumnAlignment.Right);
                                    taskColumn.ExtendedProperties["DisplayName"] = string.Format("Task {0}\n{1}\n{2:dd MMM}\n{3}", task.Number, (task.AbbreviatedName.Length > 0 ? task.AbbreviatedName : task.Name), this.Published, TaskResults.GetResultsStatusDescription(taskResults.Status));
                                    taskColumn.DefaultValue = 0;
                                    teamData.Columns.Add(taskColumn);

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

                                            string teamName = Convert.ToString(pilotView[pilotRecordIndex][pilotTeamNameColumn.ColumnName]);

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

                                                if (taskTeamPilotCounts[teamName] <= m_noWhoScoreInTask)
                                                {
                                                    // Add pilot score to team results

                                                    int teamRecordIndex = teamView.Find(teamName);

                                                    teamView[teamRecordIndex][taskColumn.Ordinal] = Convert.ToInt32(teamView[teamRecordIndex][taskColumn.Ordinal]) + pilotScore;
                                                }
                                            }
                                        }
                                    }

                                    break;
                                }
                            }
                        }
                    }

                    DataColumn totalColumn = AddTotalScoreColumn(teamData);

                    // Sort default view by the total score column
                    teamData.DefaultView.Sort = "[" + totalColumn.ColumnName + "] DESC, [Team Name] ASC";

                    AddPositionColumn(teamData.DefaultView, totalColumn.ColumnName);

                    // Compare against existing data (from previous generation) and copy across column extended properties
                    if (this.Data != null)
                    {
                        CopyColumnProperties(this.Data, teamData, false);
                    }

                    this.Data = teamData;
                }
            }
        }
    }
}
