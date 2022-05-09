using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Features
{
	abstract class Feature
	{
		public enum FeatureType
		{
			NoFlyZone,
			Airfield,
			Deck,
			Point,
			Gate
		}

		protected Feature(string name, FeatureType type)
		{
			this.Name = name;
			this.Type = type;
		}

		public string Name { get; set; }
		public FeatureType Type { get; private set; }
        public Shape Shape { get; set; }
    }
}
