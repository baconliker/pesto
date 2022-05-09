using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace ColinBaker.Pesto.UI
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();

            foreach (Control control in this.Controls)
            {
                if (control is LinkLabel)
                {
                    (control as LinkLabel).LinkClicked += linkLabel_LinkClicked;
                }
            }
		}

        private void AboutForm_Load(object sender, EventArgs e)
		{
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            this.Text = this.Text + " " + Application.ProductName;

			nameLabel.Text = Application.ProductName;
            versionLabel.Text = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
			copyrightLabel.Text = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute), false)).Copyright;
		}

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start((sender as LinkLabel).Text);
            }
            catch { }
        }
    }
}
