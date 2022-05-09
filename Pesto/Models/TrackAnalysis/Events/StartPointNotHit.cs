using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class StartPointNotHit : TrackEvent
	{
		public StartPointNotHit(Features.PointFeature startPoint)
			: base(EventType.StartPointNotHit)
		{
			this.StartPoint = startPoint;
		}

		public Features.PointFeature StartPoint { get; private set; }

		public override string Description
		{
			get
			{
				return "Start point '" + this.StartPoint.Name + "' not hit";
			}
		}
	}
}
