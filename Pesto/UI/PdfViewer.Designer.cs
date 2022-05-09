namespace ColinBaker.Pesto.UI
{
    partial class PdfViewer
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
            this.pdfPrintDialog = new System.Windows.Forms.PrintDialog();
            this.unableToDisplayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pdfPrintDialog
            // 
            this.pdfPrintDialog.AllowCurrentPage = true;
            this.pdfPrintDialog.AllowPrintToFile = false;
            this.pdfPrintDialog.AllowSomePages = true;
            this.pdfPrintDialog.UseEXDialog = true;
            // 
            // unableToDisplayLabel
            // 
            this.unableToDisplayLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unableToDisplayLabel.Location = new System.Drawing.Point(0, 0);
            this.unableToDisplayLabel.Name = "unableToDisplayLabel";
            this.unableToDisplayLabel.Size = new System.Drawing.Size(150, 150);
            this.unableToDisplayLabel.TabIndex = 0;
            this.unableToDisplayLabel.Text = "Unable to display PDF";
            this.unableToDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.unableToDisplayLabel.Visible = false;
            // 
            // PdfViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unableToDisplayLabel);
            this.Name = "PdfViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog pdfPrintDialog;
        private System.Windows.Forms.Label unableToDisplayLabel;
    }
}
