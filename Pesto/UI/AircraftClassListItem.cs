using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.UI
{
    class AircraftClassListItem
    {
        public AircraftClassListItem(Models.AircraftClass aircraftClass)
        {
            this.AircraftClass = aircraftClass;
        }

        public AircraftClassListItem()
        {
        }

        public override string ToString()
        {
            if (this.AircraftClass == null)
            {
                return "<All>";
            }
            else
            {
                return this.AircraftClass.Code;
            }
        }

        public Models.AircraftClass AircraftClass { get; set; }
    }
}
