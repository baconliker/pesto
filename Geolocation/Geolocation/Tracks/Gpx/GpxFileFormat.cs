
namespace ColinBaker.Geolocation.Tracks.Gpx
{
	public class GpxFileFormat : FileFormat
	{
		public const string NamespaceUri = "http://www.topografix.com/GPX/1/1";

		public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

		public override IEncoder GetEncoder()
		{
			return new GpxEncoder();
		}

		public override IDecoder GetDecoder()
		{
			return new GpxDecoder();
		}

		public override string DisplayName
		{
			get { return "GPX (GPS eXchange Format)"; }
		}

		public override bool EncodingSupported
		{
			get { return true; }
		}

		public override bool DecodingSupported
		{
			get { return true; }
		}

		public override string[] FileExtensions
		{
			get { return new string[] { ".gpx" }; }
		}
	}
}
