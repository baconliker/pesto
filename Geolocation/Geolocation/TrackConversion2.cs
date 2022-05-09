using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
    public class TrackConversion2
    {
        public TrackConversion2(string sourceFilePath, Files.File.FileFormat sourceFileFormat, string destinationFilePath, Files.File.FileFormat destinationFileFormat)
        {
            this.SourceFilePath = sourceFilePath;
            this.SourceFileFormat = sourceFileFormat;

            this.DestinationFilePath = destinationFilePath;
            this.DestinationFileFormat = destinationFileFormat;
        }

        public void Convert(bool ignoreFixErrors)
        {
			Files.File sourceFile;

			switch (this.SourceFileFormat)
			{
				case Files.File.FileFormat.Gpx:
					sourceFile = new Files.Gpx(this.SourceFilePath);
					break;

				case Files.File.FileFormat.Igc:
					sourceFile = new Files.Igc(this.SourceFilePath, ignoreFixErrors);
					break;

				case Files.File.FileFormat.Nmea:
					sourceFile = new Files.Nmea(this.SourceFilePath, ignoreFixErrors);
					break;

				default:
					// TODO: Use specific exception
					throw new Files.FileLoadException("Loading not supported for this file format.");
			}

			switch (this.DestinationFileFormat)
			{
				case Files.File.FileFormat.Gpx:
					Files.Gpx gpx = new Files.Gpx();
					gpx.Track = sourceFile.Track;
					gpx.Save(this.DestinationFilePath);

					break;

				case Files.File.FileFormat.Kml:
					Files.Kml kml = new Files.Kml();
					kml.Track = sourceFile.Track;
					kml.Save(this.DestinationFilePath);

					break;

				default:
					// TODO: Use specific exception
					throw new Files.FileSaveException("Saving not supported for this file format.");
			}
        }

		public void Convert()
		{
			Convert(false);
		}

        public string SourceFilePath { get; set; }
        public Files.File.FileFormat SourceFileFormat { get; set; }

        public string DestinationFilePath { get; set; }
        public Files.File.FileFormat DestinationFileFormat { get; set; }
    }
}
