namespace ColinBaker.Pesto.UI.Reminders
{
	partial class RemindersForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindersForm));
            this.remindersListView = new System.Windows.Forms.ListView();
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remindersImageList = new System.Windows.Forms.ImageList(this.components);
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.overduePanel = new System.Windows.Forms.Panel();
            this.dismissButton = new System.Windows.Forms.Button();
            this.snoozeButton = new System.Windows.Forms.Button();
            this.snoozeComboBox = new System.Windows.Forms.ComboBox();
            this.snoozeLabel = new System.Windows.Forms.Label();
            this.notOverduePanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.overduePanel.SuspendLayout();
            this.notOverduePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // remindersListView
            // 
            this.remindersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remindersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescription,
            this.colDue});
            this.remindersListView.FullRowSelect = true;
            this.remindersListView.HideSelection = false;
            this.remindersListView.Location = new System.Drawing.Point(18, 60);
            this.remindersListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.remindersListView.MultiSelect = false;
            this.remindersListView.Name = "remindersListView";
            this.remindersListView.Size = new System.Drawing.Size(628, 332);
            this.remindersListView.SmallImageList = this.remindersImageList;
            this.remindersListView.TabIndex = 0;
            this.remindersListView.UseCompatibleStateImageBehavior = false;
            this.remindersListView.View = System.Windows.Forms.View.Details;
            this.remindersListView.SelectedIndexChanged += new System.EventHandler(this.remindersListView_SelectedIndexChanged);
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 290;
            // 
            // colDue
            // 
            this.colDue.Text = "Due";
            this.colDue.Width = 105;
            // 
            // remindersImageList
            // 
            this.remindersImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("remindersImageList.ImageStream")));
            this.remindersImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.remindersImageList.Images.SetKeyName(0, "Bell");
            // 
            // filterComboBox
            // 
            this.filterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Location = new System.Drawing.Point(18, 18);
            this.filterComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(250, 28);
            this.filterComboBox.TabIndex = 4;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // overduePanel
            // 
            this.overduePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overduePanel.Controls.Add(this.dismissButton);
            this.overduePanel.Controls.Add(this.snoozeButton);
            this.overduePanel.Controls.Add(this.snoozeComboBox);
            this.overduePanel.Controls.Add(this.snoozeLabel);
            this.overduePanel.Location = new System.Drawing.Point(18, 403);
            this.overduePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.overduePanel.Name = "overduePanel";
            this.overduePanel.Size = new System.Drawing.Size(630, 57);
            this.overduePanel.TabIndex = 5;
            this.overduePanel.Visible = false;
            // 
            // dismissButton
            // 
            this.dismissButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dismissButton.Location = new System.Drawing.Point(488, 20);
            this.dismissButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dismissButton.Name = "dismissButton";
            this.dismissButton.Size = new System.Drawing.Size(142, 37);
            this.dismissButton.TabIndex = 6;
            this.dismissButton.Text = "Dismiss";
            this.dismissButton.UseVisualStyleBackColor = true;
            this.dismissButton.Click += new System.EventHandler(this.dismissButton_Click);
            // 
            // snoozeButton
            // 
            this.snoozeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.snoozeButton.Location = new System.Drawing.Point(336, 20);
            this.snoozeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.snoozeButton.Name = "snoozeButton";
            this.snoozeButton.Size = new System.Drawing.Size(142, 37);
            this.snoozeButton.TabIndex = 5;
            this.snoozeButton.Text = "Snooze";
            this.snoozeButton.UseVisualStyleBackColor = true;
            this.snoozeButton.Click += new System.EventHandler(this.snoozeButton_Click);
            // 
            // snoozeComboBox
            // 
            this.snoozeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.snoozeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.snoozeComboBox.FormattingEnabled = true;
            this.snoozeComboBox.Location = new System.Drawing.Point(0, 25);
            this.snoozeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.snoozeComboBox.Name = "snoozeComboBox";
            this.snoozeComboBox.Size = new System.Drawing.Size(325, 28);
            this.snoozeComboBox.TabIndex = 1;
            // 
            // snoozeLabel
            // 
            this.snoozeLabel.AutoSize = true;
            this.snoozeLabel.Location = new System.Drawing.Point(-4, 0);
            this.snoozeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.snoozeLabel.Name = "snoozeLabel";
            this.snoozeLabel.Size = new System.Drawing.Size(110, 20);
            this.snoozeLabel.TabIndex = 0;
            this.snoozeLabel.Text = "Remind me in:";
            // 
            // notOverduePanel
            // 
            this.notOverduePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notOverduePanel.Controls.Add(this.deleteButton);
            this.notOverduePanel.Controls.Add(this.addButton);
            this.notOverduePanel.Location = new System.Drawing.Point(18, 403);
            this.notOverduePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.notOverduePanel.Name = "notOverduePanel";
            this.notOverduePanel.Size = new System.Drawing.Size(630, 57);
            this.notOverduePanel.TabIndex = 6;
            this.notOverduePanel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(488, 20);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(142, 37);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(336, 20);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(142, 37);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // RemindersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 478);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.remindersListView);
            this.Controls.Add(this.overduePanel);
            this.Controls.Add(this.notOverduePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RemindersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reminders";
            this.overduePanel.ResumeLayout(false);
            this.overduePanel.PerformLayout();
            this.notOverduePanel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView remindersListView;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.ColumnHeader colDue;
		private System.Windows.Forms.ComboBox filterComboBox;
		private System.Windows.Forms.ImageList remindersImageList;
		private System.Windows.Forms.Panel overduePanel;
		private System.Windows.Forms.Button snoozeButton;
		private System.Windows.Forms.ComboBox snoozeComboBox;
		private System.Windows.Forms.Label snoozeLabel;
		private System.Windows.Forms.Panel notOverduePanel;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button dismissButton;
	}
}