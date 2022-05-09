using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.UI
{
    class TaskListItem
    {
        public TaskListItem(Models.Task task)
        {
            this.Task = task;
        }

        public TaskListItem(Models.Competition competition)
        {
            this.Competition = competition;
        }

        public Models.Competition Competition { get; set; }
        public Models.Task Task { get; set; }
    }
}
