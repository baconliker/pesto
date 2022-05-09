using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class FirstFix : TrackEvent
	{
		public FirstFix()
			: base(EventType.FirstFix)
		{
		}

		public override string Description
		{
			get
			{
				return "First GPS fix";
			}
		}
	}
}
