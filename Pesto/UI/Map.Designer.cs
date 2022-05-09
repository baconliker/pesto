namespace ColinBaker.Pesto.UI
{
	partial class Map
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
			this.mapWebBrowser = new System.Windows.Forms.WebBrowser();
			this.googleMapsApiKeyNotSetLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mapWebBrowser
			// 
			this.mapWebBrowser.AllowWebBrowserDrop = false;
			this.mapWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapWebBrowser.IsWebBrowserContextMenuEnabled = false;
			this.mapWebBrowser.Location = new System.Drawing.Point(0, 0);
			this.mapWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.mapWebBrowser.Name = "mapWebBrowser";
			this.mapWebBrowser.ScriptErrorsSuppressed = true;
			this.mapWebBrowser.Size = new System.Drawing.Size(688, 528);
			this.mapWebBrowser.TabIndex = 1;
			this.mapWebBrowser.Visible = false;
			this.mapWebBrowser.WebBrowserShortcutsEnabled = false;
			this.mapWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.mapWebBrowser_DocumentCompleted);
			// 
			// googleMapsApiKeyNotSetLabel
			// 
			this.googleMapsApiKeyNotSetLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.googleMapsApiKeyNotSetLabel.Location = new System.Drawing.Point(0, 0);
			this.googleMapsApiKeyNotSetLabel.Name = "googleMapsApiKeyNotSetLabel";
			this.googleMapsApiKeyNotSetLabel.Size = new System.Drawing.Size(688, 528);
			this.googleMapsApiKeyNotSetLabel.TabIndex = 2;
			this.googleMapsApiKeyNotSetLabel.Text = "Google Maps API Key not set. Please set this in the Options screen.";
			this.googleMapsApiKeyNotSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.googleMapsApiKeyNotSetLabel.Visible = false;
			// 
			// Map
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.googleMapsApiKeyNotSetLabel);
			this.Controls.Add(this.mapWebBrowser);
			this.Name = "Map";
			this.Size = new System.Drawing.Size(688, 528);
			this.Load += new System.EventHandler(this.Map_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser mapWebBrowser;
		private System.Windows.Forms.Label googleMapsApiKeyNotSetLabel;
	}
}
