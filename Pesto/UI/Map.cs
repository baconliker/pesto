using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI
{
	internal partial class Map : UserControl
	{
        public event EventHandler MapInitialized;
		public event EventHandler<MapClickedEventArgs> MapClicked;
		public event EventHandler<MapClickedEventArgs> MapRightClicked;

		MapEventReceiver m_eventReceiver = new MapEventReceiver();

		private bool m_initialized = false;

		private List<Models.Features.Feature> m_queuedFeatures = new List<Models.Features.Feature>();
		private List<Geolocation.Tracks.Track> m_queuedTracks = new List<Geolocation.Tracks.Track>();

		public Map()
		{
			InitializeComponent();

			m_eventReceiver.MapInitialized += new EventHandler(m_eventReceiver_MapInitialized);
			m_eventReceiver.MapClicked += new EventHandler<MapClickedEventArgs>(m_eventReceiver_MapClicked);
			m_eventReceiver.MapRightClicked += new EventHandler<MapClickedEventArgs>(m_eventReceiver_MapRightClicked);
		}

		public void SetToUK()
		{
			if (m_initialized)
			{
				mapWebBrowser.Document.InvokeScript("setToUK");
			}
		}

		public void Clear()
		{
			m_queuedFeatures.Clear();
			m_queuedTracks.Clear();

			if (m_initialized)
			{
				mapWebBrowser.Document.InvokeScript("clear");
			}
		}

		public void ZoomFullyIn()
		{
			if (m_initialized)
			{
				mapWebBrowser.Document.InvokeScript("zoomFullyIn");
			}
		}

		public void ZoomIn()
		{
			if (m_initialized)
			{
				mapWebBrowser.Document.InvokeScript("zoomIn");
			}
		}

		public void ZoomOut()
		{
			if (m_initialized)
			{
				mapWebBrowser.Document.InvokeScript("zoomOut");
			}
		}

		public void Pan(Geolocation.Location location)
		{
			if (m_initialized)
			{
				mapWebBrowser.Document.InvokeScript("pan", new object[] { decimal.Round(location.Latitude, 6), decimal.Round(location.Longitude, 6) });
			}
		}

        public void AutoFit()
        {
            if (m_initialized)
            {
                mapWebBrowser.Document.InvokeScript("autoFit");
            }
        }

		public void AddFeature(Models.Features.Feature feature)
		{
			if (m_initialized)
			{
				switch (feature.Type)
				{
					case Models.Features.Feature.FeatureType.Point:
						Models.Features.PointFeature point = feature as Models.Features.PointFeature;
                        Models.Features.Circle pointCircle = point.Shape as Models.Features.Circle;

						mapWebBrowser.Document.InvokeScript("addPoint", new object[] { feature.Name, decimal.Round(pointCircle.Center.Latitude, 6), decimal.Round(pointCircle.Center.Longitude, 6), pointCircle.Radius });

						break;

					case Models.Features.Feature.FeatureType.Gate:
						Models.Features.GateFeature gate = feature as Models.Features.GateFeature;
                        Models.Features.Line gateLine = gate.Shape as Models.Features.Line;

						mapWebBrowser.Document.InvokeScript("addGate", new object[] { feature.Name, decimal.Round(gateLine.Center.Latitude, 6), decimal.Round(gateLine.Center.Longitude, 6), gateLine.Width, decimal.Round(gateLine.Bearing, 1) });

						break;

					case Models.Features.Feature.FeatureType.NoFlyZone:
						Models.Features.NoFlyZoneFeature nfz = feature as Models.Features.NoFlyZoneFeature;

                        switch (nfz.Shape.Type)
                        {
                            case Models.Features.Shape.ShapeType.Circle:
                                Models.Features.Circle nfzCircle = (Models.Features.Circle)nfz.Shape;
                                mapWebBrowser.Document.InvokeScript("addNoFlyZone", new object[] { feature.Name, decimal.Round(nfzCircle.Center.Latitude, 6), decimal.Round(nfzCircle.Center.Longitude, 6), nfzCircle.Radius });
                                break;

                            case Models.Features.Shape.ShapeType.Polygon:
                                Models.Features.Polygon nfzPolygon = (Models.Features.Polygon)nfz.Shape;
                                mapWebBrowser.Document.InvokeScript("startPolygon", new object[] { feature.Name });
                                foreach (Geolocation.Location vertex in nfzPolygon.Vertices)
                                {
                                    mapWebBrowser.Document.InvokeScript("addPolygonPoint", new object[] { decimal.Round(vertex.Latitude, 6), decimal.Round(vertex.Longitude, 6) });
                                }
                                mapWebBrowser.Document.InvokeScript("finishNoFlyZonePolygon");
                                break;
                        }
                        
						break;

                    case Models.Features.Feature.FeatureType.Airfield:
                        Models.Features.AirfieldFeature airfield = feature as Models.Features.AirfieldFeature;
                        Models.Features.Polygon airfieldPolygon = airfield.Shape as Models.Features.Polygon;

                        mapWebBrowser.Document.InvokeScript("startPolygon", new object[] { feature.Name });
                        foreach (Geolocation.Location vertex in airfieldPolygon.Vertices)
                        {
                            mapWebBrowser.Document.InvokeScript("addPolygonPoint", new object[] { decimal.Round(vertex.Latitude, 6), decimal.Round(vertex.Longitude, 6) });
                        }
                        mapWebBrowser.Document.InvokeScript("finishAirfieldPolygon");

                        break;

                    case Models.Features.Feature.FeatureType.Deck:
                        Models.Features.DeckFeature deck = feature as Models.Features.DeckFeature;
                        Models.Features.Polygon deckPolygon = deck.Shape as Models.Features.Polygon;

                        mapWebBrowser.Document.InvokeScript("startPolygon", new object[] { feature.Name });
                        foreach (Geolocation.Location vertex in deckPolygon.Vertices)
                        {
                            mapWebBrowser.Document.InvokeScript("addPolygonPoint", new object[] { decimal.Round(vertex.Latitude, 6), decimal.Round(vertex.Longitude, 6) });
                        }
                        mapWebBrowser.Document.InvokeScript("finishDeckPolygon");

                        break;
                }
			}
			else
			{
				// Queue feature so it can be added as soon as the map is initialized

				m_queuedFeatures.Add(feature);
			}
		}

		public void RemoveFeature(string featureName)
		{
			if (m_initialized)
			{
				mapWebBrowser.Document.InvokeScript("removeFeature", new object[] { featureName });
			}
			else
			{
				// Remove the feature from the queue if it's there

				for (int i = 0; i < m_queuedFeatures.Count; i++)
				{
					if (string.Compare(m_queuedFeatures[i].Name, featureName, true) == 0)
					{
						m_queuedFeatures.RemoveAt(i);
						break;
					}
				}
			}
		}

		public void AddTrack(Geolocation.Tracks.Track track)
		{
			if (m_initialized)
			{
				mapWebBrowser.Document.InvokeScript("startTrack");
				foreach (ColinBaker.Geolocation.Tracks.Fix fix in track.Fixes)
				{
					mapWebBrowser.Document.InvokeScript("addTrackFix", new object[] { decimal.Round(fix.Latitude, 6), decimal.Round(fix.Longitude, 6) });
				}
				mapWebBrowser.Document.InvokeScript("finishTrack");
			}
			else
			{
				// Queue track so it can be added as soon as the map is initialized

				m_queuedTracks.Add(track);
			}
		}

		public void RemoveTrack()
		{
			if (m_initialized)
			{
				mapWebBrowser.Document.InvokeScript("removeTrack");
			}
			else
			{
				// Remove the track from the queue if it's there

				// This will need to be modified if we ever support more than one track at a time
				m_queuedTracks.Clear();
			}
		}

        public Geolocation.Location CenterLocation
        {
            get 
            {
                if (m_initialized)
                {
                    decimal latitude = System.Convert.ToDecimal(mapWebBrowser.Document.InvokeScript("getCenterLatitude"));
                    decimal longitude = System.Convert.ToDecimal(mapWebBrowser.Document.InvokeScript("getCenterLongitude"));

                    return new Geolocation.Location(latitude, longitude);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (m_initialized)
                {
                    mapWebBrowser.Document.InvokeScript("setCenter", new object[] { decimal.Round(value.Latitude, 6), decimal.Round(value.Longitude, 6) });
                }
            }
        }

        public int Zoom
        {
            get
            {
                if (m_initialized)
                {
                    return System.Convert.ToInt32(mapWebBrowser.Document.InvokeScript("getZoom"));
                }
                else 
                {
                    return -1;
                }
            }
            set
            {
                if (m_initialized)
                {
                    mapWebBrowser.Document.InvokeScript("setZoom", new object[] { value });
                }
            }
        }

		public void m_eventReceiver_MapInitialized(object sender, EventArgs e)
		{
			m_initialized = true;

			if (m_queuedFeatures.Count > 0 || m_queuedTracks.Count > 0)
			{
				// Add features that are queued
				foreach (Models.Features.Feature feature in m_queuedFeatures)
				{
					AddFeature(feature);
				}
				m_queuedFeatures.Clear();

				// Add tracks that are queued
				foreach (ColinBaker.Geolocation.Tracks.Track track in m_queuedTracks)
				{
					AddTrack(track);
				}
				m_queuedTracks.Clear();

                AutoFit();
			}
			else
			{
				SetToUK();
			}

            OnMapInitialized(e);
		}

		public void m_eventReceiver_MapClicked(object sender, MapClickedEventArgs e)
		{
			OnMapClicked(e);
		}

		public void m_eventReceiver_MapRightClicked(object sender, MapClickedEventArgs e)
		{
			OnMapRightClicked(e);
		}

        protected void OnMapInitialized(EventArgs e)
        {
            if (MapInitialized != null)
            {
                MapInitialized(this, e);
            }
        }

		protected void OnMapClicked(MapClickedEventArgs e)
		{
			if (MapClicked != null)
			{
				MapClicked(this, e);
			}
		}

		protected void OnMapRightClicked(MapClickedEventArgs e)
		{
			if (MapRightClicked != null)
			{
				MapRightClicked(this, e);
			}
		}

		private void Map_Load(object sender, EventArgs e)
		{
			Services.SettingsStore store = new Services.SettingsStore();

			if (!this.DesignMode && !string.IsNullOrEmpty(store.GoogleMapsApiKey))
			{
				mapWebBrowser.Visible = true;
				mapWebBrowser.ObjectForScripting = m_eventReceiver;

				mapWebBrowser.Navigate("file://" + Application.StartupPath + "/Resources/Html/GoogleMaps.htm");
			}
			else
			{
				googleMapsApiKeyNotSetLabel.Visible = true;
			}
		}

		private void mapWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (!m_initialized)
			{
				Services.SettingsStore store = new Services.SettingsStore();

				mapWebBrowser.Document.InvokeScript("register", new object[] { store.GoogleMapsApiKey });
			}
		}
	}
}
