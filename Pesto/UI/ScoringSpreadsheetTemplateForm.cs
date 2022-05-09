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
    public partial class ScoringSpreadsheetTemplateForm : Form
    {
        public ScoringSpreadsheetTemplateForm(string[] templateFilePaths)
        {
            InitializeComponent();

            foreach (string templateFilePath in templateFilePaths)
            {
                templatesListBox.Items.Add(new TemplateFileListItem(templateFilePath));
            }

            templatesListBox.SelectedIndex = 0;

            RefreshControlState();
        }

        public string SelectedTemplateFilePath { get; set; }

        private bool ValidateSpreadsheetTemplate()
        {
            if (useBuiltInTemplateRadioButton.Checked)
            {
                if (templatesListBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a template.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }
            else if (useExistingSpreadsheetRadioButton.Checked)
            {
                if (!System.IO.File.Exists(existingSpreadsheetTextBox.Text))
                {
                    MessageBox.Show("Please select an existing spreadsheet.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            return true;
        }

        private void RefreshControlState()
        {
            templatesListBox.Enabled = (useBuiltInTemplateRadioButton.Checked);

            existingSpreadsheetTextBox.Enabled = (useExistingSpreadsheetRadioButton.Checked);
            chooseExistingSpreadsheetButton.Enabled = (useExistingSpreadsheetRadioButton.Checked);
        }
        
        private void useBuiltInTemplateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControlState();
        }

        private void useExistingSpreadsheetRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControlState();
        }

        private void chooseExistingSpreadsheetButton_Click(object sender, EventArgs e)
        {
            if (chooseExistingSpreadsheetOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                existingSpreadsheetTextBox.Text = chooseExistingSpreadsheetOpenFileDialog.FileName;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateSpreadsheetTemplate())
            {
                if (useBuiltInTemplateRadioButton.Checked)
                {
                    this.SelectedTemplateFilePath = ((TemplateFileListItem)templatesListBox.SelectedItem).FilePath;
                }
                else if (useExistingSpreadsheetRadioButton.Checked)
                {
                    this.SelectedTemplateFilePath = existingSpreadsheetTextBox.Text;
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
