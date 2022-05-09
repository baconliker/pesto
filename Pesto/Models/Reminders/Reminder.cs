using System;

namespace ColinBaker.Pesto.Models.Reminders
{
    abstract class Reminder
    {
        private DateTime m_dueUtc;

        protected Reminder(DateTime dueUtc)
        {
            this.DueUtc = dueUtc;
        }

        public DateTime DueUtc
        {
            get
            {
                return m_dueUtc;
            }
            set
            {
                m_dueUtc = value;
                this.Notified = false;
            }
        }

        public bool Notified { get; set; }

        public bool Overdue
        {
            get
            {
                return (this.DueUtc <= DateTime.UtcNow);
            }
        }
    }
}
