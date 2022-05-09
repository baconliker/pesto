using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class NoFlyZoneIncursion : TrackEvent
	{
		public NoFlyZoneIncursion(Features.NoFlyZoneFeature nfz)
			: base(EventType.NoFlyZoneIncursion)
		{
			this.NoFlyZone = nfz;
		}

		public Features.NoFlyZoneFeature NoFlyZone { get; private set; }

		public override string Description
		{
			get
			{
				return "Incursion of no fly zone '" + this.NoFlyZone.Name + "'";
			}
		}
	}
}
