using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks.Nmea
{
	public class NmeaDecoder : IDecoder
	{
		public event EventHandler<TrackConversionEventArgs> Error;

		private DateTime m_currentDate = DateTime.MinValue;

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
						string[] sentenceData = fileLine.Split(',');

						// Check what type of record this line represents and process accordingly
						switch (sentenceData[0].ToUpper())
						{
							case "$GPRMC":
								ProcessRmcSentence(sentenceData, track);
								break;
							case "$GPGGA":
								ProcessGgaSentence(sentenceData, track);
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

		private void ProcessRmcSentence(string[] sentenceData, Track track)
		{
			// Only retrieve the date from this sentence, all the other data we need is in the GGA sentence
			m_currentDate = DateTime.ParseExact(sentenceData[9], "ddMMyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal);

			if (track.Date == DateTime.MinValue)
			{
				track.Date = m_currentDate;
			}
		}

		private void ProcessGgaSentence(string[] sentenceData, Track track)
		{
			if (m_currentDate != DateTime.MinValue)
			{
				if (string.Compare(sentenceData[6], "0") != 0)
				{
					Fix fix = new Fix();

					fix.Time = m_currentDate.Add(TimeSpan.ParseExact(sentenceData[1].Substring(0, 6), "hhmmss", System.Globalization.CultureInfo.InvariantCulture));
					fix.Latitude = Latitude.Parse((sentenceData[2] + sentenceData[3]));
					fix.Longitude = Longitude.Parse((sentenceData[4] + sentenceData[5]));

					if (!string.IsNullOrWhiteSpace(sentenceData[9]))
					{
						if (string.Compare(sentenceData[10], "M", true) == 0)
						{
							fix.Altitude = decimal.Parse(sentenceData[9]);
						}
					}

					track.Fixes.Add(fix);
				}
			}
		}
	}
}
