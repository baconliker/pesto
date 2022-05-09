using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
    //TODO: Find a better name than line
	public class Line
	{
        public Line(string name, Location from, Location to, decimal lowerAltitude, decimal upperAltitude, string styleName, string extrusionStyleName)
		{
			this.Name = name;
			this.From = from;
			this.To = to;
            this.LowerAltitude = lowerAltitude;
            this.UpperAltitude = upperAltitude;

            this.StyleName = styleName;
            this.ExtrusionStyleName = extrusionStyleName;
        }

		public string Name { get; set; }
		public Location From { get; set; }
		public Location To { get; set; }
        public decimal LowerAltitude { get; set; }
        public decimal UpperAltitude { get; set; }

        public string StyleName { get; set; }
        public string ExtrusionStyleName { get; set; }
    }
}
