using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Analyzers
{
	class GpsCategoryAnalyzer : IAnalyzer
	{
		public event EventHandler<EventOccurredEventArgs> EventOccurred;

		public GpsCategoryAnalyzer(int gpsUpdateInterval)
		{
			this.GpsUpdateInterval = gpsUpdateInterval;
		}

		public void AnalyzeFix(Geolocation.Tracks.Track track, int fixIndex)
		{
			if (fixIndex == 0)
			{
				Events.TrackEvent trackEvent = new Events.FirstFix();
				trackEvent.Time = track.Fixes[fixIndex].Time;
				trackEvent.Location = new Geolocation.Location(track.Fixes[fixIndex].Latitude, track.Fixes[fixIndex].Longitude, track.Fixes[fixIndex].Altitude);

				OnEventOccurred(new EventOccurredEventArgs(trackEvent));
			}
			else if (fixIndex == track.Fixes.Count - 1)
			{
				Events.TrackEvent trackEvent = new Events.LastFix();
				trackEvent.Time = track.Fixes[fixIndex].Time;
				trackEvent.Location = new Geolocation.Location(track.Fixes[fixIndex].Latitude, track.Fixes[fixIndex].Longitude, track.Fixes[fixIndex].Altitude);

				OnEventOccurred(new EventOccurredEventArgs(trackEvent));
			}

			if (fixIndex < track.Fixes.Count - 1)
			{
				// Check for fix being lost

				TimeSpan difference = track.Fixes[fixIndex + 1].Time.Subtract(track.Fixes[fixIndex].Time);

				if (difference.TotalSeconds > this.GpsUpdateInterval)
				{
					Events.TrackEvent trackEvent = new Events.FixLost(Convert.ToInt32(difference.TotalSeconds));
					trackEvent.Time = track.Fixes[fixIndex].Time.AddSeconds(this.GpsUpdateInterval);
					trackEvent.Location = new Geolocation.Location(track.Fixes[fixIndex].Latitude, track.Fixes[fixIndex].Longitude, track.Fixes[fixIndex].Altitude);

					OnEventOccurred(new EventOccurredEventArgs(trackEvent));
				}
			}
		}

		public int GpsUpdateInterval { get; set; }

		protected void OnEventOccurred(EventOccurredEventArgs e)
		{
			if (EventOccurred != null)
			{
				EventOccurred(this, e);
			}
		}
	}
}
