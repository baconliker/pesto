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
    partial class NationResultsForm : Form
    {
        public NationResultsForm(Models.Results.NationResults results)
        {
            InitializeComponent();

            this.Results = results;

            publishedDatePicker.Value = results.Published;
            publishedTimePicker.Value = results.Published;

			columnsControl.Populate(this.Results.Data);
        }

        public Models.Results.NationResults Results { get; set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Apply column properties
            columnsControl.Extract(this.Results.Data);

            this.Cursor = Cursors.WaitCursor;

            try
            {
                Models.ColumnWidthCalculator calculator = new Models.ColumnWidthCalculator();

                bool proceed = false;

                if (this.Results.Data.Rows.Count > 0)
                {
                    if (calculator.Calculate(this.Results.Data))
                    {
                        this.Results.FontSize = calculator.FontSizeUsed;
                        proceed = true;
                    }
                    else
                    {
                        MessageBox.Show("Unable to size columns.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        proceed = false;
                    }
                }
                else
                {
                    proceed = true;
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
