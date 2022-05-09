namespace ColinBaker.Boris.UI
{
    partial class ExplorerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerControl));
            this.competitionTreeView = new System.Windows.Forms.TreeView();
            this.treeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editCompetitionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTaskMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTaskMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeImageList = new System.Windows.Forms.ImageList(this.components);
            this.editLeagueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // competitionTreeView
            // 
            this.competitionTreeView.ContextMenuStrip = this.treeContextMenuStrip;
            this.competitionTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.competitionTreeView.HideSelection = false;
            this.competitionTreeView.ImageIndex = 0;
            this.competitionTreeView.ImageList = this.treeImageList;
            this.competitionTreeView.Location = new System.Drawing.Point(0, 0);
            this.competitionTreeView.Name = "competitionTreeView";
            this.competitionTreeView.SelectedImageIndex = 0;
            this.competitionTreeView.ShowRootLines = false;
            this.competitionTreeView.Size = new System.Drawing.Size(259, 420);
            this.competitionTreeView.TabIndex = 0;
            this.competitionTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.competitionTreeView_BeforeCollapse);
            this.competitionTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.competitionTreeView_AfterSelect);
            this.competitionTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.competitionTreeView_NodeMouseClick);
            // 
            // treeContextMenuStrip
            // 
            this.treeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCompetitionMenuItem,
            this.editLeagueMenuItem,
            this.newTaskMenuItem,
            this.editTaskMenuItem});
            this.treeContextMenuStrip.Name = "treeContextMenuStrip";
            this.treeContextMenuStrip.Size = new System.Drawing.Size(165, 114);
            this.treeContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.treeContextMenuStrip_Opening);
            // 
            // editCompetitionMenuItem
            // 
            this.editCompetitionMenuItem.Name = "editCompetitionMenuItem";
            this.editCompetitionMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editCompetitionMenuItem.Text = "Edit Competition";
            this.editCompetitionMenuItem.Click += new System.EventHandler(this.editCompetitionMenuItem_Click);
            // 
            // newTaskMenuItem
            // 
            this.newTaskMenuItem.Name = "newTaskMenuItem";
            this.newTaskMenuItem.Size = new System.Drawing.Size(164, 22);
            this.newTaskMenuItem.Text = "New Task";
            this.newTaskMenuItem.Click += new System.EventHandler(this.newTaskMenuItem_Click);
            // 
            // editTaskMenuItem
            // 
            this.editTaskMenuItem.Name = "editTaskMenuItem";
            this.editTaskMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editTaskMenuItem.Text = "Edit Task";
            this.editTaskMenuItem.Click += new System.EventHandler(this.editTaskMenuItem_Click);
            // 
            // treeImageList
            // 
            this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
            this.treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImageList.Images.SetKeyName(0, "Competition");
            this.treeImageList.Images.SetKeyName(1, "Task");
            // 
            // editLeagueMenuItem
            // 
            this.editLeagueMenuItem.Name = "editLeagueMenuItem";
            this.editLeagueMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editLeagueMenuItem.Text = "Edit League";
            this.editLeagueMenuItem.Click += new System.EventHandler(this.editLeagueMenuItem_Click);
            // 
            // ExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.competitionTreeView);
            this.Name = "ExplorerControl";
            this.Size = new System.Drawing.Size(259, 420);
            this.treeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView competitionTreeView;
        private System.Windows.Forms.ContextMenuStrip treeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newTaskMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTaskMenuItem;
        private System.Windows.Forms.ImageList treeImageList;
		private System.Windows.Forms.ToolStripMenuItem editCompetitionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLeagueMenuItem;
    }
}
