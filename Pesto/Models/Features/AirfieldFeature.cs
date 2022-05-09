using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models.Features
{
    class AirfieldFeature : Feature
    {
        public AirfieldFeature(string name, Shape shape)
            : base(name, FeatureType.Airfield)
        {
            this.Shape = shape;
        }

        public AirfieldFeature(string name)
			: base(name, FeatureType.Airfield)
		{
        }
    }
}
