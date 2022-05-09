using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
    class FinishGateNotHit : TrackEvent
    {
        public FinishGateNotHit(Features.GateFeature finishGate)
			: base(EventType.FinishGateNotHit)
		{
			this.FinishGate = finishGate;
		}

		public Features.GateFeature FinishGate { get; private set; }

		public override string Description
		{
			get
			{
				return "Finish gate '" + this.FinishGate.Name + "' not hit";
			}
		}
    }
}
