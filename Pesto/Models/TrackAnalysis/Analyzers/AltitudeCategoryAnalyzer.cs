using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Analyzers
{
	class AltitudeCategoryAnalyzer : IAnalyzer
	{
		public event EventHandler<EventOccurredEventArgs> EventOccurred;

		private const double m_tolerancePercentage = 80;

		private const int m_slidingWindowLength = 5;

		private List<Geolocation.Tracks.Fix> m_slidingWindow = new List<Geolocation.Tracks.Fix>(m_slidingWindowLength);

		private bool m_minReached = false;

		private bool m_belowMin = false;
		private Geolocation.Tracks.Fix m_belowFix = null;
		private decimal m_lowestAltitude;

		public AltitudeCategoryAnalyzer(int minAltitude)
		{
			this.MinAltitude = minAltitude;

			m_lowestAltitude = this.MinAltitude;
		}

		public void AnalyzeFix(Geolocation.Tracks.Track track, int fixIndex)
		{
			// Add current fix to sliding window
			m_slidingWindow.Add(track.Fixes[fixIndex]);
			if (m_slidingWindow.Count > m_slidingWindowLength)
			{
				m_slidingWindow.RemoveAt(0);
			}

			if (m_slidingWindow.Count == m_slidingWindowLength)
			{
				// Check if we've ever reached the min altitude an ignore if we haven't
				// This is to prevent flagging a min altitude violation during take-off/climb-out
				if (m_minReached)
				{
					if (fixIndex == track.Fixes.Count - 1)
					{
						if (m_belowMin)
						{
							// We've come to the end of the track and we're still below min altitude i.e. landing

							FinalDescentStarted(m_belowFix);
						}
					}
					else
					{
						decimal lowestAltitude;

						if (MinAltitudeBreachDetected(out lowestAltitude))
						{
							if (!m_belowMin)
							{
								m_belowMin = true;
								m_belowFix = m_slidingWindow[0];
							}

							if (lowestAltitude < m_lowestAltitude)
							{
								m_lowestAltitude = lowestAltitude;
							}
						}
						else
						{
							if (m_belowMin)
							{
								MinAltitudeBreached(m_belowFix, track.Fixes[fixIndex], m_lowestAltitude);

								m_belowMin = false;
								m_belowFix = null;
								m_lowestAltitude = this.MinAltitude;
							}
						}
					}
				}
				else
				{
					if (InitialAscentCompleteDetected())
					{
						// This is the first time we've been above the min altitude i.e. we've just finished climbing out
						InitialAscentComplete(m_slidingWindow[0]);

						m_minReached = true;
					}
					else if (fixIndex == track.Fixes.Count - 1)
					{
						// We've never reached the min altitude
						MinAltitudeBreached(track.Fixes[0], track.Fixes[fixIndex], track.Fixes[0].Altitude);
					}
				}
			}
		}

		public int MinAltitude { get; set; }

		protected void OnEventOccurred(EventOccurredEventArgs e)
		{
			if (EventOccurred != null)
			{
				EventOccurred(this, e);
			}
		}

		private bool InitialAscentCompleteDetected()
		{
			int altitudeAboveMinimumCount = 0;

			for (int i = 1; i < m_slidingWindow.Count; i++)
			{
				if (m_slidingWindow[i].Altitude > this.MinAltitude && m_slidingWindow[i].Altitude != Geolocation.Location.UnknownAltitude && m_slidingWindow[i - 1].Altitude != Geolocation.Location.UnknownAltitude)
				{
					altitudeAboveMinimumCount++;
				}
			}

			double altitudeAboveMinimumPercentage = Convert.ToDouble(altitudeAboveMinimumCount / (m_slidingWindowLength - 1) * 100);

			if (altitudeAboveMinimumPercentage >= m_tolerancePercentage)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool MinAltitudeBreachDetected(out decimal lowestAltitude)
		{
			int minAltitudeBreachCount = 0;

			lowestAltitude = Geolocation.Location.UnknownAltitude;

			for (int i = 1; i < m_slidingWindow.Count; i++)
			{
				if (m_slidingWindow[i].Altitude < this.MinAltitude && m_slidingWindow[i].Altitude != Geolocation.Location.UnknownAltitude && m_slidingWindow[i - 1].Altitude != Geolocation.Location.UnknownAltitude)
				{
					minAltitudeBreachCount++;

					if (m_slidingWindow[i].Altitude < lowestAltitude || lowestAltitude == Geolocation.Location.UnknownAltitude)
					{
						lowestAltitude = m_slidingWindow[i].Altitude;
					}
				}
			}

			double minAltitudeBreachPercentage = Convert.ToDouble(minAltitudeBreachCount / (m_slidingWindowLength - 1) * 100);

			if (minAltitudeBreachPercentage >= m_tolerancePercentage)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void InitialAscentComplete(Geolocation.Tracks.Fix fix)
		{
			Events.TrackEvent trackEvent;

			trackEvent = new Events.InitialAscent();
			trackEvent.Time = fix.Time;
			trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);

			OnEventOccurred(new EventOccurredEventArgs(trackEvent));
		}

		private void MinAltitudeBreached(Geolocation.Tracks.Fix downFix, Geolocation.Tracks.Fix upFix, decimal lowestAltitude)
		{
			Events.TrackEvent trackEvent;

			trackEvent = new Events.BelowMinAltitude(Convert.ToInt32(lowestAltitude), upFix.Time.Subtract(downFix.Time));
			trackEvent.Time = downFix.Time;
			trackEvent.Location = new Geolocation.Location(downFix.Latitude, downFix.Longitude, downFix.Altitude);

			OnEventOccurred(new EventOccurredEventArgs(trackEvent));
		}

		private void FinalDescentStarted(Geolocation.Tracks.Fix fix)
		{
			Events.TrackEvent trackEvent;

			trackEvent = new Events.FinalDescent();
			trackEvent.Time = fix.Time;
			trackEvent.Location = new Geolocation.Location(fix.Latitude, fix.Longitude, fix.Altitude);

			OnEventOccurred(new EventOccurredEventArgs(trackEvent));
		}
	}
}
