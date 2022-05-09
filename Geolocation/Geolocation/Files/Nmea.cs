using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
	public class Nmea : File
	{
        public Nmea(string filePath, bool ignoreFixErrors)
			: base(FileFormat.Nmea)
        {
			Tracks.Track track = new Tracks.Track();

			string fileLine;
			int fileLineNumber = 0;
			DateTime currentDate = DateTime.MinValue;

			using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
			{
				while (!reader.EndOfStream)
				{
					fileLine = reader.ReadLine();

					fileLineNumber++;

					string[] sentenceData = fileLine.Split(',');

					// Check what type of record this line represents and process accordingly
					try
					{
						switch (sentenceData[0].ToUpper())
						{
							case "$GPRMC":
								ProcessRmcSentence(sentenceData, track, ref currentDate);
								break;
							case "$GPGGA":
								ProcessGgaSentence(sentenceData, track, currentDate);
								break;
						}
					}
					catch (Exception ex)
					{
						if (!ignoreFixErrors)
						{
							throw new FileLoadException(ex.Message + "\n\nNMEA sentence:\n" + fileLine, ex);
						}
					}
				}
			}

			this.Track = track;
        }

		public Nmea(string filePath)
			: this(filePath, false)
		{
		}

		public Nmea()
			: base(FileFormat.Nmea)
		{
		}

		internal static string[] FileExtensions
		{
			get { return new string[] { ".nmea", ".log" }; }
		}

        private static void ProcessRmcSentence(string[] sentenceData, Tracks.Track track, ref DateTime currentDate)
		{
			// Only retrieve the date from this sentence, all the other data we need is in the GGA sentence
            currentDate = DateTime.ParseExact(sentenceData[9], "ddMMyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal);

			if (track.Date == DateTime.MinValue)
			{
                track.Date = currentDate;
			}
		}

        private static void ProcessGgaSentence(string[] sentenceData, Tracks.Track track, DateTime currentDate)
		{
            if (currentDate != DateTime.MinValue)
			{
				if (string.Compare(sentenceData[6], "0") != 0)
				{
					Tracks.Fix fix = new Tracks.Fix();

                    fix.Time = currentDate.Add(TimeSpan.ParseExact(sentenceData[1].Substring(0, 6), "hhmmss", System.Globalization.CultureInfo.InvariantCulture));
					fix.Latitude = Latitude.Parse((sentenceData[2] + sentenceData[3]));
					fix.Longitude = Longitude.Parse((sentenceData[4] + sentenceData[5]));

					if (!string.IsNullOrWhiteSpace(sentenceData[9]))
					{
						if (string.Compare(sentenceData[10], "M", true) == 0)
						{
							fix.Altitude = decimal.Parse(sentenceData[9], System.Globalization.CultureInfo.InvariantCulture);
						}
					}

					track.Fixes.Add(fix);
				}
			}
		}
	}
}
