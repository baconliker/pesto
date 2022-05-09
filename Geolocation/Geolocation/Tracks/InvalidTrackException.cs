using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks
{
	class InvalidTrackException : Exception
	{
		public InvalidTrackException(string message)
			: base(message)
		{
		}
	}
}
