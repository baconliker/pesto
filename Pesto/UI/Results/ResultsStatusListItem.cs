using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI.Results
{
    class ResultsStatusListItem
    {
        public ResultsStatusListItem(Models.Results.TaskResults.ResultsStatus status)
		{
            this.Status = status;
		}

		public override string ToString()
		{
			return Models.Results.TaskResults.GetResultsStatusDescription(this.Status);
		}

		public Models.Results.TaskResults.ResultsStatus Status { get; set; }
    }
}
