using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models.Features
{
    class DeckFeature : Feature
    {
        public DeckFeature(string name, Shape shape)
            : base(name, FeatureType.Deck)
        {
            this.Shape = shape;
        }

        public DeckFeature(string name)
			: base(name, FeatureType.Deck)
		{
        }
    }
}
