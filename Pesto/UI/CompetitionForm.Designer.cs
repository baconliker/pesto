namespace ColinBaker.Pesto.UI
{
	partial class CompetitionForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.competitionFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tracksFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.backupFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.competitionTabControl = new System.Windows.Forms.TabControl();
			this.generalTabPage = new System.Windows.Forms.TabPage();
			this.chooseBackupLocationButton = new System.Windows.Forms.Button();
			this.backupLocationTextBox = new System.Windows.Forms.TextBox();
			this.backupLocationLabel = new System.Windows.Forms.Label();
			this.timeZoneComboBox = new System.Windows.Forms.ComboBox();
			this.timeZoneLabel = new System.Windows.Forms.Label();
			this.aircraftClassesLabel = new System.Windows.Forms.Label();
			this.aircraftClassesDataGridView = new System.Windows.Forms.DataGridView();
			this.SelectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.CodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.finishDatePicker = new System.Windows.Forms.DateTimePicker();
			this.finishLabel = new System.Windows.Forms.Label();
			this.startDatePicker = new System.Windows.Forms.DateTimePicker();
			this.startLabel = new System.Windows.Forms.Label();
			this.chooseLocationButton = new System.Windows.Forms.Button();
			this.locationTextBox = new System.Windows.Forms.TextBox();
			this.locationLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.loggersTabPage = new System.Windows.Forms.TabPage();
			this.chooseFlymasterIgcLocationButton = new System.Windows.Forms.Button();
			this.flymasterIgcLocationTextBox = new System.Windows.Forms.TextBox();
			this.flymasterIgcLocationLabel = new System.Windows.Forms.Label();
			this.flymasterRadioButton = new System.Windows.Forms.RadioButton();
			this.chooseFrdlIgcLocationButton = new System.Windows.Forms.Button();
			this.frdlIgcLocationTextBox = new System.Windows.Forms.TextBox();
			this.frdlIgcLocationLabel = new System.Windows.Forms.Label();
			this.amodRadioButton = new System.Windows.Forms.RadioButton();
			this.noLoggersRadioButton = new System.Windows.Forms.RadioButton();
			this.nationTabPage = new System.Windows.Forms.TabPage();
			this.nationDefinitionsLabel = new System.Windows.Forms.Label();
			this.nationDefinitionsDataGridView = new System.Windows.Forms.DataGridView();
			this.nationAircraftClassColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nationNumberWhoScoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.competitionTabControl.SuspendLayout();
			this.generalTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.aircraftClassesDataGridView)).BeginInit();
			this.loggersTabPage.SuspendLayout();
			this.nationTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nationDefinitionsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(295, 523);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(95, 24);
			this.okButton.TabIndex = 9;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.CausesValidation = false;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(395, 523);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(95, 24);
			this.cancelButton.TabIndex = 10;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// competitionFolderDialog
			// 
			this.competitionFolderDialog.Description = "Select the folder where competition data will be stored:";
			// 
			// tracksFolderDialog
			// 
			this.tracksFolderDialog.Description = "Select the folder where track files are stored:";
			// 
			// backupFolderDialog
			// 
			this.backupFolderDialog.Description = "Select the folder where backups will be stored:";
			// 
			// competitionTabControl
			// 
			this.competitionTabControl.Controls.Add(this.generalTabPage);
			this.competitionTabControl.Controls.Add(this.loggersTabPage);
			this.competitionTabControl.Controls.Add(this.nationTabPage);
			this.competitionTabControl.Location = new System.Drawing.Point(8, 8);
			this.competitionTabControl.Margin = new System.Windows.Forms.Padding(2);
			this.competitionTabControl.Name = "competitionTabControl";
			this.competitionTabControl.SelectedIndex = 0;
			this.competitionTabControl.Size = new System.Drawing.Size(484, 510);
			this.competitionTabControl.TabIndex = 22;
			// 
			// generalTabPage
			// 
			this.generalTabPage.Controls.Add(this.chooseBackupLocationButton);
			this.generalTabPage.Controls.Add(this.backupLocationTextBox);
			this.generalTabPage.Controls.Add(this.backupLocationLabel);
			this.generalTabPage.Controls.Add(this.timeZoneComboBox);
			this.generalTabPage.Controls.Add(this.timeZoneLabel);
			this.generalTabPage.Controls.Add(this.aircraftClassesLabel);
			this.generalTabPage.Controls.Add(this.aircraftClassesDataGridView);
			this.generalTabPage.Controls.Add(this.finishDatePicker);
			this.generalTabPage.Controls.Add(this.finishLabel);
			this.generalTabPage.Controls.Add(this.startDatePicker);
			this.generalTabPage.Controls.Add(this.startLabel);
			this.generalTabPage.Controls.Add(this.chooseLocationButton);
			this.generalTabPage.Controls.Add(this.locationTextBox);
			this.generalTabPage.Controls.Add(this.locationLabel);
			this.generalTabPage.Controls.Add(this.nameTextBox);
			this.generalTabPage.Controls.Add(this.nameLabel);
			this.generalTabPage.Location = new System.Drawing.Point(4, 22);
			this.generalTabPage.Margin = new System.Windows.Forms.Padding(2);
			this.generalTabPage.Name = "generalTabPage";
			this.generalTabPage.Padding = new System.Windows.Forms.Padding(2);
			this.generalTabPage.Size = new System.Drawing.Size(476, 484);
			this.generalTabPage.TabIndex = 0;
			this.generalTabPage.Text = "General";
			this.generalTabPage.UseVisualStyleBackColor = true;
			// 
			// chooseBackupLocationButton
			// 
			this.chooseBackupLocationButton.Location = new System.Drawing.Point(389, 404);
			this.chooseBackupLocationButton.Name = "chooseBackupLocationButton";
			this.chooseBackupLocationButton.Size = new System.Drawing.Size(73, 24);
			this.chooseBackupLocationButton.TabIndex = 40;
			this.chooseBackupLocationButton.Text = "Choose...";
			this.chooseBackupLocationButton.UseVisualStyleBackColor = true;
			this.chooseBackupLocationButton.Click += new System.EventHandler(this.chooseBackupLocationButton_Click);
			// 
			// backupLocationTextBox
			// 
			this.backupLocationTextBox.Location = new System.Drawing.Point(11, 407);
			this.backupLocationTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.backupLocationTextBox.Name = "backupLocationTextBox";
			this.backupLocationTextBox.Size = new System.Drawing.Size(371, 20);
			this.backupLocationTextBox.TabIndex = 39;
			// 
			// backupLocationLabel
			// 
			this.backupLocationLabel.AutoSize = true;
			this.backupLocationLabel.Location = new System.Drawing.Point(8, 392);
			this.backupLocationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.backupLocationLabel.Name = "backupLocationLabel";
			this.backupLocationLabel.Size = new System.Drawing.Size(284, 13);
			this.backupLocationLabel.TabIndex = 38;
			this.backupLocationLabel.Text = "Backup Location (the folder where backups will be saved):";
			// 
			// timeZoneComboBox
			// 
			this.timeZoneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.timeZoneComboBox.FormattingEnabled = true;
			this.timeZoneComboBox.Location = new System.Drawing.Point(11, 120);
			this.timeZoneComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.timeZoneComboBox.Name = "timeZoneComboBox";
			this.timeZoneComboBox.Size = new System.Drawing.Size(451, 21);
			this.timeZoneComboBox.TabIndex = 37;
			// 
			// timeZoneLabel
			// 
			this.timeZoneLabel.AutoSize = true;
			this.timeZoneLabel.Location = new System.Drawing.Point(8, 105);
			this.timeZoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.timeZoneLabel.Name = "timeZoneLabel";
			this.timeZoneLabel.Size = new System.Drawing.Size(59, 13);
			this.timeZoneLabel.TabIndex = 36;
			this.timeZoneLabel.Text = "Time zone:";
			// 
			// aircraftClassesLabel
			// 
			this.aircraftClassesLabel.AutoSize = true;
			this.aircraftClassesLabel.Location = new System.Drawing.Point(8, 153);
			this.aircraftClassesLabel.Name = "aircraftClassesLabel";
			this.aircraftClassesLabel.Size = new System.Drawing.Size(81, 13);
			this.aircraftClassesLabel.TabIndex = 32;
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
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.aircraftClassesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.aircraftClassesDataGridView.ColumnHeadersHeight = 22;
			this.aircraftClassesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.aircraftClassesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedColumn,
            this.CodeColumn,
            this.DescriptionColumn});
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.aircraftClassesDataGridView.DefaultCellStyle = dataGridViewCellStyle11;
			this.aircraftClassesDataGridView.Location = new System.Drawing.Point(11, 168);
			this.aircraftClassesDataGridView.MultiSelect = false;
			this.aircraftClassesDataGridView.Name = "aircraftClassesDataGridView";
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.aircraftClassesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.aircraftClassesDataGridView.RowHeadersVisible = false;
			this.aircraftClassesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.aircraftClassesDataGridView.Size = new System.Drawing.Size(449, 167);
			this.aircraftClassesDataGridView.TabIndex = 31;
			this.aircraftClassesDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.aircraftClassesDataGridView_CellMouseUp);
			this.aircraftClassesDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.aircraftClassesDataGridView_CellValueChanged);
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
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.CodeColumn.DefaultCellStyle = dataGridViewCellStyle9;
			this.CodeColumn.FillWeight = 53.29951F;
			this.CodeColumn.HeaderText = "Code";
			this.CodeColumn.Name = "CodeColumn";
			this.CodeColumn.ReadOnly = true;
			this.CodeColumn.Width = 55;
			// 
			// DescriptionColumn
			// 
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.DescriptionColumn.DefaultCellStyle = dataGridViewCellStyle10;
			this.DescriptionColumn.FillWeight = 201.0153F;
			this.DescriptionColumn.HeaderText = "Description";
			this.DescriptionColumn.Name = "DescriptionColumn";
			this.DescriptionColumn.ReadOnly = true;
			// 
			// finishDatePicker
			// 
			this.finishDatePicker.CustomFormat = "";
			this.finishDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.finishDatePicker.Location = new System.Drawing.Point(161, 73);
			this.finishDatePicker.Name = "finishDatePicker";
			this.finishDatePicker.Size = new System.Drawing.Size(128, 20);
			this.finishDatePicker.TabIndex = 27;
			// 
			// finishLabel
			// 
			this.finishLabel.AutoSize = true;
			this.finishLabel.Location = new System.Drawing.Point(158, 57);
			this.finishLabel.Name = "finishLabel";
			this.finishLabel.Size = new System.Drawing.Size(37, 13);
			this.finishLabel.TabIndex = 26;
			this.finishLabel.Text = "Finish:";
			// 
			// startDatePicker
			// 
			this.startDatePicker.CustomFormat = "";
			this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.startDatePicker.Location = new System.Drawing.Point(11, 73);
			this.startDatePicker.Name = "startDatePicker";
			this.startDatePicker.Size = new System.Drawing.Size(128, 20);
			this.startDatePicker.TabIndex = 25;
			// 
			// startLabel
			// 
			this.startLabel.AutoSize = true;
			this.startLabel.Location = new System.Drawing.Point(8, 57);
			this.startLabel.Name = "startLabel";
			this.startLabel.Size = new System.Drawing.Size(32, 13);
			this.startLabel.TabIndex = 24;
			this.startLabel.Text = "Start:";
			// 
			// chooseLocationButton
			// 
			this.chooseLocationButton.Location = new System.Drawing.Point(389, 361);
			this.chooseLocationButton.Name = "chooseLocationButton";
			this.chooseLocationButton.Size = new System.Drawing.Size(73, 24);
			this.chooseLocationButton.TabIndex = 30;
			this.chooseLocationButton.Text = "Choose...";
			this.chooseLocationButton.UseVisualStyleBackColor = true;
			this.chooseLocationButton.Click += new System.EventHandler(this.chooseLocationButton_Click);
			// 
			// locationTextBox
			// 
			this.locationTextBox.Location = new System.Drawing.Point(11, 363);
			this.locationTextBox.Name = "locationTextBox";
			this.locationTextBox.Size = new System.Drawing.Size(371, 20);
			this.locationTextBox.TabIndex = 29;
			// 
			// locationLabel
			// 
			this.locationLabel.AutoSize = true;
			this.locationLabel.Location = new System.Drawing.Point(8, 348);
			this.locationLabel.Name = "locationLabel";
			this.locationLabel.Size = new System.Drawing.Size(281, 13);
			this.locationLabel.TabIndex = 28;
			this.locationLabel.Text = "Location (the folder where competition data will be stored):";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(11, 25);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(451, 20);
			this.nameTextBox.TabIndex = 23;
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(8, 8);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(38, 13);
			this.nameLabel.TabIndex = 22;
			this.nameLabel.Text = "Name:";
			// 
			// loggersTabPage
			// 
			this.loggersTabPage.Controls.Add(this.chooseFlymasterIgcLocationButton);
			this.loggersTabPage.Controls.Add(this.flymasterIgcLocationTextBox);
			this.loggersTabPage.Controls.Add(this.flymasterIgcLocationLabel);
			this.loggersTabPage.Controls.Add(this.flymasterRadioButton);
			this.loggersTabPage.Controls.Add(this.chooseFrdlIgcLocationButton);
			this.loggersTabPage.Controls.Add(this.frdlIgcLocationTextBox);
			this.loggersTabPage.Controls.Add(this.frdlIgcLocationLabel);
			this.loggersTabPage.Controls.Add(this.amodRadioButton);
			this.loggersTabPage.Controls.Add(this.noLoggersRadioButton);
			this.loggersTabPage.Location = new System.Drawing.Point(4, 22);
			this.loggersTabPage.Name = "loggersTabPage";
			this.loggersTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.loggersTabPage.Size = new System.Drawing.Size(476, 484);
			this.loggersTabPage.TabIndex = 2;
			this.loggersTabPage.Text = "Loggers";
			this.loggersTabPage.UseVisualStyleBackColor = true;
			// 
			// chooseFlymasterIgcLocationButton
			// 
			this.chooseFlymasterIgcLocationButton.Enabled = false;
			this.chooseFlymasterIgcLocationButton.Location = new System.Drawing.Point(383, 152);
			this.chooseFlymasterIgcLocationButton.Name = "chooseFlymasterIgcLocationButton";
			this.chooseFlymasterIgcLocationButton.Size = new System.Drawing.Size(73, 24);
			this.chooseFlymasterIgcLocationButton.TabIndex = 42;
			this.chooseFlymasterIgcLocationButton.Text = "Choose...";
			this.chooseFlymasterIgcLocationButton.UseVisualStyleBackColor = true;
			this.chooseFlymasterIgcLocationButton.Click += new System.EventHandler(this.chooseFlymasterIgcLocationButton_Click);
			// 
			// flymasterIgcLocationTextBox
			// 
			this.flymasterIgcLocationTextBox.Enabled = false;
			this.flymasterIgcLocationTextBox.Location = new System.Drawing.Point(23, 155);
			this.flymasterIgcLocationTextBox.Name = "flymasterIgcLocationTextBox";
			this.flymasterIgcLocationTextBox.Size = new System.Drawing.Size(355, 20);
			this.flymasterIgcLocationTextBox.TabIndex = 41;
			// 
			// flymasterIgcLocationLabel
			// 
			this.flymasterIgcLocationLabel.AutoSize = true;
			this.flymasterIgcLocationLabel.Location = new System.Drawing.Point(22, 139);
			this.flymasterIgcLocationLabel.Name = "flymasterIgcLocationLabel";
			this.flymasterIgcLocationLabel.Size = new System.Drawing.Size(155, 13);
			this.flymasterIgcLocationLabel.TabIndex = 40;
			this.flymasterIgcLocationLabel.Text = "Flymaster Tracker IGC location:";
			// 
			// flymasterRadioButton
			// 
			this.flymasterRadioButton.AutoSize = true;
			this.flymasterRadioButton.Location = new System.Drawing.Point(10, 109);
			this.flymasterRadioButton.Name = "flymasterRadioButton";
			this.flymasterRadioButton.Size = new System.Drawing.Size(69, 17);
			this.flymasterRadioButton.TabIndex = 39;
			this.flymasterRadioButton.Text = "Flymaster";
			this.flymasterRadioButton.UseVisualStyleBackColor = true;
			this.flymasterRadioButton.CheckedChanged += new System.EventHandler(this.flymasterRadioButton_CheckedChanged);
			// 
			// chooseFrdlIgcLocationButton
			// 
			this.chooseFrdlIgcLocationButton.Enabled = false;
			this.chooseFrdlIgcLocationButton.Location = new System.Drawing.Point(383, 71);
			this.chooseFrdlIgcLocationButton.Name = "chooseFrdlIgcLocationButton";
			this.chooseFrdlIgcLocationButton.Size = new System.Drawing.Size(73, 24);
			this.chooseFrdlIgcLocationButton.TabIndex = 38;
			this.chooseFrdlIgcLocationButton.Text = "Choose...";
			this.chooseFrdlIgcLocationButton.UseVisualStyleBackColor = true;
			this.chooseFrdlIgcLocationButton.Click += new System.EventHandler(this.chooseFrdlIgcLocationButton_Click);
			// 
			// frdlIgcLocationTextBox
			// 
			this.frdlIgcLocationTextBox.Enabled = false;
			this.frdlIgcLocationTextBox.Location = new System.Drawing.Point(23, 74);
			this.frdlIgcLocationTextBox.Name = "frdlIgcLocationTextBox";
			this.frdlIgcLocationTextBox.Size = new System.Drawing.Size(355, 20);
			this.frdlIgcLocationTextBox.TabIndex = 37;
			// 
			// frdlIgcLocationLabel
			// 
			this.frdlIgcLocationLabel.AutoSize = true;
			this.frdlIgcLocationLabel.Location = new System.Drawing.Point(22, 58);
			this.frdlIgcLocationLabel.Name = "frdlIgcLocationLabel";
			this.frdlIgcLocationLabel.Size = new System.Drawing.Size(395, 13);
			this.frdlIgcLocationLabel.TabIndex = 36;
			this.frdlIgcLocationLabel.Text = "FRDL IGC location (the folder where FRDL stores tracks, normally called \'igcFiles" +
    "\'):";
			// 
			// amodRadioButton
			// 
			this.amodRadioButton.AutoSize = true;
			this.amodRadioButton.Location = new System.Drawing.Point(10, 29);
			this.amodRadioButton.Name = "amodRadioButton";
			this.amodRadioButton.Size = new System.Drawing.Size(57, 17);
			this.amodRadioButton.TabIndex = 1;
			this.amodRadioButton.Text = "AMOD";
			this.amodRadioButton.UseVisualStyleBackColor = true;
			this.amodRadioButton.CheckedChanged += new System.EventHandler(this.amodRadioButton_CheckedChanged);
			// 
			// noLoggersRadioButton
			// 
			this.noLoggersRadioButton.AutoSize = true;
			this.noLoggersRadioButton.Checked = true;
			this.noLoggersRadioButton.Location = new System.Drawing.Point(10, 6);
			this.noLoggersRadioButton.Name = "noLoggersRadioButton";
			this.noLoggersRadioButton.Size = new System.Drawing.Size(51, 17);
			this.noLoggersRadioButton.TabIndex = 0;
			this.noLoggersRadioButton.TabStop = true;
			this.noLoggersRadioButton.Text = "None";
			this.noLoggersRadioButton.UseVisualStyleBackColor = true;
			this.noLoggersRadioButton.CheckedChanged += new System.EventHandler(this.noLoggersRadioButton_CheckedChanged);
			// 
			// nationTabPage
			// 
			this.nationTabPage.Controls.Add(this.nationDefinitionsLabel);
			this.nationTabPage.Controls.Add(this.nationDefinitionsDataGridView);
			this.nationTabPage.Location = new System.Drawing.Point(4, 22);
			this.nationTabPage.Margin = new System.Windows.Forms.Padding(2);
			this.nationTabPage.Name = "nationTabPage";
			this.nationTabPage.Padding = new System.Windows.Forms.Padding(2);
			this.nationTabPage.Size = new System.Drawing.Size(476, 484);
			this.nationTabPage.TabIndex = 1;
			this.nationTabPage.Text = "Nation";
			this.nationTabPage.UseVisualStyleBackColor = true;
			// 
			// nationDefinitionsLabel
			// 
			this.nationDefinitionsLabel.AutoSize = true;
			this.nationDefinitionsLabel.Location = new System.Drawing.Point(8, 8);
			this.nationDefinitionsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.nationDefinitionsLabel.Name = "nationDefinitionsLabel";
			this.nationDefinitionsLabel.Size = new System.Drawing.Size(279, 13);
			this.nationDefinitionsLabel.TabIndex = 1;
			this.nationDefinitionsLabel.Text = "Nation scores are calculated based on the following rules:";
			// 
			// nationDefinitionsDataGridView
			// 
			this.nationDefinitionsDataGridView.AllowUserToAddRows = false;
			this.nationDefinitionsDataGridView.AllowUserToDeleteRows = false;
			this.nationDefinitionsDataGridView.AllowUserToResizeRows = false;
			this.nationDefinitionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.nationDefinitionsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.nationDefinitionsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.nationDefinitionsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.nationDefinitionsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.nationDefinitionsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.nationDefinitionsDataGridView.ColumnHeadersHeight = 22;
			this.nationDefinitionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nationAircraftClassColumn,
            this.nationNumberWhoScoreColumn});
			this.nationDefinitionsDataGridView.Location = new System.Drawing.Point(11, 26);
			this.nationDefinitionsDataGridView.Margin = new System.Windows.Forms.Padding(2);
			this.nationDefinitionsDataGridView.MultiSelect = false;
			this.nationDefinitionsDataGridView.Name = "nationDefinitionsDataGridView";
			this.nationDefinitionsDataGridView.RowHeadersVisible = false;
			this.nationDefinitionsDataGridView.RowTemplate.Height = 28;
			this.nationDefinitionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.nationDefinitionsDataGridView.Size = new System.Drawing.Size(213, 279);
			this.nationDefinitionsDataGridView.TabIndex = 0;
			this.nationDefinitionsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.nationDefinitionsDataGridView_CellValidating);
			// 
			// nationAircraftClassColumn
			// 
			dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
			this.nationAircraftClassColumn.DefaultCellStyle = dataGridViewCellStyle13;
			this.nationAircraftClassColumn.HeaderText = "Aircraft Class";
			this.nationAircraftClassColumn.Name = "nationAircraftClassColumn";
			this.nationAircraftClassColumn.ReadOnly = true;
			// 
			// nationNumberWhoScoreColumn
			// 
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
			this.nationNumberWhoScoreColumn.DefaultCellStyle = dataGridViewCellStyle14;
			this.nationNumberWhoScoreColumn.FillWeight = 125F;
			this.nationNumberWhoScoreColumn.HeaderText = "Number Who Score";
			this.nationNumberWhoScoreColumn.Name = "nationNumberWhoScoreColumn";
			// 
			// CompetitionForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(500, 556);
			this.Controls.Add(this.competitionTabControl);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CompetitionForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Competition";
			this.competitionTabControl.ResumeLayout(false);
			this.generalTabPage.ResumeLayout(false);
			this.generalTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.aircraftClassesDataGridView)).EndInit();
			this.loggersTabPage.ResumeLayout(false);
			this.loggersTabPage.PerformLayout();
			this.nationTabPage.ResumeLayout(false);
			this.nationTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nationDefinitionsDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FolderBrowserDialog competitionFolderDialog;
		private System.Windows.Forms.FolderBrowserDialog tracksFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog backupFolderDialog;
        private System.Windows.Forms.TabControl competitionTabControl;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.Button chooseBackupLocationButton;
        private System.Windows.Forms.TextBox backupLocationTextBox;
        private System.Windows.Forms.Label backupLocationLabel;
        private System.Windows.Forms.ComboBox timeZoneComboBox;
        private System.Windows.Forms.Label timeZoneLabel;
        private System.Windows.Forms.Label aircraftClassesLabel;
        private System.Windows.Forms.DataGridView aircraftClassesDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DateTimePicker finishDatePicker;
        private System.Windows.Forms.Label finishLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Button chooseLocationButton;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TabPage nationTabPage;
        private System.Windows.Forms.Label nationDefinitionsLabel;
        private System.Windows.Forms.DataGridView nationDefinitionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationAircraftClassColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationNumberWhoScoreColumn;
		private System.Windows.Forms.TabPage loggersTabPage;
		private System.Windows.Forms.Button chooseFlymasterIgcLocationButton;
		private System.Windows.Forms.TextBox flymasterIgcLocationTextBox;
		private System.Windows.Forms.Label flymasterIgcLocationLabel;
		private System.Windows.Forms.RadioButton flymasterRadioButton;
		private System.Windows.Forms.Button chooseFrdlIgcLocationButton;
		private System.Windows.Forms.TextBox frdlIgcLocationTextBox;
		private System.Windows.Forms.Label frdlIgcLocationLabel;
		private System.Windows.Forms.RadioButton amodRadioButton;
		private System.Windows.Forms.RadioButton noLoggersRadioButton;
	}
}