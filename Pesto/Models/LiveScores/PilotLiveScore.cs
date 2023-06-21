using System;

namespace ColinBaker.Pesto.Models.LiveScores
{
	class PilotLiveScore
	{
        public PilotLiveScore(int pilotNumber, string pilotName, string loggerId, string aircraftClassCode)
        {
            this.PilotNumber = pilotNumber;
            this.PilotName = pilotName;
            this.LoggerId = loggerId;
            this.AircraftClassCode = aircraftClassCode;
        }

        public int PilotNumber { get; set; }
        public string PilotName { get; set; }
        public string LoggerId { get; set; }
        public string AircraftClassCode { get; set; }
        public int TurnpointsHit { get; set; }

        public Geolocation.Tracks.Track Track { get; set; }
    }
}
