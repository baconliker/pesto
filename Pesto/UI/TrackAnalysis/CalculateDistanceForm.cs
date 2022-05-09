using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.TrackAnalysis
{
    internal partial class CalculateDistanceForm : Form
    {
        public CalculateDistanceForm(List<Models.TrackAnalysis.Events.TrackEvent> selectedEvents, Geolocation.Tracks.Track pilotTrack)
        {
            InitializeComponent();

            directLineDistanceTextBox.Text = (CalculateDirectLineDistance(selectedEvents) / 1000).ToString("0.00");
            pilotDistanceTextBox.Text = (CalculatePilotTrackDistance(selectedEvents, pilotTrack) / 1000).ToString("0.00");
        }

        private double CalculateDirectLineDistance(List<Models.TrackAnalysis.Events.TrackEvent> selectedEvents)
        {
            double totalDistance = 0;

            for (int i = 1; i < selectedEvents.Count; i++)
            {
                Models.TrackAnalysis.Events.TrackEvent event1 = selectedEvents[i - 1];
                Models.TrackAnalysis.Events.TrackEvent event2 = selectedEvents[i];

                totalDistance += GetFeatureLocation(event1).DistanceTo(GetFeatureLocation(event2));
            }

            return totalDistance;
        }

        private double CalculatePilotTrackDistance(List<Models.TrackAnalysis.Events.TrackEvent> selectedEvents, Geolocation.Tracks.Track pilotTrack)
        {
            double totalDistance = 0;

            Models.TrackAnalysis.Events.TrackEvent startEvent = selectedEvents[0];
            Models.TrackAnalysis.Events.TrackEvent finishEvent = selectedEvents[selectedEvents.Count - 1];

            bool recordDistance = false;

            for (var fixIndex = 1; fixIndex < pilotTrack.Fixes.Count; fixIndex++)
            {
                Geolocation.Tracks.Fix fix = pilotTrack.Fixes[fixIndex];
                Geolocation.Tracks.Fix previousFix = pilotTrack.Fixes[fixIndex - 1];

                if (recordDistance)
                {
                    totalDistance += previousFix.DistanceTo(fix);
                }

                if (fix.Latitude == startEvent.Location.Latitude && fix.Longitude == startEvent.Location.Longitude && fix.Time == startEvent.Time)
                {
                    recordDistance = true;
                }

                if (fix.Latitude == finishEvent.Location.Latitude && fix.Longitude == finishEvent.Location.Longitude && fix.Time == finishEvent.Time)
                {
                    recordDistance = false;
                }
            }

            return totalDistance;
        }

        private Geolocation.Location GetFeatureLocation(Models.TrackAnalysis.Events.TrackEvent trackEvent)
        {
            Geolocation.Location location = null;

            if (trackEvent.RelatedFeature == null)
            {
                location = trackEvent.Location;
            }
            else
            {
                switch (trackEvent.RelatedFeature.Type)
                {
                    case Models.Features.Feature.FeatureType.Gate:
                        Models.Features.GateFeature gate = trackEvent.RelatedFeature as Models.Features.GateFeature;
                        location = (gate.Shape as Models.Features.Line).Center;
                        break;
                    case Models.Features.Feature.FeatureType.Point:
                        Models.Features.PointFeature point = trackEvent.RelatedFeature as Models.Features.PointFeature;
                        location = (point.Shape as Models.Features.Circle).Center;
                        break;
                }
            }

            return location;
        }
    }
}
