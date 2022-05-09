namespace ColinBaker.Pesto.UI
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.apacheFopFilePathLabel = new System.Windows.Forms.Label();
			this.apacheFopFilePathTextBox = new System.Windows.Forms.TextBox();
			this.chooseApacheFopFileButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.apacheFopFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.googleMapsApiKeyLabel = new System.Windows.Forms.Label();
			this.googleMapsApiKeyTextBox = new System.Windows.Forms.TextBox();
			this.bytescoutSpreadsheetRegistrationNameLabel = new System.Windows.Forms.Label();
			this.bytescoutSpreadsheetRegistrationNameTextBox = new System.Windows.Forms.TextBox();
			this.bytescoutSpreadsheetRegistrationKeyTextBox = new System.Windows.Forms.TextBox();
			this.bytescoutSpreadsheetRegistrationKeyLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// apacheFopFilePathLabel
			// 
			this.apacheFopFilePathLabel.AutoSize = true;
			this.apacheFopFilePathLabel.Enabled = false;
			this.apacheFopFilePathLabel.Location = new System.Drawing.Point(12, 18);
			this.apacheFopFilePathLabel.Name = "apacheFopFilePathLabel";
			this.apacheFopFilePathLabel.Size = new System.Drawing.Size(71, 13);
			this.apacheFopFilePathLabel.TabIndex = 0;
			this.apacheFopFilePathLabel.Text = "Apache FOP:";
			// 
			// apacheFopFilePathTextBox
			// 
			this.apacheFopFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.apacheFopFilePathTextBox.Enabled = false;
			this.apacheFopFilePathTextBox.Location = new System.Drawing.Point(12, 34);
			this.apacheFopFilePathTextBox.Name = "apacheFopFilePathTextBox";
			this.apacheFopFilePathTextBox.Size = new System.Drawing.Size(386, 20);
			this.apacheFopFilePathTextBox.TabIndex = 1;
			// 
			// chooseApacheFopFileButton
			// 
			this.chooseApacheFopFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chooseApacheFopFileButton.Enabled = false;
			this.chooseApacheFopFileButton.Location = new System.Drawing.Point(404, 31);
			this.chooseApacheFopFileButton.Name = "chooseApacheFopFileButton";
			this.chooseApacheFopFileButton.Size = new System.Drawing.Size(73, 24);
			this.chooseApacheFopFileButton.TabIndex = 3;
			this.chooseApacheFopFileButton.Text = "Choose...";
			this.chooseApacheFopFileButton.UseVisualStyleBackColor = true;
			this.chooseApacheFopFileButton.Click += new System.EventHandler(this.chooseApacheFopFileButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(382, 244);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(95, 24);
			this.cancelButton.TabIndex = 12;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(281, 244);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(95, 24);
			this.okButton.TabIndex = 11;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// apacheFopFileDialog
			// 
			this.apacheFopFileDialog.Filter = "Apache FOP Files|*.bat";
			this.apacheFopFileDialog.Title = "Select Apache FOP";
			// 
			// googleMapsApiKeyLabel
			// 
			this.googleMapsApiKeyLabel.AutoSize = true;
			this.googleMapsApiKeyLabel.Location = new System.Drawing.Point(12, 66);
			this.googleMapsApiKeyLabel.Name = "googleMapsApiKeyLabel";
			this.googleMapsApiKeyLabel.Size = new System.Drawing.Size(113, 13);
			this.googleMapsApiKeyLabel.TabIndex = 13;
			this.googleMapsApiKeyLabel.Text = "Google Maps API key:";
			// 
			// googleMapsApiKeyTextBox
			// 
			this.googleMapsApiKeyTextBox.Location = new System.Drawing.Point(12, 82);
			this.googleMapsApiKeyTextBox.Name = "googleMapsApiKeyTextBox";
			this.googleMapsApiKeyTextBox.Size = new System.Drawing.Size(465, 20);
			this.googleMapsApiKeyTextBox.TabIndex = 14;
			// 
			// bytescoutSpreadsheetRegistrationNameLabel
			// 
			this.bytescoutSpreadsheetRegistrationNameLabel.AutoSize = true;
			this.bytescoutSpreadsheetRegistrationNameLabel.Location = new System.Drawing.Point(12, 117);
			this.bytescoutSpreadsheetRegistrationNameLabel.Name = "bytescoutSpreadsheetRegistrationNameLabel";
			this.bytescoutSpreadsheetRegistrationNameLabel.Size = new System.Drawing.Size(203, 13);
			this.bytescoutSpreadsheetRegistrationNameLabel.TabIndex = 15;
			this.bytescoutSpreadsheetRegistrationNameLabel.Text = "Bytescout Spreadsheet registration name:";
			// 
			// bytescoutSpreadsheetRegistrationNameTextBox
			// 
			this.bytescoutSpreadsheetRegistrationNameTextBox.Location = new System.Drawing.Point(12, 133);
			this.bytescoutSpreadsheetRegistrationNameTextBox.Name = "bytescoutSpreadsheetRegistrationNameTextBox";
			this.bytescoutSpreadsheetRegistrationNameTextBox.Size = new System.Drawing.Size(465, 20);
			this.bytescoutSpreadsheetRegistrationNameTextBox.TabIndex = 16;
			// 
			// bytescoutSpreadsheetRegistrationKeyTextBox
			// 
			this.bytescoutSpreadsheetRegistrationKeyTextBox.Location = new System.Drawing.Point(12, 179);
			this.bytescoutSpreadsheetRegistrationKeyTextBox.Name = "bytescoutSpreadsheetRegistrationKeyTextBox";
			this.bytescoutSpreadsheetRegistrationKeyTextBox.Size = new System.Drawing.Size(465, 20);
			this.bytescoutSpreadsheetRegistrationKeyTextBox.TabIndex = 18;
			// 
			// bytescoutSpreadsheetRegistrationKeyLabel
			// 
			this.bytescoutSpreadsheetRegistrationKeyLabel.AutoSize = true;
			this.bytescoutSpreadsheetRegistrationKeyLabel.Location = new System.Drawing.Point(12, 163);
			this.bytescoutSpreadsheetRegistrationKeyLabel.Name = "bytescoutSpreadsheetRegistrationKeyLabel";
			this.bytescoutSpreadsheetRegistrationKeyLabel.Size = new System.Drawing.Size(194, 13);
			this.bytescoutSpreadsheetRegistrationKeyLabel.TabIndex = 17;
			this.bytescoutSpreadsheetRegistrationKeyLabel.Text = "Bytescout Spreadsheet registration key:";
			// 
			// OptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 280);
			this.Controls.Add(this.bytescoutSpreadsheetRegistrationKeyTextBox);
			this.Controls.Add(this.bytescoutSpreadsheetRegistrationKeyLabel);
			this.Controls.Add(this.bytescoutSpreadsheetRegistrationNameTextBox);
			this.Controls.Add(this.bytescoutSpreadsheetRegistrationNameLabel);
			this.Controls.Add(this.googleMapsApiKeyTextBox);
			this.Controls.Add(this.googleMapsApiKeyLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.chooseApacheFopFileButton);
			this.Controls.Add(this.apacheFopFilePathTextBox);
			this.Controls.Add(this.apacheFopFilePathLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label apacheFopFilePathLabel;
        private System.Windows.Forms.TextBox apacheFopFilePathTextBox;
        private System.Windows.Forms.Button chooseApacheFopFileButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.OpenFileDialog apacheFopFileDialog;
		private System.Windows.Forms.Label googleMapsApiKeyLabel;
		private System.Windows.Forms.TextBox googleMapsApiKeyTextBox;
		private System.Windows.Forms.Label bytescoutSpreadsheetRegistrationNameLabel;
		private System.Windows.Forms.TextBox bytescoutSpreadsheetRegistrationNameTextBox;
		private System.Windows.Forms.TextBox bytescoutSpreadsheetRegistrationKeyTextBox;
		private System.Windows.Forms.Label bytescoutSpreadsheetRegistrationKeyLabel;
	}
}