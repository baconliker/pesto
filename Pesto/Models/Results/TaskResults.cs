using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Data;

namespace ColinBaker.Pesto.Models.Results
{
    class TaskResults : Results
    {
        public enum ResultsStatus
        {
			Interim,
            Provisional,
            Official,
            Final,
            Cancelled
        }

        // TODO: Make these configurable settings
		//private const int m_complaintDeadlineHours = 4;
		//private const int m_complaintDeadlineHoursFinalDay = 1; // On the final day of competition the deadline window is smaller
        private const int m_complaintDeadlineHours = 6;
        private const int m_complaintDeadlineHoursFinalDay = 2; // On the final day of competition the deadline window is smaller

        private const int m_complaintDeadlineWindowOpenHour = 7;
		private const int m_complaintDeadlineWindowCloseHour = 22;

		public TaskResults(Task task, AircraftClass aircraftClass)
		{
            this.Task = task;
            this.AircraftClass = aircraftClass;

            this.Status = ResultsStatus.Interim;
		}

		public override void Generate(ResultsGenerationOptions options)
		{
            // Check spreadsheet mappings have been completed
            if (!this.Task.Competition.PilotsSpreadsheet.MappingsComplete())
            {
                throw new ResultsGenerationException("Pilot mappings not defined.");
            }
            if (!this.Task.ScoringSpreadsheet.MappingsComplete())
            {
                throw new ResultsGenerationException("Scoring mappings not defined.");
            }

			Services.SettingsStore store = new Services.SettingsStore();

			if (string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationName) || string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationKey))
			{
				throw new ResultsGenerationException("Bytescout Spreadsheet registration details not set. Please set these details in the Options screen.");
			}

			try
            {
                GenerateClass();
            }
            catch (Exception ex)
            {
                throw new ResultsGenerationException(string.Format("Error generating results ({0})", ex.Message), ex);
            }

            this.Published = DateTime.Now;
            this.Deadline = CalculateComplaintDeadline(this.Task, this.Published);

            this.Loaded = true;
		}

        public override void Load()
        {
            this.Task.Competition.Repository.LoadTaskResults(this);
            this.Loaded = true;
        }

		public override void Save()
		{
            this.Task.Competition.Repository.SaveTaskResults(this);
		}

        public override void Publish()
        {
            Services.ResultsPublisher publisher = new Services.ResultsPublisher(this.Task.Competition.Repository.FilePath);
            publisher.PublishTaskResults(this);
        }

        public override string GetPublishedFilePath()
        {
            Services.ResultsPublisher publisher = new Services.ResultsPublisher(this.Task.Competition.Repository.FilePath);
            return publisher.GetPublishedTaskResultsFilePath(this);
        }

        public override bool Exists()
        {
            return this.Task.Competition.Repository.TaskResultsExists(this);
        }

		public static DateTime CalculateComplaintDeadline(Task task, DateTime published)
		{
			DateTime deadline;
			DateTime start;

			if (published.Hour < m_complaintDeadlineWindowOpenHour)
			{
				start = new DateTime(published.Year, published.Month, published.Day, m_complaintDeadlineWindowOpenHour, 0, 0);
			}
			else if (published.Hour >= m_complaintDeadlineWindowCloseHour)
			{
				DateTime nextDay = new DateTime(published.AddDays(1).Year, published.AddDays(1).Month, published.AddDays(1).Day);

				start = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, m_complaintDeadlineWindowOpenHour, 0, 0);
			}
			else
			{
				start = published;
			}

			int hoursToAdd = GetComplaintDeadlineHours(task.Competition, start);

			DateTime windowClose = new DateTime(start.Year, start.Month, start.Day, m_complaintDeadlineWindowCloseHour, 0, 0);

			// Have we got enough hours remaining in the current day to fit the deadline in?
			int hoursBeforeWindowClose = windowClose.Subtract(start).Hours;

			if (hoursBeforeWindowClose >= hoursToAdd)
			{
				deadline = start.AddHours(hoursToAdd);
			}
			else
			{
				// Deadline will 'wrap' onto the next day

				int hoursAdded = 0;

				deadline = start;

				while (hoursAdded < hoursToAdd)
				{
					deadline = deadline.AddHours(1);

					DateTime windowOpen = new DateTime(deadline.Year, deadline.Month, deadline.Day, m_complaintDeadlineWindowOpenHour, 0, 0);
					windowClose = new DateTime(deadline.Year, deadline.Month, deadline.Day, m_complaintDeadlineWindowCloseHour, 0, 0);

					if (deadline >= windowOpen && deadline <= windowClose)
					{
						hoursAdded++;
					}
				}

				if (task.Competition.IsOnOrAfterLastDay(deadline))
				{
					// The complaint deadline is shorter on the final day so make sure we haven't exceeded it

					int finalDayHours = GetComplaintDeadlineHours(task.Competition, deadline);

					DateTime latestDeadline = new DateTime(deadline.Year, deadline.Month, deadline.Day, m_complaintDeadlineWindowOpenHour + finalDayHours, 0, 0);

					if (deadline > latestDeadline)
					{
						deadline = latestDeadline;
					}
				}
			}

			return deadline;
		}

		public static string GetResultsStatusDescription(ResultsStatus status)
		{
			switch (status)
			{
				case ResultsStatus.Interim:
					return "Interim";
				case ResultsStatus.Provisional:
					return "Provisional";
				case ResultsStatus.Official:
					return "Official";
				case ResultsStatus.Final:
					return "Final";
                case ResultsStatus.Cancelled:
                    return "Cancelled";
			}

			return string.Empty;
		}

        public void ZeroScores()
        {
            string scoreColumnName = this.Task.ScoringSpreadsheet.GetMapping(Column.ColumnType.Score).ColumnName;

            foreach (DataRow row in this.Data.Rows)
            {
                row[scoreColumnName] = 0;
            }
        }

        public ResultsStatus Status { get; set; }
        public DateTime Published { get; set; }
        public DateTime Deadline { get; set; }

        public AircraftClass AircraftClass { get; set; }

        public System.Data.DataTable Data { get; set; }

        public int FontSize { get; set; }

		public Task Task { get; set; }

		private void GenerateClass()
		{
			using (DataTable scoringData = this.Task.ScoringSpreadsheet.GetData(this.AircraftClass.Code))
			{
				CheckResultDataContainsMappedColumns(scoringData, this.Task.ScoringSpreadsheet, this.AircraftClass);

				using (DataTable pilotData = this.Task.Competition.PilotsSpreadsheet.GetData(this.AircraftClass.Code))
				{
					if (pilotData.Rows.Count == 0)
					{
						throw new ResultsGenerationException("No pilots found for class " + this.AircraftClass.Code + " (" + this.AircraftClass.Description + ")");
					}

					CheckResultDataContainsMappedColumns(pilotData, this.Task.Competition.PilotsSpreadsheet, this.AircraftClass);

					// Get the names of the columns containing the pilot number, this is how we'll match scores to pilot details
                    string pilotPilotNumberColumnName = this.Task.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.PilotNumber).ColumnName;
                    string scoringPilotNumberColumnName = this.Task.ScoringSpreadsheet.GetMapping(Column.ColumnType.PilotNumber).ColumnName;

					// Check that we have scores for this task for all pilots
					CheckAllPilotsHaveScores(pilotData, pilotPilotNumberColumnName, scoringData, scoringPilotNumberColumnName);

					DataTable combinedData = CombineData(pilotData, pilotPilotNumberColumnName, scoringData, scoringPilotNumberColumnName);
						
					// Get the name of the column containing the task score
                    string scoreColumnName = this.Task.ScoringSpreadsheet.GetMapping(Column.ColumnType.Score).ColumnName;
                    string pilotNameColumnName = this.Task.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.PilotName).ColumnName;

                    combinedData.DefaultView.Sort = "[" + scoreColumnName + "] DESC, [" + pilotNameColumnName + "] ASC";
                    combinedData.DefaultView.RowFilter = "[" + scoreColumnName + "] IS NOT NULL";

                    AddPositionColumn(combinedData.DefaultView, scoreColumnName);

                    // Compare against existing data (from previous generation) and copy across column extended properties
                    if (this.Data != null)
                    {
                        CopyColumnProperties(this.Data, combinedData, true);
                    }

					this.Data = combinedData;
				}
			}
		}

		private void CheckAllPilotsHaveScores(DataTable pilotData, string pilotPilotNumberColumnName, DataTable scoringData, string scoringPilotNumberColumnName)
		{
			string pilotPilotNameColumnName = this.Task.Competition.PilotsSpreadsheet.GetMapping(Column.ColumnType.PilotName).ColumnName;

			using (DataView scoringView = new DataView(scoringData, string.Empty, scoringPilotNumberColumnName, DataViewRowState.CurrentRows))
			{
				foreach (DataRow row in pilotData.Rows)
				{
					int pilotNumber = (int)row[pilotPilotNumberColumnName];

					// Try and find this pilot in the task scores
					if (scoringView.Find(pilotNumber) == -1)
					{
						throw new ResultsGenerationException("Pilot " + pilotNumber.ToString() + " (" + row[pilotPilotNameColumnName].ToString() + ") does not have a score for task " + string.Format("{0}", this.Task.Number) + " (" + this.Task.Name + ")");
					}
				}
			}
		}

		private DataTable CombineData(DataTable pilotData, string pilotPilotNumberColumnName, DataTable scoringData, string scoringPilotNumberColumnName)
		{
			DataTable combinedData = pilotData.Copy();

			DataColumn combinedPilotNumberColumn = combinedData.Columns[pilotPilotNumberColumnName];
			DataColumn scoringPilotNumberColumn = scoringData.Columns[scoringPilotNumberColumnName];

			using (DataView combinedView = new DataView(combinedData, "", "[" + combinedPilotNumberColumn.ColumnName + "]", DataViewRowState.CurrentRows))
			{
				using (DataView scoringView = new DataView(scoringData, "", "[" + scoringPilotNumberColumn.ColumnName + "]", DataViewRowState.CurrentRows))
				{
					foreach (DataColumn scoringSourceColumn in scoringData.Columns)
					{
						if (!combinedData.Columns.Contains(scoringSourceColumn.ColumnName))
						{
                            CopyColumn(scoringSourceColumn, scoringView, scoringPilotNumberColumn, combinedView, combinedPilotNumberColumn);
						}
					}
				}
			}

			return combinedData;
		}
        
		private static int GetComplaintDeadlineHours(Competition competition, DateTime date)
		{
			if (competition.IsOnOrAfterLastDay(date))
			{
				return m_complaintDeadlineHoursFinalDay;
			}
			else
			{
				return m_complaintDeadlineHours;
			}
		}
    }
}
