using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class InitialAscent : TrackEvent
	{
		public InitialAscent()
			: base(EventType.InitialAscent)
		{
		}

		public override string Description
		{
			get
			{
				return "Initial ascent complete";
			}
		}
	}
}
