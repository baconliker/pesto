using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
    class LandingOutsideAirfield : TrackEvent
    {
        public LandingOutsideAirfield()
			: base(EventType.LandingOutsideAirfield)
		{
        }

        public override string Description
        {
            get
            {
                return "Landing outside airfield";
            }
        }
    }
}
