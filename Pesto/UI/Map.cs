using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
		private bool m_processFailed = false;

		private List<Models.Features.Feature> m_queuedFeatures = new List<Models.Features.Feature>();
		private List<Geolocation.Tracks.Track> m_queuedTracks = new List<Geolocation.Tracks.Track>();

		public Map()
		{
			InitializeComponent();

			mapWebView.CoreWebView2InitializationCompleted += mapWebView_CoreWebView2InitializationCompleted;
			mapWebView.NavigationCompleted += mapWebView_NavigationCompleted;

			m_eventReceiver.MapInitialized += new EventHandler(m_eventReceiver_MapInitialized);
			m_eventReceiver.MapClicked += new EventHandler<MapClickedEventArgs>(m_eventReceiver_MapClicked);
			m_eventReceiver.MapRightClicked += new EventHandler<MapClickedEventArgs>(m_eventReceiver_MapRightClicked);
		}

		public async Task SetToUKAsync()
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync("setToUK()").ConfigureAwait(false);
			}
		}

		public async Task ClearAsync()
		{
			m_queuedFeatures.Clear();
			m_queuedTracks.Clear();

			if (m_initialized)
			{
				await ExecuteScriptAsync("clear()").ConfigureAwait(false);
			}
		}

		public async Task ZoomFullyInAsync()
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync("zoomFullyIn()").ConfigureAwait(false);
			}
		}

		public async Task ZoomInAsync()
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync("zoomIn()").ConfigureAwait(false);
			}
		}

		public async Task ZoomOutAsync()
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync("zoomOut()").ConfigureAwait(false);
			}
		}

		public async Task PanAsync(Geolocation.Location location)
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync($"pan({decimal.Round(location.Latitude, 6)}, {decimal.Round(location.Longitude, 6)})").ConfigureAwait(false);
			}
		}

        public async Task AutoFitAsync()
        {
            if (m_initialized)
            {
				await ExecuteScriptAsync("autoFit()").ConfigureAwait(false);
            }
        }

		public async Task AddFeatureAsync(Models.Features.Feature feature)
		{
			if (m_initialized)
			{
				switch (feature.Type)
				{
					case Models.Features.Feature.FeatureType.Point:
						Models.Features.PointFeature point = feature as Models.Features.PointFeature;
                        Models.Features.Circle pointCircle = point.Shape as Models.Features.Circle;

						await ExecuteScriptAsync($"addPoint('{feature.Name}', {decimal.Round(pointCircle.Center.Latitude, 6)}, {decimal.Round(pointCircle.Center.Longitude, 6)}, {pointCircle.Radius})").ConfigureAwait(false);

						break;

					case Models.Features.Feature.FeatureType.Gate:
						Models.Features.GateFeature gate = feature as Models.Features.GateFeature;
                        Models.Features.Line gateLine = gate.Shape as Models.Features.Line;

						await ExecuteScriptAsync($"addGate('{feature.Name}', {decimal.Round(gateLine.Center.Latitude, 6)}, {decimal.Round(gateLine.Center.Longitude, 6)}, {gateLine.Width}, {decimal.Round(gateLine.Bearing, 1)})").ConfigureAwait(false);

						break;

					case Models.Features.Feature.FeatureType.NoFlyZone:
						Models.Features.NoFlyZoneFeature nfz = feature as Models.Features.NoFlyZoneFeature;

                        switch (nfz.Shape.Type)
                        {
                            case Models.Features.Shape.ShapeType.Circle:
                                Models.Features.Circle nfzCircle = (Models.Features.Circle)nfz.Shape;
								await ExecuteScriptAsync($"addNoFlyZone('{feature.Name}', {decimal.Round(nfzCircle.Center.Latitude, 6)}, {decimal.Round(nfzCircle.Center.Longitude, 6)}, {nfzCircle.Radius})").ConfigureAwait(false);
                                break;

                            case Models.Features.Shape.ShapeType.Polygon:
                                Models.Features.Polygon nfzPolygon = (Models.Features.Polygon)nfz.Shape;
								await ExecuteScriptAsync($"startPolygon('{feature.Name}')");
                                foreach (Geolocation.Location vertex in nfzPolygon.Vertices)
                                {
									await ExecuteScriptAsync($"addPolygonPoint({decimal.Round(vertex.Latitude, 6)}, {decimal.Round(vertex.Longitude, 6)})");
                                }
								await ExecuteScriptAsync("finishNoFlyZonePolygon()").ConfigureAwait(false);
                                break;
                        }
                        
						break;

                    case Models.Features.Feature.FeatureType.Airfield:
                        Models.Features.AirfieldFeature airfield = feature as Models.Features.AirfieldFeature;
                        Models.Features.Polygon airfieldPolygon = airfield.Shape as Models.Features.Polygon;

						await ExecuteScriptAsync($"startPolygon('{feature.Name}')");
                        foreach (Geolocation.Location vertex in airfieldPolygon.Vertices)
                        {
							await ExecuteScriptAsync($"addPolygonPoint({decimal.Round(vertex.Latitude, 6)}, {decimal.Round(vertex.Longitude, 6)})");
                        }
						await ExecuteScriptAsync("finishAirfieldPolygon()").ConfigureAwait(false);

                        break;

                    case Models.Features.Feature.FeatureType.Deck:
                        Models.Features.DeckFeature deck = feature as Models.Features.DeckFeature;
                        Models.Features.Polygon deckPolygon = deck.Shape as Models.Features.Polygon;

						await ExecuteScriptAsync($"startPolygon('{feature.Name}')");
                        foreach (Geolocation.Location vertex in deckPolygon.Vertices)
                        {
							await ExecuteScriptAsync($"addPolygonPoint({decimal.Round(vertex.Latitude, 6)}, {decimal.Round(vertex.Longitude, 6)})");
                        }
						await ExecuteScriptAsync("finishDeckPolygon()").ConfigureAwait(false);

                        break;
                }
			}
			else
			{
				// Queue feature so it can be added as soon as the map is initialized

				m_queuedFeatures.Add(feature);
			}
		}

		public async Task RemoveFeatureAsync(string featureName)
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync($"removeFeature('{featureName}')").ConfigureAwait(false);
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

		public async Task AddTrackAsync(Geolocation.Tracks.Track track)
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync("startTrack()");
				foreach (ColinBaker.Geolocation.Tracks.Fix fix in track.Fixes)
				{
					await ExecuteScriptAsync($"addTrackFix({decimal.Round(fix.Latitude, 6)}, {decimal.Round(fix.Longitude, 6)})");
				}
				await ExecuteScriptAsync("finishTrack()").ConfigureAwait(false);
			}
			else
			{
				// Queue track so it can be added as soon as the map is initialized

				m_queuedTracks.Add(track);
			}
		}

		public async Task RemoveTrackAsync()
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync("removeTrack()").ConfigureAwait(false);
			}
			else
			{
				// Remove the track from the queue if it's there

				// This will need to be modified if we ever support more than one track at a time
				m_queuedTracks.Clear();
			}
		}

		public async Task<Geolocation.Location> GetCenterAsync()
		{
			if (m_initialized)
			{
				decimal latitude = System.Convert.ToDecimal(await ExecuteScriptAsync("getCenterLatitude()"));
				decimal longitude = System.Convert.ToDecimal(await ExecuteScriptAsync("getCenterLongitude()").ConfigureAwait(false));

				return new Geolocation.Location(latitude, longitude);
			}
			else
			{
				return null;
			}
		}

		public async Task SetCenterAsync(Geolocation.Location location)
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync($"setCenter({decimal.Round(location.Latitude, 6)}, {decimal.Round(location.Longitude, 6)})").ConfigureAwait(false);
			}
		}

		public async Task<int> GetZoomAsync()
		{
			if (m_initialized)
			{
				return System.Convert.ToInt32(await ExecuteScriptAsync("getZoom()").ConfigureAwait(false));
			}
			else
			{
				return -1;
			}
		}

		public async Task SetZoomAsync(int zoom)
		{
			if (m_initialized)
			{
				await ExecuteScriptAsync($"setZoom({zoom})").ConfigureAwait(false);
			}
		}

		public async void m_eventReceiver_MapInitialized(object sender, EventArgs e)
		{
			m_eventReceiver.MapInitialized -= new EventHandler(m_eventReceiver_MapInitialized);

			m_initialized = true;

			if (m_queuedFeatures.Count > 0 || m_queuedTracks.Count > 0)
			{
				// Add features that are queued
				foreach (Models.Features.Feature feature in m_queuedFeatures)
				{
					await AddFeatureAsync(feature);
				}
				m_queuedFeatures.Clear();

				// Add tracks that are queued
				foreach (ColinBaker.Geolocation.Tracks.Track track in m_queuedTracks)
				{
					await AddTrackAsync(track);
				}
				m_queuedTracks.Clear();

                await AutoFitAsync();
			}
			else
			{
				await SetToUKAsync();
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

		private void mapWebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
		{
			mapWebView.CoreWebView2InitializationCompleted -= mapWebView_CoreWebView2InitializationCompleted;

			Services.SettingsStore store = new Services.SettingsStore();

			if (e.InitializationException == null && e.IsSuccess)
			{
				loadingMapLabel.Visible = false;
				mapWebView.Visible = true;

				mapWebView.CoreWebView2.ProcessFailed += CoreWebView2_ProcessFailed;
				mapWebView.CoreWebView2.AddHostObjectToScript("proxy", m_eventReceiver);

				mapWebView.CoreWebView2.Navigate(Application.StartupPath + "/Resources/Html/GoogleMaps.htm");
			}
		}

		private async void mapWebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
		{
			mapWebView.NavigationCompleted -= mapWebView_NavigationCompleted;

			Services.SettingsStore store = new Services.SettingsStore();

			await ExecuteScriptAsync($"register('{store.GoogleMapsApiKey}')").ConfigureAwait(false);
		}

		private void CoreWebView2_ProcessFailed(object sender, CoreWebView2ProcessFailedEventArgs e)
		{
			// Set flag to prevent us using the WebView2 once it has failed
			m_processFailed = true;
		}

		private async Task<object> ExecuteScriptAsync(string javaScript)
		{
			if (!m_processFailed)
			{
				return await mapWebView.CoreWebView2.ExecuteScriptAsync(javaScript).ConfigureAwait(false);
			}
			else
			{
				return null;
			}
		}

		private async void Map_Load(object sender, EventArgs e)
		{
			if (!this.DesignMode)
			{
				Services.SettingsStore store = new Services.SettingsStore();

				if (string.IsNullOrEmpty(store.GoogleMapsApiKey))
				{
					googleMapsApiKeyNotSetLabel.Visible = true;
				}
				else
				{
					loadingMapLabel.Visible = true;

					var env = await CoreWebView2Environment.CreateAsync(null, @"C:\ProgramData\Colin Baker\Pesto");

					await mapWebView.EnsureCoreWebView2Async(env).ConfigureAwait(false);
				}
			}
		}
	}
}
