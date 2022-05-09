using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void calculateDistanceButton_Click(object sender, EventArgs e)
		{
			ColinBaker.Location.Location location1 = new ColinBaker.Location.Location(decimal.Parse(latitude1TextBox.Text), decimal.Parse(longitude1TextBox.Text));
			ColinBaker.Location.Location location2 = new ColinBaker.Location.Location(decimal.Parse(latitude2TextBox.Text), decimal.Parse(longitude2TextBox.Text));

			ColinBaker.Location.HaversineDistanceCalculator calculator = new ColinBaker.Location.HaversineDistanceCalculator();
			MessageBox.Show(string.Format("Distance: {0:N0} metres.", calculator.CalculateDistance(location1, location2)), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
