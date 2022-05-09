using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
    public class Placemark
    {
        public Placemark(string name, Geometry geometry)
        {
            this.Name = name;
            this.Geometry = geometry;
        }

        public string Name { get; set; }
        public Geometry Geometry { get; set; }
    }
}
