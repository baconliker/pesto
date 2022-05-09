using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	abstract class TrackEvent
	{
		public enum EventType
		{
			FirstFix,
			LastFix,
			FixLost,
			InitialAscent,
			BelowMinAltitude,
			FinalDescent,
			StartPointHit,
			StartPointNotHit,
			FinishPointHit,
			FinishPointNotHit,
			TurnpointHit,
			DuplicateTurnpointHit,
            StartGateHit,
            StartGateNotHit,
            FinishGateHit,
            FinishGateNotHit,
			HiddenGateHit,
			DuplicateHiddenGateHit,
			NoFlyZoneIncursion,
			TakeOff,
            TakeOffOutsideAirfield,
            TakeOffOutsideDeck,
			TakeOffBeforeWindowOpen,
			TakeOffAfterWindowClose,
			Landing,
            LandingOutsideAirfield,
            LandingOutsideDeck,
            LandingAfterWindowClose
		}

		public enum EventCategory
		{
			Gps,
			Altitude,
			Point,
			Gate,
			NoFlyZone,
			TakeOffLanding
		}

		public enum EventClassification
		{
			Information,
			Achievement,
			Warning,
			Failure
		}

        public static readonly EventType[] AllTypes = {
            EventType.FirstFix,
            EventType.LastFix,
            EventType.FixLost,
            EventType.InitialAscent,
            EventType.BelowMinAltitude,
            EventType.FinalDescent,
            EventType.StartPointHit,
            EventType.StartPointNotHit,
            EventType.FinishPointHit,
            EventType.FinishPointNotHit,
            EventType.TurnpointHit,
            EventType.DuplicateTurnpointHit,
            EventType.StartGateHit,
            EventType.StartGateNotHit,
            EventType.FinishGateHit,
            EventType.FinishGateNotHit,
            EventType.HiddenGateHit,
            EventType.DuplicateHiddenGateHit,
            EventType.NoFlyZoneIncursion,
            EventType.TakeOff,
            EventType.TakeOffOutsideAirfield,
            EventType.TakeOffOutsideDeck,
            EventType.TakeOffBeforeWindowOpen,
            EventType.TakeOffAfterWindowClose,
            EventType.Landing,
            EventType.LandingOutsideAirfield,
            EventType.LandingOutsideDeck,
            EventType.LandingAfterWindowClose
        };

		protected TrackEvent(EventType type)
		{
			this.Type = type;

			switch (this.Type)
			{
				case EventType.FirstFix:
					this.Category = EventCategory.Gps;
					this.Classification = EventClassification.Information;
					break;

				case EventType.LastFix:
					this.Category = EventCategory.Gps;
					this.Classification = EventClassification.Information;
					break;

				case EventType.FixLost:
					this.Category = EventCategory.Gps;
					this.Classification = EventClassification.Warning;
					break;

				case EventType.InitialAscent:
					this.Category = EventCategory.Altitude;
					this.Classification = EventClassification.Information;
					break;

				case EventType.BelowMinAltitude:
					this.Category = EventCategory.Altitude;
					this.Classification = EventClassification.Failure;
					break;

				case EventType.FinalDescent:
					this.Category = EventCategory.Altitude;
					this.Classification = EventClassification.Information;
					break;

				case EventType.StartPointHit:
					this.Category = EventCategory.Point;
					this.Classification = EventClassification.Achievement;
					break;

				case EventType.StartPointNotHit:
					this.Category = EventCategory.Point;
					this.Classification = EventClassification.Failure;
					break;

				case EventType.FinishPointHit:
					this.Category = EventCategory.Point;
					this.Classification = EventClassification.Achievement;
					break;

				case EventType.FinishPointNotHit:
					this.Category = EventCategory.Point;
					this.Classification = EventClassification.Failure;
					break;

				case EventType.TurnpointHit:
					this.Category = EventCategory.Point;
					this.Classification = EventClassification.Achievement;
					break;

				case EventType.DuplicateTurnpointHit:
					this.Category = EventCategory.Point;
					this.Classification = EventClassification.Warning;
					break;

                case EventType.StartGateHit:
                    this.Category = EventCategory.Gate;
                    this.Classification = EventClassification.Achievement;
                    break;

                case EventType.StartGateNotHit:
                    this.Category = EventCategory.Gate;
                    this.Classification = EventClassification.Failure;
                    break;

                case EventType.FinishGateHit:
                    this.Category = EventCategory.Gate;
                    this.Classification = EventClassification.Achievement;
                    break;

                case EventType.FinishGateNotHit:
                    this.Category = EventCategory.Gate;
                    this.Classification = EventClassification.Failure;
                    break;

				case EventType.HiddenGateHit:
					this.Category = EventCategory.Gate;
					this.Classification = EventClassification.Achievement;
					break;

				case EventType.DuplicateHiddenGateHit:
					this.Category = EventCategory.Gate;
					this.Classification = EventClassification.Warning;
					break;

				case EventType.NoFlyZoneIncursion:
					this.Category = EventCategory.NoFlyZone;
					this.Classification = EventClassification.Failure;
					break;

				case EventType.TakeOff:
					this.Category = EventCategory.TakeOffLanding;
					this.Classification = EventClassification.Information;
					break;

                case EventType.TakeOffOutsideAirfield:
                    this.Category = EventCategory.TakeOffLanding;
                    this.Classification = EventClassification.Failure;
                    break;

                case EventType.TakeOffOutsideDeck:
                    this.Category = EventCategory.TakeOffLanding;
                    this.Classification = EventClassification.Failure;
                    break;

                case EventType.TakeOffBeforeWindowOpen:
					this.Category = EventCategory.TakeOffLanding;
					this.Classification = EventClassification.Failure;
					break;

				case EventType.TakeOffAfterWindowClose:
					this.Category = EventCategory.TakeOffLanding;
					this.Classification = EventClassification.Failure;
					break;

				case EventType.Landing:
					this.Category = EventCategory.TakeOffLanding;
					this.Classification = EventClassification.Information;
					break;

                case EventType.LandingOutsideAirfield:
                    this.Category = EventCategory.TakeOffLanding;
                    this.Classification = EventClassification.Failure;
                    break;

                case EventType.LandingOutsideDeck:
                    this.Category = EventCategory.TakeOffLanding;
                    this.Classification = EventClassification.Failure;
                    break;

                case EventType.LandingAfterWindowClose:
					this.Category = EventCategory.TakeOffLanding;
					this.Classification = EventClassification.Failure;
					break;

				default:
					throw new ApplicationException("Event type does not have a category associated with it.");
			}

			this.Time = DateTime.MinValue;
			this.Sequence = 1;
		}

		public static string FormatCategoryDescription(EventCategory category)
		{
			string description = string.Empty;

			switch (category)
			{
				case EventCategory.Gps:
					description = "GPS";
					break;

				case EventCategory.Altitude:
					description = "Altitude";
					break;

				case EventCategory.Point:
					description = "Point";
					break;

				case EventCategory.Gate:
					description = "Gate";
					break;

				case EventCategory.NoFlyZone:
					description = "No Fly Zone";
					break;

				case EventCategory.TakeOffLanding:
					description = "Take-Off / Landing";
					break;
			}

			return description;
		}

		public abstract string Description { get; }

		public EventType Type { get; private set; }
		public EventCategory Category { get; private set; }
		public EventClassification Classification { get; private set; }

		public DateTime Time { get; set; }
		public Geolocation.Location Location { get; set; }
		public int Sequence { get; set; } // Used to differentiate when two or more events are triggered for the same fix/time
        public Features.Feature RelatedFeature { get; set; }

		public bool TimeSet
		{
			get
			{
				return (this.Time != DateTime.MinValue);
			}
		}
	}
}
