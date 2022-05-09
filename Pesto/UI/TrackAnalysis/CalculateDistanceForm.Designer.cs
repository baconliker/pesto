namespace ColinBaker.Pesto.UI.TrackAnalysis
{
    partial class CalculateDistanceForm
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
            this.directLineDistanceLabel = new System.Windows.Forms.Label();
            this.directLineDistanceTextBox = new System.Windows.Forms.TextBox();
            this.pilotDistanceLabel = new System.Windows.Forms.Label();
            this.pilotDistanceTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // directLineDistanceLabel
            // 
            this.directLineDistanceLabel.AutoSize = true;
            this.directLineDistanceLabel.Location = new System.Drawing.Point(32, 29);
            this.directLineDistanceLabel.Name = "directLineDistanceLabel";
            this.directLineDistanceLabel.Size = new System.Drawing.Size(384, 20);
            this.directLineDistanceLabel.TabIndex = 0;
            this.directLineDistanceLabel.Text = "Distance (direct line) between selected features (km):";
            // 
            // directLineDistanceTextBox
            // 
            this.directLineDistanceTextBox.Location = new System.Drawing.Point(36, 61);
            this.directLineDistanceTextBox.Name = "directLineDistanceTextBox";
            this.directLineDistanceTextBox.ReadOnly = true;
            this.directLineDistanceTextBox.Size = new System.Drawing.Size(143, 26);
            this.directLineDistanceTextBox.TabIndex = 1;
            // 
            // pilotDistanceLabel
            // 
            this.pilotDistanceLabel.AutoSize = true;
            this.pilotDistanceLabel.Location = new System.Drawing.Point(32, 136);
            this.pilotDistanceLabel.Name = "pilotDistanceLabel";
            this.pilotDistanceLabel.Size = new System.Drawing.Size(397, 20);
            this.pilotDistanceLabel.TabIndex = 2;
            this.pilotDistanceLabel.Text = "Distance flown by pilot between selected features (km):";
            // 
            // pilotDistanceTextBox
            // 
            this.pilotDistanceTextBox.Location = new System.Drawing.Point(36, 172);
            this.pilotDistanceTextBox.Name = "pilotDistanceTextBox";
            this.pilotDistanceTextBox.ReadOnly = true;
            this.pilotDistanceTextBox.Size = new System.Drawing.Size(143, 26);
            this.pilotDistanceTextBox.TabIndex = 3;
            // 
            // CalculateDistanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 237);
            this.Controls.Add(this.pilotDistanceTextBox);
            this.Controls.Add(this.pilotDistanceLabel);
            this.Controls.Add(this.directLineDistanceTextBox);
            this.Controls.Add(this.directLineDistanceLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculateDistanceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculate Distance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label directLineDistanceLabel;
        private System.Windows.Forms.TextBox directLineDistanceTextBox;
        private System.Windows.Forms.Label pilotDistanceLabel;
        private System.Windows.Forms.TextBox pilotDistanceTextBox;
    }
}