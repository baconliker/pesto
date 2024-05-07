using System;

namespace ColinBaker.Pesto.Models.Features
{
	internal class PointOfInterestFeature : Feature
	{
		public PointOfInterestFeature(string name, Shape shape) : base(name, FeatureType.PointOfInterest)
		{
			this.Shape = shape;
		}

		public PointOfInterestFeature(string name) : base(name, FeatureType.PointOfInterest)
		{
		}
	}
}
