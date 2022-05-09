using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Tracks
{
	public abstract class FileFormat
	{
		public abstract string DisplayName { get; }
		public abstract bool EncodingSupported { get; }
		public abstract bool DecodingSupported { get; }
		public abstract string[] FileExtensions { get; }

		public virtual IEncoder GetEncoder()
		{
			throw new NotSupportedException();
		}

		public virtual IDecoder GetDecoder()
		{
			throw new NotSupportedException();
		}

		public static FileFormat[] GetSupportedFormats()
		{
			return new FileFormat[] { new Gpx.GpxFileFormat(), new Igc.IgcFileFormat(), new Nmea.NmeaFileFormat(), new Kml.KmlFileFormat() };
		}

		public override string ToString()
		{
			return this.DisplayName;
		}
	}
}
