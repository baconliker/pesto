using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ColinBaker.Pesto.Services
{
    class CompetitionRepository
    {
        private const decimal m_currentFileVersion = 1.8M;
		private const int m_maxRecentCompetitions = 5;

        public CompetitionRepository(string filePath)
        {
            this.FilePath = filePath;
        }

		public static string[] GetRecentCompetitions()
		{
            SettingsStore store = new SettingsStore();

            return store.RecentCompetitionPaths;
		}

		public void UpdateRecentCompetitions()
		{
			List<string> recentCompetitions = new List<string>(GetRecentCompetitions());

			// Remove this competition if it already exists in the list
			if (recentCompetitions.Count > 0)
			{
				int i = 0;

				while (i < recentCompetitions.Count)
				{
					if (string.Compare(recentCompetitions[i], this.FilePath, true) == 0)
					{
						recentCompetitions.RemoveAt(i);
					}
					else
					{
						i++;
					}
				}
			}
			
			// Add this competition to the beginning of the list
			recentCompetitions.Insert(0, this.FilePath);
			
			// Make sure there aren't too many item in the list
			if (recentCompetitions.Count > m_maxRecentCompetitions)
			{
                recentCompetitions.RemoveRange(m_maxRecentCompetitions, recentCompetitions.Count - m_maxRecentCompetitions);
			}

            SettingsStore store = new SettingsStore();

            store.RecentCompetitionPaths = recentCompetitions.ToArray();
		}

        public Models.Competition LoadCompetition()
        {
            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);

            decimal fileVersion = ParseDecimal(document.SelectSingleNode("/Boris/@Version").InnerText);

            if (fileVersion > m_currentFileVersion)
            {
                throw new NewerCompetitionFileException();
            }

            XmlNode competitionNode = document.SelectSingleNode("/Boris/Competition");

            Models.Competition competition = new Models.Competition(this);

            competition.Name = competitionNode.SelectSingleNode("Name").InnerText;

            XmlNode logoImagePathNode = competitionNode.SelectSingleNode("LogoImagePath");
            if (logoImagePathNode != null)
            {
                competition.LogoImagePath = logoImagePathNode.InnerText;
			}

            // TODO: Check parsing of date is correct, see geo conversion code in ParaComp
            competition.Start = DateTime.Parse(competitionNode.SelectSingleNode("Start").InnerText, System.Globalization.CultureInfo.InvariantCulture);
            // TODO: Check parsing of date is correct, see geo conversion code in ParaComp
            competition.Finish = DateTime.Parse(competitionNode.SelectSingleNode("Finish").InnerText, System.Globalization.CultureInfo.InvariantCulture).AddDays(1).AddSeconds(-1);

            XmlNode timeZoneNode = competitionNode.SelectSingleNode("TimeZone");
            if (timeZoneNode != null)
            {
                competition.TimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneNode.InnerText);
            }
            else
            {
                competition.TimeZone = TimeZoneInfo.Local;
            }

			XmlNode aircraftClassesNode = competitionNode.SelectSingleNode("AircraftClasses");
			if (aircraftClassesNode != null)
			{
				foreach (XmlNode codeNode in competitionNode.SelectNodes("AircraftClasses/Code"))
				{
					foreach (Models.AircraftClass aircraftClass in Models.AircraftClass.GetAllClasses())
					{
						if (string.Compare(aircraftClass.Code, codeNode.InnerText, true) == 0)
						{
							competition.AircraftClasses.Add(aircraftClass);
							break;
						}
					}
				}
			}
			else
			{
				competition.AircraftClasses = new List<Models.AircraftClass>(Models.AircraftClass.GetBackwardCompatibleClasses());
			}

            foreach (Models.AircraftClass aircraftClass in competition.AircraftClasses)
            {
                competition.OverallResults.Add(new Models.Results.OverallResults(competition, aircraftClass));
                competition.TeamResults.Add(new Models.Results.TeamResults(competition, aircraftClass));
            }

            XmlNode nationDefinitionsNode = competitionNode.SelectSingleNode("NationDefinitions");
            if (nationDefinitionsNode != null)
            {
                foreach (XmlNode nationDefinitionNode in nationDefinitionsNode.SelectNodes("NationDefinition"))
                {
                    string aircraftClassCode = nationDefinitionNode.SelectSingleNode("AircraftClassCode").InnerText;

                    foreach (Models.AircraftClass aircraftClass in competition.AircraftClasses)
                    {
                        if (aircraftClass.Code == aircraftClassCode)
                        {
                            competition.NationDefinitions.Add(new Models.NationDefinition(aircraftClass, int.Parse(nationDefinitionNode.SelectSingleNode("NumberWhoScore").InnerText, System.Globalization.CultureInfo.InvariantCulture)));
                            break;
                        }
                    }
                }
            }

            XmlNode backupPathNode = competitionNode.SelectSingleNode("BackupPath");
            if (backupPathNode != null)
            {
                competition.BackupPath = backupPathNode.InnerText;
            }

            XmlNode frdlIgcPathNode = competitionNode.SelectSingleNode("FrdlIgcPath");
            if (frdlIgcPathNode != null)
            {
                competition.FrdlIgcPath = frdlIgcPathNode.InnerText;
            }

            XmlNode flymasterIgcPathNode = competitionNode.SelectSingleNode("FlymasterIgcPath");
            if (flymasterIgcPathNode != null)
            {
                competition.FlymasterIgcPath = flymasterIgcPathNode.InnerText;
            }

            XmlNode flymasterApiNode;
            
            flymasterApiNode = competitionNode.SelectSingleNode("FlymasterApiUsername");
            if (flymasterApiNode != null)
            {
                competition.FlymasterApiUsername = flymasterApiNode.InnerText;
            }
            flymasterApiNode = competitionNode.SelectSingleNode("FlymasterApiPassword");
            if (flymasterApiNode != null)
            {
                competition.FlymasterApiPassword = flymasterApiNode.InnerText;
            }
            flymasterApiNode = competitionNode.SelectSingleNode("FlymasterApiGroupId");
            if (flymasterApiNode != null)
            {
                competition.FlymasterApiGroupId = flymasterApiNode.InnerText;
            }

            XmlNode defaultTurnpointRadiusNode = competitionNode.SelectSingleNode("DefaultPointRadius");
            if (defaultTurnpointRadiusNode != null)
            {
                competition.DefaultPointRadius = int.Parse(defaultTurnpointRadiusNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
            }

			XmlNode defaultGateWidthNode = competitionNode.SelectSingleNode("DefaultGateWidth");
			if (defaultGateWidthNode != null)
			{
				competition.DefaultGateWidth = int.Parse(defaultGateWidthNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
			}

			competition.PilotsSpreadsheet.Mappings.Clear();

            foreach (XmlNode columnMappingNode in competitionNode.SelectNodes("PilotSpreadsheetMappings/ColumnMapping"))
            {
                Models.Spreadsheets.SpreadsheetColumnMapping mapping = new Models.Spreadsheets.SpreadsheetColumnMapping();

                switch (columnMappingNode.SelectSingleNode("ColumnType").InnerText)
                {
                    case "N":
                        mapping.ColumnType = Models.Column.ColumnType.PilotNumber;
                        break;
                    case "P":
                        mapping.ColumnType = Models.Column.ColumnType.PilotName;
                        break;
                    case "T":
                        mapping.ColumnType = Models.Column.ColumnType.TeamName;
                        break;
                    case "C":
                        mapping.ColumnType = Models.Column.ColumnType.Country;
                        break;
                    case "M":
                        mapping.ColumnType = Models.Column.ColumnType.Motor;
                        break;
                    case "W":
                        mapping.ColumnType = Models.Column.ColumnType.Wing;
                        break;
                    case "L":
                        mapping.ColumnType = Models.Column.ColumnType.LoggerId;
                        break;
                }
                if (string.Compare(columnMappingNode.SelectSingleNode("Required").InnerText, "Y", true) == 0)
                {
                    mapping.Required = true;
                }
                else
                {
                    mapping.Required = false;
                }
                mapping.ColumnName = columnMappingNode.SelectSingleNode("ColumnName").InnerText;

                competition.PilotsSpreadsheet.Mappings.Add(mapping);
            }

			foreach (XmlNode featureNode in competitionNode.SelectNodes("Features/*"))
			{
				competition.Features.Add(ExtractCompetitionFeature(featureNode));
			}

            foreach (XmlNode taskNode in competitionNode.SelectNodes("Tasks/Task"))
            {
                Models.Task task = new Models.Task(competition);
                competition.Tasks.Add(task);

                task.Number = int.Parse(taskNode.SelectSingleNode("Number").InnerText, System.Globalization.CultureInfo.InvariantCulture);
                task.Name = taskNode.SelectSingleNode("Name").InnerText;

                XmlNode abbreviatedNameNode = taskNode.SelectSingleNode("AbbreviatedName");
                if (abbreviatedNameNode == null)
                {
                    task.AbbreviatedName = string.Empty;
                }
                else
                {
                    task.AbbreviatedName = abbreviatedNameNode.InnerText;
                }
                
                switch (taskNode.SelectSingleNode("Type").InnerText)
                {
                    case "E":
                        task.Type = Models.Task.TaskType.Economy;
                        break;
                    case "N":
                        task.Type = Models.Task.TaskType.Navigation;
                        break;
                    case "P":
                        task.Type = Models.Task.TaskType.Precision;
                        break;
                }

                aircraftClassesNode = taskNode.SelectSingleNode("AircraftClasses");
                if (aircraftClassesNode != null)
                {
                    foreach (XmlNode codeNode in aircraftClassesNode.SelectNodes("Code"))
                    {
                        foreach (Models.AircraftClass aircraftClass in competition.AircraftClasses)
                        {
                            if (string.Compare(aircraftClass.Code, codeNode.InnerText, true) == 0)
                            {
                                task.AircraftClasses.Add(aircraftClass);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // For backward compatibility
                    foreach (Models.AircraftClass aircraftClass in competition.AircraftClasses)
                    {
                        task.AircraftClasses.Add(aircraftClass);
                    }
                }

                foreach (Models.AircraftClass aircraftClass in task.AircraftClasses)
                {
                    task.Results.Add(new Models.Results.TaskResults(task, aircraftClass));
                }

                XmlNode launchOpenNode = taskNode.SelectSingleNode("LaunchOpen");
				if (launchOpenNode == null)
				{
					// Backward compatibility with old competition files that only contain start date

					// TODO: Check parsing of date is correct, see geo conversion code in ParaComp
					task.LaunchOpen = DateTime.Parse(taskNode.SelectSingleNode("Start").InnerText, System.Globalization.CultureInfo.InvariantCulture);
				}
				else
				{
					// TODO: Check parsing of date is correct, see geo conversion code in ParaComp
					task.LaunchOpen = DateTime.Parse(launchOpenNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);

					XmlNode launchCloseNode = taskNode.SelectSingleNode("LaunchClose");
					if (launchCloseNode != null)
					{
						// TODO: Check parsing of date is correct, see geo conversion code in ParaComp
						task.LaunchClose = DateTime.Parse(launchCloseNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
					}

					XmlNode landByNode = taskNode.SelectSingleNode("LandBy");
					if (landByNode != null)
					{
						// TODO: Check parsing of date is correct, see geo conversion code in ParaComp
						task.LandBy = DateTime.Parse(landByNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
					}
				}

                task.ScoringSpreadsheet.Mappings.Clear();

                foreach (XmlNode columnMappingNode in taskNode.SelectNodes("SpreadsheetMappings/ColumnMapping"))
                {
                    Models.Spreadsheets.SpreadsheetColumnMapping mapping = new Models.Spreadsheets.SpreadsheetColumnMapping();

                    switch (columnMappingNode.SelectSingleNode("ColumnType").InnerText)
                    {
                        case "N":
                            mapping.ColumnType = Models.Column.ColumnType.PilotNumber;
                            break;
                        case "S":
                            mapping.ColumnType = Models.Column.ColumnType.Score;
                            break;
                    }
                    if (string.Compare(columnMappingNode.SelectSingleNode("Required").InnerText, "Y", true) == 0)
                    {
                        mapping.Required = true;
                    }
                    else
                    {
                        mapping.Required = false;
                    }
                    mapping.ColumnName = columnMappingNode.SelectSingleNode("ColumnName").InnerText;

                    task.ScoringSpreadsheet.Mappings.Add(mapping);
                }

                XmlNode takeOffDeckNode = taskNode.SelectSingleNode("TakeOffDeck");
                if (takeOffDeckNode != null)
                {
                    task.TakeOffDeck = ExtractTaskFeature(takeOffDeckNode.FirstChild, competition) as Models.Features.DeckFeature;
                }

                XmlNode landingDeckNode = taskNode.SelectSingleNode("LandingDeck");
                if (landingDeckNode != null)
                {
                    task.LandingDeck = ExtractTaskFeature(landingDeckNode.FirstChild, competition) as Models.Features.DeckFeature;
                }

                XmlNode startPointOrGateNode = taskNode.SelectSingleNode("StartPointOrGate");
				if (startPointOrGateNode != null)
				{
					task.StartPointOrGate = ExtractTaskFeature(startPointOrGateNode.FirstChild, competition);
				}

				XmlNode finishPointOrGateNode = taskNode.SelectSingleNode("FinishPointOrGate");
				if (finishPointOrGateNode != null)
				{
					task.FinishPointOrGate = ExtractTaskFeature(finishPointOrGateNode.FirstChild, competition);
				}

				foreach (XmlNode turnpointNode in taskNode.SelectNodes("Turnpoints/Point"))
				{
					task.Turnpoints.Add(ExtractTaskFeature(turnpointNode, competition) as Models.Features.PointFeature);
				}

				foreach (XmlNode hiddenGateNode in taskNode.SelectNodes("HiddenGates/Gate"))
				{
					task.HiddenGates.Add(ExtractTaskFeature(hiddenGateNode, competition) as Models.Features.GateFeature);
				}

                foreach (XmlNode noFlyZoneNode in taskNode.SelectNodes("NoFlyZones/NoFlyZone"))
                {
                    task.NoFlyZones.Add(ExtractCompetitionFeature(noFlyZoneNode) as Models.Features.NoFlyZoneFeature);
                }

                // For backward compatibility
                if (task.NoFlyZones.Count == 0)
                {
                    // Copy no fly zones from competition to task
                    foreach (Models.Features.Feature feature in competition.Features)
                    {
                        if (feature.Type == Models.Features.Feature.FeatureType.NoFlyZone)
                        {
                            task.NoFlyZones.Add((feature as Models.Features.NoFlyZoneFeature).Clone(feature.Name));
                        }
                    }
                }

                foreach (XmlNode manualTrackNode in taskNode.SelectNodes("ManualTracks/ManualTrack"))
                {
                    task.ManualTracks.Add(new Models.ManualTrack()
                    {
                        Task = task,
                        PilotNumber = int.Parse(manualTrackNode.Attributes["PilotNumber"].InnerText, System.Globalization.CultureInfo.InvariantCulture),
                        TrackFilePath = manualTrackNode.InnerText
                    });
                }

                XmlNode eventTypeFiltersNode = taskNode.SelectSingleNode("EventTypeFilters");
                if (eventTypeFiltersNode != null)
                {
                    string[] eventTypeFilterNames = eventTypeFiltersNode.InnerText.Split(',');
                    List<Models.TrackAnalysis.Events.TrackEvent.EventType> eventTypeFilters = new List<Models.TrackAnalysis.Events.TrackEvent.EventType>();

                    foreach (string eventTypeFilterName in eventTypeFilterNames)
                    {
                        if (Enum.TryParse(eventTypeFilterName, out Models.TrackAnalysis.Events.TrackEvent.EventType eventType))
                        {
                            eventTypeFilters.Add(eventType);
                        }
                    }

                    task.EventTypeFilters = eventTypeFilters.ToArray();
                }
            }

            return competition;
        }

        public void SaveCompetition(Models.Competition competition)
        {
            XmlElement element;

            XmlDocument document = new XmlDocument();

            XmlElement rootElement = document.CreateElement("Boris");
            rootElement.SetAttribute("Type", "Competition");
            rootElement.SetAttribute("Version", m_currentFileVersion.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture));
            document.AppendChild(rootElement);

            XmlElement competitionElement = document.CreateElement("Competition");
            rootElement.AppendChild(competitionElement);

            element = document.CreateElement("Name");
            element.InnerText = competition.Name;
            competitionElement.AppendChild(element);

			element = document.CreateElement("LogoImagePath");
			element.InnerText = competition.LogoImagePath;
			competitionElement.AppendChild(element);

			element = document.CreateElement("Start");
            element.InnerText = competition.Start.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            competitionElement.AppendChild(element);

            element = document.CreateElement("Finish");
            element.InnerText = competition.Finish.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            competitionElement.AppendChild(element);

            element = document.CreateElement("TimeZone");
            element.InnerText = competition.TimeZone.Id;
            competitionElement.AppendChild(element);

			XmlElement aircraftClassesElement = document.CreateElement("AircraftClasses");
			competitionElement.AppendChild(aircraftClassesElement);

			foreach (Models.AircraftClass aircraftClass in competition.AircraftClasses)
			{
				element = document.CreateElement("Code");
				element.InnerText = aircraftClass.Code;
				aircraftClassesElement.AppendChild(element);
			}

            if (competition.NationDefinitions.Count > 0)
            {
                XmlElement nationDefinitionsElement = document.CreateElement("NationDefinitions");
                competitionElement.AppendChild(nationDefinitionsElement);

                foreach (Models.NationDefinition nationDefinition in competition.NationDefinitions)
                {
                    XmlElement nationDefinitionElement = document.CreateElement("NationDefinition");
                    nationDefinitionsElement.AppendChild(nationDefinitionElement);

                    element = document.CreateElement("AircraftClassCode");
                    element.InnerText = nationDefinition.AircraftClass.Code;
                    nationDefinitionElement.AppendChild(element);

                    element = document.CreateElement("NumberWhoScore");
                    element.InnerText = nationDefinition.NumberWhoScore.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    nationDefinitionElement.AppendChild(element);
                }
            }

            if (!string.IsNullOrEmpty(competition.BackupPath))
            {
                element = document.CreateElement("BackupPath");
                element.InnerText = competition.BackupPath;
                competitionElement.AppendChild(element);
            }

            if (!string.IsNullOrEmpty(competition.FrdlIgcPath))
            {
                element = document.CreateElement("FrdlIgcPath");
                element.InnerText = competition.FrdlIgcPath;
                competitionElement.AppendChild(element);
            }

            if (!string.IsNullOrEmpty(competition.FlymasterIgcPath))
            {
                element = document.CreateElement("FlymasterIgcPath");
                element.InnerText = competition.FlymasterIgcPath;
                competitionElement.AppendChild(element);
            }

            if (!string.IsNullOrEmpty(competition.FlymasterApiUsername))
            {
                element = document.CreateElement("FlymasterApiUsername");
                element.InnerText = competition.FlymasterApiUsername;
                competitionElement.AppendChild(element);
            }
            if (!string.IsNullOrEmpty(competition.FlymasterApiPassword))
            {
                element = document.CreateElement("FlymasterApiPassword");
                element.InnerText = competition.FlymasterApiPassword;
                competitionElement.AppendChild(element);
            }
            if (!string.IsNullOrEmpty(competition.FlymasterApiGroupId))
            {
                element = document.CreateElement("FlymasterApiGroupId");
                element.InnerText = competition.FlymasterApiGroupId;
                competitionElement.AppendChild(element);
            }

            element = document.CreateElement("DefaultPointRadius");
            element.InnerText = competition.DefaultPointRadius.ToString("0", System.Globalization.CultureInfo.InvariantCulture);
            competitionElement.AppendChild(element);

			element = document.CreateElement("DefaultGateWidth");
			element.InnerText = competition.DefaultGateWidth.ToString("0", System.Globalization.CultureInfo.InvariantCulture);
			competitionElement.AppendChild(element);

			XmlElement pilotSpreadsheetMappingsElement = document.CreateElement("PilotSpreadsheetMappings");
            competitionElement.AppendChild(pilotSpreadsheetMappingsElement);

            foreach (Models.Spreadsheets.SpreadsheetColumnMapping mapping in competition.PilotsSpreadsheet.Mappings)
            {
                XmlElement columnMappingElement = document.CreateElement("ColumnMapping");
                pilotSpreadsheetMappingsElement.AppendChild(columnMappingElement);

                element = document.CreateElement("ColumnType");
                switch (mapping.ColumnType)
                {
                    case Models.Column.ColumnType.PilotNumber:
                        element.InnerText = "N";
                        break;
                    case Models.Column.ColumnType.PilotName:
                        element.InnerText = "P";
                        break;
                    case Models.Column.ColumnType.TeamName:
                        element.InnerText = "T";
                        break;
                    case Models.Column.ColumnType.Country:
                        element.InnerText = "C";
                        break;
                    case Models.Column.ColumnType.Motor:
                        element.InnerText = "M";
                        break;
                    case Models.Column.ColumnType.Wing:
                        element.InnerText = "W";
                        break;
                    case Models.Column.ColumnType.LoggerId:
                        element.InnerText = "L";
                        break;
                }
                columnMappingElement.AppendChild(element);

                element = document.CreateElement("Required");
                if (mapping.Required)
                {
                    element.InnerText = "Y";
                }
                else
                {
                    element.InnerText = "N";
                }
                columnMappingElement.AppendChild(element);

                element = document.CreateElement("ColumnName");
                element.InnerText = mapping.ColumnName;
                columnMappingElement.AppendChild(element);
            }

			if (competition.Features.Count > 0)
			{
				XmlElement featuresElement = document.CreateElement("Features");
				competitionElement.AppendChild(featuresElement);

				foreach (Models.Features.Feature feature in competition.Features)
				{
					InsertCompetitionFeature(feature, featuresElement);
				}
			}

            XmlElement tasksElement = document.CreateElement("Tasks");
            competitionElement.AppendChild(tasksElement);

            foreach (Models.Task task in competition.Tasks)
            {
                XmlElement taskElement = document.CreateElement("Task");
                tasksElement.AppendChild(taskElement);

                element = document.CreateElement("Number");
                element.InnerText = String.Format("{0}", task.Number);
                taskElement.AppendChild(element);

                element = document.CreateElement("Name");
                element.InnerText = task.Name;
                taskElement.AppendChild(element);

                if (task.AbbreviatedName.Length > 0)
                {
                    element = document.CreateElement("AbbreviatedName");
                    element.InnerText = task.AbbreviatedName;
                    taskElement.AppendChild(element);
                }

                element = document.CreateElement("Type");
                switch (task.Type)
                {
                    case Models.Task.TaskType.Economy:
                        element.InnerText = "E";
                        break;
                    case Models.Task.TaskType.Navigation:
                        element.InnerText = "N";
                        break;
                    case Models.Task.TaskType.Precision:
                        element.InnerText = "P";
                        break;
                }
                taskElement.AppendChild(element);

                aircraftClassesElement = document.CreateElement("AircraftClasses");
                taskElement.AppendChild(aircraftClassesElement);

                foreach (Models.AircraftClass aircraftClass in task.AircraftClasses)
                {
                    element = document.CreateElement("Code");
                    element.InnerText = aircraftClass.Code;
                    aircraftClassesElement.AppendChild(element);
                }

                element = document.CreateElement("LaunchOpen");
				element.InnerText = task.LaunchOpen.ToString("yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture);
				taskElement.AppendChild(element);

				if (task.LaunchCloseSet)
				{
					element = document.CreateElement("LaunchClose");
					element.InnerText = task.LaunchClose.ToString("yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture);
					taskElement.AppendChild(element);
				}

				if (task.LandBySet)
				{
					element = document.CreateElement("LandBy");
					element.InnerText = task.LandBy.ToString("yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture);
					taskElement.AppendChild(element);
				}

                XmlElement taskSpreadsheetMappingsElement = document.CreateElement("SpreadsheetMappings");
                taskElement.AppendChild(taskSpreadsheetMappingsElement);

                foreach (Models.Spreadsheets.SpreadsheetColumnMapping mapping in task.ScoringSpreadsheet.Mappings)
                {
                    XmlElement columnMappingElement = document.CreateElement("ColumnMapping");
                    taskSpreadsheetMappingsElement.AppendChild(columnMappingElement);

                    element = document.CreateElement("ColumnType");
                    switch (mapping.ColumnType)
                    {
                        case Models.Column.ColumnType.PilotNumber:
                            element.InnerText = "N";
                            break;
                        case Models.Column.ColumnType.Score:
                            element.InnerText = "S";
                            break;
                    }
                    columnMappingElement.AppendChild(element);

                    element = document.CreateElement("Required");
                    if (mapping.Required)
                    {
                        element.InnerText = "Y";
                    }
                    else
                    {
                        element.InnerText = "N";
                    }
                    columnMappingElement.AppendChild(element);

                    element = document.CreateElement("ColumnName");
                    element.InnerText = mapping.ColumnName;
                    columnMappingElement.AppendChild(element);
                }

                if (task.TakeOffDeck != null)
                {
                    XmlElement takeOffDeckElement = document.CreateElement("TakeOffDeck");
                    taskElement.AppendChild(takeOffDeckElement);

                    InsertTaskFeature(task.TakeOffDeck, takeOffDeckElement);
                }

                if (task.LandingDeck != null)
                {
                    XmlElement landingDeckElement = document.CreateElement("LandingDeck");
                    taskElement.AppendChild(landingDeckElement);

                    InsertTaskFeature(task.LandingDeck, landingDeckElement);
                }

                if (task.StartPointOrGate != null)
				{
					XmlElement startPointOrGateElement = document.CreateElement("StartPointOrGate");
					taskElement.AppendChild(startPointOrGateElement);

					InsertTaskFeature(task.StartPointOrGate, startPointOrGateElement);
				}

				if (task.FinishPointOrGate != null)
				{
					XmlElement finishPointOrGateElement = document.CreateElement("FinishPointOrGate");
					taskElement.AppendChild(finishPointOrGateElement);

					InsertTaskFeature(task.FinishPointOrGate, finishPointOrGateElement);
				}

				if (task.Turnpoints.Count > 0)
				{
					XmlElement turnpointsElement = document.CreateElement("Turnpoints");
					taskElement.AppendChild(turnpointsElement);

					foreach (Models.Features.PointFeature point in task.Turnpoints)
					{
						InsertTaskFeature(point, turnpointsElement);
					}
				}

				if (task.HiddenGates.Count > 0)
				{
					XmlElement hiddenGatesElement = document.CreateElement("HiddenGates");
					taskElement.AppendChild(hiddenGatesElement);

					foreach (Models.Features.GateFeature gate in task.HiddenGates)
					{
						InsertTaskFeature(gate, hiddenGatesElement);
					}
				}

                if (task.NoFlyZones.Count > 0)
                {
                    XmlElement noFlyZonesElement = document.CreateElement("NoFlyZones");
                    taskElement.AppendChild(noFlyZonesElement);

                    foreach (Models.Features.NoFlyZoneFeature nfz in task.NoFlyZones)
                    {
                        // Inserting the same as a competition feature because we're recording all the details not just name
                        InsertCompetitionFeature(nfz, noFlyZonesElement);
                    }
                }

                if (task.ManualTracks.Count > 0)
                {
                    XmlElement manualTracksElement = document.CreateElement("ManualTracks");
                    taskElement.AppendChild(manualTracksElement);

                    foreach (Models.ManualTrack track in task.ManualTracks)
                    {
                        XmlElement manualTrackElement = document.CreateElement("ManualTrack");
                        manualTrackElement.SetAttribute("PilotNumber", track.PilotNumber.ToString("0"));
                        manualTrackElement.InnerText = track.TrackFilePath;
                        manualTracksElement.AppendChild(manualTrackElement);
                    }
                }

                XmlElement eventTypeFiltersElement = document.CreateElement("EventTypeFilters");
                taskElement.AppendChild(eventTypeFiltersElement);

                List<string> eventTypeFilters = new List<string>();

                foreach (Models.TrackAnalysis.Events.TrackEvent.EventType eventType in task.EventTypeFilters)
                {
                    eventTypeFilters.Add(Enum.GetName(typeof(Models.TrackAnalysis.Events.TrackEvent.EventType), eventType));
                }

                eventTypeFiltersElement.InnerText = string.Join(",", eventTypeFilters);
            }

            document.Save(competition.Repository.FilePath);
        }

        public void LoadReminders(Models.Reminders.ReminderCollection reminders)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            string remindersFilePath = pathBuilder.GetRemindersFilePath();

            if (System.IO.File.Exists(remindersFilePath))
            {
                XmlDocument document = new XmlDocument();
                document.Load(remindersFilePath);

                foreach (XmlNode reminderNode in document.SelectNodes("/Boris/Reminders/TaskResultsReminder"))
                {
                    DateTime dueUtc = DateTime.ParseExact(reminderNode.SelectSingleNode("DueUtc").InnerText, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal);
                    int taskNumber = int.Parse(reminderNode.SelectSingleNode("TaskNumber").InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    string aircraftClassCode = reminderNode.SelectSingleNode("AircraftClassCode").InnerText;
                    Models.Results.TaskResults.ResultsStatus status;

                    switch (reminderNode.SelectSingleNode("Status").InnerText)
                    {
                        case "O":
                            status = Models.Results.TaskResults.ResultsStatus.Official;
                            break;
                        case "F":
                            status = Models.Results.TaskResults.ResultsStatus.Final;
                            break;
                        default:
                            status = Models.Results.TaskResults.ResultsStatus.Provisional;
                            break;
                    }

                    reminders.Add(new Models.Reminders.TaskResultsReminder(dueUtc, taskNumber, aircraftClassCode, status));
                }

                foreach (XmlNode reminderNode in document.SelectNodes("/Boris/Reminders/CustomReminder"))
                {
                    DateTime dueUtc = DateTime.ParseExact(reminderNode.SelectSingleNode("DueUtc").InnerText, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal);
                    string description = reminderNode.SelectSingleNode("Description").InnerText;

                    reminders.Add(new Models.Reminders.CustomReminder(dueUtc, description));
                }
            }
        }

        public void SaveReminders(Models.Reminders.ReminderCollection reminders)
        {
            XmlElement element;

            XmlDocument document = new XmlDocument();

            XmlElement rootElement = document.CreateElement("Boris");
            rootElement.SetAttribute("Type", "Reminders");
            document.AppendChild(rootElement);

            XmlElement remindersElement = document.CreateElement("Reminders");
            rootElement.AppendChild(remindersElement);

            foreach (Models.Reminders.Reminder reminder in reminders)
            {
                if (reminder is Models.Reminders.TaskResultsReminder)
                {
                    Models.Reminders.TaskResultsReminder taskResultsReminder = (reminder as Models.Reminders.TaskResultsReminder);

                    XmlElement reminderElement = document.CreateElement("TaskResultsReminder");
                    remindersElement.AppendChild(reminderElement);

                    element = document.CreateElement("DueUtc");
                    element.InnerText = taskResultsReminder.DueUtc.ToString("yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    reminderElement.AppendChild(element);

                    element = document.CreateElement("TaskNumber");
                    element.InnerText = taskResultsReminder.TaskNumber.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    reminderElement.AppendChild(element);

                    element = document.CreateElement("AircraftClassCode");
                    element.InnerText = taskResultsReminder.AircraftClassCode;
                    reminderElement.AppendChild(element);

                    element = document.CreateElement("Status");
                    switch (taskResultsReminder.Status)
                    {
                        case Models.Results.TaskResults.ResultsStatus.Official:
                            element.InnerText = "O";
                            break;
                        case Models.Results.TaskResults.ResultsStatus.Final:
                            element.InnerText = "F";
                            break;
                    }
                    reminderElement.AppendChild(element);
                }
                else if (reminder is Models.Reminders.CustomReminder)
                {
                    Models.Reminders.CustomReminder customReminder = (reminder as Models.Reminders.CustomReminder);

                    XmlElement reminderElement = document.CreateElement("CustomReminder");
                    remindersElement.AppendChild(reminderElement);

                    element = document.CreateElement("DueUtc");
                    element.InnerText = customReminder.DueUtc.ToString("yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    reminderElement.AppendChild(element);

                    element = document.CreateElement("Description");
                    element.InnerText = customReminder.Description;
                    reminderElement.AppendChild(element);
                }
            }

            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            document.Save(pathBuilder.GetRemindersFilePath());
        }

        public bool TaskResultsExists(Models.Results.TaskResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            return (pathBuilder.GetTaskResultsFilePath(results) != null);
        }

        public void LoadTaskResults(Models.Results.TaskResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            XmlDocument document = new XmlDocument();
            document.Load(pathBuilder.GetTaskResultsFilePath(results));

            XmlNode resultsNode = document.SelectSingleNode("Boris/Results");

            switch (resultsNode.SelectSingleNode("Status").InnerText)
            {
                case "O":
                    results.Status = Models.Results.TaskResults.ResultsStatus.Official;
                    break;
                case "F":
                    results.Status = Models.Results.TaskResults.ResultsStatus.Final;
                    break;
                case "C":
                    results.Status = Models.Results.TaskResults.ResultsStatus.Cancelled;
                    break;
                default:
                    results.Status = Models.Results.TaskResults.ResultsStatus.Provisional;
                    break;
            }

            results.Published = DateTime.Parse(resultsNode.SelectSingleNode("Published").InnerText, System.Globalization.CultureInfo.InvariantCulture);

            XmlNode deadlineNode = resultsNode.SelectSingleNode("Deadline");
            if (deadlineNode != null)
            {
                results.Deadline = DateTime.Parse(deadlineNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
            }

            XmlNode classNode = resultsNode.SelectSingleNode(string.Format("Class[Code = '{0}']", results.AircraftClass.Code));

            if (classNode != null)
            {
                results.FontSize = int.Parse(classNode.SelectSingleNode("FontSize").InnerText, System.Globalization.CultureInfo.InvariantCulture);

                results.Data = ExtractResultsTable(classNode);
            }
        }

        public void SaveTaskResults(Models.Results.TaskResults results)
        {
            XmlElement element;

            XmlDocument document = new XmlDocument();

            XmlElement rootElement = document.CreateElement("Boris");
            rootElement.SetAttribute("Type", "TaskResults");
            rootElement.SetAttribute("Version", "1.3");
            document.AppendChild(rootElement);

            XmlElement competitionElement = document.CreateElement("Competition");
            rootElement.AppendChild(competitionElement);

            element = document.CreateElement("Name");
            element.InnerText = results.Task.Competition.Name;
            competitionElement.AppendChild(element);

			element = document.CreateElement("Logo");
			element.InnerText = results.Task.Competition.LogoImagePath;
			competitionElement.AppendChild(element);

			XmlElement taskElement = document.CreateElement("Task");
            rootElement.AppendChild(taskElement);

            element = document.CreateElement("Number");
            element.InnerText = String.Format("{0}", results.Task.Number);
            taskElement.AppendChild(element);

            element = document.CreateElement("Name");
            element.InnerText = results.Task.Name;
            taskElement.AppendChild(element);

            element = document.CreateElement("Type");
            switch (results.Task.Type)
            {
                case Models.Task.TaskType.Economy:
                    element.InnerText = "E";
                    break;
                case Models.Task.TaskType.Navigation:
                    element.InnerText = "N";
                    break;
                case Models.Task.TaskType.Precision:
                    element.InnerText = "P";
                    break;
            }
            taskElement.AppendChild(element);

            element = document.CreateElement("Start");
            element.InnerText = results.Task.LaunchOpen.ToString("yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture);
            taskElement.AppendChild(element);

            XmlElement resultsElement = document.CreateElement("Results");
            rootElement.AppendChild(resultsElement);

            element = document.CreateElement("Status");
            switch (results.Status)
            {
                case Models.Results.TaskResults.ResultsStatus.Provisional:
                    element.InnerText = "P";
                    break;
                case Models.Results.TaskResults.ResultsStatus.Official:
                    element.InnerText = "O";
                    break;
                case Models.Results.TaskResults.ResultsStatus.Final:
                    element.InnerText = "F";
                    break;
                case Models.Results.TaskResults.ResultsStatus.Cancelled:
                    element.InnerText = "C";
                    break;
            }
            resultsElement.AppendChild(element);

            element = document.CreateElement("Published");
            element.InnerText = results.Published.ToString("yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture);
            resultsElement.AppendChild(element);

            if (results.Status == Models.Results.TaskResults.ResultsStatus.Provisional || results.Status == Models.Results.TaskResults.ResultsStatus.Official)
            {
                element = document.CreateElement("Deadline");
                element.InnerText = results.Deadline.ToString("yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture);
                resultsElement.AppendChild(element);
            }

            if (results.Data.Rows.Count > 0)
            {
                XmlElement classElement = document.CreateElement("Class");
                resultsElement.AppendChild(classElement);

                element = document.CreateElement("Code");
                element.InnerText = results.AircraftClass.Code;
                classElement.AppendChild(element);

                element = document.CreateElement("Description");
                element.InnerText = results.AircraftClass.Description;
                classElement.AppendChild(element);

                element = document.CreateElement("FontSize");
                element.InnerText = results.FontSize.ToString(System.Globalization.CultureInfo.InvariantCulture);
                classElement.AppendChild(element);

                InsertResultsTable(results.Data, classElement);
            }

            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            System.IO.FileInfo resultsFile = new System.IO.FileInfo(pathBuilder.GetNextTaskResultsFilePath(results));

            resultsFile.Directory.Create();

            document.Save(resultsFile.FullName);
        }

        public bool OverallResultsExists(Models.Results.OverallResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            return (pathBuilder.GetOverallResultsFilePath(results) != null);
        }

        public void LoadOverallResults(Models.Results.OverallResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            XmlDocument document = new XmlDocument();
            document.Load(pathBuilder.GetOverallResultsFilePath(results));

            XmlNode resultsNode = document.SelectSingleNode("Boris/Results");

            XmlNode classNode = resultsNode.SelectSingleNode(string.Format("Class[Code = '{0}']", results.AircraftClass.Code));

            if (classNode != null)
            {
                results.FontSize = int.Parse(classNode.SelectSingleNode("FontSize").InnerText, System.Globalization.CultureInfo.InvariantCulture);

                results.Data = ExtractResultsTable(classNode);
            }
        }

        public void SaveOverallResults(Models.Results.OverallResults results)
        {
            XmlElement element;

            XmlDocument document = new XmlDocument();

            XmlElement rootElement = document.CreateElement("Boris");
            rootElement.SetAttribute("Type", "OverallResults");
            rootElement.SetAttribute("Version", "1.4");
            document.AppendChild(rootElement);

            XmlElement competitionElement = document.CreateElement("Competition");
            rootElement.AppendChild(competitionElement);

            element = document.CreateElement("Name");
            element.InnerText = results.Competition.Name;
            competitionElement.AppendChild(element);

			element = document.CreateElement("Logo");
			element.InnerText = results.Competition.LogoImagePath;
			competitionElement.AppendChild(element);

			XmlElement resultsElement = document.CreateElement("Results");
            rootElement.AppendChild(resultsElement);

            element = document.CreateElement("Published");
            element.InnerText = results.Published.ToString("yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture);
            resultsElement.AppendChild(element);

            element = document.CreateElement("TaskCount");
			element.InnerText = results.Competition.Tasks.Count.ToString(System.Globalization.CultureInfo.InvariantCulture);
			resultsElement.AppendChild(element);

            if (results.Data.Rows.Count > 0)
            {
                XmlElement classElement = document.CreateElement("Class");
                resultsElement.AppendChild(classElement);

                element = document.CreateElement("Code");
                element.InnerText = results.AircraftClass.Code;
                classElement.AppendChild(element);

                element = document.CreateElement("Description");
                element.InnerText = results.AircraftClass.Description;
                classElement.AppendChild(element);

                element = document.CreateElement("FontSize");
                element.InnerText = results.FontSize.ToString(System.Globalization.CultureInfo.InvariantCulture);
                classElement.AppendChild(element);

                InsertResultsTable(results.Data, classElement);
            }

            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            System.IO.FileInfo resultsFile = new System.IO.FileInfo(pathBuilder.GetNextOverallResultsFilePath(results));

            resultsFile.Directory.Create();

            document.Save(resultsFile.FullName);
        }

        public bool TeamResultsExists(Models.Results.TeamResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            return (pathBuilder.GetTeamResultsFilePath(results) != null);
        }

        public bool NationResultsExists()
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            return (pathBuilder.GetNationResultsFilePath() != null);
        }

        public void LoadTeamResults(Models.Results.TeamResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            XmlDocument document = new XmlDocument();
            document.Load(pathBuilder.GetTeamResultsFilePath(results));

            XmlNode resultsNode = document.SelectSingleNode("Boris/Results");

            XmlNode classNode = resultsNode.SelectSingleNode(string.Format("Class[Code = '{0}']", results.AircraftClass.Code));

            if (classNode != null)
            {
                results.FontSize = int.Parse(classNode.SelectSingleNode("FontSize").InnerText, System.Globalization.CultureInfo.InvariantCulture);

                results.Data = ExtractResultsTable(classNode);
            }
        }

        public void LoadNationResults(Models.Results.NationResults results)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            XmlDocument document = new XmlDocument();
            document.Load(pathBuilder.GetNationResultsFilePath());

            XmlNode resultsNode = document.SelectSingleNode("Boris/Results");

            results.FontSize = int.Parse(resultsNode.SelectSingleNode("FontSize").InnerText, System.Globalization.CultureInfo.InvariantCulture);

            results.Data = ExtractResultsTable(resultsNode);
        }

        public void SaveTeamResults(Models.Results.TeamResults results)
        {
            XmlElement element;

            XmlDocument document = new XmlDocument();

            XmlElement rootElement = document.CreateElement("Boris");
            rootElement.SetAttribute("Type", "TeamResults");
            rootElement.SetAttribute("Version", "1.4");
            document.AppendChild(rootElement);

            XmlElement competitionElement = document.CreateElement("Competition");
            rootElement.AppendChild(competitionElement);

            element = document.CreateElement("Name");
            element.InnerText = results.Competition.Name;
            competitionElement.AppendChild(element);

			element = document.CreateElement("Logo");
			element.InnerText = results.Competition.LogoImagePath;
			competitionElement.AppendChild(element);

			XmlElement resultsElement = document.CreateElement("Results");
            rootElement.AppendChild(resultsElement);

            element = document.CreateElement("Published");
            element.InnerText = results.Published.ToString("yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture);
            resultsElement.AppendChild(element);

            if (results.Data.Rows.Count > 0)
            {
                XmlElement classElement = document.CreateElement("Class");
                resultsElement.AppendChild(classElement);

                element = document.CreateElement("Code");
                element.InnerText = results.AircraftClass.Code;
                classElement.AppendChild(element);

                element = document.CreateElement("Description");
                element.InnerText = results.AircraftClass.Description;
                classElement.AppendChild(element);

                element = document.CreateElement("FontSize");
                element.InnerText = results.FontSize.ToString(System.Globalization.CultureInfo.InvariantCulture);
                classElement.AppendChild(element);

                InsertResultsTable(results.Data, classElement);
            }

            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            System.IO.FileInfo resultsFile = new System.IO.FileInfo(pathBuilder.GetNextTeamResultsFilePath(results));

            resultsFile.Directory.Create();

            document.Save(resultsFile.FullName);
        }

        public void SaveNationResults(Models.Results.NationResults results)
        {
            XmlElement element;

            XmlDocument document = new XmlDocument();

            XmlElement rootElement = document.CreateElement("Boris");
            rootElement.SetAttribute("Type", "NationResults");
            rootElement.SetAttribute("Version", "1.1");
            document.AppendChild(rootElement);

            XmlElement competitionElement = document.CreateElement("Competition");
            rootElement.AppendChild(competitionElement);

            element = document.CreateElement("Name");
            element.InnerText = results.Competition.Name;
            competitionElement.AppendChild(element);

			element = document.CreateElement("Logo");
			element.InnerText = results.Competition.LogoImagePath;
			competitionElement.AppendChild(element);

			XmlElement resultsElement = document.CreateElement("Results");
            rootElement.AppendChild(resultsElement);

            element = document.CreateElement("Published");
            element.InnerText = results.Published.ToString("yyyy-MM-ddTHH:mm", System.Globalization.CultureInfo.InvariantCulture);
            resultsElement.AppendChild(element);

            element = document.CreateElement("FontSize");
            element.InnerText = results.FontSize.ToString(System.Globalization.CultureInfo.InvariantCulture);
            resultsElement.AppendChild(element);

            InsertResultsTable(results.Data, resultsElement);

            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            System.IO.FileInfo resultsFile = new System.IO.FileInfo(pathBuilder.GetNextNationResultsFilePath());

            resultsFile.Directory.Create();

            document.Save(resultsFile.FullName);
        }

        public void Backup(Models.Competition competition)
        {
            FilePathBuilder pathBuilder = new FilePathBuilder(this.FilePath);

            ICSharpCode.SharpZipLib.Zip.FastZip zip = new ICSharpCode.SharpZipLib.Zip.FastZip();

            zip.CreateEmptyDirectories = true;
            zip.CreateZip(pathBuilder.GetBackupDestinationFilePath(competition.BackupPath), pathBuilder.GetBackupSourceFolderPath(), true, @"-\.zip$");
        }

        public string FilePath { get; set; }

		private void InsertCompetitionFeature(Models.Features.Feature feature, XmlElement parentElement)
		{
			XmlElement element;

			switch (feature.Type)
			{
				case Models.Features.Feature.FeatureType.Point:
					Models.Features.PointFeature point = feature as Models.Features.PointFeature;
                    Models.Features.Circle pointCircle = point.Shape as Models.Features.Circle;

					XmlElement pointElement = parentElement.OwnerDocument.CreateElement("Point");
					parentElement.AppendChild(pointElement);

					element = parentElement.OwnerDocument.CreateElement("Name");
					element.InnerText = point.Name;
					pointElement.AppendChild(element);

                    InsertCompetitionFeatureShape(point.Shape, pointElement);

                    if (point.LowerAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        element = parentElement.OwnerDocument.CreateElement("LowerAltitude");
                        element.InnerText = point.LowerAltitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        pointElement.AppendChild(element);
                    }
                    if (point.UpperAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        element = parentElement.OwnerDocument.CreateElement("UpperAltitude");
                        element.InnerText = point.UpperAltitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        pointElement.AppendChild(element);
                    }

					break;

				case Models.Features.Feature.FeatureType.Gate:
					Models.Features.GateFeature gate = feature as Models.Features.GateFeature;
                    Models.Features.Line gateLine = (gate.Shape as Models.Features.Line);
                    
                    XmlElement gateElement = parentElement.OwnerDocument.CreateElement("Gate");
					parentElement.AppendChild(gateElement);

					element = parentElement.OwnerDocument.CreateElement("Name");
					element.InnerText = gate.Name;
					gateElement.AppendChild(element);

                    InsertCompetitionFeatureShape(gate.Shape, gateElement);

                    if (gate.LowerAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        element = parentElement.OwnerDocument.CreateElement("LowerAltitude");
                        element.InnerText = gate.LowerAltitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        gateElement.AppendChild(element);
                    }
                    if (gate.UpperAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        element = parentElement.OwnerDocument.CreateElement("UpperAltitude");
                        element.InnerText = gate.UpperAltitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        gateElement.AppendChild(element);
                    }

					break;

				case Models.Features.Feature.FeatureType.NoFlyZone:
					Models.Features.NoFlyZoneFeature nfz = feature as Models.Features.NoFlyZoneFeature;

					XmlElement nfzElement = parentElement.OwnerDocument.CreateElement("NoFlyZone");
					parentElement.AppendChild(nfzElement);

					element = parentElement.OwnerDocument.CreateElement("Name");
					element.InnerText = nfz.Name;
					nfzElement.AppendChild(element);

                    InsertCompetitionFeatureShape(nfz.Shape, nfzElement);

                    if (nfz.LowerAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        element = parentElement.OwnerDocument.CreateElement("LowerAltitude");
                        element.InnerText = nfz.LowerAltitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        nfzElement.AppendChild(element);
                    }
                    if (nfz.UpperAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        element = parentElement.OwnerDocument.CreateElement("UpperAltitude");
                        element.InnerText = nfz.UpperAltitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
                        nfzElement.AppendChild(element);
                    }

					break;

                case Models.Features.Feature.FeatureType.Airfield:
                    Models.Features.AirfieldFeature airfield = feature as Models.Features.AirfieldFeature;

                    XmlElement airfieldElement = parentElement.OwnerDocument.CreateElement("Airfield");
                    parentElement.AppendChild(airfieldElement);

                    element = parentElement.OwnerDocument.CreateElement("Name");
                    element.InnerText = airfield.Name;
                    airfieldElement.AppendChild(element);

                    InsertCompetitionFeatureShape(airfield.Shape, airfieldElement);

                    break;

                case Models.Features.Feature.FeatureType.Deck:
                    Models.Features.DeckFeature deck = feature as Models.Features.DeckFeature;

                    XmlElement deckElement = parentElement.OwnerDocument.CreateElement("Deck");
                    parentElement.AppendChild(deckElement);

                    element = parentElement.OwnerDocument.CreateElement("Name");
                    element.InnerText = deck.Name;
                    deckElement.AppendChild(element);

                    InsertCompetitionFeatureShape(deck.Shape, deckElement);

                    break;
            }
		}

        private void InsertCompetitionFeatureShape(Models.Features.Shape shape, XmlElement parentElement)
        {
            XmlElement element;

            switch (shape.Type)
            {
                case Models.Features.Shape.ShapeType.Circle:
                    Models.Features.Circle circle = shape as Models.Features.Circle;

                    XmlElement circleElement = parentElement.OwnerDocument.CreateElement("Circle");
                    parentElement.AppendChild(circleElement);

                    element = parentElement.OwnerDocument.CreateElement("Latitude");
                    element.InnerText = circle.Center.Latitude.ToString("#0.000000", System.Globalization.CultureInfo.InvariantCulture);
                    circleElement.AppendChild(element);

                    element = parentElement.OwnerDocument.CreateElement("Longitude");
                    element.InnerText = circle.Center.Longitude.ToString("##0.000000", System.Globalization.CultureInfo.InvariantCulture);
                    circleElement.AppendChild(element);

                    element = parentElement.OwnerDocument.CreateElement("Radius");
                    element.InnerText = circle.Radius.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    circleElement.AppendChild(element);

                    break;

                case Models.Features.Shape.ShapeType.Line:
                    Models.Features.Line line = shape as Models.Features.Line;

                    XmlElement lineElement = parentElement.OwnerDocument.CreateElement("Line");
                    parentElement.AppendChild(lineElement);

                    element = parentElement.OwnerDocument.CreateElement("Latitude");
                    element.InnerText = line.Center.Latitude.ToString("#0.000000", System.Globalization.CultureInfo.InvariantCulture);
                    lineElement.AppendChild(element);

                    element = parentElement.OwnerDocument.CreateElement("Longitude");
                    element.InnerText = line.Center.Longitude.ToString("##0.000000", System.Globalization.CultureInfo.InvariantCulture);
                    lineElement.AppendChild(element);

                    element = parentElement.OwnerDocument.CreateElement("Width");
                    element.InnerText = line.Width.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    lineElement.AppendChild(element);

                    element = parentElement.OwnerDocument.CreateElement("Bearing");
                    element.InnerText = line.Bearing.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
                    lineElement.AppendChild(element);

                    break;

                case Models.Features.Shape.ShapeType.Polygon:
                    Models.Features.Polygon polygon = shape as Models.Features.Polygon;

                    XmlElement polygonElement = parentElement.OwnerDocument.CreateElement("Polygon");
                    parentElement.AppendChild(polygonElement);

                    foreach (Geolocation.Location vertex in polygon.Vertices)
                    {
                        XmlElement vertexElement = parentElement.OwnerDocument.CreateElement("Vertex");
                        polygonElement.AppendChild(vertexElement);

                        element = parentElement.OwnerDocument.CreateElement("Latitude");
                        element.InnerText = vertex.Latitude.ToString("#0.000000", System.Globalization.CultureInfo.InvariantCulture);
                        vertexElement.AppendChild(element);

                        element = parentElement.OwnerDocument.CreateElement("Longitude");
                        element.InnerText = vertex.Longitude.ToString("##0.000000", System.Globalization.CultureInfo.InvariantCulture);
                        vertexElement.AppendChild(element);
                    }

                    break;
            }
        }

		private void InsertTaskFeature(Models.Features.Feature feature, XmlElement parentElement)
		{
			XmlElement element;

			switch (feature.Type)
			{
                case Models.Features.Feature.FeatureType.Deck:
                    Models.Features.DeckFeature deck = feature as Models.Features.DeckFeature;

                    XmlElement deckElement = parentElement.OwnerDocument.CreateElement("Deck");
                    parentElement.AppendChild(deckElement);

                    element = parentElement.OwnerDocument.CreateElement("Name");
                    element.InnerText = deck.Name;
                    deckElement.AppendChild(element);

                    break;

                case Models.Features.Feature.FeatureType.Point:
					Models.Features.PointFeature point = feature as Models.Features.PointFeature;

					XmlElement pointElement = parentElement.OwnerDocument.CreateElement("Point");
					parentElement.AppendChild(pointElement);

					element = parentElement.OwnerDocument.CreateElement("Name");
					element.InnerText = point.Name;
					pointElement.AppendChild(element);

					break;

				case Models.Features.Feature.FeatureType.Gate:
					Models.Features.GateFeature gate = feature as Models.Features.GateFeature;

					XmlElement gateElement = parentElement.OwnerDocument.CreateElement("Gate");
					parentElement.AppendChild(gateElement);

					element = parentElement.OwnerDocument.CreateElement("Name");
					element.InnerText = gate.Name;
					gateElement.AppendChild(element);

					break;
			}
		}

        private void InsertResultsTable(System.Data.DataTable data, XmlElement parentElement)
        {
            XmlElement element;

            XmlElement tableElement = parentElement.OwnerDocument.CreateElement("Table");
            parentElement.AppendChild(tableElement);

            XmlElement columnsElement = parentElement.OwnerDocument.CreateElement("Columns");
            tableElement.AppendChild(columnsElement);

            foreach (System.Data.DataColumn column in data.Columns)
            {
                XmlElement columnElement = parentElement.OwnerDocument.CreateElement("Column");
                columnsElement.AppendChild(columnElement);

                element = parentElement.OwnerDocument.CreateElement("Name");
                element.InnerText = column.ColumnName;
                columnElement.AppendChild(element);

                Models.Column.ColumnType columnType = (Models.Column.ColumnType)column.ExtendedProperties["Type"];
                if (columnType != Models.Column.ColumnType.None)
                {
                    element = parentElement.OwnerDocument.CreateElement("Type");
                    switch (columnType)
                    {
                        case Models.Column.ColumnType.PilotNumber:
                            element.InnerText = "N";
                            break;
                        case Models.Column.ColumnType.PilotName:
                            element.InnerText = "P";
                            break;
                        case Models.Column.ColumnType.TeamName:
                            element.InnerText = "T";
                            break;
						case Models.Column.ColumnType.TeamMembers:
							element.InnerText = "B";
							break;
                        case Models.Column.ColumnType.Score:
                            element.InnerText = "S";
                            break;
                        case Models.Column.ColumnType.TotalScore:
                            element.InnerText = "O";
                            break;
                        case Models.Column.ColumnType.Country:
                            element.InnerText = "C";
                            break;
                        case Models.Column.ColumnType.Motor:
                            element.InnerText = "M";
                            break;
                        case Models.Column.ColumnType.Wing:
                            element.InnerText = "W";
                            break;
                    }
                    columnElement.AppendChild(element);
                }

                element = parentElement.OwnerDocument.CreateElement("DisplayName");
                element.InnerText = (string)column.ExtendedProperties["DisplayName"];
                columnElement.AppendChild(element);

                element = parentElement.OwnerDocument.CreateElement("Visible");
                if ((bool)column.ExtendedProperties["Visible"])
                {
                    element.InnerText = "Y";
                }
                else
                {
                    element.InnerText = "N";
                }
                columnElement.AppendChild(element);

                element = parentElement.OwnerDocument.CreateElement("Width");
                element.InnerText = column.ExtendedProperties["Width"].ToString();
                columnElement.AppendChild(element);

                element = parentElement.OwnerDocument.CreateElement("Align");
                switch ((Models.Column.ColumnAlignment)column.ExtendedProperties["Align"])
                {
                    case Models.Column.ColumnAlignment.Center:
                        element.InnerText = "C";
                        break;
                    case Models.Column.ColumnAlignment.Left:
                        element.InnerText = "L";
                        break;
                    case Models.Column.ColumnAlignment.Right:
                        element.InnerText = "R";
                        break;
                }
                columnElement.AppendChild(element);

                element = parentElement.OwnerDocument.CreateElement("Bold");
                if ((bool)column.ExtendedProperties["Bold"])
                {
                    element.InnerText = "Y";
                }
                else
                {
                    element.InnerText = "N";
                }
                columnElement.AppendChild(element);
            }

            XmlElement rowsElement = parentElement.OwnerDocument.CreateElement("Rows");
            tableElement.AppendChild(rowsElement);

            foreach (System.Data.DataRowView row in data.DefaultView)
            {
                XmlElement rowElement = parentElement.OwnerDocument.CreateElement("Row");
                rowsElement.AppendChild(rowElement);

                foreach (System.Data.DataColumn column in row.DataView.Table.Columns)
                {
                    XmlElement cellElement = parentElement.OwnerDocument.CreateElement("Cell");
                    rowElement.AppendChild(cellElement);

                    element = parentElement.OwnerDocument.CreateElement("Value");
                    element.InnerText = row[column.ColumnName].ToString();
                    cellElement.AppendChild(element);
                }
            }
        }

		private Models.Features.Feature ExtractCompetitionFeature(XmlNode featureNode)
		{
			Models.Features.Feature feature = null;
            XmlNode altitudeNode;

			switch (featureNode.LocalName)
			{
				case "Point":
					Models.Features.PointFeature point = new Models.Features.PointFeature(featureNode.SelectSingleNode("Name").InnerText);

                    point.Shape = ExtractCompetitionFeatureShape(featureNode);

                    altitudeNode = featureNode.SelectSingleNode("LowerAltitude");
                    if (altitudeNode != null)
                    {
                        point.LowerAltitude = int.Parse(altitudeNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        point.LowerAltitude = Geolocation.Location.UnknownAltitude;
                    }
                    altitudeNode = featureNode.SelectSingleNode("UpperAltitude");
                    if (altitudeNode != null)
                    {
                        point.UpperAltitude = int.Parse(altitudeNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        point.UpperAltitude = Geolocation.Location.UnknownAltitude;
                    }

					feature = point;
					break;

				case "Gate":
					Models.Features.GateFeature gate = new Models.Features.GateFeature(featureNode.SelectSingleNode("Name").InnerText);

                    gate.Shape = ExtractCompetitionFeatureShape(featureNode);

                    altitudeNode = featureNode.SelectSingleNode("LowerAltitude");
                    if (altitudeNode != null)
                    {
                        gate.LowerAltitude = int.Parse(altitudeNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        gate.LowerAltitude = Geolocation.Location.UnknownAltitude;
                    }
                    altitudeNode = featureNode.SelectSingleNode("UpperAltitude");
                    if (altitudeNode != null)
                    {
                        gate.UpperAltitude = int.Parse(altitudeNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        gate.UpperAltitude = Geolocation.Location.UnknownAltitude;
                    }

					feature = gate;
					break;

				case "NoFlyZone":
                    Models.Features.NoFlyZoneFeature nfz = new Models.Features.NoFlyZoneFeature(featureNode.SelectSingleNode("Name").InnerText);

                    nfz.Shape = ExtractCompetitionFeatureShape(featureNode);

                    altitudeNode = featureNode.SelectSingleNode("LowerAltitude");
                    if (altitudeNode != null)
                    {
                        nfz.LowerAltitude = int.Parse(altitudeNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        nfz.LowerAltitude = Geolocation.Location.UnknownAltitude;
                    }
                    altitudeNode = featureNode.SelectSingleNode("UpperAltitude");
                    if (altitudeNode != null)
                    {
                        nfz.UpperAltitude = int.Parse(altitudeNode.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        nfz.UpperAltitude = Geolocation.Location.UnknownAltitude;
                    }

					feature = nfz;
					break;

                case "Airfield":
                    feature = new Models.Features.AirfieldFeature(featureNode.SelectSingleNode("Name").InnerText, ExtractCompetitionFeatureShape(featureNode));
                    break;

                case "Deck":
                    feature = new Models.Features.DeckFeature(featureNode.SelectSingleNode("Name").InnerText, ExtractCompetitionFeatureShape(featureNode));
                    break;
            }

			return feature;
		}

        private Models.Features.Shape ExtractCompetitionFeatureShape(XmlNode featureNode)
        {
            Models.Features.Shape shape = null;
            Models.Features.Shape.ShapeType type;

            XmlNode shapeNode = featureNode.ChildNodes[1];

            switch (shapeNode.Name)
            {
                case "Line":
                    type = Models.Features.Shape.ShapeType.Line;
                    break;
                case "Circle":
                    type = Models.Features.Shape.ShapeType.Circle;
                    break;
                case "Polygon":
                    type = Models.Features.Shape.ShapeType.Polygon;
                    break;
                default: // For compatibility
                    if (featureNode.Name == "Gate")
                    {
                        type = Models.Features.Shape.ShapeType.Line;
                    }
                    else
                    {
                        type = Models.Features.Shape.ShapeType.Circle;
                    }
                    shapeNode = featureNode;
                    break;
            }

            switch (type)
            {
                case Models.Features.Shape.ShapeType.Circle:
                    Models.Features.Circle circle = new Models.Features.Circle();
                    circle.Center = new Geolocation.Location(ParseDecimal(shapeNode.SelectSingleNode("Latitude").InnerText), ParseDecimal(shapeNode.SelectSingleNode("Longitude").InnerText));
                    circle.Radius = int.Parse(shapeNode.SelectSingleNode("Radius").InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    shape = circle;
                    break;
                case Models.Features.Shape.ShapeType.Line:
                    Models.Features.Line line = new Models.Features.Line();
                    line.Center = new Geolocation.Location(ParseDecimal(shapeNode.SelectSingleNode("Latitude").InnerText), ParseDecimal(shapeNode.SelectSingleNode("Longitude").InnerText));
                    line.Width = int.Parse(shapeNode.SelectSingleNode("Width").InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    line.Bearing = ParseDecimal(shapeNode.SelectSingleNode("Bearing").InnerText);
                    shape = line;
                    break;
                case Models.Features.Shape.ShapeType.Polygon:
                    Models.Features.Polygon polygon = new Models.Features.Polygon();
                    foreach (XmlNode vertexNode in shapeNode.SelectNodes("Vertex"))
                    {
                        polygon.Vertices.Add(new Geolocation.Location(ParseDecimal(vertexNode.SelectSingleNode("Latitude").InnerText), ParseDecimal(vertexNode.SelectSingleNode("Longitude").InnerText)));
                    }
                    shape = polygon;
                    break;
            }

            return shape;
        }

		private Models.Features.Feature ExtractTaskFeature(XmlNode featureNode, Models.Competition competition)
		{
			Models.Features.Feature feature = null;

			string featureName = featureNode.SelectSingleNode("Name").InnerText;

			foreach (Models.Features.Feature competitionFeature in competition.Features)
			{
				if (string.Compare(competitionFeature.Name, featureName, true) == 0)
				{
					feature = competitionFeature;
					break;
				}
			}

			return feature;
		}

        private System.Data.DataTable ExtractResultsTable(XmlNode parentNode)
        {
            System.Data.DataTable resultsData = new System.Data.DataTable();

            foreach (XmlNode columnNode in parentNode.SelectNodes("Table/Columns/Column"))
            {
                System.Data.DataColumn column = resultsData.Columns.Add(columnNode.SelectSingleNode("Name").InnerText);

                XmlNode columnTypeNode = columnNode.SelectSingleNode("Type");
                if (columnTypeNode != null)
                {
                    switch (columnTypeNode.InnerText)
                    {
                        case "N":
                            column.ExtendedProperties.Add("Type", Models.Column.ColumnType.PilotNumber);
                            break;
                        case "P":
                            column.ExtendedProperties.Add("Type", Models.Column.ColumnType.PilotName);
                            break;
                        case "T":
                            column.ExtendedProperties.Add("Type", Models.Column.ColumnType.TeamName);
                            break;
						case "B":
							column.ExtendedProperties.Add("Type", Models.Column.ColumnType.TeamMembers);
							break;
                        case "S":
                            column.ExtendedProperties.Add("Type", Models.Column.ColumnType.Score);
                            column.DataType = typeof(int);
                            break;
                        case "O":
                            column.ExtendedProperties.Add("Type", Models.Column.ColumnType.TotalScore);
                            column.DataType = typeof(int);
                            break;
                        case "C":
                            column.ExtendedProperties.Add("Type", Models.Column.ColumnType.Country);
                            break;
                        case "M":
                            column.ExtendedProperties.Add("Type", Models.Column.ColumnType.Motor);
                            break;
                        case "W":
                            column.ExtendedProperties.Add("Type", Models.Column.ColumnType.Wing);
                            break;
                        default:
                            column.ExtendedProperties.Add("Type", Models.Column.ColumnType.None);
                            break;
                    }
                }
                else
                {
                    column.ExtendedProperties.Add("Type", Models.Column.ColumnType.None);
                }

                column.ExtendedProperties.Add("DisplayName", columnNode.SelectSingleNode("DisplayName").InnerText);
                if (string.Compare(columnNode.SelectSingleNode("Visible").InnerText, "Y", true) == 0)
                {
                    column.ExtendedProperties.Add("Visible", true);
                }
                else
                {
                    column.ExtendedProperties.Add("Visible", false);
                }
                column.ExtendedProperties.Add("Width", float.Parse(columnNode.SelectSingleNode("Width").InnerText, System.Globalization.CultureInfo.InvariantCulture));
                switch (columnNode.SelectSingleNode("Align").InnerText)
                {
                    case "C":
                        column.ExtendedProperties.Add("Align", Models.Column.ColumnAlignment.Center);
                        break;
                    case "R":
                        column.ExtendedProperties.Add("Align", Models.Column.ColumnAlignment.Right);
                        break;
                    default:
                        column.ExtendedProperties.Add("Align", Models.Column.ColumnAlignment.Left);
                        break;
                }
                if (string.Compare(columnNode.SelectSingleNode("Bold").InnerText, "Y", true) == 0)
                {
                    column.ExtendedProperties.Add("Bold", true);
                }
                else
                {
                    column.ExtendedProperties.Add("Bold", false);
                }
            }

            foreach (XmlNode rowNode in parentNode.SelectNodes("Table/Rows/Row"))
            {
                System.Data.DataRow row = resultsData.Rows.Add();

                int columnIndex = 0;

                foreach (XmlNode cellValueNode in rowNode.SelectNodes("Cell/Value"))
                {
                    row[columnIndex] = cellValueNode.InnerText;
                    columnIndex++;
                }
            }

            return resultsData;
        }

        // Can be removed after version 1.2.15
        private static decimal ParseDecimal(string number)
        {
            return decimal.Parse(number.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
