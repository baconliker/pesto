using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI
{
	class TaskTypeListItem
	{
		public TaskTypeListItem(Models.Task.TaskType type)
		{
			this.Type = type;
		}

		public override string ToString()
		{
			return Models.Task.GetTaskTypeDescription(this.Type);
		}

		public Models.Task.TaskType Type { get; set; }
	}
}
