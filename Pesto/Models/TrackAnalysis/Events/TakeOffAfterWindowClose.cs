using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class TakeOffAfterWindowClose : TrackEvent
	{
		public TakeOffAfterWindowClose()
			: base(EventType.TakeOffAfterWindowClose)
		{
		}

		public override string Description
		{
			get
			{
				return "Take-off after window close";
			}
		}
	}
}
