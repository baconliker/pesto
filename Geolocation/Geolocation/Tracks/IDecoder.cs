using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks
{
	public interface IDecoder
	{
		event EventHandler<TrackConversionEventArgs> Error;

		Track Decode(System.IO.FileStream stream);
	}
}
