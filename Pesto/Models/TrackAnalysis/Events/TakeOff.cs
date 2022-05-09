using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class TakeOff : TrackEvent
	{
		public TakeOff()
			: base(EventType.TakeOff)
		{
		}

		public override string Description
		{
			get
			{
				return "Take-off";
			}
		}
	}
}
