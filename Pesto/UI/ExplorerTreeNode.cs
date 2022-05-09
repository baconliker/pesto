using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Boris.UI
{
	class ExplorerTreeNode : System.Windows.Forms.TreeNode
	{
		private NodeType m_nodeType;

		public enum NodeType
		{
			Competition,
			Task
		}

		public ExplorerTreeNode(string text, NodeType type) : base(text)
		{
			this.Type = type;
		}

		public static string BuildCompetitionText(Models.Competition competition)
		{
			return competition.Name;
		}

		public static string BuildTaskText(Models.Task task)
		{
			return String.Format("{0} - {1}", task.Number, task.Name);
		}

		public NodeType Type
		{
			get
			{
				return m_nodeType;
			}
			set
			{
				m_nodeType = value;
				switch (m_nodeType)
				{
					case NodeType.Competition:
						this.ImageKey = "Competition";
						this.SelectedImageKey = "Competition";
						break;
					case NodeType.Task:
						this.ImageKey = "Task";
						this.SelectedImageKey = "Task";
						break;
				}
			}
		}

		public Models.Competition Competition { get; set; }
		public Models.Task Task { get; set; }
	}
}
