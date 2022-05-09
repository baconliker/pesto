using System;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.Reminders
{
	partial class CustomReminderForm : Form
	{
		private Models.Competition m_competition;

		public CustomReminderForm(Models.Competition competition)
		{
			InitializeComponent();

			m_competition = competition;

			dueDateTimePickerDate.Value = DateTime.Now;
			dueDateTimePickerTime.Value = DateTime.Now;
		}

		private bool ValidateCustomReminder()
		{
			if (descriptionTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("Please enter a description.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				descriptionTextBox.Focus();
				return false;
			}

			return true;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (ValidateCustomReminder())
			{
				DateTime dueUtc = new DateTime(dueDateTimePickerDate.Value.Year, dueDateTimePickerDate.Value.Month, dueDateTimePickerDate.Value.Day, dueDateTimePickerTime.Value.Hour, dueDateTimePickerTime.Value.Minute, 0, DateTimeKind.Local).ToUniversalTime();

                Models.Reminders.CustomReminder reminder = new Models.Reminders.CustomReminder(dueUtc, descriptionTextBox.Text);
				m_competition.Reminders.Add(reminder);
			}
			else
			{
				// Prevent form from closing
				this.DialogResult = DialogResult.None;
			}
		}
	}
}
