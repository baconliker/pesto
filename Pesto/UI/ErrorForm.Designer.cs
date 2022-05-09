namespace ColinBaker.Pesto.UI
{
    partial class ErrorForm
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
			this.messageLabel = new System.Windows.Forms.Label();
			this.stackTraceTextBox = new System.Windows.Forms.TextBox();
			this.exitButton = new System.Windows.Forms.Button();
			this.messageTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// messageLabel
			// 
			this.messageLabel.AutoSize = true;
			this.messageLabel.Location = new System.Drawing.Point(12, 20);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Size = new System.Drawing.Size(234, 13);
			this.messageLabel.TabIndex = 0;
			this.messageLabel.Text = "Oops, something went wrong. Here\'s the details:";
			// 
			// stackTraceTextBox
			// 
			this.stackTraceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.stackTraceTextBox.Location = new System.Drawing.Point(12, 115);
			this.stackTraceTextBox.Multiline = true;
			this.stackTraceTextBox.Name = "stackTraceTextBox";
			this.stackTraceTextBox.ReadOnly = true;
			this.stackTraceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.stackTraceTextBox.Size = new System.Drawing.Size(432, 244);
			this.stackTraceTextBox.TabIndex = 1;
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exitButton.Location = new System.Drawing.Point(358, 376);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(86, 24);
			this.exitButton.TabIndex = 2;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// messageTextBox
			// 
			this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messageTextBox.Location = new System.Drawing.Point(12, 51);
			this.messageTextBox.Multiline = true;
			this.messageTextBox.Name = "messageTextBox";
			this.messageTextBox.ReadOnly = true;
			this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.messageTextBox.Size = new System.Drawing.Size(432, 58);
			this.messageTextBox.TabIndex = 3;
			// 
			// ErrorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 412);
			this.Controls.Add(this.messageTextBox);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.stackTraceTextBox);
			this.Controls.Add(this.messageLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ErrorForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Error";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox stackTraceTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox messageTextBox;
    }
}