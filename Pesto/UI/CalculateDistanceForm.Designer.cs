namespace ColinBaker.Pesto.UI
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
            this.fromGroupBox = new System.Windows.Forms.GroupBox();
            this.fromLatitudeLabel = new System.Windows.Forms.Label();
            this.fromLatitudeTextBox = new System.Windows.Forms.TextBox();
            this.fromLongitudeTextBox = new System.Windows.Forms.TextBox();
            this.fromLongitudeLabel = new System.Windows.Forms.Label();
            this.toGroupBox = new System.Windows.Forms.GroupBox();
            this.toLongitudeTextBox = new System.Windows.Forms.TextBox();
            this.toLongitudeLabel = new System.Windows.Forms.Label();
            this.toLatitudeTextBox = new System.Windows.Forms.TextBox();
            this.toLatitudeLabel = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.fromGroupBox.SuspendLayout();
            this.toGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // fromGroupBox
            // 
            this.fromGroupBox.Controls.Add(this.fromLongitudeTextBox);
            this.fromGroupBox.Controls.Add(this.fromLongitudeLabel);
            this.fromGroupBox.Controls.Add(this.fromLatitudeTextBox);
            this.fromGroupBox.Controls.Add(this.fromLatitudeLabel);
            this.fromGroupBox.Location = new System.Drawing.Point(23, 12);
            this.fromGroupBox.Name = "fromGroupBox";
            this.fromGroupBox.Size = new System.Drawing.Size(188, 197);
            this.fromGroupBox.TabIndex = 0;
            this.fromGroupBox.TabStop = false;
            this.fromGroupBox.Text = "From";
            // 
            // fromLatitudeLabel
            // 
            this.fromLatitudeLabel.AutoSize = true;
            this.fromLatitudeLabel.Location = new System.Drawing.Point(13, 40);
            this.fromLatitudeLabel.Name = "fromLatitudeLabel";
            this.fromLatitudeLabel.Size = new System.Drawing.Size(71, 20);
            this.fromLatitudeLabel.TabIndex = 0;
            this.fromLatitudeLabel.Text = "Latitude:";
            // 
            // fromLatitudeTextBox
            // 
            this.fromLatitudeTextBox.Location = new System.Drawing.Point(17, 63);
            this.fromLatitudeTextBox.Name = "fromLatitudeTextBox";
            this.fromLatitudeTextBox.Size = new System.Drawing.Size(154, 26);
            this.fromLatitudeTextBox.TabIndex = 1;
            // 
            // fromLongitudeTextBox
            // 
            this.fromLongitudeTextBox.Location = new System.Drawing.Point(17, 134);
            this.fromLongitudeTextBox.Name = "fromLongitudeTextBox";
            this.fromLongitudeTextBox.Size = new System.Drawing.Size(154, 26);
            this.fromLongitudeTextBox.TabIndex = 3;
            // 
            // fromLongitudeLabel
            // 
            this.fromLongitudeLabel.AutoSize = true;
            this.fromLongitudeLabel.Location = new System.Drawing.Point(13, 111);
            this.fromLongitudeLabel.Name = "fromLongitudeLabel";
            this.fromLongitudeLabel.Size = new System.Drawing.Size(84, 20);
            this.fromLongitudeLabel.TabIndex = 2;
            this.fromLongitudeLabel.Text = "Longitude:";
            // 
            // toGroupBox
            // 
            this.toGroupBox.Controls.Add(this.toLongitudeTextBox);
            this.toGroupBox.Controls.Add(this.toLongitudeLabel);
            this.toGroupBox.Controls.Add(this.toLatitudeTextBox);
            this.toGroupBox.Controls.Add(this.toLatitudeLabel);
            this.toGroupBox.Location = new System.Drawing.Point(232, 12);
            this.toGroupBox.Name = "toGroupBox";
            this.toGroupBox.Size = new System.Drawing.Size(188, 197);
            this.toGroupBox.TabIndex = 1;
            this.toGroupBox.TabStop = false;
            this.toGroupBox.Text = "To";
            // 
            // toLongitudeTextBox
            // 
            this.toLongitudeTextBox.Location = new System.Drawing.Point(17, 134);
            this.toLongitudeTextBox.Name = "toLongitudeTextBox";
            this.toLongitudeTextBox.Size = new System.Drawing.Size(154, 26);
            this.toLongitudeTextBox.TabIndex = 3;
            // 
            // toLongitudeLabel
            // 
            this.toLongitudeLabel.AutoSize = true;
            this.toLongitudeLabel.Location = new System.Drawing.Point(13, 111);
            this.toLongitudeLabel.Name = "toLongitudeLabel";
            this.toLongitudeLabel.Size = new System.Drawing.Size(84, 20);
            this.toLongitudeLabel.TabIndex = 2;
            this.toLongitudeLabel.Text = "Longitude:";
            // 
            // toLatitudeTextBox
            // 
            this.toLatitudeTextBox.Location = new System.Drawing.Point(17, 63);
            this.toLatitudeTextBox.Name = "toLatitudeTextBox";
            this.toLatitudeTextBox.Size = new System.Drawing.Size(154, 26);
            this.toLatitudeTextBox.TabIndex = 1;
            // 
            // toLatitudeLabel
            // 
            this.toLatitudeLabel.AutoSize = true;
            this.toLatitudeLabel.Location = new System.Drawing.Point(13, 40);
            this.toLatitudeLabel.Name = "toLatitudeLabel";
            this.toLatitudeLabel.Size = new System.Drawing.Size(71, 20);
            this.toLatitudeLabel.TabIndex = 0;
            this.toLatitudeLabel.Text = "Latitude:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(280, 262);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(140, 35);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // CalculateDistanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 321);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.toGroupBox);
            this.Controls.Add(this.fromGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculateDistanceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculate Distance";
            this.fromGroupBox.ResumeLayout(false);
            this.fromGroupBox.PerformLayout();
            this.toGroupBox.ResumeLayout(false);
            this.toGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox fromGroupBox;
        private System.Windows.Forms.TextBox fromLongitudeTextBox;
        private System.Windows.Forms.Label fromLongitudeLabel;
        private System.Windows.Forms.TextBox fromLatitudeTextBox;
        private System.Windows.Forms.Label fromLatitudeLabel;
        private System.Windows.Forms.GroupBox toGroupBox;
        private System.Windows.Forms.TextBox toLongitudeTextBox;
        private System.Windows.Forms.Label toLongitudeLabel;
        private System.Windows.Forms.TextBox toLatitudeTextBox;
        private System.Windows.Forms.Label toLatitudeLabel;
        private System.Windows.Forms.Button btnCalculate;
    }
}