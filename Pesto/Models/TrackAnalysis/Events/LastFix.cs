using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class LastFix : TrackEvent
	{
		public LastFix()
			: base(EventType.LastFix)
		{
		}

		public override string Description
		{
			get
			{
				return "Last GPS fix";
			}
		}
	}
}
