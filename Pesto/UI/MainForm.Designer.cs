namespace ColinBaker.Pesto.UI
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainRibbon = new System.Windows.Forms.Ribbon();
			this.homeRibbonTab = new System.Windows.Forms.RibbonTab();
			this.competitionRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.newCompetitionRibbonButton = new System.Windows.Forms.RibbonButton();
			this.openCompetitionRibbonButton = new System.Windows.Forms.RibbonButton();
			this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
			this.competitionPropertiesRibbonButton = new System.Windows.Forms.RibbonButton();
			this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
			this.reloadRibbonButton = new System.Windows.Forms.RibbonButton();
			this.backupRibbonButton = new System.Windows.Forms.RibbonButton();
			this.remindersRibbonButton = new System.Windows.Forms.RibbonButton();
			this.defineFeaturesRibbonButton = new System.Windows.Forms.RibbonButton();
			this.ribbonSeparator5 = new System.Windows.Forms.RibbonSeparator();
			this.pilotsRibbonButton = new System.Windows.Forms.RibbonButton();
			this.pilotsSpreadsheetRibbonButton = new System.Windows.Forms.RibbonButton();
			this.pilotMappingsRibbonButton = new System.Windows.Forms.RibbonButton();
			this.taskRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.addTaskRibbonButton = new System.Windows.Forms.RibbonButton();
			this.editTaskRibbonButton = new System.Windows.Forms.RibbonButton();
			this.ribbonSeparator6 = new System.Windows.Forms.RibbonSeparator();
			this.scoresRibbonButton = new System.Windows.Forms.RibbonButton();
			this.taskSpreadsheetRibbonButton = new System.Windows.Forms.RibbonButton();
			this.taskMappingsRibbonButton = new System.Windows.Forms.RibbonButton();
			this.ribbonSeparator7 = new System.Windows.Forms.RibbonSeparator();
			this.selectTaskFeaturesRibbonButton = new System.Windows.Forms.RibbonButton();
			this.trackAnalysisRibbonButton = new System.Windows.Forms.RibbonButton();
			this.resultsRibbonTab = new System.Windows.Forms.RibbonTab();
			this.generateRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.generateTaskRibbonButton = new System.Windows.Forms.RibbonButton();
			this.generateOverallRibbonButton = new System.Windows.Forms.RibbonButton();
			this.generateTeamRibbonButton = new System.Windows.Forms.RibbonButton();
			this.generateNationRibbonButton = new System.Windows.Forms.RibbonButton();
			this.publishRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.printRibbonButton = new System.Windows.Forms.RibbonButton();
			this.uploadRibbonButton = new System.Windows.Forms.RibbonButton();
			this.miscellaneousRibbonTab = new System.Windows.Forms.RibbonTab();
			this.toolsRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.optionsRibbonButton = new System.Windows.Forms.RibbonButton();
			this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
			this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
			this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
			this.convertTracksRibbonButton = new System.Windows.Forms.RibbonButton();
			this.createPdfRibbonButton = new System.Windows.Forms.RibbonButton();
			this.calculateDistanceRibbonButton = new System.Windows.Forms.RibbonButton();
			this.helpRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.aboutRibbonButton = new System.Windows.Forms.RibbonButton();
			this.checkForUpdatesRibbonButton = new System.Windows.Forms.RibbonButton();
			this.openCompetitionDialog = new System.Windows.Forms.OpenFileDialog();
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.pnlStartup = new System.Windows.Forms.Panel();
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.tasksTaskListBox = new ColinBaker.Pesto.UI.TaskListBox();
			this.nationResultsPdfViewer = new ColinBaker.Pesto.UI.PdfViewer();
			this.taskResultsPdfViewer = new ColinBaker.Pesto.UI.PdfViewer();
			this.aircraftClassesListBox = new ColinBaker.Pesto.UI.AircraftClassListBox();
			this.resultsTabControl = new System.Windows.Forms.TabControl();
			this.competitionResultsTabPage = new System.Windows.Forms.TabPage();
			this.competitionResultsPdfViewer = new ColinBaker.Pesto.UI.PdfViewer();
			this.teamResultsTabPage = new System.Windows.Forms.TabPage();
			this.teamResultsPdfViewer = new ColinBaker.Pesto.UI.PdfViewer();
			this.reminderNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			this.resultsTabControl.SuspendLayout();
			this.competitionResultsTabPage.SuspendLayout();
			this.teamResultsTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainRibbon
			// 
			this.mainRibbon.CaptionBarVisible = false;
			this.mainRibbon.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.mainRibbon.Location = new System.Drawing.Point(0, 0);
			this.mainRibbon.Minimized = false;
			this.mainRibbon.Name = "mainRibbon";
			// 
			// 
			// 
			this.mainRibbon.OrbDropDown.BorderRoundness = 8;
			this.mainRibbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
			this.mainRibbon.OrbDropDown.Name = "";
			this.mainRibbon.OrbDropDown.Size = new System.Drawing.Size(527, 447);
			this.mainRibbon.OrbDropDown.TabIndex = 0;
			this.mainRibbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
			this.mainRibbon.OrbVisible = false;
			this.mainRibbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
			this.mainRibbon.Size = new System.Drawing.Size(699, 122);
			this.mainRibbon.TabIndex = 0;
			this.mainRibbon.Tabs.Add(this.homeRibbonTab);
			this.mainRibbon.Tabs.Add(this.resultsRibbonTab);
			this.mainRibbon.Tabs.Add(this.miscellaneousRibbonTab);
			this.mainRibbon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
			this.mainRibbon.TabSpacing = 4;
			this.mainRibbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
			// 
			// homeRibbonTab
			// 
			this.homeRibbonTab.Name = "homeRibbonTab";
			this.homeRibbonTab.Panels.Add(this.competitionRibbonPanel);
			this.homeRibbonTab.Panels.Add(this.taskRibbonPanel);
			this.homeRibbonTab.Text = "Home";
			this.homeRibbonTab.Value = "";
			// 
			// competitionRibbonPanel
			// 
			this.competitionRibbonPanel.ButtonMoreVisible = false;
			this.competitionRibbonPanel.Image = ((System.Drawing.Image)(resources.GetObject("competitionRibbonPanel.Image")));
			this.competitionRibbonPanel.Items.Add(this.newCompetitionRibbonButton);
			this.competitionRibbonPanel.Items.Add(this.openCompetitionRibbonButton);
			this.competitionRibbonPanel.Items.Add(this.competitionPropertiesRibbonButton);
			this.competitionRibbonPanel.Items.Add(this.ribbonSeparator1);
			this.competitionRibbonPanel.Items.Add(this.reloadRibbonButton);
			this.competitionRibbonPanel.Items.Add(this.backupRibbonButton);
			this.competitionRibbonPanel.Items.Add(this.remindersRibbonButton);
			this.competitionRibbonPanel.Items.Add(this.defineFeaturesRibbonButton);
			this.competitionRibbonPanel.Items.Add(this.ribbonSeparator5);
			this.competitionRibbonPanel.Items.Add(this.pilotsRibbonButton);
			this.competitionRibbonPanel.Name = "competitionRibbonPanel";
			this.competitionRibbonPanel.Text = "Competition";
			// 
			// newCompetitionRibbonButton
			// 
			this.newCompetitionRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("newCompetitionRibbonButton.Image")));
			this.newCompetitionRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("newCompetitionRibbonButton.LargeImage")));
			this.newCompetitionRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.newCompetitionRibbonButton.Name = "newCompetitionRibbonButton";
			this.newCompetitionRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("newCompetitionRibbonButton.SmallImage")));
			this.newCompetitionRibbonButton.Text = "New";
			this.newCompetitionRibbonButton.Click += new System.EventHandler(this.newCompetitionRibbonButton_Click);
			// 
			// openCompetitionRibbonButton
			// 
			this.openCompetitionRibbonButton.DropDownItems.Add(this.ribbonButton1);
			this.openCompetitionRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("openCompetitionRibbonButton.Image")));
			this.openCompetitionRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("openCompetitionRibbonButton.LargeImage")));
			this.openCompetitionRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.openCompetitionRibbonButton.Name = "openCompetitionRibbonButton";
			this.openCompetitionRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("openCompetitionRibbonButton.SmallImage")));
			this.openCompetitionRibbonButton.Style = System.Windows.Forms.RibbonButtonStyle.SplitDropDown;
			this.openCompetitionRibbonButton.Text = "Open";
			this.openCompetitionRibbonButton.DropDownItemClicked += new System.Windows.Forms.RibbonButton.RibbonItemEventHandler(this.openCompetitionRibbonButton_DropDownItemClicked);
			this.openCompetitionRibbonButton.Click += new System.EventHandler(this.openCompetitionRibbonButton_Click);
			// 
			// ribbonButton1
			// 
			this.ribbonButton1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
			this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
			this.ribbonButton1.Name = "ribbonButton1";
			this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
			this.ribbonButton1.Text = "Test";
			// 
			// competitionPropertiesRibbonButton
			// 
			this.competitionPropertiesRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("competitionPropertiesRibbonButton.Image")));
			this.competitionPropertiesRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("competitionPropertiesRibbonButton.LargeImage")));
			this.competitionPropertiesRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.competitionPropertiesRibbonButton.Name = "competitionPropertiesRibbonButton";
			this.competitionPropertiesRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("competitionPropertiesRibbonButton.SmallImage")));
			this.competitionPropertiesRibbonButton.Text = "Properties";
			this.competitionPropertiesRibbonButton.Click += new System.EventHandler(this.competitionPropertiesRibbonButton_Click);
			// 
			// ribbonSeparator1
			// 
			this.ribbonSeparator1.Name = "ribbonSeparator1";
			// 
			// reloadRibbonButton
			// 
			this.reloadRibbonButton.FlashIntervall = 750;
			this.reloadRibbonButton.FlashSmallImage = ((System.Drawing.Image)(resources.GetObject("reloadRibbonButton.FlashSmallImage")));
			this.reloadRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("reloadRibbonButton.Image")));
			this.reloadRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("reloadRibbonButton.LargeImage")));
			this.reloadRibbonButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.reloadRibbonButton.Name = "reloadRibbonButton";
			this.reloadRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("reloadRibbonButton.SmallImage")));
			this.reloadRibbonButton.Text = "Reload";
			this.reloadRibbonButton.Click += new System.EventHandler(this.reloadRibbonButton_Click);
			// 
			// backupRibbonButton
			// 
			this.backupRibbonButton.FlashIntervall = 750;
			this.backupRibbonButton.FlashSmallImage = ((System.Drawing.Image)(resources.GetObject("backupRibbonButton.FlashSmallImage")));
			this.backupRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("backupRibbonButton.Image")));
			this.backupRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("backupRibbonButton.LargeImage")));
			this.backupRibbonButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.backupRibbonButton.Name = "backupRibbonButton";
			this.backupRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("backupRibbonButton.SmallImage")));
			this.backupRibbonButton.Text = "Backup";
			this.backupRibbonButton.Click += new System.EventHandler(this.backupRibbonButton_Click);
			// 
			// remindersRibbonButton
			// 
			this.remindersRibbonButton.FlashIntervall = 750;
			this.remindersRibbonButton.FlashSmallImage = ((System.Drawing.Image)(resources.GetObject("remindersRibbonButton.FlashSmallImage")));
			this.remindersRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("remindersRibbonButton.Image")));
			this.remindersRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("remindersRibbonButton.LargeImage")));
			this.remindersRibbonButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.remindersRibbonButton.Name = "remindersRibbonButton";
			this.remindersRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("remindersRibbonButton.SmallImage")));
			this.remindersRibbonButton.Text = "Reminders";
			this.remindersRibbonButton.Click += new System.EventHandler(this.remindersRibbonButton_Click);
			// 
			// defineFeaturesRibbonButton
			// 
			this.defineFeaturesRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("defineFeaturesRibbonButton.Image")));
			this.defineFeaturesRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("defineFeaturesRibbonButton.LargeImage")));
			this.defineFeaturesRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.defineFeaturesRibbonButton.Name = "defineFeaturesRibbonButton";
			this.defineFeaturesRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("defineFeaturesRibbonButton.SmallImage")));
			this.defineFeaturesRibbonButton.Text = "Define Features";
			this.defineFeaturesRibbonButton.Click += new System.EventHandler(this.defineFeaturesRibbonButton_Click);
			// 
			// ribbonSeparator5
			// 
			this.ribbonSeparator5.Name = "ribbonSeparator5";
			// 
			// pilotsRibbonButton
			// 
			this.pilotsRibbonButton.DropDownItems.Add(this.pilotsSpreadsheetRibbonButton);
			this.pilotsRibbonButton.DropDownItems.Add(this.pilotMappingsRibbonButton);
			this.pilotsRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("pilotsRibbonButton.Image")));
			this.pilotsRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("pilotsRibbonButton.LargeImage")));
			this.pilotsRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.pilotsRibbonButton.Name = "pilotsRibbonButton";
			this.pilotsRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("pilotsRibbonButton.SmallImage")));
			this.pilotsRibbonButton.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
			this.pilotsRibbonButton.Text = "Pilots";
			// 
			// pilotsSpreadsheetRibbonButton
			// 
			this.pilotsSpreadsheetRibbonButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.pilotsSpreadsheetRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("pilotsSpreadsheetRibbonButton.Image")));
			this.pilotsSpreadsheetRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("pilotsSpreadsheetRibbonButton.LargeImage")));
			this.pilotsSpreadsheetRibbonButton.Name = "pilotsSpreadsheetRibbonButton";
			this.pilotsSpreadsheetRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("pilotsSpreadsheetRibbonButton.SmallImage")));
			this.pilotsSpreadsheetRibbonButton.Text = "Spreadsheet";
			this.pilotsSpreadsheetRibbonButton.Click += new System.EventHandler(this.pilotsSpreadsheetRibbonButton_Click);
			// 
			// pilotMappingsRibbonButton
			// 
			this.pilotMappingsRibbonButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.pilotMappingsRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("pilotMappingsRibbonButton.Image")));
			this.pilotMappingsRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("pilotMappingsRibbonButton.LargeImage")));
			this.pilotMappingsRibbonButton.Name = "pilotMappingsRibbonButton";
			this.pilotMappingsRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("pilotMappingsRibbonButton.SmallImage")));
			this.pilotMappingsRibbonButton.Text = "Mappings";
			this.pilotMappingsRibbonButton.Click += new System.EventHandler(this.pilotMappingsRibbonButton_Click);
			// 
			// taskRibbonPanel
			// 
			this.taskRibbonPanel.ButtonMoreVisible = false;
			this.taskRibbonPanel.Image = ((System.Drawing.Image)(resources.GetObject("taskRibbonPanel.Image")));
			this.taskRibbonPanel.Items.Add(this.addTaskRibbonButton);
			this.taskRibbonPanel.Items.Add(this.editTaskRibbonButton);
			this.taskRibbonPanel.Items.Add(this.ribbonSeparator6);
			this.taskRibbonPanel.Items.Add(this.scoresRibbonButton);
			this.taskRibbonPanel.Items.Add(this.ribbonSeparator7);
			this.taskRibbonPanel.Items.Add(this.selectTaskFeaturesRibbonButton);
			this.taskRibbonPanel.Items.Add(this.trackAnalysisRibbonButton);
			this.taskRibbonPanel.Name = "taskRibbonPanel";
			this.taskRibbonPanel.Text = "Task";
			// 
			// addTaskRibbonButton
			// 
			this.addTaskRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("addTaskRibbonButton.Image")));
			this.addTaskRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("addTaskRibbonButton.LargeImage")));
			this.addTaskRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.addTaskRibbonButton.Name = "addTaskRibbonButton";
			this.addTaskRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("addTaskRibbonButton.SmallImage")));
			this.addTaskRibbonButton.Text = "Add";
			this.addTaskRibbonButton.Click += new System.EventHandler(this.addTaskRibbonButton_Click);
			// 
			// editTaskRibbonButton
			// 
			this.editTaskRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("editTaskRibbonButton.Image")));
			this.editTaskRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("editTaskRibbonButton.LargeImage")));
			this.editTaskRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.editTaskRibbonButton.Name = "editTaskRibbonButton";
			this.editTaskRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("editTaskRibbonButton.SmallImage")));
			this.editTaskRibbonButton.Text = "Edit";
			this.editTaskRibbonButton.Click += new System.EventHandler(this.editTaskRibbonButton_Click);
			// 
			// ribbonSeparator6
			// 
			this.ribbonSeparator6.Name = "ribbonSeparator6";
			// 
			// scoresRibbonButton
			// 
			this.scoresRibbonButton.DropDownItems.Add(this.taskSpreadsheetRibbonButton);
			this.scoresRibbonButton.DropDownItems.Add(this.taskMappingsRibbonButton);
			this.scoresRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("scoresRibbonButton.Image")));
			this.scoresRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("scoresRibbonButton.LargeImage")));
			this.scoresRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.scoresRibbonButton.Name = "scoresRibbonButton";
			this.scoresRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("scoresRibbonButton.SmallImage")));
			this.scoresRibbonButton.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
			this.scoresRibbonButton.Text = "Scores";
			// 
			// taskSpreadsheetRibbonButton
			// 
			this.taskSpreadsheetRibbonButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.taskSpreadsheetRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("taskSpreadsheetRibbonButton.Image")));
			this.taskSpreadsheetRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("taskSpreadsheetRibbonButton.LargeImage")));
			this.taskSpreadsheetRibbonButton.Name = "taskSpreadsheetRibbonButton";
			this.taskSpreadsheetRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("taskSpreadsheetRibbonButton.SmallImage")));
			this.taskSpreadsheetRibbonButton.Text = "Spreadsheet";
			this.taskSpreadsheetRibbonButton.Click += new System.EventHandler(this.taskSpreadsheetRibbonButton_Click);
			// 
			// taskMappingsRibbonButton
			// 
			this.taskMappingsRibbonButton.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
			this.taskMappingsRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("taskMappingsRibbonButton.Image")));
			this.taskMappingsRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("taskMappingsRibbonButton.LargeImage")));
			this.taskMappingsRibbonButton.Name = "taskMappingsRibbonButton";
			this.taskMappingsRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("taskMappingsRibbonButton.SmallImage")));
			this.taskMappingsRibbonButton.Text = "Mappings";
			this.taskMappingsRibbonButton.Click += new System.EventHandler(this.taskMappingsRibbonButton_Click);
			// 
			// ribbonSeparator7
			// 
			this.ribbonSeparator7.Name = "ribbonSeparator7";
			// 
			// selectTaskFeaturesRibbonButton
			// 
			this.selectTaskFeaturesRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("selectTaskFeaturesRibbonButton.Image")));
			this.selectTaskFeaturesRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("selectTaskFeaturesRibbonButton.LargeImage")));
			this.selectTaskFeaturesRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.selectTaskFeaturesRibbonButton.Name = "selectTaskFeaturesRibbonButton";
			this.selectTaskFeaturesRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("selectTaskFeaturesRibbonButton.SmallImage")));
			this.selectTaskFeaturesRibbonButton.Text = "Select Features";
			this.selectTaskFeaturesRibbonButton.Click += new System.EventHandler(this.selectTaskFeaturesRibbonButton_Click);
			// 
			// trackAnalysisRibbonButton
			// 
			this.trackAnalysisRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("trackAnalysisRibbonButton.Image")));
			this.trackAnalysisRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("trackAnalysisRibbonButton.LargeImage")));
			this.trackAnalysisRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.trackAnalysisRibbonButton.Name = "trackAnalysisRibbonButton";
			this.trackAnalysisRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("trackAnalysisRibbonButton.SmallImage")));
			this.trackAnalysisRibbonButton.Text = "Track Analysis";
			this.trackAnalysisRibbonButton.Click += new System.EventHandler(this.trackAnalysisRibbonButton_Click);
			// 
			// resultsRibbonTab
			// 
			this.resultsRibbonTab.Name = "resultsRibbonTab";
			this.resultsRibbonTab.Panels.Add(this.generateRibbonPanel);
			this.resultsRibbonTab.Panels.Add(this.publishRibbonPanel);
			this.resultsRibbonTab.Text = "Results";
			// 
			// generateRibbonPanel
			// 
			this.generateRibbonPanel.ButtonMoreVisible = false;
			this.generateRibbonPanel.Image = ((System.Drawing.Image)(resources.GetObject("generateRibbonPanel.Image")));
			this.generateRibbonPanel.Items.Add(this.generateTaskRibbonButton);
			this.generateRibbonPanel.Items.Add(this.generateOverallRibbonButton);
			this.generateRibbonPanel.Items.Add(this.generateTeamRibbonButton);
			this.generateRibbonPanel.Items.Add(this.generateNationRibbonButton);
			this.generateRibbonPanel.Name = "generateRibbonPanel";
			this.generateRibbonPanel.Text = "Generate";
			// 
			// generateTaskRibbonButton
			// 
			this.generateTaskRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("generateTaskRibbonButton.Image")));
			this.generateTaskRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("generateTaskRibbonButton.LargeImage")));
			this.generateTaskRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.generateTaskRibbonButton.Name = "generateTaskRibbonButton";
			this.generateTaskRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("generateTaskRibbonButton.SmallImage")));
			this.generateTaskRibbonButton.Text = "Task";
			this.generateTaskRibbonButton.Click += new System.EventHandler(this.generateTaskRibbonButton_Click);
			// 
			// generateOverallRibbonButton
			// 
			this.generateOverallRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("generateOverallRibbonButton.Image")));
			this.generateOverallRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("generateOverallRibbonButton.LargeImage")));
			this.generateOverallRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.generateOverallRibbonButton.Name = "generateOverallRibbonButton";
			this.generateOverallRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("generateOverallRibbonButton.SmallImage")));
			this.generateOverallRibbonButton.Text = "Overall";
			this.generateOverallRibbonButton.Click += new System.EventHandler(this.generateOverallRibbonButton_Click);
			// 
			// generateTeamRibbonButton
			// 
			this.generateTeamRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("generateTeamRibbonButton.Image")));
			this.generateTeamRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("generateTeamRibbonButton.LargeImage")));
			this.generateTeamRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.generateTeamRibbonButton.Name = "generateTeamRibbonButton";
			this.generateTeamRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("generateTeamRibbonButton.SmallImage")));
			this.generateTeamRibbonButton.Text = "Team";
			this.generateTeamRibbonButton.Click += new System.EventHandler(this.generateTeamRibbonButton_Click);
			// 
			// generateNationRibbonButton
			// 
			this.generateNationRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("generateNationRibbonButton.Image")));
			this.generateNationRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("generateNationRibbonButton.LargeImage")));
			this.generateNationRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.generateNationRibbonButton.Name = "generateNationRibbonButton";
			this.generateNationRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("generateNationRibbonButton.SmallImage")));
			this.generateNationRibbonButton.Text = "Nation";
			this.generateNationRibbonButton.Click += new System.EventHandler(this.generateNationRibbonButton_Click);
			// 
			// publishRibbonPanel
			// 
			this.publishRibbonPanel.ButtonMoreVisible = false;
			this.publishRibbonPanel.Image = ((System.Drawing.Image)(resources.GetObject("publishRibbonPanel.Image")));
			this.publishRibbonPanel.Items.Add(this.printRibbonButton);
			this.publishRibbonPanel.Items.Add(this.uploadRibbonButton);
			this.publishRibbonPanel.Name = "publishRibbonPanel";
			this.publishRibbonPanel.Text = "Publish";
			// 
			// printRibbonButton
			// 
			this.printRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("printRibbonButton.Image")));
			this.printRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("printRibbonButton.LargeImage")));
			this.printRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.printRibbonButton.Name = "printRibbonButton";
			this.printRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("printRibbonButton.SmallImage")));
			this.printRibbonButton.Text = "Print";
			this.printRibbonButton.Click += new System.EventHandler(this.printRibbonButton_Click);
			// 
			// uploadRibbonButton
			// 
			this.uploadRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("uploadRibbonButton.Image")));
			this.uploadRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("uploadRibbonButton.LargeImage")));
			this.uploadRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.uploadRibbonButton.Name = "uploadRibbonButton";
			this.uploadRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("uploadRibbonButton.SmallImage")));
			this.uploadRibbonButton.Text = "Upload via FTP";
			this.uploadRibbonButton.Click += new System.EventHandler(this.uploadRibbonButton_Click);
			// 
			// miscellaneousRibbonTab
			// 
			this.miscellaneousRibbonTab.Name = "miscellaneousRibbonTab";
			this.miscellaneousRibbonTab.Panels.Add(this.toolsRibbonPanel);
			this.miscellaneousRibbonTab.Panels.Add(this.helpRibbonPanel);
			this.miscellaneousRibbonTab.Text = "Miscellaneous";
			// 
			// toolsRibbonPanel
			// 
			this.toolsRibbonPanel.ButtonMoreVisible = false;
			this.toolsRibbonPanel.Image = ((System.Drawing.Image)(resources.GetObject("toolsRibbonPanel.Image")));
			this.toolsRibbonPanel.Items.Add(this.optionsRibbonButton);
			this.toolsRibbonPanel.Items.Add(this.ribbonSeparator4);
			this.toolsRibbonPanel.Items.Add(this.convertTracksRibbonButton);
			this.toolsRibbonPanel.Items.Add(this.createPdfRibbonButton);
			this.toolsRibbonPanel.Items.Add(this.calculateDistanceRibbonButton);
			this.toolsRibbonPanel.Name = "toolsRibbonPanel";
			this.toolsRibbonPanel.Text = "Tools";
			// 
			// optionsRibbonButton
			// 
			this.optionsRibbonButton.DropDownItems.Add(this.ribbonSeparator2);
			this.optionsRibbonButton.DropDownItems.Add(this.ribbonSeparator3);
			this.optionsRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("optionsRibbonButton.Image")));
			this.optionsRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("optionsRibbonButton.LargeImage")));
			this.optionsRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.optionsRibbonButton.Name = "optionsRibbonButton";
			this.optionsRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("optionsRibbonButton.SmallImage")));
			this.optionsRibbonButton.Text = "Options";
			this.optionsRibbonButton.Click += new System.EventHandler(this.optionsRibbonButton_Click);
			// 
			// ribbonSeparator2
			// 
			this.ribbonSeparator2.Name = "ribbonSeparator2";
			// 
			// ribbonSeparator3
			// 
			this.ribbonSeparator3.Name = "ribbonSeparator3";
			// 
			// ribbonSeparator4
			// 
			this.ribbonSeparator4.Name = "ribbonSeparator4";
			// 
			// convertTracksRibbonButton
			// 
			this.convertTracksRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("convertTracksRibbonButton.Image")));
			this.convertTracksRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("convertTracksRibbonButton.LargeImage")));
			this.convertTracksRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.convertTracksRibbonButton.Name = "convertTracksRibbonButton";
			this.convertTracksRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("convertTracksRibbonButton.SmallImage")));
			this.convertTracksRibbonButton.Text = "Convert Tracks";
			this.convertTracksRibbonButton.Click += new System.EventHandler(this.convertTracksRibbonButton_Click);
			// 
			// createPdfRibbonButton
			// 
			this.createPdfRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("createPdfRibbonButton.Image")));
			this.createPdfRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("createPdfRibbonButton.LargeImage")));
			this.createPdfRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.createPdfRibbonButton.Name = "createPdfRibbonButton";
			this.createPdfRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("createPdfRibbonButton.SmallImage")));
			this.createPdfRibbonButton.Text = "Create PDF";
			this.createPdfRibbonButton.Click += new System.EventHandler(this.createPdfRibbonButton_Click);
			// 
			// calculateDistanceRibbonButton
			// 
			this.calculateDistanceRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("calculateDistanceRibbonButton.Image")));
			this.calculateDistanceRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("calculateDistanceRibbonButton.LargeImage")));
			this.calculateDistanceRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.calculateDistanceRibbonButton.Name = "calculateDistanceRibbonButton";
			this.calculateDistanceRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("calculateDistanceRibbonButton.SmallImage")));
			this.calculateDistanceRibbonButton.Text = "Calculate Distance";
			this.calculateDistanceRibbonButton.Click += new System.EventHandler(this.calculateDistanceRibbonButton_Click);
			// 
			// helpRibbonPanel
			// 
			this.helpRibbonPanel.ButtonMoreVisible = false;
			this.helpRibbonPanel.Image = ((System.Drawing.Image)(resources.GetObject("helpRibbonPanel.Image")));
			this.helpRibbonPanel.Items.Add(this.aboutRibbonButton);
			this.helpRibbonPanel.Items.Add(this.checkForUpdatesRibbonButton);
			this.helpRibbonPanel.Name = "helpRibbonPanel";
			this.helpRibbonPanel.Text = "Help";
			// 
			// aboutRibbonButton
			// 
			this.aboutRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutRibbonButton.Image")));
			this.aboutRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("aboutRibbonButton.LargeImage")));
			this.aboutRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.aboutRibbonButton.Name = "aboutRibbonButton";
			this.aboutRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("aboutRibbonButton.SmallImage")));
			this.aboutRibbonButton.Text = "About";
			this.aboutRibbonButton.Click += new System.EventHandler(this.aboutRibbonButton_Click);
			// 
			// checkForUpdatesRibbonButton
			// 
			this.checkForUpdatesRibbonButton.FlashIntervall = 750;
			this.checkForUpdatesRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("checkForUpdatesRibbonButton.Image")));
			this.checkForUpdatesRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("checkForUpdatesRibbonButton.LargeImage")));
			this.checkForUpdatesRibbonButton.MinimumSize = new System.Drawing.Size(70, 0);
			this.checkForUpdatesRibbonButton.Name = "checkForUpdatesRibbonButton";
			this.checkForUpdatesRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("checkForUpdatesRibbonButton.SmallImage")));
			this.checkForUpdatesRibbonButton.Text = "Check For Updates";
			this.checkForUpdatesRibbonButton.Click += new System.EventHandler(this.checkForUpdatesRibbonButton_Click);
			// 
			// openCompetitionDialog
			// 
			this.openCompetitionDialog.Filter = "Competition Files|*.boris|All Files|*.*";
			this.openCompetitionDialog.Title = "Open Competition";
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.mainStatusStrip.Location = new System.Drawing.Point(0, 504);
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.Size = new System.Drawing.Size(699, 22);
			this.mainStatusStrip.TabIndex = 1;
			this.mainStatusStrip.Text = "statusStrip1";
			// 
			// pnlStartup
			// 
			this.pnlStartup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlStartup.Location = new System.Drawing.Point(0, 0);
			this.pnlStartup.Name = "pnlStartup";
			this.pnlStartup.Size = new System.Drawing.Size(699, 526);
			this.pnlStartup.TabIndex = 3;
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.BackColor = System.Drawing.SystemColors.Control;
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 122);
			this.mainSplitContainer.Name = "mainSplitContainer";
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.tasksTaskListBox);
			this.mainSplitContainer.Panel1.Resize += new System.EventHandler(this.mainSplitContainer_Panel1_Resize);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.nationResultsPdfViewer);
			this.mainSplitContainer.Panel2.Controls.Add(this.taskResultsPdfViewer);
			this.mainSplitContainer.Panel2.Controls.Add(this.aircraftClassesListBox);
			this.mainSplitContainer.Panel2.Controls.Add(this.resultsTabControl);
			this.mainSplitContainer.Panel2.Resize += new System.EventHandler(this.mainSplitContainer_Panel2_Resize);
			this.mainSplitContainer.Size = new System.Drawing.Size(699, 389);
			this.mainSplitContainer.SplitterDistance = 199;
			this.mainSplitContainer.TabIndex = 2;
			// 
			// tasksTaskListBox
			// 
			this.tasksTaskListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.tasksTaskListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tasksTaskListBox.FormattingEnabled = true;
			this.tasksTaskListBox.IntegralHeight = false;
			this.tasksTaskListBox.ItemHeight = 36;
			this.tasksTaskListBox.Location = new System.Drawing.Point(0, 0);
			this.tasksTaskListBox.Name = "tasksTaskListBox";
			this.tasksTaskListBox.Size = new System.Drawing.Size(201, 391);
			this.tasksTaskListBox.TabIndex = 0;
			this.tasksTaskListBox.SelectedIndexChanged += new System.EventHandler(this.tasksTaskListBox_SelectedIndexChanged);
			// 
			// nationResultsPdfViewer
			// 
			this.nationResultsPdfViewer.BackColor = System.Drawing.SystemColors.Window;
			this.nationResultsPdfViewer.Location = new System.Drawing.Point(224, 196);
			this.nationResultsPdfViewer.Margin = new System.Windows.Forms.Padding(1);
			this.nationResultsPdfViewer.Name = "nationResultsPdfViewer";
			this.nationResultsPdfViewer.Size = new System.Drawing.Size(140, 137);
			this.nationResultsPdfViewer.TabIndex = 3;
			// 
			// taskResultsPdfViewer
			// 
			this.taskResultsPdfViewer.BackColor = System.Drawing.SystemColors.Window;
			this.taskResultsPdfViewer.Location = new System.Drawing.Point(74, 196);
			this.taskResultsPdfViewer.Margin = new System.Windows.Forms.Padding(1);
			this.taskResultsPdfViewer.Name = "taskResultsPdfViewer";
			this.taskResultsPdfViewer.Size = new System.Drawing.Size(136, 137);
			this.taskResultsPdfViewer.TabIndex = 2;
			// 
			// aircraftClassesListBox
			// 
			this.aircraftClassesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.aircraftClassesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.aircraftClassesListBox.FormattingEnabled = true;
			this.aircraftClassesListBox.IntegralHeight = false;
			this.aircraftClassesListBox.ItemHeight = 36;
			this.aircraftClassesListBox.Location = new System.Drawing.Point(0, 0);
			this.aircraftClassesListBox.Margin = new System.Windows.Forms.Padding(2);
			this.aircraftClassesListBox.Name = "aircraftClassesListBox";
			this.aircraftClassesListBox.Size = new System.Drawing.Size(71, 391);
			this.aircraftClassesListBox.TabIndex = 1;
			this.aircraftClassesListBox.SelectedIndexChanged += new System.EventHandler(this.aircraftClassesListBox_SelectedIndexChanged);
			// 
			// resultsTabControl
			// 
			this.resultsTabControl.Controls.Add(this.competitionResultsTabPage);
			this.resultsTabControl.Controls.Add(this.teamResultsTabPage);
			this.resultsTabControl.Location = new System.Drawing.Point(74, 0);
			this.resultsTabControl.Name = "resultsTabControl";
			this.resultsTabControl.SelectedIndex = 0;
			this.resultsTabControl.Size = new System.Drawing.Size(190, 190);
			this.resultsTabControl.TabIndex = 0;
			this.resultsTabControl.SelectedIndexChanged += new System.EventHandler(this.resultsTabControl_SelectedIndexChanged);
			// 
			// competitionResultsTabPage
			// 
			this.competitionResultsTabPage.Controls.Add(this.competitionResultsPdfViewer);
			this.competitionResultsTabPage.Location = new System.Drawing.Point(4, 22);
			this.competitionResultsTabPage.Name = "competitionResultsTabPage";
			this.competitionResultsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.competitionResultsTabPage.Size = new System.Drawing.Size(182, 164);
			this.competitionResultsTabPage.TabIndex = 1;
			this.competitionResultsTabPage.Text = "Overall";
			this.competitionResultsTabPage.UseVisualStyleBackColor = true;
			// 
			// competitionResultsPdfViewer
			// 
			this.competitionResultsPdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.competitionResultsPdfViewer.Location = new System.Drawing.Point(3, 3);
			this.competitionResultsPdfViewer.Margin = new System.Windows.Forms.Padding(1);
			this.competitionResultsPdfViewer.Name = "competitionResultsPdfViewer";
			this.competitionResultsPdfViewer.Size = new System.Drawing.Size(176, 158);
			this.competitionResultsPdfViewer.TabIndex = 0;
			// 
			// teamResultsTabPage
			// 
			this.teamResultsTabPage.Controls.Add(this.teamResultsPdfViewer);
			this.teamResultsTabPage.Location = new System.Drawing.Point(4, 22);
			this.teamResultsTabPage.Name = "teamResultsTabPage";
			this.teamResultsTabPage.Size = new System.Drawing.Size(182, 164);
			this.teamResultsTabPage.TabIndex = 2;
			this.teamResultsTabPage.Text = "Team";
			this.teamResultsTabPage.UseVisualStyleBackColor = true;
			// 
			// teamResultsPdfViewer
			// 
			this.teamResultsPdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.teamResultsPdfViewer.Location = new System.Drawing.Point(0, 0);
			this.teamResultsPdfViewer.Margin = new System.Windows.Forms.Padding(1);
			this.teamResultsPdfViewer.Name = "teamResultsPdfViewer";
			this.teamResultsPdfViewer.Size = new System.Drawing.Size(182, 164);
			this.teamResultsPdfViewer.TabIndex = 0;
			// 
			// reminderNotifyIcon
			// 
			this.reminderNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("reminderNotifyIcon.Icon")));
			this.reminderNotifyIcon.Text = "Pesto";
			this.reminderNotifyIcon.BalloonTipClicked += new System.EventHandler(this.reminderNotifyIcon_BalloonTipClicked);
			this.reminderNotifyIcon.BalloonTipClosed += new System.EventHandler(this.reminderNotifyIcon_BalloonTipClosed);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(699, 526);
			this.Controls.Add(this.mainStatusStrip);
			this.Controls.Add(this.mainRibbon);
			this.Controls.Add(this.pnlStartup);
			this.Controls.Add(this.mainSplitContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			this.resultsTabControl.ResumeLayout(false);
			this.competitionResultsTabPage.ResumeLayout(false);
			this.teamResultsTabPage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Ribbon mainRibbon;
		private System.Windows.Forms.RibbonTab homeRibbonTab;
		private System.Windows.Forms.RibbonPanel competitionRibbonPanel;
		private System.Windows.Forms.RibbonButton newCompetitionRibbonButton;
		private System.Windows.Forms.RibbonButton openCompetitionRibbonButton;
		private System.Windows.Forms.RibbonButton competitionPropertiesRibbonButton;
		private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
		private System.Windows.Forms.RibbonButton defineFeaturesRibbonButton;
		private System.Windows.Forms.RibbonPanel taskRibbonPanel;
		private System.Windows.Forms.RibbonButton addTaskRibbonButton;
		private System.Windows.Forms.RibbonButton editTaskRibbonButton;
		private System.Windows.Forms.RibbonButton trackAnalysisRibbonButton;
		private System.Windows.Forms.RibbonTab resultsRibbonTab;
		private System.Windows.Forms.RibbonTab miscellaneousRibbonTab;
		private System.Windows.Forms.RibbonPanel generateRibbonPanel;
		private System.Windows.Forms.RibbonPanel publishRibbonPanel;
		private System.Windows.Forms.RibbonButton generateTaskRibbonButton;
		private System.Windows.Forms.RibbonButton generateOverallRibbonButton;
		private System.Windows.Forms.RibbonButton generateTeamRibbonButton;
		private System.Windows.Forms.RibbonButton printRibbonButton;
		private System.Windows.Forms.RibbonButton uploadRibbonButton;
		private System.Windows.Forms.RibbonPanel toolsRibbonPanel;
		private System.Windows.Forms.RibbonPanel helpRibbonPanel;
		private System.Windows.Forms.RibbonButton optionsRibbonButton;
		private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
		private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
		private System.Windows.Forms.RibbonSeparator ribbonSeparator4;
		private System.Windows.Forms.RibbonButton convertTracksRibbonButton;
		private System.Windows.Forms.RibbonButton createPdfRibbonButton;
		private System.Windows.Forms.RibbonButton aboutRibbonButton;
		private System.Windows.Forms.OpenFileDialog openCompetitionDialog;
		private System.Windows.Forms.StatusStrip mainStatusStrip;
		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private TaskListBox tasksTaskListBox;
		private System.Windows.Forms.TabControl resultsTabControl;
		private System.Windows.Forms.TabPage competitionResultsTabPage;
		private System.Windows.Forms.TabPage teamResultsTabPage;
		private System.Windows.Forms.RibbonButton pilotsRibbonButton;
		private System.Windows.Forms.RibbonButton pilotsSpreadsheetRibbonButton;
		private System.Windows.Forms.RibbonButton pilotMappingsRibbonButton;
		private System.Windows.Forms.RibbonSeparator ribbonSeparator5;
		private System.Windows.Forms.RibbonSeparator ribbonSeparator6;
		private System.Windows.Forms.RibbonButton scoresRibbonButton;
		private System.Windows.Forms.RibbonButton taskSpreadsheetRibbonButton;
		private System.Windows.Forms.RibbonButton taskMappingsRibbonButton;
		private System.Windows.Forms.RibbonSeparator ribbonSeparator7;
		private System.Windows.Forms.RibbonButton ribbonButton1;
		private System.Windows.Forms.RibbonButton backupRibbonButton;
        private System.Windows.Forms.RibbonButton selectTaskFeaturesRibbonButton;
		private System.Windows.Forms.Panel pnlStartup;
		private System.Windows.Forms.RibbonButton reloadRibbonButton;
        private System.Windows.Forms.RibbonButton checkForUpdatesRibbonButton;
        private PdfViewer competitionResultsPdfViewer;
        private PdfViewer teamResultsPdfViewer;
        private System.Windows.Forms.RibbonButton calculateDistanceRibbonButton;
        private System.Windows.Forms.RibbonButton generateNationRibbonButton;
        private AircraftClassListBox aircraftClassesListBox;
        private PdfViewer nationResultsPdfViewer;
        private PdfViewer taskResultsPdfViewer;
        private System.Windows.Forms.NotifyIcon reminderNotifyIcon;
        private System.Windows.Forms.RibbonButton remindersRibbonButton;
    }
}