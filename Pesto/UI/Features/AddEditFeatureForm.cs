using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.Features
{
    internal partial class AddEditFeatureForm : Form
    {
        // Design time form size isn't being respected for some reason (due to the ribbon I think)
        private const int m_formHeight = 560;

        private Geolocation.Location m_initialMapLocation = null;
        private int m_initialMapZoom;

        private Models.Features.Feature.FeatureType m_type;

        public AddEditFeatureForm(Models.Features.Feature.FeatureType type, Models.Competition competition, Geolocation.Location initialMapLocation, int initialMapZoom, bool useInitialMapLocationCoordinates)
        {
            InitializeComponent();

            this.Competition = competition;

            m_initialMapLocation = initialMapLocation;
            m_initialMapZoom = initialMapZoom;

            m_type = type;

            switch (m_type)
            {
                case Models.Features.Feature.FeatureType.Gate:
                    this.Text = "New Gate";

                    if (useInitialMapLocationCoordinates && initialMapLocation != null)
                    {
                        lineLatitudeTextBox.Text = initialMapLocation.Latitude.ToString("#0.000000");
                        lineLongitudeTextBox.Text = initialMapLocation.Longitude.ToString("##0.000000");
                    }

                    lineWidthTextBox.Text = Models.Features.GateFeature.DefaultWidth.ToString();
                    lineBearingTextBox.Text = Models.Features.GateFeature.DefaultBearing.ToString("##0.0");

                    break;

                case Models.Features.Feature.FeatureType.NoFlyZone:
                    this.Text = "New No Fly Zone";

                    if (useInitialMapLocationCoordinates && initialMapLocation != null)
			        {
				        circleLatitudeTextBox.Text = initialMapLocation.Latitude.ToString("#0.000000");
				        circleLongitudeTextBox.Text = initialMapLocation.Longitude.ToString("##0.000000");
			        }

			        circleRadiusTextBox.Text = Models.Features.PointFeature.DefaultRadius.ToString();

                    break;

                case Models.Features.Feature.FeatureType.Point:
                    this.Text = "New Point";

                    if (useInitialMapLocationCoordinates && initialMapLocation != null)
			        {
				        circleLatitudeTextBox.Text = initialMapLocation.Latitude.ToString("#0.000000");
				        circleLongitudeTextBox.Text = initialMapLocation.Longitude.ToString("##0.000000");
			        }

			        circleRadiusTextBox.Text = Models.Features.PointFeature.DefaultRadius.ToString();

                    break;

                case Models.Features.Feature.FeatureType.Airfield:
                    this.Text = "New Airfield";

                    lowerAltitudeTextBox.Enabled = false;
                    upperAltitudeTextBox.Enabled = false;

                    break;

                case Models.Features.Feature.FeatureType.Deck:
                    this.Text = "New Deck";

                    lowerAltitudeTextBox.Enabled = false;
                    upperAltitudeTextBox.Enabled = false;

                    break;
            }

            PopulateShapeTypes();
        }

        public AddEditFeatureForm(Models.Features.Feature feature, Models.Competition competition)
        {
            InitializeComponent();

            this.OriginalFeatureName = feature.Name;
            this.Feature = feature;
            this.Competition = competition;

            m_type = this.Feature.Type;

            nameTextBox.Text = this.Feature.Name;

            switch (m_type)
            {
                case Models.Features.Feature.FeatureType.Gate:
                    this.Text = "Edit Gate";

                    Models.Features.GateFeature gate = this.Feature as Models.Features.GateFeature;
                    Models.Features.Line gateLine = gate.Shape as Models.Features.Line;

                    lineLatitudeTextBox.Text = gateLine.Center.Latitude.ToString("#0.000000");
                    lineLongitudeTextBox.Text = gateLine.Center.Longitude.ToString("##0.000000");
                    lineWidthTextBox.Text = gateLine.Width.ToString();
                    lineBearingTextBox.Text = gateLine.Bearing.ToString("##0.0");

                    if (gate.LowerAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        lowerAltitudeTextBox.Text = gate.LowerAltitude.ToString();
                    }
                    if (gate.UpperAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        upperAltitudeTextBox.Text = gate.UpperAltitude.ToString();
                    }

                    break;

                case Models.Features.Feature.FeatureType.NoFlyZone:
                    this.Text = "Edit No Fly Zone";

                    Models.Features.NoFlyZoneFeature nfz = this.Feature as Models.Features.NoFlyZoneFeature;

                    switch (nfz.Shape.Type)
                    {
                        case Models.Features.Shape.ShapeType.Circle:
                            Models.Features.Circle nfzCircle = nfz.Shape as Models.Features.Circle;

                            circleLatitudeTextBox.Text = nfzCircle.Center.Latitude.ToString("#0.000000");
                            circleLongitudeTextBox.Text = nfzCircle.Center.Longitude.ToString("##0.000000");
                            circleRadiusTextBox.Text = nfzCircle.Radius.ToString();
                            break;

                        case Models.Features.Shape.ShapeType.Polygon:
                            Models.Features.Polygon nfzPolygon = nfz.Shape as Models.Features.Polygon;

                            foreach (Geolocation.Location vertex in nfzPolygon.Vertices)
                            {
                                AddPolygonVertex(vertex);
                            }
                            break;
                    }

                    if (nfz.LowerAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        lowerAltitudeTextBox.Text = nfz.LowerAltitude.ToString();
                    }
                    if (nfz.UpperAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        upperAltitudeTextBox.Text = nfz.UpperAltitude.ToString();
                    }

                    break;

                case Models.Features.Feature.FeatureType.Point:
                    this.Text = "Edit Point";

                    Models.Features.PointFeature point = this.Feature as Models.Features.PointFeature;
                    Models.Features.Circle pointCircle = point.Shape as Models.Features.Circle;

			        circleLatitudeTextBox.Text = pointCircle.Center.Latitude.ToString("#0.000000");
			        circleLongitudeTextBox.Text = pointCircle.Center.Longitude.ToString("##0.000000");
			        circleRadiusTextBox.Text = pointCircle.Radius.ToString();

                    if (point.LowerAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        lowerAltitudeTextBox.Text = point.LowerAltitude.ToString();
                    }
                    if (point.UpperAltitude != Geolocation.Location.UnknownAltitude)
                    {
                        upperAltitudeTextBox.Text = point.UpperAltitude.ToString();
                    }

                    break;

                case Models.Features.Feature.FeatureType.Airfield:
                    this.Text = "Edit Airfield";

                    Models.Features.AirfieldFeature airfield = this.Feature as Models.Features.AirfieldFeature;
                    Models.Features.Polygon airfieldPolygon = airfield.Shape as Models.Features.Polygon;

                    foreach (Geolocation.Location vertex in airfieldPolygon.Vertices)
                    {
                        AddPolygonVertex(vertex);
                    }

                    lowerAltitudeTextBox.Enabled = false;
                    upperAltitudeTextBox.Enabled = false;

                    break;

                case Models.Features.Feature.FeatureType.Deck:
                    this.Text = "Edit Deck";

                    Models.Features.DeckFeature deck = this.Feature as Models.Features.DeckFeature;
                    Models.Features.Polygon deckPolygon = deck.Shape as Models.Features.Polygon;

                    foreach (Geolocation.Location vertex in deckPolygon.Vertices)
                    {
                        AddPolygonVertex(vertex);
                    }

                    lowerAltitudeTextBox.Enabled = false;
                    upperAltitudeTextBox.Enabled = false;

                    break;
            }

            PopulateShapeTypes();
        }

        public string OriginalFeatureName { get; private set; }
        public Models.Features.Feature Feature { get; private set; }
        public Models.Competition Competition { get; private set; }

        #region Map

        private void ShowMap()
        {
            featureMap.Visible = true;

            // Create a temporary feature in order to display map

            Models.Features.Feature temporaryFeature = CreateFeature();

            if (temporaryFeature != null)
            {
                AddFeatureToMap(temporaryFeature);
            }

            RefreshControlState();
        }

        private void HideMap()
        {
            featureMap.Visible = false;

            ClearMap();
        }

        private void ClearMap()
        {
            featureMap.Clear();

            RefreshControlState();
        }

        private void AddFeatureToMap(Models.Features.Feature feature)
        {
            if (featureMap.Visible)
            {
                featureMap.AddFeature(feature);
            }
        }

        #endregion

        private void PopulateShapeTypes()
        {
            switch (m_type)
            {
                case Models.Features.Feature.FeatureType.Gate:
                    shapeComboBox.Items.Add(new ShapeListItem(Models.Features.Shape.ShapeType.Line));
                    SelectShapeType(Models.Features.Shape.ShapeType.Line);
                    break;

                case Models.Features.Feature.FeatureType.NoFlyZone:
                    shapeComboBox.Items.Add(new ShapeListItem(Models.Features.Shape.ShapeType.Circle));
                    shapeComboBox.Items.Add(new ShapeListItem(Models.Features.Shape.ShapeType.Polygon));
                    if (this.Feature != null)
                    {
                        Models.Features.NoFlyZoneFeature nfz = this.Feature as Models.Features.NoFlyZoneFeature;
                        SelectShapeType(nfz.Shape.Type);
                    }
                    else
                    {
                        SelectShapeType(Models.Features.Shape.ShapeType.Circle);
                    }
                    break;

                case Models.Features.Feature.FeatureType.Point:
                    shapeComboBox.Items.Add(new ShapeListItem(Models.Features.Shape.ShapeType.Circle));
                    SelectShapeType(Models.Features.Shape.ShapeType.Circle);
                    break;

                case Models.Features.Feature.FeatureType.Airfield:
                    shapeComboBox.Items.Add(new ShapeListItem(Models.Features.Shape.ShapeType.Polygon));
                    SelectShapeType(Models.Features.Shape.ShapeType.Polygon);
                    break;

                case Models.Features.Feature.FeatureType.Deck:
                    shapeComboBox.Items.Add(new ShapeListItem(Models.Features.Shape.ShapeType.Polygon));
                    SelectShapeType(Models.Features.Shape.ShapeType.Polygon);
                    break;
            }

            if (shapeComboBox.Items.Count == 1)
            {
                shapeComboBox.Enabled = false;
            }
        }

        private void SelectShapeType(Models.Features.Shape.ShapeType type)
        {
            foreach (ShapeListItem item in shapeComboBox.Items)
            {
                if (item.Type == type)
                {
                    shapeComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void AddPolygonVertex(Geolocation.Location vertex)
        {
            object[] row = new object[5];

            row[0] = polygonDataGridView.Rows.Count + 1;
            if (vertex != null)
            {
                row[1] = vertex.Latitude.ToString("#0.000000");
                row[2] = vertex.Longitude.ToString("##0.000000");
            }

            int rowIndex = polygonDataGridView.Rows.Add(row);

            if (vertex == null)
            {
                polygonDataGridView.CurrentCell = polygonDataGridView.Rows[rowIndex].Cells["Latitude"];
                polygonDataGridView.BeginEdit(false);
            }
        }

        private Models.Features.Feature CreateFeature()
        {
            // Allows a partially defined feature to be created so that we can use it to create a temporary feature to display in the map

            Models.Features.Feature feature = null;

            switch (m_type)
            {
                case Models.Features.Feature.FeatureType.Gate:
                    if (!string.IsNullOrWhiteSpace(lineLatitudeTextBox.Text) && !string.IsNullOrWhiteSpace(lineLongitudeTextBox.Text) && !string.IsNullOrWhiteSpace(lineWidthTextBox.Text) && !string.IsNullOrWhiteSpace(lineBearingTextBox.Text))
                    {
                        Models.Features.GateFeature gate = new Models.Features.GateFeature(nameTextBox.Text);
                        gate.Shape = new Models.Features.Line(new Geolocation.Location(decimal.Parse(lineLatitudeTextBox.Text), decimal.Parse(lineLongitudeTextBox.Text)), int.Parse(lineWidthTextBox.Text), decimal.Parse(lineBearingTextBox.Text));

                        feature = gate;
                    }

                    break;

                case Models.Features.Feature.FeatureType.NoFlyZone:
                    Models.Features.NoFlyZoneFeature nfz = new Models.Features.NoFlyZoneFeature(nameTextBox.Text);

                    switch ((shapeComboBox.SelectedItem as ShapeListItem).Type)
                    {
                        case Models.Features.Shape.ShapeType.Circle:
                            if (!string.IsNullOrWhiteSpace(circleLatitudeTextBox.Text) && !string.IsNullOrWhiteSpace(circleLongitudeTextBox.Text) && !string.IsNullOrWhiteSpace(circleRadiusTextBox.Text))
                            {
                                nfz.Shape = new Models.Features.Circle(new Geolocation.Location(decimal.Parse(circleLatitudeTextBox.Text), decimal.Parse(circleLongitudeTextBox.Text)), int.Parse(circleRadiusTextBox.Text));
                            }
                            break;

                        case Models.Features.Shape.ShapeType.Polygon:
                            if (polygonDataGridView.Rows.Count > 0)
                            {
                                Models.Features.Polygon polygon = new Models.Features.Polygon();
                                foreach (DataGridViewRow row in polygonDataGridView.Rows)
                                {
                                    polygon.Vertices.Add(new Geolocation.Location(decimal.Parse(row.Cells["Latitude"].Value.ToString()), decimal.Parse(row.Cells["Longitude"].Value.ToString())));
                                }
                                nfz.Shape = polygon;
                            }
                            break;
                    }

                    if (!string.IsNullOrWhiteSpace(lowerAltitudeTextBox.Text))
                    {
                        nfz.LowerAltitude = int.Parse(lowerAltitudeTextBox.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(upperAltitudeTextBox.Text))
                    {
                        nfz.UpperAltitude = int.Parse(upperAltitudeTextBox.Text);
                    }

                    if (nfz.Shape != null)
                    {
                        feature = nfz;
                    }

                    break;

                case Models.Features.Feature.FeatureType.Point:
                    if (!string.IsNullOrWhiteSpace(circleLatitudeTextBox.Text) && !string.IsNullOrWhiteSpace(circleLongitudeTextBox.Text) && !string.IsNullOrWhiteSpace(circleRadiusTextBox.Text))
                    {
                        Models.Features.PointFeature point = new Models.Features.PointFeature(nameTextBox.Text);
                        point.Shape = new Models.Features.Circle(new Geolocation.Location(decimal.Parse(circleLatitudeTextBox.Text), decimal.Parse(circleLongitudeTextBox.Text)), int.Parse(circleRadiusTextBox.Text));

                        if (!string.IsNullOrWhiteSpace(lowerAltitudeTextBox.Text))
                        {
                            point.LowerAltitude = int.Parse(lowerAltitudeTextBox.Text);
                        }
                        if (!string.IsNullOrWhiteSpace(upperAltitudeTextBox.Text))
                        {
                            point.UpperAltitude = int.Parse(upperAltitudeTextBox.Text);
                        }

                        feature = point;
                    }

                    break;

                case Models.Features.Feature.FeatureType.Airfield:
                    Models.Features.AirfieldFeature airfield = new Models.Features.AirfieldFeature(nameTextBox.Text);

                    if (polygonDataGridView.Rows.Count > 0)
                    {
                        Models.Features.Polygon polygon = new Models.Features.Polygon();
                        foreach (DataGridViewRow row in polygonDataGridView.Rows)
                        {
                            polygon.Vertices.Add(new Geolocation.Location(decimal.Parse(row.Cells["Latitude"].Value.ToString()), decimal.Parse(row.Cells["Longitude"].Value.ToString())));
                        }
                        airfield.Shape = polygon;
                    }

                    if (airfield.Shape != null)
                    {
                        feature = airfield;
                    }

                    break;

                case Models.Features.Feature.FeatureType.Deck:
                    Models.Features.DeckFeature deck = new Models.Features.DeckFeature(nameTextBox.Text);

                    if (polygonDataGridView.Rows.Count > 0)
                    {
                        Models.Features.Polygon polygon = new Models.Features.Polygon();
                        foreach (DataGridViewRow row in polygonDataGridView.Rows)
                        {
                            polygon.Vertices.Add(new Geolocation.Location(decimal.Parse(row.Cells["Latitude"].Value.ToString()), decimal.Parse(row.Cells["Longitude"].Value.ToString())));
                        }
                        deck.Shape = polygon;
                    }

                    if (deck.Shape != null)
                    {
                        feature = deck;
                    }

                    break;
            }

            return feature;
        }

        private bool ValidateFeature()
        {
            if (!Validate())
            {
                return false;
            }

            if (nameTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a name.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nameTextBox.Focus();
                return false;
            }

            switch ((shapeComboBox.SelectedItem as ShapeListItem).Type)
            {
                case Models.Features.Shape.ShapeType.Circle:
                    if (String.IsNullOrWhiteSpace(circleLatitudeTextBox.Text))
			        {
				        MessageBox.Show("Please enter a latitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        circleLatitudeTextBox.Focus();
                        return false;
			        }

			        if (String.IsNullOrWhiteSpace(circleLongitudeTextBox.Text))
			        {
				        MessageBox.Show("Please enter a valid longitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        circleLongitudeTextBox.Focus();
                        return false;
			        }

			        if (String.IsNullOrWhiteSpace(circleRadiusTextBox.Text))
			        {
				        MessageBox.Show("Please enter a valid radius.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        circleRadiusTextBox.Focus();
                        return false;
			        }

                    break;

                case Models.Features.Shape.ShapeType.Line:
                    if (String.IsNullOrWhiteSpace(lineLatitudeTextBox.Text))
			        {
				        MessageBox.Show("Please enter a latitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lineLatitudeTextBox.Focus();
                        return false;
			        }

			        if (String.IsNullOrWhiteSpace(lineLongitudeTextBox.Text))
			        {
				        MessageBox.Show("Please enter a valid longitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lineLongitudeTextBox.Focus();
                        return false;
			        }

			        if (String.IsNullOrWhiteSpace(lineWidthTextBox.Text))
			        {
				        MessageBox.Show("Please enter a valid width.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lineWidthTextBox.Focus();
                        return false;
			        }

                    if (String.IsNullOrWhiteSpace(lineBearingTextBox.Text))
                    {
                        MessageBox.Show("Please enter a valid bearing.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lineBearingTextBox.Focus();
                        return false;
                    }

                    break;

                case Models.Features.Shape.ShapeType.Polygon:
                    if (polygonDataGridView.Rows.Count < 3)
                    {
                        MessageBox.Show("Please add at least 3 points.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        polygonDataGridView.Focus();
                        return false;
                    }

                    break;
            }

            if (m_type == Models.Features.Feature.FeatureType.Point || m_type == Models.Features.Feature.FeatureType.Gate || m_type == Models.Features.Feature.FeatureType.NoFlyZone)
            {
                if (!string.IsNullOrWhiteSpace(lowerAltitudeTextBox.Text) && !string.IsNullOrWhiteSpace(upperAltitudeTextBox.Text))
                {
                    int lowerAltitude = int.Parse(lowerAltitudeTextBox.Text);
                    int upperAltitude = int.Parse(upperAltitudeTextBox.Text);

                    if (upperAltitude <= lowerAltitude)
                    {
                        MessageBox.Show("Upper altitude must be greater than lower altitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        upperAltitudeTextBox.Focus();
                        return false;
                    }
                }
            }

            // Check that a feature with this name does not already exist
            foreach (Models.Features.Feature existingFeature in this.Competition.Features)
            {
                if (this.Feature == null || existingFeature != this.Feature)
                {
                    if (string.Compare(existingFeature.Name, nameTextBox.Text, true) == 0)
                    {
                        MessageBox.Show("A feature with this name already exists.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        nameTextBox.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void RefreshControlState()
        {
            Models.Features.Shape.ShapeType shapeType = (shapeComboBox.SelectedItem as ShapeListItem).Type;

            addPolygonRibbonButton.Enabled = (shapeType == Models.Features.Shape.ShapeType.Polygon);
            removePolygonRibbonButton.Enabled = (shapeType == Models.Features.Shape.ShapeType.Polygon) && polygonDataGridView.Rows.Count > 0;
            removeAllPolygonRibbonButton.Enabled = (shapeType == Models.Features.Shape.ShapeType.Polygon) && polygonDataGridView.Rows.Count > 0;

            zoomInRibbonButton.Enabled = featureMap.Visible;
            zoomOutRibbonButton.Enabled = featureMap.Visible;
        }

        private void AddEditFeatureForm_Load(object sender, EventArgs e)
        {
            this.Height = m_formHeight;
        }

        private void saveRibbonButton_Click(object sender, EventArgs e)
        {
            if (ValidateFeature())
            {
                if (this.Feature == null)
                {
                    // Add new feature

                    this.Feature = CreateFeature();
                    this.Competition.Features.Add(this.Feature);
                }
                else
                {
                    // Update existing feature

                    this.Feature.Name = nameTextBox.Text;

                    switch (m_type)
                    {
                        case Models.Features.Feature.FeatureType.Gate:
                            Models.Features.GateFeature existingGate = this.Feature as Models.Features.GateFeature;

                            existingGate.Shape = new Models.Features.Line(new Geolocation.Location(decimal.Parse(lineLatitudeTextBox.Text), decimal.Parse(lineLongitudeTextBox.Text)), int.Parse(lineWidthTextBox.Text), decimal.Parse(lineBearingTextBox.Text));

                            if (!string.IsNullOrWhiteSpace(lowerAltitudeTextBox.Text))
                            {
                                existingGate.LowerAltitude = int.Parse(lowerAltitudeTextBox.Text);
                            }
                            else
                            {
                                existingGate.LowerAltitude = Geolocation.Location.UnknownAltitude;
                            }
                            if (!string.IsNullOrWhiteSpace(upperAltitudeTextBox.Text))
                            {
                                existingGate.UpperAltitude = int.Parse(upperAltitudeTextBox.Text);
                            }
                            else
                            {
                                existingGate.UpperAltitude = Geolocation.Location.UnknownAltitude;
                            }

                            break;

                        case Models.Features.Feature.FeatureType.NoFlyZone:
                            Models.Features.NoFlyZoneFeature existingNfz = this.Feature as Models.Features.NoFlyZoneFeature;

                            switch ((shapeComboBox.SelectedItem as ShapeListItem).Type)
                            {
                                case Models.Features.Shape.ShapeType.Circle:
                                    existingNfz.Shape = new Models.Features.Circle(new Geolocation.Location(decimal.Parse(circleLatitudeTextBox.Text), decimal.Parse(circleLongitudeTextBox.Text)), int.Parse(circleRadiusTextBox.Text));
                                    break;

                                case Models.Features.Shape.ShapeType.Polygon:
                                    Models.Features.Polygon nfzPolygon = new Models.Features.Polygon();
                                    foreach (DataGridViewRow row in polygonDataGridView.Rows)
                                    {
                                        nfzPolygon.Vertices.Add(new Geolocation.Location(decimal.Parse(row.Cells["Latitude"].Value.ToString()), decimal.Parse(row.Cells["Longitude"].Value.ToString())));
                                    }
                                    existingNfz.Shape = nfzPolygon;
                                    break;
                            }

                            if (!string.IsNullOrWhiteSpace(lowerAltitudeTextBox.Text))
                            {
                                existingNfz.LowerAltitude = int.Parse(lowerAltitudeTextBox.Text);
                            }
                            else
                            {
                                existingNfz.LowerAltitude = Geolocation.Location.UnknownAltitude;
                            }
                            if (!string.IsNullOrWhiteSpace(upperAltitudeTextBox.Text))
                            {
                                existingNfz.UpperAltitude = int.Parse(upperAltitudeTextBox.Text);
                            }
                            else
                            {
                                existingNfz.UpperAltitude = Geolocation.Location.UnknownAltitude;
                            }

                            break;

                        case Models.Features.Feature.FeatureType.Point:
                            Models.Features.PointFeature existingPoint = this.Feature as Models.Features.PointFeature;

                            existingPoint.Shape = new Models.Features.Circle(new Geolocation.Location(decimal.Parse(circleLatitudeTextBox.Text), decimal.Parse(circleLongitudeTextBox.Text)), int.Parse(circleRadiusTextBox.Text));

                            if (!string.IsNullOrWhiteSpace(lowerAltitudeTextBox.Text))
                            {
                                existingPoint.LowerAltitude = int.Parse(lowerAltitudeTextBox.Text);
                            }
                            else
                            {
                                existingPoint.LowerAltitude = Geolocation.Location.UnknownAltitude;
                            }
                            if (!string.IsNullOrWhiteSpace(upperAltitudeTextBox.Text))
                            {
                                existingPoint.UpperAltitude = int.Parse(upperAltitudeTextBox.Text);
                            }
                            else
                            {
                                existingPoint.UpperAltitude = Geolocation.Location.UnknownAltitude;
                            }

                            break;

                        case Models.Features.Feature.FeatureType.Airfield:
                            Models.Features.AirfieldFeature existingAirfield = this.Feature as Models.Features.AirfieldFeature;

                            Models.Features.Polygon airfieldPolygon = new Models.Features.Polygon();
                            foreach (DataGridViewRow row in polygonDataGridView.Rows)
                            {
                                airfieldPolygon.Vertices.Add(new Geolocation.Location(decimal.Parse(row.Cells["Latitude"].Value.ToString()), decimal.Parse(row.Cells["Longitude"].Value.ToString())));
                            }
                            existingAirfield.Shape = airfieldPolygon;

                            break;

                        case Models.Features.Feature.FeatureType.Deck:
                            Models.Features.DeckFeature existingDeck = this.Feature as Models.Features.DeckFeature;

                            Models.Features.Polygon deckPolygon = new Models.Features.Polygon();
                            foreach (DataGridViewRow row in polygonDataGridView.Rows)
                            {
                                deckPolygon.Vertices.Add(new Geolocation.Location(decimal.Parse(row.Cells["Latitude"].Value.ToString()), decimal.Parse(row.Cells["Longitude"].Value.ToString())));
                            }
                            existingDeck.Shape = deckPolygon;

                            break;
                    }
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancelRibbonButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void shapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            circleGroupBox.Visible = false;
            lineGroupBox.Visible = false;
            polygonGroupBox.Visible = false;

            switch ((shapeComboBox.SelectedItem as ShapeListItem).Type)
            {
                case Models.Features.Shape.ShapeType.Circle:
                    circleGroupBox.Visible = true;
                    break;

                case Models.Features.Shape.ShapeType.Line:
                    lineGroupBox.Visible = true;
                    break;

                case Models.Features.Shape.ShapeType.Polygon:
                    polygonGroupBox.Visible = true;
                    break;
            }

            ClearMap();
            ShowMap();
        }

        private void showMapRibbonButton_Click(object sender, EventArgs e)
        {
            if (showMapRibbonButton.Checked)
            {
                ShowMap();
            }
            else
            {
                HideMap();
            }
        }

        private void zoomInRibbonButton_Click(object sender, EventArgs e)
        {
            featureMap.ZoomIn();
        }

        private void zoomOutRibbonButton_Click(object sender, EventArgs e)
        {
            featureMap.ZoomOut();
        }

        private void featureMap_MapInitialized(object sender, EventArgs e)
        {
            ShowMap();

            if (this.Feature != null)
            {
                featureMap.AutoFit();
            }
            else
            {
                if (m_initialMapLocation != null)
                {
                    featureMap.CenterLocation = m_initialMapLocation;
                    featureMap.Zoom = m_initialMapZoom;
                }
            }
        }

        private void featureMap_MapClicked(object sender, MapClickedEventArgs e)
        {
            ShapeListItem selectedShape = shapeComboBox.SelectedItem as ShapeListItem;

            switch (selectedShape.Type)
            {
                case Models.Features.Shape.ShapeType.Circle:
                    circleLatitudeTextBox.Text = e.Location.Latitude.ToString("#0.000000");
                    circleLongitudeTextBox.Text = e.Location.Longitude.ToString("##0.000000");
                    break;

				case Models.Features.Shape.ShapeType.Line:
					lineLatitudeTextBox.Text = e.Location.Latitude.ToString("#0.000000");
					lineLongitudeTextBox.Text = e.Location.Longitude.ToString("#0.000000");
					break;

				case Models.Features.Shape.ShapeType.Polygon:
                    AddPolygonVertex(new Geolocation.Location(e.Location.Latitude, e.Location.Longitude));
                    break;
            }

            ClearMap();
            ShowMap();
        }

        private void circleLatitudeTextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal latitude;

            if (circleLatitudeTextBox.Text.Length > 0)
            {
                if (!decimal.TryParse(circleLatitudeTextBox.Text, out latitude))
                {
                    MessageBox.Show("Please enter a valid latitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else
                {
                    ClearMap();
                    ShowMap();
                }
            }
            else
            {
                ClearMap();
            }
        }

        private void circleLongitudeTextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal longitude;

            if (circleLongitudeTextBox.Text.Length > 0)
            {
                if (!decimal.TryParse(circleLongitudeTextBox.Text, out longitude))
                {
                    MessageBox.Show("Please enter a valid longitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else
                {
                    ClearMap();
                    ShowMap();
                }
            }
            else
            {
                ClearMap();
            }
        }

        private void circleRadiusTextBox_Validating(object sender, CancelEventArgs e)
        {
            int radius;

            if (circleRadiusTextBox.Text.Length > 0)
            {
                if (!int.TryParse(circleRadiusTextBox.Text, out radius))
                {
                    MessageBox.Show("Please enter a valid radius.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else
                {
                    ClearMap();
                    ShowMap();
                }
            }
            else
            {
                ClearMap();
            }
        }

        private void lowerAltitudeTextBox_Validating(object sender, CancelEventArgs e)
        {
            int lowerAltitude;

            if (lowerAltitudeTextBox.Text.Length > 0)
            {
                if (!int.TryParse(lowerAltitudeTextBox.Text, out lowerAltitude))
                {
                    MessageBox.Show("Please enter a valid lower altitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }

        private void upperAltitudeTextBox_Validating(object sender, CancelEventArgs e)
        {
            int upperAltitude;

            if (upperAltitudeTextBox.Text.Length > 0)
            {
                if (!int.TryParse(upperAltitudeTextBox.Text, out upperAltitude))
                {
                    MessageBox.Show("Please enter a valid upper altitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }

        private void lineLatitudeTextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal latitude;

            if (lineLatitudeTextBox.Text.Length > 0)
            {
                if (!decimal.TryParse(lineLatitudeTextBox.Text, out latitude))
                {
                    MessageBox.Show("Please enter a valid latitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else
                {
                    ClearMap();
                    ShowMap();
                }
            }
            else
            {
                ClearMap();
            }
        }

        private void lineLongitudeTextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal longitude;

            if (lineLongitudeTextBox.Text.Length > 0)
            {
                if (!decimal.TryParse(lineLongitudeTextBox.Text, out longitude))
                {
                    MessageBox.Show("Please enter a valid longitude.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else
                {
                    ClearMap();
                    ShowMap();
                }
            }
            else
            {
                ClearMap();
            }
        }

        private void lineWidthTextBox_Validating(object sender, CancelEventArgs e)
        {
            int width;

            if (lineWidthTextBox.Text.Length > 0)
            {
                if (!int.TryParse(lineWidthTextBox.Text, out width))
                {
                    MessageBox.Show("Please enter a valid width.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else
                {
                    ClearMap();
                    ShowMap();
                }
            }
            else
            {
                ClearMap();
            }
        }

        private void lineBearingTextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal bearing;

            if (lineBearingTextBox.Text.Length > 0)
            {
                if (!decimal.TryParse(lineBearingTextBox.Text, out bearing))
                {
                    MessageBox.Show("Please enter a valid bearing.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else
                {
                    ClearMap();
                    ShowMap();
                }
            }
            else
            {
                ClearMap();
            }
        }

        private void addPolygonRibbonButton_Click(object sender, EventArgs e)
        {
            AddPolygonVertex(null);
        }

        private void removePolygonRibbonButton_Click(object sender, EventArgs e)
        {
            polygonDataGridView.Rows.RemoveAt(polygonDataGridView.Rows.Count - 1);

            ClearMap();
            ShowMap();
        }

        private void removeAllPolygonRibbonButton_Click(object sender, EventArgs e)
        {
            polygonDataGridView.Rows.Clear();

            ClearMap();
            ShowMap();
        }

        private void polygonDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal latitude;
            decimal longitude;

            switch (polygonDataGridView.Columns[e.ColumnIndex].Name)
            {
                case "Latitude":
                    if (!decimal.TryParse(e.FormattedValue.ToString(), out latitude))
                    {
                        MessageBox.Show("Please enter a valid latitude", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                    break;

                case "Longitude":
                    if (!decimal.TryParse(e.FormattedValue.ToString(), out longitude))
                    {
                        MessageBox.Show("Please enter a valid longitude", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                    break;
            }
        }
    }
}
