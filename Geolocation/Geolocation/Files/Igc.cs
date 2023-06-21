using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
	public class Igc : File
	{
		private DateTime m_currentDate;

		public Igc(string filePath, bool ignoreFixErrors)
			: base(FileFormat.Igc)
        {
			Tracks.Track track = new Tracks.Track();

			string fileLine;
			int fileLineNumber = 0;

			using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
			{
				while (!reader.EndOfStream)
				{
					fileLine = reader.ReadLine();

					fileLineNumber++;

					try
					{
						// Check what type of record this line represents and process accordingly
						switch (fileLine.Substring(0, 1).ToUpper())
						{
							case "H":
								ProcessHRecord(fileLine, track);
								break;
							case "B":
								ProcessBRecord(fileLine, track);
								break;
						}
					}
					catch (Exception ex)
					{
						if (!ignoreFixErrors)
						{
							throw new FileLoadException(ex.Message + "\n\nRecord:\n" + fileLine, ex);
						}
					}
				}
			}

			this.Track = track;
        }

		public Igc(string filePath)
			: this(filePath, false)
		{
		}

		public Igc()
			: base(FileFormat.Igc)
		{
		}

		internal static string[] FileExtensions
		{
			get { return new string[] { ".igc" }; }
		}

		private void ProcessHRecord(string fileLine, Tracks.Track track)
		{
			// Check the sub-type
			switch (fileLine.Substring(2, 3).ToUpper())
			{
				case "DTE":
					m_currentDate = DateTime.ParseExact(fileLine.Substring(5, 6), "ddMMyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal);
					track.Date = m_currentDate;
					break;
			}
		}

        private void ProcessBRecord(string fileLine, Tracks.Track track)
		{
			Tracks.Fix fix = new Tracks.Fix();

			DateTime fixTime = m_currentDate.Add(TimeSpan.ParseExact(fileLine.Substring(1, 6), "hhmmss", System.Globalization.CultureInfo.InvariantCulture));

			// Since the igc file format only specifies the date once at the beginning we need to handle rollover to the following day
			if (track.Fixes.Count > 0)
			{
				DateTime previousFixTime = track.Fixes[track.Fixes.Count - 1].Time;

				// Handle rollover to the next day
				if (fixTime < previousFixTime)
				{
					fixTime = fixTime.AddDays(1);
					m_currentDate = m_currentDate.AddDays(1);
				}
			}

			fix.Time = fixTime;
			fix.Latitude = Latitude.Parse(fileLine.Substring(7, 8));
			fix.Longitude = Longitude.Parse(fileLine.Substring(15, 9));

			if (string.Compare(fileLine.Substring(24, 1), "A", true) == 0)
			{
				fix.Altitude = decimal.Parse(fileLine.Substring(30, 5), System.Globalization.CultureInfo.InvariantCulture);
			}

			track.Fixes.Add(fix);
		}
	}
}
