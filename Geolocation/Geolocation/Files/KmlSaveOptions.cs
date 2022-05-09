using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
    public class KmlSaveOptions
    {
        public KmlSaveOptions()
        {
            this.IncludeTrackFixData = true;
            this.ClampTrackToGround = true;
        }

        public bool IncludeTrackFixData { get; set; }
        public bool ClampTrackToGround { get; set; }
    }
}
