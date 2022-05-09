namespace Test
{
	partial class MainForm
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
			this.calculateDistanceGroupBox = new System.Windows.Forms.GroupBox();
			this.calculateDistanceButton = new System.Windows.Forms.Button();
			this.longitude2TextBox = new System.Windows.Forms.TextBox();
			this.longitude2Label = new System.Windows.Forms.Label();
			this.latitude2TextBox = new System.Windows.Forms.TextBox();
			this.latitude2Label = new System.Windows.Forms.Label();
			this.longitude1TextBox = new System.Windows.Forms.TextBox();
			this.longitude1Label = new System.Windows.Forms.Label();
			this.latitude1TextBox = new System.Windows.Forms.TextBox();
			this.latitude1Label = new System.Windows.Forms.Label();
			this.calculateDistanceGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// calculateDistanceGroupBox
			// 
			this.calculateDistanceGroupBox.Controls.Add(this.calculateDistanceButton);
			this.calculateDistanceGroupBox.Controls.Add(this.longitude2TextBox);
			this.calculateDistanceGroupBox.Controls.Add(this.longitude2Label);
			this.calculateDistanceGroupBox.Controls.Add(this.latitude2TextBox);
			this.calculateDistanceGroupBox.Controls.Add(this.latitude2Label);
			this.calculateDistanceGroupBox.Controls.Add(this.longitude1TextBox);
			this.calculateDistanceGroupBox.Controls.Add(this.longitude1Label);
			this.calculateDistanceGroupBox.Controls.Add(this.latitude1TextBox);
			this.calculateDistanceGroupBox.Controls.Add(this.latitude1Label);
			this.calculateDistanceGroupBox.Location = new System.Drawing.Point(12, 12);
			this.calculateDistanceGroupBox.Name = "calculateDistanceGroupBox";
			this.calculateDistanceGroupBox.Size = new System.Drawing.Size(349, 148);
			this.calculateDistanceGroupBox.TabIndex = 0;
			this.calculateDistanceGroupBox.TabStop = false;
			this.calculateDistanceGroupBox.Text = "Calculate Distance";
			// 
			// calculateDistanceButton
			// 
			this.calculateDistanceButton.Location = new System.Drawing.Point(236, 106);
			this.calculateDistanceButton.Name = "calculateDistanceButton";
			this.calculateDistanceButton.Size = new System.Drawing.Size(97, 25);
			this.calculateDistanceButton.TabIndex = 8;
			this.calculateDistanceButton.Text = "Calculate";
			this.calculateDistanceButton.UseVisualStyleBackColor = true;
			this.calculateDistanceButton.Click += new System.EventHandler(this.calculateDistanceButton_Click);
			// 
			// longitude2TextBox
			// 
			this.longitude2TextBox.Location = new System.Drawing.Point(258, 54);
			this.longitude2TextBox.Name = "longitude2TextBox";
			this.longitude2TextBox.Size = new System.Drawing.Size(75, 20);
			this.longitude2TextBox.TabIndex = 7;
			this.longitude2TextBox.Text = "-0.740479";
			// 
			// longitude2Label
			// 
			this.longitude2Label.AutoSize = true;
			this.longitude2Label.Location = new System.Drawing.Point(195, 57);
			this.longitude2Label.Name = "longitude2Label";
			this.longitude2Label.Size = new System.Drawing.Size(57, 13);
			this.longitude2Label.TabIndex = 6;
			this.longitude2Label.Text = "Longitude:";
			// 
			// latitude2TextBox
			// 
			this.latitude2TextBox.Location = new System.Drawing.Point(258, 28);
			this.latitude2TextBox.Name = "latitude2TextBox";
			this.latitude2TextBox.Size = new System.Drawing.Size(75, 20);
			this.latitude2TextBox.TabIndex = 5;
			this.latitude2TextBox.Text = "51.511663";
			// 
			// latitude2Label
			// 
			this.latitude2Label.AutoSize = true;
			this.latitude2Label.Location = new System.Drawing.Point(195, 31);
			this.latitude2Label.Name = "latitude2Label";
			this.latitude2Label.Size = new System.Drawing.Size(48, 13);
			this.latitude2Label.TabIndex = 4;
			this.latitude2Label.Text = "Latitude:";
			// 
			// longitude1TextBox
			// 
			this.longitude1TextBox.Location = new System.Drawing.Point(80, 54);
			this.longitude1TextBox.Name = "longitude1TextBox";
			this.longitude1TextBox.Size = new System.Drawing.Size(75, 20);
			this.longitude1TextBox.TabIndex = 3;
			this.longitude1TextBox.Text = "-0.735876";
			// 
			// longitude1Label
			// 
			this.longitude1Label.AutoSize = true;
			this.longitude1Label.Location = new System.Drawing.Point(17, 57);
			this.longitude1Label.Name = "longitude1Label";
			this.longitude1Label.Size = new System.Drawing.Size(57, 13);
			this.longitude1Label.TabIndex = 2;
			this.longitude1Label.Text = "Longitude:";
			// 
			// latitude1TextBox
			// 
			this.latitude1TextBox.Location = new System.Drawing.Point(80, 28);
			this.latitude1TextBox.Name = "latitude1TextBox";
			this.latitude1TextBox.Size = new System.Drawing.Size(75, 20);
			this.latitude1TextBox.TabIndex = 1;
			this.latitude1TextBox.Text = "51.511576";
			// 
			// latitude1Label
			// 
			this.latitude1Label.AutoSize = true;
			this.latitude1Label.Location = new System.Drawing.Point(17, 31);
			this.latitude1Label.Name = "latitude1Label";
			this.latitude1Label.Size = new System.Drawing.Size(48, 13);
			this.latitude1Label.TabIndex = 0;
			this.latitude1Label.Text = "Latitude:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 297);
			this.Controls.Add(this.calculateDistanceGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Location Test";
			this.calculateDistanceGroupBox.ResumeLayout(false);
			this.calculateDistanceGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox calculateDistanceGroupBox;
		private System.Windows.Forms.Button calculateDistanceButton;
		private System.Windows.Forms.TextBox longitude2TextBox;
		private System.Windows.Forms.Label longitude2Label;
		private System.Windows.Forms.TextBox latitude2TextBox;
		private System.Windows.Forms.Label latitude2Label;
		private System.Windows.Forms.TextBox longitude1TextBox;
		private System.Windows.Forms.Label longitude1Label;
		private System.Windows.Forms.TextBox latitude1TextBox;
		private System.Windows.Forms.Label latitude1Label;
	}
}

