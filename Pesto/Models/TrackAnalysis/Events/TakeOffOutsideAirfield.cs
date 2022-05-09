using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
    class TakeOffOutsideAirfield : TrackEvent
    {
        public TakeOffOutsideAirfield()
			: base(EventType.TakeOffOutsideAirfield)
		{
        }

        public override string Description
        {
            get
            {
                return "Take-off outside airfield";
            }
        }
    }
}
