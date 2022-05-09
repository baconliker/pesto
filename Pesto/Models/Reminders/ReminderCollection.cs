using System;

namespace ColinBaker.Pesto.Models.Reminders
{
    class ReminderCollection : System.Collections.ObjectModel.Collection<Reminder>
    {
        private Competition m_competition;

        public ReminderCollection(Competition competition)
        {
            m_competition = competition;
        }

        public void Load()
        {
            m_competition.Repository.LoadReminders(this);
        }

        public void Save()
        {
            m_competition.Repository.SaveReminders(this);
        }

        public new void Add(Reminder reminder)
        {
            if (reminder is TaskResultsReminder)
            {
                TaskResultsReminder taskResultsReminder = reminder as TaskResultsReminder;

                int i = 0;

                while (i < this.Count)
                {
                    if (this[i] is TaskResultsReminder)
                    {
                        TaskResultsReminder existingTaskResultsReminder = this[i] as TaskResultsReminder;

                        if (taskResultsReminder.TaskNumber == existingTaskResultsReminder.TaskNumber && taskResultsReminder.AircraftClassCode == existingTaskResultsReminder.AircraftClassCode)
                        {
                            this.Remove(existingTaskResultsReminder);
                        }
                        else
                        {
                            i++;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            base.Add(reminder);
        }
    }
}
