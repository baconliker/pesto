namespace ColinBaker.Pesto.UI.Features
{
	partial class FeatureDefinitionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeatureDefinitionForm));
            this.featuresRibbon = new System.Windows.Forms.Ribbon();
            this.featuresRibbonTab = new System.Windows.Forms.RibbonTab();
            this.addRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.addAirfieldRibbonButton = new System.Windows.Forms.RibbonButton();
            this.addDeckRibbonButton = new System.Windows.Forms.RibbonButton();
            this.addNfzRibbonButton = new System.Windows.Forms.RibbonButton();
            this.addGateRibbonButton = new System.Windows.Forms.RibbonButton();
            this.addPointRibbonButton = new System.Windows.Forms.RibbonButton();
            this.addFeaturesRibbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.cloneRibbonButton = new System.Windows.Forms.RibbonButton();
            this.addFeaturesRibbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.importRibbonButton = new System.Windows.Forms.RibbonButton();
            this.amendRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.editRibbonButton = new System.Windows.Forms.RibbonButton();
            this.deleteRibbonButton = new System.Windows.Forms.RibbonButton();
            this.viewRibbonTab = new System.Windows.Forms.RibbonTab();
            this.mapRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.showMapRibbonButton = new System.Windows.Forms.RibbonButton();
            this.zoomInRibbonButton = new System.Windows.Forms.RibbonButton();
            this.zoomOutRibbonButton = new System.Windows.Forms.RibbonButton();
            this.featuresSplitContainer = new System.Windows.Forms.SplitContainer();
            this.featuresTreeView = new System.Windows.Forms.TreeView();
            this.featuresMap = new ColinBaker.Pesto.UI.Map();
            this.mapContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNfzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAirfieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.featuresSplitContainer)).BeginInit();
            this.featuresSplitContainer.Panel1.SuspendLayout();
            this.featuresSplitContainer.Panel2.SuspendLayout();
            this.featuresSplitContainer.SuspendLayout();
            this.mapContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // featuresRibbon
            // 
            this.featuresRibbon.CaptionBarVisible = false;
            this.featuresRibbon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.featuresRibbon.Location = new System.Drawing.Point(0, 0);
            this.featuresRibbon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.featuresRibbon.Minimized = false;
            this.featuresRibbon.Name = "featuresRibbon";
            // 
            // 
            // 
            this.featuresRibbon.OrbDropDown.BorderRoundness = 8;
            this.featuresRibbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.featuresRibbon.OrbDropDown.Name = "";
            this.featuresRibbon.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.featuresRibbon.OrbDropDown.TabIndex = 0;
            this.featuresRibbon.OrbImage = null;
            this.featuresRibbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.featuresRibbon.OrbVisible = false;
            this.featuresRibbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.featuresRibbon.Size = new System.Drawing.Size(1092, 186);
            this.featuresRibbon.TabIndex = 0;
            this.featuresRibbon.Tabs.Add(this.featuresRibbonTab);
            this.featuresRibbon.Tabs.Add(this.viewRibbonTab);
            this.featuresRibbon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.featuresRibbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // featuresRibbonTab
            // 
            this.featuresRibbonTab.Panels.Add(this.addRibbonPanel);
            this.featuresRibbonTab.Panels.Add(this.amendRibbonPanel);
            this.featuresRibbonTab.Text = "Features";
            // 
            // addRibbonPanel
            // 
            this.addRibbonPanel.ButtonMoreVisible = false;
            this.addRibbonPanel.Items.Add(this.addAirfieldRibbonButton);
            this.addRibbonPanel.Items.Add(this.addDeckRibbonButton);
            this.addRibbonPanel.Items.Add(this.addNfzRibbonButton);
            this.addRibbonPanel.Items.Add(this.addGateRibbonButton);
            this.addRibbonPanel.Items.Add(this.addPointRibbonButton);
            this.addRibbonPanel.Items.Add(this.addFeaturesRibbonSeparator1);
            this.addRibbonPanel.Items.Add(this.cloneRibbonButton);
            this.addRibbonPanel.Items.Add(this.addFeaturesRibbonSeparator2);
            this.addRibbonPanel.Items.Add(this.importRibbonButton);
            this.addRibbonPanel.Text = "Add";
            // 
            // addAirfieldRibbonButton
            // 
            this.addAirfieldRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("addAirfieldRibbonButton.Image")));
            this.addAirfieldRibbonButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.addAirfieldRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("addAirfieldRibbonButton.SmallImage")));
            this.addAirfieldRibbonButton.Text = "Add Airfield";
            this.addAirfieldRibbonButton.Click += new System.EventHandler(this.addAirfieldRibbonButton_Click);
            // 
            // addDeckRibbonButton
            // 
            this.addDeckRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("addDeckRibbonButton.Image")));
            this.addDeckRibbonButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.addDeckRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("addDeckRibbonButton.SmallImage")));
            this.addDeckRibbonButton.Text = "Add Deck";
            this.addDeckRibbonButton.Click += new System.EventHandler(this.addDeckRibbonButton_Click);
            // 
            // addNfzRibbonButton
            // 
            this.addNfzRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("addNfzRibbonButton.Image")));
            this.addNfzRibbonButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.addNfzRibbonButton.MinimumSize = new System.Drawing.Size(60, 0);
            this.addNfzRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("addNfzRibbonButton.SmallImage")));
            this.addNfzRibbonButton.Text = "Add No Fly Zone";
            this.addNfzRibbonButton.Click += new System.EventHandler(this.addNfzRibbonButton_Click);
            // 
            // addGateRibbonButton
            // 
            this.addGateRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("addGateRibbonButton.Image")));
            this.addGateRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.addGateRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("addGateRibbonButton.SmallImage")));
            this.addGateRibbonButton.Text = "Add Gate";
            this.addGateRibbonButton.Click += new System.EventHandler(this.addGateRibbonButton_Click);
            // 
            // addPointRibbonButton
            // 
            this.addPointRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("addPointRibbonButton.Image")));
            this.addPointRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.addPointRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("addPointRibbonButton.SmallImage")));
            this.addPointRibbonButton.Text = "Add Point";
            this.addPointRibbonButton.Click += new System.EventHandler(this.addPointRibbonButton_Click);
            // 
            // cloneRibbonButton
            // 
            this.cloneRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("cloneRibbonButton.Image")));
            this.cloneRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.cloneRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("cloneRibbonButton.SmallImage")));
            this.cloneRibbonButton.Text = "Clone";
            this.cloneRibbonButton.Click += new System.EventHandler(this.cloneRibbonButton_Click);
            // 
            // importRibbonButton
            // 
            this.importRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("importRibbonButton.Image")));
            this.importRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.importRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("importRibbonButton.SmallImage")));
            this.importRibbonButton.Text = "Import";
            this.importRibbonButton.Click += new System.EventHandler(this.importRibbonButton_Click);
            // 
            // amendRibbonPanel
            // 
            this.amendRibbonPanel.ButtonMoreVisible = false;
            this.amendRibbonPanel.Items.Add(this.editRibbonButton);
            this.amendRibbonPanel.Items.Add(this.deleteRibbonButton);
            this.amendRibbonPanel.Text = "Amend";
            // 
            // editRibbonButton
            // 
            this.editRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("editRibbonButton.Image")));
            this.editRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.editRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("editRibbonButton.SmallImage")));
            this.editRibbonButton.Text = "Edit";
            this.editRibbonButton.Click += new System.EventHandler(this.editRibbonButton_Click);
            // 
            // deleteRibbonButton
            // 
            this.deleteRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteRibbonButton.Image")));
            this.deleteRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.deleteRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("deleteRibbonButton.SmallImage")));
            this.deleteRibbonButton.Text = "Delete";
            this.deleteRibbonButton.Click += new System.EventHandler(this.deleteRibbonButton_Click);
            // 
            // viewRibbonTab
            // 
            this.viewRibbonTab.Panels.Add(this.mapRibbonPanel);
            this.viewRibbonTab.Text = "View";
            // 
            // mapRibbonPanel
            // 
            this.mapRibbonPanel.ButtonMoreVisible = false;
            this.mapRibbonPanel.Items.Add(this.showMapRibbonButton);
            this.mapRibbonPanel.Items.Add(this.zoomInRibbonButton);
            this.mapRibbonPanel.Items.Add(this.zoomOutRibbonButton);
            this.mapRibbonPanel.Text = "Map";
            // 
            // showMapRibbonButton
            // 
            this.showMapRibbonButton.Checked = true;
            this.showMapRibbonButton.CheckOnClick = true;
            this.showMapRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("showMapRibbonButton.Image")));
            this.showMapRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.showMapRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("showMapRibbonButton.SmallImage")));
            this.showMapRibbonButton.Text = "Show Map";
            this.showMapRibbonButton.Click += new System.EventHandler(this.showMapRibbonButton_Click);
            // 
            // zoomInRibbonButton
            // 
            this.zoomInRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInRibbonButton.Image")));
            this.zoomInRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.zoomInRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomInRibbonButton.SmallImage")));
            this.zoomInRibbonButton.Text = "Zoom In";
            this.zoomInRibbonButton.Click += new System.EventHandler(this.zoomInRibbonButton_Click);
            // 
            // zoomOutRibbonButton
            // 
            this.zoomOutRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutRibbonButton.Image")));
            this.zoomOutRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.zoomOutRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomOutRibbonButton.SmallImage")));
            this.zoomOutRibbonButton.Text = "Zoom Out";
            this.zoomOutRibbonButton.Click += new System.EventHandler(this.zoomOutRibbonButton_Click);
            // 
            // featuresSplitContainer
            // 
            this.featuresSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featuresSplitContainer.Location = new System.Drawing.Point(0, 186);
            this.featuresSplitContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.featuresSplitContainer.Name = "featuresSplitContainer";
            // 
            // featuresSplitContainer.Panel1
            // 
            this.featuresSplitContainer.Panel1.Controls.Add(this.featuresTreeView);
            // 
            // featuresSplitContainer.Panel2
            // 
            this.featuresSplitContainer.Panel2.Controls.Add(this.featuresMap);
            this.featuresSplitContainer.Size = new System.Drawing.Size(1092, 719);
            this.featuresSplitContainer.SplitterDistance = 267;
            this.featuresSplitContainer.SplitterWidth = 6;
            this.featuresSplitContainer.TabIndex = 1;
            // 
            // featuresTreeView
            // 
            this.featuresTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featuresTreeView.HideSelection = false;
            this.featuresTreeView.Location = new System.Drawing.Point(0, 0);
            this.featuresTreeView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.featuresTreeView.Name = "featuresTreeView";
            this.featuresTreeView.ShowRootLines = false;
            this.featuresTreeView.Size = new System.Drawing.Size(267, 719);
            this.featuresTreeView.TabIndex = 0;
            this.featuresTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.featuresTreeView_AfterSelect);
            this.featuresTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.featuresTreeView_MouseDoubleClick);
            // 
            // featuresMap
            // 
            this.featuresMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featuresMap.Location = new System.Drawing.Point(0, 0);
            this.featuresMap.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.featuresMap.Name = "featuresMap";
            this.featuresMap.Size = new System.Drawing.Size(819, 719);
            this.featuresMap.TabIndex = 0;
            this.featuresMap.MapRightClicked += new System.EventHandler<ColinBaker.Pesto.UI.MapClickedEventArgs>(this.featuresMap_MapRightClicked);
            // 
            // mapContextMenuStrip
            // 
            this.mapContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mapContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNfzToolStripMenuItem,
            this.addAirfieldToolStripMenuItem,
            this.addDeckToolStripMenuItem,
            this.addPointToolStripMenuItem,
            this.addGateToolStripMenuItem});
            this.mapContextMenuStrip.Name = "mapContextMenuStrip";
            this.mapContextMenuStrip.Size = new System.Drawing.Size(233, 154);
            // 
            // addNfzToolStripMenuItem
            // 
            this.addNfzToolStripMenuItem.Name = "addNfzToolStripMenuItem";
            this.addNfzToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.addNfzToolStripMenuItem.Text = "Add No Fly Zone";
            this.addNfzToolStripMenuItem.Click += new System.EventHandler(this.addNfzToolStripMenuItem_Click);
            // 
            // addAirfieldToolStripMenuItem
            // 
            this.addAirfieldToolStripMenuItem.Enabled = false;
            this.addAirfieldToolStripMenuItem.Name = "addAirfieldToolStripMenuItem";
            this.addAirfieldToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.addAirfieldToolStripMenuItem.Text = "Add Airfield";
            // 
            // addDeckToolStripMenuItem
            // 
            this.addDeckToolStripMenuItem.Enabled = false;
            this.addDeckToolStripMenuItem.Name = "addDeckToolStripMenuItem";
            this.addDeckToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.addDeckToolStripMenuItem.Text = "Add Deck";
            // 
            // addPointToolStripMenuItem
            // 
            this.addPointToolStripMenuItem.Name = "addPointToolStripMenuItem";
            this.addPointToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.addPointToolStripMenuItem.Text = "Add Point";
            this.addPointToolStripMenuItem.Click += new System.EventHandler(this.addPointToolStripMenuItem_Click);
            // 
            // addGateToolStripMenuItem
            // 
            this.addGateToolStripMenuItem.Name = "addGateToolStripMenuItem";
            this.addGateToolStripMenuItem.Size = new System.Drawing.Size(232, 30);
            this.addGateToolStripMenuItem.Text = "Add Gate";
            this.addGateToolStripMenuItem.Click += new System.EventHandler(this.addGateToolStripMenuItem_Click);
            // 
            // importOpenFileDialog
            // 
            this.importOpenFileDialog.Filter = "Google Earth Files (*.kml)|*.kml";
            this.importOpenFileDialog.Title = "Select File To Import";
            // 
            // FeatureDefinitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 905);
            this.Controls.Add(this.featuresSplitContainer);
            this.Controls.Add(this.featuresRibbon);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "FeatureDefinitionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Define Features";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FeatureDefinitionForm_Load);
            this.featuresSplitContainer.Panel1.ResumeLayout(false);
            this.featuresSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.featuresSplitContainer)).EndInit();
            this.featuresSplitContainer.ResumeLayout(false);
            this.mapContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Ribbon featuresRibbon;
		private System.Windows.Forms.RibbonTab featuresRibbonTab;
		private System.Windows.Forms.RibbonPanel addRibbonPanel;
		private System.Windows.Forms.RibbonButton addPointRibbonButton;
		private System.Windows.Forms.RibbonPanel amendRibbonPanel;
		private System.Windows.Forms.RibbonButton editRibbonButton;
		private System.Windows.Forms.RibbonButton deleteRibbonButton;
		private System.Windows.Forms.SplitContainer featuresSplitContainer;
		private System.Windows.Forms.TreeView featuresTreeView;
		private System.Windows.Forms.RibbonTab viewRibbonTab;
		private System.Windows.Forms.RibbonPanel mapRibbonPanel;
		private System.Windows.Forms.RibbonButton showMapRibbonButton;
		private System.Windows.Forms.RibbonButton zoomInRibbonButton;
		private System.Windows.Forms.RibbonButton zoomOutRibbonButton;
		private Map featuresMap;
		private System.Windows.Forms.ContextMenuStrip mapContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addNfzToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addAirfieldToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addDeckToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addPointToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addGateToolStripMenuItem;
		private System.Windows.Forms.RibbonButton addNfzRibbonButton;
		private System.Windows.Forms.RibbonButton addGateRibbonButton;
        private System.Windows.Forms.RibbonSeparator addFeaturesRibbonSeparator1;
        private System.Windows.Forms.RibbonButton importRibbonButton;
        private System.Windows.Forms.OpenFileDialog importOpenFileDialog;
        private System.Windows.Forms.RibbonButton addAirfieldRibbonButton;
        private System.Windows.Forms.RibbonButton addDeckRibbonButton;
        private System.Windows.Forms.RibbonButton cloneRibbonButton;
        private System.Windows.Forms.RibbonSeparator addFeaturesRibbonSeparator2;
    }
}