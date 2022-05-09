using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Boris.UI
{
	partial class MainOldForm : Form
	{
		private Models.Competition m_competition;

		public MainOldForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			RefreshControlState();
		}

        private bool GenerateResults(Models.Results.Results results)
        {
            if (Services.Pdf.PdfWriter.IsConfigured())
            {
                using (GenerateResultsForm generateForm = new GenerateResultsForm(results, null))
                {
                    return (generateForm.ShowDialog() == System.Windows.Forms.DialogResult.OK);
                }
            }
            else
            {
                MessageBox.Show("PDF Writer not configured, set Apache FOP path in Options.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

		private void DisplayTaskResults()
		{
			Models.Task task = competitionExplorerControl.GetSelectedTask();

			if (task != null)
			{
                DisplayResults(task.Results, taskResultsWebBrowser);
			}
			else
			{
				taskResultsWebBrowser.Navigate("about:blank");
			}

            taskResultsWebBrowser.BringToFront();
		}

        private void DisplayCompetitionResults()
        {
            DisplayResults(m_competition.Results, competitionResultsWebBrowser);

            resultsTabControl.BringToFront();
            resultsTabControl.SelectedTab = competitionResultsTabPage;
        }

        private void DisplayTeamResults()
        {
            DisplayResults(m_competition.TeamResults, teamResultsWebBrowser);

            resultsTabControl.BringToFront();
            resultsTabControl.SelectedTab = teamResultsTabPage;
        }

        private void DisplayLeagueResults()
        {
            DisplayResults(m_competition.LeagueResults, leagueResultsWebBrowser);

            resultsTabControl.BringToFront();
            resultsTabControl.SelectedTab = leagueResultsTabPage;
        }

        private void DisplayResults(Models.Results.Results results, WebBrowser browser)
        {
            if (results.Exists())
            {
                Uri url = new Uri(results.GetPublishedUrl() + "#toolbar=0&navpanes=0");

                if (browser.Url == null || url.ToString() != browser.Url.ToString())
                {
                    browser.Navigate(url);
                }
            }
            else
            {
                browser.Navigate("about:blank");
            }
        }

		private void RefreshControlState()
		{
			RefreshMenuStripState();
			RefreshToolStripState();
		}

		private void RefreshMenuStripState()
		{
		}

		private void RefreshToolStripState()
		{
			Models.Task selectedTask = competitionExplorerControl.GetSelectedTask();
            bool pilotsSpreadsheetExists = (m_competition != null && m_competition.PilotsSpreadsheet.Exists());
            bool scoringSpreadsheetExists = (selectedTask != null && selectedTask.ScoringSpreadsheet.Exists());

			defineNfzsMenuItem.Enabled = (m_competition != null);

			pilotsSplitButton.Enabled = (m_competition != null);
            pilotsMappingsMenuItem.Enabled = pilotsSpreadsheetExists;
			scoringSplitButton.Enabled = (selectedTask != null);
            scoringMappingMenuItem.Enabled = scoringSpreadsheetExists;
            generateResultsDropDownButton.Visible = (pilotsSpreadsheetExists && selectedTask == null);
            generateTaskResultsButton.Visible = (pilotsSpreadsheetExists && scoringSpreadsheetExists);

            if (m_competition != null)
            {
                if (selectedTask != null && selectedTask.Results.Exists())
                {
                    printResultsButton.Enabled = true;
                }
                else
                {
                    if (resultsTabControl.SelectedTab == competitionResultsTabPage && m_competition.Results.Exists())
                    {
                        printResultsButton.Enabled = true;
                    }
                    else if (resultsTabControl.SelectedTab == teamResultsTabPage && m_competition.TeamResults.Exists())
                    {
                        printResultsButton.Enabled = true;
                    }
                    else if (resultsTabControl.SelectedTab == leagueResultsTabPage && m_competition.LeagueResults.Exists())
                    {
                        printResultsButton.Enabled = true;
                    }
                    else
                    {
                        printResultsButton.Enabled = false;
                    }
                }
            }
            else
            {
                printResultsButton.Enabled = false;
            }
		}

		private void fileExitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void createPdfMenuItem_Click(object sender, EventArgs e)
        {
            using (CreatePdfForm form = new CreatePdfForm())
            {
                form.ShowDialog();
            }
        }

        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            using (OptionsForm form = new OptionsForm())
            {
                form.ShowDialog();
            }
        }

		private void newCompetitionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			using (CompetitionForm form = new CompetitionForm())
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_competition = form.Competition;
					m_competition.Save();

                    competitionExplorerControl.AddCompetition(m_competition);

					startupPanel.Visible = false;
					competitionSplitContainer.Visible = true;
				}
			}
		}

		private void openCompetitionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (openCompetitionDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
                Services.CompetitionRepository repository = new Services.CompetitionRepository(openCompetitionDialog.FileName);
                m_competition = repository.LoadCompetition();

                competitionExplorerControl.AddCompetition(m_competition);

				startupPanel.Visible = false;
				competitionSplitContainer.Visible = true;
			}
		}

		private void startupPanel_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(new Pen(Color.LightSteelBlue, 1), 200, 25, 200, startupPanel.ClientSize.Height - 25);
		}

		private void startupPanel_SizeChanged(object sender, EventArgs e)
		{
			startupPanel.Invalidate();
		}

		private void competitionExplorerControl_ItemSelected(object sender, EventArgs e)
		{
            Models.Task task = competitionExplorerControl.GetSelectedTask();

            if (task != null)
            {
                DisplayTaskResults();
            }
            else
            {
                DisplayCompetitionResults();
            }

			RefreshControlState();
		}

		private void competitionExplorerControl_EditCompetition(object sender, EventArgs e)
		{
			Models.Competition competition = competitionExplorerControl.GetSelectedCompetition();

			using (CompetitionForm form = new CompetitionForm(competition))
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					competitionExplorerControl.UpdateCompetition(competition);

					competition.Save();
				}
			}
		}

        private void competitionExplorerControl_NewTask(object sender, EventArgs e)
        {
            Models.Competition competition = competitionExplorerControl.GetSelectedCompetition();

            using (TaskForm form = new TaskForm(competition))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    competitionExplorerControl.AddTask(form.Task);

                    competition.Save();
                }
            }
        }

        private void competitionExplorerControl_EditTask(object sender, EventArgs e)
        {
            Models.Task task = competitionExplorerControl.GetSelectedTask();

            using (TaskForm form = new TaskForm(task))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    competitionExplorerControl.UpdateTask(task);

                    task.Competition.Save();
                }
            }
        }

        private void competitionExplorerControl_EditLeague(object sender, EventArgs e)
        {
            Models.Competition competition = competitionExplorerControl.GetSelectedCompetition();

            using (LeagueForm form = new LeagueForm(competition))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    competition.Save();
                }
            }
        }

        private void pilotsSplitButton_ButtonClick(object sender, EventArgs e)
        {
			if (!m_competition.PilotsSpreadsheet.Exists())
			{
				m_competition.PilotsSpreadsheet.Create(m_competition.PilotsSpreadsheet.GetTemplateFilePaths()[0]);
			}

			m_competition.PilotsSpreadsheet.Open();

            RefreshControlState();
        }

        private void pilotsMappingsMenuItem_Click(object sender, EventArgs e)
        {
			using (ColumnMappingForm form = new ColumnMappingForm(m_competition.PilotsSpreadsheet))
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_competition.Save();
				}
			}
        }

		private void scoringSplitButton_ButtonClick(object sender, EventArgs e)
		{
			Models.Task task = competitionExplorerControl.GetSelectedTask();

            bool open = false;

            if (task.ScoringSpreadsheet.Exists())
            {
                open = true;
            }
            else
			{
                string[] templateFilePaths = task.ScoringSpreadsheet.GetTemplateFilePaths();

                if (templateFilePaths.Length > 1)
                {
                    using (ScoringSpreadsheetTemplateForm form = new ScoringSpreadsheetTemplateForm(templateFilePaths))
                    {
                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            task.ScoringSpreadsheet.Create(form.SelectedTemplateFilePath);
                            open = true;
                        }
                    }
                }
                else
                {
                    task.ScoringSpreadsheet.Create(templateFilePaths[0]);
                    open = true;
                }
			}

            if (open)
            {
                task.ScoringSpreadsheet.Open();

                RefreshControlState();
            }
		}

		private void scoringMappingMenuItem_Click(object sender, EventArgs e)
		{
			Models.Task task = competitionExplorerControl.GetSelectedTask();

			using (ColumnMappingForm form = new ColumnMappingForm(task.ScoringSpreadsheet))
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_competition.Save();
				}
			}
		}

        private void generateCompetitionResultsMenuItem_Click(object sender, EventArgs e)
        {
            if (GenerateResults(m_competition.Results))
            {
                using (CompetitionResultsForm resultsForm = new CompetitionResultsForm(m_competition.Results))
                {
                    if (resultsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        RefreshControlState();

                        DisplayCompetitionResults();
                    }
                }
            }
        }

        private void generateTeamResultsMenuItem_Click(object sender, EventArgs e)
        {
            if (GenerateResults(m_competition.TeamResults))
            {
                using (TeamResultsForm resultsForm = new TeamResultsForm(m_competition.TeamResults))
                {
                    if (resultsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        RefreshControlState();

                        DisplayTeamResults();
                    }
                }
            }
        }

        private void generateLeagueResultsMenuItem_Click(object sender, EventArgs e)
        {
            bool generateResults = false;
            string message = "Do you want to check for valid classes and competitors?";

            switch (MessageBox.Show(message, this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    m_competition.LeagueResults.CheckForValidClasses = true;
                    generateResults = true;
                    break;
                case System.Windows.Forms.DialogResult.No:
                    m_competition.LeagueResults.CheckForValidClasses = false;
                    generateResults = true;
                    break;
            }

            if (generateResults)
            {
                if (GenerateResults(m_competition.LeagueResults))
                {
                    using (LeagueResultsForm resultsForm = new LeagueResultsForm(m_competition.LeagueResults))
                    {
                        if (resultsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            RefreshControlState();

                            DisplayLeagueResults();
                        }
                    }
                }
            }
        }

        private void generateTaskResultsButton_Click(object sender, EventArgs e)
        {
            Models.Task task = competitionExplorerControl.GetSelectedTask();

            if (GenerateResults(task.Results))
            {
                using (TaskResultsForm resultsForm = new TaskResultsForm(task.Results))
                {
                    if (resultsForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        RefreshControlState();

                        DisplayTaskResults();
                    }
                }

                task.Competition.Save();
            }
        }

        private void printResultsButton_Click(object sender, EventArgs e)
        {
            Models.Task selectedTask = competitionExplorerControl.GetSelectedTask();

            if (selectedTask != null)
            {
                taskResultsWebBrowser.ShowPrintDialog();
            }
            else
            {
                if (resultsTabControl.SelectedTab == competitionResultsTabPage)
                {
                    competitionResultsWebBrowser.ShowPrintDialog();
                }

                if (resultsTabControl.SelectedTab == teamResultsTabPage)
                {
                    teamResultsWebBrowser.ShowPrintDialog();
                }

                if (resultsTabControl.SelectedTab == leagueResultsTabPage)
                {
                    leagueResultsWebBrowser.ShowPrintDialog();
                }
            }
        }

        private void resultsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultsTabControl.SelectedTab == competitionResultsTabPage)
            {
                DisplayCompetitionResults();
            }

            if (resultsTabControl.SelectedTab == teamResultsTabPage)
            {
                DisplayTeamResults();
            }

            if (resultsTabControl.SelectedTab == leagueResultsTabPage)
            {
                DisplayLeagueResults();
            }

            RefreshControlState();
        }

		private void tracksMenuItem_Click(object sender, EventArgs e)
		{
            //using (TracksForm form = new TracksForm())
            //{
            //    form.ShowDialog();
            //}

            Models.Nfz[] nfzs;
			Location.Tracks.Track track;
            int[] incursionIndices;

            if (CheckForNfzIncursion(out nfzs, out track, out incursionIndices))
            {
                MessageBox.Show("Intersection.");

                using (NfzIncursionForm form = new NfzIncursionForm(nfzs, track, incursionIndices))
                {
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No intersection.");
            }
		}

        private static bool CheckForNfzIncursion(out Models.Nfz[] nfzs, out Location.Tracks.Track track, out int[] incursionIndices)
        {
            nfzs = new Models.Nfz[1];
            List<int> indices = new List<int>();

			nfzs[0] = new Models.Nfz();
            nfzs[0].Latitude = 51.511576M;
            nfzs[0].Longitude = -0.735876M;
            nfzs[0].Radius = 250;

            // Intersects
			track = new Location.Tracks.Track();
			track.Points.Add(new Location.Location(51.515604M, -0.741893M));
			track.Points.Add(new Location.Location(51.511663M, -0.740479M));
			track.Points.Add(new Location.Location(51.509400M, -0.732834M));
			track.Points.Add(new Location.Location(51.511926M, -0.727734M));

            indices.Add(1);
            indices.Add(2);

            incursionIndices = indices.ToArray();

			return IsIntersection2(nfzs[0], track.Points[1].Latitude, track.Points[1].Longitude, track.Points[2].Latitude, track.Points[2].Longitude);

            // Does not intersect
            //points = new Models.LatLon[2];
            //points[0].Latitude = 51.510972M;
            //points[0].Longitude = -0.742904M;
            //points[1].Latitude = 51.507822M;
            //points[1].Longitude = -0.734500M;

            //return IsIntersection2(nfzs[0], points[0].Latitude, points[0].Longitude, points[1].Latitude, points[1].Longitude);
        }

        private static bool IsIntersection1(Models.Nfz nfz, decimal pointALat, decimal pointALon, decimal pointBLat, decimal pointBLon)
        {
            // Does not work

            decimal area = Math.Abs((pointBLon - pointALon) * (pointALat - nfz.Latitude) - (nfz.Longitude - pointALon) * (pointBLat - pointALat));
            double lab = Math.Sqrt(Math.Pow((double)(pointBLon - pointALon), 2) + Math.Pow((double)(pointBLat - pointALat), 2));
            double h = (double)area / lab;

            return (h < nfz.Radius);
        }

        private static bool IsIntersection2(Models.Nfz nfz, decimal pointALat, decimal pointALon, decimal pointBLat, decimal pointBLon)
        {
            double lab = Math.Sqrt(Math.Pow((double)(pointBLon - pointALon), 2) + Math.Pow((double)(pointBLat - pointALat), 2));

            double dX = (double)(pointBLon - pointALon) / lab;
            double dY = (double)(pointBLat - pointALat) / lab;

            double t = dX * (double)(nfz.Longitude - pointALon) + dY * (double)(nfz.Latitude - pointALat);

            double eX = t * dX + (double)pointALon;
            double eY = t * dY + (double)pointALat;

            // Use Haversine formula to calculate distance
            //double lec = Math.Sqrt(Math.Pow(eX - (double)nfz.Longitude, 2) + Math.Pow(eY - (double)nfz.Latitude, 2));
			ColinBaker.Location.HaversineDistanceCalculator calculator = new Location.HaversineDistanceCalculator();
			double lec = calculator.CalculateDistance(new ColinBaker.Location.Location((decimal)eY, (decimal)eX), new ColinBaker.Location.Location(nfz.Latitude, nfz.Longitude));

            return (lec < nfz.Radius);
        }

		private void checkForNfzIncursionsMenuItem_Click(object sender, EventArgs e)
		{
			//
		}

		private void defineNfzsMenuItem_Click(object sender, EventArgs e)
		{
			System.Collections.ObjectModel.Collection<Models.Nfz> nfzs = m_competition.LoadNfzs();

			using (NfzDefinitionForm form = new NfzDefinitionForm(nfzs))
			{
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					m_competition.SaveNfzs(nfzs);
				}
			}
		}

		private void convertTracksMenuItem_Click(object sender, EventArgs e)
		{
			using (TrackConversionForm form = new TrackConversionForm())
			{
				form.ShowDialog();
			}
		}

		private void aboutMenuItem_Click(object sender, EventArgs e)
		{
			using (AboutForm form = new AboutForm())
			{
				form.ShowDialog();
			}
		}
	}
}
