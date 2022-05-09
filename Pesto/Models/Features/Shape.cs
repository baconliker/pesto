using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Features
{
    abstract class Shape
    {
        public enum ShapeType
        {
            Circle,
            Line,
            Polygon
        }

        protected Shape(ShapeType type)
		{
			this.Type = type;
		}

        public ShapeType Type { get; private set; }
    }
}
