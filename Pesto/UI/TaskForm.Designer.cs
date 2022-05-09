namespace ColinBaker.Pesto.UI
{
	partial class TaskForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.launchOpenTimePicker = new System.Windows.Forms.DateTimePicker();
            this.launchOpenDatePicker = new System.Windows.Forms.DateTimePicker();
            this.launchOpenLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.launchCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.launchCloseTimePicker = new System.Windows.Forms.DateTimePicker();
            this.launchCloseDatePicker = new System.Windows.Forms.DateTimePicker();
            this.landByTimePicker = new System.Windows.Forms.DateTimePicker();
            this.landByDatePicker = new System.Windows.Forms.DateTimePicker();
            this.landByCheckBox = new System.Windows.Forms.CheckBox();
            this.abbreviatedNameLabel = new System.Windows.Forms.Label();
            this.abbreviatedNameTextBox = new System.Windows.Forms.TextBox();
            this.aircraftClassesLabel = new System.Windows.Forms.Label();
            this.aircraftClassesDataGridView = new System.Windows.Forms.DataGridView();
            this.SelectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.aircraftClassesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(442, 685);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(142, 37);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(290, 685);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(142, 37);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // launchOpenTimePicker
            // 
            this.launchOpenTimePicker.CustomFormat = "HH:mm";
            this.launchOpenTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.launchOpenTimePicker.Location = new System.Drawing.Point(223, 463);
            this.launchOpenTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.launchOpenTimePicker.Name = "launchOpenTimePicker";
            this.launchOpenTimePicker.ShowUpDown = true;
            this.launchOpenTimePicker.Size = new System.Drawing.Size(102, 26);
            this.launchOpenTimePicker.TabIndex = 8;
            // 
            // launchOpenDatePicker
            // 
            this.launchOpenDatePicker.CustomFormat = "";
            this.launchOpenDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.launchOpenDatePicker.Location = new System.Drawing.Point(18, 463);
            this.launchOpenDatePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.launchOpenDatePicker.Name = "launchOpenDatePicker";
            this.launchOpenDatePicker.Size = new System.Drawing.Size(182, 26);
            this.launchOpenDatePicker.TabIndex = 7;
            // 
            // launchOpenLabel
            // 
            this.launchOpenLabel.AutoSize = true;
            this.launchOpenLabel.Location = new System.Drawing.Point(14, 439);
            this.launchOpenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.launchOpenLabel.Name = "launchOpenLabel";
            this.launchOpenLabel.Size = new System.Drawing.Size(106, 20);
            this.launchOpenLabel.TabIndex = 6;
            this.launchOpenLabel.Text = "Launch open:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(18, 166);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(307, 28);
            this.typeComboBox.TabIndex = 5;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(14, 142);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(47, 20);
            this.typeLabel.TabIndex = 4;
            this.typeLabel.Text = "Type:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(18, 106);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(299, 26);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(14, 81);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(55, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(18, 45);
            this.numberTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(84, 26);
            this.numberTextBox.TabIndex = 18;
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(14, 20);
            this.numberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(69, 20);
            this.numberLabel.TabIndex = 17;
            this.numberLabel.Text = "Number:";
            // 
            // launchCloseCheckBox
            // 
            this.launchCloseCheckBox.AutoSize = true;
            this.launchCloseCheckBox.Location = new System.Drawing.Point(18, 513);
            this.launchCloseCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.launchCloseCheckBox.Name = "launchCloseCheckBox";
            this.launchCloseCheckBox.Size = new System.Drawing.Size(133, 24);
            this.launchCloseCheckBox.TabIndex = 9;
            this.launchCloseCheckBox.Text = "Launch close:";
            this.launchCloseCheckBox.UseVisualStyleBackColor = true;
            this.launchCloseCheckBox.CheckedChanged += new System.EventHandler(this.launchCloseCheckBox_CheckedChanged);
            // 
            // launchCloseTimePicker
            // 
            this.launchCloseTimePicker.CustomFormat = "HH:mm";
            this.launchCloseTimePicker.Enabled = false;
            this.launchCloseTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.launchCloseTimePicker.Location = new System.Drawing.Point(223, 547);
            this.launchCloseTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.launchCloseTimePicker.Name = "launchCloseTimePicker";
            this.launchCloseTimePicker.ShowUpDown = true;
            this.launchCloseTimePicker.Size = new System.Drawing.Size(102, 26);
            this.launchCloseTimePicker.TabIndex = 11;
            // 
            // launchCloseDatePicker
            // 
            this.launchCloseDatePicker.CustomFormat = "";
            this.launchCloseDatePicker.Enabled = false;
            this.launchCloseDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.launchCloseDatePicker.Location = new System.Drawing.Point(18, 547);
            this.launchCloseDatePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.launchCloseDatePicker.Name = "launchCloseDatePicker";
            this.launchCloseDatePicker.Size = new System.Drawing.Size(182, 26);
            this.launchCloseDatePicker.TabIndex = 10;
            // 
            // landByTimePicker
            // 
            this.landByTimePicker.CustomFormat = "HH:mm";
            this.landByTimePicker.Enabled = false;
            this.landByTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.landByTimePicker.Location = new System.Drawing.Point(223, 630);
            this.landByTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.landByTimePicker.Name = "landByTimePicker";
            this.landByTimePicker.ShowUpDown = true;
            this.landByTimePicker.Size = new System.Drawing.Size(102, 26);
            this.landByTimePicker.TabIndex = 14;
            // 
            // landByDatePicker
            // 
            this.landByDatePicker.CustomFormat = "";
            this.landByDatePicker.Enabled = false;
            this.landByDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.landByDatePicker.Location = new System.Drawing.Point(18, 630);
            this.landByDatePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.landByDatePicker.Name = "landByDatePicker";
            this.landByDatePicker.Size = new System.Drawing.Size(182, 26);
            this.landByDatePicker.TabIndex = 13;
            // 
            // landByCheckBox
            // 
            this.landByCheckBox.AutoSize = true;
            this.landByCheckBox.Location = new System.Drawing.Point(18, 596);
            this.landByCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.landByCheckBox.Name = "landByCheckBox";
            this.landByCheckBox.Size = new System.Drawing.Size(95, 24);
            this.landByCheckBox.TabIndex = 12;
            this.landByCheckBox.Text = "Land by:";
            this.landByCheckBox.UseVisualStyleBackColor = true;
            this.landByCheckBox.CheckedChanged += new System.EventHandler(this.landByCheckBox_CheckedChanged);
            // 
            // abbreviatedNameLabel
            // 
            this.abbreviatedNameLabel.AutoSize = true;
            this.abbreviatedNameLabel.Location = new System.Drawing.Point(337, 81);
            this.abbreviatedNameLabel.Name = "abbreviatedNameLabel";
            this.abbreviatedNameLabel.Size = new System.Drawing.Size(144, 20);
            this.abbreviatedNameLabel.TabIndex = 2;
            this.abbreviatedNameLabel.Text = "Abbreviated Name:";
            // 
            // abbreviatedNameTextBox
            // 
            this.abbreviatedNameTextBox.Location = new System.Drawing.Point(341, 106);
            this.abbreviatedNameTextBox.Name = "abbreviatedNameTextBox";
            this.abbreviatedNameTextBox.Size = new System.Drawing.Size(243, 26);
            this.abbreviatedNameTextBox.TabIndex = 3;
            // 
            // aircraftClassesLabel
            // 
            this.aircraftClassesLabel.AutoSize = true;
            this.aircraftClassesLabel.Location = new System.Drawing.Point(14, 210);
            this.aircraftClassesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aircraftClassesLabel.Name = "aircraftClassesLabel";
            this.aircraftClassesLabel.Size = new System.Drawing.Size(121, 20);
            this.aircraftClassesLabel.TabIndex = 20;
            this.aircraftClassesLabel.Text = "Aircraft classes:";
            // 
            // aircraftClassesDataGridView
            // 
            this.aircraftClassesDataGridView.AllowUserToAddRows = false;
            this.aircraftClassesDataGridView.AllowUserToDeleteRows = false;
            this.aircraftClassesDataGridView.AllowUserToOrderColumns = true;
            this.aircraftClassesDataGridView.AllowUserToResizeRows = false;
            this.aircraftClassesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.aircraftClassesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.aircraftClassesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.aircraftClassesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.aircraftClassesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.aircraftClassesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aircraftClassesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.aircraftClassesDataGridView.ColumnHeadersHeight = 22;
            this.aircraftClassesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.aircraftClassesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedColumn,
            this.CodeColumn,
            this.DescriptionColumn});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.aircraftClassesDataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.aircraftClassesDataGridView.Location = new System.Drawing.Point(18, 235);
            this.aircraftClassesDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.aircraftClassesDataGridView.MultiSelect = false;
            this.aircraftClassesDataGridView.Name = "aircraftClassesDataGridView";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aircraftClassesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.aircraftClassesDataGridView.RowHeadersVisible = false;
            this.aircraftClassesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.aircraftClassesDataGridView.Size = new System.Drawing.Size(566, 183);
            this.aircraftClassesDataGridView.TabIndex = 19;
            // 
            // SelectedColumn
            // 
            this.SelectedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SelectedColumn.FillWeight = 45.68528F;
            this.SelectedColumn.HeaderText = "";
            this.SelectedColumn.Name = "SelectedColumn";
            this.SelectedColumn.Width = 30;
            // 
            // CodeColumn
            // 
            this.CodeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.CodeColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.CodeColumn.FillWeight = 53.29951F;
            this.CodeColumn.HeaderText = "Code";
            this.CodeColumn.Name = "CodeColumn";
            this.CodeColumn.ReadOnly = true;
            this.CodeColumn.Width = 55;
            // 
            // DescriptionColumn
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.DescriptionColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.DescriptionColumn.FillWeight = 201.0153F;
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.ReadOnly = true;
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 741);
            this.Controls.Add(this.aircraftClassesLabel);
            this.Controls.Add(this.aircraftClassesDataGridView);
            this.Controls.Add(this.abbreviatedNameTextBox);
            this.Controls.Add(this.abbreviatedNameLabel);
            this.Controls.Add(this.landByTimePicker);
            this.Controls.Add(this.landByDatePicker);
            this.Controls.Add(this.landByCheckBox);
            this.Controls.Add(this.launchCloseTimePicker);
            this.Controls.Add(this.launchCloseDatePicker);
            this.Controls.Add(this.launchCloseCheckBox);
            this.Controls.Add(this.launchOpenTimePicker);
            this.Controls.Add(this.launchOpenDatePicker);
            this.Controls.Add(this.launchOpenLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task";
            ((System.ComponentModel.ISupportInitialize)(this.aircraftClassesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.DateTimePicker launchOpenTimePicker;
		private System.Windows.Forms.DateTimePicker launchOpenDatePicker;
		private System.Windows.Forms.Label launchOpenLabel;
		private System.Windows.Forms.ComboBox typeComboBox;
		private System.Windows.Forms.Label typeLabel;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox numberTextBox;
		private System.Windows.Forms.Label numberLabel;
		private System.Windows.Forms.CheckBox launchCloseCheckBox;
		private System.Windows.Forms.DateTimePicker launchCloseTimePicker;
		private System.Windows.Forms.DateTimePicker launchCloseDatePicker;
		private System.Windows.Forms.DateTimePicker landByTimePicker;
		private System.Windows.Forms.DateTimePicker landByDatePicker;
		private System.Windows.Forms.CheckBox landByCheckBox;
        private System.Windows.Forms.Label abbreviatedNameLabel;
        private System.Windows.Forms.TextBox abbreviatedNameTextBox;
        private System.Windows.Forms.Label aircraftClassesLabel;
        private System.Windows.Forms.DataGridView aircraftClassesDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
    }
}