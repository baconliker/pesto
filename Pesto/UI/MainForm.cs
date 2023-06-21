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
	public partial class MainForm : Form
	{
        private const string m_reminderNotificationTitle = "Pesto Reminder";
        private const int m_reminderNotificationTimeout = 15000;

        private Models.Competition m_competition;

        private Reminders.RemindersForm m_remindersForm = null;
        private Services.Reminders.RemindersMonitor m_remindersMonitor;

        private bool m_populatingTasks = false;
        private bool m_selectingAircraftClass = false;

		public MainForm()
		{
			InitializeComponent();
        }

		private void SetFormTitle()
		{
			if (m_competition == null)
			{
				this.Text = Application.ProductName;
			}
			else
			{
				this.Text = Application.ProductName + " - " + m_competition.Name;
			}
		}

		private void PopulateRecentCompetitions()
		{
			openCompetitionRibbonButton.DropDownItems.Clear();

			int count = 0;

			foreach (string filePath in Services.CompetitionRepository.GetRecentCompetitions())
			{
				count++;

				RibbonButton button = new RibbonButton(string.Format("{0}. {1} ", count, filePath));
				button.Tag = filePath;

				openCompetitionRibbonButton.DropDownItems.Add(button);
			}
		}

		private void CloseCompetition()
		{
            if (m_remindersMonitor != null)
            {
                m_remindersMonitor.Stop();
                m_remindersMonitor.NewRemindersDue -= m_remindersMonitor_NewRemindersDue;
                m_remindersMonitor.RemindersNoLongerDue -= m_remindersMonitor_RemindersNoLongerDue;
                m_remindersMonitor = null;
            }

            m_competition = null;

			SetFormTitle();

			tasksTaskListBox.Items.Clear();
			ClearAllResults();

			RefreshControlState();
		}

		private void OpenCompetition(string filePath)
		{
			CloseCompetition();

			Services.CompetitionRepository repository = new Services.CompetitionRepository(filePath);

            try
            {
                m_competition = repository.LoadCompetition();

                repository.UpdateRecentCompetitions();

                m_competition.Reminders.Load();

                m_remindersMonitor = new Services.Reminders.RemindersMonitor(m_competition, this);
                m_remindersMonitor.NewRemindersDue += m_remindersMonitor_NewRemindersDue;
                m_remindersMonitor.RemindersNoLongerDue += m_remindersMonitor_RemindersNoLongerDue;
                m_remindersMonitor.Start();

                SetFormTitle();

                PopulateRecentCompetitions();
                PopulateTasks();

                RefreshControlState();

                Application.DoEvents();

                if (tasksTaskListBox.SelectedItems.Count > 0)
                {
                    TaskOrCompetitionSelected();
                }

                tasksTaskListBox.Focus();
            }
            catch (Services.NewerCompetitionFileException)
            {
                MessageBox.Show("The competition file you are trying to open was created with a newer version of Pesto. Please update Pesto to the latest version and try again.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                throw;
            }
		}

		private void PopulateTasks()
		{
            m_populatingTasks = true;

            tasksTaskListBox.Items.Clear();

            tasksTaskListBox.Items.Add(new TaskListItem(m_competition));

            if (m_competition.Tasks.Count > 0)
			{
				foreach (Models.Task task in m_competition.Tasks)
				{
					tasksTaskListBox.Items.Add(new TaskListItem(task));
				}
			}

            SelectCompetition();

            mainSplitContainer.SplitterDistance = tasksTaskListBox.GetRecommendedWidth();

            m_populatingTasks = false;
        }

        private void SelectCompetition()
        {
            tasksTaskListBox.SelectedIndex = 0;
        }

		private void TaskOrCompetitionSelected()
		{
			if (!m_populatingTasks)
			{
                PopulateAircraftClasses();
			}
		}

        private void PopulateAircraftClasses()
        {
            TaskListItem taskItem = tasksTaskListBox.SelectedItem as TaskListItem;

            aircraftClassesListBox.Items.Clear();

            if (taskItem.Task == null)
            {
                aircraftClassesListBox.Items.Add(new AircraftClassListItem());

                foreach (Models.AircraftClass aircraftClass in m_competition.AircraftClasses)
                {
                    aircraftClassesListBox.Items.Add(new AircraftClassListItem(aircraftClass));
                }
            }
            else
            {
                foreach (Models.AircraftClass aircraftClass in taskItem.Task.AircraftClasses)
                {
                    aircraftClassesListBox.Items.Add(new AircraftClassListItem(aircraftClass));
                }
            }

            aircraftClassesListBox.SelectedIndex = 0;
        }

        private void SelectAircraftClass(Models.AircraftClass aircraftClass)
        {
            m_selectingAircraftClass = true;

            try
            {
                foreach (AircraftClassListItem item in aircraftClassesListBox.Items)
                {
                    if (aircraftClass == null)
                    {
                        if (item.AircraftClass == null)
                        {
                            aircraftClassesListBox.SelectedItem = item;

                            break;
                        }
                    }
                    else
                    {
                        if (item.AircraftClass != null && item.AircraftClass.Code == aircraftClass.Code)
                        {
                            aircraftClassesListBox.SelectedItem = item;

                            break;
                        }
                    }
                }
            }
            finally
            {
                m_selectingAircraftClass = false;
            }

            RefreshControlState();
        }

		private bool CheckIfPdfWriterIsConfigured()
		{
			if (Services.Pdf.PdfWriter.IsConfigured())
			{
				return true;
			}
			else
			{
				MessageBox.Show("PDF Writer not configured, set Apache FOP path in Options.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}

		private bool GenerateResults(Models.Results.Results results, Models.Results.ResultsGenerationOptions options)
		{
			if (CheckIfPdfWriterIsConfigured())
			{
				using (Results.GenerationProgressForm generateForm = new Results.GenerationProgressForm(results, options))
				{
					return (generateForm.ShowDialog() == System.Windows.Forms.DialogResult.OK);
				}
			}
			else
			{
				return false;
			}
		}

		private bool GenerateResults(Models.Results.Results results)
		{
			return GenerateResults(results, null);
		}

		private void ClearAllResults()
		{
            taskResultsPdfViewer.Clear();
            competitionResultsPdfViewer.Clear();
			teamResultsPdfViewer.Clear();
			nationResultsPdfViewer.Clear();
		}

		private void DisplayTaskResults(Models.Task task, Models.AircraftClass aircraftClass)
		{
            foreach (Models.Results.TaskResults taskResults in task.Results)
            {
                if (taskResults.AircraftClass.Code == aircraftClass.Code)
                {
                    DisplayResults(taskResults, taskResultsPdfViewer);
                    break;
                }
            }

            nationResultsPdfViewer.Visible = false;
            resultsTabControl.Visible = false;
            taskResultsPdfViewer.Visible = true;
        }

		private void DisplayOverallResults(Models.AircraftClass aircraftClass)
		{
            foreach (Models.Results.OverallResults overallResults in m_competition.OverallResults)
            {
                if (overallResults.AircraftClass.Code == aircraftClass.Code)
                {
                    DisplayResults(overallResults, competitionResultsPdfViewer);
                    break;
                }
            }

            nationResultsPdfViewer.Visible = false;
            resultsTabControl.Visible = true;
            taskResultsPdfViewer.Visible = false;

            resultsTabControl.SelectedTab = competitionResultsTabPage;
        }

		private void DisplayTeamResults(Models.AircraftClass aircraftClass)
		{
            foreach (Models.Results.TeamResults teamResults in m_competition.TeamResults)
            {
                if (teamResults.AircraftClass.Code == aircraftClass.Code)
                {
                    DisplayResults(teamResults, teamResultsPdfViewer);
                    break;
                }
            }

            nationResultsPdfViewer.Visible = false;
            resultsTabControl.Visible = true;
            taskResultsPdfViewer.Visible = false;

            resultsTabControl.SelectedTab = teamResultsTabPage;
        }

        private void DisplayNationResults()
        {
            DisplayResults(m_competition.NationResults, nationResultsPdfViewer);

            nationResultsPdfViewer.Visible = true;
            resultsTabControl.Visible = false;
            taskResultsPdfViewer.Visible = false;
        }

		private void DisplayResults(Models.Results.Results results, PdfViewer pdfViewer)
		{
			if (results.Exists())
			{
                pdfViewer.LoadPdf(results.GetPublishedFilePath());
            }
			else
			{
				pdfViewer.Clear();
			}
		}

        private void GetSelectedTaskAndAircraftClass(out Models.Task task, out Models.AircraftClass aircraftClass)
        {
            task = null;
            aircraftClass = null;

            if (tasksTaskListBox.SelectedIndex != -1)
            {
                task = (tasksTaskListBox.SelectedItem as TaskListItem).Task;
            }

            if (aircraftClassesListBox.SelectedIndex != -1)
            {
                aircraftClass = (aircraftClassesListBox.SelectedItem as AircraftClassListItem).AircraftClass;
            }
        }

		private void RefreshControlState()
		{
            Models.Task selectedTask;
            Models.AircraftClass selectedAircraftClass;

            GetSelectedTaskAndAircraftClass(out selectedTask, out selectedAircraftClass);

            bool pilotsSpreadsheetExists = (m_competition != null && m_competition.PilotsSpreadsheet.Exists());
			bool taskSpreadsheetExists = (selectedTask != null && selectedTask.ScoringSpreadsheet.Exists());
			
			competitionPropertiesRibbonButton.Enabled = (m_competition != null);
			reloadRibbonButton.Enabled = (m_competition != null);
            backupRibbonButton.Enabled = (m_competition != null && m_competition.BackupPath.Length > 0);
            remindersRibbonButton.Enabled = (m_competition != null);
            defineFeaturesRibbonButton.Enabled = (m_competition != null);
			pilotsRibbonButton.Enabled = (m_competition != null);
			pilotMappingsRibbonButton.Enabled = pilotsSpreadsheetExists;

			addTaskRibbonButton.Enabled = (m_competition != null);
			editTaskRibbonButton.Enabled = (m_competition != null && selectedTask != null);
            copyTaskRibbonButton.Enabled = (m_competition != null && selectedTask != null);
            scoresRibbonButton.Enabled = (m_competition != null && selectedTask != null);
			taskMappingsRibbonButton.Enabled = taskSpreadsheetExists;
			selectTaskFeaturesRibbonButton.Enabled = (m_competition != null && selectedTask != null);
			trackAnalysisRibbonButton.Enabled = (pilotsSpreadsheetExists && m_competition.PilotsSpreadsheet.MappingsComplete() && selectedTask != null);
            liveScoresRibbonButton.Enabled = (pilotsSpreadsheetExists && m_competition.PilotsSpreadsheet.MappingsComplete() && selectedTask != null && selectedTask.Type == Models.Task.TaskType.Navigation);

            generateTaskRibbonButton.Enabled = (pilotsSpreadsheetExists && taskSpreadsheetExists);
			generateOverallRibbonButton.Enabled = pilotsSpreadsheetExists && m_competition.Tasks.Count > 0 && selectedAircraftClass != null;
			generateTeamRibbonButton.Enabled = pilotsSpreadsheetExists && m_competition.Tasks.Count > 0 && selectedAircraftClass != null;
            generateNationRibbonButton.Enabled = pilotsSpreadsheetExists && m_competition.Tasks.Count > 0 && m_competition.NationDefinitions.Count > 0;

            printRibbonButton.Enabled = false;
            if (m_competition != null)
			{
                if (selectedTask == null)
                {
                    if (selectedAircraftClass == null)
                    {
                        printRibbonButton.Enabled = m_competition.NationResults.Exists();
                    }
                    else
                    {
                        if (resultsTabControl.SelectedTab == competitionResultsTabPage)
                        {
                            foreach (Models.Results.OverallResults competitionResults in m_competition.OverallResults)
                            {
                                if (competitionResults.AircraftClass.Code == selectedAircraftClass.Code)
                                {
                                    printRibbonButton.Enabled = competitionResults.Exists();

                                    break;
                                }
                            }
                        }
                        else if (resultsTabControl.SelectedTab == teamResultsTabPage)
                        {
                            foreach (Models.Results.TeamResults teamResults in m_competition.TeamResults)
                            {
                                if (teamResults.AircraftClass.Code == selectedAircraftClass.Code)
                                {
                                    printRibbonButton.Enabled = teamResults.Exists();

                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Models.Results.TaskResults taskResults in selectedTask.Results)
                    {
                        if (taskResults.AircraftClass.Code == selectedAircraftClass.Code)
                        {
                            printRibbonButton.Enabled = taskResults.Exists();

                            break;
                        }
                    }
                }
			}

			uploadRibbonButton.Enabled = false;

			pnlStartup.Visible = (m_competition == null);
		}

		#region Complaint Deadline Calculation Testing

		// TODO: Remove when we're absolutely sure the the new complaint deadline calculation code is correct!
		private void TestComplaintDeadlineCalculation()
		{
			// Competition dates should be: 24/04/2013 - 26/04/2013

			DateTime published;
			DateTime expected;
			DateTime actual;

			// Middle of comp, middle of day
			published = new DateTime(2013, 4, 24, 12, 0, 0);
			expected = new DateTime(2013, 4, 24, 16, 0, 0);
			actual = Models.Results.TaskResults.CalculateComplaintDeadline(m_competition.Tasks[0], published);
			if (!CompareDates(actual, expected))
			{
				ShowTestFailedMessage(published, expected, actual);
			}

			// Middle of comp, before window open
			published = new DateTime(2013, 4, 24, 6, 0, 0);
			expected = new DateTime(2013, 4, 24, 11, 0, 0);
			actual = Models.Results.TaskResults.CalculateComplaintDeadline(m_competition.Tasks[0], published);
			if (!CompareDates(actual, expected))
			{
				ShowTestFailedMessage(published, expected, actual);
			}

			// Middle of comp, just before window close
			published = new DateTime(2013, 4, 24, 21, 36, 0);
			expected = new DateTime(2013, 4, 25, 10, 36, 0);
			actual = Models.Results.TaskResults.CalculateComplaintDeadline(m_competition.Tasks[0], published);
			if (!CompareDates(actual, expected))
			{
				ShowTestFailedMessage(published, expected, actual);
			}

			// Middle of comp, after window close
			published = new DateTime(2013, 4, 24, 23, 0, 0);
			expected = new DateTime(2013, 4, 25, 11, 0, 0);
			actual = Models.Results.TaskResults.CalculateComplaintDeadline(m_competition.Tasks[0], published);
			if (!CompareDates(actual, expected))
			{
				ShowTestFailedMessage(published, expected, actual);
			}

			// Last day of comp, middle of day
			published = new DateTime(2013, 4, 26, 12, 0, 0);
			expected = new DateTime(2013, 4, 26, 13, 0, 0);
			actual = Models.Results.TaskResults.CalculateComplaintDeadline(m_competition.Tasks[0], published);
			if (!CompareDates(actual, expected))
			{
				ShowTestFailedMessage(published, expected, actual);
			}

			// Last day of comp, before window open
			published = new DateTime(2013, 4, 26, 5, 0, 0);
			expected = new DateTime(2013, 4, 26, 8, 0, 0);
			actual = Models.Results.TaskResults.CalculateComplaintDeadline(m_competition.Tasks[0], published);
			if (!CompareDates(actual, expected))
			{
				ShowTestFailedMessage(published, expected, actual);
			}

			// Penultimate day of comp, just before window close
			published = new DateTime(2013, 4, 25, 18, 17, 0);
			expected = new DateTime(2013, 4, 26, 07, 17, 0);
			actual = Models.Results.TaskResults.CalculateComplaintDeadline(m_competition.Tasks[0], published);
			if (!CompareDates(actual, expected))
			{
				ShowTestFailedMessage(published, expected, actual);
			}

			// Penultimate day of comp, just before window close
			published = new DateTime(2013, 4, 25, 21, 29, 0);
			expected = new DateTime(2013, 4, 26, 08, 00, 0);
			actual = Models.Results.TaskResults.CalculateComplaintDeadline(m_competition.Tasks[0], published);
			if (!CompareDates(actual, expected))
			{
				ShowTestFailedMessage(published, expected, actual);
			}

			// Penultimate day of comp, after window close
			published = new DateTime(2013, 4, 25, 23, 0, 0);
			expected = new DateTime(2013, 4, 26, 8, 0, 0);
			actual = Models.Results.TaskResults.CalculateComplaintDeadline(m_competition.Tasks[0], published);
			if (!CompareDates(actual, expected))
			{
				ShowTestFailedMessage(published, expected, actual);
			}

			MessageBox.Show("Tests complete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static bool CompareDates(DateTime date1, DateTime date2)
		{
			if (date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day && date1.Hour == date2.Hour && date1.Minute == date2.Minute)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void ShowTestFailedMessage(DateTime published, DateTime expected, DateTime actual)
		{
			string message = "Test failed.\n\n";

			message += string.Format("Published: {0:dd MMM yyyy HH:mm}\n", published);
			message += string.Format("Expected: {0:dd MMM yyyy HH:mm}\n", expected);
			message += string.Format("Actual: {0:dd MMM yyyy HH:mm}", actual);

			MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		#endregion

		private void MainForm_Load(object sender, EventArgs e)
		{
			SetFormTitle();

			PopulateRecentCompetitions();

			RefreshControlState();
		}

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_remindersForm != null)
            {
                m_remindersForm.Close();
            }
        }

        private void m_remindersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_remindersForm.FormClosed -= m_remindersForm_FormClosed;

            m_remindersForm.Dispose();
            m_remindersForm = null;
        }

        private void m_remindersMonitor_NewRemindersDue(object sender, Services.Reminders.RemindersDueEventArgs e)
        {
            string notificationText = string.Empty;

            if (e.Reminders.Length == 1)
            {
                Reminders.ReminderDescriptionBuilder descriptionBuilder = new Reminders.ReminderDescriptionBuilder(e.Reminders[0]);

                notificationText = descriptionBuilder.ToString();
            }
            else
            {
                notificationText = string.Format("{0} reminders are due.", e.Reminders.Length);
            }

            reminderNotifyIcon.Visible = true;
            reminderNotifyIcon.ShowBalloonTip(m_reminderNotificationTimeout, m_reminderNotificationTitle, notificationText, ToolTipIcon.Info);

            if (m_remindersForm != null)
            {
                m_remindersForm.Reload();
            }

            remindersRibbonButton.FlashEnabled = true;
        }

        private void m_remindersMonitor_RemindersNoLongerDue(object sender, EventArgs e)
        {
            remindersRibbonButton.FlashEnabled = false;
        }

        private void newCompetitionRibbonButton_Click(object sender, EventArgs e)
		{
			using (CompetitionForm form = new CompetitionForm())
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					CloseCompetition();

					m_competition = form.Competition;
					m_competition.Save();

					m_competition.Repository.UpdateRecentCompetitions();

                    m_remindersMonitor = new Services.Reminders.RemindersMonitor(m_competition, this);
                    m_remindersMonitor.NewRemindersDue += m_remindersMonitor_NewRemindersDue;
                    m_remindersMonitor.RemindersNoLongerDue += m_remindersMonitor_RemindersNoLongerDue;
                    m_remindersMonitor.Start();

                    SetFormTitle();

					PopulateRecentCompetitions();
					PopulateTasks();

					RefreshControlState();

                    if (tasksTaskListBox.SelectedItems.Count > 0)
                    {
                        TaskOrCompetitionSelected();
                    }

                    tasksTaskListBox.Focus();
				}
			}
		}

		private void openCompetitionRibbonButton_Click(object sender, EventArgs e)
		{
			if (openCompetitionDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				OpenCompetition(openCompetitionDialog.FileName);
			}
		}

		private void openCompetitionRibbonButton_DropDownItemClicked(object sender, RibbonItemEventArgs e)
		{
			OpenCompetition(e.Item.Tag as string);
		}

		private void competitionPropertiesRibbonButton_Click(object sender, EventArgs e)
		{
			using (CompetitionForm form = new CompetitionForm(m_competition))
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_competition.Save();

					SetFormTitle();

                    PopulateTasks();

					if (tasksTaskListBox.SelectedItems.Count > 0)
					{
						TaskOrCompetitionSelected();
					}

					RefreshControlState();
				}
			}
		}

		private void reloadRibbonButton_Click(object sender, EventArgs e)
		{
			OpenCompetition(m_competition.Repository.FilePath);

			reloadRibbonButton.FlashEnabled = false;
		}

		private void backupRibbonButton_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Please save and close any scoring spreadsheets before continuing.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    m_competition.Repository.Backup(m_competition);

                    MessageBox.Show("Competition successfully backed up.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Unable to backup competition.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
		}

		private void defineFeaturesRibbonButton_Click(object sender, EventArgs e)
		{
            using (Features.FeatureDefinitionForm form = new Features.FeatureDefinitionForm(m_competition))
			{
				form.ShowDialog();

				m_competition.Save();
			}
		}

		private void pilotsSpreadsheetRibbonButton_Click(object sender, EventArgs e)
		{
			if (!m_competition.PilotsSpreadsheet.Exists())
			{
				m_competition.PilotsSpreadsheet.Create(m_competition.PilotsSpreadsheet.GetTemplateFilePaths()[0]);
			}

			m_competition.PilotsSpreadsheet.Open();

			RefreshControlState();
		}

		private void pilotMappingsRibbonButton_Click(object sender, EventArgs e)
		{
            Services.SettingsStore store = new Services.SettingsStore();

            if (string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationName) || string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationKey))
            {
                MessageBox.Show("Bytescout Spreadsheet registration details not set. Please set these details in the Options screen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

			using (ColumnMappingForm form = new ColumnMappingForm(m_competition.PilotsSpreadsheet, m_competition))
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					// TODO: Move this Save and all the others into child forms?
					m_competition.Save();
				}
			}

			this.Cursor = Cursors.Default;
		}

		private void addTaskRibbonButton_Click(object sender, EventArgs e)
		{
			using (TaskForm form = new TaskForm(m_competition))
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_competition.Save();

                    int newItemIndex = tasksTaskListBox.Items.Add(new TaskListItem(form.Task));
                    tasksTaskListBox.SelectedIndex = newItemIndex;

                    mainSplitContainer.SplitterDistance = tasksTaskListBox.GetRecommendedWidth();

                    RefreshControlState();
				}
			}
		}

		private void editTaskRibbonButton_Click(object sender, EventArgs e)
		{
			Models.Task task = (tasksTaskListBox.SelectedItem as TaskListItem).Task;

			using (TaskForm form = new TaskForm(task, m_competition))
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
                    task.Competition.Save();

                    tasksTaskListBox.Refresh();

                    mainSplitContainer.SplitterDistance = tasksTaskListBox.GetRecommendedWidth();
				}
			}
		}

		private void taskSpreadsheetRibbonButton_Click(object sender, EventArgs e)
		{
			Models.Task task = (tasksTaskListBox.SelectedItem as TaskListItem).Task;

			bool open = false;

			if (task.ScoringSpreadsheet.Exists())
			{
				open = true;
			}
			else
			{
				string[] templateFilePaths = task.ScoringSpreadsheet.GetTemplateFilePaths();

                using (ScoringSpreadsheetTemplateForm form = new ScoringSpreadsheetTemplateForm(templateFilePaths))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        task.ScoringSpreadsheet.Create(form.SelectedTemplateFilePath);
                        open = true;
                    }
                }
            }

			if (open)
			{
				task.ScoringSpreadsheet.Open();

				RefreshControlState();
			}
		}

		private void taskMappingsRibbonButton_Click(object sender, EventArgs e)
		{
            Services.SettingsStore store = new Services.SettingsStore();

            if (string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationName) || string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationKey))
            {
                MessageBox.Show("Bytescout Spreadsheet registration details not set. Please set these details in the Options screen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Models.Task task = (tasksTaskListBox.SelectedItem as TaskListItem).Task;

			this.Cursor = Cursors.WaitCursor;

			using (ColumnMappingForm form = new ColumnMappingForm(task.ScoringSpreadsheet, task))
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_competition.Save();
				}
			}

			this.Cursor = Cursors.Default;
		}

		private void selectTaskFeaturesRibbonButton_Click(object sender, EventArgs e)
		{
			Models.Task task = (tasksTaskListBox.SelectedItem as TaskListItem).Task;

			using (Features.TaskFeaturesForm form = new Features.TaskFeaturesForm(task))
			{
				form.ShowDialog();

				m_competition.Save();
			}
		}

		private void trackAnalysisRibbonButton_Click(object sender, EventArgs e)
		{
            Services.SettingsStore store = new Services.SettingsStore();

            if (string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationName) || string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationKey))
            {
                MessageBox.Show("Bytescout Spreadsheet registration details not set. Please set these details in the Options screen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Models.Task task = (tasksTaskListBox.SelectedItem as TaskListItem).Task;

            this.Cursor = Cursors.WaitCursor;

            using (TrackAnalysis.TrackAnalysisForm form = new TrackAnalysis.TrackAnalysisForm(task))
            {
                form.ShowDialog();

                m_competition.Save();
            }

            this.Cursor = Cursors.Default;
        }

		private void generateTaskRibbonButton_Click(object sender, EventArgs e)
		{
			Models.Task selectedTask = (tasksTaskListBox.SelectedItem as TaskListItem).Task;
            Models.AircraftClass selectedAircraftClass = (aircraftClassesListBox.SelectedItem as AircraftClassListItem).AircraftClass;

            foreach (Models.Results.TaskResults taskResults in selectedTask.Results)
            {
                if (taskResults.AircraftClass.Code == selectedAircraftClass.Code)
                {
                    if (GenerateResults(taskResults))
                    {
                        using (Results.TaskResultsForm resultsForm = new Results.TaskResultsForm(taskResults))
                        {
                            if (resultsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                RefreshControlState();

                                DisplayTaskResults(selectedTask, selectedAircraftClass);
                            }
                        }

                        selectedTask.Competition.Save();
                    }

                    break;
                }
            }
		}

		private void generateOverallRibbonButton_Click(object sender, EventArgs e)
		{
            Models.AircraftClass selectedAircraftClass = (aircraftClassesListBox.SelectedItem as AircraftClassListItem).AircraftClass;

            using (Results.OverallResultsOptionsForm optionsForm = new Results.OverallResultsOptionsForm(m_competition, selectedAircraftClass))
			{
				if (optionsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					Models.Results.OverallResultsGenerationOptions options = new Models.Results.OverallResultsGenerationOptions(optionsForm.SelectedTaskNumbers);

                    foreach (Models.Results.OverallResults overallResults in m_competition.OverallResults)
                    {
                        if (overallResults.AircraftClass.Code == selectedAircraftClass.Code)
                        {
                            if (GenerateResults(overallResults, options))
                            {
                                using (Results.OverallResultsForm resultsForm = new Results.OverallResultsForm(overallResults))
                                {
                                    if (resultsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        RefreshControlState();

                                        SelectCompetition();
                                        SelectAircraftClass(selectedAircraftClass);

                                        DisplayOverallResults(selectedAircraftClass);
                                    }
                                }
                            }

                            break;
                        }
                    }
				}
			}
		}

		private void generateTeamRibbonButton_Click(object sender, EventArgs e)
		{
            Models.AircraftClass selectedAircraftClass = (aircraftClassesListBox.SelectedItem as AircraftClassListItem).AircraftClass;

			using (Results.TeamResultsOptionsForm optionsForm = new Results.TeamResultsOptionsForm(m_competition, selectedAircraftClass))
			{
				if (optionsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					Models.Results.TeamResultsGenerationOptions options = new Models.Results.TeamResultsGenerationOptions(optionsForm.SelectedTaskNumbers);

                    foreach (Models.Results.TeamResults teamResults in m_competition.TeamResults)
                    {
                        if (teamResults.AircraftClass.Code == selectedAircraftClass.Code)
                        {
                            if (GenerateResults(teamResults, options))
                            {
                                using (Results.TeamResultsForm resultsForm = new Results.TeamResultsForm(teamResults))
                                {
                                    if (resultsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        RefreshControlState();

                                        SelectCompetition();
                                        SelectAircraftClass(selectedAircraftClass);

                                        DisplayTeamResults(selectedAircraftClass);
                                    }
                                }
                            }

                            break;
                        }
                    }
				}
			}
		}

        private void generateNationRibbonButton_Click(object sender, EventArgs e)
        {
            using (Results.NationResultsOptionsForm optionsForm = new Results.NationResultsOptionsForm(m_competition))
            {
                if (optionsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Models.Results.NationResultsGenerationOptions options = new Models.Results.NationResultsGenerationOptions(optionsForm.SelectedTaskNumbers);

                    if (GenerateResults(m_competition.NationResults, options))
                    {
                        using (Results.NationResultsForm resultsForm = new Results.NationResultsForm(m_competition.NationResults))
                        {
                            if (resultsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                RefreshControlState();

                                SelectCompetition();
                                SelectAircraftClass(null);

                                DisplayNationResults();
                            }
                        }
                    }
                }
            }
        }

		private void printRibbonButton_Click(object sender, EventArgs e)
		{
            Models.Task selectedTask;
            Models.AircraftClass selectedAircraftClass;

            GetSelectedTaskAndAircraftClass(out selectedTask, out selectedAircraftClass);

            if (selectedTask == null)
            {
                if (selectedAircraftClass == null)
                {
                    nationResultsPdfViewer.Print();
                }
                else
                {
                    if (resultsTabControl.SelectedTab == competitionResultsTabPage)
                    {
                        competitionResultsPdfViewer.Print();
                    }
                    else if (resultsTabControl.SelectedTab == teamResultsTabPage)
                    {
                        teamResultsPdfViewer.Print();
                    }
                }
            }
            else
            {
                taskResultsPdfViewer.Print();
            }
		}

		private void uploadRibbonButton_Click(object sender, EventArgs e)
		{
			//
		}

		private void optionsRibbonButton_Click(object sender, EventArgs e)
		{
			using (OptionsForm form = new OptionsForm())
			{
				form.ShowDialog();
			}
		}

		private void convertTracksRibbonButton_Click(object sender, EventArgs e)
		{
			using (TrackConversionForm form = new TrackConversionForm())
			{
				form.ShowDialog();
			}
		}

		private void createPdfRibbonButton_Click(object sender, EventArgs e)
		{
			if (CheckIfPdfWriterIsConfigured())
			{
				using (CreatePdfForm form = new CreatePdfForm())
				{
					form.ShowDialog();
				}
			}
		}

		private void aboutRibbonButton_Click(object sender, EventArgs e)
		{
			using (AboutForm form = new AboutForm())
			{
				form.ShowDialog();
			}
		}

		private void tasksTaskListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			TaskOrCompetitionSelected();
		}

		private void resultsTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
            AircraftClassListItem selectedAircraftClassItem = aircraftClassesListBox.SelectedItem as AircraftClassListItem;

            if (resultsTabControl.SelectedTab == competitionResultsTabPage)
			{
				DisplayOverallResults(selectedAircraftClassItem.AircraftClass);
			}

			if (resultsTabControl.SelectedTab == teamResultsTabPage)
			{
				DisplayTeamResults(selectedAircraftClassItem.AircraftClass);
			}

			RefreshControlState();
		}

        private void checkForUpdatesRibbonButton_Click(object sender, EventArgs e)
        {
            using (Services.ApplicationUpdater checker = new Services.ApplicationUpdater())
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    if (checker.IsUpdateAvailable())
                    {
                        if (MessageBox.Show("An update is available, would you like to install it now?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            using (UpdateCheckForm form = new UpdateCheckForm(checker))
                            {
                                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    this.Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("You are running the latest version of {0}.", Application.ProductName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to check for updates.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void calculateDistanceRibbonButton_Click(object sender, EventArgs e)
        {
            using (CalculateDistanceForm form = new CalculateDistanceForm())
            {
                form.ShowDialog();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            mainSplitContainer.Width = this.ClientSize.Width;
            mainSplitContainer.Height = this.ClientSize.Height - mainSplitContainer.Top;
        }

        private void mainSplitContainer_Panel1_Resize(object sender, EventArgs e)
        {
            tasksTaskListBox.Width = mainSplitContainer.Panel1.Width;
            tasksTaskListBox.Height = mainSplitContainer.Panel1.Height - tasksTaskListBox.Top - 22;
        }

        private void mainSplitContainer_Panel2_Resize(object sender, EventArgs e)
        {
            aircraftClassesListBox.Height = mainSplitContainer.Panel2.ClientSize.Height - aircraftClassesListBox.Top - 22;

            resultsTabControl.Width = mainSplitContainer.Panel2.ClientSize.Width - resultsTabControl.Left;
            resultsTabControl.Height = mainSplitContainer.Panel2.ClientSize.Height - resultsTabControl.Top - 22;

            taskResultsPdfViewer.Left = resultsTabControl.Left;
            taskResultsPdfViewer.Top = resultsTabControl.Top;
            taskResultsPdfViewer.Width = resultsTabControl.Width;
            taskResultsPdfViewer.Height = resultsTabControl.Height;

            nationResultsPdfViewer.Left = resultsTabControl.Left;
            nationResultsPdfViewer.Top = resultsTabControl.Top;
            nationResultsPdfViewer.Width = resultsTabControl.Width;
            nationResultsPdfViewer.Height = resultsTabControl.Height;
        }

        private void aircraftClassesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_selectingAircraftClass) return;

            Models.Task selectedTask;
            Models.AircraftClass selectedAircraftClass;

            GetSelectedTaskAndAircraftClass(out selectedTask, out selectedAircraftClass);

            if (selectedTask == null)
            {
                if (selectedAircraftClass == null)
                {
                    DisplayNationResults();
                }
                else
                {
                    if (resultsTabControl.SelectedTab == teamResultsTabPage)
                    {
                        DisplayTeamResults(selectedAircraftClass);
                    }
                    else
                    {
                        DisplayOverallResults(selectedAircraftClass);
                    }
                }
            }
            else
            {
                DisplayTaskResults(selectedTask, selectedAircraftClass);
            }

            RefreshControlState();
        }

        private void reminderNotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            reminderNotifyIcon.Visible = false;

            if (m_remindersForm != null)
            {
                m_remindersForm.ReloadOverdue();

                if (m_remindersForm.WindowState == FormWindowState.Minimized)
                {
                    m_remindersForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                m_remindersForm = new Reminders.RemindersForm(m_competition, true);
                m_remindersForm.FormClosed += m_remindersForm_FormClosed;

                m_remindersForm.Show(this);
            }

            m_remindersForm.Activate();
        }

        private void reminderNotifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            reminderNotifyIcon.Visible = false;
        }

        private void remindersRibbonButton_Click(object sender, EventArgs e)
        {
            if (m_remindersForm != null)
            {
                m_remindersForm.ReloadAll();

                if (m_remindersForm.WindowState == FormWindowState.Minimized)
                {
                    m_remindersForm.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                m_remindersForm = new Reminders.RemindersForm(m_competition, false);
                m_remindersForm.FormClosed += m_remindersForm_FormClosed;

                m_remindersForm.Show(this);
            }

            m_remindersForm.Activate();
        }

		private void copyTaskRibbonButton_Click(object sender, EventArgs e)
		{
            Models.Task taskToCopy = (tasksTaskListBox.SelectedItem as TaskListItem).Task;

            Services.TaskDuplicator duplicator = new Services.TaskDuplicator();
            Models.Task newTask = duplicator.Duplicate(taskToCopy, m_competition);

            int newItemIndex = tasksTaskListBox.Items.Add(new TaskListItem(newTask));
            tasksTaskListBox.SelectedIndex = newItemIndex;

            mainSplitContainer.SplitterDistance = tasksTaskListBox.GetRecommendedWidth();

            RefreshControlState();
        }

		private void liveScoresRibbonButton_Click(object sender, EventArgs e)
		{
            Services.SettingsStore store = new Services.SettingsStore();

            if (string.IsNullOrEmpty(store.GoogleMapsApiKey))
            {
                MessageBox.Show("Google API key not set. Please set these details in the Options screen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationName) || string.IsNullOrEmpty(store.BytescoutSpreadsheetRegistrationKey))
            {
                MessageBox.Show("Bytescout Spreadsheet registration details not set. Please set these details in the Options screen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(m_competition.FlymasterApiUsername) || string.IsNullOrEmpty(m_competition.FlymasterApiPassword) || string.IsNullOrEmpty(m_competition.FlymasterApiGroupId))
            {
                MessageBox.Show("Flymaster API details not set. Please set these details in the competition Properties screen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Models.Task task = (tasksTaskListBox.SelectedItem as TaskListItem).Task;

            if (!task.LandBySet)
            {
                MessageBox.Show("A 'Land by' date & time must be set in order to load Flymaster tracks", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (LiveScores.LiveScoresForm form = new LiveScores.LiveScoresForm(task))
            {
                form.ShowDialog();
            }
        }
	}
}
