using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.Results
{
    partial class OverallResultsForm : Form
    {
        public OverallResultsForm(Models.Results.OverallResults results)
        {
            InitializeComponent();

            this.Results = results;

            this.Text += string.Format(" ({0})", this.Results.AircraftClass.Code);

            publishedDatePicker.Value = results.Published;
            publishedTimePicker.Value = results.Published;

            columnsControl.Populate(this.Results.Data);
        }

        public Models.Results.OverallResults Results { get; set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            columnsControl.Extract(this.Results.Data);

            this.Cursor = Cursors.WaitCursor;

            try
            {
                Models.ColumnWidthCalculator calculator = new Models.ColumnWidthCalculator();

                bool proceed = true;

                if (this.Results.Data.Rows.Count > 0)
                {
                    if (calculator.Calculate(this.Results.Data))
                    {
                        this.Results.FontSize = calculator.FontSizeUsed;
                    }
                    else
                    {
                        MessageBox.Show("Unable to size columns.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        proceed = false;
                    }
                }

                if (proceed)
                {
                    this.Results.Published = Utils.BuildDateTime(publishedDatePicker, publishedTimePicker);

                    this.Results.Save();
                    this.Results.Publish();
                }
                else
                {
                    // Prevent dialog from closing
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
