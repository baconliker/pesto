using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI
{
	[System.Runtime.InteropServices.ComVisibleAttribute(true)]
	public class MapEventReceiver
	{
        public event EventHandler MapInitialized;
		public event EventHandler<MapClickedEventArgs> MapClicked;
		public event EventHandler<MapClickedEventArgs> MapRightClicked;

		public void OnMapInitialized()
        {
            if (MapInitialized != null)
            {
                MapInitialized(this, new EventArgs());
            }
        }

		public void OnMapClick(decimal latitude, decimal longitude)
		{
			if (MapClicked != null)
			{
				MapClicked(this, new MapClickedEventArgs(new Geolocation.Location(latitude, longitude)));
			}
		}

		public void OnMapRightClick(decimal latitude, decimal longitude)
		{
			if (MapRightClicked != null)
			{
				MapRightClicked(this, new MapClickedEventArgs(new Geolocation.Location(latitude, longitude)));
			}
		}
	}
}
