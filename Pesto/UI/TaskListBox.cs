using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI
{
	class TaskListBox : ListBox
	{
        private const int m_minItemWidth = 200;

        private const int m_competitionIconLeftMargin = 2;
        private const int m_competitionIconTopMargin = 2;

        private const int m_competitionTextLeftMargin = 40;
        private const int m_competitionTextTopMargin = 8;

        private const int m_taskIconLeftMargin = 22;
        private const int m_taskIconTopMargin = 2;

        private const int m_taskTextLeftMargin = 60;
        private const int m_taskTextTopMargin = 8;

		public TaskListBox()
		{
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.ItemHeight = 36;
		}

		public int GetRecommendedWidth()
		{
			int maxItemWidth = m_minItemWidth;

			using (Graphics g = CreateGraphics())
			{
				foreach (TaskListItem item in this.Items)
				{
                    int itemWidth;

                    if (item.Task == null)
                    {
                        int competitionTextWidth = Convert.ToInt32(g.MeasureString(GetCompetitionText(item.Competition), this.Font, 0, System.Drawing.StringFormat.GenericDefault).Width);
                        itemWidth = m_competitionTextLeftMargin + competitionTextWidth;
                    }
                    else
                    {
                        int taskTextWidth = Convert.ToInt32(g.MeasureString(GetTaskText(item.Task), this.Font, 0, System.Drawing.StringFormat.GenericDefault).Width);
                        itemWidth = m_taskTextLeftMargin + taskTextWidth;
                    }

                    if (itemWidth > maxItemWidth)
                    {
                        maxItemWidth = itemWidth;
                    }
                }
			}

			return maxItemWidth;
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				e.DrawBackground();

				if (!this.DesignMode)
				{
                    TaskListItem item = this.Items[e.Index] as TaskListItem;

                    if (item.Task == null)
                    {
                        e.Graphics.DrawImage(Pesto.Properties.Resources.Trophy, e.Bounds.X + m_competitionIconLeftMargin, e.Bounds.Y + m_competitionIconTopMargin, Pesto.Properties.Resources.Trophy.Width, Pesto.Properties.Resources.Trophy.Height);
                        TextRenderer.DrawText(e.Graphics, GetCompetitionText(item.Competition).Replace("&", "&&"), this.Font, new Point(e.Bounds.X + m_competitionTextLeftMargin, e.Bounds.Y + m_competitionTextTopMargin), e.ForeColor);
                    }
                    else
                    {
                        switch (item.Task.Type)
                        {
                            case Models.Task.TaskType.Economy:
                                e.Graphics.DrawImage(Pesto.Properties.Resources.Economy, e.Bounds.X + m_taskIconLeftMargin, e.Bounds.Y + m_taskIconTopMargin, Pesto.Properties.Resources.Economy.Width, Pesto.Properties.Resources.Economy.Height);
                                break;
                            case Models.Task.TaskType.Navigation:
                                e.Graphics.DrawImage(Pesto.Properties.Resources.Navigation, e.Bounds.X + m_taskIconLeftMargin, e.Bounds.Y + m_taskIconTopMargin, Pesto.Properties.Resources.Navigation.Width, Pesto.Properties.Resources.Navigation.Height);
                                break;
                            case Models.Task.TaskType.Precision:
                                e.Graphics.DrawImage(Pesto.Properties.Resources.Precision, e.Bounds.X + m_taskIconLeftMargin, e.Bounds.Y + m_taskIconTopMargin, Pesto.Properties.Resources.Precision.Width, Pesto.Properties.Resources.Precision.Height);
                                break;
                        }

                        TextRenderer.DrawText(e.Graphics, GetTaskText(item.Task).Replace("&", "&&"), this.Font, new Point(e.Bounds.X + m_taskTextLeftMargin, e.Bounds.Y + m_taskTextTopMargin), e.ForeColor);
                    }
				}
				
				e.DrawFocusRectangle();
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			this.Invalidate();
		}

        private static string GetCompetitionText(Models.Competition competition)
        {
            return competition.Name;
        }

        private static string GetTaskText(Models.Task task)
        {
            return string.Format("{0:00} - {1}", task.Number, task.Name);
        }
    }
}
