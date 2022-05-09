using System;

namespace ColinBaker.Pesto.UI.Reminders
{
	class RemindersFilterListItem
	{
		public enum FilterType
		{
			All,
			Overdue
		}

		public RemindersFilterListItem(FilterType type)
		{
			this.Type = type;
		}

		public FilterType Type { get; private set; }

		public override string ToString()
		{
			switch (this.Type)
			{
				case FilterType.All:
					return "All";
				case FilterType.Overdue:
					return "Overdue";
				default:
					return string.Empty;
			}
		}
	}
}
