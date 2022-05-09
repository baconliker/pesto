using System;
using System.Xml;

namespace ColinBaker.Geolocation.Tracks.Kml
{
	public class KmlEncoder : IEncoder
	{
        private const string m_kmlNamespaceUri = "http://www.opengis.net/kml/2.2";

		private const string m_extensionNamespacePrefix = "gx";
		private const string m_extensionNamespaceUri = "http://www.google.com/kml/ext/2.2";

		private const string m_dateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
		private const string m_latLonFormat = "0.000000";
		private const string m_altitudeFormat = "0.0";

        private const string m_defaultTrackName = "GPS Track";

		public void Encode(Track track, System.IO.FileStream stream)
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
            if (!string.IsNullOrWhiteSpace(track.Name))
            {
                nameElement.InnerText = track.Name;
            }
            else
            {
                nameElement.InnerText = m_defaultTrackName;
            }
            documentElement.AppendChild(nameElement);

            if (track.Fixes.Count > 0)
            {
                decimal centerLatitude;
                decimal centerLongitude;

                GetTrackCenter(track, out centerLatitude, out centerLongitude);

				InsertLookAtElement(track.Fixes[0].Time.ToUniversalTime(), track.Fixes[track.Fixes.Count - 1].Time.ToUniversalTime(), centerLatitude, centerLongitude, 0, CalculateLookAtRange(track), documentElement);
            }

            InsertStyleElement("multiTrack_n", "http://earth.google.com/images/kml-icons/track-directional/track-0.png", 1, "99ffac59", 6, -1, documentElement);
            InsertStyleElement("multiTrack_h", "http://earth.google.com/images/kml-icons/track-directional/track-0.png", 1.2M, "99ffac59", 8, -1, documentElement);
            InsertStyleMapElement("multiTrack", "#multiTrack_n", "#multiTrack_h", documentElement);

            InsertStyleElement("lineStyle", string.Empty, 1, "99ffac59", 6, -1, documentElement);

            XmlElement tracksFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
            documentElement.AppendChild(tracksFolderElement);

            element = document.CreateElement("name", m_kmlNamespaceUri);
            element.InnerText = "Tracks";
            tracksFolderElement.AppendChild(element);

			XmlElement placemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
            tracksFolderElement.AppendChild(placemarkElement);

            element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
            element.InnerText = "#multiTrack";
            placemarkElement.AppendChild(element);

			XmlElement trackElement = document.CreateElement(m_extensionNamespacePrefix, "Track", m_extensionNamespaceUri);
			placemarkElement.AppendChild(trackElement);

			foreach (Fix fix in track.Fixes)
			{
				XmlElement whenElement = document.CreateElement("when", m_kmlNamespaceUri);
				whenElement.InnerText = fix.Time.ToUniversalTime().ToString(m_dateTimeFormat);
				trackElement.AppendChild(whenElement);
			}

			foreach (Fix fix in track.Fixes)
			{
				XmlElement coordElement = document.CreateElement(m_extensionNamespacePrefix, "coord", m_extensionNamespaceUri);
				coordElement.InnerText = fix.Longitude.ToString(m_latLonFormat) + " " + fix.Latitude.ToString(m_latLonFormat);
				if (fix.Altitude != Location.UnknownAltitude)
				{
					coordElement.InnerText = coordElement.InnerText + " " + fix.Altitude.ToString(m_altitudeFormat);
				}
				trackElement.AppendChild(coordElement);
			}

            XmlElement unnamedFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
            tracksFolderElement.AppendChild(unnamedFolderElement);

            element = document.CreateElement("snippet", m_kmlNamespaceUri);
            element.InnerText = "";
            unnamedFolderElement.AppendChild(element);

			InsertTrackDescriptionElement(track, unnamedFolderElement);

            XmlElement tracksTimeSpanElement = document.CreateElement("TimeSpan", m_kmlNamespaceUri);
            unnamedFolderElement.AppendChild(tracksTimeSpanElement);

            element = document.CreateElement("begin", m_kmlNamespaceUri);
            element.InnerText = track.Fixes[0].Time.ToUniversalTime().ToString(m_dateTimeFormat);
            tracksTimeSpanElement.AppendChild(element);

            element = document.CreateElement("end", m_kmlNamespaceUri);
            element.InnerText = track.Fixes[track.Fixes.Count - 1].Time.ToUniversalTime().ToString(m_dateTimeFormat);
            tracksTimeSpanElement.AppendChild(element);

            XmlElement pointsFolderElement = document.CreateElement("Folder", m_kmlNamespaceUri);
            unnamedFolderElement.AppendChild(pointsFolderElement);

            element = document.CreateElement("name", m_kmlNamespaceUri);
            element.InnerText = "Points";
            pointsFolderElement.AppendChild(element);

            int bearing;
            int directionIndicator;
            System.Collections.Generic.List<int> directionsUsed = new System.Collections.Generic.List<int>();

            for (int i = 0; i < track.Fixes.Count; i++)
            {
                if (i == 0)
                {
                    bearing = 0;
                }
                else
                {
                    bearing = track.Fixes[i - 1].BearingTo(track.Fixes[i]);
                }

                // Determine direction in increments of 22.5 degrees (0 - 15)
                directionIndicator = (int)Math.Round(bearing / 22.5, MidpointRounding.AwayFromZero) % 16;

                if (!directionsUsed.Contains(directionIndicator))
                {
                    directionsUsed.Add(directionIndicator);
                }

				InsertPointPlacemarkElement(i, track.Fixes[i], directionIndicator, pointsFolderElement);
            }

            foreach (int direction in directionsUsed)
            {
                InsertDirectionIndicatorStyleMap(direction, documentElement);
            }

            XmlElement pathPlacemarkElement = document.CreateElement("Placemark", m_kmlNamespaceUri);
            tracksFolderElement.AppendChild(pathPlacemarkElement);

            element = document.CreateElement("name", m_kmlNamespaceUri);
            element.InnerText = "Path";
            pathPlacemarkElement.AppendChild(element);

            element = document.CreateElement("styleUrl", m_kmlNamespaceUri);
            element.InnerText = "#lineStyle";
            pathPlacemarkElement.AppendChild(element);

            XmlElement lineStringElement = document.CreateElement("LineString", m_kmlNamespaceUri);
            pathPlacemarkElement.AppendChild(lineStringElement);

            element = document.CreateElement("tessellate", m_kmlNamespaceUri);
            element.InnerText = "1";
            lineStringElement.AppendChild(element);

            System.Text.StringBuilder coordinates = new System.Text.StringBuilder();

            foreach (Fix fix in track.Fixes)
            {
                if (coordinates.Length > 0)
                {
                    coordinates.Append(" ");
                }

                coordinates.Append(fix.Longitude.ToString(m_latLonFormat));
                coordinates.Append(",");
                coordinates.Append(fix.Latitude.ToString(m_latLonFormat));
                if (fix.Altitude != Fix.UnknownAltitude)
                {
                    coordinates.Append(",");
                    coordinates.Append(fix.Altitude.ToString(m_altitudeFormat));
                }
            }

            element = document.CreateElement("coordinates", m_kmlNamespaceUri);
            element.InnerText = coordinates.ToString();
            lineStringElement.AppendChild(element);

			document.Save(stream);
		}

        private void InsertStyleElement(string id, string iconUrl, decimal iconScale, string lineColor, int lineWidth, decimal labelScale, XmlElement parentElement)
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
                    element.InnerText = iconScale.ToString("0.0");
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
                element.InnerText = lineWidth.ToString();
                lineStyleElement.AppendChild(element);
            }

            if (labelScale != 1)
            {
                XmlElement labelStyleElement = parentElement.OwnerDocument.CreateElement("LabelStyle", m_kmlNamespaceUri);
                styleElement.AppendChild(labelStyleElement);

                element = parentElement.OwnerDocument.CreateElement("scale", m_kmlNamespaceUri);
                element.InnerText = labelScale.ToString("0.0");
                labelStyleElement.AppendChild(element);
            }
        }

        private void InsertStyleMapElement(string id, string normalStyleUrl, string highlightStyleUrl, XmlElement parentElement)
        {
            XmlElement styleMapElement = parentElement.OwnerDocument.CreateElement("StyleMap", m_kmlNamespaceUri);
            styleMapElement.SetAttribute("id", id);
            parentElement.AppendChild(styleMapElement);

            InsertStyleMapPairElement("normal", normalStyleUrl, styleMapElement);
            InsertStyleMapPairElement("highlight", highlightStyleUrl, styleMapElement);
        }

        private void InsertStyleMapPairElement(string key, string styleUrl, XmlElement parentElement)
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

        private void InsertPointPlacemarkElement(int fixIndex, Fix fix, int directionIndicator, XmlElement parentElement)
        {
            XmlElement element;

            XmlElement placemarkElement = parentElement.OwnerDocument.CreateElement("Placemark", m_kmlNamespaceUri);
            parentElement.AppendChild(placemarkElement);

            element = parentElement.OwnerDocument.CreateElement("name", m_kmlNamespaceUri);
            element.InnerText = string.Format("-{0}", fixIndex);
            placemarkElement.AppendChild(element);

            element = parentElement.OwnerDocument.CreateElement("snippet", m_kmlNamespaceUri);
            placemarkElement.AppendChild(element);

			InsertPointDescriptionElement(fix, placemarkElement);

            InsertLookAtElement(fix.Latitude, fix.Longitude, 66, 0, placemarkElement);

            XmlElement timeStampElement = parentElement.OwnerDocument.CreateElement("TimeStamp", m_kmlNamespaceUri);
            placemarkElement.AppendChild(timeStampElement);

            element = parentElement.OwnerDocument.CreateElement("when", m_kmlNamespaceUri);
            element.InnerText = fix.Time.ToString(m_dateTimeFormat);
            timeStampElement.AppendChild(element);

            element = parentElement.OwnerDocument.CreateElement("styleUrl", m_kmlNamespaceUri);
            element.InnerText = string.Format("#track-{0}", directionIndicator);
            placemarkElement.AppendChild(element);

            XmlElement pointElement = parentElement.OwnerDocument.CreateElement("Point", m_kmlNamespaceUri);
            placemarkElement.AppendChild(pointElement);

            element = parentElement.OwnerDocument.CreateElement("coordinates", m_kmlNamespaceUri);
            element.InnerText = fix.Longitude.ToString(m_latLonFormat) + "," + fix.Latitude.ToString(m_latLonFormat);
            if (fix.Altitude != Location.UnknownAltitude)
            {
                element.InnerText = element.InnerText + "," + fix.Altitude.ToString(m_altitudeFormat);
            }
            pointElement.AppendChild(element);
        }

        private void InsertLookAtElement(DateTime begin, DateTime end, decimal latitude, decimal longitude, int tilt, int range, XmlElement parentElement)
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
                    element.InnerText = begin.ToString(m_dateTimeFormat);
                    timeSpanElement.AppendChild(element);
                }

                if (end != DateTime.MinValue)
                {
                    element = parentElement.OwnerDocument.CreateElement("end", m_kmlNamespaceUri);
					element.InnerText = end.ToString(m_dateTimeFormat);
                    timeSpanElement.AppendChild(element);
                }
            }

            element = parentElement.OwnerDocument.CreateElement("longitude", m_kmlNamespaceUri);
            element.InnerText = longitude.ToString(m_latLonFormat);
            lookAtElement.AppendChild(element);

            element = parentElement.OwnerDocument.CreateElement("latitude", m_kmlNamespaceUri);
            element.InnerText = latitude.ToString(m_latLonFormat);
            lookAtElement.AppendChild(element);

            element = parentElement.OwnerDocument.CreateElement("altitude", m_kmlNamespaceUri);
            element.InnerText = "0";
            lookAtElement.AppendChild(element);

            element = parentElement.OwnerDocument.CreateElement("heading", m_kmlNamespaceUri);
            element.InnerText = "0";
            lookAtElement.AppendChild(element);

            element = parentElement.OwnerDocument.CreateElement("tilt", m_kmlNamespaceUri);
            element.InnerText = tilt.ToString();
            lookAtElement.AppendChild(element);

            element = parentElement.OwnerDocument.CreateElement("range", m_kmlNamespaceUri);
            element.InnerText = range.ToString();
            lookAtElement.AppendChild(element);
        }

        private void InsertLookAtElement(decimal latitude, decimal longitude, int tilt, int range, XmlElement parentElement)
        {
            InsertLookAtElement(DateTime.MinValue, DateTime.MinValue, latitude, longitude, tilt, range, parentElement);
        }

		private static void InsertTrackDescriptionElement(Track track, XmlElement parentElement)
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
			htmlCell.InnerText = "Distance: " + statistics.Distance.ToString("0.0") + " meters";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Min Alt: " + statistics.MinAltitude.ToString(m_altitudeFormat) + " meters";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Max Alt: " + statistics.MaxAltitude.ToString(m_altitudeFormat) + " meters";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Max Speed: " + statistics.MaxSpeed.ToString("0.0") + " km/hour";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Avg Speed: " + statistics.AverageSpeed.ToString("0.0") + " km/hour";
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Start Time: " + statistics.StartTime.ToString(m_dateTimeFormat);
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "End Time: " + statistics.EndTime.ToString(m_dateTimeFormat);
			htmlRow.AppendChild(htmlCell);

			XmlCDataSection cdata = parentElement.OwnerDocument.CreateCDataSection(htmlFragment.OuterXml);
			descriptionElement.AppendChild(cdata);
		}

        private void InsertDirectionIndicatorStyleMap(int directionIndicator, XmlElement parentElement)
        {
            string styleMapId = "track-" + directionIndicator.ToString();

            string normalStyleId = "track-" + directionIndicator.ToString() + "_n";
            string highlightStyleId = "track-" + directionIndicator.ToString() + "_h";

            InsertStyleElement(normalStyleId, "http://earth.google.com/images/kml-icons/track-directional/track-" + directionIndicator.ToString() + ".png", 0.5M, string.Empty, 1, 0, parentElement);
            InsertStyleElement(highlightStyleId, "http://earth.google.com/images/kml-icons/track-directional/track-" + directionIndicator.ToString() + ".png", 1.2M, string.Empty, 1, 0, parentElement);
            InsertStyleMapElement(styleMapId, "#" + normalStyleId, "#" + highlightStyleId, parentElement);
        }

		private void InsertPointDescriptionElement(Fix fix, XmlElement parentElement)
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
			htmlCell.InnerText = "Longitude: " + fix.Longitude.ToString(m_latLonFormat);
			htmlRow.AppendChild(htmlCell);

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Latitude: " + fix.Latitude.ToString(m_latLonFormat);
			htmlRow.AppendChild(htmlCell);

			if (fix.Altitude != Fix.UnknownAltitude)
			{
				htmlRow = htmlFragment.CreateElement("tr");
				htmlTable.AppendChild(htmlRow);

				htmlCell = htmlFragment.CreateElement("td");
				htmlCell.InnerText = "Altitude: " + fix.Altitude.ToString(m_altitudeFormat) + " meters";
				htmlRow.AppendChild(htmlCell);
			}

			if (fix.Speed != Fix.UnknownSpeed)
			{
				htmlRow = htmlFragment.CreateElement("tr");
				htmlTable.AppendChild(htmlRow);

				htmlCell = htmlFragment.CreateElement("td");
				htmlCell.InnerText = "Speed: " + fix.Speed.ToString("0.0") + " km/hour";
				htmlRow.AppendChild(htmlCell);
			}

			if (fix.Heading != Fix.UnknownHeading)
			{
				htmlRow = htmlFragment.CreateElement("tr");
				htmlTable.AppendChild(htmlRow);

				htmlCell = htmlFragment.CreateElement("td");
				htmlCell.InnerText = "Heading: " + fix.Heading.ToString("0.0");
				htmlRow.AppendChild(htmlCell);
			}

			htmlRow = htmlFragment.CreateElement("tr");
			htmlTable.AppendChild(htmlRow);

			htmlCell = htmlFragment.CreateElement("td");
			htmlCell.InnerText = "Time: " + fix.Time.ToString(m_dateTimeFormat);
			htmlRow.AppendChild(htmlCell);

			XmlCDataSection cdata = parentElement.OwnerDocument.CreateCDataSection(htmlFragment.OuterXml);
			descriptionElement.AppendChild(cdata);
		}

        private void GetTrackCenter(Track track, out decimal latitude, out decimal longitude)
        {
            decimal minLatitude = track.Fixes[0].Latitude;
            decimal maxLatitude = track.Fixes[0].Latitude;
            decimal minLongitude = track.Fixes[0].Longitude;
            decimal maxLongitude = track.Fixes[0].Longitude;

            foreach (Fix fix in track.Fixes)
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

		private int CalculateLookAtRange(Track track)
		{
			// Get track bounds and use distance between bottom left and top right

			decimal minLatitude = track.Fixes[0].Latitude;
			decimal maxLatitude = track.Fixes[0].Latitude;
			decimal minLongitude = track.Fixes[0].Longitude;
			decimal maxLongitude = track.Fixes[0].Longitude;

			foreach (Fix fix in track.Fixes)
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
