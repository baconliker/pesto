using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ColinBaker.Pesto.UI.TrackAnalysis
{
	internal partial class AnalysisProgressForm : Form
	{
		private delegate void FinishAnalysisHandler(Exception exception);
		private delegate void UpdateProgressHandler(int fixes, int currentFix);

        private int m_processedTracksFixCount = 0;

        public AnalysisProgressForm(Models.Task task, Models.TrackAnalysis.Pilot[] pilotsToAnalyze, int minAltitude)
        {
            InitializeComponent();

            this.Task = task;
            this.PilotsToAnalyse = pilotsToAnalyze;
            this.MinAltitude = minAltitude;

            int totalFixes = 0;

            foreach (Models.TrackAnalysis.Pilot pilot in pilotsToAnalyze)
            {
                totalFixes += pilot.Track.Fixes.Count;
            }

            analysisProgressBar.Minimum = 0;
            analysisProgressBar.Maximum = totalFixes;
            analysisProgressBar.Value = 0;

            Thread thread = new Thread(new ThreadStart(StartAnalysis));
            thread.Start();
        }

        public Models.Task Task { get; private set; }
        public Models.TrackAnalysis.Pilot[] PilotsToAnalyse { get; private set; }
        public int MinAltitude { get; private set; }

		public Models.TrackAnalysis.TrackAnalyzer Analyzer { get; set; }

		private void StartAnalysis()
		{
			Exception analysisException = null;

			try
			{
                foreach (Models.TrackAnalysis.Pilot pilot in this.PilotsToAnalyse)
                {
                    Models.TrackAnalysis.TrackAnalyzer analyzer = new Models.TrackAnalysis.TrackAnalyzer(this.Task, pilot.Track, this.MinAltitude);

                    analyzer.ProgressChanged += new EventHandler<Models.TrackAnalysis.AnalysisProgressEventArgs>(Analyzer_ProgressChanged);

                    analyzer.RunAnalysis();

                    pilot.Events = analyzer.Events;

                    analyzer.ProgressChanged -= new EventHandler<Models.TrackAnalysis.AnalysisProgressEventArgs>(Analyzer_ProgressChanged);

                    m_processedTracksFixCount += pilot.Track.Fixes.Count;
                }

				Thread.Sleep(1000);
			}
			catch (Exception ex)
			{
				analysisException = ex;

                // Remove all events from all pilots otherwise we could be left in a confusing state

                foreach (Models.TrackAnalysis.Pilot pilot in this.PilotsToAnalyse)
                {
                    pilot.Events = null;
                }
			}

			FinishAnalysis(analysisException);
		}

		private void UpdateProgress(int fixes, int currentFix)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new UpdateProgressHandler(UpdateProgress), new object[] { fixes, currentFix });
			}
			else
			{
                int newValue = m_processedTracksFixCount + currentFix;

                if (newValue > analysisProgressBar.Maximum)
                {
                    analysisProgressBar.Value = analysisProgressBar.Maximum;
                }
                else
                {
                    analysisProgressBar.Value = newValue;
                }
			}
		}

		private void FinishAnalysis(Exception exception)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new FinishAnalysisHandler(FinishAnalysis), new object[] { exception });
			}
			else
			{
				if (exception == null)
				{
					this.DialogResult = System.Windows.Forms.DialogResult.OK;
				}
				else
				{
					MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

				this.Close();
			}
		}

		private void Analyzer_ProgressChanged(object sender, Models.TrackAnalysis.AnalysisProgressEventArgs e)
		{
			UpdateProgress(e.Fixes, e.CurrentFix);
		}
	}
}
