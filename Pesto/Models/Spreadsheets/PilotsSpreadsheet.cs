using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Spreadsheets
{
	class PilotsSpreadsheet : Spreadsheet
	{
		public PilotsSpreadsheet(Competition competition) : base()
		{
			this.Competition = competition;

			this.Mappings.Add(new SpreadsheetColumnMapping(Column.ColumnType.PilotNumber, "Number", true));
            this.Mappings.Add(new SpreadsheetColumnMapping(Column.ColumnType.PilotName, "Name", true));
            this.Mappings.Add(new SpreadsheetColumnMapping(Column.ColumnType.TeamName, "Country", false));
            this.Mappings.Add(new SpreadsheetColumnMapping(Column.ColumnType.Country, "Country", false));
            this.Mappings.Add(new SpreadsheetColumnMapping(Column.ColumnType.Motor, "Motor", false));
            this.Mappings.Add(new SpreadsheetColumnMapping(Column.ColumnType.Wing, "Wing", false));
			this.Mappings.Add(new SpreadsheetColumnMapping(Column.ColumnType.LoggerId, "LoggerID", false));
		}

		public override string[] GetTemplateFilePaths()
		{
			return new string[] { System.Windows.Forms.Application.StartupPath + @"\Resources\Spreadsheets\Pilots.xlsx" };
		}

		protected override string GetFilePath()
		{
			return this.Competition.GetFolderPath() + @"\Pilots.xlsx";
		}

		public Competition Competition { get; set; }
	}
}
