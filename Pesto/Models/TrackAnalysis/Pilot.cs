using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis
{
    class Pilot
    {
        public Pilot(int number, string name, string loggerId, string aircraftClassCode)
        {
            this.Number = number;
            this.Name = name;
            this.LoggerId = loggerId;
            this.AircraftClassCode = aircraftClassCode;

            this.Events = new List<Models.TrackAnalysis.Events.TrackEvent>();
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public string LoggerId { get; set; }
        public string AircraftClassCode { get; set; }

        public Geolocation.Tracks.Track Track { get; set; }
        public List<Models.TrackAnalysis.Events.TrackEvent> Events { get; set; }
    }
}
