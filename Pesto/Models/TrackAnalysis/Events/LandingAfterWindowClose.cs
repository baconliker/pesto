using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class LandingAfterWindowClose : TrackEvent
	{
		public LandingAfterWindowClose()
			: base(EventType.LandingAfterWindowClose)
		{
		}

		public override string Description
		{
			get
			{
				return "Landing after window close";
			}
		}
	}
}
