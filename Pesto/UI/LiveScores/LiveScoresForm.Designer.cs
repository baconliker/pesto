
namespace ColinBaker.Pesto.UI.LiveScores
{
	partial class LiveScoresForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.scoresDataGridView = new System.Windows.Forms.DataGridView();
			this.PilotNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PilotNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TurnpointsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.displayUpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.aircraftClassLabel = new System.Windows.Forms.Label();
			this.loadTracksTimer = new System.Windows.Forms.Timer(this.components);
			this.liveMap = new ColinBaker.Pesto.UI.Map();
			((System.ComponentModel.ISupportInitialize)(this.scoresDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// scoresDataGridView
			// 
			this.scoresDataGridView.AllowUserToAddRows = false;
			this.scoresDataGridView.AllowUserToDeleteRows = false;
			this.scoresDataGridView.AllowUserToResizeRows = false;
			this.scoresDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scoresDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.scoresDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.scoresDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.scoresDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.scoresDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.scoresDataGridView.ColumnHeadersHeight = 22;
			this.scoresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.scoresDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PilotNumberColumn,
            this.PilotNameColumn,
            this.TurnpointsColumn});
			this.scoresDataGridView.Enabled = false;
			this.scoresDataGridView.Location = new System.Drawing.Point(901, 42);
			this.scoresDataGridView.MultiSelect = false;
			this.scoresDataGridView.Name = "scoresDataGridView";
			this.scoresDataGridView.ReadOnly = true;
			this.scoresDataGridView.RowHeadersVisible = false;
			this.scoresDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.scoresDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.scoresDataGridView.Size = new System.Drawing.Size(238, 643);
			this.scoresDataGridView.TabIndex = 1;
			// 
			// PilotNumberColumn
			// 
			this.PilotNumberColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.PilotNumberColumn.FillWeight = 45.68527F;
			this.PilotNumberColumn.HeaderText = "No";
			this.PilotNumberColumn.Name = "PilotNumberColumn";
			this.PilotNumberColumn.ReadOnly = true;
			this.PilotNumberColumn.Width = 36;
			// 
			// PilotNameColumn
			// 
			this.PilotNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.PilotNameColumn.FillWeight = 127.1573F;
			this.PilotNameColumn.HeaderText = "Pilot Name";
			this.PilotNameColumn.Name = "PilotNameColumn";
			this.PilotNameColumn.ReadOnly = true;
			// 
			// TurnpointsColumn
			// 
			this.TurnpointsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.TurnpointsColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.TurnpointsColumn.FillWeight = 127.1573F;
			this.TurnpointsColumn.HeaderText = "Turnpoints";
			this.TurnpointsColumn.Name = "TurnpointsColumn";
			this.TurnpointsColumn.ReadOnly = true;
			this.TurnpointsColumn.Width = 70;
			// 
			// displayUpdateTimer
			// 
			this.displayUpdateTimer.Interval = 10000;
			this.displayUpdateTimer.Tick += new System.EventHandler(this.displayUpdateTimer_Tick);
			// 
			// aircraftClassLabel
			// 
			this.aircraftClassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.aircraftClassLabel.AutoSize = true;
			this.aircraftClassLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.aircraftClassLabel.Location = new System.Drawing.Point(896, 9);
			this.aircraftClassLabel.Name = "aircraftClassLabel";
			this.aircraftClassLabel.Size = new System.Drawing.Size(111, 30);
			this.aircraftClassLabel.TabIndex = 2;
			this.aircraftClassLabel.Text = "Loading...";
			// 
			// loadTracksTimer
			// 
			this.loadTracksTimer.Interval = 600000;
			this.loadTracksTimer.Tick += new System.EventHandler(this.loadTracksTimer_Tick);
			// 
			// liveMap
			// 
			this.liveMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.liveMap.Location = new System.Drawing.Point(0, 0);
			this.liveMap.Name = "liveMap";
			this.liveMap.Size = new System.Drawing.Size(884, 696);
			this.liveMap.TabIndex = 0;
			this.liveMap.MapInitialized += new System.EventHandler(this.liveMap_MapInitialized);
			// 
			// LiveScoresForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1151, 697);
			this.Controls.Add(this.aircraftClassLabel);
			this.Controls.Add(this.scoresDataGridView);
			this.Controls.Add(this.liveMap);
			this.Name = "LiveScoresForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Live Scores";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LiveScoresForm_FormClosed);
			this.Load += new System.EventHandler(this.LiveScoresForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.scoresDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Map liveMap;
		private System.Windows.Forms.DataGridView scoresDataGridView;
		private System.Windows.Forms.Timer displayUpdateTimer;
		private System.Windows.Forms.Label aircraftClassLabel;
		private System.Windows.Forms.Timer loadTracksTimer;
		private System.Windows.Forms.DataGridViewTextBoxColumn PilotNumberColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn PilotNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn TurnpointsColumn;
	}
}