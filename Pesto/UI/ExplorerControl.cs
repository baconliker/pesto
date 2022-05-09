using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Boris.UI
{
    partial class ExplorerControl : UserControl
    {
		public event EventHandler<EventArgs> ItemSelected;
		public event EventHandler<EventArgs> EditCompetition;
        public event EventHandler<EventArgs> NewTask;
        public event EventHandler<EventArgs> EditTask;
        public event EventHandler<EventArgs> EditLeague;

        public ExplorerControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            competitionTreeView.Nodes.Clear();
        }

        public void AddCompetition(Models.Competition competition)
        {
            competitionTreeView.BeginUpdate();

			ExplorerTreeNode node = new ExplorerTreeNode(ExplorerTreeNode.BuildCompetitionText(competition), ExplorerTreeNode.NodeType.Competition);
            node.Competition = competition;
            competitionTreeView.Nodes.Add(node);

            foreach (Models.Task task in competition.Tasks)
            {
                AddTask(task, node);
            }

			competitionTreeView.SelectedNode = node;

            competitionTreeView.EndUpdate();
        }

        public void AddTask(Models.Task task)
        {
            foreach (ExplorerTreeNode node in competitionTreeView.Nodes)
            {
                if (node.Competition == task.Competition)
                {
                    AddTask(task, node);
                    break;
                }
            }
        }

		public void UpdateCompetition(Models.Competition competition)
		{
			foreach (ExplorerTreeNode competitionNode in competitionTreeView.Nodes)
			{
				if (competitionNode.Competition == competition)
				{
					competitionNode.Text = ExplorerTreeNode.BuildCompetitionText(competition);

					break;
				}
			}
		}

        public void UpdateTask(Models.Task task)
        {
            foreach (ExplorerTreeNode competitionNode in competitionTreeView.Nodes)
            {
                if (competitionNode.Competition == task.Competition)
                {
                    foreach (ExplorerTreeNode taskNode in competitionNode.Nodes)
                    {
                        if (taskNode.Task == task)
                        {
                            taskNode.Text = ExplorerTreeNode.BuildTaskText(task);

                            break;
                        }
                    }

                    break;
                }
            }
        }

        public Models.Competition GetSelectedCompetition()
        {
            ExplorerTreeNode selectedNode = (ExplorerTreeNode)competitionTreeView.SelectedNode;

            if (selectedNode.Type == ExplorerTreeNode.NodeType.Task)
            {
                return selectedNode.Task.Competition;
            }
            else
            {
                return selectedNode.Competition;
            }
        }

        public Models.Task GetSelectedTask()
        {
            ExplorerTreeNode selectedNode = (ExplorerTreeNode)competitionTreeView.SelectedNode;

            if (selectedNode != null && selectedNode.Type == ExplorerTreeNode.NodeType.Task)
            {
                return selectedNode.Task;
            }
            else
            {
                return null;
            }
        }

		protected void OnItemSelected(EventArgs e)
		{
			if (ItemSelected != null)
			{
				ItemSelected(this, e);
			}
		}

		protected void OnEditCompetition(EventArgs e)
		{
			if (EditCompetition != null)
			{
				EditCompetition(this, e);
			}
		}

        protected void OnNewTask(EventArgs e)
        {
            if (NewTask != null)
            {
                NewTask(this, e);
            }
        }

        protected void OnEditTask(EventArgs e)
        {
            if (EditTask != null)
            {
                EditTask(this, e);
            }
        }

        protected void OnEditLeague(EventArgs e)
        {
            if (EditLeague != null)
            {
                EditLeague(this, e);
            }
        }

        private void AddTask(Models.Task task, ExplorerTreeNode parentNode)
        {
            ExplorerTreeNode node = new ExplorerTreeNode(ExplorerTreeNode.BuildTaskText(task), ExplorerTreeNode.NodeType.Task);
            node.Task = task;
            parentNode.Nodes.Add(node);

            parentNode.Expand();
        }

		private void competitionTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			OnItemSelected(new EventArgs());
		}

        private void competitionTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void competitionTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                competitionTreeView.SelectedNode = e.Node;
            }
        }

        private void treeContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (competitionTreeView.SelectedNode != null)
            {
                ExplorerTreeNode selectedNode = (ExplorerTreeNode)competitionTreeView.SelectedNode;

				editCompetitionMenuItem.Visible = false;
                newTaskMenuItem.Visible = false;
                editTaskMenuItem.Visible = false;
                editLeagueMenuItem.Visible = false;

                switch (selectedNode.Type)
                {
                    case ExplorerTreeNode.NodeType.Competition:
						editCompetitionMenuItem.Visible = true;
                        newTaskMenuItem.Visible = true;
                        editLeagueMenuItem.Visible = true;
                        break;
                    case ExplorerTreeNode.NodeType.Task:
                        editTaskMenuItem.Visible = true;
                        break;
                    default:
                        e.Cancel = true;
                        break;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

		private void editCompetitionMenuItem_Click(object sender, EventArgs e)
		{
			OnEditCompetition(new EventArgs());
		}

        private void newTaskMenuItem_Click(object sender, EventArgs e)
        {
            OnNewTask(new EventArgs());
        }

        private void editTaskMenuItem_Click(object sender, EventArgs e)
        {
            OnEditTask(new EventArgs());
        }

        private void editLeagueMenuItem_Click(object sender, EventArgs e)
        {
            OnEditLeague(new EventArgs());
        }
    }
}
