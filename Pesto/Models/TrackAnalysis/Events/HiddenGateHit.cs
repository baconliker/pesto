using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class HiddenGateHit : TrackEvent
	{
		public HiddenGateHit(Features.GateFeature gate)
			: base(EventType.HiddenGateHit)
		{
			this.Gate = gate;
		}

		public Features.GateFeature Gate { get; private set; }

		public override string Description
		{
			get
			{
				return "Hidden gate '" + this.Gate.Name + "' hit";
			}
		}
	}
}
