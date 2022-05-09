using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class FinishPointHit : TrackEvent
	{
		public FinishPointHit(Features.PointFeature finishPoint)
			: base(EventType.FinishPointHit)
		{
			this.FinishPoint = finishPoint;
		}

		public Features.PointFeature FinishPoint { get; private set; }

		public override string Description
		{
			get
			{
				return "Finish point '" + this.FinishPoint.Name + "' hit";
			}
		}
	}
}
