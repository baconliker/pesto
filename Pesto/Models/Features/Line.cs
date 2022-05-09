using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models.Features
{
    class Line : Shape
    {
        public Line(Geolocation.Location center, int width, decimal bearing) : base(ShapeType.Line)
        {
            this.Center = center;
            this.Width = width;
            this.Bearing = bearing;
        }

        public Line() : base(ShapeType.Line)
        {
        }

        public Geolocation.Location Center { get; set; }
        public int Width { get; set; }
        public decimal Bearing { get; set; }
    }
}
