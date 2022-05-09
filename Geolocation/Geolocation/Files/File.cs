using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
	public abstract class File
	{
        public enum FileFormat
        {
			Unknown,
            Gpx,
            Igc,
            Kml,
            Nmea
        }

		protected File(FileFormat format)
        {
            this.Format = format;
        }

		public static bool DetermineFileFormat(string filePath, out FileFormat format)
		{
			bool formatDetermined = false;
			System.IO.FileInfo file = new System.IO.FileInfo(filePath);

			// Just use file extension to determine format. In future we could also examine the file contents
			switch (file.Extension)
			{
				case ".gpx":
					format = FileFormat.Gpx;
					formatDetermined = true;
					break;
				case ".igc":
					format = FileFormat.Igc;
					formatDetermined = true;
					break;
				case ".kml":
					format = FileFormat.Kml;
					formatDetermined = true;
					break;
				case ".nmea":
					format = FileFormat.Nmea;
					formatDetermined = true;
					break;
				case ".log":
					format = FileFormat.Nmea;
					formatDetermined = true;
					break;
				default:
					format = FileFormat.Unknown;
					break;
			}

			return formatDetermined;
		}

		public static string[] GetCommonFileExtensions(FileFormat format)
		{
			switch (format)
			{
				case FileFormat.Gpx:
					return Gpx.FileExtensions;
				case FileFormat.Igc:
					return Igc.FileExtensions;
				case FileFormat.Kml:
					return Kml.FileExtensions;
				case FileFormat.Nmea:
					return Nmea.FileExtensions;
				default:
					return new string[] {};
			}
		}

        public FileFormat Format { get; private set; }
		public Tracks.Track Track { get; set; }
	}
}
