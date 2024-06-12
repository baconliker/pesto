using ColinBaker.Pesto.Models.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Analyzers
{
	class PointCategoryAnalyzer : IAnalyzer
	{
		public event EventHandler<EventOccurredEventArgs> EventOccurred;

		private PointState m_startPointState;
		private PointState m_finishPointState;

		private List<PointState> m_turnpointStates;

        private Geolocation.HaversineDistanceCalculator m_distanceCalculator = new Geolocation.HaversineDistanceCalculator();

		public PointCategoryAnalyzer(Task task)
		{
			this.Task = task;

			if (this.Task.StartPointOrGate != null && this.Task.StartPointOrGate.Type == Features.Feature.FeatureType.Point)
			{
				m_startPointState = new PointState(PointState.PointType.Start, this.Task.StartPointOrGate as Features.PointFeature);
			}
			if (this.Task.FinishPointOrGate != null && this.Task.FinishPointOrGate.Type == Features.Feature.FeatureType.Point)
			{
				m_finishPointState = new PointState(PointState.PointType.Finish, this.Task.FinishPointOrGate as Features.PointFeature);
			}

			m_turnpointStates = new List<PointState>();

			foreach (Features.PointFeature point in task.Turnpoints)
			{
				m_turnpointStates.Add(new PointState(PointState.PointType.Turn, point));
			}
		}

		public void AnalyzeFix(Geolocation.Tracks.Track track, int fixIndex)
		{
			if (m_startPointState != null)
			{
				CheckPointState(m_startPointState, ref track, fixIndex);
			}

			if (m_finishPointState != null)
			{
				CheckPointState(m_finishPointState, ref track, fixIndex);
			}

			foreach (PointState pointState in m_turnpointStates)
			{
				CheckPointState(pointState, ref track, fixIndex);
			}

			// Check for finish point being hit. This is done here because it involves comparison of start and finish points
			if (m_finishPointState != null && fixIndex == track.Fixes.Count - 1)
			{
				if (m_finishPointState.Visits.Count > 0)
				{
					if (m_startPointState == null)
					{
                        // TODO: Should this be the first visit, not the last visit? Surely we need both a start and finish point to be defined
						FinishPointHit(m_finishPointState.Point, m_finishPointState.LastVisit.ClosestFix);
					}
					else
					{
                        // TODO: Should this be the second visit, not the last visit?
						if (string.Compare(m_finishPointState.Point.Name, m_startPointState.Point.Name, true) == 0 && m_finishPointState.LastVisit.ClosestFix.Time == m_startPointState.FirstVisit.ClosestFix.Time)
						{
							FinishPointNotHit(m_finishPointState.Point);
						}
						else
						{
							FinishPointHit(m_finishPointState.Point, m_finishPointState.LastVisit.ClosestFix);
						}
					}
				}
				else
				{
					FinishPointNotHit(m_finishPointState.Point);
				}
			}
		}

		public Task Task { get; set; }

		private void CheckPointState(PointState pointState, ref Geolocation.Tracks.Track track, int fixIndex)
		{
            double distanceToCentre;

            if (IsWithinPoint(track.Fixes[fixIndex], pointState.Point, out distanceToCentre))
			{
				if (!pointState.WithinCylinder)
				{
					// We've just entered a point

					pointState.WithinCylinder = true;
					pointState.Visits.Add(new PointVisit((pointState.Point.Shape as Models.Features.Circle).Radius));
				}

				if (distanceToCentre < pointState.LastVisit.ClosestDistance)
				{
					pointState.LastVisit.ClosestDistance = distanceToCentre;
					pointState.LastVisit.ClosestFix = track.Fixes[fixIndex];
				}
			}
			else
			{
				if (pointState.WithinCylinder)
				{
					// We've just left a point, raise event for closest fix to centre

					if (pointState.Type == PointState.PointType.Start && pointState.Visits.Count == 1)
					{
						StartPointHit(pointState.Point, pointState.FirstVisit.ClosestFix);
					}
                    else if (pointState.Type == PointState.PointType.Turn)
                    {
                        TurnpointHit(pointState.Point, pointState.LastVisit.ClosestFix, pointState.Visits.Count);
                    }

					pointState.WithinCylinder = false;
				}
			}

			// Do processing on final fix
			if (fixIndex == track.Fixes.Count - 1)
			{
				switch (pointState.Type)
				{
					case PointState.PointType.Start:
						if (pointState.WithinCylinder && pointState.Visits.Count == 1)
						{
							// We've come to the end of the track and we're still inside the start point (landing out)

							StartPointHit(pointState.Point, pointState.Visits[0].ClosestFix);
						}
						else if (pointState.Visits.Count == 0)
						{
							StartPointNotHit(pointState.Point);
						}
						break;

					case PointState.PointType.Turn:
						if (pointState.WithinCylinder)
						{
							// We've come to the end of the track and we're still inside the turn point (landing out)

							TurnpointHit(pointState.Point, pointState.LastVisit.ClosestFix, pointState.Visits.Count);
						}
						break;
				}
			}
		}

        private bool IsWithinPoint(Geolocation.Tracks.Fix fix, Features.PointFeature point, out double distanceToCentre)
        {
            Models.Features.Circle pointCircle = point.Shape as Models.Features.Circle;

            distanceToCentre = m_distanceCalculator.CalculateDistance(fix, pointCircle.Center);

            if (distanceToCentre <= (double)pointCircle.Radius)
            {
                if (point.LowerAltitude != Geolocation.Location.UnknownAltitude && point.UpperAltitude != Geolocation.Location.UnknownAltitude)
                {
                    // This is a floating turnpoint stretching from the given lower altitude to the given upper altitude
                    if (fix.Altitude >= point.LowerAltitude && fix.Altitude <= point.UpperAltitude)
                    {
                        return true;
                    }
                }
                else if (point.LowerAltitude != Geolocation.Location.UnknownAltitude && point.UpperAltitude == Geolocation.Location.UnknownAltitude)
                {
                    // This is a floating turnpoint stretching from the given lower altitude to an infinite upper altitude
                    if (fix.Altitude >= point.LowerAltitude)
                    {
                        return true;
                    }
                }
                else if (point.LowerAltitude == Geolocation.Location.UnknownAltitude && point.UpperAltitude != Geolocation.Location.UnknownAltitude)
                {
                    // This is a turnpoint stretching from the ground to the given upper altitude
                    if (fix.Altitude <= point.UpperAltitude)
                    {
                        return true;
                    }
                }
                else
                {
                    // This is standard turnpoint stretching from the ground to infinite altitude
                    return true;
                }
            }

            return false;
        }

		private void StartPointHit(Features.PointFeature point, Geolocation.Tracks.Fix fix)
		{
			Events.TrackEvent trackEvent = new Events.StartPointHit(point);
			trackEvent.Time = fix.Time;
			trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
            trackEvent.RelatedFeature = point;

			OnEventOccurred(new EventOccurredEventArgs(trackEvent));
		}

		private void StartPointNotHit(Features.PointFeature point)
		{
			Events.TrackEvent trackEvent = new Events.StartPointNotHit(point);
			trackEvent.Location = (point.Shape as Models.Features.Circle).Center;
			trackEvent.Sequence = 1;
            trackEvent.RelatedFeature = point;

			OnEventOccurred(new EventOccurredEventArgs(trackEvent));
		}

		private void FinishPointHit(Features.PointFeature point, Geolocation.Tracks.Fix fix)
		{
			Events.TrackEvent trackEvent = new Events.FinishPointHit(point);
			trackEvent.Time = fix.Time;
			trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
            trackEvent.RelatedFeature = point;

			OnEventOccurred(new EventOccurredEventArgs(trackEvent));
		}

		private void FinishPointNotHit(Features.PointFeature point)
		{
			Events.TrackEvent trackEvent = new Events.FinishPointNotHit(point);
			trackEvent.Location = (point.Shape as Models.Features.Circle).Center;
			trackEvent.Sequence = 2;
            trackEvent.RelatedFeature = point;

			OnEventOccurred(new EventOccurredEventArgs(trackEvent));
		}

		private void TurnpointHit(Features.PointFeature point, Geolocation.Tracks.Fix fix, int visits)
		{
			Events.TrackEvent trackEvent;

			if (visits > 1)
			{
				trackEvent = new Events.DuplicateTurnpointHit(point);
			}
            else
            {
                trackEvent = new Events.TurnpointHit(point);
            }

            trackEvent.Time = fix.Time;
            trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
            trackEvent.Sequence = 1;
            trackEvent.RelatedFeature = point;

            OnEventOccurred(new EventOccurredEventArgs(trackEvent));
        }

		protected void OnEventOccurred(EventOccurredEventArgs e)
		{
			if (EventOccurred != null)
			{
				EventOccurred(this, e);
			}
		}

		private class PointState
		{
			public enum PointType
			{
				Start,
				Finish,
				Turn
			}

			public PointState(PointType type, Features.PointFeature point)
			{
				this.Type = type;
				this.Point = point;
				this.WithinCylinder = false;

				this.Visits = new List<PointVisit>();
			}

			public PointType Type { get; set; }
			public Features.PointFeature Point { get; set; }
			public bool WithinCylinder { get; set; }

			public List<PointVisit> Visits { get; set; }

			public PointVisit FirstVisit
			{
				get
				{
					if (this.Visits.Count > 0)
					{
						return this.Visits[0];
					}
					else
					{
						return null;
					}
				}
			}

			public PointVisit LastVisit
			{
				get
				{
					if (this.Visits.Count > 0)
					{
						return this.Visits[this.Visits.Count - 1];
					}
					else
					{
						return null;
					}
				}
			}
		}

		private class PointVisit
		{
			public PointVisit(double closestDistance)
			{
				this.ClosestDistance = closestDistance;
			}

			public double ClosestDistance { get; set; }
			public Geolocation.Tracks.Fix ClosestFix { get; set; }
		}
	}
}
