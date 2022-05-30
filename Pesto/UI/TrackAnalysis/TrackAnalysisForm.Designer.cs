namespace ColinBaker.Pesto.UI.TrackAnalysis
{
	partial class TrackAnalysisForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackAnalysisForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mainRibbon = new System.Windows.Forms.Ribbon();
			this.analysisRibbonTab = new System.Windows.Forms.RibbonTab();
			this.taskRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.selectFeaturesRibbonButton = new System.Windows.Forms.RibbonButton();
			this.selectTrackRibbonButton = new System.Windows.Forms.RibbonButton();
			this.runAnalysisRibbonButton = new System.Windows.Forms.RibbonButton();
			this.eventsRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.removeEventRibbonButton = new System.Windows.Forms.RibbonButton();
			this.filterEventsRibbonButton = new System.Windows.Forms.RibbonButton();
			this.calculateRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.calculateDistanceRibbonButton = new System.Windows.Forms.RibbonButton();
			this.calculateAreaRibbonButton = new System.Windows.Forms.RibbonButton();
			this.calculateTimeRibbonButton = new System.Windows.Forms.RibbonButton();
			this.calculateSpeedRibbonButton = new System.Windows.Forms.RibbonButton();
			this.minAltitudeRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.minAltitudeRibbonCheckBox = new System.Windows.Forms.RibbonCheckBox();
			this.minAltitudeRibbonTextBox = new System.Windows.Forms.RibbonTextBox();
			this.minAltitudeRibbonComboBox = new System.Windows.Forms.RibbonComboBox();
			this.minAltitudeUnitFeetRibbonLabel = new System.Windows.Forms.RibbonLabel();
			this.minAltitudeUnitMetresRibbonLabel = new System.Windows.Forms.RibbonLabel();
			this.outputRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.openKmlRibbonButton = new System.Windows.Forms.RibbonButton();
			this.exportAnalysisRibbonButton = new System.Windows.Forms.RibbonButton();
			this.viewRibbonTab = new System.Windows.Forms.RibbonTab();
			this.mapRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.zoomInRibbonButton = new System.Windows.Forms.RibbonButton();
			this.zoomOutRibbonButton = new System.Windows.Forms.RibbonButton();
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.pilotsDataGridView = new System.Windows.Forms.DataGridView();
			this.PilotNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PilotNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AircraftClassColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.eventsSplitContainer = new System.Windows.Forms.SplitContainer();
			this.eventsDataGridView = new System.Windows.Forms.DataGridView();
			this.BlahColumn = new System.Windows.Forms.DataGridViewImageColumn();
			this.NoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LocalTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TimeElapsedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CategoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LatitudeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LongitudeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AltitudeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.analysisMap = new ColinBaker.Pesto.UI.Map();
			this.eventClassificationImageList = new System.Windows.Forms.ImageList(this.components);
			this.exportKmlFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.exportKmlFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.eventsHeaderContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyColumnDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyVerticallyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyHorizontallyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eventsCellContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyCellValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pilotsDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.eventsSplitContainer)).BeginInit();
			this.eventsSplitContainer.Panel1.SuspendLayout();
			this.eventsSplitContainer.Panel2.SuspendLayout();
			this.eventsSplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
			this.eventsHeaderContextMenuStrip.SuspendLayout();
			this.eventsCellContextMenuStrip.SuspendLayout();
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
			this.mainRibbon.Size = new System.Drawing.Size(901, 121);
			this.mainRibbon.TabIndex = 0;
			this.mainRibbon.Tabs.Add(this.analysisRibbonTab);
			this.mainRibbon.Tabs.Add(this.viewRibbonTab);
			this.mainRibbon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
			this.mainRibbon.TabSpacing = 4;
			this.mainRibbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
			// 
			// analysisRibbonTab
			// 
			this.analysisRibbonTab.Name = "analysisRibbonTab";
			this.analysisRibbonTab.Panels.Add(this.taskRibbonPanel);
			this.analysisRibbonTab.Panels.Add(this.eventsRibbonPanel);
			this.analysisRibbonTab.Panels.Add(this.calculateRibbonPanel);
			this.analysisRibbonTab.Panels.Add(this.minAltitudeRibbonPanel);
			this.analysisRibbonTab.Panels.Add(this.outputRibbonPanel);
			this.analysisRibbonTab.Text = "Analysis";
			// 
			// taskRibbonPanel
			// 
			this.taskRibbonPanel.ButtonMoreVisible = false;
			this.taskRibbonPanel.Items.Add(this.selectFeaturesRibbonButton);
			this.taskRibbonPanel.Items.Add(this.selectTrackRibbonButton);
			this.taskRibbonPanel.Items.Add(this.runAnalysisRibbonButton);
			this.taskRibbonPanel.Name = "taskRibbonPanel";
			this.taskRibbonPanel.Text = "Task";
			// 
			// selectFeaturesRibbonButton
			// 
			this.selectFeaturesRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("selectFeaturesRibbonButton.Image")));
			this.selectFeaturesRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("selectFeaturesRibbonButton.LargeImage")));
			this.selectFeaturesRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.selectFeaturesRibbonButton.Name = "selectFeaturesRibbonButton";
			this.selectFeaturesRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("selectFeaturesRibbonButton.SmallImage")));
			this.selectFeaturesRibbonButton.Text = "Select Features";
			this.selectFeaturesRibbonButton.Click += new System.EventHandler(this.selectFeaturesRibbonButton_Click);
			// 
			// selectTrackRibbonButton
			// 
			this.selectTrackRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("selectTrackRibbonButton.Image")));
			this.selectTrackRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("selectTrackRibbonButton.LargeImage")));
			this.selectTrackRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.selectTrackRibbonButton.Name = "selectTrackRibbonButton";
			this.selectTrackRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("selectTrackRibbonButton.SmallImage")));
			this.selectTrackRibbonButton.Text = "Manual Tracks";
			this.selectTrackRibbonButton.Click += new System.EventHandler(this.selectTrackRibbonButton_Click);
			// 
			// runAnalysisRibbonButton
			// 
			this.runAnalysisRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("runAnalysisRibbonButton.Image")));
			this.runAnalysisRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("runAnalysisRibbonButton.LargeImage")));
			this.runAnalysisRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.runAnalysisRibbonButton.Name = "runAnalysisRibbonButton";
			this.runAnalysisRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("runAnalysisRibbonButton.SmallImage")));
			this.runAnalysisRibbonButton.Text = "Run Analysis";
			this.runAnalysisRibbonButton.Click += new System.EventHandler(this.runAnalysisRibbonButton_Click);
			// 
			// eventsRibbonPanel
			// 
			this.eventsRibbonPanel.ButtonMoreVisible = false;
			this.eventsRibbonPanel.Items.Add(this.removeEventRibbonButton);
			this.eventsRibbonPanel.Items.Add(this.filterEventsRibbonButton);
			this.eventsRibbonPanel.Name = "eventsRibbonPanel";
			this.eventsRibbonPanel.Text = "Events";
			// 
			// removeEventRibbonButton
			// 
			this.removeEventRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("removeEventRibbonButton.Image")));
			this.removeEventRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("removeEventRibbonButton.LargeImage")));
			this.removeEventRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.removeEventRibbonButton.Name = "removeEventRibbonButton";
			this.removeEventRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("removeEventRibbonButton.SmallImage")));
			this.removeEventRibbonButton.Text = "Remove";
			this.removeEventRibbonButton.Click += new System.EventHandler(this.removeEventRibbonButton_Click);
			// 
			// filterEventsRibbonButton
			// 
			this.filterEventsRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("filterEventsRibbonButton.Image")));
			this.filterEventsRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("filterEventsRibbonButton.LargeImage")));
			this.filterEventsRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.filterEventsRibbonButton.Name = "filterEventsRibbonButton";
			this.filterEventsRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("filterEventsRibbonButton.SmallImage")));
			this.filterEventsRibbonButton.Text = "Filter";
			this.filterEventsRibbonButton.Click += new System.EventHandler(this.filterEventsRibbonButton_Click);
			// 
			// calculateRibbonPanel
			// 
			this.calculateRibbonPanel.ButtonMoreVisible = false;
			this.calculateRibbonPanel.Items.Add(this.calculateDistanceRibbonButton);
			this.calculateRibbonPanel.Items.Add(this.calculateAreaRibbonButton);
			this.calculateRibbonPanel.Items.Add(this.calculateTimeRibbonButton);
			this.calculateRibbonPanel.Items.Add(this.calculateSpeedRibbonButton);
			this.calculateRibbonPanel.Name = "calculateRibbonPanel";
			this.calculateRibbonPanel.Text = "Calculate";
			// 
			// calculateDistanceRibbonButton
			// 
			this.calculateDistanceRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("calculateDistanceRibbonButton.Image")));
			this.calculateDistanceRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("calculateDistanceRibbonButton.LargeImage")));
			this.calculateDistanceRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.calculateDistanceRibbonButton.Name = "calculateDistanceRibbonButton";
			this.calculateDistanceRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("calculateDistanceRibbonButton.SmallImage")));
			this.calculateDistanceRibbonButton.Text = "Distance";
			this.calculateDistanceRibbonButton.Click += new System.EventHandler(this.calculateDistanceRibbonButton_Click);
			// 
			// calculateAreaRibbonButton
			// 
			this.calculateAreaRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("calculateAreaRibbonButton.Image")));
			this.calculateAreaRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("calculateAreaRibbonButton.LargeImage")));
			this.calculateAreaRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.calculateAreaRibbonButton.Name = "calculateAreaRibbonButton";
			this.calculateAreaRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("calculateAreaRibbonButton.SmallImage")));
			this.calculateAreaRibbonButton.Text = "Area";
			this.calculateAreaRibbonButton.Click += new System.EventHandler(this.calculateAreaRibbonButton_Click);
			// 
			// calculateTimeRibbonButton
			// 
			this.calculateTimeRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("calculateTimeRibbonButton.Image")));
			this.calculateTimeRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("calculateTimeRibbonButton.LargeImage")));
			this.calculateTimeRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.calculateTimeRibbonButton.Name = "calculateTimeRibbonButton";
			this.calculateTimeRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("calculateTimeRibbonButton.SmallImage")));
			this.calculateTimeRibbonButton.Text = "Time";
			this.calculateTimeRibbonButton.Click += new System.EventHandler(this.calculateTimeRibbonButton_Click);
			// 
			// calculateSpeedRibbonButton
			// 
			this.calculateSpeedRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("calculateSpeedRibbonButton.Image")));
			this.calculateSpeedRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("calculateSpeedRibbonButton.LargeImage")));
			this.calculateSpeedRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.calculateSpeedRibbonButton.Name = "calculateSpeedRibbonButton";
			this.calculateSpeedRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("calculateSpeedRibbonButton.SmallImage")));
			this.calculateSpeedRibbonButton.Text = "Speed";
			this.calculateSpeedRibbonButton.Click += new System.EventHandler(this.calculateSpeedRibbonButton_Click);
			// 
			// minAltitudeRibbonPanel
			// 
			this.minAltitudeRibbonPanel.ButtonMoreVisible = false;
			this.minAltitudeRibbonPanel.Items.Add(this.minAltitudeRibbonCheckBox);
			this.minAltitudeRibbonPanel.Items.Add(this.minAltitudeRibbonTextBox);
			this.minAltitudeRibbonPanel.Items.Add(this.minAltitudeRibbonComboBox);
			this.minAltitudeRibbonPanel.Name = "minAltitudeRibbonPanel";
			this.minAltitudeRibbonPanel.Text = "Minimum Altitude";
			// 
			// minAltitudeRibbonCheckBox
			// 
			this.minAltitudeRibbonCheckBox.Checked = true;
			this.minAltitudeRibbonCheckBox.Name = "minAltitudeRibbonCheckBox";
			this.minAltitudeRibbonCheckBox.Text = "Check Minimum Altitude";
			this.minAltitudeRibbonCheckBox.CheckBoxCheckChanged += new System.EventHandler(this.minAltitudeRibbonCheckBox_CheckBoxCheckChanged);
			// 
			// minAltitudeRibbonTextBox
			// 
			this.minAltitudeRibbonTextBox.Name = "minAltitudeRibbonTextBox";
			this.minAltitudeRibbonTextBox.Text = "";
			this.minAltitudeRibbonTextBox.TextBoxText = "500";
			this.minAltitudeRibbonTextBox.TextBoxWidth = 90;
			this.minAltitudeRibbonTextBox.Value = "";
			// 
			// minAltitudeRibbonComboBox
			// 
			this.minAltitudeRibbonComboBox.AllowTextEdit = false;
			this.minAltitudeRibbonComboBox.DrawIconsBar = false;
			this.minAltitudeRibbonComboBox.DropDownItems.Add(this.minAltitudeUnitFeetRibbonLabel);
			this.minAltitudeRibbonComboBox.DropDownItems.Add(this.minAltitudeUnitMetresRibbonLabel);
			this.minAltitudeRibbonComboBox.Name = "minAltitudeRibbonComboBox";
			this.minAltitudeRibbonComboBox.Text = "";
			this.minAltitudeRibbonComboBox.TextBoxText = "Feet";
			this.minAltitudeRibbonComboBox.TextBoxWidth = 90;
			// 
			// minAltitudeUnitFeetRibbonLabel
			// 
			this.minAltitudeUnitFeetRibbonLabel.Name = "minAltitudeUnitFeetRibbonLabel";
			this.minAltitudeUnitFeetRibbonLabel.Text = "Feet";
			this.minAltitudeUnitFeetRibbonLabel.Value = "ft";
			// 
			// minAltitudeUnitMetresRibbonLabel
			// 
			this.minAltitudeUnitMetresRibbonLabel.Name = "minAltitudeUnitMetresRibbonLabel";
			this.minAltitudeUnitMetresRibbonLabel.Text = "Metres";
			this.minAltitudeUnitMetresRibbonLabel.Value = "m";
			// 
			// outputRibbonPanel
			// 
			this.outputRibbonPanel.ButtonMoreVisible = false;
			this.outputRibbonPanel.Items.Add(this.openKmlRibbonButton);
			this.outputRibbonPanel.Items.Add(this.exportAnalysisRibbonButton);
			this.outputRibbonPanel.Name = "outputRibbonPanel";
			this.outputRibbonPanel.Text = "Output";
			// 
			// openKmlRibbonButton
			// 
			this.openKmlRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("openKmlRibbonButton.Image")));
			this.openKmlRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("openKmlRibbonButton.LargeImage")));
			this.openKmlRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.openKmlRibbonButton.Name = "openKmlRibbonButton";
			this.openKmlRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("openKmlRibbonButton.SmallImage")));
			this.openKmlRibbonButton.Text = "Export KML";
			this.openKmlRibbonButton.Click += new System.EventHandler(this.openKmlRibbonButton_Click);
			// 
			// exportAnalysisRibbonButton
			// 
			this.exportAnalysisRibbonButton.Enabled = false;
			this.exportAnalysisRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("exportAnalysisRibbonButton.Image")));
			this.exportAnalysisRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("exportAnalysisRibbonButton.LargeImage")));
			this.exportAnalysisRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.exportAnalysisRibbonButton.Name = "exportAnalysisRibbonButton";
			this.exportAnalysisRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("exportAnalysisRibbonButton.SmallImage")));
			this.exportAnalysisRibbonButton.Text = "Upload via FTP";
			// 
			// viewRibbonTab
			// 
			this.viewRibbonTab.Name = "viewRibbonTab";
			this.viewRibbonTab.Panels.Add(this.mapRibbonPanel);
			this.viewRibbonTab.Text = "View";
			// 
			// mapRibbonPanel
			// 
			this.mapRibbonPanel.ButtonMoreVisible = false;
			this.mapRibbonPanel.Items.Add(this.zoomInRibbonButton);
			this.mapRibbonPanel.Items.Add(this.zoomOutRibbonButton);
			this.mapRibbonPanel.Name = "mapRibbonPanel";
			this.mapRibbonPanel.Text = "Map";
			// 
			// zoomInRibbonButton
			// 
			this.zoomInRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInRibbonButton.Image")));
			this.zoomInRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("zoomInRibbonButton.LargeImage")));
			this.zoomInRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.zoomInRibbonButton.Name = "zoomInRibbonButton";
			this.zoomInRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomInRibbonButton.SmallImage")));
			this.zoomInRibbonButton.Text = "Zoom In";
			this.zoomInRibbonButton.Click += new System.EventHandler(this.zoomInRibbonButton_Click);
			// 
			// zoomOutRibbonButton
			// 
			this.zoomOutRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutRibbonButton.Image")));
			this.zoomOutRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("zoomOutRibbonButton.LargeImage")));
			this.zoomOutRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.zoomOutRibbonButton.Name = "zoomOutRibbonButton";
			this.zoomOutRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomOutRibbonButton.SmallImage")));
			this.zoomOutRibbonButton.Text = "Zoom Out";
			this.zoomOutRibbonButton.Click += new System.EventHandler(this.zoomOutRibbonButton_Click);
			// 
			// mainSplitContainer
			// 
			this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 121);
			this.mainSplitContainer.Name = "mainSplitContainer";
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.pilotsDataGridView);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.eventsSplitContainer);
			this.mainSplitContainer.Size = new System.Drawing.Size(901, 547);
			this.mainSplitContainer.SplitterDistance = 215;
			this.mainSplitContainer.TabIndex = 1;
			// 
			// pilotsDataGridView
			// 
			this.pilotsDataGridView.AllowUserToAddRows = false;
			this.pilotsDataGridView.AllowUserToDeleteRows = false;
			this.pilotsDataGridView.AllowUserToResizeRows = false;
			this.pilotsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.pilotsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.pilotsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pilotsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.pilotsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.pilotsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.pilotsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.pilotsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PilotNumberColumn,
            this.PilotNameColumn,
            this.AircraftClassColumn});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.pilotsDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
			this.pilotsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pilotsDataGridView.Location = new System.Drawing.Point(0, 0);
			this.pilotsDataGridView.Name = "pilotsDataGridView";
			this.pilotsDataGridView.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.pilotsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.pilotsDataGridView.RowHeadersVisible = false;
			this.pilotsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.pilotsDataGridView.Size = new System.Drawing.Size(215, 547);
			this.pilotsDataGridView.TabIndex = 0;
			this.pilotsDataGridView.SelectionChanged += new System.EventHandler(this.pilotsDataGridView_SelectionChanged);
			// 
			// PilotNumberColumn
			// 
			this.PilotNumberColumn.FillWeight = 35.53299F;
			this.PilotNumberColumn.HeaderText = "No";
			this.PilotNumberColumn.Name = "PilotNumberColumn";
			this.PilotNumberColumn.ReadOnly = true;
			// 
			// PilotNameColumn
			// 
			this.PilotNameColumn.FillWeight = 164.467F;
			this.PilotNameColumn.HeaderText = "Pilot Name";
			this.PilotNameColumn.Name = "PilotNameColumn";
			this.PilotNameColumn.ReadOnly = true;
			// 
			// AircraftClassColumn
			// 
			this.AircraftClassColumn.FillWeight = 45F;
			this.AircraftClassColumn.HeaderText = "Class";
			this.AircraftClassColumn.Name = "AircraftClassColumn";
			this.AircraftClassColumn.ReadOnly = true;
			// 
			// eventsSplitContainer
			// 
			this.eventsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.eventsSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.eventsSplitContainer.Name = "eventsSplitContainer";
			this.eventsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// eventsSplitContainer.Panel1
			// 
			this.eventsSplitContainer.Panel1.Controls.Add(this.eventsDataGridView);
			this.eventsSplitContainer.Panel1Collapsed = true;
			// 
			// eventsSplitContainer.Panel2
			// 
			this.eventsSplitContainer.Panel2.Controls.Add(this.analysisMap);
			this.eventsSplitContainer.Size = new System.Drawing.Size(682, 547);
			this.eventsSplitContainer.SplitterDistance = 316;
			this.eventsSplitContainer.TabIndex = 0;
			// 
			// eventsDataGridView
			// 
			this.eventsDataGridView.AllowUserToAddRows = false;
			this.eventsDataGridView.AllowUserToDeleteRows = false;
			this.eventsDataGridView.AllowUserToResizeRows = false;
			this.eventsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.eventsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.eventsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.eventsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.eventsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.eventsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.eventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.eventsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BlahColumn,
            this.NoColumn,
            this.LocalTimeColumn,
            this.TimeElapsedColumn,
            this.DescriptionColumn,
            this.CategoryColumn,
            this.LatitudeColumn,
            this.LongitudeColumn,
            this.AltitudeColumn});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.eventsDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
			this.eventsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.eventsDataGridView.Location = new System.Drawing.Point(0, 0);
			this.eventsDataGridView.Name = "eventsDataGridView";
			this.eventsDataGridView.ReadOnly = true;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.eventsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.eventsDataGridView.RowHeadersVisible = false;
			this.eventsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.eventsDataGridView.Size = new System.Drawing.Size(150, 316);
			this.eventsDataGridView.TabIndex = 1;
			this.eventsDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.eventsDataGridView_CellMouseClick);
			this.eventsDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.eventsDataGridView_ColumnHeaderMouseClick);
			this.eventsDataGridView.SelectionChanged += new System.EventHandler(this.eventsDataGridView_SelectionChanged);
			// 
			// BlahColumn
			// 
			this.BlahColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.BlahColumn.FillWeight = 51.61689F;
			this.BlahColumn.HeaderText = "";
			this.BlahColumn.Name = "BlahColumn";
			this.BlahColumn.ReadOnly = true;
			this.BlahColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.BlahColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.BlahColumn.Width = 24;
			// 
			// NoColumn
			// 
			this.NoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.NoColumn.FillWeight = 90F;
			this.NoColumn.HeaderText = "No";
			this.NoColumn.Name = "NoColumn";
			this.NoColumn.ReadOnly = true;
			// 
			// LocalTimeColumn
			// 
			this.LocalTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.LocalTimeColumn.FillWeight = 190F;
			this.LocalTimeColumn.HeaderText = "Time (Local)";
			this.LocalTimeColumn.Name = "LocalTimeColumn";
			this.LocalTimeColumn.ReadOnly = true;
			// 
			// TimeElapsedColumn
			// 
			this.TimeElapsedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.TimeElapsedColumn.FillWeight = 225F;
			this.TimeElapsedColumn.HeaderText = "Time (Elapsed)";
			this.TimeElapsedColumn.Name = "TimeElapsedColumn";
			this.TimeElapsedColumn.ReadOnly = true;
			// 
			// DescriptionColumn
			// 
			this.DescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.DescriptionColumn.FillWeight = 480F;
			this.DescriptionColumn.HeaderText = "Description";
			this.DescriptionColumn.Name = "DescriptionColumn";
			this.DescriptionColumn.ReadOnly = true;
			// 
			// CategoryColumn
			// 
			this.CategoryColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.CategoryColumn.FillWeight = 250F;
			this.CategoryColumn.HeaderText = "Category";
			this.CategoryColumn.Name = "CategoryColumn";
			this.CategoryColumn.ReadOnly = true;
			// 
			// LatitudeColumn
			// 
			this.LatitudeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.LatitudeColumn.DefaultCellStyle = dataGridViewCellStyle5;
			this.LatitudeColumn.FillWeight = 150F;
			this.LatitudeColumn.HeaderText = "Latitude";
			this.LatitudeColumn.Name = "LatitudeColumn";
			this.LatitudeColumn.ReadOnly = true;
			// 
			// LongitudeColumn
			// 
			this.LongitudeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.LongitudeColumn.DefaultCellStyle = dataGridViewCellStyle6;
			this.LongitudeColumn.FillWeight = 175F;
			this.LongitudeColumn.HeaderText = "Longitude";
			this.LongitudeColumn.Name = "LongitudeColumn";
			this.LongitudeColumn.ReadOnly = true;
			// 
			// AltitudeColumn
			// 
			this.AltitudeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.AltitudeColumn.DefaultCellStyle = dataGridViewCellStyle7;
			this.AltitudeColumn.FillWeight = 140F;
			this.AltitudeColumn.HeaderText = "Altitude";
			this.AltitudeColumn.Name = "AltitudeColumn";
			this.AltitudeColumn.ReadOnly = true;
			// 
			// analysisMap
			// 
			this.analysisMap.CenterLocation = null;
			this.analysisMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.analysisMap.Location = new System.Drawing.Point(0, 0);
			this.analysisMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.analysisMap.Name = "analysisMap";
			this.analysisMap.Size = new System.Drawing.Size(682, 547);
			this.analysisMap.TabIndex = 0;
			this.analysisMap.Zoom = -1;
			this.analysisMap.Resize += new System.EventHandler(this.analysisMap_Resize);
			// 
			// eventClassificationImageList
			// 
			this.eventClassificationImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("eventClassificationImageList.ImageStream")));
			this.eventClassificationImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.eventClassificationImageList.Images.SetKeyName(0, "Information");
			this.eventClassificationImageList.Images.SetKeyName(1, "Achievement");
			this.eventClassificationImageList.Images.SetKeyName(2, "Warning");
			this.eventClassificationImageList.Images.SetKeyName(3, "Failure");
			// 
			// exportKmlFileDialog
			// 
			this.exportKmlFileDialog.DefaultExt = "kml";
			this.exportKmlFileDialog.Filter = "Google Earth files|*.kml|All files|*.*";
			this.exportKmlFileDialog.Title = "Export KML";
			// 
			// exportKmlFolderBrowserDialog
			// 
			this.exportKmlFolderBrowserDialog.Description = "Select export folder";
			// 
			// eventsHeaderContextMenuStrip
			// 
			this.eventsHeaderContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.eventsHeaderContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyColumnDataMenuItem});
			this.eventsHeaderContextMenuStrip.Name = "eventsHeaderContextMenuStrip";
			this.eventsHeaderContextMenuStrip.Size = new System.Drawing.Size(176, 26);
			// 
			// copyColumnDataMenuItem
			// 
			this.copyColumnDataMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyVerticallyMenuItem,
            this.copyHorizontallyMenuItem});
			this.copyColumnDataMenuItem.Name = "copyColumnDataMenuItem";
			this.copyColumnDataMenuItem.Size = new System.Drawing.Size(175, 22);
			this.copyColumnDataMenuItem.Text = "Copy Column Data";
			// 
			// copyVerticallyMenuItem
			// 
			this.copyVerticallyMenuItem.Name = "copyVerticallyMenuItem";
			this.copyVerticallyMenuItem.Size = new System.Drawing.Size(201, 22);
			this.copyVerticallyMenuItem.Text = "Vertically";
			this.copyVerticallyMenuItem.Click += new System.EventHandler(this.copyVerticallyMenuItem_Click);
			// 
			// copyHorizontallyMenuItem
			// 
			this.copyHorizontallyMenuItem.Name = "copyHorizontallyMenuItem";
			this.copyHorizontallyMenuItem.Size = new System.Drawing.Size(201, 22);
			this.copyHorizontallyMenuItem.Text = "Horizontally (Transpose)";
			this.copyHorizontallyMenuItem.Click += new System.EventHandler(this.copyHorizontallyMenuItem_Click);
			// 
			// eventsCellContextMenuStrip
			// 
			this.eventsCellContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.eventsCellContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCellValueToolStripMenuItem});
			this.eventsCellContextMenuStrip.Name = "eventsCellContextMenuStrip";
			this.eventsCellContextMenuStrip.Size = new System.Drawing.Size(103, 26);
			// 
			// copyCellValueToolStripMenuItem
			// 
			this.copyCellValueToolStripMenuItem.Name = "copyCellValueToolStripMenuItem";
			this.copyCellValueToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.copyCellValueToolStripMenuItem.Text = "Copy";
			this.copyCellValueToolStripMenuItem.Click += new System.EventHandler(this.copyCellValueToolStripMenuItem_Click);
			// 
			// TrackAnalysisForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(901, 668);
			this.Controls.Add(this.mainSplitContainer);
			this.Controls.Add(this.mainRibbon);
			this.KeyPreview = true;
			this.MinimizeBox = false;
			this.Name = "TrackAnalysisForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Track Analysis";
			this.Load += new System.EventHandler(this.TrackAnalysisForm_Load);
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pilotsDataGridView)).EndInit();
			this.eventsSplitContainer.Panel1.ResumeLayout(false);
			this.eventsSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.eventsSplitContainer)).EndInit();
			this.eventsSplitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).EndInit();
			this.eventsHeaderContextMenuStrip.ResumeLayout(false);
			this.eventsCellContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Ribbon mainRibbon;
		private System.Windows.Forms.RibbonTab analysisRibbonTab;
		private System.Windows.Forms.RibbonPanel taskRibbonPanel;
		private System.Windows.Forms.RibbonButton selectFeaturesRibbonButton;
		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private System.Windows.Forms.DataGridView pilotsDataGridView;
		private System.Windows.Forms.RibbonButton runAnalysisRibbonButton;
		private System.Windows.Forms.SplitContainer eventsSplitContainer;
		private System.Windows.Forms.DataGridView eventsDataGridView;
		private System.Windows.Forms.ImageList eventClassificationImageList;
		private System.Windows.Forms.RibbonPanel calculateRibbonPanel;
		private System.Windows.Forms.RibbonButton calculateDistanceRibbonButton;
		private System.Windows.Forms.RibbonButton calculateAreaRibbonButton;
		private Map analysisMap;
		private System.Windows.Forms.RibbonTab viewRibbonTab;
		private System.Windows.Forms.RibbonPanel mapRibbonPanel;
		private System.Windows.Forms.RibbonButton zoomInRibbonButton;
		private System.Windows.Forms.RibbonButton zoomOutRibbonButton;
		private System.Windows.Forms.RibbonPanel minAltitudeRibbonPanel;
		private System.Windows.Forms.RibbonCheckBox minAltitudeRibbonCheckBox;
		private System.Windows.Forms.RibbonTextBox minAltitudeRibbonTextBox;
		private System.Windows.Forms.RibbonComboBox minAltitudeRibbonComboBox;
		private System.Windows.Forms.RibbonLabel minAltitudeUnitFeetRibbonLabel;
		private System.Windows.Forms.RibbonLabel minAltitudeUnitMetresRibbonLabel;
		private System.Windows.Forms.RibbonButton calculateTimeRibbonButton;
		private System.Windows.Forms.RibbonButton calculateSpeedRibbonButton;
		private System.Windows.Forms.RibbonPanel outputRibbonPanel;
		private System.Windows.Forms.RibbonButton openKmlRibbonButton;
		private System.Windows.Forms.RibbonButton exportAnalysisRibbonButton;
		private System.Windows.Forms.SaveFileDialog exportKmlFileDialog;
		private System.Windows.Forms.FolderBrowserDialog exportKmlFolderBrowserDialog;
        private System.Windows.Forms.RibbonPanel eventsRibbonPanel;
        private System.Windows.Forms.RibbonButton removeEventRibbonButton;
        private System.Windows.Forms.ContextMenuStrip eventsHeaderContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyColumnDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyVerticallyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyHorizontallyMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn BlahColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeElapsedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LatitudeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LongitudeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AltitudeColumn;
        private System.Windows.Forms.ContextMenuStrip eventsCellContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyCellValueToolStripMenuItem;
        private System.Windows.Forms.RibbonButton filterEventsRibbonButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn PilotNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PilotNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AircraftClassColumn;
		private System.Windows.Forms.RibbonButton selectTrackRibbonButton;
	}
}