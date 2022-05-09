namespace ColinBaker.Pesto.UI.Results
{
    partial class TaskResultsForm
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
			this.taskTabControl = new System.Windows.Forms.TabControl();
			this.generalTabPage = new System.Windows.Forms.TabPage();
			this.autoCalculateDeadlineCheckBox = new System.Windows.Forms.CheckBox();
			this.deadlineTimePicker = new System.Windows.Forms.DateTimePicker();
			this.deadlineDatePicker = new System.Windows.Forms.DateTimePicker();
			this.deadlineLabel = new System.Windows.Forms.Label();
			this.publishedTimePicker = new System.Windows.Forms.DateTimePicker();
			this.publishedDatePicker = new System.Windows.Forms.DateTimePicker();
			this.publishedLabel = new System.Windows.Forms.Label();
			this.statusComboBox = new System.Windows.Forms.ComboBox();
			this.statusLabel = new System.Windows.Forms.Label();
			this.columnsTabPage = new System.Windows.Forms.TabPage();
			this.columnsControl = new ColinBaker.Pesto.UI.Results.ResultsColumnsControl();
			this.taskTabControl.SuspendLayout();
			this.generalTabPage.SuspendLayout();
			this.columnsTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(422, 344);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(95, 24);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(321, 344);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(95, 24);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// taskTabControl
			// 
			this.taskTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.taskTabControl.Controls.Add(this.generalTabPage);
			this.taskTabControl.Controls.Add(this.columnsTabPage);
			this.taskTabControl.Location = new System.Drawing.Point(12, 12);
			this.taskTabControl.Name = "taskTabControl";
			this.taskTabControl.SelectedIndex = 0;
			this.taskTabControl.Size = new System.Drawing.Size(505, 319);
			this.taskTabControl.TabIndex = 0;
			// 
			// generalTabPage
			// 
			this.generalTabPage.Controls.Add(this.autoCalculateDeadlineCheckBox);
			this.generalTabPage.Controls.Add(this.deadlineTimePicker);
			this.generalTabPage.Controls.Add(this.deadlineDatePicker);
			this.generalTabPage.Controls.Add(this.deadlineLabel);
			this.generalTabPage.Controls.Add(this.publishedTimePicker);
			this.generalTabPage.Controls.Add(this.publishedDatePicker);
			this.generalTabPage.Controls.Add(this.publishedLabel);
			this.generalTabPage.Controls.Add(this.statusComboBox);
			this.generalTabPage.Controls.Add(this.statusLabel);
			this.generalTabPage.Location = new System.Drawing.Point(4, 22);
			this.generalTabPage.Name = "generalTabPage";
			this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.generalTabPage.Size = new System.Drawing.Size(497, 293);
			this.generalTabPage.TabIndex = 0;
			this.generalTabPage.Text = "General";
			this.generalTabPage.UseVisualStyleBackColor = true;
			// 
			// autoCalculateDeadlineCheckBox
			// 
			this.autoCalculateDeadlineCheckBox.AutoSize = true;
			this.autoCalculateDeadlineCheckBox.Checked = true;
			this.autoCalculateDeadlineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoCalculateDeadlineCheckBox.Location = new System.Drawing.Point(9, 115);
			this.autoCalculateDeadlineCheckBox.Name = "autoCalculateDeadlineCheckBox";
			this.autoCalculateDeadlineCheckBox.Size = new System.Drawing.Size(262, 17);
			this.autoCalculateDeadlineCheckBox.TabIndex = 5;
			this.autoCalculateDeadlineCheckBox.Text = "Automatically calculate complaint/protest deadline";
			this.autoCalculateDeadlineCheckBox.UseVisualStyleBackColor = true;
			this.autoCalculateDeadlineCheckBox.CheckedChanged += new System.EventHandler(this.autoCalculateDeadlineCheckBox_CheckedChanged);
			// 
			// deadlineTimePicker
			// 
			this.deadlineTimePicker.CustomFormat = "HH:mm";
			this.deadlineTimePicker.Enabled = false;
			this.deadlineTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.deadlineTimePicker.Location = new System.Drawing.Point(153, 154);
			this.deadlineTimePicker.Name = "deadlineTimePicker";
			this.deadlineTimePicker.ShowUpDown = true;
			this.deadlineTimePicker.Size = new System.Drawing.Size(74, 20);
			this.deadlineTimePicker.TabIndex = 8;
			// 
			// deadlineDatePicker
			// 
			this.deadlineDatePicker.CustomFormat = "";
			this.deadlineDatePicker.Enabled = false;
			this.deadlineDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.deadlineDatePicker.Location = new System.Drawing.Point(9, 154);
			this.deadlineDatePicker.Name = "deadlineDatePicker";
			this.deadlineDatePicker.Size = new System.Drawing.Size(128, 20);
			this.deadlineDatePicker.TabIndex = 7;
			// 
			// deadlineLabel
			// 
			this.deadlineLabel.AutoSize = true;
			this.deadlineLabel.Location = new System.Drawing.Point(6, 138);
			this.deadlineLabel.Name = "deadlineLabel";
			this.deadlineLabel.Size = new System.Drawing.Size(52, 13);
			this.deadlineLabel.TabIndex = 6;
			this.deadlineLabel.Text = "Deadline:";
			// 
			// publishedTimePicker
			// 
			this.publishedTimePicker.CustomFormat = "HH:mm";
			this.publishedTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.publishedTimePicker.Location = new System.Drawing.Point(153, 80);
			this.publishedTimePicker.Name = "publishedTimePicker";
			this.publishedTimePicker.ShowUpDown = true;
			this.publishedTimePicker.Size = new System.Drawing.Size(74, 20);
			this.publishedTimePicker.TabIndex = 4;
			this.publishedTimePicker.ValueChanged += new System.EventHandler(this.publishedTimePicker_ValueChanged);
			// 
			// publishedDatePicker
			// 
			this.publishedDatePicker.CustomFormat = "";
			this.publishedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.publishedDatePicker.Location = new System.Drawing.Point(9, 80);
			this.publishedDatePicker.Name = "publishedDatePicker";
			this.publishedDatePicker.Size = new System.Drawing.Size(128, 20);
			this.publishedDatePicker.TabIndex = 3;
			this.publishedDatePicker.ValueChanged += new System.EventHandler(this.publishedDatePicker_ValueChanged);
			// 
			// publishedLabel
			// 
			this.publishedLabel.AutoSize = true;
			this.publishedLabel.Location = new System.Drawing.Point(6, 64);
			this.publishedLabel.Name = "publishedLabel";
			this.publishedLabel.Size = new System.Drawing.Size(56, 13);
			this.publishedLabel.TabIndex = 2;
			this.publishedLabel.Text = "Published:";
			// 
			// statusComboBox
			// 
			this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.statusComboBox.FormattingEnabled = true;
			this.statusComboBox.Location = new System.Drawing.Point(9, 29);
			this.statusComboBox.Name = "statusComboBox";
			this.statusComboBox.Size = new System.Drawing.Size(172, 21);
			this.statusComboBox.TabIndex = 1;
			this.statusComboBox.SelectedIndexChanged += new System.EventHandler(this.statusComboBox_SelectedIndexChanged);
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(6, 13);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(40, 13);
			this.statusLabel.TabIndex = 0;
			this.statusLabel.Text = "Status:";
			// 
			// columnsTabPage
			// 
			this.columnsTabPage.Controls.Add(this.columnsControl);
			this.columnsTabPage.Location = new System.Drawing.Point(4, 22);
			this.columnsTabPage.Name = "columnsTabPage";
			this.columnsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.columnsTabPage.Size = new System.Drawing.Size(497, 293);
			this.columnsTabPage.TabIndex = 1;
			this.columnsTabPage.Text = "Columns";
			this.columnsTabPage.UseVisualStyleBackColor = true;
			// 
			// columnsControl
			// 
			this.columnsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.columnsControl.Location = new System.Drawing.Point(6, 6);
			this.columnsControl.Name = "columnsControl";
			this.columnsControl.Size = new System.Drawing.Size(485, 281);
			this.columnsControl.TabIndex = 0;
			// 
			// TaskResultsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(529, 380);
			this.Controls.Add(this.taskTabControl);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TaskResultsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Task Results";
			this.taskTabControl.ResumeLayout(false);
			this.generalTabPage.ResumeLayout(false);
			this.generalTabPage.PerformLayout();
			this.columnsTabPage.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.TabControl taskTabControl;
		private System.Windows.Forms.TabPage generalTabPage;
		private System.Windows.Forms.TabPage columnsTabPage;
		private System.Windows.Forms.CheckBox autoCalculateDeadlineCheckBox;
		private System.Windows.Forms.DateTimePicker deadlineTimePicker;
		private System.Windows.Forms.DateTimePicker deadlineDatePicker;
		private System.Windows.Forms.Label deadlineLabel;
		private System.Windows.Forms.DateTimePicker publishedTimePicker;
		private System.Windows.Forms.DateTimePicker publishedDatePicker;
		private System.Windows.Forms.Label publishedLabel;
		private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label statusLabel;
        private ResultsColumnsControl columnsControl;
    }
}