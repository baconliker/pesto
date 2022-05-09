using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
    class StartGateNotHit : TrackEvent
    {
        public StartGateNotHit(Features.GateFeature startGate)
			: base(EventType.StartGateNotHit)
		{
			this.StartGate = startGate;
		}

		public Features.GateFeature StartGate { get; private set; }

		public override string Description
		{
			get
			{
				return "Start gate '" + this.StartGate.Name + "' not hit";
			}
		}
    }
}
