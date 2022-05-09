using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Analyzers
{
    class BoundingBox
    {
        public void Extend(Geolocation.Location location)
        {
            if (this.NE == null && this.SW == null)
            {
                this.NE = new Geolocation.Location(location.Latitude, location.Longitude);
                this.SW = new Geolocation.Location(location.Latitude, location.Longitude);
            }
            else
            {
                this.NE.Latitude = Math.Max(location.Latitude, this.NE.Latitude);
                this.NE.Longitude = Math.Max(location.Longitude, this.NE.Longitude);

                this.SW.Latitude = Math.Min(location.Latitude, this.SW.Latitude);
                this.SW.Longitude = Math.Min(location.Longitude, this.SW.Longitude);
            }
        }

        public Geolocation.Location NE { get; private set; }
        public Geolocation.Location SW { get; private set; }
    }
}
