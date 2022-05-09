using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI.TrackAnalysis
{
    internal partial class EventFilterForm : Form
    {
        private bool m_populating = false;

        public EventFilterForm(Models.TrackAnalysis.Events.TrackEvent.EventType[] eventTypes)
        {
            InitializeComponent();

            this.EventTypes = eventTypes;
        }

        public Models.TrackAnalysis.Events.TrackEvent.EventType[] EventTypes { get; set; }

        private void PopulateFilters()
        {
            TreeNode rootNode = filterTreeView.Nodes.Add(string.Empty, "All Events", "Folder");

            TreeNode categoryNode;

            categoryNode = rootNode.Nodes.Add(string.Empty, "GPS", "Folder");
            categoryNode.Nodes.Add(new EventFilterTreeNode("First Fix", "Information", Models.TrackAnalysis.Events.TrackEvent.EventType.FirstFix));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Last Fix", "Information", Models.TrackAnalysis.Events.TrackEvent.EventType.LastFix));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Fix Lost", "Warning", Models.TrackAnalysis.Events.TrackEvent.EventType.FixLost));

            categoryNode = rootNode.Nodes.Add(string.Empty, "Altitude", "Folder");
            categoryNode.Nodes.Add(new EventFilterTreeNode("Initial Ascent", "Information", Models.TrackAnalysis.Events.TrackEvent.EventType.InitialAscent));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Below Min Altitude", "Failure", Models.TrackAnalysis.Events.TrackEvent.EventType.BelowMinAltitude));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Final Descent", "Information", Models.TrackAnalysis.Events.TrackEvent.EventType.FinalDescent));

            categoryNode = rootNode.Nodes.Add(string.Empty, "Start Point / Gate", "Folder");
            categoryNode.Nodes.Add(new EventFilterTreeNode("Hit", "Achievement", Models.TrackAnalysis.Events.TrackEvent.EventType.StartPointHit, Models.TrackAnalysis.Events.TrackEvent.EventType.StartGateHit));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Not Hit", "Failure", Models.TrackAnalysis.Events.TrackEvent.EventType.StartPointNotHit, Models.TrackAnalysis.Events.TrackEvent.EventType.StartGateNotHit));

            categoryNode = rootNode.Nodes.Add(string.Empty, "Finish Point / Gate", "Folder");
            categoryNode.Nodes.Add(new EventFilterTreeNode("Hit", "Achievement", Models.TrackAnalysis.Events.TrackEvent.EventType.FinishPointHit, Models.TrackAnalysis.Events.TrackEvent.EventType.FinishGateHit));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Not Hit", "Failure", Models.TrackAnalysis.Events.TrackEvent.EventType.FinishPointNotHit, Models.TrackAnalysis.Events.TrackEvent.EventType.FinishGateNotHit));

            categoryNode = rootNode.Nodes.Add(string.Empty, "Turnpoints", "Folder");
            categoryNode.Nodes.Add(new EventFilterTreeNode("Hit", "Achievement", Models.TrackAnalysis.Events.TrackEvent.EventType.TurnpointHit));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Duplicate Hit", "Warning", Models.TrackAnalysis.Events.TrackEvent.EventType.DuplicateTurnpointHit));

            categoryNode = rootNode.Nodes.Add(string.Empty, "Hidden Gates", "Folder");
            categoryNode.Nodes.Add(new EventFilterTreeNode("Hit", "Achievement", Models.TrackAnalysis.Events.TrackEvent.EventType.HiddenGateHit));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Duplicate Hit", "Warning", Models.TrackAnalysis.Events.TrackEvent.EventType.DuplicateHiddenGateHit));

            categoryNode = rootNode.Nodes.Add(string.Empty, "No Fly Zones", "Folder");
            categoryNode.Nodes.Add(new EventFilterTreeNode("No Fly Zone Incursion", "Failure", Models.TrackAnalysis.Events.TrackEvent.EventType.NoFlyZoneIncursion));

            categoryNode = rootNode.Nodes.Add(string.Empty, "Take Off & Landing", "Folder");
            categoryNode.Nodes.Add(new EventFilterTreeNode("Take Off / Landing", "Information", Models.TrackAnalysis.Events.TrackEvent.EventType.TakeOff, Models.TrackAnalysis.Events.TrackEvent.EventType.Landing));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Take Off / Landing Outside Airfield", "Failure", Models.TrackAnalysis.Events.TrackEvent.EventType.TakeOffOutsideAirfield, Models.TrackAnalysis.Events.TrackEvent.EventType.LandingOutsideAirfield));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Take Off / Landing Outside Deck", "Failure", Models.TrackAnalysis.Events.TrackEvent.EventType.TakeOffOutsideDeck, Models.TrackAnalysis.Events.TrackEvent.EventType.LandingOutsideDeck));
            categoryNode.Nodes.Add(new EventFilterTreeNode("Take Off / Landing Outside Window", "Failure", Models.TrackAnalysis.Events.TrackEvent.EventType.TakeOffBeforeWindowOpen, Models.TrackAnalysis.Events.TrackEvent.EventType.TakeOffAfterWindowClose, Models.TrackAnalysis.Events.TrackEvent.EventType.LandingAfterWindowClose));
        }

        private void SetSelectedEventTypes(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode is EventFilterTreeNode)
                {
                    if (this.EventTypes.Contains((childNode as EventFilterTreeNode).EventTypes[0]))
                    {
                        childNode.Checked = true;

                        // Expand path
                        TreeNode nodeToExpand = childNode;
                        while (1 == 1)
                        {
                            nodeToExpand.Expand();

                            if (nodeToExpand.Parent != null)
                            {
                                nodeToExpand = nodeToExpand.Parent;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    SetSelectedEventTypes(childNode);
                }
            }

            int checkedCount = 0;

            // See if all child nodes have been checked, if so check this node too
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Checked)
                {
                    checkedCount++;
                }
            }

            if (checkedCount == node.Nodes.Count)
            {
                node.Checked = true;
            }
        }

        private void AddSelectedEventTypes(TreeNode node, List<Models.TrackAnalysis.Events.TrackEvent.EventType> eventTypes)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode is EventFilterTreeNode)
                {
                    if (childNode.Checked)
                    {
                        eventTypes.AddRange((childNode as EventFilterTreeNode).EventTypes);
                    }
                }
                else
                {
                    AddSelectedEventTypes(childNode, eventTypes);
                }
            }
        }

        private void EventFilterForm_Load(object sender, EventArgs e)
        {
            m_populating = true;

            PopulateFilters();

            SetSelectedEventTypes(filterTreeView.Nodes[0]);

            m_populating = false;

            filterTreeView.SelectedNode = filterTreeView.Nodes[0];
            filterTreeView.SelectedNode.EnsureVisible();
        }

        private void filterTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (m_populating) return;

            foreach (TreeNode childNode in e.Node.Nodes)
            {
                childNode.Checked = e.Node.Checked;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            List<Models.TrackAnalysis.Events.TrackEvent.EventType> eventTypes = new List<Models.TrackAnalysis.Events.TrackEvent.EventType>();

            AddSelectedEventTypes(filterTreeView.Nodes[0], eventTypes);

            if (eventTypes.Count > 0)
            {
                this.EventTypes = eventTypes.ToArray();
            }
            else
            {
                MessageBox.Show("Please select at least one event type.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Prevent dialog from closing
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }
        }
    }
}
