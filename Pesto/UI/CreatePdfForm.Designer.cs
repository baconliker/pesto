namespace ColinBaker.Pesto.UI
{
    partial class CreatePdfForm
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
            this.inputFilePathLabel = new System.Windows.Forms.Label();
            this.inputFilePathTextBox = new System.Windows.Forms.TextBox();
            this.stylesheetFilePathLabel = new System.Windows.Forms.Label();
            this.stylesheetFilePathTextBox = new System.Windows.Forms.TextBox();
            this.outputFilePathLabel = new System.Windows.Forms.Label();
            this.outputFilePathTextBox = new System.Windows.Forms.TextBox();
            this.chooseInputFileButton = new System.Windows.Forms.Button();
            this.stylesheetFileButton = new System.Windows.Forms.Button();
            this.outputFileButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.inputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.stylesheetFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.outputFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openPdfCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // inputFilePathLabel
            // 
            this.inputFilePathLabel.AutoSize = true;
            this.inputFilePathLabel.Location = new System.Drawing.Point(12, 18);
            this.inputFilePathLabel.Name = "inputFilePathLabel";
            this.inputFilePathLabel.Size = new System.Drawing.Size(59, 13);
            this.inputFilePathLabel.TabIndex = 0;
            this.inputFilePathLabel.Text = "Input XML:";
            // 
            // inputFilePathTextBox
            // 
            this.inputFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFilePathTextBox.Location = new System.Drawing.Point(12, 34);
            this.inputFilePathTextBox.Name = "inputFilePathTextBox";
            this.inputFilePathTextBox.Size = new System.Drawing.Size(411, 20);
            this.inputFilePathTextBox.TabIndex = 1;
            // 
            // stylesheetFilePathLabel
            // 
            this.stylesheetFilePathLabel.AutoSize = true;
            this.stylesheetFilePathLabel.Location = new System.Drawing.Point(12, 68);
            this.stylesheetFilePathLabel.Name = "stylesheetFilePathLabel";
            this.stylesheetFilePathLabel.Size = new System.Drawing.Size(56, 13);
            this.stylesheetFilePathLabel.TabIndex = 3;
            this.stylesheetFilePathLabel.Text = "Stylesheet";
            // 
            // stylesheetFilePathTextBox
            // 
            this.stylesheetFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stylesheetFilePathTextBox.Location = new System.Drawing.Point(15, 84);
            this.stylesheetFilePathTextBox.Name = "stylesheetFilePathTextBox";
            this.stylesheetFilePathTextBox.Size = new System.Drawing.Size(408, 20);
            this.stylesheetFilePathTextBox.TabIndex = 4;
            // 
            // outputFilePathLabel
            // 
            this.outputFilePathLabel.AutoSize = true;
            this.outputFilePathLabel.Location = new System.Drawing.Point(12, 121);
            this.outputFilePathLabel.Name = "outputFilePathLabel";
            this.outputFilePathLabel.Size = new System.Drawing.Size(63, 13);
            this.outputFilePathLabel.TabIndex = 6;
            this.outputFilePathLabel.Text = "Output PDF";
            // 
            // outputFilePathTextBox
            // 
            this.outputFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFilePathTextBox.Location = new System.Drawing.Point(15, 137);
            this.outputFilePathTextBox.Name = "outputFilePathTextBox";
            this.outputFilePathTextBox.Size = new System.Drawing.Size(408, 20);
            this.outputFilePathTextBox.TabIndex = 7;
            // 
            // chooseInputFileButton
            // 
            this.chooseInputFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseInputFileButton.Location = new System.Drawing.Point(429, 31);
            this.chooseInputFileButton.Name = "chooseInputFileButton";
            this.chooseInputFileButton.Size = new System.Drawing.Size(73, 24);
            this.chooseInputFileButton.TabIndex = 2;
            this.chooseInputFileButton.Text = "Choose...";
            this.chooseInputFileButton.UseVisualStyleBackColor = true;
            this.chooseInputFileButton.Click += new System.EventHandler(this.chooseInputFileButton_Click);
            // 
            // stylesheetFileButton
            // 
            this.stylesheetFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stylesheetFileButton.Location = new System.Drawing.Point(429, 81);
            this.stylesheetFileButton.Name = "stylesheetFileButton";
            this.stylesheetFileButton.Size = new System.Drawing.Size(73, 24);
            this.stylesheetFileButton.TabIndex = 5;
            this.stylesheetFileButton.Text = "Choose...";
            this.stylesheetFileButton.UseVisualStyleBackColor = true;
            this.stylesheetFileButton.Click += new System.EventHandler(this.stylesheetFileButton_Click);
            // 
            // outputFileButton
            // 
            this.outputFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFileButton.Location = new System.Drawing.Point(429, 134);
            this.outputFileButton.Name = "outputFileButton";
            this.outputFileButton.Size = new System.Drawing.Size(73, 24);
            this.outputFileButton.TabIndex = 8;
            this.outputFileButton.Text = "Choose...";
            this.outputFileButton.UseVisualStyleBackColor = true;
            this.outputFileButton.Click += new System.EventHandler(this.outputFileButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(407, 211);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 24);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(306, 211);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(95, 24);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // inputFileDialog
            // 
            this.inputFileDialog.Filter = "XML Files|*.xml";
            this.inputFileDialog.Title = "Select Input File";
            // 
            // stylesheetFileDialog
            // 
            this.stylesheetFileDialog.Filter = "Stylesheet Files|*.xsl";
            this.stylesheetFileDialog.Title = "Select Stylesheet File";
            // 
            // outputFileDialog
            // 
            this.outputFileDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            this.outputFileDialog.Title = "Choose Output File";
            // 
            // openPdfCheckBox
            // 
            this.openPdfCheckBox.AutoSize = true;
            this.openPdfCheckBox.Checked = true;
            this.openPdfCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openPdfCheckBox.Location = new System.Drawing.Point(15, 177);
            this.openPdfCheckBox.Name = "openPdfCheckBox";
            this.openPdfCheckBox.Size = new System.Drawing.Size(141, 17);
            this.openPdfCheckBox.TabIndex = 11;
            this.openPdfCheckBox.Text = "Open PDF after creation";
            this.openPdfCheckBox.UseVisualStyleBackColor = true;
            // 
            // CreatePdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 247);
            this.Controls.Add(this.openPdfCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.outputFileButton);
            this.Controls.Add(this.stylesheetFileButton);
            this.Controls.Add(this.chooseInputFileButton);
            this.Controls.Add(this.outputFilePathTextBox);
            this.Controls.Add(this.outputFilePathLabel);
            this.Controls.Add(this.stylesheetFilePathTextBox);
            this.Controls.Add(this.stylesheetFilePathLabel);
            this.Controls.Add(this.inputFilePathTextBox);
            this.Controls.Add(this.inputFilePathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatePdfForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputFilePathLabel;
        private System.Windows.Forms.TextBox inputFilePathTextBox;
        private System.Windows.Forms.Label stylesheetFilePathLabel;
        private System.Windows.Forms.TextBox stylesheetFilePathTextBox;
        private System.Windows.Forms.Label outputFilePathLabel;
        private System.Windows.Forms.TextBox outputFilePathTextBox;
        private System.Windows.Forms.Button chooseInputFileButton;
        private System.Windows.Forms.Button stylesheetFileButton;
        private System.Windows.Forms.Button outputFileButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.OpenFileDialog inputFileDialog;
        private System.Windows.Forms.OpenFileDialog stylesheetFileDialog;
        private System.Windows.Forms.SaveFileDialog outputFileDialog;
        private System.Windows.Forms.CheckBox openPdfCheckBox;
    }
}