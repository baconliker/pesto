using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Features
{
	class NoFlyZoneFeature : Feature
	{
        public NoFlyZoneFeature(string name, Shape shape)
            : base(name, FeatureType.NoFlyZone)
        {
            this.Shape = shape;
            this.LowerAltitude = Geolocation.Location.UnknownAltitude;
            this.UpperAltitude = Geolocation.Location.UnknownAltitude;
        }

        public NoFlyZoneFeature(string name)
			: base(name, FeatureType.NoFlyZone)
		{
            this.LowerAltitude = Geolocation.Location.UnknownAltitude;
            this.UpperAltitude = Geolocation.Location.UnknownAltitude;
		}

        public NoFlyZoneFeature Clone(string name)
        {
            NoFlyZoneFeature featureClone = new NoFlyZoneFeature(name);

            switch (this.Shape.Type)
            {
                case Shape.ShapeType.Circle:
                    Circle circle = this.Shape as Circle;
                    featureClone.Shape = new Circle(new Geolocation.Location(circle.Center.Latitude, circle.Center.Longitude), circle.Radius);
                    break;
                case Shape.ShapeType.Polygon:
                    Polygon polygon = this.Shape as Polygon;
                    featureClone.Shape = new Polygon();
                    foreach (Geolocation.Location vertex in polygon.Vertices)
                    {
                        (featureClone.Shape as Polygon).Vertices.Add(new Geolocation.Location(vertex.Latitude, vertex.Longitude));
                    }
                    break;
            }
            
            featureClone.LowerAltitude = this.LowerAltitude;
            featureClone.UpperAltitude = this.UpperAltitude;

            return featureClone;
        }

        public int LowerAltitude { get; set; }
        public int UpperAltitude { get; set; }
	}
}
