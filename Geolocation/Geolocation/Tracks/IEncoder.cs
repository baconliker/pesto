using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks
{
	public interface IEncoder
	{
		void Encode(Track track, System.IO.FileStream stream);
	}
}
