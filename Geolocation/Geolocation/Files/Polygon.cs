using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Geolocation.Files
{
    public class Polygon : Geometry
    {
        public Polygon(string name, Location[] vertices, decimal lowerAltitude, decimal upperAltitude, string styleName, string extrusionStyleName) : base(GeometryType.Polygon)
        {
            this.Name = name;
            this.Vertices = vertices;
            this.LowerAltitude = lowerAltitude;
            this.UpperAltitude = upperAltitude;

            this.StyleName = styleName;
            this.ExtrusionStyleName = extrusionStyleName;

            this.ClampToGround = false;
        }

        public Polygon(string name, Location[] vertices, string styleName) : base(GeometryType.Polygon)
        {
            this.Name = name;
            this.Vertices = vertices;
            this.LowerAltitude = Location.UnknownAltitude;
            this.UpperAltitude = Location.UnknownAltitude;

            this.StyleName = styleName;
            this.ExtrusionStyleName = String.Empty;

            this.ClampToGround = true;
        }

        public Polygon() : base(GeometryType.Polygon)
        {
            this.Name = String.Empty;
            this.LowerAltitude = Location.UnknownAltitude;
            this.UpperAltitude = Location.UnknownAltitude;

            this.StyleName = String.Empty;
            this.ExtrusionStyleName = String.Empty;

            this.ClampToGround = true;
        }

        public string Name { get; set; }
        public Location[] Vertices { get; set; }
        public decimal LowerAltitude { get; set; }
        public decimal UpperAltitude { get; set; }

        public string StyleName { get; set; }
        public string ExtrusionStyleName { get; set; }

        //TODO: Add this to all shapes and use instead of global ClampToGround flag
        public bool ClampToGround { get; set; }
    }
}
