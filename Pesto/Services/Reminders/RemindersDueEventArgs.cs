using System;

namespace ColinBaker.Pesto.Services.Reminders
{
    class RemindersDueEventArgs : EventArgs
    {
        public RemindersDueEventArgs(Models.Reminders.Reminder[] reminders)
        {
            this.Reminders = reminders;
        }

        public Models.Reminders.Reminder[] Reminders { get; private set; }
    }
}
