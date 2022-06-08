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
    internal partial class ImportFeaturesForm : Form
    {
        private const string m_featureTypeAirfield = "Airfield";
        private const string m_featureTypeDeck = "Deck";
        private const string m_featureTypeNoFlyZone = "No Fly Zone";
        private const string m_featureTypePoint = "Point";

        public ImportFeaturesForm(Geolocation.Files.Kml file, Models.Competition competition)
        {
            InitializeComponent();

            this.File = file;
            this.Competition = competition;
            this.ImportedFeatures = new List<Models.Features.Feature>();

            Populate();
        }

        public Geolocation.Files.Kml File { get; private set; }
        public Models.Competition Competition { get; private set; }
        public List<Models.Features.Feature> ImportedFeatures { get; private set; }

        private void Populate()
        {
            bool airfieldFeatureExists = false;

            foreach (Models.Features.Feature feature in this.Competition.Features)
            {
                if (feature.Type == Models.Features.Feature.FeatureType.Airfield)
                {
                    airfieldFeatureExists = true;
                }
            }

            foreach (Geolocation.Files.Placemark placemark in this.File.Placemarks)
            {
                object[] row = new object[3];

                row[0] = true;
                row[1] = placemark.Name;

                int rowIndex = featuresDataGridView.Rows.Add(row);

                DataGridViewComboBoxCell typeCell = featuresDataGridView.Rows[rowIndex].Cells["TypeColumn"] as DataGridViewComboBoxCell;

                switch (placemark.Geometry.Type)
                {
                    case Geolocation.Files.Geometry.GeometryType.Point:
                        typeCell.Items.Add(m_featureTypePoint);
                        typeCell.Items.Add(m_featureTypeNoFlyZone);
                        break;
                    case Geolocation.Files.Geometry.GeometryType.Polygon:
                        typeCell.Items.Add(m_featureTypeNoFlyZone);
                        typeCell.Items.Add(m_featureTypeDeck);
                        if (!airfieldFeatureExists)
                        {
                            typeCell.Items.Add(m_featureTypeAirfield);
                        }
                        break;
                }
                typeCell.Value = typeCell.Items[0];

                featuresDataGridView.Rows[rowIndex].Tag = placemark;
            }
        }

        private bool ValidateFeatures()
        {
            bool featuresSelected = false;

            foreach (DataGridViewRow row in featuresDataGridView.Rows)
            {
                if ((bool)row.Cells["SelectedColumn"].Value)
                {
                    featuresSelected = true;
                }
            }

            if (!featuresSelected)
            {
                MessageBox.Show("Please select some features to import.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private bool FeatureExists(string name)
        {
            bool exists = false;

            foreach (Models.Features.Feature feature in this.Competition.Features)
            {
                if (string.Compare(feature.Name, name, true) == 0)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateFeatures())
            {
                foreach (DataGridViewRow row in featuresDataGridView.Rows)
                {
                    if ((bool)row.Cells["SelectedColumn"].Value)
                    {
                        Geolocation.Files.Placemark placemark = (Geolocation.Files.Placemark)row.Tag;

                        string newFeatureName = placemark.Name;

                        // Ensure the feature has a unique name
                        if (FeatureExists(newFeatureName))
                        {
                            int copyCounter = 1;

                            do
                            {
                                copyCounter++;
                                newFeatureName = string.Format("{0} ({1})", placemark.Name, copyCounter);
                            } while (FeatureExists(newFeatureName));
                        }

                        Models.Features.Feature newFeature = null;

                        switch (row.Cells["TypeColumn"].Value as string)
                        {
                            case m_featureTypeAirfield:
                                Models.Features.Polygon airfieldPolygon = new Models.Features.Polygon();
                                airfieldPolygon.Vertices = new System.Collections.ObjectModel.Collection<Geolocation.Location>((placemark.Geometry as Geolocation.Files.Polygon).Vertices);
                                newFeature = new Models.Features.AirfieldFeature(newFeatureName, airfieldPolygon);
                                break;

                            case m_featureTypeDeck:
                                Models.Features.Polygon deckPolygon = new Models.Features.Polygon();
                                deckPolygon.Vertices = new System.Collections.ObjectModel.Collection<Geolocation.Location>((placemark.Geometry as Geolocation.Files.Polygon).Vertices);
                                newFeature = new Models.Features.DeckFeature(newFeatureName, deckPolygon);
                                break;

                            case m_featureTypeNoFlyZone:
                                switch (placemark.Geometry.Type)
                                {
                                    case Geolocation.Files.Geometry.GeometryType.Point:
                                        Models.Features.Circle nfzCircle = new Models.Features.Circle();
                                        nfzCircle.Center = (placemark.Geometry as Geolocation.Files.Point).Coordinates;
                                        nfzCircle.Radius = this.Competition.DefaultPointRadius;
                                        newFeature = new Models.Features.NoFlyZoneFeature(newFeatureName, nfzCircle);
                                        break;
                                    case Geolocation.Files.Geometry.GeometryType.Polygon:
                                        Models.Features.Polygon nfzPolygon = new Models.Features.Polygon();
                                        nfzPolygon.Vertices = new System.Collections.ObjectModel.Collection<Geolocation.Location>((placemark.Geometry as Geolocation.Files.Polygon).Vertices);
                                        newFeature = new Models.Features.NoFlyZoneFeature(newFeatureName, nfzPolygon);
                                        break;
                                }
                                break;

                            case m_featureTypePoint:
                                Models.Features.Circle pointCircle = new Models.Features.Circle();
                                pointCircle.Center = (placemark.Geometry as Geolocation.Files.Point).Coordinates;
                                pointCircle.Radius = this.Competition.DefaultPointRadius;
                                newFeature = new Models.Features.PointFeature(newFeatureName, pointCircle);
                                break;
                        }

                        if (newFeature != null)
                        {
                            this.Competition.Features.Add(newFeature);
                            this.ImportedFeatures.Add(newFeature);
                        }
                    }
                }
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }

        private class FeatureType
        {
            public FeatureType(string name, Models.Features.Feature.FeatureType type)
            {
                this.Name = name;
                this.Type = type;
            }

            public string Name { get; set; }
            public Models.Features.Feature.FeatureType Type { get; set; }

            public override string ToString()
            {
                return this.Name;
            }
        }

        private void featuresDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Exception.Message);
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in featuresDataGridView.Rows)
            {
                row.Cells["SelectedColumn"].Value = true;
            }
        }

        private void selectNoneButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in featuresDataGridView.Rows)
            {
                row.Cells["SelectedColumn"].Value = false;
            }
        }
    }
}
