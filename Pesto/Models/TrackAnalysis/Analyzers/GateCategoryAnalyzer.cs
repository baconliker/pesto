using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Analyzers
{
	class GateCategoryAnalyzer : IAnalyzer
	{
		public event EventHandler<EventOccurredEventArgs> EventOccurred;

        private GateState m_startGateState;
        private GateState m_finishGateState;

		private List<GateState> m_gateStates = new List<GateState>();

		public GateCategoryAnalyzer(Task task)
		{
			this.Task = task;

            if (this.Task.StartPointOrGate != null && this.Task.StartPointOrGate.Type == Features.Feature.FeatureType.Gate)
            {
                m_startGateState = new GateState(GateState.GateType.Start, this.Task.StartPointOrGate as Features.GateFeature);
            }
            if (this.Task.FinishPointOrGate != null && this.Task.FinishPointOrGate.Type == Features.Feature.FeatureType.Gate)
            {
                m_finishGateState = new GateState(GateState.GateType.Finish, this.Task.FinishPointOrGate as Features.GateFeature);
            }

			foreach (Features.GateFeature gate in task.HiddenGates)
			{
                m_gateStates.Add(new GateState(GateState.GateType.Hidden, gate));
			}
		}

		public void AnalyzeFix(Geolocation.Tracks.Track track, int fixIndex)
		{
			if (fixIndex > 0)
			{
				LineInfo trackLine = new LineInfo(track.Fixes[fixIndex - 1], track.Fixes[fixIndex]);

				// Check if the track hits any gate

                if (m_startGateState != null)
                {
                    CheckGateState(m_startGateState, trackLine, track, fixIndex);
                }

                if (m_finishGateState != null)
                {
                    CheckGateState(m_finishGateState, trackLine, track, fixIndex);
                }

				foreach (GateState gateState in m_gateStates)
				{
                    CheckGateState(gateState, trackLine, track, fixIndex);
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

        private void CheckGateState(GateState gateState, LineInfo trackLine, Geolocation.Tracks.Track track, int fixIndex)
        {
            if (TrackCrossesGateInCorrectDirection(trackLine, gateState))
            {
                gateState.VisitCount++;

                switch (gateState.Type)
                {
                    case GateState.GateType.Start:
                        if (gateState.VisitCount == 1)
                        {
                            StartGateHit(gateState.Gate, track.Fixes[fixIndex - 1]);
                        }
                        break;

                    case GateState.GateType.Finish:
                        if (gateState.VisitCount == 1)
                        {
                            // TODO: Make this configurable?
                            // Change for WPC2016 - use the fix before the finish gate per S10
                            //FinishGateHit(gateState.Gate, track.Fixes[fixIndex]);
                            FinishGateHit(gateState.Gate, track.Fixes[fixIndex - 1]);
                        }
                        break;

                    default:
                        HiddenGateHit(gateState.Gate, track.Fixes[fixIndex - 1], gateState.VisitCount);
                        break;
                }
            }
            else
            {
                if (fixIndex == track.Fixes.Count - 1)
                {
                    // Do processing on final fix

                    switch (gateState.Type)
                    {
                        case GateState.GateType.Start:
                            if (gateState.VisitCount == 0)
                            {
                                StartGateNotHit(gateState.Gate);
                            }
                            break;

                        case GateState.GateType.Finish:
                            if (gateState.VisitCount == 0)
                            {
                                FinishGateNotHit(gateState.Gate);
                            }
                            break;
                    }
                }
            }
        }

        private void StartGateHit(Features.GateFeature gate, Geolocation.Tracks.Fix fix)
        {
            Events.TrackEvent trackEvent = new Events.StartGateHit(gate);
            trackEvent.Time = fix.Time;
            trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
            trackEvent.RelatedFeature = gate;

            OnEventOccurred(new EventOccurredEventArgs(trackEvent));
        }

        private void StartGateNotHit(Features.GateFeature gate)
        {
            Events.TrackEvent trackEvent = new Events.StartGateNotHit(gate);
            trackEvent.Location = (gate.Shape as Models.Features.Line).Center;
            trackEvent.Sequence = 1;
            trackEvent.RelatedFeature = gate;

            OnEventOccurred(new EventOccurredEventArgs(trackEvent));
        }

        private void FinishGateHit(Features.GateFeature gate, Geolocation.Tracks.Fix fix)
        {
            Events.TrackEvent trackEvent = new Events.FinishGateHit(gate);
            trackEvent.Time = fix.Time;
            trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
            trackEvent.RelatedFeature = gate;

            OnEventOccurred(new EventOccurredEventArgs(trackEvent));
        }

        private void FinishGateNotHit(Features.GateFeature gate)
        {
            Events.TrackEvent trackEvent = new Events.FinishGateNotHit(gate);
            trackEvent.Location = (gate.Shape as Models.Features.Line).Center;
            trackEvent.Sequence = 2;
            trackEvent.RelatedFeature = gate;

            OnEventOccurred(new EventOccurredEventArgs(trackEvent));
        }

        private void HiddenGateHit(Features.GateFeature gate, Geolocation.Tracks.Fix fix, int visits)
        {
            Events.TrackEvent trackEvent;
            
            if (visits > 1)
            {
                trackEvent = new Events.DuplicateHiddenGateHit(gate);
            }
            else
            {
                trackEvent = new Events.HiddenGateHit(gate);
            }

            trackEvent.Time = fix.Time;
            trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);
            trackEvent.RelatedFeature = gate;

            OnEventOccurred(new EventOccurredEventArgs(trackEvent));
        }

		private bool TrackCrossesGateInCorrectDirection(LineInfo trackLine, GateState gateState)
		{
			Geolocation.Location intersection = LinesIntersect(trackLine, gateState.Line);

			if (intersection != null)
			{
				// Lines intersect

                // Check height is OK

                bool heightOK = false;

                if (gateState.Gate.LowerAltitude != Geolocation.Location.UnknownAltitude && gateState.Gate.UpperAltitude != Geolocation.Location.UnknownAltitude)
                {
                    // This is a floating gate stretching from the given lower altitude to the given upper altitude
                    if (intersection.Altitude >= gateState.Gate.LowerAltitude && intersection.Altitude <= gateState.Gate.UpperAltitude)
                    {
                        heightOK = true;
                    }
                }
                else if (gateState.Gate.LowerAltitude != Geolocation.Location.UnknownAltitude && gateState.Gate.UpperAltitude == Geolocation.Location.UnknownAltitude)
                {
                    // This is a floating gate stretching from the given lower altitude to an infinite upper altitude
                    if (intersection.Altitude >= gateState.Gate.LowerAltitude)
                    {
                        heightOK = true;
                    }
                }
                else if (gateState.Gate.LowerAltitude == Geolocation.Location.UnknownAltitude && gateState.Gate.UpperAltitude != Geolocation.Location.UnknownAltitude)
                {
                    // This is a gate stretching from the ground to the given upper altitude
                    if (intersection.Altitude <= gateState.Gate.UpperAltitude)
                    {
                        heightOK = true;
                    }
                }
                else
                {
                    // This is standard gate stretching from the ground to infinite altitude
                    heightOK = true;
                }

                if (heightOK)
                {
                    // Check intersection

                    if (intersection.Latitude == trackLine.P1.Latitude && intersection.Longitude == trackLine.P1.Longitude)
                    {
                        // The intersection coords are the same as the track line start. This means there's a gps fix exactly on the gate, we've already counted the gate as being hit and we're about to again.
                        // This should be done first in case the pilot somehow flies right along the gate
                    }
                    else if (intersection.Latitude == trackLine.P2.Latitude && intersection.Longitude == trackLine.P2.Longitude)
                    {
                        // The intersection coords are the same as the track line end. This means there's a gps fix exactly on the gate
                        return true;
                    }
                    else
                    {
                        // Make sure track crosses gate in the correct direction

                        //TODO: Extend these cases to deal with crossing Greenwich Meridian where appropriate

                        Models.Features.Line gateLine = gateState.Gate.Shape as Models.Features.Line;

                        Geolocation.Location poly1 = gateState.ExtendedLine.P1;
                        Geolocation.Location poly2 = gateState.ExtendedLine.P1.Translate(gateLine.Width, (double)gateLine.Bearing);
                        Geolocation.Location poly3 = gateState.ExtendedLine.P2.Translate(gateLine.Width, (double)gateLine.Bearing);
                        Geolocation.Location poly4 = gateState.ExtendedLine.P2;

                        var polygon = new Models.Features.Polygon();
                        polygon.Vertices.Add(poly1);
                        polygon.Vertices.Add(poly2);
                        polygon.Vertices.Add(poly3);
                        polygon.Vertices.Add(poly4);

                        return IsFixWithinPolygon(trackLine.P2, polygon);

                        //if (gateLine.Bearing == 0)
                        //{
                        //    if (trackLine.P2.Latitude > trackLine.P1.Latitude)
                        //    {
                        //        return true;
                        //    }
                        //}
                        //else if (gateLine.Bearing == 90)
                        //{
                        //    if (trackLine.P2.Longitude > trackLine.P1.Longitude)
                        //    {
                        //        return true;
                        //    }
                        //}
                        //else if (gateLine.Bearing == 180)
                        //{
                        //    if (trackLine.P2.Latitude < trackLine.P1.Latitude)
                        //    {
                        //        return true;
                        //    }
                        //}
                        //else if (gateLine.Bearing == 270)
                        //{
                        //    if (trackLine.P2.Longitude < trackLine.P1.Longitude)
                        //    {
                        //        return true;
                        //    }
                        //}
                        //else if ((gateLine.Bearing > 0 && gateLine.Bearing < 90) || (gateLine.Bearing > 180 && gateLine.Bearing < 270))
                        //{
                        //    if (IsPointInTriangle(trackLine.P2, gateState.ExtendedLine.P1, new Geolocation.Location(gateState.ExtendedLine.P1.Latitude, gateState.ExtendedLine.P2.Longitude), gateState.ExtendedLine.P2))
                        //    {
                        //        return true;
                        //    }
                        //}
                        //else if ((gateLine.Bearing > 90 && gateLine.Bearing < 180) || (gateLine.Bearing > 270 && gateLine.Bearing < 360))
                        //{
                        //    if (IsPointInTriangle(trackLine.P2, gateState.ExtendedLine.P1, new Geolocation.Location(gateState.ExtendedLine.P2.Latitude, gateState.ExtendedLine.P1.Longitude), gateState.ExtendedLine.P2))
                        //    {
                        //        return true;
                        //    }
                        //}
                    }
                }
			}

			return false;
		}

		private Geolocation.Location LinesIntersect(LineInfo line1, LineInfo line2)
		{
            Geolocation.Location intersection = new Geolocation.Location();

			// http://www.topcoder.com/tc?module=Static&d1=tutorials&d2=geometry2

			decimal delta = line1.A * line2.B - line2.A * line1.B;
			if (delta == 0)
				return null;

			decimal x = (line2.B * line1.C2 - line1.B * line2.C2) / delta;
			decimal y = (line1.A * line2.C2 - line2.A * line1.C2) / delta;

			intersection.Latitude = y;
			intersection.Longitude = x;
            // TODO: Calculate altitude properly
            intersection.Altitude = line1.P2.Altitude;

			// NOTE: any 2 non parallel lines will intersect at some point, the below code is to ensure they intersect within the given start and end points

			if (!(line1.LocationWithinBounds(intersection) && line2.LocationWithinBounds(intersection)))
			{
				return null;
			}

			return intersection;
		}

		private bool IsPointInTriangle(Geolocation.Location pt, Geolocation.Location v1, Geolocation.Location v2, Geolocation.Location v3)
		{
			bool b1, b2, b3;

			b1 = Sign(pt, v1, v2) < 0;
			b2 = Sign(pt, v2, v3) < 0;
			b3 = Sign(pt, v3, v1) < 0;

			return ((b1 == b2) && (b2 == b3));
		}

		private decimal Sign(Geolocation.Location p1, Geolocation.Location p2, Geolocation.Location p3)
		{
			return (p1.Longitude - p3.Longitude) * (p2.Latitude - p3.Latitude) - (p2.Longitude - p3.Longitude) * (p1.Latitude - p3.Latitude);
		}

        //TODO: This is copied from NoFlyZoneCategoryAnalyzer, move elsewhere and dedupe
        // Actually this is a slight variation which does not use a bounding box
        private static bool IsFixWithinPolygon(Geolocation.Location location, Features.Polygon polygon)
        {
            // Use slower ray casting to check if it's actually inside the polygon.Vertices
            // http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html

            bool inside = false;

            for (int i = 0, j = polygon.Vertices.Count - 1; i < polygon.Vertices.Count; j = i++)
            {
                if ((polygon.Vertices[i].Latitude > location.Latitude) != (polygon.Vertices[j].Latitude > location.Latitude) &&
                     location.Longitude < (polygon.Vertices[j].Longitude - polygon.Vertices[i].Longitude) * (location.Latitude - polygon.Vertices[i].Latitude) / (polygon.Vertices[j].Latitude - polygon.Vertices[i].Latitude) + polygon.Vertices[i].Longitude)
                {
                    inside = !inside;
                }
            }

            return inside;
        }

        private class LineInfo
		{
			public Geolocation.Location P1;
            public Geolocation.Location P2;
            public double M; // Slope
			public double C; // Intercept with Y axis
            public bool Vertical;

			public decimal A;
			public decimal B;
			public decimal C2;

			public LineInfo(Geolocation.Location p1, Geolocation.Location p2)
			{
				this.P1 = p1;
				this.P2 = p2;

				if (p1.Longitude == p2.Longitude)
				{
					this.Vertical = true;
				}
				else
				{
					this.M = (double)((p2.Latitude - p1.Latitude) / (p2.Longitude - p1.Longitude));
					this.C = (double)p1.Latitude - (M * (double)p1.Longitude);
				}

				this.A = p2.Latitude - p1.Latitude;
				this.B = p1.Longitude - p2.Longitude;
				this.C2 = this.A * p1.Longitude + this.B * p1.Latitude;
			}

			public bool LocationWithinBounds(Geolocation.Location location)
			{
                bool withinBounds = false;

                if (((location.Longitude >= P1.Longitude) && (location.Longitude <= P2.Longitude)) || ((location.Longitude >= P2.Longitude) && (location.Longitude <= P1.Longitude)))
				{
					if (((location.Latitude >= P1.Latitude) && (location.Latitude <= P2.Latitude)) || ((location.Latitude >= P2.Latitude) && (location.Latitude <= P1.Latitude)))
					{
						withinBounds = true;
                    }
                }

                return withinBounds;
			}
		}

		private class GateState
		{
            public enum GateType
            {
                Start,
                Finish,
                Hidden
            }

			public GateState(GateType type, Features.GateFeature gate)
			{
                Models.Features.Line gateLine = gate.Shape as Models.Features.Line;

				decimal fromBearing = gateLine.Bearing - 90;
				Geolocation.Location from = gateLine.Center.Translate((int)(gateLine.Width / 2), (double)((360 + fromBearing) % 360));
				Geolocation.Location fromExtended = gateLine.Center.Translate((int)((gateLine.Width * 1.1) / 2), (double)((360 + fromBearing) % 360));

				decimal toBearing = gateLine.Bearing + 90;
				Geolocation.Location to = gateLine.Center.Translate((int)(gateLine.Width / 2), (double)(toBearing % 360));
				Geolocation.Location toExtended = gateLine.Center.Translate((int)((gateLine.Width * 1.1) / 2), (double)(toBearing % 360));

                this.Type = type;
				this.Gate = gate;
				this.Line = new LineInfo(from, to);
				this.ExtendedLine = new LineInfo(fromExtended, toExtended);
			}

            public GateType Type { get; set; }
			public Features.GateFeature Gate { get; set; }
			public LineInfo Line { get; set; }
			public LineInfo ExtendedLine { get; set; } // This defines a slightly wider gate and is used when checking that the gate has been passed in the correct direction. If the exact gate width were used it's possible to miss tracks that just clip the edge of the gate
			public int VisitCount { get; set; }
		}
	}
}
