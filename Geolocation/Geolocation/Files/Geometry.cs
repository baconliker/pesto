using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Geolocation.Files
{
    public class Geometry
    {
        public enum GeometryType
        {
            Point,
            Polygon
        }

        public Geometry(GeometryType type)
        {
            this.Type = type;
        }

        public GeometryType Type { get; set; }
    }
}
