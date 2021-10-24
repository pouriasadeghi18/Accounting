using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Accounting.App
{
   public static class DateConvertor
    {
        public static string ToShamsi (this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00");
        }
        public static DateTime ToMiladi(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, new System.Globalization.PersianCalendar());
        }
    }
}
