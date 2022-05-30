using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.TrackAnalysis
{
	partial class PilotManualTracksForm : Form
	{
		public PilotManualTracksForm(int pilotNumber, string pilotName, Models.Task task)
		{
			InitializeComponent();

			this.PilotNumber = pilotNumber;
			this.Text += pilotName;
			this.Task = task;

			foreach (Models.ManualTrack track in task.ManualTracks.Where(t => t.PilotNumber == pilotNumber))
			{
				manualTracksListBox.Items.Add(track);
			}
		}

		public int PilotNumber { get; private set; }
		public Models.Task Task { get; private set; }

		private void manualTracksListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			removeButton.Enabled = manualTracksListBox.SelectedIndex != -1;
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			if (addManualTrackDialog.ShowDialog() == DialogResult.OK)
			{
				foreach (string filePath in addManualTrackDialog.FileNames)
				{
					manualTracksListBox.Items.Add(new Models.ManualTrack()
					{
						Task = this.Task,
						PilotNumber = this.PilotNumber,
						TrackFilePath = filePath
					});
				}
			}
		}

		private void removeButton_Click(object sender, EventArgs e)
		{
			manualTracksListBox.Items.RemoveAt(manualTracksListBox.SelectedIndex);
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			// Remove and then re-add manual tracks for this pilot

			List<Models.ManualTrack> existingTracks = this.Task.ManualTracks.Where(t => t.PilotNumber == this.PilotNumber).ToList();

			foreach (Models.ManualTrack track in existingTracks)
			{
				this.Task.ManualTracks.Remove(track);
			}

			foreach (Models.ManualTrack track in manualTracksListBox.Items)
			{
				this.Task.ManualTracks.Add(track);
			}
		}
	}
}
