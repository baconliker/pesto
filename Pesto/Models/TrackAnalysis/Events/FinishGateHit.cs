using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
    class FinishGateHit : TrackEvent
    {
        public FinishGateHit(Features.GateFeature finishGate)
			: base(EventType.FinishGateHit)
		{
			this.FinishGate = finishGate;
		}

		public Features.GateFeature FinishGate { get; private set; }

		public override string Description
		{
			get
			{
				return "Finish gate '" + this.FinishGate.Name + "' hit";
			}
		}
    }
}
