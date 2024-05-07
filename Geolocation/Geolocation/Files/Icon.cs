using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Geolocation.Files
{
	public class Icon
	{
		public Icon(string name, Location location, string iconUri)
		{
			this.Name = name;
			this.Location = location;
			this.IconUri = iconUri;
		}

		public string Name { get; set; }
		public Location Location { get; set; }
		public string IconUri { get; set; }
	}
}
