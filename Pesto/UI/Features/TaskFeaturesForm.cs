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
	internal partial class TaskFeaturesForm : Form
	{
		private bool m_ignoreEvent;

		public TaskFeaturesForm(Models.Task task)
		{
			InitializeComponent();

			this.Task = task;
		}

		public Models.Task Task { get; private set; }

        private void PopulateDecks(Models.Features.DeckFeature selectedDeck, ComboBox comboBox)
        {
            m_ignoreEvent = true;

            comboBox.Items.Clear();

            comboBox.Items.Add(new FeatureListItem());

            int selectedIndex = 0;

            foreach (Models.Features.Feature feature in this.Task.Competition.Features)
            {
                if (feature.Type == Models.Features.Feature.FeatureType.Deck)
                {
                    int index = comboBox.Items.Add(new FeatureListItem(feature));

                    if (selectedDeck != null && string.Compare(selectedDeck.Name, feature.Name, true) == 0)
                    {
                        selectedIndex = index;
                    }
                }
            }

            comboBox.SelectedIndex = selectedIndex;

            m_ignoreEvent = false;
        }

		private void PopulateStartPointGate()
		{
			PopulateStartFinishPointGate(this.Task.StartPointOrGate, startPointGateComboBox);
		}

		private void PopulateFinishPointGate()
		{
			PopulateStartFinishPointGate(this.Task.FinishPointOrGate, finishPointGateComboBox);
		}

		private void PopulateStartFinishPointGate(Models.Features.Feature selectedFeature, ComboBox comboBox)
		{
			m_ignoreEvent = true;

			comboBox.Items.Clear();

			comboBox.Items.Add(new FeatureListItem());

			int selectedIndex = 0;

			foreach (Models.Features.Feature feature in this.Task.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.Point || feature.Type == Models.Features.Feature.FeatureType.Gate)
				{
					int index = comboBox.Items.Add(new FeatureListItem(feature));

					if (selectedFeature != null && string.Compare(selectedFeature.Name, feature.Name, true) == 0)
					{
						selectedIndex = index;
					}
				}
			}

			comboBox.SelectedIndex = selectedIndex;

			m_ignoreEvent = false;
		}

		private void PopulateTurnpoints()
		{
			m_ignoreEvent = true;

			turnpointsCheckedListBox.Items.Clear();

			foreach (Models.Features.Feature feature in this.Task.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.Point)
				{
					bool selected = false;

					foreach (Models.Features.PointFeature turnpoint in this.Task.Turnpoints)
					{
						if (string.Compare(turnpoint.Name, feature.Name, true) == 0)
						{
							selected = true;
							break;
						}
					}

					FeatureListItem item = new FeatureListItem(feature);
					int index = turnpointsCheckedListBox.Items.Add(item);

					turnpointsCheckedListBox.SetItemChecked(index, selected);
				}
			}

			m_ignoreEvent = false;
		}

		private void PopulateHiddenGates()
		{
			m_ignoreEvent = true;

			hiddenGatesCheckedListBox.Items.Clear();

			foreach (Models.Features.Feature feature in this.Task.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.Gate)
				{
					bool selected = false;

					foreach (Models.Features.GateFeature gate in this.Task.HiddenGates)
					{
						if (string.Compare(gate.Name, feature.Name, true) == 0)
						{
							selected = true;
							break;
						}
					}

					FeatureListItem item = new FeatureListItem(feature);
					int index = hiddenGatesCheckedListBox.Items.Add(item);

					hiddenGatesCheckedListBox.SetItemChecked(index, selected);
				}
			}

			m_ignoreEvent = false;
		}

		#region Map

		private void ShowMap()
		{
			featuresMap.Visible = true;

            if (this.Task.TakeOffDeck != null)
            {
                AddFeatureToMap(this.Task.TakeOffDeck);
            }

            if (this.Task.LandingDeck != null)
            {
                AddFeatureToMap(this.Task.LandingDeck);
            }

            if (this.Task.StartPointOrGate != null)
			{
				AddFeatureToMap(this.Task.StartPointOrGate);
			}

			if (this.Task.FinishPointOrGate != null)
			{
				AddFeatureToMap(this.Task.FinishPointOrGate);
			}

			foreach (Models.Features.PointFeature turnpoint in this.Task.Turnpoints)
			{
				AddFeatureToMap(turnpoint);
			}

			foreach (Models.Features.GateFeature gate in this.Task.HiddenGates)
			{
				AddFeatureToMap(gate);
			}

            foreach (Models.Features.NoFlyZoneFeature nfz in this.Task.NoFlyZones)
            {
                AddFeatureToMap(nfz);
            }

            foreach (Models.Features.Feature feature in this.Task.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.Airfield)
				{
					AddFeatureToMap(feature);
				}
			}
		}

		private void HideMap()
		{
			featuresMap.Visible = false;
			featuresMap.Clear();
		}

		private void AddFeatureToMap(Models.Features.Feature feature)
		{
			if (featuresMap.Visible)
			{
				featuresMap.AddFeature(feature);
			}
		}

		private void RemoveFeatureFromMap(Models.Features.Feature feature)
		{
			if (featuresMap.Visible)
			{
				featuresMap.RemoveFeature(feature.Name);
			}
		}

		#endregion

		private void RefreshControlState()
		{
			zoomInRibbonButton.Enabled = featuresMap.Visible;
			zoomOutRibbonButton.Enabled = featuresMap.Visible;
		}

		private void TaskFeaturesForm_Load(object sender, EventArgs e)
		{
            PopulateDecks(this.Task.TakeOffDeck, takeOffDeckComboBox);
            PopulateDecks(this.Task.LandingDeck, landingDeckComboBox);
            PopulateStartPointGate();
			PopulateFinishPointGate();
			PopulateTurnpoints();
			PopulateHiddenGates();

			ShowMap();
		}

		private void defineRibbonButton_Click(object sender, EventArgs e)
		{
			using (FeatureDefinitionForm form = new FeatureDefinitionForm(this.Task.Competition))
			{
				form.ShowDialog();

				this.Task.Competition.Save();

				HideMap();
                PopulateDecks(this.Task.TakeOffDeck, takeOffDeckComboBox);
                PopulateDecks(this.Task.LandingDeck, landingDeckComboBox);
                PopulateStartPointGate();
				PopulateFinishPointGate();
				PopulateTurnpoints();
				PopulateHiddenGates();
				ShowMap();
			}
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

			RefreshControlState();
		}

		private void zoomInRibbonButton_Click(object sender, EventArgs e)
		{
			featuresMap.ZoomIn();
		}

		private void zoomOutRibbonButton_Click(object sender, EventArgs e)
		{
			featuresMap.ZoomOut();
		}

        private void takeOffDeckComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_ignoreEvent) return;

            if (this.Task.TakeOffDeck != null)
            {
                RemoveFeatureFromMap(this.Task.TakeOffDeck);
            }

            if (takeOffDeckComboBox.SelectedIndex == 0)
            {
                this.Task.TakeOffDeck = null;
            }
            else
            {
                FeatureListItem selectedItem = takeOffDeckComboBox.SelectedItem as FeatureListItem;

                this.Task.TakeOffDeck = selectedItem.Feature as Models.Features.DeckFeature;
                AddFeatureToMap(selectedItem.Feature);
            }
        }

        private void landingDeckComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_ignoreEvent) return;

            if (this.Task.LandingDeck != null)
            {
                RemoveFeatureFromMap(this.Task.LandingDeck);
            }

            if (landingDeckComboBox.SelectedIndex == 0)
            {
                this.Task.LandingDeck = null;
            }
            else
            {
                FeatureListItem selectedItem = landingDeckComboBox.SelectedItem as FeatureListItem;

                this.Task.LandingDeck = selectedItem.Feature as Models.Features.DeckFeature;
                AddFeatureToMap(selectedItem.Feature);
            }
        }

        private void startPointGateComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ignoreEvent) return;

			if (this.Task.StartPointOrGate != null)
			{
				RemoveFeatureFromMap(this.Task.StartPointOrGate);
			}

			if (startPointGateComboBox.SelectedIndex == 0)
			{
				this.Task.StartPointOrGate = null;
			}
			else
			{
				FeatureListItem selectedItem = startPointGateComboBox.SelectedItem as FeatureListItem;

				this.Task.StartPointOrGate = selectedItem.Feature;
				AddFeatureToMap(selectedItem.Feature);
			}
		}

		private void finishPointGateComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ignoreEvent) return;

			if (this.Task.FinishPointOrGate != null)
			{
				RemoveFeatureFromMap(this.Task.FinishPointOrGate);
			}

			if (finishPointGateComboBox.SelectedIndex == 0)
			{
				this.Task.FinishPointOrGate = null;
			}
			else
			{
				FeatureListItem selectedItem = finishPointGateComboBox.SelectedItem as FeatureListItem;

				this.Task.FinishPointOrGate = selectedItem.Feature;
				AddFeatureToMap(selectedItem.Feature);
			}
		}

		private void turnpointsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (m_ignoreEvent) return;

			if (e.NewValue != e.CurrentValue)
			{
				FeatureListItem selectedItem = turnpointsCheckedListBox.Items[e.Index] as FeatureListItem;

				if (e.NewValue == CheckState.Checked)
				{
					this.Task.Turnpoints.Add(selectedItem.Feature as Models.Features.PointFeature);
					AddFeatureToMap(selectedItem.Feature);
				}
				else if (e.NewValue == CheckState.Unchecked)
				{
					foreach (Models.Features.PointFeature taskTurnpoint in this.Task.Turnpoints)
					{
						if (string.Compare(taskTurnpoint.Name, selectedItem.Feature.Name, true) == 0)
						{
							this.Task.Turnpoints.Remove(taskTurnpoint);
							break;
						}
					}

					RemoveFeatureFromMap(selectedItem.Feature);
				}
			}

			RefreshControlState();
		}

		private void hiddenGatesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (m_ignoreEvent) return;

			if (e.NewValue != e.CurrentValue)
			{
				FeatureListItem selectedItem = hiddenGatesCheckedListBox.Items[e.Index] as FeatureListItem;

				if (e.NewValue == CheckState.Checked)
				{
					this.Task.HiddenGates.Add(selectedItem.Feature as Models.Features.GateFeature);
					AddFeatureToMap(selectedItem.Feature);
				}
				else if (e.NewValue == CheckState.Unchecked)
				{
					foreach (Models.Features.GateFeature taskGate in this.Task.HiddenGates)
					{
						if (string.Compare(taskGate.Name, selectedItem.Feature.Name, true) == 0)
						{
							this.Task.HiddenGates.Remove(taskGate);
							break;
						}
					}

					RemoveFeatureFromMap(selectedItem.Feature);
				}
			}

			RefreshControlState();
		}
    }
}
