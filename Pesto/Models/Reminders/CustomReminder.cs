using System;

namespace ColinBaker.Pesto.Models.Reminders
{
    class CustomReminder : Reminder
    {
        public CustomReminder(DateTime dueUtc, string description) : base(dueUtc)
        {
            this.Description = description;
        }

        public string Description { get; private set; }
    }
}
