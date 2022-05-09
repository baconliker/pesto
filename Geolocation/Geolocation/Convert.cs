using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
	public class Convert
	{
		public static double DegreesToRadians(decimal degrees)
		{
            return (double)degrees * (Math.PI / 180);
		}

		public static decimal RadiansToDegrees(double radians)
		{
            return (decimal)(radians * (180 / Math.PI));
		}

		public static int FeetToMeters(int feet)
		{
			return System.Convert.ToInt32(feet * 0.3048);
		}
	}
}
