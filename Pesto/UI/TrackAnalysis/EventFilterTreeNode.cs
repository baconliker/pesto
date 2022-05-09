using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColinBaker.Pesto.UI.TrackAnalysis
{
    class EventFilterTreeNode : System.Windows.Forms.TreeNode
    {
        public EventFilterTreeNode(string text, string imageKey, params Models.TrackAnalysis.Events.TrackEvent.EventType[] eventTypes) : base(text)
        {
            this.ImageKey = imageKey;
            this.SelectedImageKey = imageKey;
            this.EventTypes = eventTypes;
        }

        public Models.TrackAnalysis.Events.TrackEvent.EventType[] EventTypes { get; set; }
    }
}
