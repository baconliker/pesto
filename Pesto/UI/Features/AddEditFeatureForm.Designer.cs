namespace ColinBaker.Pesto.UI.Features
{
    partial class AddEditFeatureForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditFeatureForm));
			this.featureRibbon = new System.Windows.Forms.Ribbon();
			this.featureRibbonTab = new System.Windows.Forms.RibbonTab();
			this.changesRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.saveRibbonButton = new System.Windows.Forms.RibbonButton();
			this.cancelRibbonButton = new System.Windows.Forms.RibbonButton();
			this.polygonRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.addPolygonRibbonButton = new System.Windows.Forms.RibbonButton();
			this.removePolygonRibbonButton = new System.Windows.Forms.RibbonButton();
			this.removeAllPolygonRibbonButton = new System.Windows.Forms.RibbonButton();
			this.viewRibbonTab = new System.Windows.Forms.RibbonTab();
			this.mapRibbonPanel = new System.Windows.Forms.RibbonPanel();
			this.showMapRibbonButton = new System.Windows.Forms.RibbonButton();
			this.zoomInRibbonButton = new System.Windows.Forms.RibbonButton();
			this.zoomOutRibbonButton = new System.Windows.Forms.RibbonButton();
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.shapeLabel = new System.Windows.Forms.Label();
			this.shapeComboBox = new System.Windows.Forms.ComboBox();
			this.circleGroupBox = new System.Windows.Forms.GroupBox();
			this.circleRadiusTextBox = new System.Windows.Forms.TextBox();
			this.circleRadiusLabel = new System.Windows.Forms.Label();
			this.circleLongitudeTextBox = new System.Windows.Forms.TextBox();
			this.circleLongitudeLabel = new System.Windows.Forms.Label();
			this.circleLatitudeTextBox = new System.Windows.Forms.TextBox();
			this.circleLatitudeLabel = new System.Windows.Forms.Label();
			this.lineGroupBox = new System.Windows.Forms.GroupBox();
			this.lineBearingTypeComboBox = new System.Windows.Forms.ComboBox();
			this.lineBearingLabel = new System.Windows.Forms.Label();
			this.lineBearingTextBox = new System.Windows.Forms.TextBox();
			this.lineWidthTextBox = new System.Windows.Forms.TextBox();
			this.lineWidthLabel = new System.Windows.Forms.Label();
			this.lineLongitudeTextBox = new System.Windows.Forms.TextBox();
			this.lineLongitudeLabel = new System.Windows.Forms.Label();
			this.lineLatitudeTextBox = new System.Windows.Forms.TextBox();
			this.lineLatitudeLabel = new System.Windows.Forms.Label();
			this.polygonGroupBox = new System.Windows.Forms.GroupBox();
			this.polygonDataGridView = new System.Windows.Forms.DataGridView();
			this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.upperAltitudeTextBox = new System.Windows.Forms.TextBox();
			this.upperAltitudeLabel = new System.Windows.Forms.Label();
			this.lowerAltitudeTextBox = new System.Windows.Forms.TextBox();
			this.lowerAltitudeLabel = new System.Windows.Forms.Label();
			this.featureMap = new ColinBaker.Pesto.UI.Map();
			this.circleGroupBox.SuspendLayout();
			this.lineGroupBox.SuspendLayout();
			this.polygonGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.polygonDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// featureRibbon
			// 
			this.featureRibbon.CaptionBarVisible = false;
			this.featureRibbon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.featureRibbon.Location = new System.Drawing.Point(0, 0);
			this.featureRibbon.Margin = new System.Windows.Forms.Padding(2);
			this.featureRibbon.Minimized = false;
			this.featureRibbon.Name = "featureRibbon";
			// 
			// 
			// 
			this.featureRibbon.OrbDropDown.BorderRoundness = 8;
			this.featureRibbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
			this.featureRibbon.OrbDropDown.Name = "";
			this.featureRibbon.OrbDropDown.Size = new System.Drawing.Size(527, 447);
			this.featureRibbon.OrbDropDown.TabIndex = 0;
			this.featureRibbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
			this.featureRibbon.OrbVisible = false;
			this.featureRibbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
			this.featureRibbon.Size = new System.Drawing.Size(774, 121);
			this.featureRibbon.TabIndex = 10;
			this.featureRibbon.Tabs.Add(this.featureRibbonTab);
			this.featureRibbon.Tabs.Add(this.viewRibbonTab);
			this.featureRibbon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
			this.featureRibbon.TabSpacing = 4;
			this.featureRibbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
			// 
			// featureRibbonTab
			// 
			this.featureRibbonTab.Name = "featureRibbonTab";
			this.featureRibbonTab.Panels.Add(this.changesRibbonPanel);
			this.featureRibbonTab.Panels.Add(this.polygonRibbonPanel);
			this.featureRibbonTab.Text = "Feature";
			// 
			// changesRibbonPanel
			// 
			this.changesRibbonPanel.ButtonMoreVisible = false;
			this.changesRibbonPanel.Items.Add(this.saveRibbonButton);
			this.changesRibbonPanel.Items.Add(this.cancelRibbonButton);
			this.changesRibbonPanel.Name = "changesRibbonPanel";
			this.changesRibbonPanel.Text = "Changes";
			// 
			// saveRibbonButton
			// 
			this.saveRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("saveRibbonButton.Image")));
			this.saveRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("saveRibbonButton.LargeImage")));
			this.saveRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.saveRibbonButton.Name = "saveRibbonButton";
			this.saveRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("saveRibbonButton.SmallImage")));
			this.saveRibbonButton.Text = "Save";
			this.saveRibbonButton.Click += new System.EventHandler(this.saveRibbonButton_Click);
			// 
			// cancelRibbonButton
			// 
			this.cancelRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelRibbonButton.Image")));
			this.cancelRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("cancelRibbonButton.LargeImage")));
			this.cancelRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.cancelRibbonButton.Name = "cancelRibbonButton";
			this.cancelRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("cancelRibbonButton.SmallImage")));
			this.cancelRibbonButton.Text = "Cancel";
			this.cancelRibbonButton.Click += new System.EventHandler(this.cancelRibbonButton_Click);
			// 
			// polygonRibbonPanel
			// 
			this.polygonRibbonPanel.ButtonMoreVisible = false;
			this.polygonRibbonPanel.Items.Add(this.addPolygonRibbonButton);
			this.polygonRibbonPanel.Items.Add(this.removePolygonRibbonButton);
			this.polygonRibbonPanel.Items.Add(this.removeAllPolygonRibbonButton);
			this.polygonRibbonPanel.Name = "polygonRibbonPanel";
			this.polygonRibbonPanel.Text = "Polygon";
			// 
			// addPolygonRibbonButton
			// 
			this.addPolygonRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("addPolygonRibbonButton.Image")));
			this.addPolygonRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("addPolygonRibbonButton.LargeImage")));
			this.addPolygonRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.addPolygonRibbonButton.Name = "addPolygonRibbonButton";
			this.addPolygonRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("addPolygonRibbonButton.SmallImage")));
			this.addPolygonRibbonButton.Text = "Add";
			this.addPolygonRibbonButton.Click += new System.EventHandler(this.addPolygonRibbonButton_Click);
			// 
			// removePolygonRibbonButton
			// 
			this.removePolygonRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("removePolygonRibbonButton.Image")));
			this.removePolygonRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("removePolygonRibbonButton.LargeImage")));
			this.removePolygonRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.removePolygonRibbonButton.Name = "removePolygonRibbonButton";
			this.removePolygonRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("removePolygonRibbonButton.SmallImage")));
			this.removePolygonRibbonButton.Text = "Remove";
			this.removePolygonRibbonButton.Click += new System.EventHandler(this.removePolygonRibbonButton_Click);
			// 
			// removeAllPolygonRibbonButton
			// 
			this.removeAllPolygonRibbonButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAllPolygonRibbonButton.Image")));
			this.removeAllPolygonRibbonButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("removeAllPolygonRibbonButton.LargeImage")));
			this.removeAllPolygonRibbonButton.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
			this.removeAllPolygonRibbonButton.Name = "removeAllPolygonRibbonButton";
			this.removeAllPolygonRibbonButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("removeAllPolygonRibbonButton.SmallImage")));
			this.removeAllPolygonRibbonButton.Text = "Remove All";
			this.removeAllPolygonRibbonButton.Click += new System.EventHandler(this.removeAllPolygonRibbonButton_Click);
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
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(8, 129);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(38, 13);
			this.nameLabel.TabIndex = 0;
			this.nameLabel.Text = "Name:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(11, 144);
			this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(263, 20);
			this.nameTextBox.TabIndex = 1;
			// 
			// shapeLabel
			// 
			this.shapeLabel.AutoSize = true;
			this.shapeLabel.Location = new System.Drawing.Point(8, 172);
			this.shapeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.shapeLabel.Name = "shapeLabel";
			this.shapeLabel.Size = new System.Drawing.Size(41, 13);
			this.shapeLabel.TabIndex = 2;
			this.shapeLabel.Text = "Shape:";
			// 
			// shapeComboBox
			// 
			this.shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shapeComboBox.FormattingEnabled = true;
			this.shapeComboBox.Location = new System.Drawing.Point(11, 187);
			this.shapeComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.shapeComboBox.Name = "shapeComboBox";
			this.shapeComboBox.Size = new System.Drawing.Size(263, 21);
			this.shapeComboBox.TabIndex = 3;
			this.shapeComboBox.SelectedIndexChanged += new System.EventHandler(this.shapeComboBox_SelectedIndexChanged);
			// 
			// circleGroupBox
			// 
			this.circleGroupBox.Controls.Add(this.circleRadiusTextBox);
			this.circleGroupBox.Controls.Add(this.circleRadiusLabel);
			this.circleGroupBox.Controls.Add(this.circleLongitudeTextBox);
			this.circleGroupBox.Controls.Add(this.circleLongitudeLabel);
			this.circleGroupBox.Controls.Add(this.circleLatitudeTextBox);
			this.circleGroupBox.Controls.Add(this.circleLatitudeLabel);
			this.circleGroupBox.Location = new System.Drawing.Point(11, 216);
			this.circleGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.circleGroupBox.Name = "circleGroupBox";
			this.circleGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.circleGroupBox.Size = new System.Drawing.Size(262, 205);
			this.circleGroupBox.TabIndex = 4;
			this.circleGroupBox.TabStop = false;
			this.circleGroupBox.Text = "Circle properties";
			this.circleGroupBox.Visible = false;
			// 
			// circleRadiusTextBox
			// 
			this.circleRadiusTextBox.Location = new System.Drawing.Point(8, 129);
			this.circleRadiusTextBox.Name = "circleRadiusTextBox";
			this.circleRadiusTextBox.Size = new System.Drawing.Size(60, 20);
			this.circleRadiusTextBox.TabIndex = 5;
			this.circleRadiusTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.circleRadiusTextBox_Validating);
			// 
			// circleRadiusLabel
			// 
			this.circleRadiusLabel.AutoSize = true;
			this.circleRadiusLabel.Location = new System.Drawing.Point(5, 114);
			this.circleRadiusLabel.Name = "circleRadiusLabel";
			this.circleRadiusLabel.Size = new System.Drawing.Size(83, 13);
			this.circleRadiusLabel.TabIndex = 4;
			this.circleRadiusLabel.Text = "Radius (metres):";
			// 
			// circleLongitudeTextBox
			// 
			this.circleLongitudeTextBox.Location = new System.Drawing.Point(8, 85);
			this.circleLongitudeTextBox.Name = "circleLongitudeTextBox";
			this.circleLongitudeTextBox.Size = new System.Drawing.Size(94, 20);
			this.circleLongitudeTextBox.TabIndex = 3;
			this.circleLongitudeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.circleLongitudeTextBox_Validating);
			// 
			// circleLongitudeLabel
			// 
			this.circleLongitudeLabel.AutoSize = true;
			this.circleLongitudeLabel.Location = new System.Drawing.Point(5, 70);
			this.circleLongitudeLabel.Name = "circleLongitudeLabel";
			this.circleLongitudeLabel.Size = new System.Drawing.Size(143, 13);
			this.circleLongitudeLabel.TabIndex = 2;
			this.circleLongitudeLabel.Text = "Longitude (decimal degrees):";
			// 
			// circleLatitudeTextBox
			// 
			this.circleLatitudeTextBox.Location = new System.Drawing.Point(8, 42);
			this.circleLatitudeTextBox.Name = "circleLatitudeTextBox";
			this.circleLatitudeTextBox.Size = new System.Drawing.Size(94, 20);
			this.circleLatitudeTextBox.TabIndex = 1;
			this.circleLatitudeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.circleLatitudeTextBox_Validating);
			// 
			// circleLatitudeLabel
			// 
			this.circleLatitudeLabel.AutoSize = true;
			this.circleLatitudeLabel.Location = new System.Drawing.Point(5, 25);
			this.circleLatitudeLabel.Name = "circleLatitudeLabel";
			this.circleLatitudeLabel.Size = new System.Drawing.Size(134, 13);
			this.circleLatitudeLabel.TabIndex = 0;
			this.circleLatitudeLabel.Text = "Latitude (decimal degrees):";
			// 
			// lineGroupBox
			// 
			this.lineGroupBox.Controls.Add(this.lineBearingTypeComboBox);
			this.lineGroupBox.Controls.Add(this.lineBearingLabel);
			this.lineGroupBox.Controls.Add(this.lineBearingTextBox);
			this.lineGroupBox.Controls.Add(this.lineWidthTextBox);
			this.lineGroupBox.Controls.Add(this.lineWidthLabel);
			this.lineGroupBox.Controls.Add(this.lineLongitudeTextBox);
			this.lineGroupBox.Controls.Add(this.lineLongitudeLabel);
			this.lineGroupBox.Controls.Add(this.lineLatitudeTextBox);
			this.lineGroupBox.Controls.Add(this.lineLatitudeLabel);
			this.lineGroupBox.Location = new System.Drawing.Point(11, 216);
			this.lineGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.lineGroupBox.Name = "lineGroupBox";
			this.lineGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.lineGroupBox.Size = new System.Drawing.Size(262, 205);
			this.lineGroupBox.TabIndex = 5;
			this.lineGroupBox.TabStop = false;
			this.lineGroupBox.Text = "Line properties";
			this.lineGroupBox.Visible = false;
			// 
			// lineBearingTypeComboBox
			// 
			this.lineBearingTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.lineBearingTypeComboBox.FormattingEnabled = true;
			this.lineBearingTypeComboBox.Items.AddRange(new object[] {
            "Default (clockwise from north)",
            "Adobe (anti-clockwise from east)"});
			this.lineBearingTypeComboBox.Location = new System.Drawing.Point(75, 173);
			this.lineBearingTypeComboBox.Name = "lineBearingTypeComboBox";
			this.lineBearingTypeComboBox.Size = new System.Drawing.Size(180, 21);
			this.lineBearingTypeComboBox.TabIndex = 8;
			this.lineBearingTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.lineBearingTypeComboBox_SelectedIndexChanged);
			// 
			// lineBearingLabel
			// 
			this.lineBearingLabel.AutoSize = true;
			this.lineBearingLabel.Location = new System.Drawing.Point(6, 157);
			this.lineBearingLabel.Name = "lineBearingLabel";
			this.lineBearingLabel.Size = new System.Drawing.Size(93, 13);
			this.lineBearingLabel.TabIndex = 6;
			this.lineBearingLabel.Text = "Bearing (degrees):";
			// 
			// lineBearingTextBox
			// 
			this.lineBearingTextBox.Location = new System.Drawing.Point(9, 174);
			this.lineBearingTextBox.Name = "lineBearingTextBox";
			this.lineBearingTextBox.Size = new System.Drawing.Size(60, 20);
			this.lineBearingTextBox.TabIndex = 7;
			this.lineBearingTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.lineBearingTextBox_Validating);
			// 
			// lineWidthTextBox
			// 
			this.lineWidthTextBox.Location = new System.Drawing.Point(9, 129);
			this.lineWidthTextBox.Name = "lineWidthTextBox";
			this.lineWidthTextBox.Size = new System.Drawing.Size(60, 20);
			this.lineWidthTextBox.TabIndex = 5;
			this.lineWidthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.lineWidthTextBox_Validating);
			// 
			// lineWidthLabel
			// 
			this.lineWidthLabel.AutoSize = true;
			this.lineWidthLabel.Location = new System.Drawing.Point(5, 114);
			this.lineWidthLabel.Name = "lineWidthLabel";
			this.lineWidthLabel.Size = new System.Drawing.Size(78, 13);
			this.lineWidthLabel.TabIndex = 4;
			this.lineWidthLabel.Text = "Width (metres):";
			// 
			// lineLongitudeTextBox
			// 
			this.lineLongitudeTextBox.Location = new System.Drawing.Point(9, 85);
			this.lineLongitudeTextBox.Name = "lineLongitudeTextBox";
			this.lineLongitudeTextBox.Size = new System.Drawing.Size(94, 20);
			this.lineLongitudeTextBox.TabIndex = 3;
			this.lineLongitudeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.lineLongitudeTextBox_Validating);
			// 
			// lineLongitudeLabel
			// 
			this.lineLongitudeLabel.AutoSize = true;
			this.lineLongitudeLabel.Location = new System.Drawing.Point(5, 70);
			this.lineLongitudeLabel.Name = "lineLongitudeLabel";
			this.lineLongitudeLabel.Size = new System.Drawing.Size(143, 13);
			this.lineLongitudeLabel.TabIndex = 2;
			this.lineLongitudeLabel.Text = "Longitude (decimal degrees):";
			// 
			// lineLatitudeTextBox
			// 
			this.lineLatitudeTextBox.Location = new System.Drawing.Point(9, 42);
			this.lineLatitudeTextBox.Name = "lineLatitudeTextBox";
			this.lineLatitudeTextBox.Size = new System.Drawing.Size(94, 20);
			this.lineLatitudeTextBox.TabIndex = 1;
			this.lineLatitudeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.lineLatitudeTextBox_Validating);
			// 
			// lineLatitudeLabel
			// 
			this.lineLatitudeLabel.AutoSize = true;
			this.lineLatitudeLabel.Location = new System.Drawing.Point(5, 25);
			this.lineLatitudeLabel.Name = "lineLatitudeLabel";
			this.lineLatitudeLabel.Size = new System.Drawing.Size(134, 13);
			this.lineLatitudeLabel.TabIndex = 0;
			this.lineLatitudeLabel.Text = "Latitude (decimal degrees):";
			// 
			// polygonGroupBox
			// 
			this.polygonGroupBox.Controls.Add(this.polygonDataGridView);
			this.polygonGroupBox.Location = new System.Drawing.Point(11, 216);
			this.polygonGroupBox.Margin = new System.Windows.Forms.Padding(2);
			this.polygonGroupBox.Name = "polygonGroupBox";
			this.polygonGroupBox.Padding = new System.Windows.Forms.Padding(2);
			this.polygonGroupBox.Size = new System.Drawing.Size(262, 205);
			this.polygonGroupBox.TabIndex = 11;
			this.polygonGroupBox.TabStop = false;
			this.polygonGroupBox.Text = "Polygon";
			this.polygonGroupBox.Visible = false;
			// 
			// polygonDataGridView
			// 
			this.polygonDataGridView.AllowUserToAddRows = false;
			this.polygonDataGridView.AllowUserToDeleteRows = false;
			this.polygonDataGridView.AllowUserToResizeRows = false;
			this.polygonDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.polygonDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.polygonDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.polygonDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.polygonDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.polygonDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.polygonDataGridView.ColumnHeadersHeight = 22;
			this.polygonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.polygonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Latitude,
            this.Longitude});
			this.polygonDataGridView.Location = new System.Drawing.Point(11, 20);
			this.polygonDataGridView.Margin = new System.Windows.Forms.Padding(2);
			this.polygonDataGridView.MultiSelect = false;
			this.polygonDataGridView.Name = "polygonDataGridView";
			this.polygonDataGridView.RowHeadersVisible = false;
			this.polygonDataGridView.RowTemplate.Height = 28;
			this.polygonDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.polygonDataGridView.Size = new System.Drawing.Size(239, 170);
			this.polygonDataGridView.TabIndex = 0;
			this.polygonDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.polygonDataGridView_CellValidating);
			// 
			// No
			// 
			this.No.HeaderText = "No";
			this.No.Name = "No";
			this.No.ReadOnly = true;
			// 
			// Latitude
			// 
			this.Latitude.HeaderText = "Latitude";
			this.Latitude.Name = "Latitude";
			// 
			// Longitude
			// 
			this.Longitude.HeaderText = "Longitude";
			this.Longitude.Name = "Longitude";
			// 
			// upperAltitudeTextBox
			// 
			this.upperAltitudeTextBox.Location = new System.Drawing.Point(11, 490);
			this.upperAltitudeTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.upperAltitudeTextBox.Name = "upperAltitudeTextBox";
			this.upperAltitudeTextBox.Size = new System.Drawing.Size(61, 20);
			this.upperAltitudeTextBox.TabIndex = 8;
			this.upperAltitudeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.upperAltitudeTextBox_Validating);
			// 
			// upperAltitudeLabel
			// 
			this.upperAltitudeLabel.AutoSize = true;
			this.upperAltitudeLabel.Location = new System.Drawing.Point(8, 475);
			this.upperAltitudeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.upperAltitudeLabel.Name = "upperAltitudeLabel";
			this.upperAltitudeLabel.Size = new System.Drawing.Size(228, 13);
			this.upperAltitudeLabel.TabIndex = 7;
			this.upperAltitudeLabel.Text = "Upper Altitude (metres, leave blank for no limit):";
			// 
			// lowerAltitudeTextBox
			// 
			this.lowerAltitudeTextBox.Location = new System.Drawing.Point(11, 447);
			this.lowerAltitudeTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.lowerAltitudeTextBox.Name = "lowerAltitudeTextBox";
			this.lowerAltitudeTextBox.Size = new System.Drawing.Size(61, 20);
			this.lowerAltitudeTextBox.TabIndex = 6;
			this.lowerAltitudeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.lowerAltitudeTextBox_Validating);
			// 
			// lowerAltitudeLabel
			// 
			this.lowerAltitudeLabel.AutoSize = true;
			this.lowerAltitudeLabel.Location = new System.Drawing.Point(8, 432);
			this.lowerAltitudeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lowerAltitudeLabel.Name = "lowerAltitudeLabel";
			this.lowerAltitudeLabel.Size = new System.Drawing.Size(254, 13);
			this.lowerAltitudeLabel.TabIndex = 5;
			this.lowerAltitudeLabel.Text = "Lower Altitude (metres, leave blank for ground level):";
			// 
			// featureMap
			// 
			this.featureMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.featureMap.Location = new System.Drawing.Point(286, 120);
			this.featureMap.Name = "featureMap";
			this.featureMap.Size = new System.Drawing.Size(488, 396);
			this.featureMap.TabIndex = 9;
			this.featureMap.MapInitialized += new System.EventHandler(this.featureMap_MapInitialized);
			this.featureMap.MapClicked += new System.EventHandler<ColinBaker.Pesto.UI.MapClickedEventArgs>(this.featureMap_MapClicked);
			// 
			// AddEditFeatureForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 517);
			this.Controls.Add(this.upperAltitudeTextBox);
			this.Controls.Add(this.upperAltitudeLabel);
			this.Controls.Add(this.lowerAltitudeTextBox);
			this.Controls.Add(this.lowerAltitudeLabel);
			this.Controls.Add(this.shapeComboBox);
			this.Controls.Add(this.shapeLabel);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.featureMap);
			this.Controls.Add(this.featureRibbon);
			this.Controls.Add(this.circleGroupBox);
			this.Controls.Add(this.polygonGroupBox);
			this.Controls.Add(this.lineGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddEditFeatureForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add / Edit Feature";
			this.Load += new System.EventHandler(this.AddEditFeatureForm_Load);
			this.circleGroupBox.ResumeLayout(false);
			this.circleGroupBox.PerformLayout();
			this.lineGroupBox.ResumeLayout(false);
			this.lineGroupBox.PerformLayout();
			this.polygonGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.polygonDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon featureRibbon;
        private System.Windows.Forms.RibbonTab featureRibbonTab;
        private System.Windows.Forms.RibbonPanel changesRibbonPanel;
        private System.Windows.Forms.RibbonButton saveRibbonButton;
        private System.Windows.Forms.RibbonButton cancelRibbonButton;
        private System.Windows.Forms.RibbonTab viewRibbonTab;
        private Map featureMap;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label shapeLabel;
        private System.Windows.Forms.ComboBox shapeComboBox;
        private System.Windows.Forms.GroupBox circleGroupBox;
        private System.Windows.Forms.TextBox circleRadiusTextBox;
        private System.Windows.Forms.Label circleRadiusLabel;
        private System.Windows.Forms.TextBox circleLongitudeTextBox;
        private System.Windows.Forms.Label circleLongitudeLabel;
        private System.Windows.Forms.TextBox circleLatitudeTextBox;
        private System.Windows.Forms.Label circleLatitudeLabel;
        private System.Windows.Forms.TextBox upperAltitudeTextBox;
        private System.Windows.Forms.Label upperAltitudeLabel;
        private System.Windows.Forms.TextBox lowerAltitudeTextBox;
        private System.Windows.Forms.Label lowerAltitudeLabel;
        private System.Windows.Forms.RibbonPanel mapRibbonPanel;
        private System.Windows.Forms.RibbonButton showMapRibbonButton;
        private System.Windows.Forms.RibbonButton zoomInRibbonButton;
        private System.Windows.Forms.RibbonButton zoomOutRibbonButton;
        private System.Windows.Forms.GroupBox lineGroupBox;
        private System.Windows.Forms.TextBox lineLongitudeTextBox;
        private System.Windows.Forms.Label lineLongitudeLabel;
        private System.Windows.Forms.TextBox lineLatitudeTextBox;
        private System.Windows.Forms.Label lineLatitudeLabel;
        private System.Windows.Forms.TextBox lineBearingTextBox;
        private System.Windows.Forms.Label lineBearingLabel;
        private System.Windows.Forms.TextBox lineWidthTextBox;
        private System.Windows.Forms.Label lineWidthLabel;
        private System.Windows.Forms.GroupBox polygonGroupBox;
        private System.Windows.Forms.DataGridView polygonDataGridView;
        private System.Windows.Forms.RibbonPanel polygonRibbonPanel;
        private System.Windows.Forms.RibbonButton addPolygonRibbonButton;
        private System.Windows.Forms.RibbonButton removePolygonRibbonButton;
        private System.Windows.Forms.RibbonButton removeAllPolygonRibbonButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
		private System.Windows.Forms.ComboBox lineBearingTypeComboBox;
	}
}