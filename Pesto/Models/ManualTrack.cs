using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models
{
	class ManualTrack
	{
		public Task Task { get; set; }
		public int PilotNumber { get; set; }
		public string TrackFilePath { get; set; }

		public override string ToString()
		{
			return this.TrackFilePath;
		}
	}
}
