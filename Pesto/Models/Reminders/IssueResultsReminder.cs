using System;

namespace ColinBaker.Pesto.Models.Reminders
{
    class TaskResultsReminder : Reminder
    {
        public TaskResultsReminder(DateTime dueUtc, int taskNumber, string aircraftClassCode, Models.Results.TaskResults.ResultsStatus status) : base(dueUtc)
        {
            this.Status = status;
            this.TaskNumber = taskNumber;
            this.AircraftClassCode = aircraftClassCode;
        }

        public int TaskNumber { get; private set; }
        public string AircraftClassCode { get; private set; }
        public Models.Results.TaskResults.ResultsStatus Status { get; private set; }
    }
}
