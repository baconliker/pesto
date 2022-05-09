using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.Results
{
	class TeamResultsGenerationOptions : ResultsGenerationOptions
	{
		public TeamResultsGenerationOptions(int[] taskNumbers)
		{
			this.TaskNumbers = taskNumbers;
		}

		public int[] TaskNumbers { get; set; }
	}
}
