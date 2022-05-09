namespace ColinBaker.Pesto.UI.TrackAnalysis
{
    partial class EventFilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventFilterForm));
            this.filterTreeView = new System.Windows.Forms.TreeView();
            this.filterTreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filterTreeView
            // 
            this.filterTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTreeView.CheckBoxes = true;
            this.filterTreeView.ImageIndex = 0;
            this.filterTreeView.ImageList = this.filterTreeViewImageList;
            this.filterTreeView.Location = new System.Drawing.Point(12, 12);
            this.filterTreeView.Name = "filterTreeView";
            this.filterTreeView.SelectedImageIndex = 0;
            this.filterTreeView.Size = new System.Drawing.Size(631, 454);
            this.filterTreeView.TabIndex = 0;
            this.filterTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.filterTreeView_AfterCheck);
            // 
            // filterTreeViewImageList
            // 
            this.filterTreeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("filterTreeViewImageList.ImageStream")));
            this.filterTreeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.filterTreeViewImageList.Images.SetKeyName(0, "Folder");
            this.filterTreeViewImageList.Images.SetKeyName(1, "Information");
            this.filterTreeViewImageList.Images.SetKeyName(2, "Achievement");
            this.filterTreeViewImageList.Images.SetKeyName(3, "Warning");
            this.filterTreeViewImageList.Images.SetKeyName(4, "Failure");
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(363, 480);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(137, 34);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(506, 480);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(137, 34);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // EventFilterForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 526);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.filterTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter Events";
            this.Load += new System.EventHandler(this.EventFilterForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView filterTreeView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ImageList filterTreeViewImageList;
    }
}