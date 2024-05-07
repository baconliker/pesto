namespace ColinBaker.Pesto.UI.Features
{
	partial class TaskFeaturesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskFeaturesForm));
			this.mainRibbon = new System.Windows.Forms.Ribbon();
			this.featuresRibbonTab = new System.Windows.Forms.RibbonTab();
			this.competitionRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.defineRibbonButton = new System.Windows.Forms.RibbonButton();
			this.selectRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.selectAllRibbonButton = new System.Windows.Forms.RibbonButton();
			this.selectNoneRibbonButton = new System.Windows.Forms.RibbonButton();
			this.viewRibbonTab = new System.Windows.Forms.RibbonTab();
			this.mapRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.showMapRibbonButton = new System.Windows.Forms.RibbonButton();
			this.zoomInRibbonButton = new System.Windows.Forms.RibbonButton();
			this.zoomOutRibbonButton = new System.Windows.Forms.RibbonButton();
			this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.pointsOfInterestCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.pointsOfInterestLabel = new System.Windows.Forms.Label();
			this.elapsedTimePointGateComboBox = new System.Windows.Forms.ComboBox();
			this.elapsedTimePointGateLabel = new System.Windows.Forms.Label();
			this.landingDeckComboBox = new System.Windows.Forms.ComboBox();
			this.landingDeckLabel = new System.Windows.Forms.Label();
			this.takeOffDeckComboBox = new System.Windows.Forms.ComboBox();
			this.takeOffDeckLabel = new System.Windows.Forms.Label();
			this.hiddenGatesCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.hiddenGatesLabel = new System.Windows.Forms.Label();
			this.turnpointsCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.turnpointsLabel = new System.Windows.Forms.Label();
			this.finishPointGateComboBox = new System.Windows.Forms.ComboBox();
			this.finishPointGateLabel = new System.Windows.Forms.Label();
			this.startPointGateComboBox = new System.Windows.Forms.ComboBox();
			this.startPointGateLabel = new System.Windows.Forms.Label();
			this.featuresMap = new ColinBaker.Pesto.UI.Map();
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
			this.mainSplitContainer.Panel1.SuspendLayout();
			this.mainSplitContainer.Panel2.SuspendLayout();
			this.mainSplitContainer.SuspendLayout();
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
			this.mainRibbon.Size = new System.Drawing.Size(873, 126);
			this.mainRibbon.TabIndex = 0;
			this.mainRibbon.Tabs.Add(this.featuresRibbonTab);
			this.mainRibbon.Tabs.Add(this.viewRibbonTab);
			this.mainRibbon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
			this.mainRibbon.TabSpacing = 4;
			this.mainRibbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
			// 
			// featuresRibbonTab
			// 
			this.featuresRibbonTab.Name = "featuresRibbonTab";
			this.featuresRibbonTab.Panels.Add(this.competitionRibbonPanel);
			this.featuresRibbonTab.Panels.Add(this.selectRibbonPanel);
			this.featuresRibbonTab.Text = "Features";
			// 
			// competitionRibbonPanel
			// 
			this.competitionRibbonPanel.ButtonMoreVisible = false;
			this.competitionRibbonPanel.Items.Add(this.defineRibbonButton);
			this.competitionRibbonPanel.Name = "competitionRibbonPanel";
			this.competitionRibbonPanel.Text = "Competition";
			// 
			// defineRibbonButton
			// 
			this.defineRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("defineRibbonButton.Image")));
			this.defineRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("defineRibbonButton.LargeImage")));
			this.defineRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.defineRibbonButton.Name = "defineRibbonButton";
			this.defineRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("defineRibbonButton.SmallImage")));
			this.defineRibbonButton.Text = "Define Features";
			this.defineRibbonButton.Click += new System.EventHandler(this.defineRibbonButton_Click);
			// 
			// selectRibbonPanel
			// 
			this.selectRibbonPanel.ButtonMoreVisible = false;
			this.selectRibbonPanel.Items.Add(this.selectAllRibbonButton);
			this.selectRibbonPanel.Items.Add(this.selectNoneRibbonButton);
			this.selectRibbonPanel.Name = "selectRibbonPanel";
			this.selectRibbonPanel.Text = "Select";
			// 
			// selectAllRibbonButton
			// 
			this.selectAllRibbonButton.CheckedGroup = "";
			this.selectAllRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("selectAllRibbonButton.Image")));
			this.selectAllRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("selectAllRibbonButton.LargeImage")));
			this.selectAllRibbonButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.selectAllRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.selectAllRibbonButton.Name = "selectAllRibbonButton";
			this.selectAllRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("selectAllRibbonButton.SmallImage")));
			this.selectAllRibbonButton.Text = "Select All";
			this.selectAllRibbonButton.Click += new System.EventHandler(this.selectAllRibbonButton_Click);
			// 
			// selectNoneRibbonButton
			// 
			this.selectNoneRibbonButton.CheckedGroup = "";
			this.selectNoneRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("selectNoneRibbonButton.Image")));
			this.selectNoneRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("selectNoneRibbonButton.LargeImage")));
			this.selectNoneRibbonButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.selectNoneRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
			this.selectNoneRibbonButton.Name = "selectNoneRibbonButton";
			this.selectNoneRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("selectNoneRibbonButton.SmallImage")));
			this.selectNoneRibbonButton.Text = "Select None";
			this.selectNoneRibbonButton.Click += new System.EventHandler(this.selectNoneRibbonButton_Click);
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
			this.mapRibbonPanel.Items.Add(this.showMapRibbonButton);
			this.mapRibbonPanel.Items.Add(this.zoomInRibbonButton);
			this.mapRibbonPanel.Items.Add(this.zoomOutRibbonButton);
			this.mapRibbonPanel.Name = "mapRibbonPanel";
			this.mapRibbonPanel.Text = "Map";
			// 
			// showMapRibbonButton
			// 
			this.showMapRibbonButton.Checked = true;
			this.showMapRibbonButton.CheckOnClick = true;
			this.showMapRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("showMapRibbonButton.Image")));
			this.showMapRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("showMapRibbonButton.LargeImage")));
			this.showMapRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.showMapRibbonButton.Name = "showMapRibbonButton";
			this.showMapRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("showMapRibbonButton.SmallImage")));
			this.showMapRibbonButton.Text = "Show Map";
			this.showMapRibbonButton.Click += new System.EventHandler(this.showMapRibbonButton_Click);
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
			this.mainSplitContainer.Location = new System.Drawing.Point(0, 126);
			this.mainSplitContainer.Name = "mainSplitContainer";
			// 
			// mainSplitContainer.Panel1
			// 
			this.mainSplitContainer.Panel1.Controls.Add(this.pointsOfInterestCheckedListBox);
			this.mainSplitContainer.Panel1.Controls.Add(this.pointsOfInterestLabel);
			this.mainSplitContainer.Panel1.Controls.Add(this.elapsedTimePointGateComboBox);
			this.mainSplitContainer.Panel1.Controls.Add(this.elapsedTimePointGateLabel);
			this.mainSplitContainer.Panel1.Controls.Add(this.landingDeckComboBox);
			this.mainSplitContainer.Panel1.Controls.Add(this.landingDeckLabel);
			this.mainSplitContainer.Panel1.Controls.Add(this.takeOffDeckComboBox);
			this.mainSplitContainer.Panel1.Controls.Add(this.takeOffDeckLabel);
			this.mainSplitContainer.Panel1.Controls.Add(this.hiddenGatesCheckedListBox);
			this.mainSplitContainer.Panel1.Controls.Add(this.hiddenGatesLabel);
			this.mainSplitContainer.Panel1.Controls.Add(this.turnpointsCheckedListBox);
			this.mainSplitContainer.Panel1.Controls.Add(this.turnpointsLabel);
			this.mainSplitContainer.Panel1.Controls.Add(this.finishPointGateComboBox);
			this.mainSplitContainer.Panel1.Controls.Add(this.finishPointGateLabel);
			this.mainSplitContainer.Panel1.Controls.Add(this.startPointGateComboBox);
			this.mainSplitContainer.Panel1.Controls.Add(this.startPointGateLabel);
			// 
			// mainSplitContainer.Panel2
			// 
			this.mainSplitContainer.Panel2.Controls.Add(this.featuresMap);
			this.mainSplitContainer.Size = new System.Drawing.Size(873, 474);
			this.mainSplitContainer.SplitterDistance = 214;
			this.mainSplitContainer.TabIndex = 1;
			// 
			// pointsOfInterestCheckedListBox
			// 
			this.pointsOfInterestCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pointsOfInterestCheckedListBox.FormattingEnabled = true;
			this.pointsOfInterestCheckedListBox.Location = new System.Drawing.Point(15, 383);
			this.pointsOfInterestCheckedListBox.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
			this.pointsOfInterestCheckedListBox.Name = "pointsOfInterestCheckedListBox";
			this.pointsOfInterestCheckedListBox.Size = new System.Drawing.Size(187, 79);
			this.pointsOfInterestCheckedListBox.TabIndex = 16;
			this.pointsOfInterestCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.pointsOfInterestCheckedListBox_ItemCheck);
			// 
			// pointsOfInterestLabel
			// 
			this.pointsOfInterestLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pointsOfInterestLabel.AutoSize = true;
			this.pointsOfInterestLabel.Location = new System.Drawing.Point(12, 366);
			this.pointsOfInterestLabel.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
			this.pointsOfInterestLabel.Name = "pointsOfInterestLabel";
			this.pointsOfInterestLabel.Size = new System.Drawing.Size(88, 13);
			this.pointsOfInterestLabel.TabIndex = 15;
			this.pointsOfInterestLabel.Text = "Points of interest:";
			// 
			// elapsedTimePointGateComboBox
			// 
			this.elapsedTimePointGateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.elapsedTimePointGateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.elapsedTimePointGateComboBox.FormattingEnabled = true;
			this.elapsedTimePointGateComboBox.Location = new System.Drawing.Point(15, 191);
			this.elapsedTimePointGateComboBox.Name = "elapsedTimePointGateComboBox";
			this.elapsedTimePointGateComboBox.Size = new System.Drawing.Size(187, 21);
			this.elapsedTimePointGateComboBox.TabIndex = 14;
			this.elapsedTimePointGateComboBox.SelectedIndexChanged += new System.EventHandler(this.elapsedTimePointGateComboBox_SelectedIndexChanged);
			// 
			// elapsedTimePointGateLabel
			// 
			this.elapsedTimePointGateLabel.AutoSize = true;
			this.elapsedTimePointGateLabel.Location = new System.Drawing.Point(12, 175);
			this.elapsedTimePointGateLabel.Name = "elapsedTimePointGateLabel";
			this.elapsedTimePointGateLabel.Size = new System.Drawing.Size(132, 13);
			this.elapsedTimePointGateLabel.TabIndex = 13;
			this.elapsedTimePointGateLabel.Text = "Elapsed time point or gate:";
			// 
			// landingDeckComboBox
			// 
			this.landingDeckComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.landingDeckComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.landingDeckComboBox.FormattingEnabled = true;
			this.landingDeckComboBox.Location = new System.Drawing.Point(15, 63);
			this.landingDeckComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.landingDeckComboBox.Name = "landingDeckComboBox";
			this.landingDeckComboBox.Size = new System.Drawing.Size(187, 21);
			this.landingDeckComboBox.TabIndex = 12;
			this.landingDeckComboBox.SelectedIndexChanged += new System.EventHandler(this.landingDeckComboBox_SelectedIndexChanged);
			// 
			// landingDeckLabel
			// 
			this.landingDeckLabel.AutoSize = true;
			this.landingDeckLabel.Location = new System.Drawing.Point(12, 48);
			this.landingDeckLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.landingDeckLabel.Name = "landingDeckLabel";
			this.landingDeckLabel.Size = new System.Drawing.Size(75, 13);
			this.landingDeckLabel.TabIndex = 11;
			this.landingDeckLabel.Text = "Landing deck:";
			// 
			// takeOffDeckComboBox
			// 
			this.takeOffDeckComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.takeOffDeckComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.takeOffDeckComboBox.FormattingEnabled = true;
			this.takeOffDeckComboBox.Location = new System.Drawing.Point(15, 27);
			this.takeOffDeckComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.takeOffDeckComboBox.Name = "takeOffDeckComboBox";
			this.takeOffDeckComboBox.Size = new System.Drawing.Size(187, 21);
			this.takeOffDeckComboBox.TabIndex = 10;
			this.takeOffDeckComboBox.SelectedIndexChanged += new System.EventHandler(this.takeOffDeckComboBox_SelectedIndexChanged);
			// 
			// takeOffDeckLabel
			// 
			this.takeOffDeckLabel.AutoSize = true;
			this.takeOffDeckLabel.Location = new System.Drawing.Point(12, 12);
			this.takeOffDeckLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.takeOffDeckLabel.Name = "takeOffDeckLabel";
			this.takeOffDeckLabel.Size = new System.Drawing.Size(77, 13);
			this.takeOffDeckLabel.TabIndex = 9;
			this.takeOffDeckLabel.Text = "Take-off deck:";
			// 
			// hiddenGatesCheckedListBox
			// 
			this.hiddenGatesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.hiddenGatesCheckedListBox.FormattingEnabled = true;
			this.hiddenGatesCheckedListBox.Location = new System.Drawing.Point(15, 284);
			this.hiddenGatesCheckedListBox.Name = "hiddenGatesCheckedListBox";
			this.hiddenGatesCheckedListBox.Size = new System.Drawing.Size(187, 79);
			this.hiddenGatesCheckedListBox.TabIndex = 8;
			this.hiddenGatesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.hiddenGatesCheckedListBox_ItemCheck);
			// 
			// hiddenGatesLabel
			// 
			this.hiddenGatesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.hiddenGatesLabel.AutoSize = true;
			this.hiddenGatesLabel.Location = new System.Drawing.Point(12, 268);
			this.hiddenGatesLabel.Name = "hiddenGatesLabel";
			this.hiddenGatesLabel.Size = new System.Drawing.Size(73, 13);
			this.hiddenGatesLabel.TabIndex = 7;
			this.hiddenGatesLabel.Text = "Hidden gates:";
			// 
			// turnpointsCheckedListBox
			// 
			this.turnpointsCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.turnpointsCheckedListBox.FormattingEnabled = true;
			this.turnpointsCheckedListBox.Location = new System.Drawing.Point(15, 231);
			this.turnpointsCheckedListBox.Name = "turnpointsCheckedListBox";
			this.turnpointsCheckedListBox.Size = new System.Drawing.Size(187, 34);
			this.turnpointsCheckedListBox.TabIndex = 6;
			this.turnpointsCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.turnpointsCheckedListBox_ItemCheck);
			// 
			// turnpointsLabel
			// 
			this.turnpointsLabel.AutoSize = true;
			this.turnpointsLabel.Location = new System.Drawing.Point(12, 215);
			this.turnpointsLabel.Name = "turnpointsLabel";
			this.turnpointsLabel.Size = new System.Drawing.Size(60, 13);
			this.turnpointsLabel.TabIndex = 5;
			this.turnpointsLabel.Text = "Turnpoints:";
			// 
			// finishPointGateComboBox
			// 
			this.finishPointGateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.finishPointGateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.finishPointGateComboBox.FormattingEnabled = true;
			this.finishPointGateComboBox.Location = new System.Drawing.Point(15, 151);
			this.finishPointGateComboBox.Name = "finishPointGateComboBox";
			this.finishPointGateComboBox.Size = new System.Drawing.Size(187, 21);
			this.finishPointGateComboBox.TabIndex = 4;
			this.finishPointGateComboBox.SelectedIndexChanged += new System.EventHandler(this.finishPointGateComboBox_SelectedIndexChanged);
			// 
			// finishPointGateLabel
			// 
			this.finishPointGateLabel.AutoSize = true;
			this.finishPointGateLabel.Location = new System.Drawing.Point(12, 135);
			this.finishPointGateLabel.Name = "finishPointGateLabel";
			this.finishPointGateLabel.Size = new System.Drawing.Size(99, 13);
			this.finishPointGateLabel.TabIndex = 3;
			this.finishPointGateLabel.Text = "Finish point or gate:";
			// 
			// startPointGateComboBox
			// 
			this.startPointGateComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.startPointGateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.startPointGateComboBox.FormattingEnabled = true;
			this.startPointGateComboBox.Location = new System.Drawing.Point(15, 114);
			this.startPointGateComboBox.Name = "startPointGateComboBox";
			this.startPointGateComboBox.Size = new System.Drawing.Size(187, 21);
			this.startPointGateComboBox.TabIndex = 2;
			this.startPointGateComboBox.SelectedIndexChanged += new System.EventHandler(this.startPointGateComboBox_SelectedIndexChanged);
			// 
			// startPointGateLabel
			// 
			this.startPointGateLabel.AutoSize = true;
			this.startPointGateLabel.Location = new System.Drawing.Point(12, 97);
			this.startPointGateLabel.Name = "startPointGateLabel";
			this.startPointGateLabel.Size = new System.Drawing.Size(94, 13);
			this.startPointGateLabel.TabIndex = 1;
			this.startPointGateLabel.Text = "Start point or gate:";
			// 
			// featuresMap
			// 
			this.featuresMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.featuresMap.Location = new System.Drawing.Point(0, 0);
			this.featuresMap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.featuresMap.Name = "featuresMap";
			this.featuresMap.Size = new System.Drawing.Size(655, 474);
			this.featuresMap.TabIndex = 0;
			// 
			// TaskFeaturesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(873, 600);
			this.Controls.Add(this.mainSplitContainer);
			this.Controls.Add(this.mainRibbon);
			this.KeyPreview = true;
			this.MinimizeBox = false;
			this.Name = "TaskFeaturesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Task Features";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.TaskFeaturesForm_Load);
			this.mainSplitContainer.Panel1.ResumeLayout(false);
			this.mainSplitContainer.Panel1.PerformLayout();
			this.mainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
			this.mainSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Ribbon mainRibbon;
		private System.Windows.Forms.RibbonTab featuresRibbonTab;
		private System.Windows.Forms.RibbonPanel competitionRibbonPanel;
		private System.Windows.Forms.RibbonButton defineRibbonButton;
		private System.Windows.Forms.RibbonTab viewRibbonTab;
		private System.Windows.Forms.RibbonPanel mapRibbonPanel;
		private System.Windows.Forms.RibbonButton showMapRibbonButton;
		private System.Windows.Forms.RibbonButton zoomInRibbonButton;
		private System.Windows.Forms.RibbonButton zoomOutRibbonButton;
		private System.Windows.Forms.SplitContainer mainSplitContainer;
		private Map featuresMap;
		private System.Windows.Forms.CheckedListBox turnpointsCheckedListBox;
		private System.Windows.Forms.Label turnpointsLabel;
		private System.Windows.Forms.ComboBox finishPointGateComboBox;
		private System.Windows.Forms.Label finishPointGateLabel;
		private System.Windows.Forms.ComboBox startPointGateComboBox;
		private System.Windows.Forms.Label startPointGateLabel;
		private System.Windows.Forms.CheckedListBox hiddenGatesCheckedListBox;
		private System.Windows.Forms.Label hiddenGatesLabel;
        private System.Windows.Forms.ComboBox landingDeckComboBox;
        private System.Windows.Forms.Label landingDeckLabel;
        private System.Windows.Forms.ComboBox takeOffDeckComboBox;
        private System.Windows.Forms.Label takeOffDeckLabel;
		private System.Windows.Forms.RibbonPanel selectRibbonPanel;
		private System.Windows.Forms.RibbonButton selectAllRibbonButton;
		private System.Windows.Forms.RibbonButton selectNoneRibbonButton;
		private System.Windows.Forms.ComboBox elapsedTimePointGateComboBox;
		private System.Windows.Forms.Label elapsedTimePointGateLabel;
		private System.Windows.Forms.Label pointsOfInterestLabel;
		private System.Windows.Forms.CheckedListBox pointsOfInterestCheckedListBox;
	}
}