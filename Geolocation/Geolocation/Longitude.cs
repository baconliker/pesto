using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
	class Longitude
	{
		/// <summary>
		/// Converts the string representation of a longitude into a longitude value
		/// </summary>
		/// <param name="s">The string representation of the longitude. Can be in the format DDDMMMMM or DDDMM.MMM</param>
		/// <returns>The longitude in decimal degrees</returns>
		public static decimal Parse(string s)
		{
			// Conversion between lat/lon formats can be found here:
			// http://en.wikipedia.org/wiki/Geographic_coordinate_conversion

			int degrees = int.Parse(s.Substring(0, 3), System.Globalization.CultureInfo.InvariantCulture);
			decimal minutes;

			string minutesText = s.Substring(3, s.Length - 4);

			if (minutesText.IndexOf(".") == -1)
			{
				minutes = decimal.Parse(minutesText.Substring(0, 2) + "." + minutesText.Substring(2), System.Globalization.CultureInfo.InvariantCulture);
			}
			else
			{
				minutes = decimal.Parse(minutesText, System.Globalization.CultureInfo.InvariantCulture);
			}

			decimal decimalDegrees = degrees + (minutes / 60);

			if (s.EndsWith("W", true, System.Globalization.CultureInfo.InvariantCulture))
			{
				decimalDegrees *= -1;
			}

			return decimalDegrees;
		}
	}
}
