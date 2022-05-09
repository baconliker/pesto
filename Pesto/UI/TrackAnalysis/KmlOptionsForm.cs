using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.TrackAnalysis
{
	public partial class KmlOptionsForm : Form
	{
		public KmlOptionsForm(bool includeFeaturesEnabled, bool includeEventsEnabled)
		{
			InitializeComponent();

			fixDataCheckBox.Checked = false;
			clampToGroundCheckBox.Checked = false;

			featuresCheckBox.Checked = includeFeaturesEnabled;
			featuresCheckBox.Enabled = includeFeaturesEnabled;

			eventsCheckBox.Checked = includeEventsEnabled;
			eventsCheckBox.Enabled = includeEventsEnabled;
		}

        public bool IncludeTrackFixData { get; set; }
        public bool ClampTrackToGround { get; set; }
        public bool IncludeFeatures { get; set; }
		public bool IncludeEvents { get; set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.IncludeTrackFixData = fixDataCheckBox.Checked;
            this.ClampTrackToGround = clampToGroundCheckBox.Checked;
            this.IncludeFeatures = featuresCheckBox.Checked;
			this.IncludeEvents = eventsCheckBox.Checked;
        }
	}
}
