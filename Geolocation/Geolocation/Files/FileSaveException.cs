using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
	class FileSaveException : Exception
	{
		public FileSaveException(string message, Exception innerException) 
			: base(message, innerException)
        {
        }

		public FileSaveException(string message)
			: base(message)
        {
        }
	}
}
