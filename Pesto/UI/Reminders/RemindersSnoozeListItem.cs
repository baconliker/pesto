using System;
using System.Text;

namespace ColinBaker.Pesto.UI.Reminders
{
	class RemindersSnoozeListItem
	{
		public RemindersSnoozeListItem(TimeSpan interval)
		{
			this.Interval = interval;
		}

		public override string ToString()
		{
			StringBuilder snoozeText = new StringBuilder();

			if (this.Interval.Hours > 0)
			{
				snoozeText.Append(this.Interval.Hours);
				snoozeText.Append(" hour");

				if (this.Interval.Hours > 1)
				{
					snoozeText.Append("s");
				}
			}

			if (this.Interval.Minutes > 0)
			{
				if (snoozeText.Length > 0)
				{
					snoozeText.Append(" ");
				}

				snoozeText.Append(this.Interval.Minutes);
				snoozeText.Append(" minute");

				if (this.Interval.Minutes > 1)
				{
					snoozeText.Append("s");
				}
			}

			return snoozeText.ToString();
		}

		public TimeSpan Interval { get; set; }
	}
}
