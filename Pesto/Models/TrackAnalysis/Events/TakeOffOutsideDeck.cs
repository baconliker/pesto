using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
    class TakeOffOutsideDeck : TrackEvent
    {
        public TakeOffOutsideDeck()
			: base(EventType.TakeOffOutsideDeck)
		{
        }

        public override string Description
        {
            get
            {
                return "Take-off outside deck";
            }
        }
    }
}
