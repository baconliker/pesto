using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI
{
	partial class TaskForm : Form
	{
		public TaskForm(Models.Competition competition)
		{
			InitializeComponent();

			this.Competition = competition;

			this.Text = "Add Task";

			PopulateTaskTypes();
            PopulateAircraftClasses();
            
            numberTextBox.Text = String.Format("{0}", competition.Tasks.Count + 1);
			launchOpenDatePicker.Value = DateTime.Now;
			launchOpenTimePicker.Value = DateTime.Now;
			launchCloseDatePicker.Value = DateTime.Now;
			launchCloseTimePicker.Value = DateTime.Now;
			landByDatePicker.Value = DateTime.Now;
			landByTimePicker.Value = DateTime.Now;

            this.Height = 520;
        }

		public TaskForm(Models.Task task, Models.Competition competition)
		{
			InitializeComponent();

			this.Task = task;
			this.Competition = competition;

			this.Text = "Edit Task";

			PopulateTaskTypes();
            PopulateAircraftClasses();

            numberTextBox.Text = String.Format("{0}", task.Number);
			numberTextBox.ReadOnly = true;
			nameTextBox.Text = task.Name;
            abbreviatedNameTextBox.Text = task.AbbreviatedName;
			foreach (TaskTypeListItem listItem in typeComboBox.Items)
			{
				if (listItem.Type == task.Type)
				{
					typeComboBox.SelectedItem = listItem;
					break;
				}
			}
			launchOpenDatePicker.Value = task.LaunchOpen;
			launchOpenTimePicker.Value = task.LaunchOpen;
			if (task.LaunchCloseSet)
			{
				launchCloseCheckBox.Checked = true;
				launchCloseDatePicker.Value = task.LaunchClose;
				launchCloseTimePicker.Value = task.LaunchClose;
			}
			else
			{
				launchCloseDatePicker.Value = task.LaunchOpen;
				launchCloseTimePicker.Value = task.LaunchOpen;
			}
			if (task.LandBySet)
			{
				landByCheckBox.Checked = true;
				landByDatePicker.Value = task.LandBy;
				landByTimePicker.Value = task.LandBy;
			}
			else
			{
				if (task.LaunchCloseSet)
				{
					landByDatePicker.Value = task.LaunchClose;
					landByTimePicker.Value = task.LaunchClose;
				}
				else
				{
					landByDatePicker.Value = task.LaunchOpen;
					landByTimePicker.Value = task.LaunchOpen;
				}
			}

            this.Height = 520;
        }

		public Models.Competition Competition { get; set; }
		public Models.Task Task { get; set; }

		private void PopulateTaskTypes()
		{
			typeComboBox.Items.Add(new TaskTypeListItem(Models.Task.TaskType.Economy));
			typeComboBox.Items.Add(new TaskTypeListItem(Models.Task.TaskType.Navigation));
			typeComboBox.Items.Add(new TaskTypeListItem(Models.Task.TaskType.Precision));
		}

        private void PopulateAircraftClasses()
        {
            foreach (Models.AircraftClass competitionAircraftClass in this.Competition.AircraftClasses)
            {
                object[] row = new object[3];
                bool selected = false;

                if (this.Task != null)
                {
                    foreach (Models.AircraftClass taskAircraftClass in this.Task.AircraftClasses)
                    {
                        if (String.Compare(taskAircraftClass.Code, competitionAircraftClass.Code, true) == 0)
                        {
                            selected = true;
                            break;
                        }
                    }
                }
                else
                {
                    selected = true;
                }

                row[0] = selected;
                row[1] = competitionAircraftClass.Code;
                row[2] = competitionAircraftClass.Description;

                int rowIndex = aircraftClassesDataGridView.Rows.Add(row);

                aircraftClassesDataGridView.Rows[rowIndex].Tag = competitionAircraftClass;
            }
        }

		private bool ValidateTask()
		{
			int number;

			if (numberTextBox.Text.Trim().Length == 0 || !int.TryParse(numberTextBox.Text, out number))
			{
				MessageBox.Show("Please enter a number.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			else
			{
				// Check that a task with this number does not already exist
				foreach (Models.Task task in this.Competition.Tasks)
				{
					if (this.Task == null || task != this.Task)
					{
						if (task.Number == number)
						{
							MessageBox.Show("A task with this number already exists.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return false;
						}
					}
				}
			}

			if (nameTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("Please enter a name.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			if (typeComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select a type.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

            int selectedAircraftClassCount = 0;

            foreach (DataGridViewRow row in aircraftClassesDataGridView.Rows)
            {
                if ((bool)row.Cells["SelectedColumn"].Value)
                {
                    selectedAircraftClassCount++;
                }
                else if (this.Task != null)
                {
                    Models.AircraftClass taskAircraftClass = row.Tag as Models.AircraftClass;

                    foreach (Models.Results.TaskResults results in this.Task.Results)
                    {
                        if (results.AircraftClass.Code == taskAircraftClass.Code && results.Exists())
                        {
                            if (MessageBox.Show(string.Format("Results exist for class {0}.  Are you sure you want to continue?", results.AircraftClass.Code), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            if (selectedAircraftClassCount == 0)
            {
                MessageBox.Show("Please select at least one aircraft class.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DateTime launchOpen = Utils.BuildDateTime(launchOpenDatePicker, launchOpenTimePicker);

			if (launchOpen < this.Competition.Start || launchOpen > this.Competition.Finish)
			{
				MessageBox.Show("Launch open falls outside the competition dates.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			if (launchCloseCheckBox.Checked)
			{
				DateTime launchClose = Utils.BuildDateTime(launchCloseDatePicker, launchCloseTimePicker);

				if (launchClose <= launchOpen)
				{
					MessageBox.Show("Launch close must be after launch open.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}

			if (landByCheckBox.Checked)
			{
				DateTime landBy = Utils.BuildDateTime(landByDatePicker, landByTimePicker);

				if (launchCloseCheckBox.Checked)
				{
					DateTime launchClose = Utils.BuildDateTime(launchCloseDatePicker, launchCloseTimePicker);

					if (landBy <= launchClose)
					{
						MessageBox.Show("Land by must be after launch close.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}
				else
				{
					if (landBy <= launchOpen)
					{
						MessageBox.Show("Land by must be after launch open.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}
			}

			return true;
		}

        private Models.AircraftClass[] ExtractSelectedAircraftClasses()
        {
            List<Models.AircraftClass> selectedAircraftClasses = new List<Models.AircraftClass>();

            foreach (DataGridViewRow row in aircraftClassesDataGridView.Rows)
            {
                if ((bool)row.Cells["SelectedColumn"].Value)
                {
                    selectedAircraftClasses.Add(row.Tag as Models.AircraftClass);
                }
            }

            return selectedAircraftClasses.ToArray();
        }

        private void RefreshControlState()
		{
			launchCloseDatePicker.Enabled = launchCloseCheckBox.Checked;
			launchCloseTimePicker.Enabled = launchCloseCheckBox.Checked;

			landByDatePicker.Enabled = landByCheckBox.Checked;
			landByTimePicker.Enabled = landByCheckBox.Checked;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (ValidateTask())
			{
				if (this.Task == null)
				{
					this.Task = new Models.Task(this.Competition);
					this.Competition.Tasks.Add(this.Task);
				}

				this.Task.Number = int.Parse(numberTextBox.Text);
				this.Task.Name = nameTextBox.Text;
                this.Task.AbbreviatedName = abbreviatedNameTextBox.Text;
				this.Task.Type = ((TaskTypeListItem)typeComboBox.SelectedItem).Type;
                this.Task.AircraftClasses = new List<Models.AircraftClass>(ExtractSelectedAircraftClasses());
                this.Task.SyncTaskResultsWithAircraftClasses();
                this.Task.LaunchOpen = Utils.BuildDateTime(launchOpenDatePicker, launchOpenTimePicker);
				if (launchCloseCheckBox.Checked)
				{
					this.Task.LaunchClose = Utils.BuildDateTime(launchCloseDatePicker, launchCloseTimePicker);
				}
				else
				{
					this.Task.LaunchClose = DateTime.MinValue;
				}
				if (landByCheckBox.Checked)
				{
					this.Task.LandBy = Utils.BuildDateTime(landByDatePicker, landByTimePicker);
				}
				else
				{
					this.Task.LandBy = DateTime.MinValue;
				}

                // Copy no fly zones from competition to task
                foreach (Models.Features.Feature feature in this.Competition.Features)
                {
                    if (feature.Type == Models.Features.Feature.FeatureType.NoFlyZone)
                    {
                        this.Task.NoFlyZones.Add((feature as Models.Features.NoFlyZoneFeature).Clone(feature.Name));
                    }
                }
			}
			else
			{
				// Prevent dialog from closing
				this.DialogResult = System.Windows.Forms.DialogResult.None;
			}
		}

		private void launchCloseCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			RefreshControlState();
		}

		private void landByCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			RefreshControlState();
		}
	}
}
