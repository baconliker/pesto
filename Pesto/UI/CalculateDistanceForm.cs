using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI
{
    public partial class CalculateDistanceForm : Form
    {
        public CalculateDistanceForm()
        {
            InitializeComponent();
        }

        private bool ValidateCalculateDistance(out decimal fromLatitude, out decimal fromLongitude, out decimal toLatitude, out decimal toLongitude)
        {
            fromLatitude = 0;
            fromLongitude = 0;
            toLatitude = 0;
            toLongitude = 0;

            if (!(Decimal.TryParse(fromLatitudeTextBox.Text, out fromLatitude) && fromLatitude >= -90 && fromLatitude <= 90))
            {
                MessageBox.Show("Please enter a valid latitude", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fromLatitudeTextBox.Focus();
                return false;
            }

            if (!(Decimal.TryParse(fromLongitudeTextBox.Text, out fromLongitude) && fromLongitude >= -180 && fromLongitude <= 180))
            {
                MessageBox.Show("Please enter a valid longitude", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fromLongitudeTextBox.Focus();
                return false;
            }

            if (!(Decimal.TryParse(toLatitudeTextBox.Text, out toLatitude) && toLatitude >= -90 && toLatitude <= 90))
            {
                MessageBox.Show("Please enter a valid latitude", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toLatitudeTextBox.Focus();
                return false;
            }

            if (!(Decimal.TryParse(toLongitudeTextBox.Text, out toLongitude) && toLongitude >= -180 && toLongitude <= 180))
            {
                MessageBox.Show("Please enter a valid longitude", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toLongitudeTextBox.Focus();
                return false;
            }

            return true;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal fromLatitude;
            decimal fromLongitude;
            decimal toLatitude;
            decimal toLongitude;

            if (ValidateCalculateDistance(out fromLatitude, out fromLongitude, out toLatitude, out toLongitude))
            {
                Geolocation.Location location1 = new Geolocation.Location(fromLatitude, fromLongitude);
                Geolocation.Location location2 = new Geolocation.Location(toLatitude, toLongitude);

                Geolocation.HaversineDistanceCalculator distanceCalculator = new Geolocation.HaversineDistanceCalculator();

                MessageBox.Show(string.Format("The distance between the given locations in {0:0.0}", distanceCalculator.CalculateDistance(location1, location2)), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
