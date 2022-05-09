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
	public partial class UpdateCheckForm : Form
	{
		private Services.ApplicationUpdater m_updater;

		public UpdateCheckForm(Services.ApplicationUpdater updater)
		{
			InitializeComponent();

			m_updater = updater;
		}

		private void UpdateCheckForm_Shown(object sender, EventArgs e)
		{
			Application.DoEvents();

			updateSaveFileDialog.InitialDirectory = m_updater.GetDefaultDownloadFolderPath();
			updateSaveFileDialog.FileName = m_updater.GetDefaultDownloadFileName(); ;

			if (updateSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				m_updater.DownloadProgressChanged += new EventHandler<System.Net.DownloadProgressChangedEventArgs>(m_updater_DownloadProgressChanged);
				m_updater.DownloadComplete += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(m_updater_DownloadComplete);

				try
				{
					m_updater.DownloadLatestVersionAsync(updateSaveFileDialog.FileName);
				}
				catch (Exception ex)
				{
					MessageBox.Show(string.Format("Unable to initiate download ({0})", ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				this.Close();
			}
		}

		private void m_updater_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
		{
			downloadProgressBar.Value = e.ProgressPercentage;
            downloadLabel.Text = string.Format("Downloaded {0} of {1} MB", e.BytesReceived / 1000 / 1000, e.TotalBytesToReceive / 1000 / 1000);
		}

		private void m_updater_DownloadComplete(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(string.Format("Download failed ({0})", e.Error.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				downloadLabel.Text = "Download failed";
			}
			else
			{
				downloadProgressBar.Value = 100;
				downloadLabel.Text = "Download complete";

				installButton.Enabled = true;
			}

			cancelCloseButton.Text = "Close";
		}

		private void installButton_Click(object sender, EventArgs e)
		{
            try
            {
                System.Diagnostics.Process.Start(updateSaveFileDialog.FileName);
            }
			catch
            {
                MessageBox.Show("Unable to run installer.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
	}
}
