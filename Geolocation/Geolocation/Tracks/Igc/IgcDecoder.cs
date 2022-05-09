using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks.Igc
{
	public class IgcDecoder : IDecoder
	{
		public event EventHandler<TrackConversionEventArgs> Error;

		public Track Decode(System.IO.FileStream stream)
		{
			Track track = new Track();
			string fileLine;
			int fileLineNumber = 0;

			using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
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
					catch
					{
						TrackConversionEventArgs eventArgs = new TrackConversionEventArgs(fileLineNumber, fileLine);

						OnError(eventArgs);

						if (!eventArgs.SkipError)
						{
							break;
						}
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

		private void ProcessHRecord(string fileLine, Track track)
		{
			// Check the sub-type
			switch (fileLine.Substring(2, 3).ToUpper())
			{
				case "DTE":
					track.Date = DateTime.ParseExact(fileLine.Substring(5, 6), "ddMMyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal);
					break;
			}
		}

		private void ProcessBRecord(string fileLine, Track track)
		{
			Fix fix = new Fix();

			fix.Time = track.Date.Add(TimeSpan.ParseExact(fileLine.Substring(1, 6), "hhmmss", System.Globalization.CultureInfo.InvariantCulture));
			fix.Latitude = Latitude.Parse(fileLine.Substring(7, 8));
			fix.Longitude = Longitude.Parse(fileLine.Substring(15, 9));

			if (string.Compare(fileLine.Substring(24, 1), "A", true) == 0)
			{
				fix.Altitude = decimal.Parse(fileLine.Substring(30, 5));
			}

			track.Fixes.Add(fix);
		}
	}
}
