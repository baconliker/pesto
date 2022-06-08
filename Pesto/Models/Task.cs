using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models
{
	class Task
	{
		public enum TaskType
		{
			Economy,
			Navigation,
			Precision
		}

		public Task(Competition competition)
		{
            this.Competition = competition;
            
			this.LaunchClose = DateTime.MinValue;
			this.LandBy = DateTime.MinValue;

			this.ScoringSpreadsheet = new Spreadsheets.ScoringSpreadsheet(this);

            this.AircraftClasses = new List<AircraftClass>();

            this.Turnpoints = new List<Features.PointFeature>();
			this.HiddenGates = new List<Features.GateFeature>();
            this.NoFlyZones = new List<Features.NoFlyZoneFeature>();

            this.Results = new List<Results.TaskResults>();
        }

		public string GetFolderPath()
		{
			return this.Competition.GetFolderPath() + @"\Task " + String.Format("{0}", this.Number);
		}

		public static string GetTaskTypeDescription(TaskType type)
		{
			switch (type)
			{
				case Models.Task.TaskType.Economy:
					return "Economy";
				case Models.Task.TaskType.Navigation:
					return "Navigation";
				case Models.Task.TaskType.Precision:
					return "Precision";
			}

			return string.Empty;
		}

		public bool IsUsingFeature(Features.Feature feature)
		{
            if (this.TakeOffDeck != null && string.Compare(this.TakeOffDeck.Name, feature.Name, true) == 0)
            {
                return true;
            }

            if (this.LandingDeck != null && string.Compare(this.LandingDeck.Name, feature.Name, true) == 0)
            {
                return true;
            }

            if (this.StartPointOrGate != null && string.Compare(this.StartPointOrGate.Name, feature.Name, true) == 0)
			{
				return true;
			}

			if (this.FinishPointOrGate != null && string.Compare(this.FinishPointOrGate.Name, feature.Name, true) == 0)
			{
				return true;
			}

			foreach (Features.PointFeature turnpoint in this.Turnpoints)
			{
				if (string.Compare(turnpoint.Name, feature.Name, true) == 0)
				{
					return true;
				}
			}

			foreach (Features.GateFeature gate in this.HiddenGates)
			{
				if (string.Compare(gate.Name, feature.Name, true) == 0)
				{
					return true;
				}
			}

            return false;
		}

		public void RemoveFeatureFromUse(Features.Feature feature)
		{
			int turnpointIndex = 0;
			int gateIndex = 0;

            if (this.TakeOffDeck != null && string.Compare(this.TakeOffDeck.Name, feature.Name, true) == 0)
            {
                this.TakeOffDeck = null;
            }

            if (this.LandingDeck != null && string.Compare(this.LandingDeck.Name, feature.Name, true) == 0)
            {
                this.LandingDeck = null;
            }

            if (this.StartPointOrGate != null && string.Compare(this.StartPointOrGate.Name, feature.Name, true) == 0)
			{
				this.StartPointOrGate = null;
			}

			if (this.FinishPointOrGate != null && string.Compare(this.FinishPointOrGate.Name, feature.Name, true) == 0)
			{
				this.FinishPointOrGate = null;
			}

			while (turnpointIndex < this.Turnpoints.Count)
			{
				if (string.Compare(this.Turnpoints[turnpointIndex].Name, feature.Name, true) == 0)
				{
					this.Turnpoints.RemoveAt(turnpointIndex);
				}
				else
				{
					turnpointIndex++;
				}
			}

			while (gateIndex < this.HiddenGates.Count)
			{
				if (string.Compare(this.HiddenGates[gateIndex].Name, feature.Name, true) == 0)
				{
					this.HiddenGates.RemoveAt(gateIndex);
				}
				else
				{
					gateIndex++;
				}
			}
		}

        public void SyncTaskResultsWithAircraftClasses()
        {
            foreach (Models.AircraftClass taskClass in this.AircraftClasses)
            {
                bool found = false;

                foreach (Models.Results.TaskResults results in this.Results)
                {
                    if (results.AircraftClass.Code == taskClass.Code)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    this.Results.Add(new Models.Results.TaskResults(this, taskClass));
                }
            }

            int i = 0;

            while (i < this.Results.Count)
            {
                Models.Results.TaskResults results = this.Results[i];
                bool found = false;

                foreach (Models.AircraftClass taskClass in this.AircraftClasses)
                {
                    if (taskClass.Code == results.AircraftClass.Code)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    this.Results.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        public int Number { get; set; }
		public string Name { get; set; }
        public string AbbreviatedName { get; set; }
        public TaskType Type { get; set; }
		public DateTime LaunchOpen { get; set; }
		public DateTime LaunchClose { get; set; }
		public DateTime LandBy { get; set; }

		public Spreadsheets.ScoringSpreadsheet ScoringSpreadsheet { get; private set; }

		// Features used for track analysis
        public Features.DeckFeature TakeOffDeck { get; set; }
        public Features.DeckFeature LandingDeck { get; set; }
        public Features.Feature StartPointOrGate { get; set; }
		public Features.Feature FinishPointOrGate { get; set; }
		public List<Features.PointFeature> Turnpoints { get; set; }
		public List<Features.GateFeature> HiddenGates { get; set; }

        public List<AircraftClass> AircraftClasses { get; set; }

        public List<Features.NoFlyZoneFeature> NoFlyZones { get; set; }

		public List<ManualTrack> ManualTracks = new List<ManualTrack>();

        public List<Results.TaskResults> Results { get; private set; }
        
        public Competition Competition { get; set; }

		public bool LaunchCloseSet
		{
			get
			{
				return (this.LaunchClose != DateTime.MinValue);
			}
		}

		public bool LandBySet
		{
			get
			{
				return (this.LandBy != DateTime.MinValue);
			}
		}

		public TrackAnalysis.Events.TrackEvent.EventType[] EventTypeFilters { get; set; } = TrackAnalysis.Events.TrackEvent.DefaultEventTypeFilters;
	}
}
