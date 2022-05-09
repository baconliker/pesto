using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.Models.Results
{
    class NationResultsGenerationOptions : ResultsGenerationOptions
    {
        public NationResultsGenerationOptions(int[] taskNumbers)
        {
            this.TaskNumbers = taskNumbers;
        }

        public int[] TaskNumbers { get; set; }
    }
}
