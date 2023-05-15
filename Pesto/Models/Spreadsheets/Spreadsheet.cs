using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ColinBaker.Pesto.Models.Spreadsheets
{
	abstract class Spreadsheet
	{
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		public abstract string[] GetTemplateFilePaths();
		public abstract string GetFilePath();

		public Spreadsheet()
		{
			this.Mappings = new List<SpreadsheetColumnMapping>();
		}

		public bool Exists()
		{
			return System.IO.File.Exists(GetFilePath());
		}

		public void Create(string templateFilePath)
		{
			System.IO.FileInfo destinationFile = new System.IO.FileInfo(GetFilePath());

			// Make sure the folder exists
			System.IO.Directory.CreateDirectory(destinationFile.DirectoryName);

			// Copy the template file to the task folder
			System.IO.File.Copy(templateFilePath, GetFilePath());
		}

        public void Open()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(GetFilePath());
            startInfo.UseShellExecute = true;

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();
            }
        }

		public void CopyTo(string filePath)
		{
			System.IO.FileInfo file = new System.IO.FileInfo(filePath);

			if (!file.Directory.Exists)
			{
				file.Directory.Create();
			}
			
			System.IO.File.Copy(GetFilePath(), file.FullName);
		}

		public bool MappingsComplete()
		{
			foreach (SpreadsheetColumnMapping mapping in this.Mappings)
			{
				if (mapping.Required && string.IsNullOrEmpty(mapping.ColumnName))
				{
					return false;
				}
			}

			return true;
		}

		public SpreadsheetColumnMapping GetMapping(Column.ColumnType columnType)
		{
			SpreadsheetColumnMapping foundMapping = null;

			foreach (SpreadsheetColumnMapping mapping in this.Mappings)
			{
				if (mapping.ColumnType == columnType)
				{
					foundMapping = mapping;
					break;
				}
			}

			return foundMapping;
		}

		public SpreadsheetColumnMapping GetMapping(string columnName)
		{
			SpreadsheetColumnMapping foundMapping = null;

			foreach (SpreadsheetColumnMapping mapping in this.Mappings)
			{
				if (mapping.ColumnName == columnName)
				{
					foundMapping = mapping;
					break;
				}
			}

			return foundMapping;
		}

		public DataTable GetData(string aircraftClass)
		{
			// Since we want the cell text as displayed by Excel, the only way I could find to retrieve this in a performant way is to save the sheet as csv and read back in

			string csvFilePath = System.IO.Path.GetTempFileName();

			SaveCsv(aircraftClass, csvFilePath);

			DataTable data = LoadCsv(csvFilePath);

			System.IO.File.Delete(csvFilePath);

			return data;
		}

		public string[] GetColumnNames(string aircraftClass)
		{
			string csvFilePath = System.IO.Path.GetTempFileName();

			SaveCsv(aircraftClass, csvFilePath);

			DataTable data = LoadCsv(csvFilePath);

			System.IO.File.Delete(csvFilePath);

			string[] columnNames = new string[data.Columns.Count];

			for (int i = 0; i < data.Columns.Count; i++ )
			{
				columnNames[i] = data.Columns[i].ColumnName;
			}

			return columnNames;
		}

		public List<SpreadsheetColumnMapping> Mappings { get; set; }

		private void SaveCsv(string aircraftClass, string csvFilePath)
		{
            Services.Spreadsheet.SpreadsheetConverter converter = new Services.Spreadsheet.SpreadsheetConverter();
            converter.ConvertToCsv(GetFilePath(), csvFilePath, aircraftClass);
		}

		private DataTable LoadCsv(string filePath)
		{
			DataTable data = new DataTable();
			int lineNumber = 0;

			using (System.IO.FileStream stream = System.IO.File.OpenRead(filePath))
			{
				using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
				{
					while (!reader.EndOfStream)
					{
						lineNumber++;
						string[] fileLine = ReadCsvLine(reader);

						if (lineNumber == 1)
						{
							for (int i = 0; i < fileLine.Length; i++)
							{
                                // Stop if/when we find a column without a name. Excel sometimes saves columns that contain no data
                                if (fileLine[i].Trim().Length == 0)
                                {
                                    break;
                                }

								DataColumn column = data.Columns.Add(fileLine[i]);

								SpreadsheetColumnMapping mapping = GetMapping(column.ColumnName);
								if (mapping != null)
								{
									switch (mapping.ColumnType)
									{
										case Column.ColumnType.PilotNumber:
											column.DataType = typeof(int);
											break;
										case Column.ColumnType.Score:
											column.DataType = typeof(int);
											break;
										default:
											column.DataType = typeof(string);
											break;
									}
								}
								else
								{
									column.DataType = typeof(string);
								}

								// Create extended properties
                                // TODO: Move this to Results class?
                                column.ExtendedProperties.Add("Visible", true);
                                column.ExtendedProperties.Add("DisplayName", column.ColumnName);
								column.ExtendedProperties.Add("Width", 0.0f);
                                if (mapping != null)
                                {
                                    column.ExtendedProperties.Add("Type", mapping.ColumnType);
                                    switch (mapping.ColumnType)
                                    {
                                        case Column.ColumnType.PilotNumber:
                                            column.ExtendedProperties.Add("Align", Column.ColumnAlignment.Center);
                                            column.ExtendedProperties.Add("Bold", false);
                                            break;
                                        case Column.ColumnType.Score:
                                            column.ExtendedProperties.Add("Align", Column.ColumnAlignment.Right);
                                            column.ExtendedProperties.Add("Bold", true);
                                            break;
                                        default:
                                            column.ExtendedProperties.Add("Align", Column.ColumnAlignment.Left);
                                            column.ExtendedProperties.Add("Bold", false);
                                            break;
                                    }
                                }
                                else
                                {
                                    column.ExtendedProperties.Add("Type", Column.ColumnType.None);
                                    column.ExtendedProperties.Add("Align", Column.ColumnAlignment.Left);
                                    column.ExtendedProperties.Add("Bold", false);
                                }
							}
						}
						else
						{
							// Stop if/when we find a row without a value in the first column. Excel sometimes saves rows that contain no data
							if (fileLine[0].Trim().Length == 0)
							{
								break;
							}

							DataRow row = data.Rows.Add();

							for (int i = 0; i < data.Columns.Count; i++)
							{
								if (string.IsNullOrEmpty(fileLine[i]) && data.Columns[i].DataType == typeof(int))
								{
									row[i] = 0;
								}
								else
								{
									row[i] = fileLine[i];
								}
							}
						}
					}
				}
			}

			return data;
		}

        private static string[] ReadCsvLine(System.IO.StreamReader reader)
        {
            List<string> line = new List<string>(reader.ReadLine().Split(','));

            int i = 0;

            // Combine items that have been incorrectly split because they contain commas
            while (i < line.Count)
            {
                if (line[i].StartsWith("\"") && !line[i].EndsWith("\""))
                {
                    // Combine items until we find the end double quotes
                    while (!line[i + 1].EndsWith("\""))
                    {
                        line[i] = line[i] + "," + line[i + 1];
                        line.RemoveAt(i + 1);
                    }

                    line[i] = line[i] + "," + line[i + 1];
                    line.RemoveAt(i + 1);
                }

                i++;
            }

            // Unescape items
            for (int j = 0; j < line.Count; j++)
            {
                if (line[j].StartsWith("\"") && line[j].EndsWith("\""))
                {
                    // Remove the enclosing double quotes
                    line[j] = line[j].Substring(1, line[j].Length - 2);

                    // Unescape double quotes
                    line[j] = line[j].Replace("\"\"", "\"");
                }
            }

            return line.ToArray();
        }
    }
}
