using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ColinBaker.Pesto.Models
{
	class Competition
	{
		public const string FileExtension = ".boris";

		public Competition(Services.CompetitionRepository repository)
		{
            this.Repository = repository;

			this.Name = string.Empty;

            this.FrdlIgcPath = string.Empty;
            this.FlymasterIgcPath = string.Empty;
            this.BackupPath = string.Empty;

			this.PilotsSpreadsheet = new Spreadsheets.PilotsSpreadsheet(this);

			this.AircraftClasses = new List<AircraftClass>();

            this.NationDefinitions = new List<NationDefinition>();

            this.Reminders = new Reminders.ReminderCollection(this);

            this.OverallResults = new List<Results.OverallResults>();
            this.TeamResults = new List<Results.TeamResults>();
            this.NationResults = new Results.NationResults(this);

			this.Tasks = new List<Task>();

			this.Features = new List<Features.Feature>();
		}

		public void Save()
		{
            this.Repository.SaveCompetition(this);
		}

		public string GetFolderPath()
		{
            System.IO.FileInfo file = new System.IO.FileInfo(this.Repository.FilePath);

			return file.Directory.FullName;
		}

		public bool IsOnOrAfterLastDay(DateTime date)
		{
            if (date.Date >= this.Finish.Date)
            {
                return true;
            }
			else
			{
				return false;
			}
		}

        public void SyncOverallResultsWithAircraftClasses()
        {
            foreach (Models.AircraftClass competitionClass in this.AircraftClasses)
            {
                bool found = false;

                foreach (Models.Results.OverallResults results in this.OverallResults)
                {
                    if (results.AircraftClass.Code == competitionClass.Code)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    this.OverallResults.Add(new Models.Results.OverallResults(this, competitionClass));
                }
            }

            int i = 0;

            while (i < this.OverallResults.Count)
            {
                Models.Results.OverallResults results = this.OverallResults[i];
                bool found = false;

                foreach (Models.AircraftClass competitionClass in this.AircraftClasses)
                {
                    if (competitionClass.Code == results.AircraftClass.Code)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    this.OverallResults.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        public void SyncTeamResultsWithAircraftClasses()
        {
            foreach (Models.AircraftClass competitionClass in this.AircraftClasses)
            {
                bool found = false;

                foreach (Models.Results.TeamResults results in this.TeamResults)
                {
                    if (results.AircraftClass.Code == competitionClass.Code)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    this.TeamResults.Add(new Models.Results.TeamResults(this, competitionClass));
                }
            }

            int i = 0;

            while (i < this.TeamResults.Count)
            {
                Models.Results.TeamResults results = this.TeamResults[i];
                bool found = false;

                foreach (Models.AircraftClass competitionClass in this.AircraftClasses)
                {
                    if (competitionClass.Code == results.AircraftClass.Code)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    this.TeamResults.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        public Services.CompetitionRepository Repository { get; set; }

		public string Name { get; set; }

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public TimeZoneInfo TimeZone { get; set; }

        public string BackupPath { get; set; }

        public string FrdlIgcPath { get; set; } = string.Empty;
        public string FlymasterIgcPath { get; set; } = string.Empty;
        public string FlymasterApiUsername { get; set; } = string.Empty;
        public string FlymasterApiPassword { get; set; } = string.Empty;
        public string FlymasterApiGroupId { get; set; } = string.Empty;

        public int DefaultPointRadius { get; set; } = Models.Features.PointFeature.DefaultRadius;

        public Spreadsheets.PilotsSpreadsheet PilotsSpreadsheet { get; private set; }

        public List<AircraftClass> AircraftClasses { get; set; }
		public List<Task> Tasks { get; private set; }

		public List<Features.Feature> Features { get; set; }

        public List<NationDefinition> NationDefinitions { get; set; }

        public Reminders.ReminderCollection Reminders { get; set; }

        public List<Results.OverallResults> OverallResults { get; private set; }
        public List<Results.TeamResults> TeamResults { get; private set; }
        public Results.NationResults NationResults { get; private set; }
    }
}
