using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
    class StartGateHit : TrackEvent
    {
        public StartGateHit(Features.GateFeature startGate)
			: base(EventType.StartGateHit)
		{
			this.StartGate = startGate;
		}

		public Features.GateFeature StartGate { get; private set; }

		public override string Description
		{
			get
			{
				return "Start gate '" + this.StartGate.Name + "' hit";
			}
		}
    }
}
