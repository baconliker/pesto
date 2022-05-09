using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Features
{
    class Circle : Shape
    {
        public Circle(Geolocation.Location center, int radius)
            : base(ShapeType.Circle)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public Circle()
            : base(ShapeType.Circle)
        {
        }

        public Geolocation.Location Center { get; set; }
        public int Radius { get; set; }
    }
}
