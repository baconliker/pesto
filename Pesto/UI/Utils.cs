using System;
using System.Windows.Forms;

namespace ColinBaker.Pesto.UI
{
    class Utils
    {
        public static DateTime BuildDateTime(DateTimePicker datePicker, DateTimePicker timePicker)
        {
            return new DateTime(datePicker.Value.Year, datePicker.Value.Month, datePicker.Value.Day, timePicker.Value.Hour, timePicker.Value.Minute, 0);
        }
    }
}
