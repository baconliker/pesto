using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class FinishPointNotHit : TrackEvent
	{
		public FinishPointNotHit(Features.PointFeature finishPoint)
			: base(EventType.FinishPointNotHit)
		{
			this.FinishPoint = finishPoint;
		}

		public Features.PointFeature FinishPoint { get; private set; }

		public override string Description
		{
			get
			{
				return "Finish point '" + this.FinishPoint.Name + "' not hit";
			}
		}
	}
}
