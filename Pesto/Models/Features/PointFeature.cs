using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Features
{
	class PointFeature : Feature
	{
        // TODO: Make configurable. Changed from 250m to 200m for WPC2016 to comply with section 10
		public const int DefaultRadius = 200;

        public PointFeature(string name, Shape shape)
            : base(name, FeatureType.Point)
        {
            this.Shape = shape;
            this.LowerAltitude = Geolocation.Location.UnknownAltitude;
            this.UpperAltitude = Geolocation.Location.UnknownAltitude;
        }

        public PointFeature(string name)
			: base(name, FeatureType.Point)
		{
            this.LowerAltitude = Geolocation.Location.UnknownAltitude;
            this.UpperAltitude = Geolocation.Location.UnknownAltitude;
		}

        public PointFeature Clone(string name)
        {
            PointFeature featureClone = new PointFeature(name);

            Circle circle = this.Shape as Circle;

            featureClone.Shape = new Circle(new Geolocation.Location(circle.Center.Latitude, circle.Center.Longitude, circle.Center.Altitude), circle.Radius);
            featureClone.LowerAltitude = this.LowerAltitude;
            featureClone.UpperAltitude = this.UpperAltitude;

            return featureClone;
        }
        
        public int LowerAltitude { get; set; }
        public int UpperAltitude { get; set; }
	}
}
