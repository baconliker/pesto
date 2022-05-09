using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks
{
	public class TrackStatistics
	{
		private TrackStatistics(DateTime startTime, DateTime endTime)
		{
			this.StartTime = startTime;
			this.EndTime = endTime;

			this.MinAltitude = Location.UnknownAltitude;
			this.MaxAltitude = Location.UnknownAltitude;
			this.MaxSpeed = Fix.UnknownSpeed;
			this.AverageSpeed = Fix.UnknownSpeed;
		}

		public static TrackStatistics GetStatistics(Track track)
		{
			TrackStatistics statistics = new TrackStatistics(track.Fixes[0].Time, track.Fixes[track.Fixes.Count - 1].Time);

			double cumulativeDistance = 0;
			double cumulativeSpeed = 0;

			for (int i = 0; i < track.Fixes.Count; i++)
			{
				if (i > 0)
				{
					cumulativeDistance += track.Fixes[i - 1].DistanceTo(track.Fixes[i]);
					cumulativeSpeed += track.Fixes[i].Speed;
				}

				if (track.Fixes[i].Altitude != Location.UnknownAltitude && (statistics.MinAltitude == Location.UnknownAltitude || track.Fixes[i].Altitude < statistics.MinAltitude))
				{
					statistics.MinAltitude = track.Fixes[i].Altitude;
				}

				if (track.Fixes[i].Altitude != Location.UnknownAltitude && (statistics.MaxAltitude == Location.UnknownAltitude || track.Fixes[i].Altitude > statistics.MaxAltitude))
				{
					statistics.MaxAltitude = track.Fixes[i].Altitude;
				}

				if (track.Fixes[i].Speed != Fix.UnknownSpeed && (statistics.MaxSpeed == Fix.UnknownSpeed || track.Fixes[i].Speed > statistics.MaxSpeed))
				{
					statistics.MaxSpeed = track.Fixes[i].Speed;
				}
			}

			statistics.Distance = cumulativeDistance;
			statistics.AverageSpeed = cumulativeSpeed / track.Fixes.Count - 1;

			return statistics;
		}

		public DateTime StartTime { get; private set; }
		public DateTime EndTime { get; private set; }
		public double Distance { get; private set; }
		public decimal MinAltitude { get; private set; }
		public decimal MaxAltitude { get; private set; }
		public double MaxSpeed { get; private set; }
		public double AverageSpeed { get; private set; }
	}
}
