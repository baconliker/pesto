namespace ColinBaker.Pesto.UI.TrackAnalysis
{
	partial class AnalysisProgressForm
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
			this.analysisProgressBar = new System.Windows.Forms.ProgressBar();
			this.messageLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// analysisProgressBar
			// 
			this.analysisProgressBar.Location = new System.Drawing.Point(15, 51);
			this.analysisProgressBar.Name = "analysisProgressBar";
			this.analysisProgressBar.Size = new System.Drawing.Size(369, 17);
			this.analysisProgressBar.TabIndex = 3;
			// 
			// messageLabel
			// 
			this.messageLabel.AutoSize = true;
			this.messageLabel.Location = new System.Drawing.Point(12, 18);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Size = new System.Drawing.Size(147, 13);
			this.messageLabel.TabIndex = 2;
			this.messageLabel.Text = "Analysing track, please wait...";
			// 
			// AnalysisProgressForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 87);
			this.Controls.Add(this.analysisProgressBar);
			this.Controls.Add(this.messageLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AnalysisProgressForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Track Analysis";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar analysisProgressBar;
		private System.Windows.Forms.Label messageLabel;
	}
}