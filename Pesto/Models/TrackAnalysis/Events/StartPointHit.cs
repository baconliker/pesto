using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class StartPointHit : TrackEvent
	{
		public StartPointHit(Features.PointFeature startPoint)
			: base(EventType.StartPointHit)
		{
			this.StartPoint = startPoint;
		}

		public Features.PointFeature StartPoint { get; private set; }

		public override string Description
		{
			get
			{
				return "Start point '" + this.StartPoint.Name + "' hit";
			}
		}
	}
}
