using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI.Features
{
    class ShapeListItem
    {
        public ShapeListItem(Models.Features.Shape.ShapeType type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            switch (this.Type)
            {
                case Models.Features.Shape.ShapeType.Circle:
                    return "Circle";
                case Models.Features.Shape.ShapeType.Line:
                    return "Line";
                case Models.Features.Shape.ShapeType.Polygon:
                    return "Polygon";
                default:
                    return base.ToString();
            }
        }

        public Models.Features.Shape.ShapeType Type;
    }
}
