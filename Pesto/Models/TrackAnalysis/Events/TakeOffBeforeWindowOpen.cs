using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class TakeOffBeforeWindowOpen : TrackEvent
	{
		public TakeOffBeforeWindowOpen()
			: base(EventType.TakeOffBeforeWindowOpen)
		{
		}

		public override string Description
		{
			get
			{
				return "Take-off before window open";
			}
		}
	}
}
