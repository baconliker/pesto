using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class TrackEventComparer: IComparer<TrackEvent>
	{
		public int Compare(TrackEvent event1, TrackEvent event2)
		{
			if (!event1.TimeSet)
			{
				return 1;
			}

			if (!event2.TimeSet)
			{
				return -1;
			}

			int result = event1.Time.CompareTo(event2.Time);

			if (result == 0)
			{
				result = event1.Sequence.CompareTo(event2.Sequence);
			}

			return result;
		}
	}
}
