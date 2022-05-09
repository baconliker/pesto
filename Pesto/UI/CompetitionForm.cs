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
	partial class CompetitionForm : Form
	{
        private bool m_populatingAircraftClassses = false;

		public CompetitionForm()
		{
			InitializeComponent();

			this.Text = "New Competition";

            startDatePicker.Value = DateTime.Today;
            finishDatePicker.Value = DateTime.Today;

            PopulateTimeZones(TimeZoneInfo.Local);
            PopulateAircraftClasses();
            PopulateNationDefinitions();

            nationDefinitionsDataGridView.Columns["nationNumberWhoScoreColumn"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight;

            this.Height = 595;
        }

		public CompetitionForm(Models.Competition competition)
		{
			InitializeComponent();

			this.Competition = competition;

			this.Text = "Competition Properties";

			nameTextBox.Text = competition.Name;
			startDatePicker.Value = competition.Start;
			finishDatePicker.Value = competition.Finish;

            PopulateTimeZones(this.Competition.TimeZone);
            PopulateAircraftClasses();
            PopulateNationDefinitions();

            nationDefinitionsDataGridView.Columns["nationNumberWhoScoreColumn"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopRight;

            locationTextBox.Text = competition.GetFolderPath();
			locationTextBox.ReadOnly = true;
			chooseLocationButton.Enabled = false;
            backupLocationTextBox.Text = competition.BackupPath;

            if (!string.IsNullOrEmpty(competition.FrdlIgcPath))
            {
                frdlIgcLocationTextBox.Text = competition.FrdlIgcPath;
                amodRadioButton.Checked = true;
            }
            else if (!string.IsNullOrEmpty(competition.FlymasterIgcPath))
            {
                flymasterIgcLocationTextBox.Text = competition.FlymasterIgcPath;
                flymasterRadioButton.Checked = true;
            }

            this.Height = 595;
        }

		public Models.Competition Competition { get; private set; }

        private void PopulateTimeZones(TimeZoneInfo selectedTimeZone)
        {
            timeZoneComboBox.Items.Clear();

            int selectedIndex = -1;

            foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                int index = timeZoneComboBox.Items.Add(new TimeZoneListItem(timeZone));

                if (string.Compare(selectedTimeZone.Id, timeZone.Id, true) == 0)
                {
                    selectedIndex = index;
                }
            }

            if (selectedIndex != -1)
            {
                timeZoneComboBox.SelectedIndex = selectedIndex;
            }
        }

		private void PopulateAircraftClasses()
		{
            m_populatingAircraftClassses = true;

            try
            {
                foreach (Models.AircraftClass aircraftClass in Models.AircraftClass.GetAllClasses())
                {
                    object[] row = new object[3];
                    bool selected = false;

                    if (this.Competition != null)
                    {
                        foreach (Models.AircraftClass competitionAircraftClass in this.Competition.AircraftClasses)
                        {
                            if (String.Compare(competitionAircraftClass.Code, aircraftClass.Code, true) == 0)
                            {
                                selected = true;
                                break;
                            }
                        }
                    }

                    row[0] = selected;
                    row[1] = aircraftClass.Code;
                    row[2] = aircraftClass.Description;

                    int rowIndex = aircraftClassesDataGridView.Rows.Add(row);

                    aircraftClassesDataGridView.Rows[rowIndex].Tag = aircraftClass;
                }
            }
            finally
            {
                m_populatingAircraftClassses = false;
            }
		}

        private void PopulateNationDefinitions()
        {
            Models.AircraftClass[] competitionAircraftClasses = ExtractSelectedAircraftClasses();

            foreach (Models.AircraftClass competitionAircraftClass in competitionAircraftClasses)
            {
                bool found = false;

                foreach (DataGridViewRow row in nationDefinitionsDataGridView.Rows)
                {
                    if ((row.Tag as Models.AircraftClass).Code == competitionAircraftClass.Code)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    object[] row = new object[2];
                    int numberWhoScore = 0;

                    if (this.Competition != null)
                    {
                        foreach (Models.NationDefinition nationDefinition in this.Competition.NationDefinitions)
                        {
                            if (String.Compare(nationDefinition.AircraftClass.Code, competitionAircraftClass.Code, true) == 0)
                            {
                                numberWhoScore = nationDefinition.NumberWhoScore;
                                break;
                            }
                        }
                    }

                    row[0] = competitionAircraftClass.Code;
                    row[1] = numberWhoScore;

                    int rowIndex = nationDefinitionsDataGridView.Rows.Add(row);

                    nationDefinitionsDataGridView.Rows[rowIndex].Tag = competitionAircraftClass;
                }
            }

            int i = 0;

            while (i < nationDefinitionsDataGridView.Rows.Count)
            {
                DataGridViewRow row = nationDefinitionsDataGridView.Rows[i];
                bool found = false;

                foreach (Models.AircraftClass competitionAircraftClass in competitionAircraftClasses)
                {
                    if (competitionAircraftClass.Code == (row.Tag as Models.AircraftClass).Code)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    nationDefinitionsDataGridView.Rows.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

		private bool ValidateCompetition()
		{
			if (nameTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("Please enter a name.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                competitionTabControl.SelectedTab = generalTabPage;
				return false;
			}

            if (timeZoneComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a time zone.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                competitionTabControl.SelectedTab = generalTabPage;
                return false;
            }

			int selectedAircraftClassCount = 0;

			foreach (DataGridViewRow row in aircraftClassesDataGridView.Rows)
			{
				if ((bool)row.Cells["SelectedColumn"].Value)
				{
					selectedAircraftClassCount++;
				}
                else if (this.Competition != null)
                {
                    Models.AircraftClass competitionAircraftClass = row.Tag as Models.AircraftClass;

                    // Check that this class isn't being used by a task
                    foreach (Models.Task task in this.Competition.Tasks)
                    {
                        foreach (Models.AircraftClass taskAircraftClass in task.AircraftClasses)
                        {
                            if (taskAircraftClass.Code == competitionAircraftClass.Code)
                            {
                                MessageBox.Show(string.Format("This class cannot be removed from the competition because it's being used by task {0}.", task.Number), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                competitionTabControl.SelectedTab = generalTabPage;
                                return false;
                            }
                        }
                    }
                }
			}

			if (selectedAircraftClassCount == 0)
			{
				MessageBox.Show("Please select at least one aircraft class.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                competitionTabControl.SelectedTab = generalTabPage;
                return false;
			}

			if (locationTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("Please choose a location.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                competitionTabControl.SelectedTab = generalTabPage;
                return false;
			}
			else
			{
				if (!System.IO.Directory.Exists(locationTextBox.Text))
				{
					MessageBox.Show("Please enter a valid location.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    competitionTabControl.SelectedTab = generalTabPage;
                    return false;
				}
			}

            if (backupLocationTextBox.Text.Trim().Length > 0)
            {
                if (!System.IO.Directory.Exists(backupLocationTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid backup location.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    competitionTabControl.SelectedTab = generalTabPage;
                    return false;
                }
            }

            if (amodRadioButton.Checked)
            {
                if (!System.IO.Directory.Exists(frdlIgcLocationTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid FRDL IGC location.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    competitionTabControl.SelectedTab = loggersTabPage;
                    return false;
                }
            }
            else if (flymasterRadioButton.Checked)
            {
                if (!System.IO.Directory.Exists(flymasterIgcLocationTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid Flymaster IGC location.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    competitionTabControl.SelectedTab = loggersTabPage;
                    return false;
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

        private Models.NationDefinition[] ExtractNationDefinitions()
        {
            List<Models.NationDefinition> nationDefinitions = new List<Models.NationDefinition>();

            foreach (DataGridViewRow row in nationDefinitionsDataGridView.Rows)
            {
                int numberWhoScore = int.Parse(row.Cells["nationNumberWhoScoreColumn"].Value.ToString());

                if (numberWhoScore > 0)
                {
                    nationDefinitions.Add(new Models.NationDefinition((row.Tag as Models.AircraftClass), numberWhoScore));
                }
            }

            return nationDefinitions.ToArray();
        }

        private string BuildFilePath()
		{
			return locationTextBox.Text + @"\" + nameTextBox.Text + Models.Competition.FileExtension;
		}

        private void aircraftClassesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == SelectedColumn.Index && e.RowIndex > -1 && !m_populatingAircraftClassses)
            {
                PopulateNationDefinitions();
            }
        }

        private void aircraftClassesDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == SelectedColumn.Index && e.RowIndex > -1)
            {
                aircraftClassesDataGridView.EndEdit();
            }
        }

        private void nationDefinitionsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == nationNumberWhoScoreColumn.Index)
            {
                int numberWhoScore;

                if (!int.TryParse(e.FormattedValue.ToString(), out numberWhoScore))
                {
                    MessageBox.Show("Please enter a number.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }

        private void chooseLocationButton_Click(object sender, EventArgs e)
		{
			if (competitionFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				locationTextBox.Text = competitionFolderDialog.SelectedPath;
			}
		}

        private void chooseBackupLocationButton_Click(object sender, EventArgs e)
        {
            if (backupFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                backupLocationTextBox.Text = backupFolderDialog.SelectedPath;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
		{
			if (ValidateCompetition())
			{
				if (this.Competition == null)
				{
                    Services.CompetitionRepository repository = new Services.CompetitionRepository(BuildFilePath());
                    this.Competition = new Models.Competition(repository);
				}

				this.Competition.Name = nameTextBox.Text;
				this.Competition.Start = startDatePicker.Value;
				this.Competition.Finish = finishDatePicker.Value;
                this.Competition.TimeZone = (timeZoneComboBox.SelectedItem as TimeZoneListItem).TimeZone;
				this.Competition.AircraftClasses = new List<Models.AircraftClass>(ExtractSelectedAircraftClasses());
                this.Competition.SyncOverallResultsWithAircraftClasses();
                this.Competition.SyncTeamResultsWithAircraftClasses();
                this.Competition.NationDefinitions = new List<Models.NationDefinition>(ExtractNationDefinitions());
                this.Competition.FrdlIgcPath = amodRadioButton.Checked ? frdlIgcLocationTextBox.Text : "";
                this.Competition.FlymasterIgcPath = flymasterRadioButton.Checked ? flymasterIgcLocationTextBox.Text : "";
                this.Competition.BackupPath = backupLocationTextBox.Text;
			}
			else
			{
				// Prevent dialog from closing
				this.DialogResult = System.Windows.Forms.DialogResult.None;
			}
		}

        private void noLoggersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            frdlIgcLocationTextBox.Enabled = false;
            chooseFrdlIgcLocationButton.Enabled = false;

            flymasterIgcLocationTextBox.Enabled = false;
            chooseFlymasterIgcLocationButton.Enabled = false;
        }

        private void amodRadioButton_CheckedChanged(object sender, EventArgs e)
		{
            frdlIgcLocationTextBox.Enabled = true;
            chooseFrdlIgcLocationButton.Enabled = true;

            flymasterIgcLocationTextBox.Enabled = false;
            chooseFlymasterIgcLocationButton.Enabled = false;
        }

		private void flymasterRadioButton_CheckedChanged(object sender, EventArgs e)
		{
            frdlIgcLocationTextBox.Enabled = false;
            chooseFrdlIgcLocationButton.Enabled = false;

            flymasterIgcLocationTextBox.Enabled = true;
            chooseFlymasterIgcLocationButton.Enabled = true;
        }

        private void chooseFrdlIgcLocationButton_Click(object sender, EventArgs e)
        {
            if (tracksFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frdlIgcLocationTextBox.Text = tracksFolderDialog.SelectedPath;
            }
        }

		private void chooseFlymasterIgcLocationButton_Click(object sender, EventArgs e)
		{
            if (tracksFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                flymasterIgcLocationTextBox.Text = tracksFolderDialog.SelectedPath;
            }
        }
	}
}
