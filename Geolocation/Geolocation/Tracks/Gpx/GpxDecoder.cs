using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ColinBaker.Geolocation.Tracks.Gpx
{
	public class GpxDecoder : IDecoder
	{
		public event EventHandler<TrackConversionEventArgs> Error;

		private const string m_gpxNamespacePrefix = "gx";

		public Track Decode(System.IO.FileStream stream)
		{
			Track track = new Track();

			XmlDocument document = new XmlDocument();
			
			document.Load(stream);

			XmlNamespaceManager namespaceManager = new XmlNamespaceManager(document.NameTable);
			namespaceManager.AddNamespace(m_gpxNamespacePrefix, GpxFileFormat.NamespaceUri);

			XmlNode nameNode;

			nameNode = document.SelectSingleNode("/" + m_gpxNamespacePrefix + ":gpx/" + m_gpxNamespacePrefix + ":metadata/" + m_gpxNamespacePrefix + ":name", namespaceManager);
			if (nameNode != null)
			{
				track.Name = nameNode.InnerText;
			}

			// Use track name in preference to metadata name if it exists
			nameNode = document.SelectSingleNode("/" + m_gpxNamespacePrefix + ":gpx/" + m_gpxNamespacePrefix + ":track/" + m_gpxNamespacePrefix + ":name", namespaceManager);
			if (nameNode != null)
			{
				track.Name = nameNode.InnerText;
			}

			nameNode = document.SelectSingleNode("/" + m_gpxNamespacePrefix + ":gpx/" + m_gpxNamespacePrefix + ":metadata/" + m_gpxNamespacePrefix + ":name", namespaceManager);
			if (nameNode != null)
			{
				track.Name = nameNode.InnerText;
			}

			foreach (XmlNode trkptNode in document.SelectNodes("/" + m_gpxNamespacePrefix + ":gpx/" + m_gpxNamespacePrefix + ":trk/" + m_gpxNamespacePrefix + ":trkseg/" + m_gpxNamespacePrefix + ":trkpt", namespaceManager))
			{
				Fix fix = new Fix();

				try
				{
					XmlNode timeNode = trkptNode.SelectSingleNode(m_gpxNamespacePrefix + ":time", namespaceManager);

					fix.Time = DateTime.ParseExact(timeNode.InnerText, GpxFileFormat.DateTimeFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal);
					fix.Latitude = decimal.Parse(trkptNode.Attributes["lat"].InnerText);
					fix.Longitude = decimal.Parse(trkptNode.Attributes["lon"].InnerText);

					XmlNode eleNode = trkptNode.SelectSingleNode(m_gpxNamespacePrefix + ":ele", namespaceManager);

					if (eleNode != null)
					{
						fix.Altitude = decimal.Parse(eleNode.InnerText);
					}

					track.Fixes.Add(fix);
				}
				catch
				{
					TrackConversionEventArgs eventArgs = new TrackConversionEventArgs(trkptNode.OuterXml);

					OnError(eventArgs);

					if (!eventArgs.SkipError)
					{
						break;
					}
				}
			}

			return track;
		}

		protected void OnError(TrackConversionEventArgs e)
		{
			if (Error != null)
			{
				Error(this, e);
			}
		}
	}
}
