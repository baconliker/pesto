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
	public partial class TrackConversionForm : Form
	{
		public TrackConversionForm()
		{
			InitializeComponent();
		}

		private void PreSelectInputFileFormat(string selectedFilePath)
		{
			// Try and select the correct file format

			//BORIS
			//System.IO.FileInfo file = new System.IO.FileInfo(selectedFilePath);

			//for (int i = 0; i < inputFormatComboBox.Items.Count; i++)
			//{
			//    ColinBaker.Geolocation.Tracks.FileFormat fileFormat = inputFormatComboBox.Items[i] as ColinBaker.Geolocation.Tracks.FileFormat;

			//    int index = System.Array.IndexOf(fileFormat.FileExtensions, file.Extension);

			//    if (index != -1)
			//    {
			//        inputFormatComboBox.SelectedIndex = i;
			//        break;
			//    }
			//}

			Geolocation.Files.File.FileFormat format;

			if (Geolocation.Files.File.DetermineFileFormat(selectedFilePath, out format))
			{
				foreach (TrackFileFormatListItem item in inputFormatComboBox.Items)
				{
					if (item.FileFormat == format)
					{
						inputFormatComboBox.SelectedItem = item;
						break;
					}
				}
			}
		}

		private bool ValidateTrackConversion()
		{
			if (tracksListBox.Items.Count == 0)
			{
				MessageBox.Show("Please add some tracks to convert.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			if (inputFormatComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select the input format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			if (outputFormatComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Please select the output format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			if (outputPathTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("Please select the output path.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			return true;
		}

		private string GetOutputFilePath(string inputFilePath)
		{
			string outputFilePath;

			if (tracksListBox.Items.Count == 1)
			{
				outputFilePath = outputPathTextBox.Text;
			}
			else
			{
				//BORIS
				//System.IO.FileInfo inputFile = new System.IO.FileInfo(inputFilePath);
				//ColinBaker.Geolocation.Tracks.FileFormat outputFileFormat = outputFormatComboBox.SelectedItem as ColinBaker.Geolocation.Tracks.FileFormat;

				//outputFilePath = outputPathTextBox.Text + System.IO.Path.DirectorySeparatorChar + inputFile.Name.Substring(0, inputFile.Name.Length - inputFile.Extension.Length) + outputFileFormat.FileExtensions[0];
				System.IO.FileInfo inputFile = new System.IO.FileInfo(inputFilePath);
				Geolocation.Files.File.FileFormat outputFormat = (outputFormatComboBox.SelectedItem as TrackFileFormatListItem).FileFormat;

				outputFilePath = outputPathTextBox.Text + System.IO.Path.DirectorySeparatorChar + inputFile.Name.Substring(0, inputFile.Name.Length - inputFile.Extension.Length) + Geolocation.Files.File.GetCommonFileExtensions(outputFormat)[0];
			}

			return outputFilePath;
		}

		private void RefreshControlState()
		{
			outputPathButton.Enabled = (tracksListBox.Items.Count > 0);
			removeTrackButton.Enabled = (tracksListBox.SelectedIndex != -1);
		}

		private void TrackConversionForm_Load(object sender, EventArgs e)
		{
			//ColinBaker.Geolocation.Tracks.FileFormat[] fileFormats = ColinBaker.Geolocation.Tracks.FileFormat.GetSupportedFormats();

			//foreach (ColinBaker.Geolocation.Tracks.FileFormat fileFormat in fileFormats)
			//{
			//    if (fileFormat.DecodingSupported)
			//    {
			//        inputFormatComboBox.Items.Add(fileFormat);
			//    }

			//    if (fileFormat.EncodingSupported)
			//    {
			//        outputFormatComboBox.Items.Add(fileFormat);
			//    }
			//}
			inputFormatComboBox.Items.Add(new TrackFileFormatListItem(Geolocation.Files.File.FileFormat.Gpx));
			inputFormatComboBox.Items.Add(new TrackFileFormatListItem(Geolocation.Files.File.FileFormat.Igc));
			inputFormatComboBox.Items.Add(new TrackFileFormatListItem(Geolocation.Files.File.FileFormat.Nmea));

			outputFormatComboBox.Items.Add(new TrackFileFormatListItem(Geolocation.Files.File.FileFormat.Gpx));
			outputFormatComboBox.Items.Add(new TrackFileFormatListItem(Geolocation.Files.File.FileFormat.Kml));

			RefreshControlState();
		}

		private void outputPathButton_Click(object sender, EventArgs e)
		{
			if (tracksListBox.Items.Count == 1)
			{
				//BORIS
				//ColinBaker.Geolocation.Tracks.FileFormat outputFileFormat;
				//string filter = null;

				//outputFileFormat = outputFormatComboBox.SelectedItem as ColinBaker.Geolocation.Tracks.FileFormat;

				//foreach (string extension in outputFileFormat.FileExtensions)
				//{
				//    if (!string.IsNullOrEmpty(filter))
				//    {
				//        filter += ";";
				//    }
				//    filter += "*" + extension;
				//}
				//filter = "Track files|" + filter + "|All files|*.*";

				//outputPathSaveFileDialog.Filter = filter;

				//if (outputPathSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				//{
				//    outputPathTextBox.Text = outputPathSaveFileDialog.FileName;
				//}

				string filter = string.Empty;

				if (outputFormatComboBox.SelectedIndex != -1)
				{
					Geolocation.Files.File.FileFormat outputFormat = (outputFormatComboBox.SelectedItem as TrackFileFormatListItem).FileFormat;

					foreach (string extension in Geolocation.Files.File.GetCommonFileExtensions(outputFormat))
					{
						if (!string.IsNullOrEmpty(filter))
						{
							filter += ";";
						}
						filter += "*" + extension;
					}
					filter = "Track files|" + filter + "|";
				}

				filter += "All files|*.*";

				outputPathSaveFileDialog.Filter = filter;

				if (outputPathSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					outputPathTextBox.Text = outputPathSaveFileDialog.FileName;
				}
			}
			else
			{
				if (outputPathFolderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					outputPathTextBox.Text = outputPathFolderBrowserDialog.SelectedPath;
				}
			}
		}

		private void addTracksButton_Click(object sender, EventArgs e)
		{
			if (selectTracksOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				foreach (string filePath in selectTracksOpenFileDialog.FileNames)
				{
					tracksListBox.Items.Add(filePath);
				}

				tracksListBox.SelectedIndex = 0;

				if (inputFormatComboBox.SelectedIndex == -1)
				{
					PreSelectInputFileFormat(tracksListBox.SelectedItem as string);
				}

				outputPathTextBox.Text = string.Empty;

				RefreshControlState();
			}
		}

		private void removeTrackButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = tracksListBox.SelectedIndex;

			if (selectedIndex != -1)
			{
				tracksListBox.Items.RemoveAt(selectedIndex);

				if (selectedIndex == tracksListBox.Items.Count)
				{
					// We've just deleted the bottom item in the list

					if (tracksListBox.Items.Count == 0)
					{
						inputFormatComboBox.SelectedIndex = -1;
					}
					else
					{
						tracksListBox.SelectedIndex = tracksListBox.Items.Count - 1;
					}
				}
				else
				{
					tracksListBox.SelectedIndex = selectedIndex;
				}

				outputPathTextBox.Text = string.Empty;

				RefreshControlState();
			}
		}

		private void convertButton_Click(object sender, EventArgs e)
		{
			if (ValidateTrackConversion())
			{
				this.Cursor = Cursors.WaitCursor;

				conversionProgressBar.Minimum = 0;
				conversionProgressBar.Maximum = tracksListBox.Items.Count;
				conversionProgressBar.Value = 0;

				conversionProgressBar.Visible = true;

				for (int index = 0; index < tracksListBox.Items.Count; index++)
				{
					tracksListBox.SelectedIndex = index;

					this.Refresh();

					string selectedFilePath = tracksListBox.SelectedItem as string;

					try
					{
						//BORIS
						//Geolocation.TrackConversion conversion = new Geolocation.TrackConversion(selectedFilePath, GetOutputFilePath(selectedFilePath), (inputFormatComboBox.SelectedItem as ColinBaker.Geolocation.Tracks.FileFormat).GetDecoder(), (outputFormatComboBox.SelectedItem as ColinBaker.Geolocation.Tracks.FileFormat).GetEncoder());
						Geolocation.TrackConversion2 conversion = new Geolocation.TrackConversion2(selectedFilePath, (inputFormatComboBox.SelectedItem as TrackFileFormatListItem).FileFormat, GetOutputFilePath(selectedFilePath), (outputFormatComboBox.SelectedItem as TrackFileFormatListItem).FileFormat);

						bool convert = true;

						if (System.IO.File.Exists(conversion.DestinationFilePath))
						{
							if (MessageBox.Show("The file " + conversion.DestinationFilePath + " already exists. Are you sure you want to overwrite this file?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
							{
								convert = false;
							}
						}

						if (convert)
						{
							//BORIS
							//conversion.SourceFileError += new EventHandler<Geolocation.TrackConversionEventArgs>(conversion_SourceFileError);

							//try
							//{
							//    conversion.Convert();
							//}
							//finally
							//{
							//    conversion.SourceFileError -= conversion_SourceFileError;
							//}

							conversion.Convert(ignoreFixErrorsCheckBox.Checked);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("The following error occurred converting the track " + selectedFilePath + ":\n\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

						if (index < tracksListBox.Items.Count - 1)
						{
							if (MessageBox.Show("Do you want to continue converting the remaining track(s)?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
							{
								break;
							}
						}
					}

					conversionProgressBar.Value = index + 1;
				}

				MessageBox.Show("Conversion complete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

				conversionProgressBar.Visible = false;

				this.Cursor = Cursors.Default;
			}
		}

		void conversion_SourceFileError(object sender, Geolocation.TrackConversionEventArgs e)
		{
			System.Text.StringBuilder message = new StringBuilder();

			message.Append("Invalid fix data was found when reading the track.");
			message.Append(Environment.NewLine);

			if (e.FileLineNumber != 0)
			{
				message.Append(Environment.NewLine);
				message.Append("Line number: ");
				message.Append(e.FileLineNumber);
			}

			if (!string.IsNullOrEmpty(e.SuspectData))
			{
				message.Append(Environment.NewLine);
				message.Append("Invalid data: ");
				message.Append(e.SuspectData);
			}

			message.Append(Environment.NewLine);
			message.Append(Environment.NewLine);

			message.Append("Would you like to ignore this data and continue?");

			if (MessageBox.Show(message.ToString(), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
			{
				e.SkipError = true;
			}
		}
	}
}
