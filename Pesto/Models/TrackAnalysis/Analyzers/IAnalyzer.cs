using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Analyzers
{
	interface IAnalyzer
	{
		event EventHandler<EventOccurredEventArgs> EventOccurred;
		void AnalyzeFix(Geolocation.Tracks.Track track, int fixIndex);
	}
}
