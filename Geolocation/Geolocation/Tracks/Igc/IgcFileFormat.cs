using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks.Igc
{
	public class IgcFileFormat : FileFormat
	{
		public override IDecoder GetDecoder()
		{
			return new IgcDecoder();
		}

		public override string DisplayName
		{
			get { return "IGC (International Gliding Commission)"; }
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
			get { return new string[] { ".igc" }; }
		}
	}
}
