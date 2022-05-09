using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.Results
{
    public partial class ResultsColumnsControl : UserControl
    {
        public ResultsColumnsControl()
        {
            InitializeComponent();

            ColumnAlignmentListItem[] alignmentListItems = new ColumnAlignmentListItem[] { new ColumnAlignmentListItem(Models.Column.ColumnAlignment.Left), new ColumnAlignmentListItem(Models.Column.ColumnAlignment.Center), new ColumnAlignmentListItem(Models.Column.ColumnAlignment.Right) };

            DataGridViewComboBoxColumn alignColumn = (DataGridViewComboBoxColumn)columnsDataGridView.Columns["AlignColumn"];
            alignColumn.DataSource = alignmentListItems;
            alignColumn.ValueMember = "Align";
            alignColumn.DisplayMember = "Description";
        }

        public void Populate(DataTable data)
        {
            foreach (DataColumn column in data.Columns)
            {
                object[] row = new object[5];

                row[0] = column.ExtendedProperties["Visible"];
                row[1] = column.ColumnName;
                row[2] = column.ExtendedProperties["DisplayName"];
                row[3] = column.ExtendedProperties["Align"];
                row[4] = column.ExtendedProperties["Bold"];

                int rowIndex = columnsDataGridView.Rows.Add(row);
            }
        }

        public void Extract(DataTable data)
        {
            foreach (DataGridViewRow row in columnsDataGridView.Rows)
            {
                string columnName = (string)row.Cells["NameColumn"].Value;

                DataColumn column = data.Columns[columnName];

                column.ExtendedProperties["Visible"] = (bool)row.Cells["VisibleColumn"].Value;
                column.ExtendedProperties["DisplayName"] = (string)row.Cells["DisplayNameColumn"].Value;
                column.ExtendedProperties["Align"] = (Models.Column.ColumnAlignment)row.Cells["AlignColumn"].Value;
                column.ExtendedProperties["Bold"] = (bool)row.Cells["BoldColumn"].Value;
            }
        }
    }
}
