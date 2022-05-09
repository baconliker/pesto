using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
	public class Location
	{
		public const int UnknownAltitude = -99999;

		private decimal m_latitude;
		private decimal m_longitude;
		private decimal m_altitude = UnknownAltitude;

		public Location()
		{
		}

		public Location(decimal latitude, decimal longitude)
		{
			m_latitude = decimal.Round(latitude, 6, MidpointRounding.AwayFromZero);
			m_longitude = decimal.Round(longitude, 6, MidpointRounding.AwayFromZero);
		}

		public Location(decimal latitude, decimal longitude, decimal altitude)
		{
			m_latitude = decimal.Round(latitude, 6, MidpointRounding.AwayFromZero);
			m_longitude = decimal.Round(longitude, 6, MidpointRounding.AwayFromZero);
			m_altitude = altitude;
		}

		public Location Translate(int distanceNorth, int distanceEast)
		{
            // WARNING: Untested

			double dLat = distanceNorth / Earth.Radius;
			double dLon = distanceEast / (Earth.Radius * Math.Cos(Convert.DegreesToRadians(this.Latitude)));

			decimal newLatitude = this.Latitude + Convert.RadiansToDegrees(dLat);
			decimal newLongitude = this.Longitude + Convert.RadiansToDegrees(dLon);

			return new Location(decimal.Round(newLatitude, 6, MidpointRounding.AwayFromZero), decimal.Round(newLongitude, 6, MidpointRounding.AwayFromZero));
		}

        public Location Translate(int distance, double bearing)
        {
            bearing = Convert.DegreesToRadians((decimal)bearing);
            double latitude1 = Convert.DegreesToRadians(this.Latitude);
            double longitude1 = Convert.DegreesToRadians(this.Longitude);

            double angularDistance = (double)distance / Earth.Radius;

            double latitude2 = Math.Asin(Math.Sin(latitude1) * Math.Cos(angularDistance) + Math.Cos(latitude1) * Math.Sin(angularDistance) * Math.Cos(bearing));
            double longitude2 = longitude1 + Math.Atan2(Math.Sin(bearing) * Math.Sin(angularDistance) * Math.Cos(latitude1), Math.Cos(angularDistance) - Math.Sin(latitude1) * Math.Sin(latitude2));

			return new Location(decimal.Round(Convert.RadiansToDegrees(latitude2), 6, MidpointRounding.AwayFromZero), decimal.Round(Convert.RadiansToDegrees(longitude2), 6, MidpointRounding.AwayFromZero));
        }

		public double DistanceTo(Location location)
		{
			Geolocation.HaversineDistanceCalculator distanceCalculator = new Geolocation.HaversineDistanceCalculator();

			return distanceCalculator.CalculateDistance(this, location);
		}

        public int BearingTo(Location location)
        {
            double latitude1 = Convert.DegreesToRadians(this.Latitude);
            double longitude1 = Convert.DegreesToRadians(this.Longitude);
            double latitude2 = Convert.DegreesToRadians(location.Latitude);
            double longitude2 = Convert.DegreesToRadians(location.Longitude);

            double dLon = longitude2 - longitude1;

            double y = Math.Sin(dLon) * Math.Cos(latitude2);
            double x = Math.Cos(latitude1) * Math.Sin(latitude2) - Math.Sin(latitude1) * Math.Cos(latitude2) * Math.Cos(dLon);

            int bearing = (int)Convert.RadiansToDegrees(Math.Atan2(y, x));

            // Translate bearing from the range -180 - +180 to 0 - +360
            return (bearing + 360) % 360;
        }

		public decimal Latitude
		{
			get { return m_latitude; }
			set { m_latitude = decimal.Round(value, 6, MidpointRounding.AwayFromZero); }
		}

		public decimal Longitude
		{
			get { return m_longitude; }
			set { m_longitude = decimal.Round(value, 6, MidpointRounding.AwayFromZero); }
		}

		public decimal Altitude
		{
			get { return m_altitude; }
			set { m_altitude = value; }
		}
	}
}
