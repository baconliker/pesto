using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation
{
	public class TrackConversionEventArgs : EventArgs
	{
		private int m_fileLineNumber;
		private string m_suspectData;

		private bool m_skipError;

		public TrackConversionEventArgs(int fileLineNumber, string fileLineData)
		{
			m_fileLineNumber = fileLineNumber;
			m_suspectData = fileLineData;
		}

		public TrackConversionEventArgs(string fileLineData)
		{
			m_suspectData = fileLineData;
		}

		public int FileLineNumber
		{
			get { return m_fileLineNumber; }
		}

		public string SuspectData
		{
			get { return m_suspectData; }
		}

		public bool SkipError
		{
			get { return m_skipError; }
			set { m_skipError = value; }
		}
	}
}
