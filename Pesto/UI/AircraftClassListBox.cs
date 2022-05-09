using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI
{
    class AircraftClassListBox : ListBox
    {
        public AircraftClassListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.ItemHeight = 36;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();

                if (!this.DesignMode)
                {
                    AircraftClassListItem item = this.Items[e.Index] as AircraftClassListItem;

                    TextRenderer.DrawText(e.Graphics, item.ToString(), this.Font, new Point(e.Bounds.X, e.Bounds.Y + 8), e.ForeColor);
                }

                e.DrawFocusRectangle();
            }
        }
    }
}
