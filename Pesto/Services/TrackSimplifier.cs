using System;

namespace ColinBaker.Pesto.Services
{
	class TrackSimplifier
	{
		public TrackSimplifier(Geolocation.Tracks.Track sourceTrack)
		{
			this.SourceTrack = sourceTrack;
		}

		public Geolocation.Tracks.Track Simplify(TimeSpan age, TimeSpan fixInterval)
		{
			Geolocation.Tracks.Track simplifiedTrack = new Geolocation.Tracks.Track();

			if (this.SourceTrack.Fixes.Count > 0)
			{
				int fixIndex = this.SourceTrack.Fixes.Count - 1;

				while (fixIndex >= 0 && this.SourceTrack.Fixes[this.SourceTrack.Fixes.Count - 1].Time.Subtract(this.SourceTrack.Fixes[fixIndex].Time) <= age)
				{
					if (simplifiedTrack.Fixes.Count == 0 || simplifiedTrack.Fixes[simplifiedTrack.Fixes.Count - 1].Time.Subtract(this.SourceTrack.Fixes[fixIndex].Time) >= fixInterval)
					{
						simplifiedTrack.Fixes.Insert(0, this.SourceTrack.Fixes[fixIndex]);
					}

					fixIndex--;
				}
			}

			return simplifiedTrack;
		}

		public Geolocation.Tracks.Track SourceTrack { get; private set; }
	}
}
