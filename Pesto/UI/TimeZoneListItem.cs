using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.UI
{
    class TimeZoneListItem
    {
        public TimeZoneListItem(TimeZoneInfo timeZone)
        {
            this.TimeZone = timeZone;
        }

        public override string ToString()
        {
            return this.TimeZone.DisplayName;
        }

        public TimeZoneInfo TimeZone { get; set; }
    }
}
