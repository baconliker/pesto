using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI.Features
{
	class FeatureListItem
	{
		public FeatureListItem(Models.Features.Feature feature)
		{
			this.Feature = feature;
		}

		public FeatureListItem()
		{
		}

		public Models.Features.Feature Feature { get; set; }

		public override string ToString()
		{
			if (this.Feature == null)
			{
				return "(None)";
			}
			else
			{
				return this.Feature.Name;
			}
		}
	}
}
