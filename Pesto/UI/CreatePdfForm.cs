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
    public partial class CreatePdfForm : Form
    {
        public CreatePdfForm()
        {
            InitializeComponent();
        }

        private bool ValidationPdfCreation()
        {
            if (!System.IO.File.Exists(inputFilePathTextBox.Text))
            {
                MessageBox.Show("Invalid input file", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!System.IO.File.Exists(stylesheetFilePathTextBox.Text))
            {
                MessageBox.Show("Invalid stylesheet file", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            System.IO.FileInfo outputFile = new System.IO.FileInfo(outputFilePathTextBox.Text);

            if (!outputFile.Directory.Exists)
            {
                MessageBox.Show("Invalid output directory", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void chooseInputFileButton_Click(object sender, EventArgs e)
        {
            if (inputFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                inputFilePathTextBox.Text = inputFileDialog.FileName;
            }
        }

        private void stylesheetFileButton_Click(object sender, EventArgs e)
        {
            if (stylesheetFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                stylesheetFilePathTextBox.Text = stylesheetFileDialog.FileName;
            }
        }

        private void outputFileButton_Click(object sender, EventArgs e)
        {
            if (outputFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputFilePathTextBox.Text = outputFileDialog.FileName;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidationPdfCreation())
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    Services.Pdf.PdfWriter writer = new Services.Pdf.PdfWriter();
                    writer.Write(inputFilePathTextBox.Text, stylesheetFilePathTextBox.Text, outputFilePathTextBox.Text);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                if (openPdfCheckBox.Checked)
                {
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(outputFilePathTextBox.Text);
                    startInfo.UseShellExecute = true;

                    using (System.Diagnostics.Process process = new System.Diagnostics.Process())
                    {
                        process.StartInfo = startInfo;
                        process.Start();
                    }
                }
            }
            else
            {
                // Prevent dialog from closing
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
    }
}
