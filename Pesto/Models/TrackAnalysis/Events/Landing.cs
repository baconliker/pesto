using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class Landing : TrackEvent
	{
		public Landing()
			: base(EventType.Landing)
		{
		}

		public override string Description
		{
			get
			{
				return "Landing";
			}
		}
	}
}
