using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Analyzers
{
	class NoFlyZoneCategoryAnalyzer : IAnalyzer
	{
		public event EventHandler<EventOccurredEventArgs> EventOccurred;

		private List<NoFlyZoneState> m_noFlyZoneStates = new List<NoFlyZoneState>();

		private Geolocation.HaversineDistanceCalculator m_distanceCalculator = new Geolocation.HaversineDistanceCalculator();

		public NoFlyZoneCategoryAnalyzer(Competition competition)
		{
			this.Competition = competition;

			foreach (Features.Feature feature in competition.Features)
			{
				if (feature.Type == Features.Feature.FeatureType.NoFlyZone)
				{
                    Features.NoFlyZoneFeature nfz = feature as Features.NoFlyZoneFeature;

                    switch (nfz.Shape.Type)
                    {
                        case Features.Shape.ShapeType.Circle:
                            m_noFlyZoneStates.Add(new NoFlyZoneState(nfz));
                            break;

                        case Features.Shape.ShapeType.Polygon:
                            BoundingBox bounds = new BoundingBox();

                            foreach (Geolocation.Location location in (nfz.Shape as Features.Polygon).Vertices)
                            {
                                bounds.Extend(location);
                            }

                            m_noFlyZoneStates.Add(new NoFlyZoneState(nfz, bounds));
                            break;
                    }
				}
			}
		}

		public void AnalyzeFix(Geolocation.Tracks.Track track, int fixIndex)
		{
			foreach (NoFlyZoneState nfzState in m_noFlyZoneStates)
			{
                bool withinShape = false;
                bool withinNfz = false;

                switch (nfzState.NoFlyZone.Shape.Type)
                {
                    case Features.Shape.ShapeType.Circle:
                        withinShape = IsFixWithinCircle(track.Fixes[fixIndex], nfzState.NoFlyZone.Shape as Features.Circle);
                        break;
                    case Features.Shape.ShapeType.Polygon:
                        withinShape = IsFixWithinPolygon(track.Fixes[fixIndex], nfzState.NoFlyZone.Shape as Features.Polygon, nfzState.PolygonBounds);
                        break;
                }

                if (withinShape)
                {
                    if (nfzState.NoFlyZone.LowerAltitude != Geolocation.Location.UnknownAltitude && nfzState.NoFlyZone.UpperAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        // This is a floating NFZ stretching from the given lower altitude to the given upper altitude
                        if (track.Fixes[fixIndex].Altitude >= nfzState.NoFlyZone.LowerAltitude && track.Fixes[fixIndex].Altitude <= nfzState.NoFlyZone.UpperAltitude)
                        {
                            withinNfz = true;
                        }
                    }
                    else if (nfzState.NoFlyZone.LowerAltitude != Geolocation.Location.UnknownAltitude && nfzState.NoFlyZone.UpperAltitude == Geolocation.Location.UnknownAltitude)
                    {
                        // This is a floating NFZ stretching from the given lower altitude to an infinite upper altitude
                        if (track.Fixes[fixIndex].Altitude >= nfzState.NoFlyZone.LowerAltitude)
                        {
                            withinNfz = true;
                        }
                    }
                    else if (nfzState.NoFlyZone.LowerAltitude == Geolocation.Location.UnknownAltitude && nfzState.NoFlyZone.UpperAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        // This is a NFZ stretching from the ground to the given upper altitude
                        if (track.Fixes[fixIndex].Altitude <= nfzState.NoFlyZone.UpperAltitude)
                        {
                            withinNfz = true;
                        }
                    }
                    else
                    {
                        // This is standard turnpoint stretching from the ground to infinite altitude
                        withinNfz = true;
                    }
                }

                if (withinNfz)
				{
					if (!nfzState.WithinNfz)
					{
						// We've just entered a no fly zone

						nfzState.WithinNfz = true;

						Events.TrackEvent trackEvent = new Events.NoFlyZoneIncursion(nfzState.NoFlyZone);
						trackEvent.Time = track.Fixes[fixIndex].Time;
						trackEvent.Location = new Geolocation.Location(track.Fixes[fixIndex].Latitude, track.Fixes[fixIndex].Longitude, track.Fixes[fixIndex].Altitude);
                        trackEvent.RelatedFeature = nfzState.NoFlyZone;

						OnEventOccurred(new EventOccurredEventArgs(trackEvent));
					}
				}
				else
				{
					nfzState.WithinNfz = false;
				}
			}
		}

		public Competition Competition { get; set; }

		protected void OnEventOccurred(EventOccurredEventArgs e)
		{
			if (EventOccurred != null)
			{
				EventOccurred(this, e);
			}
		}

        private bool IsFixWithinCircle(Geolocation.Tracks.Fix fix, Features.Circle circle)
        {
            int distanceToCentre = Convert.ToInt32(m_distanceCalculator.CalculateDistance(fix, circle.Center));

            if (distanceToCentre < circle.Radius)
            {
                return true;
            }

            return false;
        }

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

        private class NoFlyZoneState
		{
			public NoFlyZoneState(Features.NoFlyZoneFeature nfz)
			{
				this.NoFlyZone = nfz;
                this.PolygonBounds = null;
                this.WithinNfz = false;
			}

            public NoFlyZoneState(Features.NoFlyZoneFeature nfz, BoundingBox polygonBounds)
            {
                this.NoFlyZone = nfz;
                this.PolygonBounds = polygonBounds;
                this.WithinNfz = false;
            }

            public Features.NoFlyZoneFeature NoFlyZone { get; set; }
            public BoundingBox PolygonBounds { get; set; }
			public bool WithinNfz { get; set; }
		}
	}
}
