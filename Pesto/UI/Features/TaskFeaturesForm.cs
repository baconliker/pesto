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
			PopulatePointGate(this.Task.StartPointOrGate, startPointGateComboBox);
		}

		private void PopulateFinishPointGate()
		{
			PopulatePointGate(this.Task.FinishPointOrGate, finishPointGateComboBox);
		}

		private void PopulateElapsedTimePointGate()
		{
			PopulatePointGate(this.Task.ElapsedTimePointOrGate, elapsedTimePointGateComboBox);
		}

		private void PopulatePointGate(Models.Features.Feature selectedFeature, ComboBox comboBox)
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

		private void SelectListboxItems(CheckedListBox listBox, bool selected)
		{
			for (int i = 0; i < listBox.Items.Count; i++)
			{
				listBox.SetItemChecked(i, selected);
			}
		}

		#region Map

		private async Task ShowMapAsync()
		{
			featuresMap.Visible = true;

            if (this.Task.TakeOffDeck != null)
            {
				await AddFeatureToMapAsync(this.Task.TakeOffDeck);
            }

            if (this.Task.LandingDeck != null)
            {
				await AddFeatureToMapAsync(this.Task.LandingDeck);
            }

            if (this.Task.StartPointOrGate != null)
			{
				await AddFeatureToMapAsync(this.Task.StartPointOrGate);
			}

			if (this.Task.FinishPointOrGate != null)
			{
				await AddFeatureToMapAsync(this.Task.FinishPointOrGate);
			}

			foreach (Models.Features.PointFeature turnpoint in this.Task.Turnpoints)
			{
				await AddFeatureToMapAsync(turnpoint);
			}

			foreach (Models.Features.GateFeature gate in this.Task.HiddenGates)
			{
				await AddFeatureToMapAsync(gate);
			}

            foreach (Models.Features.NoFlyZoneFeature nfz in this.Task.NoFlyZones)
            {
				await AddFeatureToMapAsync(nfz);
            }

            foreach (Models.Features.Feature feature in this.Task.Competition.Features)
			{
				if (feature.Type == Models.Features.Feature.FeatureType.Airfield)
				{
					await AddFeatureToMapAsync(feature);
				}
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

		private async Task RemoveFeatureFromMapAsync(Models.Features.Feature feature)
		{
			if (featuresMap.Visible)
			{
				await featuresMap.RemoveFeatureAsync(feature.Name);
			}
		}

		#endregion

		private void RefreshControlState()
		{
			zoomInRibbonButton.Enabled = featuresMap.Visible;
			zoomOutRibbonButton.Enabled = featuresMap.Visible;
		}

		private async void TaskFeaturesForm_Load(object sender, EventArgs e)
		{
            PopulateDecks(this.Task.TakeOffDeck, takeOffDeckComboBox);
            PopulateDecks(this.Task.LandingDeck, landingDeckComboBox);
            PopulateStartPointGate();
			PopulateFinishPointGate();
			PopulateElapsedTimePointGate();
			PopulateTurnpoints();
			PopulateHiddenGates();

			await ShowMapAsync();
		}

		private async void defineRibbonButton_Click(object sender, EventArgs e)
		{
			using (FeatureDefinitionForm form = new FeatureDefinitionForm(this.Task.Competition))
			{
				form.ShowDialog();

				this.Task.Competition.Save();

				await HideMapAsync();
                PopulateDecks(this.Task.TakeOffDeck, takeOffDeckComboBox);
                PopulateDecks(this.Task.LandingDeck, landingDeckComboBox);
                PopulateStartPointGate();
				PopulateFinishPointGate();
				PopulateElapsedTimePointGate();
				PopulateTurnpoints();
				PopulateHiddenGates();
				await ShowMapAsync();
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

        private async void takeOffDeckComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_ignoreEvent) return;

            if (this.Task.TakeOffDeck != null)
            {
				await RemoveFeatureFromMapAsync(this.Task.TakeOffDeck);
            }

            if (takeOffDeckComboBox.SelectedIndex == 0)
            {
                this.Task.TakeOffDeck = null;
            }
            else
            {
                FeatureListItem selectedItem = takeOffDeckComboBox.SelectedItem as FeatureListItem;

                this.Task.TakeOffDeck = selectedItem.Feature as Models.Features.DeckFeature;
				await AddFeatureToMapAsync(selectedItem.Feature);
            }
        }

        private async void landingDeckComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_ignoreEvent) return;

            if (this.Task.LandingDeck != null)
            {
				await RemoveFeatureFromMapAsync(this.Task.LandingDeck);
            }

            if (landingDeckComboBox.SelectedIndex == 0)
            {
                this.Task.LandingDeck = null;
            }
            else
            {
                FeatureListItem selectedItem = landingDeckComboBox.SelectedItem as FeatureListItem;

                this.Task.LandingDeck = selectedItem.Feature as Models.Features.DeckFeature;
				await AddFeatureToMapAsync(selectedItem.Feature);
            }
        }

        private async void startPointGateComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ignoreEvent) return;

			if (this.Task.StartPointOrGate != null)
			{
				await RemoveFeatureFromMapAsync(this.Task.StartPointOrGate);
			}

			if (startPointGateComboBox.SelectedIndex == 0)
			{
				this.Task.StartPointOrGate = null;
			}
			else
			{
				FeatureListItem selectedItem = startPointGateComboBox.SelectedItem as FeatureListItem;

				this.Task.StartPointOrGate = selectedItem.Feature;
				await AddFeatureToMapAsync(selectedItem.Feature);
			}
		}

		private async void finishPointGateComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ignoreEvent) return;

			if (this.Task.FinishPointOrGate != null)
			{
				await RemoveFeatureFromMapAsync(this.Task.FinishPointOrGate);
			}

			if (finishPointGateComboBox.SelectedIndex == 0)
			{
				this.Task.FinishPointOrGate = null;
			}
			else
			{
				FeatureListItem selectedItem = finishPointGateComboBox.SelectedItem as FeatureListItem;

				this.Task.FinishPointOrGate = selectedItem.Feature;
				await AddFeatureToMapAsync(selectedItem.Feature);
			}
		}

		private async void elapsedTimePointGateComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ignoreEvent) return;

			if (this.Task.ElapsedTimePointOrGate != null)
			{
				await RemoveFeatureFromMapAsync(this.Task.ElapsedTimePointOrGate);
			}

			if (elapsedTimePointGateComboBox.SelectedIndex == 0)
			{
				this.Task.ElapsedTimePointOrGate = null;
			}
			else
			{
				FeatureListItem selectedItem = elapsedTimePointGateComboBox.SelectedItem as FeatureListItem;

				this.Task.ElapsedTimePointOrGate = selectedItem.Feature;
				await AddFeatureToMapAsync(selectedItem.Feature);
			}
		}

		private async void turnpointsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (m_ignoreEvent) return;

			if (e.NewValue != e.CurrentValue)
			{
				FeatureListItem selectedItem = turnpointsCheckedListBox.Items[e.Index] as FeatureListItem;

				if (e.NewValue == CheckState.Checked)
				{
					this.Task.Turnpoints.Add(selectedItem.Feature as Models.Features.PointFeature);
					await AddFeatureToMapAsync(selectedItem.Feature);
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

					await RemoveFeatureFromMapAsync(selectedItem.Feature);
				}
			}

			RefreshControlState();
		}

		private async void hiddenGatesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (m_ignoreEvent) return;

			if (e.NewValue != e.CurrentValue)
			{
				FeatureListItem selectedItem = hiddenGatesCheckedListBox.Items[e.Index] as FeatureListItem;

				if (e.NewValue == CheckState.Checked)
				{
					this.Task.HiddenGates.Add(selectedItem.Feature as Models.Features.GateFeature);
					await AddFeatureToMapAsync(selectedItem.Feature);
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

					await RemoveFeatureFromMapAsync(selectedItem.Feature);
				}
			}

			RefreshControlState();
		}

		private void selectAllRibbonButton_Click(object sender, EventArgs e)
		{
			SelectListboxItems(turnpointsCheckedListBox, true);
			SelectListboxItems(hiddenGatesCheckedListBox, true);
		}

		private void selectNoneRibbonButton_Click(object sender, EventArgs e)
		{
			SelectListboxItems(turnpointsCheckedListBox, false);
			SelectListboxItems(hiddenGatesCheckedListBox, false);
		}
	}
}
