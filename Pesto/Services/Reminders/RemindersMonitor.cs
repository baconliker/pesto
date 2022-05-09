using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Services.Reminders
{
    class RemindersMonitor
    {
        public event EventHandler<RemindersDueEventArgs> NewRemindersDue;
        public event EventHandler<EventArgs> RemindersNoLongerDue;

        private const int m_timerInterval = 10000;

        private Models.Competition m_competition;

        private System.Timers.Timer m_timer;

        private bool m_remindersDue = false;

        public RemindersMonitor(Models.Competition competition, System.ComponentModel.ISynchronizeInvoke synchronizingObject)
        {
            m_competition = competition;

            m_timer = new System.Timers.Timer(m_timerInterval);
            m_timer.SynchronizingObject = synchronizingObject;
            m_timer.Elapsed += m_timer_Elapsed;
        }

        public void Start()
        {
            m_timer.Start();
        }

        public void Stop()
        {
            m_timer.Stop();
        }

        protected void OnNewRemindersDue(RemindersDueEventArgs e)
        {
            if (this.NewRemindersDue != null)
            {
                this.NewRemindersDue(this, e);
            }
        }

        protected void OnRemindersNoLongerDue(EventArgs e)
        {
            if (this.RemindersNoLongerDue != null)
            {
                this.RemindersNoLongerDue(this, e);
            }
        }

        private void m_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

            int remindersDueCount = 0;
            List<Models.Reminders.Reminder> newRemindersDue = new List<Models.Reminders.Reminder>();

            foreach (Models.Reminders.Reminder reminder in m_competition.Reminders)
            {
                if (reminder.Overdue)
                {
                    remindersDueCount++;

                    if (!reminder.Notified)
                    {
                        newRemindersDue.Add(reminder);
                        reminder.Notified = true;
                    }
                }
            }

            if (newRemindersDue.Count > 0)
            {
                OnNewRemindersDue(new RemindersDueEventArgs(newRemindersDue.ToArray()));

                m_remindersDue = true;
            }
            else if (remindersDueCount == 0 && m_remindersDue)
            {
                m_remindersDue = false;

                OnRemindersNoLongerDue(new EventArgs());
            }
        }
    }
}
