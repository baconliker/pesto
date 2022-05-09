using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis
{
	class TrackAnalyzer
	{
		public event EventHandler<AnalysisProgressEventArgs> ProgressChanged;

		private const int m_defaultGpsUpdateInterval = 1; // In seconds

		private List<Analyzers.IAnalyzer> m_analyzers = new List<Analyzers.IAnalyzer>();

		public TrackAnalyzer(Task task, Geolocation.Tracks.Track track, int minAltitude)
		{
			this.Task = task;
			this.Track = track;

			this.Events = new List<TrackAnalysis.Events.TrackEvent>();

			AddAnalyzer(new Analyzers.GpsCategoryAnalyzer(m_defaultGpsUpdateInterval));
			AddAnalyzer(new Analyzers.PointCategoryAnalyzer(this.Task));
			AddAnalyzer(new Analyzers.GateCategoryAnalyzer(this.Task));
			AddAnalyzer(new Analyzers.NoFlyZoneCategoryAnalyzer(this.Task.Competition));
			if (minAltitude != 0)
			{
				AddAnalyzer(new Analyzers.AltitudeCategoryAnalyzer(minAltitude));
			}
			AddAnalyzer(new Analyzers.TakeOffLandingCategoryAnalyzer(this.Task));
		}

		public static string[] GetPossibleTrackFiles(Models.Task task, int pilotNumber)
		{
			List<string> trackFiles = new List<string>();

            if (task.Competition.FrdlIgcPath.Length > 0 && System.IO.Directory.Exists(task.Competition.FrdlIgcPath))
            {
                System.IO.DirectoryInfo tracksFolder = new System.IO.DirectoryInfo(task.Competition.FrdlIgcPath);

                foreach (System.IO.FileInfo trackFile in tracksFolder.GetFiles("*.igc"))
                {
                    try
                    {
                        int filePilotNumber = int.Parse(trackFile.Name.Substring(0, 3));
                        int fileTaskNumber = int.Parse(trackFile.Name.Substring(4, 2));

                        if (filePilotNumber == pilotNumber && fileTaskNumber == task.Number)
                        {
                            trackFiles.Add(trackFile.FullName);
                        }
                    }
                    catch (FormatException) { }
                }
            }

			return trackFiles.ToArray();
		}

		public static Geolocation.Tracks.Track LoadTrack(string trackFilePath)
		{
			//BORIS
			//Geolocation.Tracks.Igc.IgcFileFormat fileFormat = new Geolocation.Tracks.Igc.IgcFileFormat();
			//Geolocation.Tracks.IDecoder decoder = fileFormat.GetDecoder();

			//using (System.IO.FileStream trackStream = System.IO.File.OpenRead(trackFilePath))
			//{
			//    return decoder.Decode(trackStream);
			//}

			Geolocation.Files.Igc igcFile = new Geolocation.Files.Igc(trackFilePath, true);
			return igcFile.Track;
		}

		public void RunAnalysis()
		{
			OnProgressChanged(new AnalysisProgressEventArgs(this.Track.Fixes.Count, 0));

			for (int i = 0; i < this.Track.Fixes.Count; i++)
			{
				foreach (Analyzers.IAnalyzer analyzer in m_analyzers)
				{
                    analyzer.AnalyzeFix(this.Track, i);
				}

				OnProgressChanged(new AnalysisProgressEventArgs(this.Track.Fixes.Count, i + 1));
			}

			this.Events.Sort(new Events.TrackEventComparer());
		}

		public Task Task { get; set; }
        public Geolocation.Tracks.Track Track { get; set; }

		public List<Events.TrackEvent> Events { get; private set; }

		protected void OnProgressChanged(AnalysisProgressEventArgs e)
		{
			if (ProgressChanged != null)
			{
				ProgressChanged(this, e);
			}
		}

		private void AddAnalyzer(Analyzers.IAnalyzer analyzer)
		{
			analyzer.EventOccurred += new EventHandler<Analyzers.EventOccurredEventArgs>(analyzer_EventOccurred);
			m_analyzers.Add(analyzer);
		}

        /// <summary>
        /// Returns whether the task is active or not. When there are start and finish points/gates defined for the task, 
        /// the task is considered active after the pilot has hit the start point/gate and before they hit the finish point/gate. 
        /// When start and finish points/gates are not defined all of the flight is active.
        /// </summary>
        /// <returns>Whether the task is currently active or not</returns>
        private bool IsTaskActive()
        {
            if (this.Task.StartPointOrGate != null)
            {
                bool startPointOrGateHit = false;

                foreach (TrackAnalysis.Events.TrackEvent trackEvent in this.Events)
                {
                    if (trackEvent.Type == TrackAnalysis.Events.TrackEvent.EventType.StartPointHit || trackEvent.Type == TrackAnalysis.Events.TrackEvent.EventType.StartGateHit)
                    {
                        startPointOrGateHit = true;
                    }
                }

                if (!startPointOrGateHit)
                {
                    return false;
                }
            }

            if (this.Task.FinishPointOrGate != null)
            {
                bool finishPointOrGateHit = false;

                foreach (TrackAnalysis.Events.TrackEvent trackEvent in this.Events)
                {
                    if (trackEvent.Type == TrackAnalysis.Events.TrackEvent.EventType.FinishPointHit || trackEvent.Type == TrackAnalysis.Events.TrackEvent.EventType.FinishGateHit)
                    {
                        finishPointOrGateHit = true;
                    }
                }

                if (finishPointOrGateHit)
                {
                    return false;
                }
            }

            return true;
        }

		private void analyzer_EventOccurred(object sender, Analyzers.EventOccurredEventArgs e)
		{
            bool addEvent = true;

            // Ensure that turnpoints and hidden gates cannot be hit before a start gate/point or after a finish gate/point
            if (e.TrackEvent.Type == TrackAnalysis.Events.TrackEvent.EventType.TurnpointHit || e.TrackEvent.Type == TrackAnalysis.Events.TrackEvent.EventType.DuplicateTurnpointHit || e.TrackEvent.Type == TrackAnalysis.Events.TrackEvent.EventType.HiddenGateHit || e.TrackEvent.Type == TrackAnalysis.Events.TrackEvent.EventType.DuplicateHiddenGateHit)
            {
                addEvent = IsTaskActive();
            }

            if (addEvent)
            {
                this.Events.Add(e.TrackEvent);
            }
		}
	}
}
