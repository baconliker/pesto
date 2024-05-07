using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.Features
{
	internal partial class FeatureDefinitionForm : Form
	{
		private Geolocation.Location m_rightClickLocation = null;

		public FeatureDefinitionForm(Models.Competition competition)
		{
			InitializeComponent();

			this.Competition = competition;
		}

		public Models.Competition Competition { get; private set; }

        private async Task AddFeatureAsync(Models.Features.Feature.FeatureType type, Geolocation.Location location, bool useLocationCoordinates)
        {
			using (AddEditFeatureForm form = new AddEditFeatureForm(type, this.Competition, location, await featuresMap.GetZoomAsync(), useLocationCoordinates))
			{
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FeatureTreeNode groupNode = null;

                    switch (type)
                    {
                        case Models.Features.Feature.FeatureType.Gate:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.GatesGroup);
                            break;
                        case Models.Features.Feature.FeatureType.NoFlyZone:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.NoFlyZonesGroup);
                            break;
                        case Models.Features.Feature.FeatureType.Point:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.PointsGroup);
                            break;
                        case Models.Features.Feature.FeatureType.Airfield:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.AirfieldGroup);
                            break;
                        case Models.Features.Feature.FeatureType.Deck:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.DecksGroup);
                            break;
						case Models.Features.Feature.FeatureType.PointOfInterest:
							groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.PointsOfInterestGroup);
							break;
					}

                    AddFeatureToTree(form.Feature, groupNode);
                    await AddFeatureToMapAsync(form.Feature);
                }
            }
        }

		private async Task EditFeatureAsync(Models.Features.Feature feature)
		{
            string oldFeatureName = feature.Name;

            using (AddEditFeatureForm form = new AddEditFeatureForm(feature, this.Competition))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FeatureTreeNode groupNode = null;

                    switch (feature.Type)
                    {
                        case Models.Features.Feature.FeatureType.Gate:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.GatesGroup);
                            break;
                        case Models.Features.Feature.FeatureType.NoFlyZone:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.NoFlyZonesGroup);
                            break;
                        case Models.Features.Feature.FeatureType.Point:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.PointsGroup);
                            break;
                        case Models.Features.Feature.FeatureType.Airfield:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.AirfieldGroup);
                            break;
                        case Models.Features.Feature.FeatureType.Deck:
                            groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.DecksGroup);
                            break;
						case Models.Features.Feature.FeatureType.PointOfInterest:
							groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.PointsOfInterestGroup);
							break;
					}

                    foreach (FeatureTreeNode featureNode in groupNode.Nodes)
                    {
                        if (featureNode.Feature == feature)
                        {
                            featureNode.Text = FeatureTreeNode.BuildText(featureNode.Type, featureNode.Feature);

							await RemoveFeatureFromMapAsync(oldFeatureName);
							await AddFeatureToMapAsync(feature);

                            break;
                        }
                    }
                }
            }
		}

		#region Tree

		private void PopulateFeaturesTree()
		{
			FeatureTreeNode groupNode;

            featuresTreeView.BeginUpdate();

            featuresTreeView.Nodes.Clear();

			groupNode = new FeatureTreeNode(FeatureTreeNode.BuildText(FeatureTreeNode.FeatureTreeNodeType.NoFlyZonesGroup), FeatureTreeNode.FeatureTreeNodeType.NoFlyZonesGroup);
			featuresTreeView.Nodes.Add(groupNode);

			foreach (Models.Features.Feature feature in this.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.NoFlyZone)
				{
					AddFeatureToTree(feature, groupNode);
				}
			}

			groupNode = new FeatureTreeNode(FeatureTreeNode.BuildText(FeatureTreeNode.FeatureTreeNodeType.AirfieldGroup), FeatureTreeNode.FeatureTreeNodeType.AirfieldGroup);
			featuresTreeView.Nodes.Add(groupNode);

            foreach (Models.Features.Feature feature in this.Competition.Features)
            {
                if (feature.Type == Models.Features.Feature.FeatureType.Airfield)
                {
                    AddFeatureToTree(feature, groupNode);
                }
            }

            groupNode = new FeatureTreeNode(FeatureTreeNode.BuildText(FeatureTreeNode.FeatureTreeNodeType.DecksGroup), FeatureTreeNode.FeatureTreeNodeType.DecksGroup);
			featuresTreeView.Nodes.Add(groupNode);

            foreach (Models.Features.Feature feature in this.Competition.Features)
            {
                if (feature.Type == Models.Features.Feature.FeatureType.Deck)
                {
                    AddFeatureToTree(feature, groupNode);
                }
            }

            groupNode = new FeatureTreeNode(FeatureTreeNode.BuildText(FeatureTreeNode.FeatureTreeNodeType.PointsGroup), FeatureTreeNode.FeatureTreeNodeType.PointsGroup);
			featuresTreeView.Nodes.Add(groupNode);

			foreach (Models.Features.Feature feature in this.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.Point)
				{
					AddFeatureToTree(feature, groupNode);
				}
			}

			groupNode = new FeatureTreeNode(FeatureTreeNode.BuildText(FeatureTreeNode.FeatureTreeNodeType.GatesGroup), FeatureTreeNode.FeatureTreeNodeType.GatesGroup);
			featuresTreeView.Nodes.Add(groupNode);

			foreach (Models.Features.Feature feature in this.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.Gate)
				{
					AddFeatureToTree(feature, groupNode);
				}
			}

			groupNode = new FeatureTreeNode(FeatureTreeNode.BuildText(FeatureTreeNode.FeatureTreeNodeType.PointsOfInterestGroup), FeatureTreeNode.FeatureTreeNodeType.PointsOfInterestGroup);
			featuresTreeView.Nodes.Add(groupNode);

			foreach (Models.Features.Feature feature in this.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.PointOfInterest)
				{
					AddFeatureToTree(feature, groupNode);
				}
			}

			featuresTreeView.SelectedNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.PointsGroup);

            featuresTreeView.EndUpdate();
		}

		private void AddFeatureToTree(Models.Features.Feature feature, FeatureTreeNode parent)
		{
			FeatureTreeNode node = new FeatureTreeNode(FeatureTreeNode.BuildText(FeatureTreeNode.FeatureTreeNodeType.Feature, feature), FeatureTreeNode.FeatureTreeNodeType.Feature, feature);

			parent.Nodes.Add(node);
			parent.Expand();

			featuresTreeView.SelectedNode = node;
			node.EnsureVisible();
		}

		private FeatureTreeNode GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType type)
		{
			FeatureTreeNode firstNode = null;

			foreach (FeatureTreeNode node in featuresTreeView.Nodes)
			{
				if (node.Type == type)
				{
					firstNode = node;
					break;
				}
			}

			return firstNode;
		}

		#endregion

		#region Map

		private async Task ShowMapAsync()
		{
			featuresMap.Visible = true;

			foreach (Models.Features.Feature feature in this.Competition.Features)
			{
				await AddFeatureToMapAsync(feature);
			}
		}

		private async Task HideMapAsync()
		{
			featuresMap.Visible = false;
			await featuresMap.ClearAsync();
		}

		private async Task AddFeatureToMapAsync(Models.Features.Feature feature)
		{
			if (featuresMap.Visible)
			{
				await featuresMap.AddFeatureAsync(feature);
			}
		}

		private async Task RemoveFeatureFromMapAsync(string featureName)
		{
			if (featuresMap.Visible)
			{
				await featuresMap.RemoveFeatureAsync(featureName);
			}
		}

        #endregion

        private bool FeatureNameExists(string name)
        {
            foreach (Models.Features.Feature feature in this.Competition.Features)
            {
                if (feature.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        private void RefreshControlState()
        {
            bool airfieldFeatureExists = false;

            foreach (Models.Features.Feature feature in this.Competition.Features)
            {
                if (feature.Type == Models.Features.Feature.FeatureType.Airfield)
                {
                    airfieldFeatureExists = true;
                }
            }

            addAirfieldRibbonButton.Enabled = !airfieldFeatureExists;

            FeatureTreeNode selectedNode = featuresTreeView.SelectedNode as FeatureTreeNode;

            cloneRibbonButton.Enabled = (selectedNode.Type == FeatureTreeNode.FeatureTreeNodeType.Feature && selectedNode.Feature.Type == Models.Features.Feature.FeatureType.Point);

            editRibbonButton.Enabled = (selectedNode.Type == FeatureTreeNode.FeatureTreeNodeType.Feature);
			deleteRibbonButton.Enabled = (selectedNode.Type == FeatureTreeNode.FeatureTreeNodeType.Feature);

			zoomInRibbonButton.Enabled = featuresMap.Visible;
			zoomOutRibbonButton.Enabled = featuresMap.Visible;
        }

		private async void FeatureDefinitionForm_Load(object sender, EventArgs e)
		{
			PopulateFeaturesTree();

			await ShowMapAsync();
		}

		private async void addPointRibbonButton_Click(object sender, EventArgs e)
		{
			await AddFeatureAsync(Models.Features.Feature.FeatureType.Point, await featuresMap.GetCenterAsync(), false);
		}

		private async void addGateRibbonButton_Click(object sender, EventArgs e)
		{
			await AddFeatureAsync(Models.Features.Feature.FeatureType.Gate, await featuresMap.GetCenterAsync(), false);
		}

		private async void addNfzRibbonButton_Click(object sender, EventArgs e)
		{
			await AddFeatureAsync(Models.Features.Feature.FeatureType.NoFlyZone, await featuresMap.GetCenterAsync(), false);
		}

        private async void addAirfieldRibbonButton_Click(object sender, EventArgs e)
        {
			await AddFeatureAsync(Models.Features.Feature.FeatureType.Airfield, await featuresMap.GetCenterAsync(), false);
        }

        private async void addDeckRibbonButton_Click(object sender, EventArgs e)
        {
			await AddFeatureAsync(Models.Features.Feature.FeatureType.Deck, await featuresMap.GetCenterAsync(), false);
        }

		private async void addPoiRibbonButton_Click(object sender, EventArgs e)
		{
			await AddFeatureAsync(Models.Features.Feature.FeatureType.PointOfInterest, await featuresMap.GetCenterAsync(), false);
		}

		private async void editRibbonButton_Click(object sender, EventArgs e)
		{
			FeatureTreeNode selectedNode = featuresTreeView.SelectedNode as FeatureTreeNode;

			if (selectedNode.Type == FeatureTreeNode.FeatureTreeNodeType.Feature)
			{
				await EditFeatureAsync(selectedNode.Feature);
			}
		}

        private async void deleteRibbonButton_Click(object sender, EventArgs e)
        {
			FeatureTreeNode selectedNode = featuresTreeView.SelectedNode as FeatureTreeNode;

			List<Models.Task> featureInUseByTasks = new List<Models.Task>();

			// Check if the feature is in use at task level
			foreach (Models.Task task in this.Competition.Tasks)
			{
				if (task.IsUsingFeature(selectedNode.Feature))
				{
					featureInUseByTasks.Add(task);
				}
			}

			string message = string.Empty;

			if (featureInUseByTasks.Count > 0)
			{
				if (featureInUseByTasks.Count == 1)
				{
					message = string.Format("{0} is being used by task {1} ({2}).\n\n", selectedNode.Text, featureInUseByTasks[0].Number, featureInUseByTasks[0].Name);
				}
				else
				{
					message = string.Format("{0} is being used by {1} tasks.\n\n", selectedNode.Text, featureInUseByTasks.Count);
				}
			}

			message += "Are you sure you want to delete " + selectedNode.Text + "?";

			if (MessageBox.Show(message, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (selectedNode.Type == FeatureTreeNode.FeatureTreeNodeType.Feature)
                {
					// Remove this feature from any tasks that are using it
					foreach (Models.Task task in this.Competition.Tasks)
					{
						task.RemoveFeatureFromUse(selectedNode.Feature);
					}

                    this.Competition.Features.Remove(selectedNode.Feature);
                    this.Competition.Save();

                    selectedNode.Remove();

					await RemoveFeatureFromMapAsync(selectedNode.Feature.Name);
                }
            }
        }

		private async void showMapRibbonButton_Click(object sender, EventArgs e)
		{
			if (showMapRibbonButton.Checked)
			{
				await ShowMapAsync();
			}
			else
			{
				await HideMapAsync();
			}

			RefreshControlState();
		}

		private async void zoomInRibbonButton_Click(object sender, EventArgs e)
		{
			await featuresMap.ZoomInAsync();
		}

		private async void zoomOutRibbonButton_Click(object sender, EventArgs e)
		{
			await featuresMap.ZoomOutAsync();
		}

		private void featuresTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			RefreshControlState();
		}

		private async void featuresTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			FeatureTreeNode selectedNode = featuresTreeView.SelectedNode as FeatureTreeNode;

			if (selectedNode.Type == FeatureTreeNode.FeatureTreeNodeType.Feature)
			{
				await EditFeatureAsync(selectedNode.Feature);
			}
		}

		private void featuresMap_MapRightClicked(object sender, MapClickedEventArgs e)
		{
            m_rightClickLocation = e.Location;

            mapContextMenuStrip.Show(Cursor.Position);
		}

		private async void addPointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await AddFeatureAsync(Models.Features.Feature.FeatureType.Point, m_rightClickLocation, true);
		}

		private async void addGateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await AddFeatureAsync(Models.Features.Feature.FeatureType.Gate, m_rightClickLocation, true);
		}

		private async void addNfzToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await AddFeatureAsync(Models.Features.Feature.FeatureType.NoFlyZone, m_rightClickLocation, true);
		}

        private async void importRibbonButton_Click(object sender, EventArgs e)
        {
            if (importOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Geolocation.Files.Kml file = new Geolocation.Files.Kml(importOpenFileDialog.FileName);

                using (ImportFeaturesForm form = new ImportFeaturesForm(file, this.Competition))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (Models.Features.Feature feature in form.ImportedFeatures)
                        {
                            switch (feature.Type)
                            {
                                case Models.Features.Feature.FeatureType.Airfield:
                                    AddFeatureToTree(feature, GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.AirfieldGroup));
									await AddFeatureToMapAsync(feature);
                                    break;

                                case Models.Features.Feature.FeatureType.Deck:
                                    AddFeatureToTree(feature, GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.DecksGroup));
									await AddFeatureToMapAsync(feature);
                                    break;

                                case Models.Features.Feature.FeatureType.NoFlyZone:
                                    AddFeatureToTree(feature, GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.NoFlyZonesGroup));
									await AddFeatureToMapAsync(feature);
                                    break;

                                case Models.Features.Feature.FeatureType.Point:
                                    AddFeatureToTree(feature, GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.PointsGroup));
									await AddFeatureToMapAsync(feature);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private async void cloneRibbonButton_Click(object sender, EventArgs e)
        {
            FeatureTreeNode selectedNode = featuresTreeView.SelectedNode as FeatureTreeNode;

            int copyCount = 1;
            string proposedName = string.Format("{0} ({1})", selectedNode.Feature.Name, copyCount);

            while (FeatureNameExists(proposedName))
            {
                copyCount++;
                proposedName = string.Format("{0} ({1})", selectedNode.Feature.Name, copyCount);
            }

            Models.Features.PointFeature pointClone = (selectedNode.Feature as Models.Features.PointFeature).Clone(proposedName);

            this.Competition.Features.Add(pointClone);

            FeatureTreeNode groupNode = GetFirstNodeOfType(FeatureTreeNode.FeatureTreeNodeType.PointsGroup);

            AddFeatureToTree(pointClone, groupNode);
			await AddFeatureToMapAsync(pointClone);
        }
	}
}
