using ColinBaker.Pesto.Models.Features;
using org.apache.batik.svggen.font.table;
using System;
using System.Collections;
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
			this.PointsOfInterest = new List<Features.PointOfInterestFeature>();
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
            if (this.TakeOffDeck != null && string.Equals(this.TakeOffDeck.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (this.LandingDeck != null && string.Equals(this.LandingDeck.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (this.StartPointOrGate != null && string.Equals(this.StartPointOrGate.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}

			if (this.FinishPointOrGate != null && string.Equals(this.FinishPointOrGate.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}

			if (this.ElapsedTimePointOrGate != null && string.Equals(this.ElapsedTimePointOrGate.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}

			foreach (Features.PointFeature turnpoint in this.Turnpoints)
			{
				if (string.Equals(turnpoint.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}

			foreach (Features.GateFeature gate in this.HiddenGates)
			{
				if (string.Equals(gate.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}

			foreach (Features.PointOfInterestFeature poi in this.PointsOfInterest)
			{
				if (string.Equals(poi.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}

			foreach (Features.NoFlyZoneFeature nfz in this.NoFlyZones)
			{
				if (string.Equals(nfz.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}

			return false;
		}

		public void RemoveFeatureFromUse(Features.Feature feature)
		{
            if (this.TakeOffDeck != null && string.Equals(this.TakeOffDeck.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
            {
                this.TakeOffDeck = null;
            }

            if (this.LandingDeck != null && string.Equals(this.LandingDeck.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
            {
                this.LandingDeck = null;
            }

            if (this.StartPointOrGate != null && string.Equals(this.StartPointOrGate.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
			{
				this.StartPointOrGate = null;
			}

			if (this.FinishPointOrGate != null && string.Equals(this.FinishPointOrGate.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
			{
				this.FinishPointOrGate = null;
			}

			if (this.ElapsedTimePointOrGate != null && string.Equals(this.ElapsedTimePointOrGate.Name, feature.Name, StringComparison.OrdinalIgnoreCase))
			{
				this.ElapsedTimePointOrGate = null;
			}

			RemoveFeatureFromList(feature.Name, this.Turnpoints);
			RemoveFeatureFromList(feature.Name, this.HiddenGates);
			RemoveFeatureFromList(feature.Name, this.PointsOfInterest);
			RemoveFeatureFromList(feature.Name, this.NoFlyZones);
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
		public Features.Feature ElapsedTimePointOrGate { get; set; }

		public List<Features.PointFeature> Turnpoints { get; set; }
		public List<Features.GateFeature> HiddenGates { get; set; }
		public List<Features.PointOfInterestFeature> PointsOfInterest { get; set; }
		public List<Features.NoFlyZoneFeature> NoFlyZones { get; set; }

		public List<AircraftClass> AircraftClasses { get; set; }

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

		private static void RemoveFeatureFromList(string featureName, IList features)
		{
			int listIndex = 0;

			while (listIndex < features.Count)
			{
				if (string.Equals(((Features.Feature)features[listIndex]).Name, featureName, StringComparison.OrdinalIgnoreCase))
				{
					features.RemoveAt(listIndex);
				}
				else
				{
					listIndex++;
				}
			}
		}
	}
}
