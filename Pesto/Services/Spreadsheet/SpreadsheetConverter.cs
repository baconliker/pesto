using System;
using System.IO;

namespace ColinBaker.Pesto.Services.Spreadsheet
{
    class SpreadsheetConverter
    {
        public bool ConvertToCsv(string inputFilePath, string outputFilePath, string worksheetName)
        {
            bool worksheetFound = false;

            using (Bytescout.Spreadsheet.Spreadsheet spreadsheet = new Bytescout.Spreadsheet.Spreadsheet())
            {
                SettingsStore store = new SettingsStore();

                spreadsheet.RegistrationKey = store.BytescoutSpreadsheetRegistrationKey;
                spreadsheet.RegistrationName = store.BytescoutSpreadsheetRegistrationName;

                try
                {
                    spreadsheet.LoadFromFile(inputFilePath);

                    foreach (Bytescout.Spreadsheet.Worksheet sheet in spreadsheet.Worksheets)
                    {
                        if (sheet.Name == worksheetName)
                        {
                            worksheetFound = true;

                            int maxUsedColumnIndex = GetMaxUsedColumnIndex(sheet);

                            using (FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                            {
                                using (StreamWriter writer = new StreamWriter(outputStream))
                                {
                                    for (int rowIndex = 0; rowIndex <= sheet.UsedRangeRowMax; rowIndex++)
                                    {
                                        if (sheet.Cell(rowIndex, 0).Value == null)
                                        {
                                            break;
                                        }

                                        if (rowIndex > 0)
                                        {
                                            writer.Write(Environment.NewLine);
                                        }

                                        for (int columnIndex = 0; columnIndex <= maxUsedColumnIndex; columnIndex++)
                                        {
                                            if (columnIndex > 0)
                                            {
                                                writer.Write(",");
                                            }

                                            Bytescout.Spreadsheet.Cell cell = sheet.Cell(rowIndex, columnIndex);

                                            if (cell.ValueDataType == Bytescout.Spreadsheet.Constants.DataType.NUMERIC)
                                            {
                                                cell.NumberFormatString = TranslateNumberFormatString(cell);
                                            }

                                            writer.Write(EscapeCsvValue(cell.ValueAsString));
                                        }
                                    }
                                }
                            }

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Failed to convert spreadsheet to CSV ({0}).", ex.Message), ex);
                }
            }

            return worksheetFound;
        }

        private static int GetMaxUsedColumnIndex(Bytescout.Spreadsheet.Worksheet sheet)
        {
            for (int columnIndex = 0; columnIndex <= sheet.UsedRangeColumnMax; columnIndex++)
            {
                if (sheet.Cell(0, columnIndex).Value == null)
                {
                    return columnIndex - 1;
                }
            }

            return sheet.UsedRangeColumnMax;
        }

        private static string TranslateNumberFormatString(Bytescout.Spreadsheet.Cell cell)
        {
            string newFormatString;

            switch (cell.NumberFormatString)
            {
                case "HH:MM:SS":
                    newFormatString = "HH:mm:ss";
                    break;
                case "MM:SS":
                    newFormatString = "mm:ss";
                    break;
                case "MM:SS.0":
                    newFormatString = "mm:ss.f";
                    break;
                case "MM:SS.00":
                    newFormatString = "mm:ss.ff";
                    break;
                default:
                    newFormatString = cell.NumberFormatString;
                    break;
            }

            return newFormatString;
        }

        private static string EscapeCsvValue(string value)
        {
            string escapedValue;

            if (value.Contains("\""))
            {
                escapedValue = value.Replace("\"", "\"\"");
                escapedValue = "\"" + escapedValue + "\"";
            }
            else
            {
                if (value.Contains(","))
                {
                    escapedValue = "\"" + value + "\"";
                }
                else
                {
                    escapedValue = value;
                }
            }

            return escapedValue;
        }
    }
}
