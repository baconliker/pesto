namespace ColinBaker.Pesto.UI
{
	partial class UpdateCheckForm
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
			this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
			this.downloadLabel = new System.Windows.Forms.Label();
			this.installButton = new System.Windows.Forms.Button();
			this.cancelCloseButton = new System.Windows.Forms.Button();
			this.updateSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// downloadProgressBar
			// 
			this.downloadProgressBar.Location = new System.Drawing.Point(12, 23);
			this.downloadProgressBar.Name = "downloadProgressBar";
			this.downloadProgressBar.Size = new System.Drawing.Size(387, 18);
			this.downloadProgressBar.TabIndex = 0;
			// 
			// downloadLabel
			// 
			this.downloadLabel.AutoSize = true;
			this.downloadLabel.Location = new System.Drawing.Point(9, 53);
			this.downloadLabel.Name = "downloadLabel";
			this.downloadLabel.Size = new System.Drawing.Size(0, 13);
			this.downloadLabel.TabIndex = 1;
			// 
			// installButton
			// 
			this.installButton.Enabled = false;
			this.installButton.Location = new System.Drawing.Point(213, 79);
			this.installButton.Name = "installButton";
			this.installButton.Size = new System.Drawing.Size(90, 23);
			this.installButton.TabIndex = 2;
			this.installButton.Text = "Install";
			this.installButton.UseVisualStyleBackColor = true;
			this.installButton.Click += new System.EventHandler(this.installButton_Click);
			// 
			// cancelCloseButton
			// 
			this.cancelCloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelCloseButton.Location = new System.Drawing.Point(309, 79);
			this.cancelCloseButton.Name = "cancelCloseButton";
			this.cancelCloseButton.Size = new System.Drawing.Size(90, 23);
			this.cancelCloseButton.TabIndex = 3;
			this.cancelCloseButton.Text = "Cancel";
			this.cancelCloseButton.UseVisualStyleBackColor = true;
			// 
			// updateSaveFileDialog
			// 
			this.updateSaveFileDialog.AddExtension = false;
			this.updateSaveFileDialog.Filter = "Windows Installer Files|*.msi|All Files|*.*";
			this.updateSaveFileDialog.Title = "Save File As";
			// 
			// UpdateCheckForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelCloseButton;
			this.ClientSize = new System.Drawing.Size(411, 114);
			this.Controls.Add(this.cancelCloseButton);
			this.Controls.Add(this.installButton);
			this.Controls.Add(this.downloadLabel);
			this.Controls.Add(this.downloadProgressBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdateCheckForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Download Update";
			this.Shown += new System.EventHandler(this.UpdateCheckForm_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar downloadProgressBar;
		private System.Windows.Forms.Label downloadLabel;
		private System.Windows.Forms.Button installButton;
		private System.Windows.Forms.Button cancelCloseButton;
		private System.Windows.Forms.SaveFileDialog updateSaveFileDialog;
	}
}