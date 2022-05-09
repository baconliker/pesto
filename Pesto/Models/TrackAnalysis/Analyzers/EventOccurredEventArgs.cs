using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Analyzers
{
	class EventOccurredEventArgs : EventArgs
	{
		public EventOccurredEventArgs(Events.TrackEvent trackEvent)
		{
			this.TrackEvent = trackEvent;
		}

		public Events.TrackEvent TrackEvent { get; set; }
	}
}
