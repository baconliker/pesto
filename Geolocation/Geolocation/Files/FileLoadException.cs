using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Geolocation.Files
{
    class FileLoadException : Exception
    {
        public FileLoadException(string message, Exception innerException) 
			: base(message, innerException)
        {
        }

        public FileLoadException(string message) 
			: base(message)
        {
        }
    }
}
