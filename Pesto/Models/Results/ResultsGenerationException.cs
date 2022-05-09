using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Results
{
    class ResultsGenerationException : Exception
    {
        public ResultsGenerationException(string message)
            : base(message)
        {
        }

        public ResultsGenerationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
