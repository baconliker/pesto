using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models
{
    class NationDefinition
    {
        public NationDefinition(AircraftClass aircraftClass, int numberWhoScore)
        {
            this.AircraftClass = aircraftClass;
            this.NumberWhoScore = numberWhoScore;
        }

        public AircraftClass AircraftClass { get; set; }
        public int NumberWhoScore { get; set; }
    }
}
