using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Results
{
	class OverallResultsGenerationOptions : ResultsGenerationOptions
	{
		public OverallResultsGenerationOptions(int[] taskNumbers)
		{
			this.TaskNumbers = taskNumbers;
		}

		public int[] TaskNumbers { get; set; }
	}
}
