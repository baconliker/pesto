using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace ColinBaker.Pesto.Models
{
	class ColumnWidthCalculator
	{
		// TODO: Read these values from stylesheet?
		private const int m_maxFontSize = 10; // in pt
		private const int m_minFontSize = 7; // in pt
		private const float m_padding = 0.5f; // in mm
		private const float m_availableWidth = 287f; // in mm

		public bool Calculate(DataTable results)
		{
			bool successful = false;

			using (System.Drawing.Text.PrivateFontCollection fontCollection = new System.Drawing.Text.PrivateFontCollection())
			{
				// Load the font that's being used for the results from .ttf file. This means we don't have to install it
				//fontCollection.AddFontFile(System.Windows.Forms.Application.StartupPath + @"\Resources\Fonts\nina.ttf");
                fontCollection.AddFontFile(System.Windows.Forms.Application.StartupPath + @"\Resources\Fonts\tahoma.ttf");

                // Start at the largest font size and work down until we are able to fit the columns in the available width
                for (int fontSize = m_maxFontSize; fontSize >= m_minFontSize; fontSize--)
				{
                    for (int colSetting = 0; colSetting <= 1; colSetting++)
                    {
                        float[] columnWidths = TryFont(results, fontCollection.Families[0], fontSize, colSetting == 0 ? true : false);

                        float totalWidth = 0;
                        for (int i = 0; i < columnWidths.Length; i++)
                        {
                            totalWidth += columnWidths[i];
                        }

                        if (totalWidth <= m_availableWidth)
                        {
                            // We have successfully managed to fit the columns into the available width
                            // Now adjust the widths so that they take up all the available space

                            float difference = m_availableWidth - totalWidth;
                            float extraPerColumn = difference / GetVisibleColumnCount(results);

                            for (int i = 0; i < results.Columns.Count; i++)
                            {
                                bool visible = (bool)results.Columns[i].ExtendedProperties["Visible"];

                                if (visible)
                                {
                                    columnWidths[i] = columnWidths[i] + extraPerColumn;
                                }
                            }

                            // Store the widths in the results columns
                            for (int i = 0; i < results.Columns.Count; i++)
                            {
                                results.Columns[i].ExtendedProperties["Width"] = columnWidths[i];
                            }

                            this.FontSizeUsed = fontSize;

                            successful = true;
                            break;
                        }

                        if (successful) break;
                    }

                    if (successful) break;
				}
			}

			return successful;
		}

		public int FontSizeUsed { get; private set; }

		public static float[] TryFont(DataTable results, FontFamily fontFamily, int fontSize, bool entireColumnText)
		{
			float[] columnWidths = new float[results.Columns.Count];

			Font font = new Font(fontFamily, fontSize, FontStyle.Regular);

			Graphics graphics = Graphics.FromHwnd(System.Windows.Forms.Application.OpenForms[0].Handle);
			graphics.PageUnit = GraphicsUnit.Millimeter;

			for (int columnIndex = 0; columnIndex < results.Columns.Count; columnIndex++)
			{
                bool visible = (bool)results.Columns[columnIndex].ExtendedProperties["Visible"];

                if (visible)
                {
                    float maxColumnNameWidth;
                    if (entireColumnText)
                    {
                        maxColumnNameWidth = GetTextWidth((string)results.Columns[columnIndex].ExtendedProperties["DisplayName"], font, graphics);
                    }
                    else
                    {
                        maxColumnNameWidth = GetMaxWordWidth((string)results.Columns[columnIndex].ExtendedProperties["DisplayName"], font, graphics);
                    }
                    float maxColumnDataWidth = 0;

                    for (int rowIndex = 0; rowIndex < results.Rows.Count; rowIndex++)
                    {
                        float columnDataWidth = GetTextWidth(results.Rows[rowIndex][columnIndex].ToString(), font, graphics);

                        if (columnDataWidth > maxColumnDataWidth)
                        {
                            maxColumnDataWidth = columnDataWidth;
                        }
                    }

                    columnWidths[columnIndex] = maxColumnNameWidth > maxColumnDataWidth ? maxColumnNameWidth : maxColumnDataWidth;
                    // Add padding onto column width
                    columnWidths[columnIndex] += m_padding * 2;
                }
                else
                {
                    columnWidths[columnIndex] = 0;
                }
			}

			return columnWidths;
		}

		private static float GetMaxWordWidth(string text, Font font, Graphics graphics)
		{
			string[] words = text.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
			float maxWidth = 0;

			for (int i = 0; i < words.Length; i++)
			{
				float width = GetTextWidth(words[i], font, graphics);

				if (width > maxWidth)
				{
					maxWidth = width;
				}
			}

			return maxWidth;
		}

		private static float GetTextWidth(string text, Font font, Graphics graphics)
		{
			SizeF fontSize = graphics.MeasureString(text, font);

			return fontSize.Width;
		}

        private static int GetVisibleColumnCount(DataTable results)
        {
            int visibleColumnCount = 0;

            for (int i = 0; i < results.Columns.Count; i++)
            {
                bool visible = (bool)results.Columns[i].ExtendedProperties["Visible"];

                if (visible)
                {
                    visibleColumnCount++;
                }
            }

            return visibleColumnCount;
        }
	}
}
