using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks
{
	public class Track
	{
		private string m_name;

		private DateTime m_date = DateTime.MinValue;

		private readonly ObservableCollection<Fix> m_fixes = new ObservableCollection<Fix>();

		public Track()
		{
			m_fixes.CollectionChanging += new EventHandler<NotifyCollectionChangingEventArgs<Fix>>(m_fixes_CollectionChanging);
			m_fixes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(m_fixes_CollectionChanged);
		}

		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public DateTime Date
		{
			get { return m_date; }
			set { m_date = value; }
		}

		public ObservableCollection<Fix> Fixes
		{
			get { return m_fixes; }
		}

		private void m_fixes_CollectionChanging(object sender, NotifyCollectionChangingEventArgs<Fix> e)
		{
			if (m_fixes.Count > 0)
			{
				Fix previousFix = m_fixes[m_fixes.Count - 1];

				// Check validity of this fix
				if (e.Item.Time < previousFix.Time)
				{
					throw new InvalidTrackException("Fix timestamp is invalid, " + e.Item.Time.ToString() + " compared to previous fix of " + previousFix.Time.ToString());
				}
			}
		}

		private void m_fixes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			// Calculate fix heading and speed when a new fix is added
			// This means we don't need to duplicate this for each different file format
			// For now assume that we'll not be removing fixes from a track, if this changes in future we'll need to recalculate

			switch (e.Action)
			{
				case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
					if (e.NewStartingIndex > 0)
					{
						Fix addedFix = m_fixes[e.NewStartingIndex];
						Fix previousFix = m_fixes[e.NewStartingIndex - 1];

						// Calculate statistics
						addedFix.Heading = previousFix.BearingTo(addedFix);
						addedFix.Speed = previousFix.SpeedTo(addedFix);
					}

					break;
			}
		}
	}
}
