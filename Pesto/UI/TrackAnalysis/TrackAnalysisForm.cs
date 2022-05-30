using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace ColinBaker.Pesto.UI.TrackAnalysis
{
	internal partial class TrackAnalysisForm : Form
	{
        Models.TrackAnalysis.Events.TrackEvent.EventType[] m_filterEventTypes = Models.TrackAnalysis.Events.TrackEvent.AllTypes;

        public TrackAnalysisForm(Models.Task task)
		{
			InitializeComponent();

			this.Task = task;
		}

		public Models.Task Task { get; private set; }

		private void PopulatePilots()
		{
			foreach (Models.AircraftClass aircraftClass in this.Task.Competition.AircraftClasses)
			{
				string pilotNumberColumnName = this.Task.Competition.PilotsSpreadsheet.GetMapping(Models.Column.ColumnType.PilotNumber).ColumnName;
				string pilotNameColumnName = this.Task.Competition.PilotsSpreadsheet.GetMapping(Models.Column.ColumnType.PilotName).ColumnName;
                Models.Spreadsheets.SpreadsheetColumnMapping loggerIdMapping = this.Task.Competition.PilotsSpreadsheet.GetMapping(Models.Column.ColumnType.LoggerId);

                using (DataTable pilotData = this.Task.Competition.PilotsSpreadsheet.GetData(aircraftClass.Code))
				{
					foreach (DataRow pilotRow in pilotData.Rows)
					{
                        Models.TrackAnalysis.Pilot pilot = new Models.TrackAnalysis.Pilot((int)pilotRow[pilotNumberColumnName], (string)pilotRow[pilotNameColumnName], loggerIdMapping != null && pilotData.Columns.Contains(loggerIdMapping.ColumnName) ? (string)pilotRow[loggerIdMapping.ColumnName] : "", aircraftClass.Code);

                        object[] row = new object[3];

                        row[0] = pilot.Number;
                        row[1] = pilot.Name;
                        row[2] = pilot.AircraftClassCode;

                        int rowIndex = pilotsDataGridView.Rows.Add(row);

                        pilotsDataGridView.Rows[rowIndex].Tag = pilot;
					}
				}
			}

			RefreshControlState();
		}

		private void ClearEvents()
		{
			eventsDataGridView.Rows.Clear();

			eventsSplitContainer.Panel1Collapsed = true;
		}

		private void PopulateEvents(List<Models.TrackAnalysis.Events.TrackEvent> trackEvents)
		{
			ClearEvents();

			List<Models.TrackAnalysis.Events.TrackEvent.EventType> eventTypesToInclude = new List<Models.TrackAnalysis.Events.TrackEvent.EventType>(m_filterEventTypes);

			Models.TrackAnalysis.Events.TrackEvent firstEvent = null;
			int counter = 0;

			foreach (Models.TrackAnalysis.Events.TrackEvent trackEvent in trackEvents)
			{
				if (eventTypesToInclude.Contains(trackEvent.Type))
				{
					counter++;

					object[] row = new object[10];

					Image classificationIcon = null;
					switch (trackEvent.Classification)
					{
						case Models.TrackAnalysis.Events.TrackEvent.EventClassification.Information:
							classificationIcon = eventClassificationImageList.Images["Information"];
							break;
						case Models.TrackAnalysis.Events.TrackEvent.EventClassification.Achievement:
							classificationIcon = eventClassificationImageList.Images["Achievement"];
							break;
						case Models.TrackAnalysis.Events.TrackEvent.EventClassification.Warning:
							classificationIcon = eventClassificationImageList.Images["Warning"];
							break;
						case Models.TrackAnalysis.Events.TrackEvent.EventClassification.Failure:
							classificationIcon = eventClassificationImageList.Images["Failure"];
							break;
					}

					row[0] = classificationIcon;
					row[1] = counter;
					if (trackEvent.TimeSet)
					{
                        row[2] = trackEvent.Time.ToLocalTime().ToString("HH:mm:ss");
						if (firstEvent == null)
						{
							row[3] = trackEvent.Time.Subtract(trackEvent.Time).ToString();
						}
						else
						{
							row[3] = trackEvent.Time.Subtract(firstEvent.Time).ToString();
						}
					}
					else
					{
						row[2] = "N/A";
						row[3] = "N/A";
					}
					row[4] = trackEvent.Description;
					row[5] = Models.TrackAnalysis.Events.TrackEvent.FormatCategoryDescription(trackEvent.Category);
					row[6] = trackEvent.Location.Latitude.ToString("#0.000000");
					row[7] = trackEvent.Location.Longitude.ToString("##0.000000");
					row[8] = trackEvent.Location.Altitude.ToString("0.0");

					int index = eventsDataGridView.Rows.Add(row);

					eventsDataGridView.Rows[index].Tag = trackEvent;

					if (firstEvent == null)
					{
						firstEvent = trackEvent;
					}
				}
			}

			if (counter == 0)
			{
				eventsSplitContainer.Panel1Collapsed = true;
			}
			else
			{
				eventsSplitContainer.Panel1Collapsed = false;

				// Calculate the height of all the grid content so we can allocate as much screen estate to the map as possible
				int gridContentHeight = eventsDataGridView.ColumnHeadersHeight;
				for (int i = 0; i < eventsDataGridView.Rows.Count; i++)
				{
					gridContentHeight += eventsDataGridView.Rows[i].Height;
				}
				gridContentHeight += 2; // Extra for the grid borders

				int maxGridHeight = eventsSplitContainer.Height / 2;

				if (gridContentHeight > maxGridHeight)
				{
					eventsSplitContainer.SplitterDistance = maxGridHeight;
				}
				else
				{
					eventsSplitContainer.SplitterDistance = gridContentHeight;
				}
			}
		}

		private void CheckFilterEventType(RibbonButton button, Models.TrackAnalysis.Events.TrackEvent.EventType type, List<Models.TrackAnalysis.Events.TrackEvent.EventType> types)
		{
			if (button.Checked)
			{
				types.Add(type);
			}
		}

		private void ClearMap()
		{
			analysisMap.Clear();
		}

		private void PopulateMapFeatures()
		{
            if (this.Task.TakeOffDeck != null)
            {
                analysisMap.AddFeature(this.Task.TakeOffDeck);
            }

            if (this.Task.LandingDeck != null)
            {
                analysisMap.AddFeature(this.Task.LandingDeck);
            }

            if (this.Task.StartPointOrGate != null)
			{
				analysisMap.AddFeature(this.Task.StartPointOrGate);
			}

			if (this.Task.FinishPointOrGate != null)
			{
				analysisMap.AddFeature(this.Task.FinishPointOrGate);
			}

			foreach (Models.Features.PointFeature turnpoint in this.Task.Turnpoints)
			{
				analysisMap.AddFeature(turnpoint);
			}

			foreach (Models.Features.GateFeature hiddenGate in this.Task.HiddenGates)
			{
				analysisMap.AddFeature(hiddenGate);
			}

            foreach (Models.Features.NoFlyZoneFeature nfz in this.Task.NoFlyZones)
            {
                analysisMap.AddFeature(nfz);
            }

            foreach (Models.Features.Feature feature in this.Task.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.Airfield)
				{
					analysisMap.AddFeature(feature);
				}
			}
		}

		private void ClearMapTrack()
		{
			analysisMap.RemoveTrack();
		}

		private void PopulateMapTrack(Geolocation.Tracks.Track track)
		{
			ClearMapTrack();

            if (track != null)
            {
                analysisMap.AddTrack(track);
            }

            analysisMap.AutoFit();
		}

		private void ShowMapEventLocation()
		{
			if (eventsDataGridView.SelectedRows.Count == 1)
			{
				Models.TrackAnalysis.Events.TrackEvent trackEvent = eventsDataGridView.CurrentRow.Tag as Models.TrackAnalysis.Events.TrackEvent;

				analysisMap.Pan(trackEvent.Location);
				analysisMap.ZoomFullyIn();
			}
		}

        private void PilotSelected()
        {
            Models.TrackAnalysis.Pilot pilot = pilotsDataGridView.SelectedRows[0].Tag as Models.TrackAnalysis.Pilot;

            if (pilot != null)
            {
                PopulateEvents(pilot.Events);

                if (pilot.Track == null)
                {
                    pilot.Track = Models.TrackAnalysis.TrackAnalyzer.LoadTrack(this.Task, pilot);
                }

                PopulateMapTrack(pilot.Track);

                ShowMapEventLocation();

                RefreshControlState();
            }
        }

		private bool ValidateMinAltitude(out int minAltitude)
		{
			minAltitude = 0;

			if (minAltitudeRibbonCheckBox.Checked)
			{
				if (!int.TryParse(minAltitudeRibbonTextBox.TextBoxText, out minAltitude))
				{
					MessageBox.Show("Please enter a valid minimum altitude", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}

			return true;
		}

		private TimeSpan CalculateTime(Models.TrackAnalysis.Events.TrackEvent event1, Models.TrackAnalysis.Events.TrackEvent event2)
		{
			if (event1.Time > event2.Time)
			{
				return event1.Time.Subtract(event2.Time);
			}
			else
			{
				return event2.Time.Subtract(event1.Time);
			}
		}

		private void ExportKml(string kmlFilePath, Models.TrackAnalysis.Pilot pilot, Models.TrackAnalysis.Events.TrackEvent.EventType[] eventTypesToInclude, bool includeTrackFixData, bool clampTrackToGround, bool includeFeatures, bool includeEvents)
		{
            List<Models.TrackAnalysis.Events.TrackEvent.EventType> eventTypesToIncludeList = new List<Models.TrackAnalysis.Events.TrackEvent.EventType>(eventTypesToInclude);

            List<Models.TrackAnalysis.Events.TrackEvent> eventsToInclude = new List<Models.TrackAnalysis.Events.TrackEvent>();

			// Only include the events that are currently displayed i.e. respect the current filtering
			foreach (Models.TrackAnalysis.Events.TrackEvent trackEvent in pilot.Events)
			{
				if (eventTypesToIncludeList.Contains(trackEvent.Type))
				{
					eventsToInclude.Add(trackEvent);
				}
			}

			Models.TrackAnalysis.GoogleEarth.GenerateTrackFile(kmlFilePath, this.Task, pilot.Track, eventsToInclude, includeTrackFixData, clampTrackToGround, includeFeatures, includeEvents);
		}

        private void CopyEventsColumnDataToClipboard(string separator)
        {
            System.Text.StringBuilder clipboardText = new System.Text.StringBuilder();

            foreach (DataGridViewRow row in eventsDataGridView.Rows)
            {
                if (clipboardText.Length != 0)
                {
                    clipboardText.Append(separator);
                }

                clipboardText.Append(row.Cells[(eventsHeaderContextMenuStrip.Tag as DataGridViewColumn).Index].Value.ToString());
            }

            try
            {
                Clipboard.SetText(clipboardText.ToString(), TextDataFormat.Text);
            }
            catch
            {
                MessageBox.Show("Unable to set the clipboard, please try again.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private static string CleanFilePath(string filePath)
        {
            List<char> filePathChars = new List<char>(filePath.ToCharArray());
            char[] invalidChars = System.IO.Path.GetInvalidPathChars();
            
            int i = 0;

            while (i < filePathChars.Count)
            {
                if (invalidChars.Contains(filePathChars[i]))
                {
                    filePathChars.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            return new string(filePathChars.ToArray());
        }

		private void RefreshControlState()
		{
			int selectedPilotsTracks = 0;

			if (pilotsDataGridView.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow pilotRow in pilotsDataGridView.SelectedRows)
				{
					Models.TrackAnalysis.Pilot pilot = pilotRow.Tag as Models.TrackAnalysis.Pilot;

					if (pilot.Track != null)
					{
                        selectedPilotsTracks++;
						break;
					}
				}
			}

			bool twoTimedRows = false;

			if (eventsDataGridView.SelectedRows.Count == 2)
			{
				Models.TrackAnalysis.Events.TrackEvent event1 = eventsDataGridView.SelectedRows[0].Tag as Models.TrackAnalysis.Events.TrackEvent;
				Models.TrackAnalysis.Events.TrackEvent event2 = eventsDataGridView.SelectedRows[1].Tag as Models.TrackAnalysis.Events.TrackEvent;

				if (event1.TimeSet && event2.TimeSet)
				{
					twoTimedRows = true;
				}
			}

            selectTrackRibbonButton.Enabled = pilotsDataGridView.SelectedRows.Count == 1;
            runAnalysisRibbonButton.Enabled = (selectedPilotsTracks > 0);

            removeEventRibbonButton.Enabled = (eventsDataGridView.SelectedRows.Count == 1);

			calculateDistanceRibbonButton.Enabled = (eventsDataGridView.SelectedRows.Count >= 2);
			calculateAreaRibbonButton.Enabled = false;
			calculateTimeRibbonButton.Enabled = twoTimedRows;
			calculateSpeedRibbonButton.Enabled = twoTimedRows;

			openKmlRibbonButton.Enabled = (pilotsDataGridView.SelectedRows.Count >= 1);
		}

		private void TrackAnalysisForm_Load(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

            this.Text += string.Format(" (Task {0} - {1})", this.Task.Number, this.Task.Name);

			minAltitudeRibbonComboBox.SelectedItem = minAltitudeUnitFeetRibbonLabel;

			PopulatePilots();

			PopulateMapFeatures();

            PilotSelected();

			this.Cursor = Cursors.Default;
		}

		private void filterButton_Click(object sender, EventArgs e)
		{
			if (pilotsDataGridView.SelectedRows.Count == 1)
			{
				Models.TrackAnalysis.Pilot pilot = pilotsDataGridView.SelectedRows[0].Tag as Models.TrackAnalysis.Pilot;

				PopulateEvents(pilot.Events);
			}
		}

		private void selectFeaturesRibbonButton_Click(object sender, EventArgs e)
		{
			using (Features.TaskFeaturesForm form = new Features.TaskFeaturesForm(this.Task))
			{
				form.ShowDialog();

				this.Task.Competition.Save();

				foreach (DataGridViewRow row in pilotsDataGridView.Rows)
				{
					Models.TrackAnalysis.Pilot pilot = row.Tag as Models.TrackAnalysis.Pilot;

					pilot.Events.Clear();
				}
				
				ClearEvents();
				ClearMap();
				PopulateMapFeatures();

				PilotSelected();
			}
		}

		private void runAnalysisRibbonButton_Click(object sender, EventArgs e)
		{
            if (this.Task.Competition.FlymasterIgcPath.Length > 0 && !this.Task.LandBySet)
            {
                MessageBox.Show("A 'Land by' date & time must be set in order to load Flymaster tracks", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Build a list of pilots we want to analyze

                List<Models.TrackAnalysis.Pilot> pilotsToAnalyze = new List<Models.TrackAnalysis.Pilot>();

                for (int i = 0; i < pilotsDataGridView.SelectedRows.Count; i++)
                {
                    pilotsToAnalyze.Add(pilotsDataGridView.SelectedRows[i].Tag as Models.TrackAnalysis.Pilot);
                }

                // Warn about pilots for whom we don't have a track

                List<Models.TrackAnalysis.Pilot> tracklessPilots = new List<Models.TrackAnalysis.Pilot>();

                foreach (Models.TrackAnalysis.Pilot pilot in pilotsToAnalyze)
                {
                    if (pilot.Track == null)
                    {
                        // Attempt to load track for this pilot
                        pilot.Track = Models.TrackAnalysis.TrackAnalyzer.LoadTrack(this.Task, pilot);

                        // If there's still no track then add to list of 'trackless' pilots

                        if (pilot.Track == null)
                        {
                            tracklessPilots.Add(pilot);
                        }
                    }
                }

                if (tracklessPilots.Count > 0)
                {
                    System.Text.StringBuilder tracklessPilotsMessage = new StringBuilder();

                    tracklessPilotsMessage.Append("No tracks were found for the following pilot(s)");
                    tracklessPilotsMessage.Append(Environment.NewLine);

                    foreach (Models.TrackAnalysis.Pilot tracklessPilot in tracklessPilots)
                    {
                        tracklessPilotsMessage.Append(Environment.NewLine);
                        tracklessPilotsMessage.Append(tracklessPilot.Name);
                        tracklessPilotsMessage.Append(" (");
                        tracklessPilotsMessage.Append(tracklessPilot.Number);
                        tracklessPilotsMessage.Append(")");

                        pilotsToAnalyze.Remove(tracklessPilot);
                    }

                    if (MessageBox.Show(tracklessPilotsMessage.ToString(), this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }
                }

                int minAltitude;

                if (ValidateMinAltitude(out minAltitude))
                {
                    if (minAltitudeRibbonCheckBox.Checked)
                    {
                        switch (minAltitudeRibbonComboBox.SelectedValue)
                        {
                            case "ft":
                                minAltitude = Geolocation.Convert.FeetToMeters(minAltitude);
                                break;
                        }
                    }

                    foreach (Models.TrackAnalysis.Pilot pilot in pilotsToAnalyze)
                    {
                        pilot.Events.Clear();
                    }

                    ClearEvents();

                    using (AnalysisProgressForm form = new AnalysisProgressForm(this.Task, pilotsToAnalyze.ToArray(), minAltitude))
                    {
                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK && pilotsToAnalyze.Count == 1)
                        {
                            if (pilotsToAnalyze[0].Events.Count > 0)
                            {
                                PopulateEvents(pilotsToAnalyze[0].Events);
                                ShowMapEventLocation();
                            }
                            else
                            {
                                MessageBox.Show("There are no events to display.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}

		private void calculateAreaRibbonButton_Click(object sender, EventArgs e)
		{
            throw new NotImplementedException();
		}

		private void calculateTimeRibbonButton_Click(object sender, EventArgs e)
		{
			Models.TrackAnalysis.Events.TrackEvent event1 = eventsDataGridView.SelectedRows[0].Tag as Models.TrackAnalysis.Events.TrackEvent;
			Models.TrackAnalysis.Events.TrackEvent event2 = eventsDataGridView.SelectedRows[1].Tag as Models.TrackAnalysis.Events.TrackEvent;

			TimeSpan time = CalculateTime(event1, event2);

			MessageBox.Show(string.Format("The time difference between the selected events is {0}.", time), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void calculateSpeedRibbonButton_Click(object sender, EventArgs e)
		{
            Models.TrackAnalysis.Events.TrackEvent event1 = eventsDataGridView.SelectedRows[0].Tag as Models.TrackAnalysis.Events.TrackEvent;
            Models.TrackAnalysis.Events.TrackEvent event2 = eventsDataGridView.SelectedRows[1].Tag as Models.TrackAnalysis.Events.TrackEvent;

            double distance = event1.Location.DistanceTo(event2.Location) / 1000;
            TimeSpan time = CalculateTime(event1, event2);

            double speed = distance / time.TotalHours;

            MessageBox.Show(string.Format("The speed (assuming a straight line is flown) between the selected locations is {0:0.00} km/h.", speed), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void minAltitudeRibbonCheckBox_CheckBoxCheckChanged(object sender, EventArgs e)
		{
			minAltitudeRibbonTextBox.Enabled = minAltitudeRibbonCheckBox.Checked;
			minAltitudeRibbonComboBox.Enabled = minAltitudeRibbonCheckBox.Checked;
		}

        private void openKmlRibbonButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Build a list of pilots we want to export

                List<Models.TrackAnalysis.Pilot> pilotsToExport = new List<Models.TrackAnalysis.Pilot>();

                for (int i = 0; i < pilotsDataGridView.SelectedRows.Count; i++)
                {
                    pilotsToExport.Add(pilotsDataGridView.SelectedRows[i].Tag as Models.TrackAnalysis.Pilot);
                }

                // Warn about pilots for whom we don't have a track

                List<Models.TrackAnalysis.Pilot> tracklessPilots = new List<Models.TrackAnalysis.Pilot>();

                foreach (Models.TrackAnalysis.Pilot pilot in pilotsToExport)
                {
                    if (pilot.Track == null)
                    {
                        // Attempt to load track for this pilot
                        pilot.Track = Models.TrackAnalysis.TrackAnalyzer.LoadTrack(this.Task, pilot);

                        // If there's still no track then add to list of 'trackless' pilots

                        if (pilot.Track == null)
                        {
                            tracklessPilots.Add(pilot);
                        }
                    }
                }

                if (tracklessPilots.Count > 0)
                {
                    System.Text.StringBuilder tracklessPilotsMessage = new StringBuilder();

                    tracklessPilotsMessage.Append("No tracks were found for the following pilot(s)");
                    tracklessPilotsMessage.Append(Environment.NewLine);

                    foreach (Models.TrackAnalysis.Pilot tracklessPilot in tracklessPilots)
                    {
                        tracklessPilotsMessage.Append(Environment.NewLine);
                        tracklessPilotsMessage.Append(tracklessPilot.Name);
                        tracklessPilotsMessage.Append(" (");
                        tracklessPilotsMessage.Append(tracklessPilot.Number);
                        tracklessPilotsMessage.Append(")");

                        pilotsToExport.Remove(tracklessPilot);
                    }

                    if (MessageBox.Show(tracklessPilotsMessage.ToString(), this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }
                }

                if (pilotsToExport.Count > 0)
                {
                    int featuresCount = 0;
                    if (this.Task.StartPointOrGate != null) featuresCount++;
                    if (this.Task.FinishPointOrGate != null) featuresCount++;
                    featuresCount += this.Task.Turnpoints.Count;
                    featuresCount += this.Task.HiddenGates.Count;
                    foreach (Models.Features.Feature feature in this.Task.Competition.Features)
                    {
                        if (feature.Type == Models.Features.Feature.FeatureType.NoFlyZone)
                        {
                            featuresCount++;
                        }
                    }

                    using (KmlOptionsForm form = new KmlOptionsForm((featuresCount > 0), true))
                    {
                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            if (pilotsToExport.Count == 1)
                            {
                                if (exportKmlFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    ExportKml(exportKmlFileDialog.FileName, pilotsToExport[0], m_filterEventTypes, form.IncludeTrackFixData, form.ClampTrackToGround, form.IncludeFeatures, form.IncludeEvents);

                                    if (MessageBox.Show("Export complete. Do you want to open the KML file in Google Earth now?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        Models.TrackAnalysis.GoogleEarth.OpenFile(exportKmlFileDialog.FileName);
                                    }
                                }
                            }
                            else
                            {
                                if (exportKmlFolderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    foreach (Models.TrackAnalysis.Pilot pilot in pilotsToExport)
                                    {
                                        string kmlFilePath = System.IO.Path.Combine(exportKmlFolderBrowserDialog.SelectedPath, string.Format("Task {0:00} - {1:000} - {2}.kml", this.Task.Number, pilot.Number, pilot.Name));

                                        ExportKml(CleanFilePath(kmlFilePath), pilot, m_filterEventTypes, form.IncludeTrackFixData, form.ClampTrackToGround, form.IncludeFeatures, form.IncludeEvents);
                                    }

                                    MessageBox.Show("Export complete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

		private void zoomInRibbonButton_Click(object sender, EventArgs e)
		{
			analysisMap.ZoomIn();
		}

		private void zoomOutRibbonButton_Click(object sender, EventArgs e)
		{
			analysisMap.ZoomOut();
		}

		private void pilotsDataGridView_SelectionChanged(object sender, EventArgs e)
		{
			if (pilotsDataGridView.SelectedRows.Count == 1)
			{
				this.Cursor = Cursors.WaitCursor;

				PilotSelected();

				this.Cursor = Cursors.Default;
			}
			else
			{
				ClearEvents();
				ClearMapTrack();

                RefreshControlState();
            }
		}

		private void eventsDataGridView_SelectionChanged(object sender, EventArgs e)
		{
			if (eventsDataGridView.SelectedRows.Count == 1 && eventsDataGridView.SelectedRows[0].Tag != null)
			{
				ShowMapEventLocation();
			}

			RefreshControlState();
		}

		private void analysisMap_Resize(object sender, EventArgs e)
		{
			ShowMapEventLocation();
		}

        private void distanceDirectRibbonButton_Click(object sender, EventArgs e)
        {
            //
        }

        private void distanceTrackRibbonButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void calculateDistanceRibbonButton_Click(object sender, EventArgs e)
        {
            // Measure the distance between the features of all selected events. This is more useful than measuring between arbitrary points

            for (int i = 0; i < eventsDataGridView.SelectedRows.Count; i++)
            {
                Models.TrackAnalysis.Events.TrackEvent selectedEvent = eventsDataGridView.SelectedRows[i].Tag as Models.TrackAnalysis.Events.TrackEvent;

                if (selectedEvent.RelatedFeature != null && selectedEvent.RelatedFeature.Type != Models.Features.Feature.FeatureType.Point && selectedEvent.RelatedFeature.Type != Models.Features.Feature.FeatureType.Gate)
                {
                    MessageBox.Show("Cannot measure distance between features that are not points or gates.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }

            //double totalDistance = 0;

            //for (int i = 1; i < eventsDataGridView.SelectedRows.Count; i++)
            //{
            //    Models.TrackAnalysis.Events.TrackEvent event1 = eventsDataGridView.SelectedRows[i - 1].Tag as Models.TrackAnalysis.Events.TrackEvent;
            //    Models.TrackAnalysis.Events.TrackEvent event2 = eventsDataGridView.SelectedRows[i].Tag as Models.TrackAnalysis.Events.TrackEvent;

            //    Geolocation.Location location1 = null;

            //    if (event1.RelatedFeature == null)
            //    {
            //        location1 = event1.Location;
            //    }
            //    else
            //    {
            //        switch (event1.RelatedFeature.Type)
            //        {
            //            case Models.Features.Feature.FeatureType.Gate:
            //                Models.Features.GateFeature gate = event1.RelatedFeature as Models.Features.GateFeature;
            //                location1 = (gate.Shape as Models.Features.Line).Center;
            //                break;
            //            case Models.Features.Feature.FeatureType.Point:
            //                Models.Features.PointFeature point = event1.RelatedFeature as Models.Features.PointFeature;
            //                location1 = (point.Shape as Models.Features.Circle).Center;
            //                break;
            //        }
            //    }

            //    Geolocation.Location location2 = null;

            //    if (event2.RelatedFeature == null)
            //    {
            //        location2 = event2.Location;
            //    }
            //    else
            //    {
            //        switch (event2.RelatedFeature.Type)
            //        {
            //            case Models.Features.Feature.FeatureType.Gate:
            //                Models.Features.GateFeature gate = event2.RelatedFeature as Models.Features.GateFeature;
            //                location2 = (gate.Shape as Models.Features.Line).Center;
            //                break;
            //            case Models.Features.Feature.FeatureType.Point:
            //                Models.Features.PointFeature point = event2.RelatedFeature as Models.Features.PointFeature;
            //                location2 = (point.Shape as Models.Features.Circle).Center;
            //                break;
            //        }
            //    }

            //    totalDistance += location1.DistanceTo(location2);
            //}

            //MessageBox.Show(string.Format("The distance (in a direct line) between the selected features is {0:0.00} km.", totalDistance / 1000), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


            // Build list of events we're interested in. Note that the list SelectedRows property returns rows in reverse order
            var selectedEvents = new List<Models.TrackAnalysis.Events.TrackEvent>();

            for (int i = eventsDataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                selectedEvents.Add(eventsDataGridView.SelectedRows[i].Tag as Models.TrackAnalysis.Events.TrackEvent);
            }

            using (var form = new CalculateDistanceForm(selectedEvents, (pilotsDataGridView.SelectedRows[0].Tag as Models.TrackAnalysis.Pilot).Track))
            {
                form.ShowDialog();
            }
        }

        private void removeEventRibbonButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = eventsDataGridView.SelectedRows[0];

            Models.TrackAnalysis.Events.TrackEvent eventToRemove = selectedRow.Tag as Models.TrackAnalysis.Events.TrackEvent;

            (pilotsDataGridView.SelectedRows[0].Tag as Models.TrackAnalysis.Pilot).Events.Remove(eventToRemove);
            eventsDataGridView.Rows.Remove(selectedRow);

            // Re-number events
            // This enables us to filter to only show one type of event, remove false positives manually and still easily see the number of events
            int counter = 1;
            foreach (DataGridViewRow row in eventsDataGridView.Rows)
            {
                row.Cells["NoColumn"].Value = counter++;
            }

            // Re-calculate elapsed time
            if (eventsDataGridView.Rows.Count > 0)
            {
                Models.TrackAnalysis.Events.TrackEvent firstEvent = eventsDataGridView.Rows[0].Tag as Models.TrackAnalysis.Events.TrackEvent;

                foreach (DataGridViewRow row in eventsDataGridView.Rows)
                {
                    Models.TrackAnalysis.Events.TrackEvent trackEvent = row.Tag as Models.TrackAnalysis.Events.TrackEvent;

                    row.Cells["TimeElapsedColumn"].Value = trackEvent.Time.Subtract(firstEvent.Time).ToString();
                }
            }
        }

        private void eventsDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                eventsHeaderContextMenuStrip.Tag = eventsDataGridView.Columns[e.ColumnIndex];
                eventsHeaderContextMenuStrip.Show(Cursor.Position);
            }
        }

        private void copyVerticallyMenuItem_Click(object sender, EventArgs e)
        {
            CopyEventsColumnDataToClipboard("\r\n");
        }

        private void copyHorizontallyMenuItem_Click(object sender, EventArgs e)
        {
            CopyEventsColumnDataToClipboard("\t");
        }

        private void eventsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.RowIndex != -1 && !(eventsDataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn))
                {
                    eventsCellContextMenuStrip.Tag = eventsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    eventsCellContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void copyCellValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((eventsCellContextMenuStrip.Tag as DataGridViewCell).Value.ToString(), TextDataFormat.Text);
        }

        private void filterEventsRibbonButton_Click(object sender, EventArgs e)
        {
            using (EventFilterForm form = new EventFilterForm(m_filterEventTypes))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    m_filterEventTypes = form.EventTypes;

                    if (pilotsDataGridView.SelectedRows.Count == 1)
                    {
                        Models.TrackAnalysis.Pilot pilot = pilotsDataGridView.SelectedRows[0].Tag as Models.TrackAnalysis.Pilot;

                        PopulateEvents(pilot.Events);
                    }
                }
            }
        }

		private void selectTrackRibbonButton_Click(object sender, EventArgs e)
		{
            Models.TrackAnalysis.Pilot pilot = pilotsDataGridView.SelectedRows[0].Tag as Models.TrackAnalysis.Pilot;

            using (PilotManualTracksForm form = new PilotManualTracksForm(pilot.Number, pilot.Name, this.Task))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    pilot.Events.Clear();
                    ClearEvents();

                    pilot.Track = Models.TrackAnalysis.TrackAnalyzer.LoadTrack(this.Task, pilot);

                    PopulateMapTrack(pilot.Track);

                    RefreshControlState();
                }
            }
		}
	}
}
