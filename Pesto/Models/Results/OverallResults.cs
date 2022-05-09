using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Results
{
    class OverallResults : Results
    {
        public OverallResults(Competition competition, AircraftClass aircraftClass)
        {
            this.AircraftClass = aircraftClass;

            this.Competition = competition;
        }

		public override void Generate(ResultsGenerationOptions options)
        {
            Services.SettingsStore store = new Services.SettingsStore();

            if (string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationName) || string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationKey))
            {
                throw new ResultsGenerationException("Bytescout Spreadsheet registration details not set. Please set these details in the Options screen.");
            }

            OverallResultsGenerationOptions specificOptions = options as OverallResultsGenerationOptions;

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
                    }
                }
            }

            GenerateClass(tasksToGenerate);

            this.Published = DateTime.Now;

            this.Loaded = true;
        }

        public override void Load()
        {
            this.Competition.Repository.LoadOverallResults(this);
            this.Loaded = true;
        }

        public override void Save()
        {
            this.Competition.Repository.SaveOverallResults(this);
        }

        public override void Publish()
        {
            Services.ResultsPublisher publisher = new Services.ResultsPublisher(this.Competition.Repository.FilePath);
            publisher.PublishOverallResults(this);
        }

        public override string GetPublishedFilePath()
        {
            Services.ResultsPublisher publisher = new Services.ResultsPublisher(this.Competition.Repository.FilePath);
            return publisher.GetPublishedOverallResultsFilePath(this);
        }

        public override bool Exists()
        {
            return this.Competition.Repository.OverallResultsExists(this);
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
				if (pilotData.Rows.Count == 0)
				{
					throw new ResultsGenerationException("No pilots found for class " + this.AircraftClass.Code + " (" + this.AircraftClass.Description + ")");
				}

				Results.CheckResultDataContainsMappedColumns(pilotData, this.Competition.PilotsSpreadsheet, this.AircraftClass);

                DataTable competitionData = pilotData.Copy();
                DataColumn competitionPilotNumberColumn = competitionData.Columns[this.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.PilotNumber).ColumnName];

                using (DataView competitionView = new DataView(competitionData, "", "[" + competitionPilotNumberColumn.ColumnName + "]", DataViewRowState.CurrentRows))
                {
					foreach (Task task in tasksToGenerate)
                    {
                        foreach (TaskResults taskResults in task.Results)
                        {
                            if (taskResults.AircraftClass.Code == this.AircraftClass.Code)
                            {
                                DataTable taskData = taskResults.Data;
                                DataColumn taskPilotNumberColumn = taskData.Columns[task.ScoringSpreadsheet.GetMapping(Column.ColumnType.PilotNumber).ColumnName];
                                DataColumn taskScoreColumn = taskData.Columns[task.ScoringSpreadsheet.GetMapping(Column.ColumnType.Score).ColumnName];

                                using (DataView taskView = new DataView(taskData, "", "[" + taskPilotNumberColumn.ColumnName + "]", DataViewRowState.CurrentRows))
                                {
                                    DataColumn copiedColumn = Results.CopyColumn(taskScoreColumn, taskView, taskPilotNumberColumn, competitionView, competitionPilotNumberColumn);

                                    // Change the name and properties of the copied column
                                    copiedColumn.ColumnName = "Task " + string.Format("{0}", task.Number) + " - " + task.Name;
                                    copiedColumn.ExtendedProperties["DisplayName"] = "Task " + string.Format("{0}", task.Number) + Environment.NewLine + (task.AbbreviatedName.Length > 0 ? task.AbbreviatedName : task.Name) + Environment.NewLine + task.LaunchOpen.ToString("dd MMM") + Environment.NewLine + Models.Results.TaskResults.GetResultsStatusDescription(taskResults.Status);
                                    copiedColumn.ExtendedProperties["Bold"] = false;
                                }

                                break;
                            }
                        }
                    }

                    DataColumn totalColumn = AddTotalScoreColumn(competitionData);

                    string pilotNameColumnName = this.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.PilotName).ColumnName;

                    // Sort default view by the total score column
                    competitionData.DefaultView.Sort = "[" + totalColumn.ColumnName + "] DESC, [" + pilotNameColumnName + "] ASC";

					AddPositionColumn(competitionData.DefaultView, totalColumn.ColumnName);

					// Compare against existing data (from previous generation) and copy across column extended properties
					if (this.Data != null)
					{
                        // Do not copy display name from previous generation. This is so that display names are reset every time and therefore reflect the correct task status
                        // TODO: Find a better solution
                        CopyColumnProperties(this.Data, competitionData, false);
                    }

                    this.Data = competitionData;
                }
            }
        }
    }
}
