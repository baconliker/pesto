using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI
{
	public class MapClickedEventArgs : EventArgs
	{
		public MapClickedEventArgs(Geolocation.Location location)
		{
			this.Location = location;
		}

		public Geolocation.Location Location { get; set; }
	}
}
