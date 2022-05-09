using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
	public class HaversineDistanceCalculator : IDistanceCalculator
	{
		public double CalculateDistance(Location location1, Location location2)
		{
			double dLat = Convert.DegreesToRadians(location2.Latitude - location1.Latitude);
			double dLon = Convert.DegreesToRadians(location2.Longitude - location1.Longitude);

			double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(Convert.DegreesToRadians(location1.Latitude)) * Math.Cos(Convert.DegreesToRadians(location2.Latitude)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
			double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

			return (Earth.Radius * c);
		}
	}
}
