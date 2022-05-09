namespace ColinBaker.Pesto.UI.TrackAnalysis
{
	partial class KmlOptionsForm
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
			this.fixDataCheckBox = new System.Windows.Forms.CheckBox();
			this.clampToGroundCheckBox = new System.Windows.Forms.CheckBox();
			this.clampToGroundLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.featuresCheckBox = new System.Windows.Forms.CheckBox();
			this.eventsCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// fixDataCheckBox
			// 
			this.fixDataCheckBox.AutoSize = true;
			this.fixDataCheckBox.Checked = true;
			this.fixDataCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fixDataCheckBox.Location = new System.Drawing.Point(12, 12);
			this.fixDataCheckBox.Name = "fixDataCheckBox";
			this.fixDataCheckBox.Size = new System.Drawing.Size(167, 17);
			this.fixDataCheckBox.TabIndex = 0;
			this.fixDataCheckBox.Text = "Include data for each track fix";
			this.fixDataCheckBox.UseVisualStyleBackColor = true;
			// 
			// clampToGroundCheckBox
			// 
			this.clampToGroundCheckBox.AutoSize = true;
			this.clampToGroundCheckBox.Checked = true;
			this.clampToGroundCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clampToGroundCheckBox.Location = new System.Drawing.Point(12, 42);
			this.clampToGroundCheckBox.Name = "clampToGroundCheckBox";
			this.clampToGroundCheckBox.Size = new System.Drawing.Size(130, 17);
			this.clampToGroundCheckBox.TabIndex = 1;
			this.clampToGroundCheckBox.Text = "Clamp track to ground";
			this.clampToGroundCheckBox.UseVisualStyleBackColor = true;
			// 
			// clampToGroundLabel
			// 
			this.clampToGroundLabel.AutoSize = true;
			this.clampToGroundLabel.Location = new System.Drawing.Point(8, 62);
			this.clampToGroundLabel.Name = "clampToGroundLabel";
			this.clampToGroundLabel.Size = new System.Drawing.Size(328, 13);
			this.clampToGroundLabel.TabIndex = 2;
			this.clampToGroundLabel.Text = "Do not choose clamp to ground if you want to examine track altitude";
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(241, 170);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(95, 24);
			this.cancelButton.TabIndex = 14;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(140, 170);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(95, 24);
			this.okButton.TabIndex = 13;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// featuresCheckBox
			// 
			this.featuresCheckBox.AutoSize = true;
			this.featuresCheckBox.Location = new System.Drawing.Point(12, 88);
			this.featuresCheckBox.Name = "featuresCheckBox";
			this.featuresCheckBox.Size = new System.Drawing.Size(102, 17);
			this.featuresCheckBox.TabIndex = 15;
			this.featuresCheckBox.Text = "Include features";
			this.featuresCheckBox.UseVisualStyleBackColor = true;
			// 
			// eventsCheckBox
			// 
			this.eventsCheckBox.AutoSize = true;
			this.eventsCheckBox.Location = new System.Drawing.Point(12, 118);
			this.eventsCheckBox.Name = "eventsCheckBox";
			this.eventsCheckBox.Size = new System.Drawing.Size(96, 17);
			this.eventsCheckBox.TabIndex = 16;
			this.eventsCheckBox.Text = "Include events";
			this.eventsCheckBox.UseVisualStyleBackColor = true;
			// 
			// KmlOptionsForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(348, 206);
			this.Controls.Add(this.eventsCheckBox);
			this.Controls.Add(this.featuresCheckBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.clampToGroundLabel);
			this.Controls.Add(this.clampToGroundCheckBox);
			this.Controls.Add(this.fixDataCheckBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "KmlOptionsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "KML Options";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox fixDataCheckBox;
		private System.Windows.Forms.CheckBox clampToGroundCheckBox;
		private System.Windows.Forms.Label clampToGroundLabel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox featuresCheckBox;
		private System.Windows.Forms.CheckBox eventsCheckBox;
	}
}