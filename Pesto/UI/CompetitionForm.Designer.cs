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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.competitionFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tracksFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.backupFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.competitionTabControl = new System.Windows.Forms.TabControl();
			this.generalTabPage = new System.Windows.Forms.TabPage();
			this.chooseLogoButton = new System.Windows.Forms.Button();
			this.logoTextBox = new System.Windows.Forms.TextBox();
			this.logoLabel = new System.Windows.Forms.Label();
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
			this.flymasterApiGroupBox = new System.Windows.Forms.GroupBox();
			this.flymasterApiGroupIdTextBox = new System.Windows.Forms.TextBox();
			this.flymasterApiGroupIdLabel = new System.Windows.Forms.Label();
			this.flymasterApiPasswordTextBox = new System.Windows.Forms.TextBox();
			this.flymasterApiPasswordlabel = new System.Windows.Forms.Label();
			this.flymasterApiUsernameTextBox = new System.Windows.Forms.TextBox();
			this.flymasterApiUsernameLabel = new System.Windows.Forms.Label();
			this.loggersNoteLabel = new System.Windows.Forms.Label();
			this.chooseFlymasterIgcLocationButton = new System.Windows.Forms.Button();
			this.flymasterIgcLocationTextBox = new System.Windows.Forms.TextBox();
			this.flymasterIgcLocationLabel = new System.Windows.Forms.Label();
			this.chooseFrdlIgcLocationButton = new System.Windows.Forms.Button();
			this.frdlIgcLocationTextBox = new System.Windows.Forms.TextBox();
			this.frdlIgcLocationLabel = new System.Windows.Forms.Label();
			this.nationTabPage = new System.Windows.Forms.TabPage();
			this.nationDefinitionsLabel = new System.Windows.Forms.Label();
			this.nationDefinitionsDataGridView = new System.Windows.Forms.DataGridView();
			this.nationAircraftClassColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nationNumberWhoScoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.logoDialog = new System.Windows.Forms.OpenFileDialog();
			this.defaultGateWidthLabel = new System.Windows.Forms.Label();
			this.defaultGateWidthTextBox = new System.Windows.Forms.TextBox();
			this.defaultGateWidthUnitsLabel = new System.Windows.Forms.Label();
			this.competitionTabControl.SuspendLayout();
			this.generalTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.aircraftClassesDataGridView)).BeginInit();
			this.trackAnalysisTabPage.SuspendLayout();
			this.loggersGroupBox.SuspendLayout();
			this.flymasterApiGroupBox.SuspendLayout();
			this.nationTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nationDefinitionsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(590, 1006);
			this.okButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(190, 46);
			this.okButton.TabIndex = 9;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.CausesValidation = false;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(790, 1006);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(190, 46);
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
			this.competitionTabControl.Location = new System.Drawing.Point(16, 15);
			this.competitionTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.competitionTabControl.Name = "competitionTabControl";
			this.competitionTabControl.SelectedIndex = 0;
			this.competitionTabControl.Size = new System.Drawing.Size(968, 981);
			this.competitionTabControl.TabIndex = 22;
			// 
			// generalTabPage
			// 
			this.generalTabPage.Controls.Add(this.chooseLogoButton);
			this.generalTabPage.Controls.Add(this.logoTextBox);
			this.generalTabPage.Controls.Add(this.logoLabel);
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
			this.generalTabPage.Location = new System.Drawing.Point(8, 39);
			this.generalTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.generalTabPage.Name = "generalTabPage";
			this.generalTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.generalTabPage.Size = new System.Drawing.Size(952, 934);
			this.generalTabPage.TabIndex = 0;
			this.generalTabPage.Text = "General";
			this.generalTabPage.UseVisualStyleBackColor = true;
			// 
			// chooseLogoButton
			// 
			this.chooseLogoButton.Location = new System.Drawing.Point(778, 137);
			this.chooseLogoButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.chooseLogoButton.Name = "chooseLogoButton";
			this.chooseLogoButton.Size = new System.Drawing.Size(146, 46);
			this.chooseLogoButton.TabIndex = 43;
			this.chooseLogoButton.Text = "Choose...";
			this.chooseLogoButton.UseVisualStyleBackColor = true;
			this.chooseLogoButton.Click += new System.EventHandler(this.chooseLogoButton_Click);
			// 
			// logoTextBox
			// 
			this.logoTextBox.Location = new System.Drawing.Point(22, 142);
			this.logoTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.logoTextBox.Name = "logoTextBox";
			this.logoTextBox.Size = new System.Drawing.Size(738, 31);
			this.logoTextBox.TabIndex = 42;
			// 
			// logoLabel
			// 
			this.logoLabel.AutoSize = true;
			this.logoLabel.Location = new System.Drawing.Point(16, 112);
			this.logoLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.logoLabel.Name = "logoLabel";
			this.logoLabel.Size = new System.Drawing.Size(354, 25);
			this.logoLabel.TabIndex = 41;
			this.logoLabel.Text = "Logo (this will be shown on results):";
			// 
			// chooseBackupLocationButton
			// 
			this.chooseBackupLocationButton.Location = new System.Drawing.Point(778, 862);
			this.chooseBackupLocationButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.chooseBackupLocationButton.Name = "chooseBackupLocationButton";
			this.chooseBackupLocationButton.Size = new System.Drawing.Size(146, 46);
			this.chooseBackupLocationButton.TabIndex = 40;
			this.chooseBackupLocationButton.Text = "Choose...";
			this.chooseBackupLocationButton.UseVisualStyleBackColor = true;
			this.chooseBackupLocationButton.Click += new System.EventHandler(this.chooseBackupLocationButton_Click);
			// 
			// backupLocationTextBox
			// 
			this.backupLocationTextBox.Location = new System.Drawing.Point(22, 867);
			this.backupLocationTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.backupLocationTextBox.Name = "backupLocationTextBox";
			this.backupLocationTextBox.Size = new System.Drawing.Size(738, 31);
			this.backupLocationTextBox.TabIndex = 39;
			// 
			// backupLocationLabel
			// 
			this.backupLocationLabel.AutoSize = true;
			this.backupLocationLabel.Location = new System.Drawing.Point(16, 838);
			this.backupLocationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.backupLocationLabel.Name = "backupLocationLabel";
			this.backupLocationLabel.Size = new System.Drawing.Size(569, 25);
			this.backupLocationLabel.TabIndex = 38;
			this.backupLocationLabel.Text = "Backup Location (the folder where backups will be saved):";
			// 
			// timeZoneComboBox
			// 
			this.timeZoneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.timeZoneComboBox.FormattingEnabled = true;
			this.timeZoneComboBox.Location = new System.Drawing.Point(22, 315);
			this.timeZoneComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.timeZoneComboBox.Name = "timeZoneComboBox";
			this.timeZoneComboBox.Size = new System.Drawing.Size(898, 33);
			this.timeZoneComboBox.TabIndex = 37;
			// 
			// timeZoneLabel
			// 
			this.timeZoneLabel.AutoSize = true;
			this.timeZoneLabel.Location = new System.Drawing.Point(16, 287);
			this.timeZoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.timeZoneLabel.Name = "timeZoneLabel";
			this.timeZoneLabel.Size = new System.Drawing.Size(118, 25);
			this.timeZoneLabel.TabIndex = 36;
			this.timeZoneLabel.Text = "Time zone:";
			// 
			// aircraftClassesLabel
			// 
			this.aircraftClassesLabel.AutoSize = true;
			this.aircraftClassesLabel.Location = new System.Drawing.Point(16, 379);
			this.aircraftClassesLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.aircraftClassesLabel.Name = "aircraftClassesLabel";
			this.aircraftClassesLabel.Size = new System.Drawing.Size(165, 25);
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
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.aircraftClassesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.aircraftClassesDataGridView.ColumnHeadersHeight = 22;
			this.aircraftClassesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.aircraftClassesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedColumn,
            this.CodeColumn,
            this.DescriptionColumn});
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.aircraftClassesDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
			this.aircraftClassesDataGridView.Location = new System.Drawing.Point(22, 408);
			this.aircraftClassesDataGridView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.aircraftClassesDataGridView.MultiSelect = false;
			this.aircraftClassesDataGridView.Name = "aircraftClassesDataGridView";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.aircraftClassesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.aircraftClassesDataGridView.RowHeadersVisible = false;
			this.aircraftClassesDataGridView.RowHeadersWidth = 82;
			this.aircraftClassesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.aircraftClassesDataGridView.Size = new System.Drawing.Size(898, 321);
			this.aircraftClassesDataGridView.TabIndex = 31;
			this.aircraftClassesDataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.aircraftClassesDataGridView_CellMouseUp);
			this.aircraftClassesDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.aircraftClassesDataGridView_CellValueChanged);
			// 
			// SelectedColumn
			// 
			this.SelectedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.SelectedColumn.FillWeight = 45.68528F;
			this.SelectedColumn.HeaderText = "";
			this.SelectedColumn.MinimumWidth = 10;
			this.SelectedColumn.Name = "SelectedColumn";
			this.SelectedColumn.Width = 30;
			// 
			// CodeColumn
			// 
			this.CodeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.CodeColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.CodeColumn.FillWeight = 53.29951F;
			this.CodeColumn.HeaderText = "Code";
			this.CodeColumn.MinimumWidth = 10;
			this.CodeColumn.Name = "CodeColumn";
			this.CodeColumn.ReadOnly = true;
			this.CodeColumn.Width = 55;
			// 
			// DescriptionColumn
			// 
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.DescriptionColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.DescriptionColumn.FillWeight = 201.0153F;
			this.DescriptionColumn.HeaderText = "Description";
			this.DescriptionColumn.MinimumWidth = 10;
			this.DescriptionColumn.Name = "DescriptionColumn";
			this.DescriptionColumn.ReadOnly = true;
			// 
			// finishDatePicker
			// 
			this.finishDatePicker.CustomFormat = "";
			this.finishDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.finishDatePicker.Location = new System.Drawing.Point(322, 225);
			this.finishDatePicker.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.finishDatePicker.Name = "finishDatePicker";
			this.finishDatePicker.Size = new System.Drawing.Size(252, 31);
			this.finishDatePicker.TabIndex = 27;
			// 
			// finishLabel
			// 
			this.finishLabel.AutoSize = true;
			this.finishLabel.Location = new System.Drawing.Point(316, 194);
			this.finishLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.finishLabel.Name = "finishLabel";
			this.finishLabel.Size = new System.Drawing.Size(76, 25);
			this.finishLabel.TabIndex = 26;
			this.finishLabel.Text = "Finish:";
			// 
			// startDatePicker
			// 
			this.startDatePicker.CustomFormat = "";
			this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.startDatePicker.Location = new System.Drawing.Point(22, 225);
			this.startDatePicker.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.startDatePicker.Name = "startDatePicker";
			this.startDatePicker.Size = new System.Drawing.Size(252, 31);
			this.startDatePicker.TabIndex = 25;
			// 
			// startLabel
			// 
			this.startLabel.AutoSize = true;
			this.startLabel.Location = new System.Drawing.Point(16, 194);
			this.startLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.startLabel.Name = "startLabel";
			this.startLabel.Size = new System.Drawing.Size(63, 25);
			this.startLabel.TabIndex = 24;
			this.startLabel.Text = "Start:";
			// 
			// chooseLocationButton
			// 
			this.chooseLocationButton.Location = new System.Drawing.Point(778, 779);
			this.chooseLocationButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.chooseLocationButton.Name = "chooseLocationButton";
			this.chooseLocationButton.Size = new System.Drawing.Size(146, 46);
			this.chooseLocationButton.TabIndex = 30;
			this.chooseLocationButton.Text = "Choose...";
			this.chooseLocationButton.UseVisualStyleBackColor = true;
			this.chooseLocationButton.Click += new System.EventHandler(this.chooseLocationButton_Click);
			// 
			// locationTextBox
			// 
			this.locationTextBox.Location = new System.Drawing.Point(22, 783);
			this.locationTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.locationTextBox.Name = "locationTextBox";
			this.locationTextBox.Size = new System.Drawing.Size(738, 31);
			this.locationTextBox.TabIndex = 29;
			// 
			// locationLabel
			// 
			this.locationLabel.AutoSize = true;
			this.locationLabel.Location = new System.Drawing.Point(16, 754);
			this.locationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.locationLabel.Name = "locationLabel";
			this.locationLabel.Size = new System.Drawing.Size(570, 25);
			this.locationLabel.TabIndex = 28;
			this.locationLabel.Text = "Location (the folder where competition data will be stored):";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(22, 48);
			this.nameTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(898, 31);
			this.nameTextBox.TabIndex = 23;
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(16, 15);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(74, 25);
			this.nameLabel.TabIndex = 22;
			this.nameLabel.Text = "Name:";
			// 
			// trackAnalysisTabPage
			// 
			this.trackAnalysisTabPage.Controls.Add(this.defaultGateWidthUnitsLabel);
			this.trackAnalysisTabPage.Controls.Add(this.defaultGateWidthTextBox);
			this.trackAnalysisTabPage.Controls.Add(this.defaultGateWidthLabel);
			this.trackAnalysisTabPage.Controls.Add(this.defaultPointRadiusUnitsLabel);
			this.trackAnalysisTabPage.Controls.Add(this.defaultPointRadiusTextBox);
			this.trackAnalysisTabPage.Controls.Add(this.defaultPointRadiusLabel);
			this.trackAnalysisTabPage.Controls.Add(this.loggersGroupBox);
			this.trackAnalysisTabPage.Location = new System.Drawing.Point(8, 39);
			this.trackAnalysisTabPage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.trackAnalysisTabPage.Name = "trackAnalysisTabPage";
			this.trackAnalysisTabPage.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.trackAnalysisTabPage.Size = new System.Drawing.Size(952, 934);
			this.trackAnalysisTabPage.TabIndex = 2;
			this.trackAnalysisTabPage.Text = "Track Analysis";
			this.trackAnalysisTabPage.UseVisualStyleBackColor = true;
			// 
			// defaultPointRadiusUnitsLabel
			// 
			this.defaultPointRadiusUnitsLabel.AutoSize = true;
			this.defaultPointRadiusUnitsLabel.Location = new System.Drawing.Point(350, 708);
			this.defaultPointRadiusUnitsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.defaultPointRadiusUnitsLabel.Name = "defaultPointRadiusUnitsLabel";
			this.defaultPointRadiusUnitsLabel.Size = new System.Drawing.Size(77, 25);
			this.defaultPointRadiusUnitsLabel.TabIndex = 46;
			this.defaultPointRadiusUnitsLabel.Text = "metres";
			// 
			// defaultPointRadiusTextBox
			// 
			this.defaultPointRadiusTextBox.Location = new System.Drawing.Point(228, 702);
			this.defaultPointRadiusTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.defaultPointRadiusTextBox.Name = "defaultPointRadiusTextBox";
			this.defaultPointRadiusTextBox.Size = new System.Drawing.Size(106, 31);
			this.defaultPointRadiusTextBox.TabIndex = 45;
			this.defaultPointRadiusTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.defaultTurnpointRadiusTextBox_Validating);
			// 
			// defaultPointRadiusLabel
			// 
			this.defaultPointRadiusLabel.AutoSize = true;
			this.defaultPointRadiusLabel.Location = new System.Drawing.Point(14, 708);
			this.defaultPointRadiusLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.defaultPointRadiusLabel.Name = "defaultPointRadiusLabel";
			this.defaultPointRadiusLabel.Size = new System.Drawing.Size(204, 25);
			this.defaultPointRadiusLabel.TabIndex = 44;
			this.defaultPointRadiusLabel.Text = "Default point radius:";
			// 
			// loggersGroupBox
			// 
			this.loggersGroupBox.Controls.Add(this.flymasterApiGroupBox);
			this.loggersGroupBox.Controls.Add(this.loggersNoteLabel);
			this.loggersGroupBox.Controls.Add(this.chooseFlymasterIgcLocationButton);
			this.loggersGroupBox.Controls.Add(this.flymasterIgcLocationTextBox);
			this.loggersGroupBox.Controls.Add(this.flymasterIgcLocationLabel);
			this.loggersGroupBox.Controls.Add(this.chooseFrdlIgcLocationButton);
			this.loggersGroupBox.Controls.Add(this.frdlIgcLocationTextBox);
			this.loggersGroupBox.Controls.Add(this.frdlIgcLocationLabel);
			this.loggersGroupBox.Location = new System.Drawing.Point(20, 12);
			this.loggersGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.loggersGroupBox.Name = "loggersGroupBox";
			this.loggersGroupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.loggersGroupBox.Size = new System.Drawing.Size(912, 648);
			this.loggersGroupBox.TabIndex = 43;
			this.loggersGroupBox.TabStop = false;
			this.loggersGroupBox.Text = "Loggers";
			// 
			// flymasterApiGroupBox
			// 
			this.flymasterApiGroupBox.Controls.Add(this.flymasterApiGroupIdTextBox);
			this.flymasterApiGroupBox.Controls.Add(this.flymasterApiGroupIdLabel);
			this.flymasterApiGroupBox.Controls.Add(this.flymasterApiPasswordTextBox);
			this.flymasterApiGroupBox.Controls.Add(this.flymasterApiPasswordlabel);
			this.flymasterApiGroupBox.Controls.Add(this.flymasterApiUsernameTextBox);
			this.flymasterApiGroupBox.Controls.Add(this.flymasterApiUsernameLabel);
			this.flymasterApiGroupBox.Location = new System.Drawing.Point(24, 287);
			this.flymasterApiGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.flymasterApiGroupBox.Name = "flymasterApiGroupBox";
			this.flymasterApiGroupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.flymasterApiGroupBox.Size = new System.Drawing.Size(868, 256);
			this.flymasterApiGroupBox.TabIndex = 53;
			this.flymasterApiGroupBox.TabStop = false;
			this.flymasterApiGroupBox.Text = "Flymaster API";
			// 
			// flymasterApiGroupIdTextBox
			// 
			this.flymasterApiGroupIdTextBox.Location = new System.Drawing.Point(184, 171);
			this.flymasterApiGroupIdTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.flymasterApiGroupIdTextBox.Name = "flymasterApiGroupIdTextBox";
			this.flymasterApiGroupIdTextBox.Size = new System.Drawing.Size(194, 31);
			this.flymasterApiGroupIdTextBox.TabIndex = 5;
			// 
			// flymasterApiGroupIdLabel
			// 
			this.flymasterApiGroupIdLabel.AutoSize = true;
			this.flymasterApiGroupIdLabel.Location = new System.Drawing.Point(34, 177);
			this.flymasterApiGroupIdLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.flymasterApiGroupIdLabel.Name = "flymasterApiGroupIdLabel";
			this.flymasterApiGroupIdLabel.Size = new System.Drawing.Size(103, 25);
			this.flymasterApiGroupIdLabel.TabIndex = 4;
			this.flymasterApiGroupIdLabel.Text = "Group ID:";
			// 
			// flymasterApiPasswordTextBox
			// 
			this.flymasterApiPasswordTextBox.Location = new System.Drawing.Point(184, 121);
			this.flymasterApiPasswordTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.flymasterApiPasswordTextBox.Name = "flymasterApiPasswordTextBox";
			this.flymasterApiPasswordTextBox.Size = new System.Drawing.Size(356, 31);
			this.flymasterApiPasswordTextBox.TabIndex = 3;
			// 
			// flymasterApiPasswordlabel
			// 
			this.flymasterApiPasswordlabel.AutoSize = true;
			this.flymasterApiPasswordlabel.Location = new System.Drawing.Point(34, 127);
			this.flymasterApiPasswordlabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.flymasterApiPasswordlabel.Name = "flymasterApiPasswordlabel";
			this.flymasterApiPasswordlabel.Size = new System.Drawing.Size(112, 25);
			this.flymasterApiPasswordlabel.TabIndex = 2;
			this.flymasterApiPasswordlabel.Text = "Password:";
			// 
			// flymasterApiUsernameTextBox
			// 
			this.flymasterApiUsernameTextBox.Location = new System.Drawing.Point(184, 71);
			this.flymasterApiUsernameTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.flymasterApiUsernameTextBox.Name = "flymasterApiUsernameTextBox";
			this.flymasterApiUsernameTextBox.Size = new System.Drawing.Size(356, 31);
			this.flymasterApiUsernameTextBox.TabIndex = 1;
			// 
			// flymasterApiUsernameLabel
			// 
			this.flymasterApiUsernameLabel.AutoSize = true;
			this.flymasterApiUsernameLabel.Location = new System.Drawing.Point(30, 77);
			this.flymasterApiUsernameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.flymasterApiUsernameLabel.Name = "flymasterApiUsernameLabel";
			this.flymasterApiUsernameLabel.Size = new System.Drawing.Size(116, 25);
			this.flymasterApiUsernameLabel.TabIndex = 0;
			this.flymasterApiUsernameLabel.Text = "Username:";
			// 
			// loggersNoteLabel
			// 
			this.loggersNoteLabel.AutoSize = true;
			this.loggersNoteLabel.Location = new System.Drawing.Point(22, 594);
			this.loggersNoteLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.loggersNoteLabel.Name = "loggersNoteLabel";
			this.loggersNoteLabel.Size = new System.Drawing.Size(894, 25);
			this.loggersNoteLabel.TabIndex = 52;
			this.loggersNoteLabel.Text = "Note: if both Flymaster and FRDL tracks are found then the Flymaster tracks will " +
    "take priority";
			// 
			// chooseFlymasterIgcLocationButton
			// 
			this.chooseFlymasterIgcLocationButton.Location = new System.Drawing.Point(746, 198);
			this.chooseFlymasterIgcLocationButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.chooseFlymasterIgcLocationButton.Name = "chooseFlymasterIgcLocationButton";
			this.chooseFlymasterIgcLocationButton.Size = new System.Drawing.Size(146, 46);
			this.chooseFlymasterIgcLocationButton.TabIndex = 51;
			this.chooseFlymasterIgcLocationButton.Text = "Choose...";
			this.chooseFlymasterIgcLocationButton.UseVisualStyleBackColor = true;
			this.chooseFlymasterIgcLocationButton.Click += new System.EventHandler(this.chooseFlymasterIgcLocationButton_Click);
			// 
			// flymasterIgcLocationTextBox
			// 
			this.flymasterIgcLocationTextBox.Location = new System.Drawing.Point(24, 204);
			this.flymasterIgcLocationTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.flymasterIgcLocationTextBox.Name = "flymasterIgcLocationTextBox";
			this.flymasterIgcLocationTextBox.Size = new System.Drawing.Size(708, 31);
			this.flymasterIgcLocationTextBox.TabIndex = 50;
			// 
			// flymasterIgcLocationLabel
			// 
			this.flymasterIgcLocationLabel.AutoSize = true;
			this.flymasterIgcLocationLabel.Location = new System.Drawing.Point(22, 173);
			this.flymasterIgcLocationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.flymasterIgcLocationLabel.Name = "flymasterIgcLocationLabel";
			this.flymasterIgcLocationLabel.Size = new System.Drawing.Size(314, 25);
			this.flymasterIgcLocationLabel.TabIndex = 49;
			this.flymasterIgcLocationLabel.Text = "Flymaster Tracker IGC location:";
			// 
			// chooseFrdlIgcLocationButton
			// 
			this.chooseFrdlIgcLocationButton.Location = new System.Drawing.Point(746, 85);
			this.chooseFrdlIgcLocationButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.chooseFrdlIgcLocationButton.Name = "chooseFrdlIgcLocationButton";
			this.chooseFrdlIgcLocationButton.Size = new System.Drawing.Size(146, 46);
			this.chooseFrdlIgcLocationButton.TabIndex = 47;
			this.chooseFrdlIgcLocationButton.Text = "Choose...";
			this.chooseFrdlIgcLocationButton.UseVisualStyleBackColor = true;
			this.chooseFrdlIgcLocationButton.Click += new System.EventHandler(this.chooseFrdlIgcLocationButton_Click);
			// 
			// frdlIgcLocationTextBox
			// 
			this.frdlIgcLocationTextBox.Location = new System.Drawing.Point(24, 90);
			this.frdlIgcLocationTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.frdlIgcLocationTextBox.Name = "frdlIgcLocationTextBox";
			this.frdlIgcLocationTextBox.Size = new System.Drawing.Size(706, 31);
			this.frdlIgcLocationTextBox.TabIndex = 46;
			// 
			// frdlIgcLocationLabel
			// 
			this.frdlIgcLocationLabel.AutoSize = true;
			this.frdlIgcLocationLabel.Location = new System.Drawing.Point(22, 60);
			this.frdlIgcLocationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.frdlIgcLocationLabel.Name = "frdlIgcLocationLabel";
			this.frdlIgcLocationLabel.Size = new System.Drawing.Size(804, 25);
			this.frdlIgcLocationLabel.TabIndex = 45;
			this.frdlIgcLocationLabel.Text = "FRDL IGC location (the folder where FRDL stores tracks, normally called \'igcFiles" +
    "\'):";
			// 
			// nationTabPage
			// 
			this.nationTabPage.Controls.Add(this.nationDefinitionsLabel);
			this.nationTabPage.Controls.Add(this.nationDefinitionsDataGridView);
			this.nationTabPage.Location = new System.Drawing.Point(8, 39);
			this.nationTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nationTabPage.Name = "nationTabPage";
			this.nationTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nationTabPage.Size = new System.Drawing.Size(952, 934);
			this.nationTabPage.TabIndex = 1;
			this.nationTabPage.Text = "Nation";
			this.nationTabPage.UseVisualStyleBackColor = true;
			// 
			// nationDefinitionsLabel
			// 
			this.nationDefinitionsLabel.AutoSize = true;
			this.nationDefinitionsLabel.Location = new System.Drawing.Point(16, 15);
			this.nationDefinitionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.nationDefinitionsLabel.Name = "nationDefinitionsLabel";
			this.nationDefinitionsLabel.Size = new System.Drawing.Size(565, 25);
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
			this.nationDefinitionsDataGridView.Location = new System.Drawing.Point(22, 50);
			this.nationDefinitionsDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nationDefinitionsDataGridView.MultiSelect = false;
			this.nationDefinitionsDataGridView.Name = "nationDefinitionsDataGridView";
			this.nationDefinitionsDataGridView.RowHeadersVisible = false;
			this.nationDefinitionsDataGridView.RowHeadersWidth = 82;
			this.nationDefinitionsDataGridView.RowTemplate.Height = 28;
			this.nationDefinitionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.nationDefinitionsDataGridView.Size = new System.Drawing.Size(426, 537);
			this.nationDefinitionsDataGridView.TabIndex = 0;
			this.nationDefinitionsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.nationDefinitionsDataGridView_CellValidating);
			// 
			// nationAircraftClassColumn
			// 
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			this.nationAircraftClassColumn.DefaultCellStyle = dataGridViewCellStyle6;
			this.nationAircraftClassColumn.HeaderText = "Aircraft Class";
			this.nationAircraftClassColumn.MinimumWidth = 10;
			this.nationAircraftClassColumn.Name = "nationAircraftClassColumn";
			this.nationAircraftClassColumn.ReadOnly = true;
			// 
			// nationNumberWhoScoreColumn
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
			this.nationNumberWhoScoreColumn.DefaultCellStyle = dataGridViewCellStyle7;
			this.nationNumberWhoScoreColumn.FillWeight = 125F;
			this.nationNumberWhoScoreColumn.HeaderText = "Number Who Score";
			this.nationNumberWhoScoreColumn.MinimumWidth = 10;
			this.nationNumberWhoScoreColumn.Name = "nationNumberWhoScoreColumn";
			// 
			// logoDialog
			// 
			this.logoDialog.Filter = "Image files|*.jpg;*.png;*.gif;*.bmp";
			this.logoDialog.Title = "Select logo";
			// 
			// defaultGateWidthLabel
			// 
			this.defaultGateWidthLabel.AutoSize = true;
			this.defaultGateWidthLabel.Location = new System.Drawing.Point(15, 761);
			this.defaultGateWidthLabel.Name = "defaultGateWidthLabel";
			this.defaultGateWidthLabel.Size = new System.Drawing.Size(190, 25);
			this.defaultGateWidthLabel.TabIndex = 47;
			this.defaultGateWidthLabel.Text = "Default gate width:";
			// 
			// defaultGateWidthTextBox
			// 
			this.defaultGateWidthTextBox.Location = new System.Drawing.Point(228, 758);
			this.defaultGateWidthTextBox.Name = "defaultGateWidthTextBox";
			this.defaultGateWidthTextBox.Size = new System.Drawing.Size(106, 31);
			this.defaultGateWidthTextBox.TabIndex = 48;
			// 
			// defaultGateWidthUnitsLabel
			// 
			this.defaultGateWidthUnitsLabel.AutoSize = true;
			this.defaultGateWidthUnitsLabel.Location = new System.Drawing.Point(350, 761);
			this.defaultGateWidthUnitsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.defaultGateWidthUnitsLabel.Name = "defaultGateWidthUnitsLabel";
			this.defaultGateWidthUnitsLabel.Size = new System.Drawing.Size(77, 25);
			this.defaultGateWidthUnitsLabel.TabIndex = 49;
			this.defaultGateWidthUnitsLabel.Text = "metres";
			// 
			// CompetitionForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(1000, 1069);
			this.Controls.Add(this.competitionTabControl);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
			this.flymasterApiGroupBox.ResumeLayout(false);
			this.flymasterApiGroupBox.PerformLayout();
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
		private System.Windows.Forms.Button chooseFrdlIgcLocationButton;
		private System.Windows.Forms.TextBox frdlIgcLocationTextBox;
		private System.Windows.Forms.Label frdlIgcLocationLabel;
		private System.Windows.Forms.Label defaultPointRadiusUnitsLabel;
		private System.Windows.Forms.TextBox defaultPointRadiusTextBox;
		private System.Windows.Forms.Label defaultPointRadiusLabel;
		private System.Windows.Forms.Label loggersNoteLabel;
		private System.Windows.Forms.GroupBox flymasterApiGroupBox;
		private System.Windows.Forms.TextBox flymasterApiGroupIdTextBox;
		private System.Windows.Forms.Label flymasterApiGroupIdLabel;
		private System.Windows.Forms.TextBox flymasterApiPasswordTextBox;
		private System.Windows.Forms.Label flymasterApiPasswordlabel;
		private System.Windows.Forms.TextBox flymasterApiUsernameTextBox;
		private System.Windows.Forms.Label flymasterApiUsernameLabel;
		private System.Windows.Forms.Button chooseLogoButton;
		private System.Windows.Forms.TextBox logoTextBox;
		private System.Windows.Forms.Label logoLabel;
		private System.Windows.Forms.OpenFileDialog logoDialog;
		private System.Windows.Forms.Label defaultGateWidthLabel;
		private System.Windows.Forms.Label defaultGateWidthUnitsLabel;
		private System.Windows.Forms.TextBox defaultGateWidthTextBox;
	}
}