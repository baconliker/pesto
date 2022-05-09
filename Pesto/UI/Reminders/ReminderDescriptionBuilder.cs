using System;

namespace ColinBaker.Pesto.UI.Reminders
{
	class ReminderDescriptionBuilder
	{
		public ReminderDescriptionBuilder(Models.Reminders.Reminder reminder)
		{
			this.Reminder = reminder;
		}

		public override string ToString()
		{
			string description = string.Empty;

			if (this.Reminder is Models.Reminders.TaskResultsReminder)
			{
                Models.Reminders.TaskResultsReminder issueResultsReminder = (this.Reminder as Models.Reminders.TaskResultsReminder);

                description = string.Format("Issue {0} results for task {1}, class {2}", GetStatusDescription(issueResultsReminder.Status), issueResultsReminder.TaskNumber, issueResultsReminder.AircraftClassCode);
            }
			else if (this.Reminder is Models.Reminders.CustomReminder)
			{
				description = (this.Reminder as Models.Reminders.CustomReminder).Description;
			}

			return description;
		}

		public Models.Reminders.Reminder Reminder { get; private set; }

		private static string GetStatusDescription(Models.Results.TaskResults.ResultsStatus status)
		{
			string description = string.Empty;

			switch (status)
			{
				case Models.Results.TaskResults.ResultsStatus.Provisional:
					description = "provisional";
					break;
				case Models.Results.TaskResults.ResultsStatus.Official:
					description = "official";
					break;
				case Models.Results.TaskResults.ResultsStatus.Final:
					description = "final";
					break;
			}

			return description;
		}
	}
}
