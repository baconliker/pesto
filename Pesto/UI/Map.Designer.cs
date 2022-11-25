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
			this.googleMapsApiKeyNotSetLabel = new System.Windows.Forms.Label();
			this.mapWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
			this.loadingMapLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.mapWebView)).BeginInit();
			this.SuspendLayout();
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
			// mapWebView
			// 
			this.mapWebView.AllowExternalDrop = true;
			this.mapWebView.CreationProperties = null;
			this.mapWebView.DefaultBackgroundColor = System.Drawing.Color.White;
			this.mapWebView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapWebView.Location = new System.Drawing.Point(0, 0);
			this.mapWebView.Name = "mapWebView";
			this.mapWebView.Size = new System.Drawing.Size(688, 528);
			this.mapWebView.TabIndex = 3;
			this.mapWebView.Visible = false;
			this.mapWebView.ZoomFactor = 1D;
			// 
			// loadingMapLabel
			// 
			this.loadingMapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loadingMapLabel.Location = new System.Drawing.Point(0, 0);
			this.loadingMapLabel.Name = "loadingMapLabel";
			this.loadingMapLabel.Size = new System.Drawing.Size(688, 528);
			this.loadingMapLabel.TabIndex = 4;
			this.loadingMapLabel.Text = "Loading map...";
			this.loadingMapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.loadingMapLabel.Visible = false;
			// 
			// Map
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.loadingMapLabel);
			this.Controls.Add(this.googleMapsApiKeyNotSetLabel);
			this.Controls.Add(this.mapWebView);
			this.Name = "Map";
			this.Size = new System.Drawing.Size(688, 528);
			this.Load += new System.EventHandler(this.Map_Load);
			((System.ComponentModel.ISupportInitialize)(this.mapWebView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label googleMapsApiKeyNotSetLabel;
		private Microsoft.Web.WebView2.WinForms.WebView2 mapWebView;
		private System.Windows.Forms.Label loadingMapLabel;
	}
}
