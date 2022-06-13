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

		public static Geolocation.Tracks.Track LoadTrack(Models.Task task, Models.TrackAnalysis.Pilot pilot)
		{
            //BORIS
            //Geolocation.Tracks.Igc.IgcFileFormat fileFormat = new Geolocation.Tracks.Igc.IgcFileFormat();
            //Geolocation.Tracks.IDecoder decoder = fileFormat.GetDecoder();

            //using (System.IO.FileStream trackStream = System.IO.File.OpenRead(trackFilePath))
            //{
            //    return decoder.Decode(trackStream);
            //}

            Geolocation.Tracks.Track loadedTrack = null;

            // Attempt to load a track for this pilot in the following priority order:
            // 1) Manual
            // 2) Flymaster
            // 3) FRDL / AMOD

            if (task.ManualTracks.Where(t => t.PilotNumber == pilot.Number).Count() > 0)
            {
                loadedTrack = LoadManualTrack(task, pilot);
            }
            
            if (loadedTrack == null && task.Competition.FlymasterIgcPath.Length > 0)
            {
                loadedTrack = LoadFlymasterTrack(task, pilot);
            }
            
            if (loadedTrack == null && task.Competition.FrdlIgcPath.Length > 0)
            {
                loadedTrack = LoadFrdlTrack(task, pilot);
            }

            if (loadedTrack != null)
            {
                loadedTrack.Name = string.Format("Task {0} - {1}", task.Number, pilot.Name);
            }

            return loadedTrack;
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
        /// Returns the last manual track for the given pilot that contains valid data
        /// </summary>
        /// <param name="task">The task that the track must relate to</param>
        /// <param name="pilot">The pilot that the track must relate to</param>
        /// <returns>A track</returns>
        private static Geolocation.Tracks.Track LoadManualTrack(Models.Task task, Models.TrackAnalysis.Pilot pilot)
        {
            foreach (ManualTrack manualTrack in task.ManualTracks.Where(t => t.PilotNumber == pilot.Number).Reverse<ManualTrack>())
            {
                if (System.IO.File.Exists(manualTrack.TrackFilePath))
                {
                    Geolocation.Files.Igc igcFile = new Geolocation.Files.Igc(manualTrack.TrackFilePath, true);

                    if (igcFile.Track.Fixes.Count > 0)
                    {
                        return igcFile.Track;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a track that is potentially a combination of fixes from multiple files based on the task launch open and land by times
        /// </summary>
        /// <param name="task">The task that the track must relate to</param>
        /// <param name="pilot">The pilot that the track must relate to</param>
        /// <returns>A track</returns>
        private static Geolocation.Tracks.Track LoadFlymasterTrack(Models.Task task, Models.TrackAnalysis.Pilot pilot)
        {
            // For Flymaster track files we don't have the task number in the filename (unlike AMOD) so we need to examine all the track files for the this pilot and use just the fixes that fall within the task start/end
            // Note: Each file represents a 'day' but that 'day' is based on UTC so for timezones that have a large offset from UTC our task cold be split across multiple files
            // Note: the date and time in the filename is in UTC
            // We can narrow down the files to process by ignoring those that are dated more than 12 hours before task start and more than 12 hours after task end as they can't possibly contain data for our task
            // Include fixes 15 minutes before task start and 15 minutes after task end

            Geolocation.Tracks.Track compositeTrack = null;

            System.IO.DirectoryInfo tracksFolder = new System.IO.DirectoryInfo(task.Competition.FlymasterIgcPath);

            if (tracksFolder.Exists && task.LandBySet && pilot.LoggerId.Length > 0)
            {
                // Use the competition time zone to resolve the task start and finish
                DateTimeOffset taskStart = new DateTimeOffset(task.LaunchOpen, task.Competition.TimeZone.GetUtcOffset(task.LaunchOpen));
                DateTimeOffset taskFinish = new DateTimeOffset(task.LandBy, task.Competition.TimeZone.GetUtcOffset(task.LandBy));

                DateTimeOffset fileDateFrom = taskStart.AddHours(-12);
                DateTimeOffset fileDateTo = taskFinish.AddHours(12);

                DateTimeOffset fixFrom = taskStart.AddMinutes(-15);
                DateTimeOffset fixTo = taskFinish.AddMinutes(15);

                foreach (System.IO.FileInfo trackFile in tracksFolder.GetFiles("*.igc").OrderBy(f => f.FullName))
                {
                    // File names should be in the following format:
                    // LiveTrack Joe BLOGGS.131988.20210709-055436.[CIVLID].421.igc
                    // We want the 'logger number' which is 421 in this example

                    string[] fileNameParts = trackFile.Name.Split('.');

                    if (fileNameParts.Length == 6 && string.Equals(fileNameParts[fileNameParts.Length - 2], pilot.LoggerId, StringComparison.OrdinalIgnoreCase))
                    {
                        if (DateTimeOffset.TryParseExact(fileNameParts[2], "yyyyMMdd-HHmmss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal, out DateTimeOffset firstFixDate))
                        {
                            if (firstFixDate >= fileDateFrom && firstFixDate <= fileDateTo)
                            {
                                if (compositeTrack == null)
                                {
                                    compositeTrack = new Geolocation.Tracks.Track();
                                }

                                Geolocation.Files.Igc igcFile = new Geolocation.Files.Igc(trackFile.FullName, true);
                                
                                if (igcFile.Track.Fixes.Count > 0)
                                {
                                    // Check that this file follows on from previous ones
                                    if (compositeTrack.Fixes.Count == 0 || igcFile.Track.Fixes[0].Time > compositeTrack.Fixes[compositeTrack.Fixes.Count - 1].Time)
                                    {
                                        foreach (Geolocation.Tracks.Fix fix in igcFile.Track.Fixes)
                                        {
                                            if (fix.Time >= fixFrom && fix.Time <= fixTo)
                                            {
                                                compositeTrack.Fixes.Add(fix);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return compositeTrack != null && compositeTrack.Fixes.Count > 0 ? compositeTrack : null;
        }

        /// <summary>
        /// Returns the track from the file matching the task and pilot number
        /// </summary>
        /// <param name="task">The task that the track must relate to</param>
        /// <param name="pilot">The pilot that the track must relate to</param>
        /// <returns>A track</returns>
        private static Geolocation.Tracks.Track LoadFrdlTrack(Models.Task task, Models.TrackAnalysis.Pilot pilot)
        {
            System.IO.DirectoryInfo tracksFolder = new System.IO.DirectoryInfo(task.Competition.FrdlIgcPath);

            if (tracksFolder.Exists)
            {
                foreach (System.IO.FileInfo trackFile in tracksFolder.GetFiles("*.igc").OrderByDescending(f => f.FullName))
                {
                    try
                    {
                        int filePilotNumber = int.Parse(trackFile.Name.Substring(0, 3));
                        int fileTaskNumber = int.Parse(trackFile.Name.Substring(4, 2));

                        if (filePilotNumber == pilot.Number && fileTaskNumber == task.Number)
                        {
                            Geolocation.Files.Igc igcFile = new Geolocation.Files.Igc(trackFile.FullName, true);

                            if (igcFile.Track.Fixes.Count > 0)
                            {
                                return igcFile.Track;
                            }
                        }
                    }
                    catch (FormatException) { }
                }
            }

            return null;
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
