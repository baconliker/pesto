using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
	public class TrackConversion
	{
		public event EventHandler<TrackConversionEventArgs> SourceFileError;

		private string m_sourceFilePath;
		private string m_destinationFilePath;

		private Tracks.IDecoder m_decoder;
		private Tracks.IEncoder m_encoder;

		public TrackConversion(string sourceFilePath, string destinationFilePath, Tracks.IDecoder decoder, Tracks.IEncoder encoder)
		{
			m_sourceFilePath = sourceFilePath;
			m_destinationFilePath = destinationFilePath;

			m_decoder = decoder;
			m_encoder = encoder;
		}

		public void Convert()
		{
			Tracks.Track track;

			m_decoder.Error += new EventHandler<TrackConversionEventArgs>(m_decoder_Error);
			try
			{
				using (System.IO.FileStream sourceStream = System.IO.File.OpenRead(m_sourceFilePath))
				{
					track = m_decoder.Decode(sourceStream);
				}
			}
			finally
			{
				m_decoder.Error -= m_decoder_Error;
			}

			using (System.IO.FileStream destinationStream = System.IO.File.Open(m_destinationFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
			{
				m_encoder.Encode(track, destinationStream);
			}
		}

		void m_decoder_Error(object sender, TrackConversionEventArgs e)
		{
			if (SourceFileError != null)
			{
				SourceFileError(this, e);
			}
		}

		public string SourceFilePath
		{
			get { return m_sourceFilePath; }
			set { m_sourceFilePath = value; }
		}

		public string DestinationFilePath
		{
			get { return m_destinationFilePath; }
			set { m_destinationFilePath = value; }
		}
	}
}
