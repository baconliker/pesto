using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class FixLost : TrackEvent
	{

		public FixLost(int duration)
			: base(EventType.FixLost)
		{
			this.Duration = duration;
		}

		public int Duration { get; private set; }

		public override string Description
		{
			get
			{
				if (this.Duration == 1)
				{
					return string.Format("GPS fix lost for {0} second", this.Duration);
				}
				else
				{
					return string.Format("GPS fix lost for {0} seconds", this.Duration);
				}
			}
		}
	}
}
