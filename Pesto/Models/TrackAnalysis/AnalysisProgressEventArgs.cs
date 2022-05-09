using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis
{
	class AnalysisProgressEventArgs : EventArgs
	{
		public AnalysisProgressEventArgs(int fixes, int currentFix)
		{
			this.Fixes = fixes;
			this.CurrentFix = currentFix;
		}

		public int Fixes { get; set; }
		public int CurrentFix { get; set; }
	}
}
