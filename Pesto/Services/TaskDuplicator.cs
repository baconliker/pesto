using ColinBaker.Pesto.Models.Spreadsheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Services
{
	class TaskDuplicator
	{
		public Models.Task Duplicate(Models.Task taskToDuplicate, Models.Competition competition)
		{
			Models.Task newTask = new Models.Task(competition)
			{
				Number = competition.Tasks.Count + 1,
				Name = taskToDuplicate.Name,
				AbbreviatedName = taskToDuplicate.AbbreviatedName,
				Type = taskToDuplicate.Type,
				AircraftClasses = taskToDuplicate.AircraftClasses,
				LaunchOpen = taskToDuplicate.LaunchOpen,
				LaunchClose = taskToDuplicate.LaunchClose,
				LandBy = taskToDuplicate.LandBy
			};

			newTask.SyncTaskResultsWithAircraftClasses();

			newTask.ScoringSpreadsheet.Mappings.Clear();
			foreach (SpreadsheetColumnMapping mapping in taskToDuplicate.ScoringSpreadsheet.Mappings)
			{
				newTask.ScoringSpreadsheet.Mappings.Add(new SpreadsheetColumnMapping
				{
					ColumnType = mapping.ColumnType,
					ColumnName = mapping.ColumnName,
					Required = mapping.Required
				});
			}
			if (taskToDuplicate.ScoringSpreadsheet.Exists())
			{
				taskToDuplicate.ScoringSpreadsheet.CopyTo(newTask.ScoringSpreadsheet.GetFilePath());
			}

			newTask.TakeOffDeck = taskToDuplicate.TakeOffDeck;
			newTask.LandingDeck = taskToDuplicate.LandingDeck;
			newTask.StartPointOrGate = taskToDuplicate.StartPointOrGate;
			newTask.FinishPointOrGate = taskToDuplicate.FinishPointOrGate;
			newTask.Turnpoints = taskToDuplicate.Turnpoints;
			newTask.HiddenGates = taskToDuplicate.HiddenGates;
			foreach (Models.Features.NoFlyZoneFeature nfz in taskToDuplicate.NoFlyZones)
			{
				newTask.NoFlyZones.Add(nfz.Clone(nfz.Name));
			}

			competition.Tasks.Add(newTask);
			competition.Save();

			return newTask;
		}
	}
}
