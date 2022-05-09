using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Spreadsheets
{
	class SpreadsheetColumnMapping
	{
		public SpreadsheetColumnMapping(Column.ColumnType columnType, string columnName, bool required)
		{
			this.ColumnType = columnType;
			this.ColumnName = columnName;
			this.Required = required;
		}

		public SpreadsheetColumnMapping()
		{
		}

		public Column.ColumnType ColumnType { get; set; }
		public string ColumnName { get; set; }
		public bool Required { get; set; }
	}
}
