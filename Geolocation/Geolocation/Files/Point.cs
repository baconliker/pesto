using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Geolocation.Files
{
    public class Point : Geometry
    {
        public Point(Location coordinates) : base(GeometryType.Point)
        {
            this.Coordinates = coordinates;
        }

        public Location Coordinates { get; set; }
    }
}
