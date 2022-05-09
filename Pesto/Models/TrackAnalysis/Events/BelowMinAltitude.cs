using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColinBaker.Pesto.Models.TrackAnalysis.Events
{
	class BelowMinAltitude : TrackEvent
	{
		private enum TimePortionType
		{
			Hours,
			Minutes,
			Seconds
		}

		public BelowMinAltitude(int lowestAltitude, TimeSpan timeUnder)
			: base(EventType.BelowMinAltitude)
		{
			this.LowestAltitude = lowestAltitude;
			this.TimeUnder = timeUnder;
		}

		public int LowestAltitude { get; set; }
		public TimeSpan TimeUnder { get; set; }

		public override string Description
		{
			get
			{
				StringBuilder message = new StringBuilder("Below minimum altitude for ");

				AddTimePortionToMessage(this.TimeUnder.Hours, TimePortionType.Hours, message);
				AddTimePortionToMessage(this.TimeUnder.Minutes, TimePortionType.Minutes, message);
				AddTimePortionToMessage(this.TimeUnder.Seconds, TimePortionType.Seconds, message);

				message.Append(string.Format("lowest altitude reached was {0}m", this.LowestAltitude));

				//if (this.TimeUnder.Hours > 0)
				//{
				//    if (this.TimeUnder.Hours == 1)
				//    {
				//        message += string.Format("{0} hour, ", this.TimeUnder.Hours);
				//    }
				//    else
				//    {
				//        message += string.Format("{0} hours, ", this.TimeUnder.Hours);
				//    }
				//}
				//if (this.TimeUnder.Minutes > 0)
				//{
				//    if (this.TimeUnder.Minutes == 1)
				//    {
				//        message += string.Format("{0} minute, ", this.TimeUnder.Minutes);
				//    }
				//    else
				//    {
				//        message += string.Format("{0} minutes, ", this.TimeUnder.Minutes);
				//    }
				//}
				//if (this.TimeUnder.Seconds > 0)
				//{
				//    if (this.TimeUnder.Seconds == 1)
				//    {
				//        message += string.Format("{0} second, ", this.TimeUnder.Seconds);
				//    }
				//    else
				//    {
				//        message += string.Format("{0} seconds, ", this.TimeUnder.Seconds);
				//    }
				//}

				//message += string.Format("lowest altitude reached was {0}m", this.LowestAltitude);

				return message.ToString();
			}
		}

		private void AddTimePortionToMessage(int number, TimePortionType type, StringBuilder message)
		{
			string typeName = string.Empty;

			if (number > 0)
			{
				if (number == 1)
				{
					switch (type)
					{
						case TimePortionType.Hours:
							typeName = "hour";
							break;
						case TimePortionType.Minutes:
							typeName = "minute";
							break;
						case TimePortionType.Seconds:
							typeName = "second";
							break;
					}
				}
				else
				{
					switch (type)
					{
						case TimePortionType.Hours:
							typeName = "hours";
							break;
						case TimePortionType.Minutes:
							typeName = "minutes";
							break;
						case TimePortionType.Seconds:
							typeName = "seconds";
							break;
					}
				}

				message.Append(string.Format("{0} {1}, ", number, typeName));
			}
		}
	}
}
