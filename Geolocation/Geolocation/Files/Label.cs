using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
	public class Label
	{
		public Label(string name, DateTime time, Location location, string styleName)
		{
			this.Name = name;
			this.Time = time;
			this.Location = location;
			this.StyleName = styleName;
		}

		public string Name { get; set; }
		public DateTime Time { get; set; }
		public Location Location { get; set; }
		public string StyleName { get; set; }
	}
}
