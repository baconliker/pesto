using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI
{
	partial class ColumnMappingForm : Form
	{
        public ColumnMappingForm(Models.Spreadsheets.Spreadsheet spreadsheet, Models.Competition competition) : this(spreadsheet, competition.AircraftClasses[0])
        {
        }

        public ColumnMappingForm(Models.Spreadsheets.Spreadsheet spreadsheet, Models.Task task) : this(spreadsheet, task.Results[0].AircraftClass)
        {
        }

        private ColumnMappingForm(Models.Spreadsheets.Spreadsheet spreadsheet, Models.AircraftClass aircraftClass)
        {
			InitializeComponent();

			this.Spreadsheet = spreadsheet;

			DataGridViewComboBoxColumn columnNameColumn = (DataGridViewComboBoxColumn)mappingsDataGridView.Columns["ColumnNameColumn"];

			columnNameColumn.Items.Add("");
            foreach (string columnName in spreadsheet.GetColumnNames(aircraftClass.Code))
            {
                columnNameColumn.Items.Add(columnName);
            }

            foreach (Models.Spreadsheets.SpreadsheetColumnMapping mapping in this.Spreadsheet.Mappings)
			{
				object[] row = new object[3];

				row[0] = mapping.ColumnType;
				row[1] = mapping.Required;
				row[2] = mapping.ColumnName;

				int rowIndex = mappingsDataGridView.Rows.Add(row);

				mappingsDataGridView.Rows[rowIndex].Tag = mapping;
			}
		}

		public Models.Spreadsheets.Spreadsheet Spreadsheet { get; set; }

		private bool ValidateMappings()
		{
			foreach (DataGridViewRow row in mappingsDataGridView.Rows)
			{
				bool required = (bool)row.Cells["RequiredColumn"].Value;
				string columnName = (string)row.Cells["ColumnNameColumn"].Value;

				if (required && string.IsNullOrEmpty(columnName))
				{
					MessageBox.Show("Please select a column for mapping " + row.Cells["TypeColumn"].Value.ToString() + ".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}

			return true;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (ValidateMappings())
			{
				foreach (DataGridViewRow row in mappingsDataGridView.Rows)
				{
					Models.Spreadsheets.SpreadsheetColumnMapping mapping = row.Tag as Models.Spreadsheets.SpreadsheetColumnMapping;

					mapping.ColumnName = (string)row.Cells["ColumnNameColumn"].Value;
				}
			}
			else
			{
				// Prevent dialog from closing
				this.DialogResult = System.Windows.Forms.DialogResult.None;
			}
		}

		private void mappingsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			if (e.ColumnIndex == mappingsDataGridView.Columns["ColumnNameColumn"].Index)
			{
				// The data grid will raise an error if the value in the cell does not match one of the values in the drop down
				// Since this situation can occur we set this property to prevent the exception being raised
				e.ThrowException = false;

				// Clear the column name so that the mapping hasn't been set
				mappingsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
			}
		}
	}
}
