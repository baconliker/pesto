using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks.Nmea
{
	public class NmeaFileFormat : FileFormat
	{
		public override IDecoder GetDecoder()
		{
			return new NmeaDecoder();
		}

		public override string DisplayName
		{
			get { return "NMEA (National Marine Electronics Association)"; }
		}

		public override bool EncodingSupported
		{
			get { return false; }
		}

		public override bool DecodingSupported
		{
			get { return true; }
		}

		public override string[] FileExtensions
		{
			get { return new string[] { ".nmea", ".log" }; }
		}
	}
}
