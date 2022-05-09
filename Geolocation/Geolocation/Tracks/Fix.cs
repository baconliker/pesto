using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks
{
	public class Fix : Location
	{
		public const int UnknownHeading = -1;
		public const int UnknownSpeed = -1;

		public Fix()
		{
			this.Heading = UnknownHeading;
			this.Speed = UnknownSpeed;
		}

		public Fix(decimal latitude, decimal longitude) : base(latitude, longitude)
		{
			this.Heading = UnknownHeading;
			this.Speed = UnknownSpeed;
		}

		public double SpeedTo(Fix fix)
		{
			double distanceKM = DistanceTo(fix) / 1000;
			TimeSpan time = fix.Time.Subtract(this.Time);

			return distanceKM / time.TotalHours;
		}

		public DateTime Time { get; set; }
		public double Heading { get; set; }
		public double Speed { get; set; }
	}
}
