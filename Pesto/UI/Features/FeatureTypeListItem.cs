using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.UI.Features
{
    class FeatureTypeListItem
    {
        public FeatureTypeListItem(Models.Features.Feature.FeatureType type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            string typeDescription = string.Empty;

            switch (this.Type)
            {
                case Models.Features.Feature.FeatureType.Airfield:
                    typeDescription = "Airfield";
                    break;
                case Models.Features.Feature.FeatureType.Deck:
                    typeDescription = "Deck";
                    break;
                case Models.Features.Feature.FeatureType.NoFlyZone:
                    typeDescription = "NoFlyZone";
                    break;
                case Models.Features.Feature.FeatureType.Point:
                    typeDescription = "Point";
                    break;
            }

            return typeDescription;
        }

        public Models.Features.Feature.FeatureType Type { get; set; }
    }
}
