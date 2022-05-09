using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ColinBaker.Geolocation.Tracks.Gpx
{
	public class GpxEncoder : IEncoder
	{
		private const string m_latLonFormat = "0.000000";
		private const string m_altitudeFormat = "0.00";

		public void Encode(Track track, System.IO.FileStream stream)
		{
			XmlDocument document = new XmlDocument();

			XmlElement gpxElement = document.CreateElement("gpx", GpxFileFormat.NamespaceUri);
			document.AppendChild(gpxElement);

			gpxElement.SetAttribute("xmlns", GpxFileFormat.NamespaceUri);

			XmlElement metadataElement = document.CreateElement("metadata", GpxFileFormat.NamespaceUri);
			gpxElement.AppendChild(metadataElement);

			XmlElement timeElement = document.CreateElement("time", GpxFileFormat.NamespaceUri);
			timeElement.InnerText = DateTime.UtcNow.ToString(GpxFileFormat.DateTimeFormat);
			metadataElement.AppendChild(timeElement);

			XmlElement trkElement = document.CreateElement("trk", GpxFileFormat.NamespaceUri);
			gpxElement.AppendChild(trkElement);

			if (!string.IsNullOrWhiteSpace(track.Name))
			{
				XmlElement nameElement = document.CreateElement("name", GpxFileFormat.NamespaceUri);
				nameElement.InnerText = track.Name;
				trkElement.AppendChild(nameElement);
			}

			XmlElement trksegElement = document.CreateElement("trkseg", GpxFileFormat.NamespaceUri);
			trkElement.AppendChild(trksegElement);

			foreach (Fix fix in track.Fixes)
			{
				XmlElement trkptElement = document.CreateElement("trkpt", GpxFileFormat.NamespaceUri);
				trksegElement.AppendChild(trkptElement);

				trkptElement.SetAttribute("lat", fix.Latitude.ToString(m_latLonFormat));
				trkptElement.SetAttribute("lon", fix.Longitude.ToString(m_latLonFormat));

				if (fix.Altitude != Location.UnknownAltitude)
				{
					XmlElement eleElement = document.CreateElement("ele", GpxFileFormat.NamespaceUri);
					eleElement.InnerText = fix.Altitude.ToString(m_altitudeFormat);
					trkptElement.AppendChild(eleElement);
				}

				XmlElement pointTimeElement = document.CreateElement("time", GpxFileFormat.NamespaceUri);
				pointTimeElement.InnerText = fix.Time.ToUniversalTime().ToString(GpxFileFormat.DateTimeFormat);
				trkptElement.AppendChild(pointTimeElement);
			}

			document.Save(stream);
		}
	}
}
