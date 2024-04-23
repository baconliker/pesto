using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.Results
{
    partial class TaskResultsForm : Form
    {
        public TaskResultsForm(Models.Results.TaskResults results)
        {
            InitializeComponent();
            
            this.Results = results;

            this.Text += string.Format(" (Task {0}, {1})", this.Results.Task.Number, this.Results.AircraftClass.Code);

            PopulateResultsStatuses();

			foreach (ResultsStatusListItem listItem in statusComboBox.Items)
			{
				if (listItem.Status == this.Results.Status)
				{
					statusComboBox.SelectedItem = listItem;
				}
			}
			publishedDatePicker.Value = results.Published;
			publishedTimePicker.Value = results.Published;
			deadlineDatePicker.Value = results.Deadline;
			deadlineTimePicker.Value = results.Deadline;

            PopulateColumns();
        }

        public Models.Results.TaskResults Results { get; set; }

        private void PopulateResultsStatuses()
        {
			statusComboBox.Items.Add(new ResultsStatusListItem(Models.Results.TaskResults.ResultsStatus.Interim));
			statusComboBox.Items.Add(new ResultsStatusListItem(Models.Results.TaskResults.ResultsStatus.Provisional));
			statusComboBox.Items.Add(new ResultsStatusListItem(Models.Results.TaskResults.ResultsStatus.Official));
			statusComboBox.Items.Add(new ResultsStatusListItem(Models.Results.TaskResults.ResultsStatus.Final));
            statusComboBox.Items.Add(new ResultsStatusListItem(Models.Results.TaskResults.ResultsStatus.Cancelled));
        }

        private void PopulateColumns()
        {
            columnsControl.Populate(this.Results.Data);
        }

        private void UpdateDeadline()
        {
            if (autoCalculateDeadlineCheckBox.Checked)
            {
				DateTime deadline = Models.Results.TaskResults.CalculateComplaintDeadline(this.Results.Task, Utils.BuildDateTime(publishedDatePicker, publishedTimePicker));

                deadlineDatePicker.Value = deadline;
                deadlineTimePicker.Value = deadline;
            }
        }

		private bool ValidateTaskResults()
		{
			DateTime published = Utils.BuildDateTime(publishedDatePicker, publishedTimePicker);

			// Check whether pilots are flying another task on the date these results will be published

			foreach (Models.Task task in this.Results.Task.Competition.Tasks)
			{
				if (task != this.Results.Task && task.LandBySet && published >= task.LaunchOpen && published <= task.LandBy)
				{
					string message = "These task results are due to be published while task " + task.Number.ToString() + " (" + task.Name + ") is in progress.\n\nAre you sure you want to continue?";

					if (MessageBox.Show(message, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
					{
						return false;
					}
				}
			}

			return true;
		}

        private void RefreshControlState()
        {
            ResultsStatusListItem selectedItem = statusComboBox.SelectedItem as ResultsStatusListItem;

			if (selectedItem.Status == Models.Results.TaskResults.ResultsStatus.Provisional || selectedItem.Status == Models.Results.TaskResults.ResultsStatus.Official)
            {
                autoCalculateDeadlineCheckBox.Enabled = true;

                deadlineDatePicker.Enabled = !autoCalculateDeadlineCheckBox.Checked;
                deadlineTimePicker.Enabled = !autoCalculateDeadlineCheckBox.Checked;
            }
            else
            {
                autoCalculateDeadlineCheckBox.Enabled = false;

                deadlineDatePicker.Enabled = false;
                deadlineTimePicker.Enabled = false;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            columnsControl.Extract(this.Results.Data);

            if (ValidateTaskResults())
			{
				this.Cursor = Cursors.WaitCursor;

				try
				{
					Models.ColumnWidthCalculator calculator = new Models.ColumnWidthCalculator();

					bool proceed = true;

                    if (this.Results.Data.Rows.Count > 0)
                    {
                        if (calculator.Calculate(this.Results.Data))
                        {
                            this.Results.FontSize = calculator.FontSizeUsed;
                        }
                        else
                        {
                            MessageBox.Show("Unable to size columns.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            proceed = false;
                        }
                    }

                    if (proceed)
					{
						this.Results.Status = ((ResultsStatusListItem)statusComboBox.SelectedItem).Status;
						this.Results.Published = Utils.BuildDateTime(publishedDatePicker, publishedTimePicker);
						this.Results.Deadline = Utils.BuildDateTime(deadlineDatePicker, deadlineTimePicker);

                        if (this.Results.Status == Models.Results.TaskResults.ResultsStatus.Cancelled)
                        {
                            this.Results.ZeroScores();
                        }

						this.Results.Save();
						this.Results.Publish();

                        switch (this.Results.Status)
                        {
                            case Models.Results.TaskResults.ResultsStatus.Provisional:
                                this.Results.Task.Competition.Reminders.Add(new Models.Reminders.TaskResultsReminder(this.Results.Deadline.ToUniversalTime(), this.Results.Task.Number, this.Results.AircraftClass.Code, Models.Results.TaskResults.ResultsStatus.Official));
                                this.Results.Task.Competition.Reminders.Save();
                                break;
                            case Models.Results.TaskResults.ResultsStatus.Official:
                                this.Results.Task.Competition.Reminders.Add(new Models.Reminders.TaskResultsReminder(this.Results.Deadline.ToUniversalTime(), this.Results.Task.Number, this.Results.AircraftClass.Code, Models.Results.TaskResults.ResultsStatus.Final));
                                this.Results.Task.Competition.Reminders.Save();
                                break;
                        }
					}
					else
					{
						// Prevent dialog from closing
						this.DialogResult = System.Windows.Forms.DialogResult.None;
					}
				}
				finally
				{
					this.Cursor = Cursors.Default;
				}
			}
			else
			{
				// Prevent dialog from closing
				this.DialogResult = System.Windows.Forms.DialogResult.None;
			}
        }

        private void autoCalculateDeadlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDeadline();

            RefreshControlState();
        }

        private void publishedDatePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateDeadline();
        }

        private void publishedTimePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateDeadline();
        }

        private void statusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControlState();
        }
    }
}
