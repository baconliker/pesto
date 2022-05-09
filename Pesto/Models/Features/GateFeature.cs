using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Features
{
	class GateFeature : Feature
	{
        // TODO: Make configurable. Changed from 500m to 250m for WPC2016
        public const int DefaultWidth = 250;
        public const int DefaultBearing = 0;

		public GateFeature(string name, Shape shape)
			: base(name, FeatureType.Gate)
		{
            this.Shape = shape;
            this.LowerAltitude = Geolocation.Location.UnknownAltitude;
            this.UpperAltitude = Geolocation.Location.UnknownAltitude;
		}

		public GateFeature(string name)
			: base(name, FeatureType.Gate)
		{
            this.LowerAltitude = Geolocation.Location.UnknownAltitude;
            this.UpperAltitude = Geolocation.Location.UnknownAltitude;
		}

        public int LowerAltitude { get; set; }
        public int UpperAltitude { get; set; }
	}
}
