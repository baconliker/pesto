namespace ColinBaker.Pesto.UI.Results
{
    partial class NationResultsForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.teamTabControl = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.publishedTimePicker = new System.Windows.Forms.DateTimePicker();
            this.publishedDatePicker = new System.Windows.Forms.DateTimePicker();
            this.publishedLabel = new System.Windows.Forms.Label();
            this.columnsTabPage = new System.Windows.Forms.TabPage();
            this.columnsControl = new ColinBaker.Pesto.UI.Results.ResultsColumnsControl();
            this.teamTabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.columnsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(645, 477);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(142, 37);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(494, 477);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(142, 37);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // teamTabControl
            // 
            this.teamTabControl.Controls.Add(this.generalTabPage);
            this.teamTabControl.Controls.Add(this.columnsTabPage);
            this.teamTabControl.Location = new System.Drawing.Point(18, 18);
            this.teamTabControl.Name = "teamTabControl";
            this.teamTabControl.SelectedIndex = 0;
            this.teamTabControl.Size = new System.Drawing.Size(769, 442);
            this.teamTabControl.TabIndex = 8;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.publishedTimePicker);
            this.generalTabPage.Controls.Add(this.publishedDatePicker);
            this.generalTabPage.Controls.Add(this.publishedLabel);
            this.generalTabPage.Location = new System.Drawing.Point(4, 29);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(761, 409);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // publishedTimePicker
            // 
            this.publishedTimePicker.CustomFormat = "HH:mm";
            this.publishedTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.publishedTimePicker.Location = new System.Drawing.Point(228, 50);
            this.publishedTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.publishedTimePicker.Name = "publishedTimePicker";
            this.publishedTimePicker.ShowUpDown = true;
            this.publishedTimePicker.Size = new System.Drawing.Size(109, 26);
            this.publishedTimePicker.TabIndex = 10;
            // 
            // publishedDatePicker
            // 
            this.publishedDatePicker.CustomFormat = "";
            this.publishedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.publishedDatePicker.Location = new System.Drawing.Point(12, 50);
            this.publishedDatePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.publishedDatePicker.Name = "publishedDatePicker";
            this.publishedDatePicker.Size = new System.Drawing.Size(190, 26);
            this.publishedDatePicker.TabIndex = 9;
            // 
            // publishedLabel
            // 
            this.publishedLabel.AutoSize = true;
            this.publishedLabel.Location = new System.Drawing.Point(7, 25);
            this.publishedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.publishedLabel.Name = "publishedLabel";
            this.publishedLabel.Size = new System.Drawing.Size(82, 20);
            this.publishedLabel.TabIndex = 8;
            this.publishedLabel.Text = "Published:";
            // 
            // columnsTabPage
            // 
            this.columnsTabPage.Controls.Add(this.columnsControl);
            this.columnsTabPage.Location = new System.Drawing.Point(4, 29);
            this.columnsTabPage.Name = "columnsTabPage";
            this.columnsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.columnsTabPage.Size = new System.Drawing.Size(761, 409);
            this.columnsTabPage.TabIndex = 1;
            this.columnsTabPage.Text = "Columns";
            this.columnsTabPage.UseVisualStyleBackColor = true;
            // 
            // columnsControl
            // 
            this.columnsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.columnsControl.Location = new System.Drawing.Point(9, 11);
            this.columnsControl.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.columnsControl.Name = "columnsControl";
            this.columnsControl.Size = new System.Drawing.Size(743, 390);
            this.columnsControl.TabIndex = 6;
            // 
            // NationResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 532);
            this.Controls.Add(this.teamTabControl);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NationResultsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nation Results";
            this.teamTabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.columnsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabControl teamTabControl;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabPage columnsTabPage;
        private ResultsColumnsControl columnsControl;
        private System.Windows.Forms.DateTimePicker publishedTimePicker;
        private System.Windows.Forms.DateTimePicker publishedDatePicker;
        private System.Windows.Forms.Label publishedLabel;
    }
}