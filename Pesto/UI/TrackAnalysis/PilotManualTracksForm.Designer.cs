
namespace ColinBaker.Pesto.UI.TrackAnalysis
{
	partial class PilotManualTracksForm
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
			this.manualTracksListBox = new System.Windows.Forms.ListBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.removeButton = new System.Windows.Forms.Button();
			this.addManualTrackDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// manualTracksListBox
			// 
			this.manualTracksListBox.FormattingEnabled = true;
			this.manualTracksListBox.Location = new System.Drawing.Point(12, 12);
			this.manualTracksListBox.Name = "manualTracksListBox";
			this.manualTracksListBox.Size = new System.Drawing.Size(520, 160);
			this.manualTracksListBox.TabIndex = 0;
			this.manualTracksListBox.SelectedIndexChanged += new System.EventHandler(this.manualTracksListBox_SelectedIndexChanged);
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(550, 12);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(95, 24);
			this.okButton.TabIndex = 10;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(550, 42);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(95, 24);
			this.cancelButton.TabIndex = 11;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(550, 117);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(95, 24);
			this.addButton.TabIndex = 12;
			this.addButton.Text = "Add...";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// removeButton
			// 
			this.removeButton.Enabled = false;
			this.removeButton.Location = new System.Drawing.Point(550, 148);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(95, 24);
			this.removeButton.TabIndex = 13;
			this.removeButton.Text = "Remove";
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
			// 
			// addManualTrackDialog
			// 
			this.addManualTrackDialog.Filter = "IGC track files|*.igc;";
			this.addManualTrackDialog.Multiselect = true;
			this.addManualTrackDialog.Title = "Add Manual Track(s)";
			// 
			// PilotManualTracksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(657, 183);
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.manualTracksListBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PilotManualTracksForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Manual Tracks - ";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox manualTracksListBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.OpenFileDialog addManualTrackDialog;
	}
}