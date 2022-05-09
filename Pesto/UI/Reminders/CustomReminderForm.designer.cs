namespace ColinBaker.Pesto.UI.Reminders
{
	partial class CustomReminderForm
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
			this.descriptionLabel = new System.Windows.Forms.Label();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.dueLabel = new System.Windows.Forms.Label();
			this.dueDateTimePickerDate = new System.Windows.Forms.DateTimePicker();
			this.dueDateTimePickerTime = new System.Windows.Forms.DateTimePicker();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// descriptionLabel
			// 
			this.descriptionLabel.AutoSize = true;
			this.descriptionLabel.Location = new System.Drawing.Point(9, 9);
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
			this.descriptionLabel.TabIndex = 0;
			this.descriptionLabel.Text = "Description:";
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Location = new System.Drawing.Point(12, 25);
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.Size = new System.Drawing.Size(381, 20);
			this.descriptionTextBox.TabIndex = 1;
			// 
			// dueLabel
			// 
			this.dueLabel.AutoSize = true;
			this.dueLabel.Location = new System.Drawing.Point(9, 57);
			this.dueLabel.Name = "dueLabel";
			this.dueLabel.Size = new System.Drawing.Size(30, 13);
			this.dueLabel.TabIndex = 2;
			this.dueLabel.Text = "Due:";
			// 
			// dueDateTimePickerDate
			// 
			this.dueDateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dueDateTimePickerDate.Location = new System.Drawing.Point(12, 73);
			this.dueDateTimePickerDate.Name = "dueDateTimePickerDate";
			this.dueDateTimePickerDate.Size = new System.Drawing.Size(105, 20);
			this.dueDateTimePickerDate.TabIndex = 3;
			// 
			// dueDateTimePickerTime
			// 
			this.dueDateTimePickerTime.CustomFormat = "HH:mm";
			this.dueDateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dueDateTimePickerTime.Location = new System.Drawing.Point(123, 73);
			this.dueDateTimePickerTime.Name = "dueDateTimePickerTime";
			this.dueDateTimePickerTime.ShowUpDown = true;
			this.dueDateTimePickerTime.Size = new System.Drawing.Size(63, 20);
			this.dueDateTimePickerTime.TabIndex = 4;
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(211, 123);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(88, 22);
			this.okButton.TabIndex = 5;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(305, 123);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(88, 22);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// CustomReminderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 157);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.dueDateTimePickerTime);
			this.Controls.Add(this.dueDateTimePickerDate);
			this.Controls.Add(this.dueLabel);
			this.Controls.Add(this.descriptionTextBox);
			this.Controls.Add(this.descriptionLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomReminderForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Custom Reminder";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label descriptionLabel;
		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.Label dueLabel;
		private System.Windows.Forms.DateTimePicker dueDateTimePickerDate;
		private System.Windows.Forms.DateTimePicker dueDateTimePickerTime;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
	}
}