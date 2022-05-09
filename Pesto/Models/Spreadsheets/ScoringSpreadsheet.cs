using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Spreadsheets
{
	class ScoringSpreadsheet : Spreadsheet
	{
		public ScoringSpreadsheet(Task task) : base()
		{
			this.Task = task;

            this.Mappings.Add(new SpreadsheetColumnMapping(Column.ColumnType.PilotNumber, "Pilot Number", true));
            this.Mappings.Add(new SpreadsheetColumnMapping(Column.ColumnType.Score, "", true));
		}

		public override string[] GetTemplateFilePaths()
		{
			return System.IO.Directory.GetFiles(System.Windows.Forms.Application.StartupPath + @"\Resources\Spreadsheets\Scoring");
		}

		protected override string GetFilePath()
		{
			return this.Task.GetFolderPath() + @"\Scoring.xlsx";
		}

		public Task Task { get; set; }
	}
}
