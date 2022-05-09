using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
	interface IDistanceCalculator
	{
		double CalculateDistance(Location location1, Location location2);
	}
}
