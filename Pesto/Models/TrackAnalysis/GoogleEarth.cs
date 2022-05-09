using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis
{
	class GoogleEarth
	{
		private const string m_achievementEventStyleName = "achievementLabel";
		private const string m_informationEventStyleName = "informationLabel";
		private const string m_warningEventStyleName = "warningLabel";
		private const string m_failureEventStyleName = "failureLabel";

        private const int defaultMaxAltitude = 1000;

        public static void GenerateTrackFile(string filePath, Task task, Geolocation.Tracks.Track track, List<Events.TrackEvent> events, bool includeTrackFixData, bool clampToGround, bool includeFeatures, bool includeEvents)
		{
            Geolocation.Tracks.TrackStatistics stats = Geolocation.Tracks.TrackStatistics.GetStatistics(track);
            
            decimal maxAltitude;

            // This is the altitude to use to draw features that have an 'infinite' height
            // Exception handling is because I've modified the code just before WPC2016
            try
            {
                maxAltitude = CalculateMaxAltitude(task, track);
            }
            catch
            {
                maxAltitude = defaultMaxAltitude;
            }
            
            

			//BORIS
			//using (System.IO.FileStream destinationStream = System.IO.File.Open(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
			//{
			//    Geolocation.Tracks.Kml.KmlEncoder encoder = new Geolocation.Tracks.Kml.KmlEncoder();
			//    encoder.Encode(track, destinationStream);
			//}
			Geolocation.Files.Kml kmlFile = new Geolocation.Files.Kml();

			kmlFile.Track = track;

			if (includeEvents)
			{
				foreach (Events.TrackEvent evt in events)
				{
					string iconUrl = string.Empty;

					switch (evt.Classification)
					{
						case Events.TrackEvent.EventClassification.Achievement:
							iconUrl = m_achievementEventStyleName;
							break;
						case Events.TrackEvent.EventClassification.Information:
							iconUrl = m_informationEventStyleName;
							break;
						case Events.TrackEvent.EventClassification.Warning:
							iconUrl = m_warningEventStyleName;
							break;
						case Events.TrackEvent.EventClassification.Failure:
							iconUrl = m_failureEventStyleName;
							break;
					}

					kmlFile.Labels.Add(new Geolocation.Files.Label(evt.Description, evt.Time, evt.Location, iconUrl));
				}
			}

            if (includeFeatures)
            {
                //TODO: Make sure we don't add a feature twice (e.g. start and finish points using the same point feature)

                if (task.TakeOffDeck != null)
                {
                    kmlFile.Polygons.Add(CreatePolygonFromDeck(task.TakeOffDeck, "deckFeature"));
                }

                if (task.LandingDeck != null)
                {
                    kmlFile.Polygons.Add(CreatePolygonFromDeck(task.LandingDeck, "deckFeature"));
                }

                if (task.StartPointOrGate != null)
				{
					switch (task.StartPointOrGate.Type)
					{
						case Features.Feature.FeatureType.Point:
							Features.PointFeature point = task.StartPointOrGate as Features.PointFeature;
                            kmlFile.Cylinders.Add(CreateCylinderFromPoint(point, "pointFeature", "pointFeatureExtrusion", maxAltitude));

							break;

						case Features.Feature.FeatureType.Gate:
							Features.GateFeature gate = task.StartPointOrGate as Features.GateFeature;
							kmlFile.Lines.Add(CreateLineFromGate(gate, "gateFeature", "gateFeatureExtrusion", maxAltitude));

							break;
					}
				}

				if (task.FinishPointOrGate != null)
				{
                    switch (task.FinishPointOrGate.Type)
					{
						case Features.Feature.FeatureType.Point:
							Features.PointFeature point = task.FinishPointOrGate as Features.PointFeature;
                            kmlFile.Cylinders.Add(CreateCylinderFromPoint(point, "pointFeature", "pointFeatureExtrusion", maxAltitude));

							break;

						case Features.Feature.FeatureType.Gate:
							Features.GateFeature gate = task.FinishPointOrGate as Features.GateFeature;
							kmlFile.Lines.Add(CreateLineFromGate(gate, "gateFeature", "gateFeatureExtrusion", maxAltitude));

							break;
					}
				}

				foreach (Features.PointFeature turnpoint in task.Turnpoints)
				{
                    kmlFile.Cylinders.Add(CreateCylinderFromPoint(turnpoint, "pointFeature", "pointFeatureExtrusion", maxAltitude));
				}

				foreach (Features.GateFeature hiddenGate in task.HiddenGates)
				{
					kmlFile.Lines.Add(CreateLineFromGate(hiddenGate, "gateFeature", "gateFeatureExtrusion", maxAltitude));
                }

                foreach (Features.NoFlyZoneFeature nfz in task.NoFlyZones)
                {
                    switch (nfz.Shape.Type)
                    {
                        case Features.Shape.ShapeType.Circle:
                            kmlFile.Cylinders.Add(CreateCylinderFromNoFlyZone(nfz, "nfzFeature", "nfzFeatureExtrusion", maxAltitude));
                            break;
                        case Features.Shape.ShapeType.Polygon:
                            kmlFile.Polygons.Add(CreatePolygonFromNoFlyZone(nfz, "nfzFeature", "nfzFeatureExtrusion", maxAltitude));
                            break;
                    }
                }

                foreach (Features.Feature feature in task.Competition.Features)
				{
                    if (feature.Type == Features.Feature.FeatureType.Airfield)
                    {
                        kmlFile.Polygons.Add(CreatePolygonFromAirfield(feature as Features.AirfieldFeature, "airfieldFeature"));
                    }
				}
            }

            Geolocation.Files.KmlSaveOptions options = new Geolocation.Files.KmlSaveOptions();
            options.IncludeTrackFixData = includeTrackFixData;
            options.ClampTrackToGround = clampToGround;

			kmlFile.Save(filePath, options);
		}

		public static void GenerateAnalysisFile(Geolocation.Tracks.Track track, List<Events.TrackEvent> events)
		{
			throw new NotImplementedException("");
		}

		public static void OpenFile(string filePath)
		{
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(filePath);
			startInfo.UseShellExecute = true;

			using (System.Diagnostics.Process process = new System.Diagnostics.Process())
			{
				process.StartInfo = startInfo;
				process.Start();
			}
		}

        private static decimal CalculateMaxAltitude(Task task, Geolocation.Tracks.Track track)
        {
            decimal maxAltitude = 0;

            Geolocation.Tracks.TrackStatistics stats = Geolocation.Tracks.TrackStatistics.GetStatistics(track);

            if (stats.MaxAltitude != Geolocation.Location.UnknownAltitude && stats.MaxAltitude > maxAltitude)
            {
                maxAltitude = stats.MaxAltitude;
            }

            if (task.StartPointOrGate != null)
            {
                AmendMaxAltitudeBasedOnFeature(task.StartPointOrGate, ref maxAltitude);
            }
            if (task.FinishPointOrGate != null)
            {
                AmendMaxAltitudeBasedOnFeature(task.FinishPointOrGate, ref maxAltitude);
            }

            foreach (Features.PointFeature turnpoint in task.Turnpoints)
            {
                AmendMaxAltitudeBasedOnFeature(turnpoint, ref maxAltitude);
            }

            foreach (Features.GateFeature hiddenGate in task.HiddenGates)
            {
                AmendMaxAltitudeBasedOnFeature(hiddenGate, ref maxAltitude);
            }

            foreach (Features.NoFlyZoneFeature nfz in task.NoFlyZones)
            {
                AmendMaxAltitudeBasedOnFeature(nfz, ref maxAltitude);
            }

            return maxAltitude;
        }

        private static void AmendMaxAltitudeBasedOnFeature(Features.Feature feature, ref decimal maxAltitude)
        {
            switch (feature.Type)
            {
                case Features.Feature.FeatureType.Gate:
                    Features.GateFeature gate = (feature as Features.GateFeature);
                    if (gate.UpperAltitude != Geolocation.Location.UnknownAltitude && gate.UpperAltitude > maxAltitude)
                    {
                        maxAltitude = gate.UpperAltitude;
                    }
                    break;

                case Features.Feature.FeatureType.Point:
                    Features.PointFeature point = (feature as Features.PointFeature);
                    if (point.UpperAltitude != Geolocation.Location.UnknownAltitude && point.UpperAltitude > maxAltitude)
                    {
                        maxAltitude = point.UpperAltitude;
                    }
                    break;

                case Features.Feature.FeatureType.NoFlyZone:
                    Features.NoFlyZoneFeature nfz = (feature as Features.NoFlyZoneFeature);
                    if (nfz.UpperAltitude != Geolocation.Location.UnknownAltitude && nfz.UpperAltitude > maxAltitude)
                    {
                        maxAltitude = nfz.UpperAltitude;
                    }
                    break;
            }
        }

        private static Geolocation.Files.Cylinder CreateCylinderFromPoint(Features.PointFeature point, string styleName, string extrusionStyleName, decimal maxAltitude)
        {
            decimal upperAltitude;

            if (point.UpperAltitude == Geolocation.Location.UnknownAltitude)
            {
                upperAltitude = maxAltitude;
            }
            else
            {
                upperAltitude = point.UpperAltitude;
            }

            Features.Circle pointCircle = point.Shape as Features.Circle;

            return new Geolocation.Files.Cylinder(point.Name, pointCircle.Center, pointCircle.Radius, point.LowerAltitude, upperAltitude, styleName, extrusionStyleName);
        }

        private static Geolocation.Files.Cylinder CreateCylinderFromNoFlyZone(Features.NoFlyZoneFeature nfz, string styleName, string extrusionStyleName, decimal maxAltitude)
        {
            decimal upperAltitude;

            if (nfz.UpperAltitude == Geolocation.Location.UnknownAltitude)
            {
                upperAltitude = maxAltitude;
            }
            else
            {
                upperAltitude = nfz.UpperAltitude;
            }

            Features.Circle nfzCircle = nfz.Shape as Features.Circle;

            return new Geolocation.Files.Cylinder(nfz.Name, nfzCircle.Center, nfzCircle.Radius, nfz.LowerAltitude, upperAltitude, styleName, extrusionStyleName);
        }
        
        private static Geolocation.Files.Line CreateLineFromGate(Features.GateFeature gate, string styleName, string extrusionStyleName, decimal maxAltitude)
		{
            decimal upperAltitude;

            if (gate.UpperAltitude == Geolocation.Location.UnknownAltitude)
            {
                upperAltitude = maxAltitude;
            }
            else
            {
                upperAltitude = gate.UpperAltitude;
            }

            Models.Features.Line gateLine = gate.Shape as Models.Features.Line;

			decimal fromBearing = gateLine.Bearing - 90;
			Geolocation.Location from = gateLine.Center.Translate((int)(gateLine.Width / 2), (double)((360 + fromBearing) % 360));

			decimal toBearing = gateLine.Bearing + 90;
			Geolocation.Location to = gateLine.Center.Translate((int)(gateLine.Width / 2), (double)(toBearing % 360));

			return new Geolocation.Files.Line(gate.Name, from, to, gate.LowerAltitude, upperAltitude, styleName, extrusionStyleName);
		}

        private static Geolocation.Files.Polygon CreatePolygonFromNoFlyZone(Features.NoFlyZoneFeature nfz, string styleName, string extrusionStyleName, decimal maxAltitude)
        {
            decimal upperAltitude;

            if (nfz.UpperAltitude == Geolocation.Location.UnknownAltitude)
            {
                upperAltitude = maxAltitude;
            }
            else
            {
                upperAltitude = nfz.UpperAltitude;
            }

            Features.Polygon nfzPolygon = (Features.Polygon)nfz.Shape;

            return new Geolocation.Files.Polygon(nfz.Name, nfzPolygon.Vertices.ToArray(), nfz.LowerAltitude, upperAltitude, styleName, extrusionStyleName);
        }

        private static Geolocation.Files.Polygon CreatePolygonFromAirfield(Features.AirfieldFeature airfield, string styleName)
        {
            return new Geolocation.Files.Polygon(airfield.Name, (airfield.Shape as Features.Polygon).Vertices.ToArray(), Geolocation.Location.UnknownAltitude, Geolocation.Location.UnknownAltitude, styleName, String.Empty);
        }

        private static Geolocation.Files.Polygon CreatePolygonFromDeck(Features.DeckFeature deck, string styleName)
        {
            return new Geolocation.Files.Polygon(deck.Name, (deck.Shape as Features.Polygon).Vertices.ToArray(), Geolocation.Location.UnknownAltitude, Geolocation.Location.UnknownAltitude, styleName, String.Empty);
        }
    }
}
