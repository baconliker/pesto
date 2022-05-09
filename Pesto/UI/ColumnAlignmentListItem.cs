using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.UI
{
    class ColumnAlignmentListItem
    {
        public ColumnAlignmentListItem(Models.Column.ColumnAlignment align)
        {
            this.Align = align;
        }

        public Models.Column.ColumnAlignment Align { get; set; }

        public string Description
        {
            get
            {
                return Models.Column.GetAlignmentDescription(this.Align);
            }
        }
    }
}
