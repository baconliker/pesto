using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Analyzers
{
	class TakeOffLandingCategoryAnalyzer : IAnalyzer
	{
		public event EventHandler<EventOccurredEventArgs> EventOccurred;

		private const double m_walkingSpeed = 4.8; // km/h
		private const double m_maxRunningSpeed = 36; // km/h = 10 second 100m time (I think this is safe because Usain Bolt doesn't fly a paramotor!)

		private const double m_tolerancePercentage = 80;

		private const int m_slidingWindowLength = 10;

		private List<WindowFix> m_slidingWindow = new List<WindowFix>(m_slidingWindowLength);

        private AirfieldState m_airfieldState = null;
        private DeckState m_takeOffDeckState = null;
        private DeckState m_landingDeckState = null;

        private bool m_airborne = false;

		public TakeOffLandingCategoryAnalyzer(Task task)
		{
			this.Task = task;

            foreach (Features.Feature feature in task.Competition.Features)
            {
                if (feature.Type == Features.Feature.FeatureType.Airfield)
                {
                    m_airfieldState = new AirfieldState(feature as Features.AirfieldFeature);

                    break;
                }
            }

            if (this.Task.TakeOffDeck != null)
            {
                m_takeOffDeckState = new DeckState(this.Task.TakeOffDeck);
            }

            if (this.Task.LandingDeck != null)
            {
                m_landingDeckState = new DeckState(this.Task.LandingDeck);
            }
        }

		public void AnalyzeFix(Geolocation.Tracks.Track track, int fixIndex)
		{
            double acceleration = 0;

            if (m_slidingWindow.Count > 0)
            {
                TimeSpan fixTimeDifference = track.Fixes[fixIndex].Time.Subtract(m_slidingWindow[m_slidingWindow.Count - 1].Fix.Time);

                acceleration = (track.Fixes[fixIndex].Speed - m_slidingWindow[m_slidingWindow.Count - 1].Fix.Speed) / fixTimeDifference.TotalSeconds;
            }

            // Add current fix to sliding window
            m_slidingWindow.Add(new WindowFix(fixIndex, track.Fixes[fixIndex], acceleration));
            if (m_slidingWindow.Count > m_slidingWindowLength)
            {
                m_slidingWindow.RemoveAt(0);
            }

            if (m_slidingWindow.Count == m_slidingWindowLength)
			{
				if (m_airborne)
				{
                    // Look for landing

                    int landingFixIndex;

                    if (LandingDetected2(out landingFixIndex))
					{
						m_airborne = false;
                        Landed(track.Fixes[landingFixIndex]);
					}
				}
				else
				{
                    // Look for take-off

                    int takeOffFixIndex;

                    if (TakeOffDetected4(out takeOffFixIndex))
					{
						m_airborne = true;
                        TakenOff(track.Fixes[takeOffFixIndex]);
					}
				}
			}
		}

		public Task Task { get; set; }

		protected void OnEventOccurred(EventOccurredEventArgs e)
		{
			if (EventOccurred != null)
			{
				EventOccurred(this, e);
			}
		}

        // TODO: Remove old take-off detected code after WPC2016
        private bool TakeOffDetected(out int takeOffFixIndex)
		{
			int altitudeIncreaseCount = 0;
			int fasterThanWalkingSpeedCount = 0;
			int fasterThanRunningSpeedCount = 0;

			for (int i = 1; i < m_slidingWindow.Count; i++)
			{
				if (m_slidingWindow[i].Fix.Altitude > m_slidingWindow[i - 1].Fix.Altitude && m_slidingWindow[i].Fix.Altitude != Geolocation.Location.UnknownAltitude && m_slidingWindow[i - 1].Fix.Altitude != Geolocation.Location.UnknownAltitude)
				{
					altitudeIncreaseCount++;
				}

				if (m_slidingWindow[i].Fix.Speed > m_walkingSpeed)
				{
					fasterThanWalkingSpeedCount++;
				}

				if (m_slidingWindow[i].Fix.Speed > m_maxRunningSpeed)
				{
					fasterThanRunningSpeedCount++;
				}
			}

			double altitudeIncreasePercentage = Convert.ToDouble(altitudeIncreaseCount / (m_slidingWindowLength - 1) * 100);
			double fasterThanWalkingSpeedPercentage = fasterThanWalkingSpeedCount / (m_slidingWindowLength - 1) * 100;
			double fasterThanRunningSpeedPercentage = fasterThanRunningSpeedCount / (m_slidingWindowLength - 1) * 100;

			if ((altitudeIncreasePercentage >= m_tolerancePercentage && fasterThanWalkingSpeedPercentage >= m_tolerancePercentage) || fasterThanRunningSpeedPercentage >= m_tolerancePercentage)
			{
                takeOffFixIndex = m_slidingWindow[0].FixIndex;
                return true;
			}
			else
			{
                takeOffFixIndex = -1;
                return false;
			}
		}

        private bool TakeOffDetected4(out int takeOffFixIndex)
        {
            for (int i = 0; i < m_slidingWindow.Count; i++)
            {
                if (m_slidingWindow[i].Fix.Speed < 14)
                {
                    takeOffFixIndex = -1;
                    return false;
                }

                if (i > 0)
                {
                    if (Math.Abs(m_slidingWindow[i].Fix.Heading - m_slidingWindow[i - 1].Fix.Heading) >= 45)
                    {
                        takeOffFixIndex = -1;
                        return false;
                    }
                }
            }

            // We've detected the take off run, now try and identify where within this the take off actually happens

            takeOffFixIndex = m_slidingWindow[0].FixIndex;
            double maxAcceleration = m_slidingWindow[0].Acceleration;

            for (int i = 1; i < m_slidingWindow.Count; i++)
            {
                // Look for max acceleration
                if (m_slidingWindow[i].Acceleration >= maxAcceleration)
                {
                    takeOffFixIndex = m_slidingWindow[i].FixIndex;
                    maxAcceleration = m_slidingWindow[i].Acceleration;
                }

                // Stop if we see an increase in altitude
                if (m_slidingWindow[i].Fix.Altitude > m_slidingWindow[i - 1].Fix.Altitude)
                {
                    break;
                }
            }

            return true;
        }

        // TODO: Remove old landing detected code after WPC2016
        private bool LandingDetected(out int landingFixIndex)
		{
			int altitudeConstantCount = 0;
			int slowerThanWalkingSpeedCount = 0;

			for (int i = 1; i < m_slidingWindow.Count; i++)
			{
				if (m_slidingWindow[i].Fix.Altitude == m_slidingWindow[i - 1].Fix.Altitude && m_slidingWindow[i].Fix.Altitude != Geolocation.Location.UnknownAltitude && m_slidingWindow[i - 1].Fix.Altitude != Geolocation.Location.UnknownAltitude)
				{
					altitudeConstantCount++;
				}

				if (m_slidingWindow[i].Fix.Speed <= m_walkingSpeed)
				{
					slowerThanWalkingSpeedCount++;
				}
			}

			double altitudeConstantPercentage = altitudeConstantCount / (m_slidingWindowLength - 1) * 100;
			double slowerThanWalkingSpeedPercentage = slowerThanWalkingSpeedCount / (m_slidingWindowLength - 1) * 100;

			if (altitudeConstantPercentage >= m_tolerancePercentage && slowerThanWalkingSpeedPercentage >= m_tolerancePercentage)
			{
                landingFixIndex = m_slidingWindow[0].FixIndex;
                return true;
			}
			else
			{
                landingFixIndex = -1;
                return false;
			}
		}

        private bool LandingDetected2(out int landingFixIndex)
        {
            for (int i = 1; i < m_slidingWindow.Count; i++)
            {
                if (m_slidingWindow[i].Fix.Speed >= 14)
                {
                    landingFixIndex = -1;
                    return false;
                }
            }

            landingFixIndex = m_slidingWindow[0].FixIndex;
            return true;
        }

        private void TakenOff(Geolocation.Tracks.Fix fix)
		{
			Events.TrackEvent trackEvent;

			trackEvent = new Events.TakeOff();
			trackEvent.Time = fix.Time;
			trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
			trackEvent.Sequence = 1;

			OnEventOccurred(new EventOccurredEventArgs(trackEvent));

            if (m_airfieldState != null && !IsFixWithinPolygon(fix, m_airfieldState.Airfield.Shape as Features.Polygon, m_airfieldState.PolygonBounds))
            {
                trackEvent = new Events.TakeOffOutsideAirfield();
                trackEvent.Time = fix.Time;
                trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
                trackEvent.Sequence = 2;

                OnEventOccurred(new EventOccurredEventArgs(trackEvent));
            }

            if (m_takeOffDeckState != null && !IsFixWithinPolygon(fix, m_takeOffDeckState.Deck.Shape as Features.Polygon, m_takeOffDeckState.PolygonBounds))
            {
                trackEvent = new Events.TakeOffOutsideDeck();
                trackEvent.Time = fix.Time;
                trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
                trackEvent.Sequence = 3;

                OnEventOccurred(new EventOccurredEventArgs(trackEvent));
            }

            if (fix.Time < this.Task.LaunchOpen.ToUniversalTime())
			{
				trackEvent = new Events.TakeOffBeforeWindowOpen();
				trackEvent.Time = fix.Time;
				trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
				trackEvent.Sequence = 4;

				OnEventOccurred(new EventOccurredEventArgs(trackEvent));
			}

			if (this.Task.LaunchCloseSet && fix.Time > this.Task.LaunchClose.ToUniversalTime())
			{
				trackEvent = new Events.TakeOffAfterWindowClose();
				trackEvent.Time = fix.Time;
				trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
				trackEvent.Sequence = 5;

				OnEventOccurred(new EventOccurredEventArgs(trackEvent));
			}
		}

		private void Landed(Geolocation.Tracks.Fix fix)
		{
			Events.TrackEvent trackEvent = new Events.Landing();
			trackEvent.Time = fix.Time;
			trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
			trackEvent.Sequence = 1;

			OnEventOccurred(new EventOccurredEventArgs(trackEvent));

            if (m_airfieldState != null && !IsFixWithinPolygon(fix, m_airfieldState.Airfield.Shape as Features.Polygon, m_airfieldState.PolygonBounds))
            {
                trackEvent = new Events.LandingOutsideAirfield();
                trackEvent.Time = fix.Time;
                trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
                trackEvent.Sequence = 2;

                OnEventOccurred(new EventOccurredEventArgs(trackEvent));
            }

            if (m_landingDeckState != null && !IsFixWithinPolygon(fix, m_landingDeckState.Deck.Shape as Features.Polygon, m_landingDeckState.PolygonBounds))
            {
                trackEvent = new Events.LandingOutsideDeck();
                trackEvent.Time = fix.Time;
                trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
                trackEvent.Sequence = 3;

                OnEventOccurred(new EventOccurredEventArgs(trackEvent));
            }

            if (this.Task.LandBySet && fix.Time > this.Task.LandBy.ToUniversalTime())
			{
				trackEvent = new Events.LandingAfterWindowClose();
				trackEvent.Time = fix.Time;
				trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
				trackEvent.Sequence = 4;

				OnEventOccurred(new EventOccurredEventArgs(trackEvent));
			}
		}

        //TODO: This is copied from NoFlyZoneCategoryAnalyzer, move elsewhere and dedupe
        private bool IsFixWithinPolygon(Geolocation.Tracks.Fix fix, Features.Polygon polygon, BoundingBox polygonBounds)
        {
            // First check if it's within bounding box because this is very fast
            if (fix.Latitude < polygonBounds.SW.Latitude || fix.Latitude > polygonBounds.NE.Latitude || fix.Longitude < polygonBounds.SW.Longitude || fix.Longitude > polygonBounds.NE.Longitude)
            {
                return false;
            }
            else
            {
                // Use slower ray casting to check if it's actually inside the polygon.Vertices
                // http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html

                bool inside = false;

                for (int i = 0, j = polygon.Vertices.Count - 1; i < polygon.Vertices.Count; j = i++)
                {
                    if ((polygon.Vertices[i].Latitude > fix.Latitude) != (polygon.Vertices[j].Latitude > fix.Latitude) &&
                         fix.Longitude < (polygon.Vertices[j].Longitude - polygon.Vertices[i].Longitude) * (fix.Latitude - polygon.Vertices[i].Latitude) / (polygon.Vertices[j].Latitude - polygon.Vertices[i].Latitude) + polygon.Vertices[i].Longitude)
                    {
                        inside = !inside;
                    }
                }

                return inside;
            }
        }

        private class WindowFix
        {
            public WindowFix(int fixIndex, ColinBaker.Geolocation.Tracks.Fix fix, double acceleration)
            {
                this.FixIndex = fixIndex;
                this.Fix = fix;
                this.Acceleration = acceleration;
            }

            public int FixIndex { get; set; }
            public ColinBaker.Geolocation.Tracks.Fix Fix { get; set; }
            public double Acceleration { get; set; }
        }

        private class AirfieldState
        {
            public AirfieldState(Features.AirfieldFeature airfield)
            {
                this.Airfield = airfield;
                this.PolygonBounds = new BoundingBox();

                foreach (Geolocation.Location location in (airfield.Shape as Features.Polygon).Vertices)
                {
                    this.PolygonBounds.Extend(location);
                }
            }

            public Features.AirfieldFeature Airfield { get; set; }
            public BoundingBox PolygonBounds { get; set; }
        }

        private class DeckState
        {
            public DeckState(Features.DeckFeature deck)
            {
                this.Deck = deck;
                this.PolygonBounds = new BoundingBox();

                foreach (Geolocation.Location location in (deck.Shape as Features.Polygon).Vertices)
                {
                    this.PolygonBounds.Extend(location);
                }
            }

            public Features.DeckFeature Deck { get; set; }
            public BoundingBox PolygonBounds { get; set; }
        }
    }
}
