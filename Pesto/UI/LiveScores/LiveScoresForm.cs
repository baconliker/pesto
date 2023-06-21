using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.LiveScores
{
	internal partial class LiveScoresForm : Form
	{
		private const int m_maxPilotsInClassToDisplay = 10;

		private enum DisplayMode
		{
			All,
			AircraftClass
		}

		private string m_formTitle;

		private ConcurrentBag<Models.LiveScores.PilotLiveScore> m_liveScores = new ConcurrentBag<Models.LiveScores.PilotLiveScore>();

		private DisplayMode m_displayMode = DisplayMode.All;
		private int m_aircraftClassIndex = 0;
		private int m_pilotListIndex = 0;

		private Services.FlymasterApi m_flymasterApi = new Services.FlymasterApi();

		private System.IO.DirectoryInfo m_tracksFolder;

		private bool m_repopulateMapTracks = false;

		public LiveScoresForm(Models.Task task)
		{
			InitializeComponent();

			this.Task = task;

			foreach (Models.AircraftClass aircraftClass in task.AircraftClasses)
			{
				string pilotNumberColumnName = this.Task.Competition.PilotsSpreadsheet.GetMapping(Models.Column.ColumnType.PilotNumber).ColumnName;
				string pilotNameColumnName = this.Task.Competition.PilotsSpreadsheet.GetMapping(Models.Column.ColumnType.PilotName).ColumnName;
				Models.Spreadsheets.SpreadsheetColumnMapping loggerIdMapping = this.Task.Competition.PilotsSpreadsheet.GetMapping(Models.Column.ColumnType.LoggerId);

				using (DataTable pilotData = task.Competition.PilotsSpreadsheet.GetData(aircraftClass.Code))
				{
					foreach (DataRow pilotRow in pilotData.Rows)
					{
						m_liveScores.Add(new Models.LiveScores.PilotLiveScore((int)pilotRow[pilotNumberColumnName], (string)pilotRow[pilotNameColumnName], loggerIdMapping != null && pilotData.Columns.Contains(loggerIdMapping.ColumnName) ? (string)pilotRow[loggerIdMapping.ColumnName] : "", aircraftClass.Code));
					}
				}
			}

			// Create a temporary folder that will be used to download the tracks into for analysis
			m_tracksFolder = new System.IO.DirectoryInfo(System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString()));
			m_tracksFolder.Create();

			m_formTitle = $"{this.Text} (Task {this.Task.Number} - {this.Task.Name})";
		}

		public Models.Task Task { get; private set; }

		private async Task PopulateMapFeaturesAsync()
		{
			if (this.Task.TakeOffDeck != null)
			{
				await liveMap.AddFeatureAsync(this.Task.TakeOffDeck);
			}

			if (this.Task.LandingDeck != null)
			{
				await liveMap.AddFeatureAsync(this.Task.LandingDeck);
			}

			if (this.Task.StartPointOrGate != null)
			{
				await liveMap.AddFeatureAsync(this.Task.StartPointOrGate);
			}

			if (this.Task.FinishPointOrGate != null)
			{
				await liveMap.AddFeatureAsync(this.Task.FinishPointOrGate);
			}

			foreach (Models.Features.PointFeature turnpoint in this.Task.Turnpoints)
			{
				await liveMap.AddFeatureAsync(turnpoint);
			}

			foreach (Models.Features.GateFeature hiddenGate in this.Task.HiddenGates)
			{
				await liveMap.AddFeatureAsync(hiddenGate);
			}

			foreach (Models.Features.NoFlyZoneFeature nfz in this.Task.NoFlyZones)
			{
				await liveMap.AddFeatureAsync(nfz);
			}

			foreach (Models.Features.Feature feature in this.Task.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.Airfield)
				{
					await liveMap.AddFeatureAsync(feature);
				}
			}
		}

		private async Task ProcessTracksAsync()
		{
			Debug.WriteLine($"Start processing tracks at {DateTime.Now}");

			try
			{
				List<DateTime> downloadDates = GetDownloadDates(this.Task);

				if (downloadDates.Count > 0)
				{
					List<string> downloadedFiles = new List<string>();
					DateTime nowUtc = DateTime.UtcNow;

					foreach (DateTime downloadDate in downloadDates)
					{
						string destinationFilePath = System.IO.Path.Combine(m_tracksFolder.FullName, downloadDate.ToString("yyyy-MM-dd") + ".zip");

						if (downloadDate < nowUtc.Date)
						{
							if (!System.IO.File.Exists(destinationFilePath))
							{
								UpdateStatus($"Downloading Tracks for {downloadDate.ToShortDateString()} UTC...");

								await m_flymasterApi.DownloadTracks(this.Task.Competition.FlymasterApiGroupId, downloadDate, true, destinationFilePath);
								downloadedFiles.Add(destinationFilePath);
							}
						}
						else
						{
							UpdateStatus($"Downloading Tracks for {downloadDate.ToShortDateString()} UTC...");

							await m_flymasterApi.DownloadTracks(this.Task.Competition.FlymasterApiGroupId, downloadDate, true, destinationFilePath);
							downloadedFiles.Add(destinationFilePath);
						}
					}

					if (downloadedFiles.Count > 0)
					{
						UpdateStatus("Extracting Tracks...");

						Parallel.ForEach(downloadedFiles, filePath =>
						{
							ICSharpCode.SharpZipLib.Zip.FastZip zip = new ICSharpCode.SharpZipLib.Zip.FastZip();

							zip.ExtractZip(filePath, m_tracksFolder.FullName, @"-\.ics$");
						});

						UpdateStatus("Analysing Tracks...");

						Stopwatch overallTimer = new Stopwatch();
						overallTimer.Start();

						Parallel.ForEach(m_liveScores, liveScore =>
						{
							Stopwatch timer = new Stopwatch();

							timer.Start();
							Geolocation.Tracks.Track pilotTrack = Models.TrackAnalysis.TrackAnalyzer.LoadFlymasterTrack(this.Task, liveScore.LoggerId, m_tracksFolder);
							timer.Stop();
							Debug.WriteLine($"Loaded/merged tracks for pilot {liveScore.PilotNumber} - {liveScore.PilotName} in {timer.Elapsed}");

							if (pilotTrack != null)
							{
								timer.Restart();
								Models.TrackAnalysis.TrackAnalyzer analyzer = new Models.TrackAnalysis.TrackAnalyzer(this.Task, pilotTrack, 0);
								analyzer.RunAnalysis();
								timer.Stop();
								Debug.WriteLine($"Analysed tracks for pilot {liveScore.PilotNumber} - {liveScore.PilotName} in {timer.Elapsed}");

								liveScore.TurnpointsHit = analyzer.Events.Where(evnt => evnt.Type == Models.TrackAnalysis.Events.TrackEvent.EventType.TurnpointHit).Count();

								Services.TrackSimplifier trackSimplifier = new Services.TrackSimplifier(pilotTrack);
								liveScore.Track = trackSimplifier.Simplify(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(30));
							}
						});

						overallTimer.Stop();
						Debug.WriteLine($"All done in {overallTimer.Elapsed}");

						// Signal that the tracks on the map should be re-populated the next time the display is refreshed
						m_repopulateMapTracks = true;
					}
				}

				UpdateStatus($"Last Updated {DateTime.Now.ToShortTimeString()}");
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);

				UpdateStatus("Unable To Process Tracks");
			}

			Debug.WriteLine($"Finish processing tracks at {DateTime.Now}");
		}

		private async Task RefreshDisplayAsync()
		{
			if (m_displayMode == DisplayMode.AircraftClass)
			{
				aircraftClassLabel.Text = this.Task.AircraftClasses[m_aircraftClassIndex].Code;
			}
			else
			{
				aircraftClassLabel.Text = "All Pilots";
			}

			if (m_displayMode == DisplayMode.All || m_pilotListIndex == 0)
			{
				PopulateLiveScores();
			}
			else
			{
				scoresDataGridView.Rows[m_pilotListIndex].Selected = true;
				// Ensure that the selected row is visible (scrolls if necessary)
				scoresDataGridView.CurrentCell = scoresDataGridView.Rows[m_pilotListIndex].Cells[0];
			}

			await PopulatePilotTracksAsync();

			switch (m_displayMode)
			{
				case DisplayMode.All:
					m_displayMode = DisplayMode.AircraftClass;
					break;

				case DisplayMode.AircraftClass:
					int maxPilotsInClassToDisplay = Math.Min(m_maxPilotsInClassToDisplay, scoresDataGridView.Rows.Count);

					Models.LiveScores.PilotLiveScore thisLiveScore = (Models.LiveScores.PilotLiveScore)scoresDataGridView.Rows[m_pilotListIndex].Tag;
					Models.LiveScores.PilotLiveScore nextLiveScore = m_pilotListIndex < scoresDataGridView.Rows.Count - 1 ? (Models.LiveScores.PilotLiveScore)scoresDataGridView.Rows[m_pilotListIndex + 1].Tag : null;

					if (m_pilotListIndex < maxPilotsInClassToDisplay - 1 || (nextLiveScore != null && nextLiveScore.TurnpointsHit == thisLiveScore.TurnpointsHit))
					{
						m_pilotListIndex++;
					}
					else if (m_aircraftClassIndex < this.Task.AircraftClasses.Count - 1)
					{
						m_aircraftClassIndex++;
						m_pilotListIndex = 0;
					}
					else
					{
						m_displayMode = DisplayMode.All;
						m_aircraftClassIndex = 0;
						m_pilotListIndex = 0;
					}
					break;
			}
		}

		private async Task PopulatePilotTracksAsync()
		{
			if (m_repopulateMapTracks)
			{
				await liveMap.ClearTracksAsync();

				foreach (Models.LiveScores.PilotLiveScore liveScore in m_liveScores)
				{
					if (liveScore.Track != null && liveScore.Track.Fixes.Count > 0)
					{
						await liveMap.AddTrackAsync(liveScore.Track, liveScore.PilotNumber);
					}
				}

				m_repopulateMapTracks = false;
			}

			if (m_displayMode == DisplayMode.AircraftClass)
			{
				Models.LiveScores.PilotLiveScore liveScore = (Models.LiveScores.PilotLiveScore)scoresDataGridView.Rows[m_pilotListIndex].Tag;

				if (liveScore.Track != null && liveScore.Track.Fixes.Count > 0)
				{
					await liveMap.SetCenterAsync(liveScore.Track.Fixes[liveScore.Track.Fixes.Count - 1]);
					await liveMap.ZoomFullyInAsync();
				}
				else
				{
					await liveMap.AutoFitTracksAsync();
				}
			}
			else
			{
				await liveMap.AutoFitTracksAsync();
			}
		}

		private void PopulateLiveScores()
		{
			scoresDataGridView.Rows.Clear();

			if (m_displayMode == DisplayMode.AircraftClass)
			{
				foreach (Models.LiveScores.PilotLiveScore liveScore in m_liveScores.Where(score => string.Equals(score.AircraftClassCode, this.Task.AircraftClasses[m_aircraftClassIndex].Code, StringComparison.OrdinalIgnoreCase)).OrderByDescending(score => score.TurnpointsHit).ThenBy(score => score.PilotName))
				{
					AddLiveScoreRow(liveScore);
				}
			}
			else
			{
				foreach (Models.LiveScores.PilotLiveScore liveScore in m_liveScores.OrderByDescending(score => score.TurnpointsHit).ThenBy(score => score.PilotName))
				{
					AddLiveScoreRow(liveScore);
				}

				scoresDataGridView.ClearSelection();
			}
		}

		private static List<DateTime> GetDownloadDates(Models.Task task)
		{
			List<DateTime> downloadDates = new List<DateTime>();

			// Tracks are downloaded a day at a time and are in the form of a zip file containing igc files for each tracker
			// Note: the date specified when downloading is in UTC so we should attempt to download tracks starting the day before the task starts to cater for time zones in the east where tasks could potentially start before 00:00 UTC

			DateTime taskStartUtc = TimeZoneInfo.ConvertTimeToUtc(task.LaunchOpen, task.Competition.TimeZone);
			DateTime taskFinishUtc = TimeZoneInfo.ConvertTimeToUtc(task.LandBy, task.Competition.TimeZone);

			DateTime dateUtc = taskStartUtc.Date;

			while (dateUtc <= taskFinishUtc.Date && dateUtc <= DateTime.UtcNow.Date)
			{
				downloadDates.Add(dateUtc);
				dateUtc = dateUtc.AddDays(1);
			}

			return downloadDates;
		}

		private void AddLiveScoreRow(Models.LiveScores.PilotLiveScore liveScore)
		{
			object[] row = new object[3];

			row[0] = liveScore.PilotNumber;
			row[1] = liveScore.PilotName;
			row[2] = liveScore.TurnpointsHit;

			int rowIndex = scoresDataGridView.Rows.Add(row);

			scoresDataGridView.Rows[rowIndex].Tag = liveScore;
		}

		private void UpdateStatus(string statusText)
		{
			if (string.IsNullOrEmpty(statusText))
			{
				this.Text = m_formTitle;
			}
			else
			{
				this.Text = $"{m_formTitle} - {statusText}";
			}
		}

		private async void LiveScoresForm_Load(object sender, EventArgs e)
		{
			UpdateStatus(string.Empty);

			await PopulateMapFeaturesAsync();
		}

		private void LiveScoresForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				m_tracksFolder.Delete(true);
			}
			catch
			{
			}
		}

		private async void liveMap_MapInitialized(object sender, EventArgs e)
		{
			switch (await m_flymasterApi.Login(this.Task.Competition.FlymasterApiUsername, this.Task.Competition.FlymasterApiPassword))
			{
				case Services.FlymasterApi.LoginResult.Success:
					await ProcessTracksAsync();
					await RefreshDisplayAsync();

					loadTracksTimer.Enabled = true;
					displayUpdateTimer.Enabled = true;

					break;

				case Services.FlymasterApi.LoginResult.InvalidUsernamePassword:
					MessageBox.Show("Unable to login to Flymaster, please check username / password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;

				case Services.FlymasterApi.LoginResult.NetworkError:
					MessageBox.Show("Unable to connect to Flymaster, please check your internet connection", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					break;
			}
		}

		private async void displayUpdateTimer_Tick(object sender, EventArgs e)
		{
			await RefreshDisplayAsync();
		}

		private async void loadTracksTimer_Tick(object sender, EventArgs e)
		{
			await ProcessTracksAsync();
		}
	}
}
