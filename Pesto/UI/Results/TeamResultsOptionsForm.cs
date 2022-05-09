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
	partial class TeamResultsOptionsForm : Form
	{
		public TeamResultsOptionsForm(Models.Competition competition, Models.AircraftClass aircraftClass)
		{
			InitializeComponent();

            this.Text += string.Format(" ({0})", aircraftClass.Code);

            PopulateTasks(competition, aircraftClass);
		}

		public int[] SelectedTaskNumbers { get; private set; }

		private void PopulateTasks(Models.Competition competition, Models.AircraftClass aircraftClass)
		{
			foreach (Models.Task task in competition.Tasks)
			{
                foreach (Models.Results.TaskResults taskResults in task.Results)
                {
                    if (taskResults.AircraftClass.Code == aircraftClass.Code)
                    {
                        if (taskResults.Exists())
                        {
                            object[] row = new object[3];

                            row[0] = true;
                            row[1] = task.Number;
                            row[2] = task.Name;

                            int rowIndex = tasksDataGridView.Rows.Add(row);
                        }
                    }
                }
			}
		}

		private bool ValidateOptions()
		{
			int selectedTaskCount = 0;

			foreach (DataGridViewRow row in tasksDataGridView.Rows)
			{
				if ((bool)row.Cells["SelectedColumn"].Value)
				{
					selectedTaskCount++;
				}
			}

			if (selectedTaskCount == 0)
			{
				MessageBox.Show("Please select at least one task.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			return true;
		}

		private void ExtractSelectedTasks()
		{
			List<int> selectedTaskNumbers = new List<int>();

			foreach (DataGridViewRow row in tasksDataGridView.Rows)
			{
				if ((bool)row.Cells["SelectedColumn"].Value)
				{
					selectedTaskNumbers.Add((int)row.Cells["NumberColumn"].Value);
				}
			}

			this.SelectedTaskNumbers = selectedTaskNumbers.ToArray();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (ValidateOptions())
			{
				ExtractSelectedTasks();
			}
			else
			{
				// Prevent dialog from closing
				this.DialogResult = System.Windows.Forms.DialogResult.None;
			}
		}
	}
}
