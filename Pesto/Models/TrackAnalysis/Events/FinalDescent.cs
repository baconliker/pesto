using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class FinalDescent : TrackEvent
	{
		public FinalDescent()
			: base(EventType.FinalDescent)
		{
		}

		public override string Description
		{
			get
			{
				return "Final descent started";
			}
		}
	}
}
