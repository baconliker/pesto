using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI
{
	class TrackFileFormatListItem
	{
		public TrackFileFormatListItem(Geolocation.Files.File.FileFormat fileFormat)
		{
			this.FileFormat = fileFormat;
		}

		public Geolocation.Files.File.FileFormat FileFormat { get; set; }

		public override string ToString()
		{
			switch (this.FileFormat)
			{
				case Geolocation.Files.File.FileFormat.Gpx:
					return "GPX (GPS eXchange Format)";
				case Geolocation.Files.File.FileFormat.Igc:
					return "IGC (International Gliding Commission)";
				case Geolocation.Files.File.FileFormat.Kml:
					return "KML (Keyhole Markup Language)";
				case Geolocation.Files.File.FileFormat.Nmea:
					return "NMEA (National Marine Electronics Association)";
				default:
					return "Unknown";
			}
		}
	}
}
