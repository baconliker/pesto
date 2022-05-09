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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();

            Services.SettingsStore store = new Services.SettingsStore();

            apacheFopFilePathTextBox.Text = store.FopPath;
            googleMapsApiKeyTextBox.Text = store.GoogleMapsApiKey;
            bytescoutSpreadsheetRegistrationNameTextBox.Text = store.BytescoutSpreadsheetRegistrationName;
            bytescoutSpreadsheetRegistrationKeyTextBox.Text = store.BytescoutSpreadsheetRegistrationKey;
        }

        private bool ValidateOptions()
        {
            if (apacheFopFilePathTextBox.Text.Length > 0)
            {
                if (!System.IO.File.Exists(apacheFopFilePathTextBox.Text))
                {
                    MessageBox.Show("Invalid Apache FOP File", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            return true;
        }

        private void chooseApacheFopFileButton_Click(object sender, EventArgs e)
        {
            if (apacheFopFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                apacheFopFilePathTextBox.Text = apacheFopFileDialog.FileName;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateOptions())
            {
                Services.SettingsStore store = new Services.SettingsStore();

                //store.FopPath = apacheFopFilePathTextBox.Text;
                store.GoogleMapsApiKey = googleMapsApiKeyTextBox.Text.Trim();
                store.BytescoutSpreadsheetRegistrationName = bytescoutSpreadsheetRegistrationNameTextBox.Text.Trim();
                store.BytescoutSpreadsheetRegistrationKey = bytescoutSpreadsheetRegistrationKeyTextBox.Text.Trim();
            }
            else
            {
                // Prevent dialog from closing
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
    }
}
