namespace ColinBaker.Pesto.UI
{
	partial class TrackConversionForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.inputFormatLabel = new System.Windows.Forms.Label();
			this.inputFormatComboBox = new System.Windows.Forms.ComboBox();
			this.outputFormatLabel = new System.Windows.Forms.Label();
			this.outputFormatComboBox = new System.Windows.Forms.ComboBox();
			this.outputPathLabel = new System.Windows.Forms.Label();
			this.outputPathTextBox = new System.Windows.Forms.TextBox();
			this.outputPathButton = new System.Windows.Forms.Button();
			this.conversionProgressBar = new System.Windows.Forms.ProgressBar();
			this.addTracksButton = new System.Windows.Forms.Button();
			this.removeTrackButton = new System.Windows.Forms.Button();
			this.convertButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.tracksListBox = new System.Windows.Forms.ListBox();
			this.selectTracksOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.outputPathSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.outputPathFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.ignoreFixErrorsCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// inputFormatLabel
			// 
			this.inputFormatLabel.AutoSize = true;
			this.inputFormatLabel.Location = new System.Drawing.Point(9, 317);
			this.inputFormatLabel.Name = "inputFormatLabel";
			this.inputFormatLabel.Size = new System.Drawing.Size(66, 13);
			this.inputFormatLabel.TabIndex = 1;
			this.inputFormatLabel.Text = "Input format:";
			// 
			// inputFormatComboBox
			// 
			this.inputFormatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inputFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputFormatComboBox.FormattingEnabled = true;
			this.inputFormatComboBox.Location = new System.Drawing.Point(113, 314);
			this.inputFormatComboBox.Name = "inputFormatComboBox";
			this.inputFormatComboBox.Size = new System.Drawing.Size(393, 21);
			this.inputFormatComboBox.TabIndex = 2;
			// 
			// outputFormatLabel
			// 
			this.outputFormatLabel.AutoSize = true;
			this.outputFormatLabel.Location = new System.Drawing.Point(9, 344);
			this.outputFormatLabel.Name = "outputFormatLabel";
			this.outputFormatLabel.Size = new System.Drawing.Size(74, 13);
			this.outputFormatLabel.TabIndex = 3;
			this.outputFormatLabel.Text = "Output format:";
			// 
			// outputFormatComboBox
			// 
			this.outputFormatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.outputFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.outputFormatComboBox.FormattingEnabled = true;
			this.outputFormatComboBox.Location = new System.Drawing.Point(113, 341);
			this.outputFormatComboBox.Name = "outputFormatComboBox";
			this.outputFormatComboBox.Size = new System.Drawing.Size(393, 21);
			this.outputFormatComboBox.TabIndex = 4;
			// 
			// outputPathLabel
			// 
			this.outputPathLabel.AutoSize = true;
			this.outputPathLabel.Location = new System.Drawing.Point(9, 371);
			this.outputPathLabel.Name = "outputPathLabel";
			this.outputPathLabel.Size = new System.Drawing.Size(66, 13);
			this.outputPathLabel.TabIndex = 5;
			this.outputPathLabel.Text = "Output path:";
			// 
			// outputPathTextBox
			// 
			this.outputPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.outputPathTextBox.Location = new System.Drawing.Point(113, 368);
			this.outputPathTextBox.Name = "outputPathTextBox";
			this.outputPathTextBox.ReadOnly = true;
			this.outputPathTextBox.Size = new System.Drawing.Size(314, 20);
			this.outputPathTextBox.TabIndex = 6;
			// 
			// outputPathButton
			// 
			this.outputPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.outputPathButton.Location = new System.Drawing.Point(433, 365);
			this.outputPathButton.Name = "outputPathButton";
			this.outputPathButton.Size = new System.Drawing.Size(73, 24);
			this.outputPathButton.TabIndex = 7;
			this.outputPathButton.Text = "Choose...";
			this.outputPathButton.UseVisualStyleBackColor = true;
			this.outputPathButton.Click += new System.EventHandler(this.outputPathButton_Click);
			// 
			// conversionProgressBar
			// 
			this.conversionProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.conversionProgressBar.Location = new System.Drawing.Point(12, 414);
			this.conversionProgressBar.Name = "conversionProgressBar";
			this.conversionProgressBar.Size = new System.Drawing.Size(494, 18);
			this.conversionProgressBar.TabIndex = 8;
			this.conversionProgressBar.Visible = false;
			// 
			// addTracksButton
			// 
			this.addTracksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.addTracksButton.Location = new System.Drawing.Point(112, 438);
			this.addTracksButton.Name = "addTracksButton";
			this.addTracksButton.Size = new System.Drawing.Size(94, 24);
			this.addTracksButton.TabIndex = 9;
			this.addTracksButton.Text = "Add Track(s)";
			this.addTracksButton.UseVisualStyleBackColor = true;
			this.addTracksButton.Click += new System.EventHandler(this.addTracksButton_Click);
			// 
			// removeTrackButton
			// 
			this.removeTrackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.removeTrackButton.Location = new System.Drawing.Point(212, 438);
			this.removeTrackButton.Name = "removeTrackButton";
			this.removeTrackButton.Size = new System.Drawing.Size(94, 24);
			this.removeTrackButton.TabIndex = 10;
			this.removeTrackButton.Text = "Remove Track";
			this.removeTrackButton.UseVisualStyleBackColor = true;
			this.removeTrackButton.Click += new System.EventHandler(this.removeTrackButton_Click);
			// 
			// convertButton
			// 
			this.convertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.convertButton.Location = new System.Drawing.Point(312, 438);
			this.convertButton.Name = "convertButton";
			this.convertButton.Size = new System.Drawing.Size(94, 24);
			this.convertButton.TabIndex = 11;
			this.convertButton.Text = "Convert";
			this.convertButton.UseVisualStyleBackColor = true;
			this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.closeButton.Location = new System.Drawing.Point(412, 438);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(94, 24);
			this.closeButton.TabIndex = 12;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			// 
			// tracksListBox
			// 
			this.tracksListBox.FormattingEnabled = true;
			this.tracksListBox.Location = new System.Drawing.Point(12, 12);
			this.tracksListBox.Name = "tracksListBox";
			this.tracksListBox.Size = new System.Drawing.Size(499, 290);
			this.tracksListBox.TabIndex = 13;
			// 
			// selectTracksOpenFileDialog
			// 
			this.selectTracksOpenFileDialog.Filter = "Track files|*.nmea;*.log;*.gpx;*.igc|All files|*.*";
			this.selectTracksOpenFileDialog.Multiselect = true;
			this.selectTracksOpenFileDialog.Title = "Select Track(s) to Convert";
			// 
			// outputPathSaveFileDialog
			// 
			this.outputPathSaveFileDialog.OverwritePrompt = false;
			// 
			// ignoreFixErrorsCheckBox
			// 
			this.ignoreFixErrorsCheckBox.AutoSize = true;
			this.ignoreFixErrorsCheckBox.Location = new System.Drawing.Point(113, 394);
			this.ignoreFixErrorsCheckBox.Name = "ignoreFixErrorsCheckBox";
			this.ignoreFixErrorsCheckBox.Size = new System.Drawing.Size(98, 17);
			this.ignoreFixErrorsCheckBox.TabIndex = 14;
			this.ignoreFixErrorsCheckBox.Text = "Ignore fix errors";
			this.ignoreFixErrorsCheckBox.UseVisualStyleBackColor = true;
			// 
			// TrackConversionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.closeButton;
			this.ClientSize = new System.Drawing.Size(518, 474);
			this.Controls.Add(this.ignoreFixErrorsCheckBox);
			this.Controls.Add(this.tracksListBox);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.convertButton);
			this.Controls.Add(this.removeTrackButton);
			this.Controls.Add(this.addTracksButton);
			this.Controls.Add(this.conversionProgressBar);
			this.Controls.Add(this.outputPathButton);
			this.Controls.Add(this.outputPathTextBox);
			this.Controls.Add(this.outputPathLabel);
			this.Controls.Add(this.outputFormatComboBox);
			this.Controls.Add(this.outputFormatLabel);
			this.Controls.Add(this.inputFormatComboBox);
			this.Controls.Add(this.inputFormatLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrackConversionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Convert Track(s)";
			this.Load += new System.EventHandler(this.TrackConversionForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label inputFormatLabel;
		private System.Windows.Forms.ComboBox inputFormatComboBox;
		private System.Windows.Forms.Label outputFormatLabel;
		private System.Windows.Forms.ComboBox outputFormatComboBox;
		private System.Windows.Forms.Label outputPathLabel;
		private System.Windows.Forms.TextBox outputPathTextBox;
		private System.Windows.Forms.Button outputPathButton;
		private System.Windows.Forms.ProgressBar conversionProgressBar;
		private System.Windows.Forms.Button addTracksButton;
		private System.Windows.Forms.Button removeTrackButton;
		private System.Windows.Forms.Button convertButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.ListBox tracksListBox;
		private System.Windows.Forms.OpenFileDialog selectTracksOpenFileDialog;
		private System.Windows.Forms.SaveFileDialog outputPathSaveFileDialog;
		private System.Windows.Forms.FolderBrowserDialog outputPathFolderBrowserDialog;
		private System.Windows.Forms.CheckBox ignoreFixErrorsCheckBox;
	}
}