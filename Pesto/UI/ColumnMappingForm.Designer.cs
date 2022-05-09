namespace ColinBaker.Pesto.UI
{
	partial class ColumnMappingForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.mappingsDataGridView = new System.Windows.Forms.DataGridView();
			this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RequiredColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnNameColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.mappingsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// mappingsDataGridView
			// 
			this.mappingsDataGridView.AllowUserToAddRows = false;
			this.mappingsDataGridView.AllowUserToDeleteRows = false;
			this.mappingsDataGridView.AllowUserToResizeColumns = false;
			this.mappingsDataGridView.AllowUserToResizeRows = false;
			this.mappingsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mappingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.mappingsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.mappingsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.mappingsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.mappingsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.mappingsDataGridView.ColumnHeadersHeight = 22;
			this.mappingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.mappingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeColumn,
            this.RequiredColumn,
            this.ColumnNameColumn});
			this.mappingsDataGridView.Location = new System.Drawing.Point(12, 12);
			this.mappingsDataGridView.MultiSelect = false;
			this.mappingsDataGridView.Name = "mappingsDataGridView";
			this.mappingsDataGridView.RowHeadersVisible = false;
			this.mappingsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.mappingsDataGridView.Size = new System.Drawing.Size(307, 271);
			this.mappingsDataGridView.TabIndex = 0;
			this.mappingsDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.mappingsDataGridView_DataError);
			// 
			// TypeColumn
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.TypeColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.TypeColumn.HeaderText = "Type";
			this.TypeColumn.Name = "TypeColumn";
			this.TypeColumn.ReadOnly = true;
			// 
			// RequiredColumn
			// 
			this.RequiredColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.NullValue = false;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.RequiredColumn.DefaultCellStyle = dataGridViewCellStyle2;
			this.RequiredColumn.HeaderText = "Required";
			this.RequiredColumn.Name = "RequiredColumn";
			this.RequiredColumn.ReadOnly = true;
			this.RequiredColumn.Width = 60;
			// 
			// ColumnNameColumn
			// 
			this.ColumnNameColumn.HeaderText = "Spreadsheet Column";
			this.ColumnNameColumn.Name = "ColumnNameColumn";
			this.ColumnNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(224, 298);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(95, 24);
			this.cancelButton.TabIndex = 10;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(123, 298);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(95, 24);
			this.okButton.TabIndex = 9;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// ColumnMappingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 334);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.mappingsDataGridView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ColumnMappingForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Column Mapping";
			((System.ComponentModel.ISupportInitialize)(this.mappingsDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView mappingsDataGridView;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn RequiredColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn ColumnNameColumn;
	}
}