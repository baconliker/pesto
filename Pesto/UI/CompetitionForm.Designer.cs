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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
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
			this.trackAnalysisTabPage = new System.Windows.Forms.TabPage();
			this.defaultPointRadiusUnitsLabel = new System.Windows.Forms.Label();
			this.defaultPointRadiusTextBox = new System.Windows.Forms.TextBox();
			this.defaultPointRadiusLabel = new System.Windows.Forms.Label();
			this.loggersGroupBox = new System.Windows.Forms.GroupBox();
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
			this.trackAnalysisTabPage.SuspendLayout();
			this.loggersGroupBox.SuspendLayout();
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
			this.competitionTabControl.Controls.Add(this.trackAnalysisTabPage);
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
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.aircraftClassesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
			this.aircraftClassesDataGridView.ColumnHeadersHeight = 22;
			this.aircraftClassesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.aircraftClassesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedColumn,
            this.CodeColumn,
            this.DescriptionColumn});
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.aircraftClassesDataGridView.DefaultCellStyle = dataGridViewCellStyle18;
			this.aircraftClassesDataGridView.Location = new System.Drawing.Point(11, 168);
			this.aircraftClassesDataGridView.MultiSelect = false;
			this.aircraftClassesDataGridView.Name = "aircraftClassesDataGridView";
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.aircraftClassesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
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
			dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.CodeColumn.DefaultCellStyle = dataGridViewCellStyle16;
			this.CodeColumn.FillWeight = 53.29951F;
			this.CodeColumn.HeaderText = "Code";
			this.CodeColumn.Name = "CodeColumn";
			this.CodeColumn.ReadOnly = true;
			this.CodeColumn.Width = 55;
			// 
			// DescriptionColumn
			// 
			dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.DescriptionColumn.DefaultCellStyle = dataGridViewCellStyle17;
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
			// trackAnalysisTabPage
			// 
			this.trackAnalysisTabPage.Controls.Add(this.defaultPointRadiusUnitsLabel);
			this.trackAnalysisTabPage.Controls.Add(this.defaultPointRadiusTextBox);
			this.trackAnalysisTabPage.Controls.Add(this.defaultPointRadiusLabel);
			this.trackAnalysisTabPage.Controls.Add(this.loggersGroupBox);
			this.trackAnalysisTabPage.Location = new System.Drawing.Point(4, 22);
			this.trackAnalysisTabPage.Name = "trackAnalysisTabPage";
			this.trackAnalysisTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.trackAnalysisTabPage.Size = new System.Drawing.Size(476, 484);
			this.trackAnalysisTabPage.TabIndex = 2;
			this.trackAnalysisTabPage.Text = "Track Analysis";
			this.trackAnalysisTabPage.UseVisualStyleBackColor = true;
			// 
			// defaultPointRadiusUnitsLabel
			// 
			this.defaultPointRadiusUnitsLabel.AutoSize = true;
			this.defaultPointRadiusUnitsLabel.Location = new System.Drawing.Point(175, 245);
			this.defaultPointRadiusUnitsLabel.Name = "defaultPointRadiusUnitsLabel";
			this.defaultPointRadiusUnitsLabel.Size = new System.Drawing.Size(38, 13);
			this.defaultPointRadiusUnitsLabel.TabIndex = 46;
			this.defaultPointRadiusUnitsLabel.Text = "metres";
			// 
			// defaultPointRadiusTextBox
			// 
			this.defaultPointRadiusTextBox.Location = new System.Drawing.Point(114, 242);
			this.defaultPointRadiusTextBox.Name = "defaultPointRadiusTextBox";
			this.defaultPointRadiusTextBox.Size = new System.Drawing.Size(55, 20);
			this.defaultPointRadiusTextBox.TabIndex = 45;
			this.defaultPointRadiusTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.defaultTurnpointRadiusTextBox_Validating);
			// 
			// defaultPointRadiusLabel
			// 
			this.defaultPointRadiusLabel.AutoSize = true;
			this.defaultPointRadiusLabel.Location = new System.Drawing.Point(7, 245);
			this.defaultPointRadiusLabel.Name = "defaultPointRadiusLabel";
			this.defaultPointRadiusLabel.Size = new System.Drawing.Size(101, 13);
			this.defaultPointRadiusLabel.TabIndex = 44;
			this.defaultPointRadiusLabel.Text = "Default point radius:";
			// 
			// loggersGroupBox
			// 
			this.loggersGroupBox.Controls.Add(this.chooseFlymasterIgcLocationButton);
			this.loggersGroupBox.Controls.Add(this.flymasterIgcLocationTextBox);
			this.loggersGroupBox.Controls.Add(this.flymasterIgcLocationLabel);
			this.loggersGroupBox.Controls.Add(this.flymasterRadioButton);
			this.loggersGroupBox.Controls.Add(this.chooseFrdlIgcLocationButton);
			this.loggersGroupBox.Controls.Add(this.frdlIgcLocationTextBox);
			this.loggersGroupBox.Controls.Add(this.frdlIgcLocationLabel);
			this.loggersGroupBox.Controls.Add(this.amodRadioButton);
			this.loggersGroupBox.Controls.Add(this.noLoggersRadioButton);
			this.loggersGroupBox.Location = new System.Drawing.Point(10, 6);
			this.loggersGroupBox.Name = "loggersGroupBox";
			this.loggersGroupBox.Size = new System.Drawing.Size(456, 221);
			this.loggersGroupBox.TabIndex = 43;
			this.loggersGroupBox.TabStop = false;
			this.loggersGroupBox.Text = "Loggers";
			// 
			// chooseFlymasterIgcLocationButton
			// 
			this.chooseFlymasterIgcLocationButton.Enabled = false;
			this.chooseFlymasterIgcLocationButton.Location = new System.Drawing.Point(373, 172);
			this.chooseFlymasterIgcLocationButton.Name = "chooseFlymasterIgcLocationButton";
			this.chooseFlymasterIgcLocationButton.Size = new System.Drawing.Size(73, 24);
			this.chooseFlymasterIgcLocationButton.TabIndex = 51;
			this.chooseFlymasterIgcLocationButton.Text = "Choose...";
			this.chooseFlymasterIgcLocationButton.UseVisualStyleBackColor = true;
			// 
			// flymasterIgcLocationTextBox
			// 
			this.flymasterIgcLocationTextBox.Enabled = false;
			this.flymasterIgcLocationTextBox.Location = new System.Drawing.Point(22, 176);
			this.flymasterIgcLocationTextBox.Name = "flymasterIgcLocationTextBox";
			this.flymasterIgcLocationTextBox.Size = new System.Drawing.Size(345, 20);
			this.flymasterIgcLocationTextBox.TabIndex = 50;
			// 
			// flymasterIgcLocationLabel
			// 
			this.flymasterIgcLocationLabel.AutoSize = true;
			this.flymasterIgcLocationLabel.Location = new System.Drawing.Point(21, 160);
			this.flymasterIgcLocationLabel.Name = "flymasterIgcLocationLabel";
			this.flymasterIgcLocationLabel.Size = new System.Drawing.Size(155, 13);
			this.flymasterIgcLocationLabel.TabIndex = 49;
			this.flymasterIgcLocationLabel.Text = "Flymaster Tracker IGC location:";
			// 
			// flymasterRadioButton
			// 
			this.flymasterRadioButton.AutoSize = true;
			this.flymasterRadioButton.Location = new System.Drawing.Point(9, 130);
			this.flymasterRadioButton.Name = "flymasterRadioButton";
			this.flymasterRadioButton.Size = new System.Drawing.Size(69, 17);
			this.flymasterRadioButton.TabIndex = 48;
			this.flymasterRadioButton.Text = "Flymaster";
			this.flymasterRadioButton.UseVisualStyleBackColor = true;
			// 
			// chooseFrdlIgcLocationButton
			// 
			this.chooseFrdlIgcLocationButton.Enabled = false;
			this.chooseFrdlIgcLocationButton.Location = new System.Drawing.Point(373, 92);
			this.chooseFrdlIgcLocationButton.Name = "chooseFrdlIgcLocationButton";
			this.chooseFrdlIgcLocationButton.Size = new System.Drawing.Size(73, 24);
			this.chooseFrdlIgcLocationButton.TabIndex = 47;
			this.chooseFrdlIgcLocationButton.Text = "Choose...";
			this.chooseFrdlIgcLocationButton.UseVisualStyleBackColor = true;
			// 
			// frdlIgcLocationTextBox
			// 
			this.frdlIgcLocationTextBox.Enabled = false;
			this.frdlIgcLocationTextBox.Location = new System.Drawing.Point(22, 95);
			this.frdlIgcLocationTextBox.Name = "frdlIgcLocationTextBox";
			this.frdlIgcLocationTextBox.Size = new System.Drawing.Size(345, 20);
			this.frdlIgcLocationTextBox.TabIndex = 46;
			// 
			// frdlIgcLocationLabel
			// 
			this.frdlIgcLocationLabel.AutoSize = true;
			this.frdlIgcLocationLabel.Location = new System.Drawing.Point(21, 79);
			this.frdlIgcLocationLabel.Name = "frdlIgcLocationLabel";
			this.frdlIgcLocationLabel.Size = new System.Drawing.Size(395, 13);
			this.frdlIgcLocationLabel.TabIndex = 45;
			this.frdlIgcLocationLabel.Text = "FRDL IGC location (the folder where FRDL stores tracks, normally called \'igcFiles" +
    "\'):";
			// 
			// amodRadioButton
			// 
			this.amodRadioButton.AutoSize = true;
			this.amodRadioButton.Location = new System.Drawing.Point(9, 50);
			this.amodRadioButton.Name = "amodRadioButton";
			this.amodRadioButton.Size = new System.Drawing.Size(57, 17);
			this.amodRadioButton.TabIndex = 44;
			this.amodRadioButton.Text = "AMOD";
			this.amodRadioButton.UseVisualStyleBackColor = true;
			// 
			// noLoggersRadioButton
			// 
			this.noLoggersRadioButton.AutoSize = true;
			this.noLoggersRadioButton.Checked = true;
			this.noLoggersRadioButton.Location = new System.Drawing.Point(9, 27);
			this.noLoggersRadioButton.Name = "noLoggersRadioButton";
			this.noLoggersRadioButton.Size = new System.Drawing.Size(51, 17);
			this.noLoggersRadioButton.TabIndex = 43;
			this.noLoggersRadioButton.TabStop = true;
			this.noLoggersRadioButton.Text = "None";
			this.noLoggersRadioButton.UseVisualStyleBackColor = true;
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
			dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
			this.nationAircraftClassColumn.DefaultCellStyle = dataGridViewCellStyle20;
			this.nationAircraftClassColumn.HeaderText = "Aircraft Class";
			this.nationAircraftClassColumn.Name = "nationAircraftClassColumn";
			this.nationAircraftClassColumn.ReadOnly = true;
			// 
			// nationNumberWhoScoreColumn
			// 
			dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
			this.nationNumberWhoScoreColumn.DefaultCellStyle = dataGridViewCellStyle21;
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
			this.trackAnalysisTabPage.ResumeLayout(false);
			this.trackAnalysisTabPage.PerformLayout();
			this.loggersGroupBox.ResumeLayout(false);
			this.loggersGroupBox.PerformLayout();
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
		private System.Windows.Forms.TabPage trackAnalysisTabPage;
		private System.Windows.Forms.GroupBox loggersGroupBox;
		private System.Windows.Forms.Button chooseFlymasterIgcLocationButton;
		private System.Windows.Forms.TextBox flymasterIgcLocationTextBox;
		private System.Windows.Forms.Label flymasterIgcLocationLabel;
		private System.Windows.Forms.RadioButton flymasterRadioButton;
		private System.Windows.Forms.Button chooseFrdlIgcLocationButton;
		private System.Windows.Forms.TextBox frdlIgcLocationTextBox;
		private System.Windows.Forms.Label frdlIgcLocationLabel;
		private System.Windows.Forms.RadioButton amodRadioButton;
		private System.Windows.Forms.RadioButton noLoggersRadioButton;
		private System.Windows.Forms.Label defaultPointRadiusUnitsLabel;
		private System.Windows.Forms.TextBox defaultPointRadiusTextBox;
		private System.Windows.Forms.Label defaultPointRadiusLabel;
	}
}