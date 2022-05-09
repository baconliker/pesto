using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
    class LandingOutsideDeck : TrackEvent
    {
        public LandingOutsideDeck()
			: base(EventType.LandingOutsideDeck)
		{
        }

        public override string Description
        {
            get
            {
                return "Landing outside deck";
            }
        }
    }
}
