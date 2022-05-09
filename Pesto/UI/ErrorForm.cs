using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(Exception exception)
        {
            InitializeComponent();

            messageTextBox.Text = exception.Message;
            stackTraceTextBox.Text = exception.StackTrace;
        }

		private void exitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
    }
}
