
namespace ColinBaker.Geolocation.Tracks.Kml
{
	public class KmlFileFormat : FileFormat
	{
		public override IEncoder GetEncoder()
		{
			return new KmlEncoder();
		}

		public override string DisplayName
		{
			get { return "KML (Keyhole Markup Language)"; }
		}

		public override bool EncodingSupported
		{
			get { return true; }
		}

		public override bool DecodingSupported
		{
			get { return false; }
		}

		public override string[] FileExtensions
		{
			get { return new string[] { ".kml" }; }
		}
	}
}
