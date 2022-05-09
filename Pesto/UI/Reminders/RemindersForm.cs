using System;
using System.Linq;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.Reminders
{
	partial class RemindersForm : Form
	{
		private Models.Competition m_competition;

		public RemindersForm(Models.Competition competition, bool showOverdue)
		{
			InitializeComponent();

			m_competition = competition;

			PopulateFilter();
			if (showOverdue)
			{
				SelectFilter(RemindersFilterListItem.FilterType.Overdue);
			}
			else
			{
				SelectFilter(RemindersFilterListItem.FilterType.All);
			}

			PopulateSnoozeIntervals();
			
			RefreshControlState();
		}

		public void Reload()
		{
			PopulateReminders();

			RefreshControlState();
		}

		public void ReloadAll()
		{
			SelectFilter(RemindersFilterListItem.FilterType.All);
		}
		
		public void ReloadOverdue()
		{
			SelectFilter(RemindersFilterListItem.FilterType.Overdue);
		}

		private void PopulateFilter()
		{
			filterComboBox.Items.Add(new RemindersFilterListItem(RemindersFilterListItem.FilterType.All));
			filterComboBox.Items.Add(new RemindersFilterListItem(RemindersFilterListItem.FilterType.Overdue));
		}

		private void SelectFilter(RemindersFilterListItem.FilterType type)
		{
			filterComboBox.SelectedIndex = -1;

			foreach (RemindersFilterListItem item in filterComboBox.Items)
			{
				if (item.Type == type)
				{
					filterComboBox.SelectedItem = item;
					break;
				}
			}
		}

		private void PopulateReminders()
		{
			RemindersFilterListItem.FilterType filterType = (filterComboBox.SelectedItem as RemindersFilterListItem).Type;

			remindersListView.BeginUpdate();

			try
			{
				remindersListView.Items.Clear();

				foreach (Models.Reminders.Reminder reminder in m_competition.Reminders)
				{
					bool show = true;

					if (filterType == RemindersFilterListItem.FilterType.Overdue && !reminder.Overdue)
					{
						show = false;
					}

					if (show)
					{
						DateTime dueLocal = reminder.DueUtc.ToLocalTime();

						ReminderDescriptionBuilder descriptionBuilder = new ReminderDescriptionBuilder(reminder);

						ListViewItem item = remindersListView.Items.Add(descriptionBuilder.ToString());
						item.SubItems.Add(string.Format("{0} {1}", dueLocal.ToShortDateString(), dueLocal.ToString("HH:mm")));

						if (reminder.Overdue)
						{
							item.ImageKey = "Bell";
						}

						item.Tag = reminder;
					}
				}

				if (remindersListView.Items.Count > 0)
				{
					remindersListView.Items[0].Selected = true;
				}
			}
			finally
			{
				remindersListView.EndUpdate();
			}
		}

		private void DeleteReminder(bool prompt)
		{
			bool delete = true;

			if (prompt)
			{
				delete = (MessageBox.Show("Are you sure you want to delete this reminder?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
			}

			if (delete)
			{
                Models.Reminders.Reminder reminder = remindersListView.SelectedItems[0].Tag as Models.Reminders.Reminder;

				m_competition.Reminders.Remove(reminder);
                m_competition.Reminders.Save();

                remindersListView.SelectedItems[0].Remove();
			}
		}

		private void PopulateSnoozeIntervals()
		{
			snoozeComboBox.Items.Add(new RemindersSnoozeListItem(new TimeSpan(0, 5, 0)));
			snoozeComboBox.Items.Add(new RemindersSnoozeListItem(new TimeSpan(0, 15, 0)));
			snoozeComboBox.Items.Add(new RemindersSnoozeListItem(new TimeSpan(0, 30, 0)));
			snoozeComboBox.Items.Add(new RemindersSnoozeListItem(new TimeSpan(1, 0, 0)));
			snoozeComboBox.Items.Add(new RemindersSnoozeListItem(new TimeSpan(5, 0, 0)));
		}

		private void RefreshControlState()
		{
			overduePanel.Visible = (remindersListView.SelectedItems.Count > 0 && (remindersListView.SelectedItems[0].Tag as Models.Reminders.Reminder).Overdue);
			notOverduePanel.Visible = !overduePanel.Visible;

			if (overduePanel.Visible)
			{
				snoozeComboBox.SelectedIndex = 0;
			}

			deleteButton.Enabled = (remindersListView.SelectedItems.Count > 0);
		}

		private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (filterComboBox.SelectedIndex == -1) return;

			PopulateReminders();

			RefreshControlState();
		}

		private void remindersListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshControlState();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			using (CustomReminderForm form = new CustomReminderForm(m_competition))
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
                    m_competition.Reminders.Save();

                    PopulateReminders();

					RefreshControlState();
				}
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			DeleteReminder(true);
		}

		private void snoozeButton_Click(object sender, EventArgs e)
		{
            Models.Reminders.Reminder selectedReminder = remindersListView.SelectedItems[0].Tag as Models.Reminders.Reminder;

			selectedReminder.DueUtc = DateTime.UtcNow.Add((snoozeComboBox.SelectedItem as RemindersSnoozeListItem).Interval);

            m_competition.Reminders.Save();

            PopulateReminders();

			RefreshControlState();
		}

		private void dismissButton_Click(object sender, EventArgs e)
		{
			DeleteReminder(false);
		}
	}
}
