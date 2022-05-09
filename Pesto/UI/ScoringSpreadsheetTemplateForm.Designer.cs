namespace ColinBaker.Pesto.UI
{
    partial class ScoringSpreadsheetTemplateForm
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
            this.templatesListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.useBuiltInTemplateRadioButton = new System.Windows.Forms.RadioButton();
            this.useExistingSpreadsheetRadioButton = new System.Windows.Forms.RadioButton();
            this.existingSpreadsheetTextBox = new System.Windows.Forms.TextBox();
            this.chooseExistingSpreadsheetButton = new System.Windows.Forms.Button();
            this.chooseExistingSpreadsheetOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // templatesListBox
            // 
            this.templatesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templatesListBox.FormattingEnabled = true;
            this.templatesListBox.ItemHeight = 20;
            this.templatesListBox.Location = new System.Drawing.Point(49, 55);
            this.templatesListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.templatesListBox.Name = "templatesListBox";
            this.templatesListBox.Size = new System.Drawing.Size(722, 264);
            this.templatesListBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(629, 441);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(142, 37);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(478, 441);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(142, 37);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // useBuiltInTemplateRadioButton
            // 
            this.useBuiltInTemplateRadioButton.AutoSize = true;
            this.useBuiltInTemplateRadioButton.Checked = true;
            this.useBuiltInTemplateRadioButton.Location = new System.Drawing.Point(19, 23);
            this.useBuiltInTemplateRadioButton.Name = "useBuiltInTemplateRadioButton";
            this.useBuiltInTemplateRadioButton.Size = new System.Drawing.Size(183, 24);
            this.useBuiltInTemplateRadioButton.TabIndex = 13;
            this.useBuiltInTemplateRadioButton.TabStop = true;
            this.useBuiltInTemplateRadioButton.Text = "Use built-in template:";
            this.useBuiltInTemplateRadioButton.UseVisualStyleBackColor = true;
            this.useBuiltInTemplateRadioButton.CheckedChanged += new System.EventHandler(this.useBuiltInTemplateRadioButton_CheckedChanged);
            // 
            // useExistingSpreadsheetRadioButton
            // 
            this.useExistingSpreadsheetRadioButton.AutoSize = true;
            this.useExistingSpreadsheetRadioButton.Location = new System.Drawing.Point(19, 343);
            this.useExistingSpreadsheetRadioButton.Name = "useExistingSpreadsheetRadioButton";
            this.useExistingSpreadsheetRadioButton.Size = new System.Drawing.Size(666, 24);
            this.useExistingSpreadsheetRadioButton.TabIndex = 14;
            this.useExistingSpreadsheetRadioButton.Text = "Use existing spreadsheet (the spreadsheet will be copied, the original will not b" +
    "e modified):";
            this.useExistingSpreadsheetRadioButton.UseVisualStyleBackColor = true;
            this.useExistingSpreadsheetRadioButton.CheckedChanged += new System.EventHandler(this.useExistingSpreadsheetRadioButton_CheckedChanged);
            // 
            // existingSpreadsheetTextBox
            // 
            this.existingSpreadsheetTextBox.Location = new System.Drawing.Point(49, 373);
            this.existingSpreadsheetTextBox.Name = "existingSpreadsheetTextBox";
            this.existingSpreadsheetTextBox.ReadOnly = true;
            this.existingSpreadsheetTextBox.Size = new System.Drawing.Size(571, 26);
            this.existingSpreadsheetTextBox.TabIndex = 15;
            // 
            // chooseExistingSpreadsheetButton
            // 
            this.chooseExistingSpreadsheetButton.Location = new System.Drawing.Point(629, 369);
            this.chooseExistingSpreadsheetButton.Name = "chooseExistingSpreadsheetButton";
            this.chooseExistingSpreadsheetButton.Size = new System.Drawing.Size(142, 34);
            this.chooseExistingSpreadsheetButton.TabIndex = 16;
            this.chooseExistingSpreadsheetButton.Text = "Choose...";
            this.chooseExistingSpreadsheetButton.UseVisualStyleBackColor = true;
            this.chooseExistingSpreadsheetButton.Click += new System.EventHandler(this.chooseExistingSpreadsheetButton_Click);
            // 
            // chooseExistingSpreadsheetOpenFileDialog
            // 
            this.chooseExistingSpreadsheetOpenFileDialog.Filter = "Spreadsheets|*.xlsx;*.xls;*.ods";
            this.chooseExistingSpreadsheetOpenFileDialog.Title = "Choose Existing Spreadsheet";
            // 
            // ScoringSpreadsheetTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 497);
            this.Controls.Add(this.chooseExistingSpreadsheetButton);
            this.Controls.Add(this.existingSpreadsheetTextBox);
            this.Controls.Add(this.useExistingSpreadsheetRadioButton);
            this.Controls.Add(this.useBuiltInTemplateRadioButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.templatesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScoringSpreadsheetTemplateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Scoring Spreadsheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox templatesListBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RadioButton useBuiltInTemplateRadioButton;
        private System.Windows.Forms.RadioButton useExistingSpreadsheetRadioButton;
        private System.Windows.Forms.TextBox existingSpreadsheetTextBox;
        private System.Windows.Forms.Button chooseExistingSpreadsheetButton;
        private System.Windows.Forms.OpenFileDialog chooseExistingSpreadsheetOpenFileDialog;
    }
}