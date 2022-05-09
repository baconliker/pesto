using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class TurnpointHit : TrackEvent
	{
		public TurnpointHit(Features.PointFeature turnpoint)
			: base(EventType.TurnpointHit)
		{
			this.Turnpoint = turnpoint;
		}

		public Features.PointFeature Turnpoint { get; private set; }

		public override string Description
		{
			get
			{
				return "Turnpoint '" + this.Turnpoint.Name + "' hit";
			}
		}
	}
}
