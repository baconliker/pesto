using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ColinBaker.Geolocation.Files
{
	public class Gpx : File
	{
		private const string m_namespaceUri = "http://www.topografix.com/GPX/1/1";
		private const string m_namespacePrefix = "gx";

		private const string m_dateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

		private const string m_latLonFormat = "0.000000";
		private const string m_altitudeFormat = "0.00";

		public Gpx(string filePath)
			: base(FileFormat.Gpx)
        {
			Tracks.Track track = new Tracks.Track();

			XmlDocument document = new XmlDocument();

			document.Load(filePath);

			XmlNamespaceManager namespaceManager = new XmlNamespaceManager(document.NameTable);
			namespaceManager.AddNamespace(m_namespacePrefix, m_namespaceUri);

			XmlNode nameNode;

			nameNode = document.SelectSingleNode("/" + m_namespacePrefix + ":gpx/" + m_namespacePrefix + ":metadata/" + m_namespacePrefix + ":name", namespaceManager);
			if (nameNode != null)
			{
				track.Name = nameNode.InnerText;
			}

			// Use track name in preference to metadata name if it exists
			nameNode = document.SelectSingleNode("/" + m_namespacePrefix + ":gpx/" + m_namespacePrefix + ":track/" + m_namespacePrefix + ":name", namespaceManager);
			if (nameNode != null)
			{
				track.Name = nameNode.InnerText;
			}

			nameNode = document.SelectSingleNode("/" + m_namespacePrefix + ":gpx/" + m_namespacePrefix + ":metadata/" + m_namespacePrefix + ":name", namespaceManager);
			if (nameNode != null)
			{
				track.Name = nameNode.InnerText;
			}

			foreach (XmlNode trkptNode in document.SelectNodes("/" + m_namespacePrefix + ":gpx/" + m_namespacePrefix + ":trk/" + m_namespacePrefix + ":trkseg/" + m_namespacePrefix + ":trkpt", namespaceManager))
			{
				Tracks.Fix fix = new Tracks.Fix();

				XmlNode timeNode = trkptNode.SelectSingleNode(m_namespacePrefix + ":time", namespaceManager);

				fix.Time = DateTime.ParseExact(timeNode.InnerText, m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal);
				fix.Latitude = decimal.Parse(trkptNode.Attributes["lat"].InnerText, System.Globalization.CultureInfo.InvariantCulture);
				fix.Longitude = decimal.Parse(trkptNode.Attributes["lon"].InnerText, System.Globalization.CultureInfo.InvariantCulture);

				XmlNode eleNode = trkptNode.SelectSingleNode(m_namespacePrefix + ":ele", namespaceManager);

				if (eleNode != null)
				{
					fix.Altitude = decimal.Parse(eleNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
				}

				track.Fixes.Add(fix);
			}

			this.Track = track;
        }

		public Gpx()
			: base(FileFormat.Gpx)
		{
		}

		public void Save(string filePath)
		{
			SaveFile(filePath);
		}

		internal static string[] FileExtensions
		{
			get { return new string[] { ".gpx" }; }
		}

		private void SaveFile(string filePath)
		{
			XmlDocument document = new XmlDocument();

			XmlElement gpxElement = document.CreateElement("gpx", m_namespaceUri);
			document.AppendChild(gpxElement);

			gpxElement.SetAttribute("xmlns", m_namespaceUri);

			XmlElement metadataElement = document.CreateElement("metadata", m_namespaceUri);
			gpxElement.AppendChild(metadataElement);

			XmlElement timeElement = document.CreateElement("time", m_namespaceUri);
			timeElement.InnerText = DateTime.UtcNow.ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
			metadataElement.AppendChild(timeElement);

			XmlElement trkElement = document.CreateElement("trk", m_namespaceUri);
			gpxElement.AppendChild(trkElement);

			if (!string.IsNullOrWhiteSpace(this.Track.Name))
			{
				XmlElement nameElement = document.CreateElement("name", m_namespaceUri);
				nameElement.InnerText = this.Track.Name;
				trkElement.AppendChild(nameElement);
			}

			XmlElement trksegElement = document.CreateElement("trkseg", m_namespaceUri);
			trkElement.AppendChild(trksegElement);

			foreach (Tracks.Fix fix in this.Track.Fixes)
			{
				XmlElement trkptElement = document.CreateElement("trkpt", m_namespaceUri);
				trksegElement.AppendChild(trkptElement);

				trkptElement.SetAttribute("lat", fix.Latitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));
				trkptElement.SetAttribute("lon", fix.Longitude.ToString(m_latLonFormat, System.Globalization.CultureInfo.InvariantCulture));

				if (fix.Altitude != Location.UnknownAltitude)
				{
					XmlElement eleElement = document.CreateElement("ele", m_namespaceUri);
					eleElement.InnerText = fix.Altitude.ToString(m_altitudeFormat, System.Globalization.CultureInfo.InvariantCulture);
					trkptElement.AppendChild(eleElement);
				}

				XmlElement pointTimeElement = document.CreateElement("time", m_namespaceUri);
				pointTimeElement.InnerText = fix.Time.ToUniversalTime().ToString(m_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
				trkptElement.AppendChild(pointTimeElement);
			}

			document.Save(filePath);
		}
	}
}
