using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Results
{
	abstract class Results
	{
        public abstract bool Exists();
        public abstract void Load();
        public abstract void Save();
		public abstract void Generate(ResultsGenerationOptions options);
        public abstract void Publish();
        public abstract string GetPublishedFilePath();

        public bool Loaded { get; protected set; }

		protected static void CheckResultDataContainsMappedColumns(DataTable data, Spreadsheets.Spreadsheet spreadsheet, AircraftClass aircraftClass)
		{
			foreach (Spreadsheets.SpreadsheetColumnMapping mapping in spreadsheet.Mappings)
			{
				if (mapping.Required)
				{
					if (!data.Columns.Contains(mapping.ColumnName))
					{
						throw new ResultsGenerationException("Column '" + mapping.ColumnName + "' not found for class " + aircraftClass.Code + " (" + aircraftClass.Description + ")");
					}
				}
			}
		}

        protected static DataColumn CopyColumn(DataColumn sourceColumn, DataView sourceView, DataColumn sourcePrimaryKeyColumn, DataView destinationView, DataColumn destinationPrimaryKeyColumn)
        {
            // Copies a column (including all row data) from one datatable to another
            // Assumes the source and destination views have both been sorted by the primary key column

            DataColumn newDestinationColumn = new DataColumn(sourceColumn.ColumnName, sourceColumn.DataType);

            object[] keys = new object[sourceColumn.ExtendedProperties.Count];
            sourceColumn.ExtendedProperties.Keys.CopyTo(keys, 0);

            object[] values = new object[sourceColumn.ExtendedProperties.Count];
            sourceColumn.ExtendedProperties.Values.CopyTo(values, 0);

            for (int i = 0; i < values.Length; i++)
            {
                newDestinationColumn.ExtendedProperties.Add(keys[i], values[i]);
            }

            destinationView.Table.Columns.Add(newDestinationColumn);

            // Copy data

            for (int destinationRowIndex = 0; destinationRowIndex < destinationView.Count; destinationRowIndex++)
            {
				bool found = false;

				int destinationPrimaryKey = Convert.ToInt32(destinationView[destinationRowIndex][destinationPrimaryKeyColumn.Ordinal]);
                
                // Find the equivalent row in the source data
                for (int sourceRowIndex = 0; sourceRowIndex < sourceView.Count; sourceRowIndex++)
                {
					if (Convert.ToInt32(sourceView[sourceRowIndex][sourcePrimaryKeyColumn.Ordinal]) == destinationPrimaryKey)
                    {
                        destinationView[destinationRowIndex][newDestinationColumn.Ordinal] = sourceView[sourceRowIndex][sourceColumn.Ordinal];
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
					throw new ResultsGenerationException("Source row not found when attempting to copy " + sourceColumn.ColumnName + ". No match found for primary key value " + destinationPrimaryKey.ToString());
                }
            }

            return newDestinationColumn;
        }

		protected static void AddPositionColumn(System.Data.DataView resultsView, string scoreColumnName)
		{
            if (resultsView.Table.Columns["Position"] != null)
            {
                throw new ResultsGenerationException("A column called 'Position' already exists.");
            }

			// Add column and make it the first
            System.Data.DataColumn positionColumn = CreateColumn("Position", typeof(string), Column.ColumnType.None, Column.ColumnAlignment.Left);
			resultsView.Table.Columns.Add(positionColumn);
			positionColumn.SetOrdinal(0);

			System.Data.DataColumn scoreColumn = resultsView.Table.Columns[scoreColumnName];

			int validRowCount = 0;
			int position = 0;
			List<int> equalPositions = new List<int>();

			// Add positions
			for (int i = 0; i < resultsView.Count; i++)
			{
                validRowCount++;

                if (i > 0 && Convert.ToInt32(resultsView[i][scoreColumn.Ordinal]) == Convert.ToInt32(resultsView[i - 1][scoreColumn.Ordinal]))
                {
                    position = Convert.ToInt32(resultsView[i - 1][positionColumn.Ordinal]);

                    if (!equalPositions.Contains(position))
                    {
                        equalPositions.Add(position);
                    }
                }
                else
                {
                    position = validRowCount;
                }

                resultsView[i][positionColumn.Ordinal] = position.ToString();
            }

			// Go back through and add '=' where necessary
			for (int i = 0; i < resultsView.Count; i++)
			{
				if (!string.IsNullOrEmpty(resultsView[i][positionColumn.Ordinal] as string) && equalPositions.Contains(Convert.ToInt32(resultsView[i][positionColumn.Ordinal])))
				{
					resultsView[i][positionColumn.Ordinal] += "=";
				}
			}
		}

        protected static DataColumn CreateColumn(string name, Type dataType, Column.ColumnType type, Column.ColumnAlignment align)
        {
            System.Data.DataColumn column = new System.Data.DataColumn(name, dataType);

            // Add extended properties
            column.ExtendedProperties.Add("Type", type);
            column.ExtendedProperties.Add("Visible", true);
            column.ExtendedProperties.Add("DisplayName", name);
            column.ExtendedProperties.Add("Width", 0.0f);
            column.ExtendedProperties.Add("Align", align);
            if (type == Column.ColumnType.TotalScore)
            {
                column.ExtendedProperties.Add("Bold", true);
            }
            else
            {
                column.ExtendedProperties.Add("Bold", false);
            }

            return column;
        }

        protected static void CopyColumnProperties(DataTable sourceData, DataTable destinationData, bool includeDisplayName)
        {
            foreach (DataColumn sourceColumn in sourceData.Columns)
            {
                foreach (DataColumn destinationColumn in destinationData.Columns)
                {
                    if (string.Compare(destinationColumn.ColumnName, sourceColumn.ColumnName, true) == 0)
                    {
                        destinationColumn.ExtendedProperties["Type"] = sourceColumn.ExtendedProperties["Type"];
                        destinationColumn.ExtendedProperties["Visible"] = sourceColumn.ExtendedProperties["Visible"];
                        if (includeDisplayName)
                        {
                            destinationColumn.ExtendedProperties["DisplayName"] = sourceColumn.ExtendedProperties["DisplayName"];
                        }
                        // Don't copy across width property as this will be recalculated (content may have changed)
                        destinationColumn.ExtendedProperties["Align"] = sourceColumn.ExtendedProperties["Align"];
                        destinationColumn.ExtendedProperties["Bold"] = sourceColumn.ExtendedProperties["Bold"];
                        
                        break;
                    }
                }
            }
        }

        protected static DataColumn GetColumnByType(DataTable data, Column.ColumnType type)
        {
            DataColumn columnFound = null;

            foreach (DataColumn column in data.Columns)
            {
                Column.ColumnType columnType = (Column.ColumnType)column.ExtendedProperties["Type"];

                if (columnType == type)
                {
                    columnFound = column;
                    break;
                }
            }

            return columnFound;
        }

        protected static DataColumn AddTotalScoreColumn(DataTable data)
        {
            if (data.Columns["Total"] != null)
            {
                throw new ResultsGenerationException("A column called 'Total' already exists.");
            }

            // Add column and make it the first
            System.Data.DataColumn totalScoreColumn = CreateColumn("Total", typeof(int), Column.ColumnType.TotalScore, Column.ColumnAlignment.Right);
            data.Columns.Add(totalScoreColumn);

            foreach (DataRow row in data.Rows)
            {
                int totalScore = 0;

                foreach (DataColumn column in data.Columns)
                {
                    Column.ColumnType columnType = (Column.ColumnType)column.ExtendedProperties["Type"];

                    if (columnType == Column.ColumnType.Score)
                    {
                        //TODO: Sort quick dirty fix
                        if (row[column.Ordinal] != DBNull.Value)
                        {
                            totalScore += Convert.ToInt32(row[column.Ordinal]);
                        }
                    }
                }

                row[totalScoreColumn.Ordinal] = totalScore;
            }

            return totalScoreColumn;
        }
	}
}
