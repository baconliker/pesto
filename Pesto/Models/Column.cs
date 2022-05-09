using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models
{
	class Column
	{
        public enum ColumnType
        {
            None,
            PilotNumber,
            PilotName,
            TeamName,
			TeamMembers,
            Score,
            TotalScore,
            Country,
            Motor,
            Wing
        }

        public enum ColumnAlignment
        {
            Left,
            Center,
            Right
        }

        public static string GetAlignmentDescription(ColumnAlignment align)
        {
            switch (align)
            {
                case ColumnAlignment.Center:
                    return "Centre";
                case ColumnAlignment.Left:
                    return "Left";
                case ColumnAlignment.Right:
                    return "Right";
                default:
                    return string.Empty;
            }
        }
    }
}
