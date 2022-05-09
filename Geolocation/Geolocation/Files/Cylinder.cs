using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
	public class Cylinder
	{
		public Cylinder(string name, Location center, int radius, decimal lowerAltitude, decimal upperAltitude, string styleName, string extrusionStyleName)
		{
			this.Name = name;
			this.Center = center;
            this.Radius = radius;
            this.LowerAltitude = lowerAltitude;
            this.UpperAltitude = upperAltitude;

			this.StyleName = styleName;
			this.ExtrusionStyleName = extrusionStyleName;
		}

		public string Name { get; set; }
		public Location Center { get; set; }
        public int Radius { get; set; }
        public decimal LowerAltitude { get; set; }
        public decimal UpperAltitude { get; set; }

		public string StyleName { get; set; }
		public string ExtrusionStyleName { get; set; }
	}
}
