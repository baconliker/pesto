using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ColinBaker.Geolocation.Files
{
	public class Kml : File
	{
		private const string m_kmlNamespaceUri = "http://www.opengis.net/kml/2.2";

		private const string m_extensionNamespacePrefix = "gx";
		private const string m_extensionNamespaceUri = "http://www.google.com/kml/ext/2.2";

		private const string m_dateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
		private const string m_latLonFormat = "0.000000";
		private const string m_altitudeFormat = "0.0";

		private const string m_defaultTrackName = "GPS Track";

        public Kml(string filePath)
            : base(FileFormat.Kml)
        {
            this.Placemarks = new System.Collections.ObjectModel.Collection<Placemark>();
            this.Cylinders = new System.Collections.ObjectModel.Collection<Cylinder>();
            this.Lines = new System.Collections.ObjectModel.Collection<Line>();
            this.Polygons = new System.Collections.ObjectModel.Collection<Polygon>();
            this.Labels = new System.Collections.ObjectModel.Collection<Label>();

            XmlDocument document = new XmlDocument();

            document.Load(filePath);

            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(document.NameTable);
            namespaceManager.AddNamespace("kml", m_kmlNamespaceUri);
            namespaceManager.AddNamespace(m_extensionNamespacePrefix, m_extensionNamespaceUri);

            foreach (XmlNode placemarkNode in document.SelectNodes("//kml:Placemark", namespaceManager))
            {
                XmlNode pointNode = placemarkNode.SelectSingleNode("kml:Point", namespaceManager);
                if (pointNode != null)
                {
                    this.Placemarks.Add(new Placemark(placemarkNode.SelectSingleNode("kml:name", namespaceManager).InnerText, new Point(ExtractCoordinates(pointNode.SelectSingleNode("kml:coordinates", namespaceManager))[0])));
                }

                XmlNode polygonNode = placemarkNode.SelectSingleNode("kml:Polygon", namespaceManager);
                if (polygonNode != null)
                {
                    Polygon polygon = new Polygon();
                    polygon.Vertices = ExtractCoordinates(polygonNode.SelectSingleNode("kml:outerBoundaryIs/kml:LinearRing/kml:coordinates", namespaceManager));

                    this.Placemarks.Add(new Placemark(placemarkNode.SelectSingleNode("kml:name", namespaceManager).InnerText, polygon));
                }


                XmlNode coordinatesNode = placemarkNode.SelectSingleNode("kml:Point/kml:coordinates", namespaceManager);

                if (coordinatesNode != null)
                {
                    string[] coordinates = coordinatesNode.InnerText.Split(',');

                    
                }
            }
        }

        private static Location[] ExtractCoordinates(XmlNode coordinatesNode)
        {
            List<Location> locations = new List<Location>();

            string[] coordinateSets = coordinatesNode.InnerText.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string coordinateSet in coordinateSets)
            {
                string[] coordinates = coordinateSet.Split(',');

                locations.Add(new Location(decimal.Parse(coordinates[1], System.Globalization.CultureInfo.InvariantCulture), decimal.Parse(coordinates[0], System.Globalization.CultureInfo.InvariantCulture)));
            }

            return locations.ToArray();
        }

        public Kml()
			: base(FileFormat.Kml)
        {
            this.Placemarks = new System.Collections.ObjectModel.Collection<Placemark>();
			this.Cylinders = new System.Collections.ObjectModel.Collection<Cylinder>();
			this.Lines = new System.Collections.ObjectModel.Collection<Line>();
            this.Polygons = new System.Collections.ObjectModel.Collection<Polygon>();
            this.Labels = new System.Collections.ObjectModel.Collection<Label>();
        }

		public void Save(string filePath, KmlSaveOptions options)
		{
			XmlDocument document = new XmlDocument();
			XmlElement element;

			XmlElement kmlElement = document.CreateElement("kml", m_kmlNamespaceUri);
			document.AppendChild(kmlElement);

			kmlElement.SetAttribute("xmlns", m_kmlNamespaceUri);
			kmlElement.SetAttribute("xmlns:" + m_extensionNamespacePrefix, m_extensionNamespaceUri);

			XmlElement documentElement = document.CreateElement("Document", m_kmlNamespaceUri);
			kmlElement.AppendChild(documentElement);

			XmlElement nameElement = document.CreateElement("name", m_kmlNamespaceUri);
			if (!string.IsNullOrWhiteSpace(this.Track.Name))
			{
				nameElement.InnerText = this.Track.Name;
			}
			else
			{
				nameElement.InnerText = m_defaultTrackName;
			}
			documentElement.AppendChild(nameElement);

			// LookAt

			if (this.Track.Fixes.Count > 0)
			{
				decimal centerLatitude;
				decimal centerLongitude;

				GetTrackCenter(this.Track, out centerLatitude, out centerLongitude);

				InsertLookAtElement(this.Track.Fixes[0].Time.ToUniversalTime(), this.Track.Fixes[this.Track.Fixes.Count - 1].Time.ToUniversalTime(), centerLatitude, centerLongitude, 0, CalculateLookAtRange(this.Track), documentElement);
			}

			// Styles

			if (this.Track.Fixes.Count > 0)
			{
				InsertStyleElement("multiTrack_n", "http://earth.google.com/images/kml-icons/track-directional/track-0.png", 1, "00ffffff", 1, string.Empty, string.Empty, -1, documentElement);
				InsertStyleElement("multiTrack_h", "http://earth.google.com/images/kml-icons/track-directional/track-0.png", 1.2M, "00ffffff", 1, string.Empty, string.Empty, -1, documentElement);
				InsertStyleMapElement("multiTrack", "#multiTrack_n", "#multiTrack_h", documentElement);

                InsertStyleElement("track", string.Empty, 1, "99ffac59", 5, string.Empty, string.Empty, -1, documentElement);
                InsertStyleElement("trackExtrusion", string.Empty, 1, "66000000", 1, "66000000", string.Empty, -1, documentElement);
			}

			if (this.Labels.Count > 0)
			{
				InsertStyleElement("achievementLabel", "https://www.colinbaker.me.uk/images/pesto/achievement.png", 1, string.Empty, 1, string.Empty, "ffffffff", 0.8M, documentElement);
				InsertStyleElement("informationLabel", "https://www.colinbaker.me.uk/images/pesto/information.png", 1, string.Empty, 1, string.Empty, "ffffffff", 0.8M, documentElement);
				InsertStyleElement("warningLabel", "https://www.colinbaker.me.uk/images/pesto/warning.png", 1, string.Empty, 1, string.Empty, "ffffffff", 0.8M, documentElement);
				InsertStyleElement("failureLabel", "https://www.colinbaker.me.uk/images/pesto/failure.png", 1, string.Empty, 1, string.Empty, "ffffffff", 0.8M, documentElement);
			}

            InsertStyleElement("airfieldFeature", string.Empty, 1, "9900d8ff", 5, string.Empty, string.Empty, -1, documentElement);

            InsertStyleElement("deckFeature", string.Empty, 1, "99006aff", 5, string.Empty, string.Empty, -1, documentElement);

            InsertStyleElement("pointFeature", string.Empty, 1, "99ff0000", 5, string.Empty, string.Empty, -1, documentElement);
            InsertStyleElement("pointFeatureExtrusion", string.Empty, 1, "66000000", 1, "66000000", string.Empty, -1, documentElement);

            InsertStyleElement("nfzFeature", string.Empty, 1, "990000ff", 5, string.Empty, string.Empty, -1, documentElement);
            InsertStyleElement("nfzFeatureExtrusion", string.Empty, 1, "66000000", 1, "66000000", string.Empty, -1, documentElement);

            InsertStyleElement("gateFeature", string.Empty, 1, "9900ff00", 5, string.Empty, string.Empty, -1, documentElement);
            InsertStyleElement("gateFeatureExtrusion", string.Empty, 1, "66000000", 1, "66000000", string.Empty, -1, documentElement);
			
			// Track

			if (this.Track.Fixes.Count > 0)
			{
				XmlElement trackFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
				documentElement.AppendChild(trackFolderElement);

				element = document.CreateElement("name", m_kmlNamespaceUri);
				element.InnerText = "Track";
				trackFolderElement.AppendChild(element);

				element = document.CreateElement("snippet", m_kmlNamespaceUri);
				trackFolderElement.AppendChild(element);

				InsertTrackDescriptionElement(this.Track, trackFolderElement);

				XmlElement trackTimeSpanElement = document.CreateElement("TimeSpan", m_kmlNamespaceUri);
				trackFolderElement.AppendChild(trackTimeSpanElement);

				element = document.CreateElement("begin", m_kmlNamespaceUri);
				element.InnerText = this.Track.Fixes[0].Time.ToUniversalTime().ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
				trackTimeSpanElement.AppendChild(element);

				element = document.CreateElement("end", m_kmlNamespaceUri);
				element.InnerText = this.Track.Fixes[this.Track.Fixes.Count - 1].Time.ToUniversalTime().ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
				trackTimeSpanElement.AppendChild(element);


				XmlElement placemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
				trackFolderElement.AppendChild(placemarkElement);

				element = document.CreateElement("name", m_kmlNamespaceUri);
				element.InnerText = "Location";
				placemarkElement.AppendChild(element);

				element = document.CreateElement("snippet", m_kmlNamespaceUri);
				placemarkElement.AppendChild(element);

				element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
				element.InnerText = "#multiTrack";
				placemarkElement.AppendChild(element);

				XmlElement trackElement = document.CreateElement(m_extensionNamespacePrefix, "Track", m_extensionNamespaceUri);
				placemarkElement.AppendChild(trackElement);

				if (!options.ClampTrackToGround)
				{
					element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
					element.InnerText = "absolute";
					trackElement.AppendChild(element);
				}

				foreach (Tracks.Fix fix in this.Track.Fixes)
				{
					XmlElement whenElement = document.CreateElement("when", m_kmlNamespaceUri);
					whenElement.InnerText = fix.Time.ToUniversalTime().ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
					trackElement.AppendChild(whenElement);
				}

				foreach (Tracks.Fix fix in this.Track.Fixes)
				{
					XmlElement coordElement = document.CreateElement(m_extensionNamespacePrefix, "coord", m_extensionNamespaceUri);
					coordElement.InnerText = fix.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture) + " " + fix.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture);
					if (fix.Altitude != Location.UnknownAltitude)
					{
						coordElement.InnerText = coordElement.InnerText + " " + fix.Altitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture);
					}
					trackElement.AppendChild(coordElement);
				}

				// Fixes

				if (options.IncludeTrackFixData)
				{
					XmlElement fixesFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
					trackFolderElement.AppendChild(fixesFolderElement);

					element = document.CreateElement("name", m_kmlNamespaceUri);
					element.InnerText = "Fixes";
					fixesFolderElement.AppendChild(element);

					int bearing;
					int directionIndicator;
					System.Collections.Generic.List<int> directionsUsed = new System.Collections.Generic.List<int>();

					for (int i = 0; i < this.Track.Fixes.Count; i++)
					{
						if (i == 0)
						{
							bearing = 0;
						}
						else
						{
							bearing = this.Track.Fixes[i - 1].BearingTo(this.Track.Fixes[i]);
						}

						// Determine direction in increments of 22.5 degrees (0 - 15)
						directionIndicator = (int)Math.Round(bearing / 22.5, MidpointRounding.AwayFromZero) % 16;

						if (!directionsUsed.Contains(directionIndicator))
						{
							directionsUsed.Add(directionIndicator);
						}

						InsertFixPlacemarkElement(i + 1, this.Track.Fixes[i], directionIndicator, options, fixesFolderElement);
					}

					foreach (int direction in directionsUsed)
					{
						InsertDirectionIndicatorStyleMap(direction, documentElement);
					}
				}

				// Path

				XmlElement pathFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
				trackFolderElement.AppendChild(pathFolderElement);

				element = document.CreateElement("name", m_kmlNamespaceUri);
				element.InnerText = "Path";
				pathFolderElement.AppendChild(element);

				// Path line

				XmlElement pathLinePlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
				pathFolderElement.AppendChild(pathLinePlacemarkElement);

				element = document.CreateElement("name", m_kmlNamespaceUri);
				element.InnerText = "Path Line";
				pathLinePlacemarkElement.AppendChild(element);

				element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
				element.InnerText = "#track";
				pathLinePlacemarkElement.AppendChild(element);

				XmlElement pathLineLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
				pathLinePlacemarkElement.AppendChild(pathLineLineStringElement);

				if (options.ClampTrackToGround)
				{
					element = document.CreateElement("tessellate", m_kmlNamespaceUri);
					element.InnerText = "1";
					pathLineLineStringElement.AppendChild(element);
				}
				else
				{
					element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
					element.InnerText = "absolute";
					pathLineLineStringElement.AppendChild(element);
				}

				System.Text.StringBuilder coordinates = new System.Text.StringBuilder();

				foreach (Tracks.Fix fix in this.Track.Fixes)
				{
					if (coordinates.Length > 0)
					{
						coordinates.Append(" ");
					}

					coordinates.Append(fix.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
					coordinates.Append(",");
					coordinates.Append(fix.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
					if (fix.Altitude != Tracks.Fix.UnknownAltitude)
					{
						coordinates.Append(",");
						coordinates.Append(fix.Altitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));
					}
				}

				element = document.CreateElement("coordinates", m_kmlNamespaceUri);
				element.InnerText = coordinates.ToString();
				pathLineLineStringElement.AppendChild(element);

				// Path line extrusion				

				if (!options.ClampTrackToGround)
				{
					XmlElement pathLineExtrusionPlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
					pathFolderElement.AppendChild(pathLineExtrusionPlacemarkElement);

					element = document.CreateElement("name", m_kmlNamespaceUri);
					element.InnerText = "Path Line Extrusion";
					pathLineExtrusionPlacemarkElement.AppendChild(element);

					element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
					element.InnerText = "#trackExtrusion";
					pathLineExtrusionPlacemarkElement.AppendChild(element);

					XmlElement pathLineExtrusionLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
					pathLineExtrusionPlacemarkElement.AppendChild(pathLineExtrusionLineStringElement);

					element = document.CreateElement("extrude", m_kmlNamespaceUri);
					element.InnerText = "1";
					pathLineExtrusionLineStringElement.AppendChild(element);

					element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
					element.InnerText = "absolute";
					pathLineExtrusionLineStringElement.AppendChild(element);

					element = document.CreateElement("coordinates", m_kmlNamespaceUri);
					element.InnerText = coordinates.ToString();
					pathLineExtrusionLineStringElement.AppendChild(element);
				}

				// Events

				if (this.Labels.Count > 0)
				{
					XmlElement eventsFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
					trackFolderElement.AppendChild(eventsFolderElement);

					element = document.CreateElement("name", m_kmlNamespaceUri);
					element.InnerText = "Events";
					eventsFolderElement.AppendChild(element);

					foreach (Label label in this.Labels)
					{
						XmlElement eventPlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
						eventsFolderElement.AppendChild(eventPlacemarkElement);

						element = document.CreateElement("name", m_kmlNamespaceUri);
						element.InnerText = label.Name;
						eventPlacemarkElement.AppendChild(element);

						element = document.CreateElement("snippet", m_kmlNamespaceUri);
						eventPlacemarkElement.AppendChild(element);

						InsertLabelDescriptionElement(label, eventPlacemarkElement);

						element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
						element.InnerText = "#" + label.StyleName;
						eventPlacemarkElement.AppendChild(element);

						if (label.Time != DateTime.MinValue)
						{
							XmlElement eventTimeStampElement = document.CreateElement("TimeStamp", m_kmlNamespaceUri);
							eventPlacemarkElement.AppendChild(eventTimeStampElement);

							element = document.CreateElement("when", m_kmlNamespaceUri);
							element.InnerText = label.Time.ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
							eventTimeStampElement.AppendChild(element);
						}
						
						XmlElement eventPointElement = document.CreateElement("Point", m_kmlNamespaceUri);
						eventPlacemarkElement.AppendChild(eventPointElement);

						if (!options.ClampTrackToGround && label.Location.Altitude != Tracks.Fix.UnknownAltitude)
						{
							element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
							element.InnerText = "absolute";
							eventPointElement.AppendChild(element);
						}

						System.Text.StringBuilder eventCoordinates = new System.Text.StringBuilder();

						eventCoordinates.Append(label.Location.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
						eventCoordinates.Append(",");
						eventCoordinates.Append(label.Location.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
						if (label.Location.Altitude != Tracks.Fix.UnknownAltitude)
						{
							eventCoordinates.Append(",");
							eventCoordinates.Append(label.Location.Altitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));
						}

						element = document.CreateElement("coordinates", m_kmlNamespaceUri);
						element.InnerText = eventCoordinates.ToString();
						eventPointElement.AppendChild(element);
					}
				}
			}

			// Features

			if ((this.Cylinders.Count + this.Lines.Count + this.Polygons.Count) > 0)
			{
				XmlElement featuresFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
				documentElement.AppendChild(featuresFolderElement);

				element = document.CreateElement("name", m_kmlNamespaceUri);
				element.InnerText = "Features";
				featuresFolderElement.AppendChild(element);

				foreach (Cylinder cylinder in this.Cylinders)
				{
					XmlElement cylinderFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
					featuresFolderElement.AppendChild(cylinderFolderElement);

					element = document.CreateElement("name", m_kmlNamespaceUri);
					element.InnerText = cylinder.Name;
					cylinderFolderElement.AppendChild(element);

					// Feature line

					XmlElement cylinderLinePlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
					cylinderFolderElement.AppendChild(cylinderLinePlacemarkElement);

					element = document.CreateElement("name", m_kmlNamespaceUri);
					element.InnerText = cylinder.Name + " Line";
					cylinderLinePlacemarkElement.AppendChild(element);

					element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
					element.InnerText = "#" + cylinder.StyleName;
					cylinderLinePlacemarkElement.AppendChild(element);

					XmlElement cylinderLineLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
					cylinderLinePlacemarkElement.AppendChild(cylinderLineLineStringElement);

					if (options.ClampTrackToGround)
					{
						element = document.CreateElement("tessellate", m_kmlNamespaceUri);
						element.InnerText = "1";
						cylinderLineLineStringElement.AppendChild(element);
					}
					else
					{
						element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
						element.InnerText = "absolute";
						cylinderLineLineStringElement.AppendChild(element);
					}

					System.Text.StringBuilder coordinates = new System.Text.StringBuilder();
					Location cylinderEdge;

					for (double bearing = 0; bearing <= 360; bearing++)
					{
                        cylinderEdge = cylinder.Center.Translate(cylinder.Radius, bearing);

						if (coordinates.Length > 0)
						{
							coordinates.Append(" ");
						}

						coordinates.Append(cylinderEdge.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
						coordinates.Append(",");
						coordinates.Append(cylinderEdge.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
						coordinates.Append(",");
                        coordinates.Append(cylinder.UpperAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));
					}

					element = document.CreateElement("coordinates", m_kmlNamespaceUri);
					element.InnerText = coordinates.ToString();
					cylinderLineLineStringElement.AppendChild(element);

					// Feature line extrusion

					if (!options.ClampTrackToGround)
					{
						XmlElement cylinderLineExtrusionPlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
						cylinderFolderElement.AppendChild(cylinderLineExtrusionPlacemarkElement);

						element = document.CreateElement("name", m_kmlNamespaceUri);
						element.InnerText = cylinder.Name + " Line Extrusion";
						cylinderLineExtrusionPlacemarkElement.AppendChild(element);

						element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
						element.InnerText = "#" + cylinder.ExtrusionStyleName;
						cylinderLineExtrusionPlacemarkElement.AppendChild(element);

						XmlElement cylinderLineExtrusionLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
						cylinderLineExtrusionPlacemarkElement.AppendChild(cylinderLineExtrusionLineStringElement);

						element = document.CreateElement("extrude", m_kmlNamespaceUri);
						element.InnerText = "1";
						cylinderLineExtrusionLineStringElement.AppendChild(element);

						element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
						element.InnerText = "absolute";
						cylinderLineExtrusionLineStringElement.AppendChild(element);

						element = document.CreateElement("coordinates", m_kmlNamespaceUri);
						element.InnerText = coordinates.ToString();
						cylinderLineExtrusionLineStringElement.AppendChild(element);
					}

                    // Feature lower line

                    if (!options.ClampTrackToGround)
                    {
                        cylinderLinePlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
                        cylinderFolderElement.AppendChild(cylinderLinePlacemarkElement);

                        element = document.CreateElement("name", m_kmlNamespaceUri);
                        element.InnerText = cylinder.Name + " Lower Line";
                        cylinderLinePlacemarkElement.AppendChild(element);

                        element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
                        element.InnerText = "#" + cylinder.StyleName;
                        cylinderLinePlacemarkElement.AppendChild(element);

                        cylinderLineLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
                        cylinderLinePlacemarkElement.AppendChild(cylinderLineLineStringElement);

                        if (cylinder.LowerAltitude != Location.UnknownAltitude)
                        {
                            element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
                            element.InnerText = "absolute";
                            cylinderLineLineStringElement.AppendChild(element);
                        }
                        else
                        {
                            element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
                            element.InnerText = "clampToGround";
                            cylinderLineLineStringElement.AppendChild(element);
                        }

                        coordinates = new System.Text.StringBuilder();

                        for (double bearing = 0; bearing <= 360; bearing++)
                        {
                            cylinderEdge = cylinder.Center.Translate(cylinder.Radius, bearing);

                            if (coordinates.Length > 0)
                            {
                                coordinates.Append(" ");
                            }

                            coordinates.Append(cylinderEdge.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                            coordinates.Append(",");
                            coordinates.Append(cylinderEdge.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                            coordinates.Append(",");
                            coordinates.Append(cylinder.LowerAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));
                        }

                        element = document.CreateElement("coordinates", m_kmlNamespaceUri);
                        element.InnerText = coordinates.ToString();
                        cylinderLineLineStringElement.AppendChild(element);
                    }
				}

				foreach (Line line in this.Lines)
				{
					XmlElement cylinderFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
					featuresFolderElement.AppendChild(cylinderFolderElement);

					element = document.CreateElement("name", m_kmlNamespaceUri);
					element.InnerText = line.Name;
					cylinderFolderElement.AppendChild(element);

					// Feature line

					XmlElement lineLinePlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
					cylinderFolderElement.AppendChild(lineLinePlacemarkElement);

					element = document.CreateElement("name", m_kmlNamespaceUri);
					element.InnerText = line.Name + " Line";
					lineLinePlacemarkElement.AppendChild(element);

					element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
					element.InnerText = "#" + line.StyleName;
					lineLinePlacemarkElement.AppendChild(element);

					XmlElement lineLineLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
					lineLinePlacemarkElement.AppendChild(lineLineLineStringElement);

					if (options.ClampTrackToGround)
					{
						element = document.CreateElement("tessellate", m_kmlNamespaceUri);
						element.InnerText = "1";
						lineLineLineStringElement.AppendChild(element);
					}
					else
					{
						element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
						element.InnerText = "absolute";
						lineLineLineStringElement.AppendChild(element);
					}

					System.Text.StringBuilder coordinates = new System.Text.StringBuilder();

					coordinates.Append(line.From.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
					coordinates.Append(",");
					coordinates.Append(line.From.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
					coordinates.Append(",");
                    coordinates.Append(line.UpperAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));

					coordinates.Append(" ");

					coordinates.Append(line.To.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
					coordinates.Append(",");
					coordinates.Append(line.To.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
					coordinates.Append(",");
                    coordinates.Append(line.UpperAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));

					element = document.CreateElement("coordinates", m_kmlNamespaceUri);
					element.InnerText = coordinates.ToString();
					lineLineLineStringElement.AppendChild(element);

					// Feature line extrusion

					if (!options.ClampTrackToGround)
					{
						XmlElement lineLineExtrusionPlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
						cylinderFolderElement.AppendChild(lineLineExtrusionPlacemarkElement);

						element = document.CreateElement("name", m_kmlNamespaceUri);
						element.InnerText = line.Name + " Line Extrusion";
						lineLineExtrusionPlacemarkElement.AppendChild(element);

						element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
						element.InnerText = "#" + line.ExtrusionStyleName;
						lineLineExtrusionPlacemarkElement.AppendChild(element);

						XmlElement lineLineExtrusionLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
						lineLineExtrusionPlacemarkElement.AppendChild(lineLineExtrusionLineStringElement);

						element = document.CreateElement("extrude", m_kmlNamespaceUri);
						element.InnerText = "1";
						lineLineExtrusionLineStringElement.AppendChild(element);

						element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
						element.InnerText = "absolute";
						lineLineExtrusionLineStringElement.AppendChild(element);

						element = document.CreateElement("coordinates", m_kmlNamespaceUri);
						element.InnerText = coordinates.ToString();
						lineLineExtrusionLineStringElement.AppendChild(element);
					}

                    // Feature lower line

                    if (!options.ClampTrackToGround)
                    {
                        lineLinePlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
                        cylinderFolderElement.AppendChild(lineLinePlacemarkElement);

                        element = document.CreateElement("name", m_kmlNamespaceUri);
                        element.InnerText = line.Name + " Line";
                        lineLinePlacemarkElement.AppendChild(element);

                        element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
                        element.InnerText = "#" + line.StyleName;
                        lineLinePlacemarkElement.AppendChild(element);

                        lineLineLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
                        lineLinePlacemarkElement.AppendChild(lineLineLineStringElement);

                        element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
                        if (line.LowerAltitude != Location.UnknownAltitude)
                        {
                            element.InnerText = "absolute";
                        }
                        else
                        {
                            element.InnerText = "clampToGround";
                        }
                        lineLineLineStringElement.AppendChild(element);

                        coordinates = new System.Text.StringBuilder();

                        coordinates.Append(line.From.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                        coordinates.Append(",");
                        coordinates.Append(line.From.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                        coordinates.Append(",");
                        coordinates.Append(line.LowerAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));

                        coordinates.Append(" ");

                        coordinates.Append(line.To.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                        coordinates.Append(",");
                        coordinates.Append(line.To.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                        coordinates.Append(",");
                        coordinates.Append(line.LowerAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));

                        element = document.CreateElement("coordinates", m_kmlNamespaceUri);
                        element.InnerText = coordinates.ToString();
                        lineLineLineStringElement.AppendChild(element);
                    }
				}

                foreach (Polygon polygon in this.Polygons)
                {
                    XmlElement cylinderFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
                    featuresFolderElement.AppendChild(cylinderFolderElement);

                    element = document.CreateElement("name", m_kmlNamespaceUri);
                    element.InnerText = polygon.Name;
                    cylinderFolderElement.AppendChild(element);

                    // Feature line

                    XmlElement cylinderLinePlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
                    cylinderFolderElement.AppendChild(cylinderLinePlacemarkElement);

                    element = document.CreateElement("name", m_kmlNamespaceUri);
                    element.InnerText = polygon.Name + " Line";
                    cylinderLinePlacemarkElement.AppendChild(element);

                    element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
                    element.InnerText = "#" + polygon.StyleName;
                    cylinderLinePlacemarkElement.AppendChild(element);

                    XmlElement cylinderLineLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
                    cylinderLinePlacemarkElement.AppendChild(cylinderLineLineStringElement);

                    if (options.ClampTrackToGround || polygon.ClampToGround)
                    {
                        element = document.CreateElement("tessellate", m_kmlNamespaceUri);
                        element.InnerText = "1";
                        cylinderLineLineStringElement.AppendChild(element);
                    }
                    else
                    {
                        element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
                        element.InnerText = "absolute";
                        cylinderLineLineStringElement.AppendChild(element);
                    }

                    System.Text.StringBuilder coordinates = new System.Text.StringBuilder();

                    foreach (Location vertex in polygon.Vertices)
                    {
                        if (coordinates.Length > 0)
                        {
                            coordinates.Append(" ");
                        }

                        coordinates.Append(vertex.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                        coordinates.Append(",");
                        coordinates.Append(vertex.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                        coordinates.Append(",");
                        coordinates.Append(polygon.UpperAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));
                    }
                    coordinates.Append(" ");
                    coordinates.Append(polygon.Vertices[0].Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                    coordinates.Append(",");
                    coordinates.Append(polygon.Vertices[0].Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                    coordinates.Append(",");
                    coordinates.Append(polygon.UpperAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));

                    element = document.CreateElement("coordinates", m_kmlNamespaceUri);
                    element.InnerText = coordinates.ToString();
                    cylinderLineLineStringElement.AppendChild(element);

                    // Feature line extrusion

                    if (!options.ClampTrackToGround && !polygon.ClampToGround)
                    {
                        XmlElement cylinderLineExtrusionPlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
                        cylinderFolderElement.AppendChild(cylinderLineExtrusionPlacemarkElement);

                        element = document.CreateElement("name", m_kmlNamespaceUri);
                        element.InnerText = polygon.Name + " Line Extrusion";
                        cylinderLineExtrusionPlacemarkElement.AppendChild(element);

                        element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
                        element.InnerText = "#" + polygon.ExtrusionStyleName;
                        cylinderLineExtrusionPlacemarkElement.AppendChild(element);

                        XmlElement cylinderLineExtrusionLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
                        cylinderLineExtrusionPlacemarkElement.AppendChild(cylinderLineExtrusionLineStringElement);

                        element = document.CreateElement("extrude", m_kmlNamespaceUri);
                        element.InnerText = "1";
                        cylinderLineExtrusionLineStringElement.AppendChild(element);

                        element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
                        element.InnerText = "absolute";
                        cylinderLineExtrusionLineStringElement.AppendChild(element);

                        element = document.CreateElement("coordinates", m_kmlNamespaceUri);
                        element.InnerText = coordinates.ToString();
                        cylinderLineExtrusionLineStringElement.AppendChild(element);
                    }

                    // Feature lower line

                    if (!options.ClampTrackToGround)
                    {
                        cylinderLinePlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
                        cylinderFolderElement.AppendChild(cylinderLinePlacemarkElement);

                        element = document.CreateElement("name", m_kmlNamespaceUri);
                        element.InnerText = polygon.Name + " Lower Line";
                        cylinderLinePlacemarkElement.AppendChild(element);

                        element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
                        element.InnerText = "#" + polygon.StyleName;
                        cylinderLinePlacemarkElement.AppendChild(element);

                        cylinderLineLineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
                        cylinderLinePlacemarkElement.AppendChild(cylinderLineLineStringElement);

                        if (polygon.LowerAltitude != Location.UnknownAltitude)
                        {
                            element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
                            element.InnerText = "absolute";
                            cylinderLineLineStringElement.AppendChild(element);
                        }
                        else
                        {
                            element = document.CreateElement("altitudeMode", m_kmlNamespaceUri);
                            element.InnerText = "clampToGround";
                            cylinderLineLineStringElement.AppendChild(element);
                        }

                        coordinates = new System.Text.StringBuilder();

                        foreach (Location vertex in polygon.Vertices)
                        {
                            if (coordinates.Length > 0)
                            {
                                coordinates.Append(" ");
                            }

                            coordinates.Append(vertex.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                            coordinates.Append(",");
                            coordinates.Append(vertex.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                            coordinates.Append(",");
                            coordinates.Append(polygon.LowerAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));
                        }
                        coordinates.Append(" ");
                        coordinates.Append(polygon.Vertices[0].Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                        coordinates.Append(",");
                        coordinates.Append(polygon.Vertices[0].Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
                        coordinates.Append(",");
                        coordinates.Append(polygon.LowerAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture));

                        element = document.CreateElement("coordinates", m_kmlNamespaceUri);
                        element.InnerText = coordinates.ToString();
                        cylinderLineLineStringElement.AppendChild(element);
                    }
                }
            }

            document.Save(filePath.Replace("/", ""));
        }

        public void Save(string filePath)
        {
            Save(filePath, new KmlSaveOptions());
        }

        public System.Collections.ObjectModel.Collection<Placemark> Placemarks { get; set; }

        public System.Collections.ObjectModel.Collection<Cylinder> Cylinders { get; set; }
		public System.Collections.ObjectModel.Collection<Line> Lines { get; set; }
        public System.Collections.ObjectModel.Collection<Polygon> Polygons { get; set; }
		public System.Collections.ObjectModel.Collection<Label> Labels { get; set; }

		internal static string[] FileExtensions
		{
			get { return new string[] { ".kml" }; }
		}

		private static void InsertStyleElement(string id, string iconUrl, decimal iconScale, string lineColor, int lineWidth, string polyColor, string labelColor, decimal labelScale, XmlElement parentElement)
		{
			XmlElement element;

			XmlElement styleElement = parentElement.OwnerDocument.CreateElement("Style", m_kmlNamespaceUri);
			styleElement.SetAttribute("id", id);
			parentElement.AppendChild(styleElement);

			if (!string.IsNullOrEmpty(iconUrl))
			{
				XmlElement iconStyleElement = parentElement.OwnerDocument.CreateElement("IconStyle", m_kmlNamespaceUri);
				styleElement.AppendChild(iconStyleElement);

				if (iconScale != 1)
				{
					element = parentElement.OwnerDocument.CreateElement("scale", m_kmlNamespaceUri);
					element.InnerText = iconScale.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
					iconStyleElement.AppendChild(element);
				}

				XmlElement iconElement = parentElement.OwnerDocument.CreateElement("Icon", m_kmlNamespaceUri);
				iconStyleElement.AppendChild(iconElement);

				element = parentElement.OwnerDocument.CreateElement("href", m_kmlNamespaceUri);
				element.InnerText = iconUrl;
				iconElement.AppendChild(element);
			}

			if (!string.IsNullOrEmpty(lineColor) && lineWidth != 0)
			{
				XmlElement lineStyleElement = parentElement.OwnerDocument.CreateElement("LineStyle", m_kmlNamespaceUri);
				styleElement.AppendChild(lineStyleElement);

				element = parentElement.OwnerDocument.CreateElement("color", m_kmlNamespaceUri);
				element.InnerText = lineColor;
				lineStyleElement.AppendChild(element);

				element = parentElement.OwnerDocument.CreateElement("width", m_kmlNamespaceUri);
				element.InnerText = lineWidth.ToString(System.Globalization.CultureInfo.InvariantCulture);
				lineStyleElement.AppendChild(element);
			}

            if (!string.IsNullOrEmpty(polyColor))
            {
                XmlElement polyStyleElement = parentElement.OwnerDocument.CreateElement("PolyStyle", m_kmlNamespaceUri);
                styleElement.AppendChild(polyStyleElement);

                element = parentElement.OwnerDocument.CreateElement("color", m_kmlNamespaceUri);
                element.InnerText = polyColor;
                polyStyleElement.AppendChild(element);

				element = parentElement.OwnerDocument.CreateElement("colorMode", m_kmlNamespaceUri);
				element.InnerText = "normal";
				polyStyleElement.AppendChild(element);
            }

			if (!string.IsNullOrEmpty(labelColor) || labelScale != 1)
			{
				XmlElement labelStyleElement = parentElement.OwnerDocument.CreateElement("LabelStyle", m_kmlNamespaceUri);
				styleElement.AppendChild(labelStyleElement);

				if (!string.IsNullOrEmpty(labelColor))
				{
					element = parentElement.OwnerDocument.CreateElement("color", m_kmlNamespaceUri);
					element.InnerText = labelColor;
					labelStyleElement.AppendChild(element);

					element = parentElement.OwnerDocument.CreateElement("colorMode", m_kmlNamespaceUri);
					element.InnerText = "normal";
					labelStyleElement.AppendChild(element);
				}

				if (labelScale != 1)
				{
					element = parentElement.OwnerDocument.CreateElement("scale", m_kmlNamespaceUri);
					element.InnerText = labelScale.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
					labelStyleElement.AppendChild(element);
				}
			}
		}

		private static void InsertStyleMapElement(string id, string normalStyleUrl, string highlightStyleUrl, XmlElement parentElement)
		{
			XmlElement styleMapElement = parentElement.OwnerDocument.CreateElement("StyleMap", m_kmlNamespaceUri);
			styleMapElement.SetAttribute("id", id);
			parentElement.AppendChild(styleMapElement);

			InsertStyleMapPairElement("normal", normalStyleUrl, styleMapElement);
			InsertStyleMapPairElement("highlight", highlightStyleUrl, styleMapElement);
		}

		private static void InsertStyleMapPairElement(string key, string styleUrl, XmlElement parentElement)
		{
			XmlElement element;

			XmlElement pairElement = parentElement.OwnerDocument.CreateElement("Pair", m_kmlNamespaceUri);
			parentElement.AppendChild(pairElement);

			element = parentElement.OwnerDocument.CreateElement("key", m_kmlNamespaceUri);
			element.InnerText = key;
			pairElement.AppendChild(element);

			element = parentElement.OwnerDocument.CreateElement("styleUrl", m_kmlNamespaceUri);
			element.InnerText = styleUrl;
			pairElement.AppendChild(element);
		}

		private static void InsertFixPlacemarkElement(int fixCount, Tracks.Fix fix, int directionIndicator, KmlSaveOptions options, XmlElement parentElement)
		{
			XmlElement element;

			XmlElement placemarkElement = parentElement.OwnerDocument.CreateElement("Placemark", m_kmlNamespaceUri);
			parentElement.AppendChild(placemarkElement);

			element = parentElement.OwnerDocument.CreateElement("name", m_kmlNamespaceUri);
			element.InnerText = string.Format("Fix {0}", fixCount);
			placemarkElement.AppendChild(element);

			element = parentElement.OwnerDocument.CreateElement("snippet", m_kmlNamespaceUri);
			placemarkElement.AppendChild(element);

			InsertPointDescriptionElement(fix, placemarkElement);

			InsertLookAtElement(fix.Latitude, fix.Longitude, 66, 0, placemarkElement);

			XmlElement timeStampElement = parentElement.OwnerDocument.CreateElement("TimeStamp", m_kmlNamespaceUri);
			placemarkElement.AppendChild(timeStampElement);

			element = parentElement.OwnerDocument.CreateElement("when", m_kmlNamespaceUri);
			element.InnerText = fix.Time.ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
			timeStampElement.AppendChild(element);

			element = parentElement.OwnerDocument.CreateElement("styleUrl", m_kmlNamespaceUri);
			element.InnerText = string.Format("#this.Track-{0}", directionIndicator);
			placemarkElement.AppendChild(element);

			XmlElement pointElement = parentElement.OwnerDocument.CreateElement("Point", m_kmlNamespaceUri);
			placemarkElement.AppendChild(pointElement);

            if (!options.ClampTrackToGround)
            {
                element = parentElement.OwnerDocument.CreateElement("altitudeMode", m_kmlNamespaceUri);
                element.InnerText = "absolute";
                pointElement.AppendChild(element);
            }

			element = parentElement.OwnerDocument.CreateElement("coordinates", m_kmlNamespaceUri);
			element.InnerText = fix.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture) + "," + fix.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture);
			if (fix.Altitude != Location.UnknownAltitude)
			{
				element.InnerText = element.InnerText + "," + fix.Altitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture);
			}
			pointElement.AppendChild(element);
		}

		private static void InsertLookAtElement(DateTime begin, DateTime end, decimal latitude, decimal longitude, int tilt, int range, XmlElement parentElement)
		{
			XmlElement element;

			XmlElement lookAtElement = parentElement.OwnerDocument.CreateElement("LookAt", m_kmlNamespaceUri);
			parentElement.AppendChild(lookAtElement);

			if (begin != DateTime.MinValue || end != DateTime.MinValue)
			{
				XmlElement timeSpanElement = parentElement.OwnerDocument.CreateElement(m_extensionNamespacePrefix, "TimeSpan", m_extensionNamespaceUri);
				lookAtElement.AppendChild(timeSpanElement);

				if (begin != DateTime.MinValue)
				{
					element = parentElement.OwnerDocument.CreateElement("begin", m_kmlNamespaceUri);
					element.InnerText = begin.ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
					timeSpanElement.AppendChild(element);
				}

				if (end != DateTime.MinValue)
				{
					element = parentElement.OwnerDocument.CreateElement("end", m_kmlNamespaceUri);
					element.InnerText = end.ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
					timeSpanElement.AppendChild(element);
				}
			}

			element = parentElement.OwnerDocument.CreateElement("longitude", m_kmlNamespaceUri);
			element.InnerText = longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture);
			lookAtElement.AppendChild(element);

			element = parentElement.OwnerDocument.CreateElement("latitude", m_kmlNamespaceUri);
			element.InnerText = latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture);
			lookAtElement.AppendChild(element);

			element = parentElement.OwnerDocument.CreateElement("altitude", m_kmlNamespaceUri);
			element.InnerText = "0";
			lookAtElement.AppendChild(element);

			element = parentElement.OwnerDocument.CreateElement("heading", m_kmlNamespaceUri);
			element.InnerText = "0";
			lookAtElement.AppendChild(element);

			element = parentElement.OwnerDocument.CreateElement("tilt", m_kmlNamespaceUri);
			element.InnerText = tilt.ToString(System.Globalization.CultureInfo.InvariantCulture);
			lookAtElement.AppendChild(element);

			element = parentElement.OwnerDocument.CreateElement("range", m_kmlNamespaceUri);
			element.InnerText = range.ToString(System.Globalization.CultureInfo.InvariantCulture);
			lookAtElement.AppendChild(element);
		}

		private static void InsertLookAtElement(decimal latitude, decimal longitude, int tilt, int range, XmlElement parentElement)
		{
			InsertLookAtElement(DateTime.MinValue, DateTime.MinValue, latitude, longitude, tilt, range, parentElement);
		}

		private static void InsertTrackDescriptionElement(Tracks.Track track, XmlElement parentElement)
		{
			Geolocation.Tracks.TrackStatistics statistics = Geolocation.Tracks.TrackStatistics.GetStatistics(track);

			XmlElement descriptionElement = parentElement.OwnerDocument.CreateElement("description", m_kmlNamespaceUri);
			parentElement.AppendChild(descriptionElement);

			// Use XML DOM to create HTML as it's XML compliant
			XmlDocument htmlFragment = new XmlDocument();

			XmlElement htmlTable = htmlFragment.CreateElement("table");
			htmlFragment.AppendChild(htmlTable);

			XmlElement htmlRow;
			XmlElement htmlCell;

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Distance: " + string.Format("{0:0.0}", statistics.Distance / 1000) + " km";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Min Alt: " + statistics.MinAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture) + " meters";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Max Alt: " + statistics.MaxAltitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture) + " meters";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Max Speed: " + statistics.MaxSpeed.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " km/hour";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Avg Speed: " + statistics.AverageSpeed.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " km/hour";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Start Time: " + statistics.StartTime.ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "End Time: " + statistics.EndTime.ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
			htmlRow.AppendChild(htmlCell);

			XmlCDataSection cdata = parentElement.OwnerDocument.CreateCDataSection(htmlFragment.OuterXml);
			descriptionElement.AppendChild(cdata);
		}

		private static void InsertDirectionIndicatorStyleMap(int directionIndicator, XmlElement parentElement)
		{
			string styleMapId = "this.Track-" + directionIndicator.ToString(System.Globalization.CultureInfo.InvariantCulture);

			string normalStyleId = "this.Track-" + directionIndicator.ToString(System.Globalization.CultureInfo.InvariantCulture) + "_n";
			string highlightStyleId = "this.Track-" + directionIndicator.ToString(System.Globalization.CultureInfo.InvariantCulture) + "_h";

			InsertStyleElement(normalStyleId, "http://earth.google.com/images/kml-icons/track-directional/track-" + directionIndicator.ToString(System.Globalization.CultureInfo.InvariantCulture) + ".png", 0.5M, string.Empty, 1, string.Empty, string.Empty, 0, parentElement);
			InsertStyleElement(highlightStyleId, "http://earth.google.com/images/kml-icons/track-directional/track-" + directionIndicator.ToString(System.Globalization.CultureInfo.InvariantCulture) + ".png", 1.2M, string.Empty, 1, string.Empty, string.Empty, 0, parentElement);
			InsertStyleMapElement(styleMapId, "#" + normalStyleId, "#" + highlightStyleId, parentElement);
		}

		private static void InsertPointDescriptionElement(Tracks.Fix fix, XmlElement parentElement)
		{
			XmlElement descriptionElement = parentElement.OwnerDocument.CreateElement("description", m_kmlNamespaceUri);
			parentElement.AppendChild(descriptionElement);

			// Use XML DOM to create HTML as it's XML compliant
			XmlDocument htmlFragment = new XmlDocument();

			XmlElement htmlTable = htmlFragment.CreateElement("table");
			htmlFragment.AppendChild(htmlTable);

			XmlElement htmlRow;
			XmlElement htmlCell;

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Latitude: " + fix.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture);
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Longitude: " + fix.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture);
			htmlRow.AppendChild(htmlCell);

			if (fix.Altitude != Tracks.Fix.UnknownAltitude)
			{
				htmlRow = htmlFragment.CreateElement("tr");
				htmlTable.AppendChild(htmlRow);

				htmlCell = htmlFragment.CreateElement("td");
				htmlCell.InnerText = "Altitude: " + fix.Altitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture) + " meters";
				htmlRow.AppendChild(htmlCell);
			}

			if (fix.Speed != Tracks.Fix.UnknownSpeed)
			{
				htmlRow = htmlFragment.CreateElement("tr");
				htmlTable.AppendChild(htmlRow);

				htmlCell = htmlFragment.CreateElement("td");
				htmlCell.InnerText = "Speed: " + fix.Speed.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + " km/hour";
				htmlRow.AppendChild(htmlCell);
			}

			if (fix.Heading != Tracks.Fix.UnknownHeading)
			{
				htmlRow = htmlFragment.CreateElement("tr");
				htmlTable.AppendChild(htmlRow);

				htmlCell = htmlFragment.CreateElement("td");
				htmlCell.InnerText = "Heading: " + fix.Heading.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
				htmlRow.AppendChild(htmlCell);
			}

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Time: " + fix.Time.ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
			htmlRow.AppendChild(htmlCell);

			XmlCDataSection cdata = parentElement.OwnerDocument.CreateCDataSection(htmlFragment.OuterXml);
			descriptionElement.AppendChild(cdata);
		}

		private static void InsertLabelDescriptionElement(Label label, XmlElement parentElement)
		{
			XmlElement descriptionElement = parentElement.OwnerDocument.CreateElement("description", m_kmlNamespaceUri);
			parentElement.AppendChild(descriptionElement);

			// Use XML DOM to create HTML as it's XML compliant
			XmlDocument htmlFragment = new XmlDocument();

			XmlElement htmlTable = htmlFragment.CreateElement("table");
			htmlFragment.AppendChild(htmlTable);

			XmlElement htmlRow;
			XmlElement htmlCell;

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Latitude: " + label.Location.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture);
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Longitude: " + label.Location.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture);
			htmlRow.AppendChild(htmlCell);

			if (label.Location.Altitude != Location.UnknownAltitude)
			{
				htmlRow = htmlFragment.CreateElement("tr");
				htmlTable.AppendChild(htmlRow);

				htmlCell = htmlFragment.CreateElement("td");
				htmlCell.InnerText = "Altitude: " + label.Location.Altitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture) + " meters";
				htmlRow.AppendChild(htmlCell);
			}

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Time: " + label.Time.ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
			htmlRow.AppendChild(htmlCell);

			XmlCDataSection cdata = parentElement.OwnerDocument.CreateCDataSection(htmlFragment.OuterXml);
			descriptionElement.AppendChild(cdata);
		}

		private static void GetTrackCenter(Tracks.Track track, out decimal latitude, out decimal longitude)
		{
			decimal minLatitude = track.Fixes[0].Latitude;
			decimal maxLatitude = track.Fixes[0].Latitude;
			decimal minLongitude = track.Fixes[0].Longitude;
			decimal maxLongitude = track.Fixes[0].Longitude;

			foreach (Tracks.Fix fix in track.Fixes)
			{
				if (fix.Latitude < minLatitude)
				{
					minLatitude = fix.Latitude;
				}
				else if (fix.Latitude > maxLatitude)
				{
					maxLatitude = fix.Latitude;
				}

				if (fix.Longitude < minLongitude)
				{
					minLongitude = fix.Longitude;
				}
				else if (fix.Longitude > maxLongitude)
				{
					maxLongitude = fix.Longitude;
				}
			}

			latitude = minLatitude + ((maxLatitude - minLatitude) / 2);
			longitude = minLongitude + ((maxLongitude - minLongitude) / 2);
		}

		private static int CalculateLookAtRange(Tracks.Track track)
		{
			// Get this.Track bounds and use distance between bottom left and top right

			decimal minLatitude = track.Fixes[0].Latitude;
			decimal maxLatitude = track.Fixes[0].Latitude;
			decimal minLongitude = track.Fixes[0].Longitude;
			decimal maxLongitude = track.Fixes[0].Longitude;

			foreach (Tracks.Fix fix in track.Fixes)
			{
				if (fix.Latitude < minLatitude)
				{
					minLatitude = fix.Latitude;
				}
				else if (fix.Latitude > maxLatitude)
				{
					maxLatitude = fix.Latitude;
				}

				if (fix.Longitude < minLongitude)
				{
					minLongitude = fix.Longitude;
				}
				else if (fix.Longitude > maxLongitude)
				{
					maxLongitude = fix.Longitude;
				}
			}

			Location bottomLeft = new Location(minLatitude, minLongitude);
			Location topRight = new Location(maxLatitude, maxLongitude);

			HaversineDistanceCalculator distanceCalculator = new HaversineDistanceCalculator();

			return System.Convert.ToInt32(distanceCalculator.CalculateDistance(bottomLeft, topRight));
		}
	}
}
