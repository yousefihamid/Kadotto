using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utility
{
    public class DateTimeConvert
    {
        public static string GetGregorianDate(DateTime Date)
        {
            return Date.ToString(DisplayFormat.DateStringFormat);
        }

        public static string GetGregorianDate(DateTime? Date)
        {
            string date = string.Empty;
            if (Date != null)
            {
                date = Date.Value.ToString(DisplayFormat.DateStringFormat);
            }
            return date;
        }

        public static string GetPersianDate(DateTime Date)
        {
            var Persian = new System.Globalization.PersianCalendar();
            return string.Format(DisplayFormat.DateStringPersianFormat, Persian.GetYear(Date), Persian.GetMonth(Date), Persian.GetDayOfMonth(Date));
        }

        public static string GetPersianDate(DateTime? Date)
        {
            string date = string.Empty;
            if (Date != null)
            {
                var Persian = new System.Globalization.PersianCalendar();
                date = string.Format(DisplayFormat.DateStringPersianFormat, Persian.GetYear(Date.Value), Persian.GetMonth(Date.Value), Persian.GetDayOfMonth(Date.Value));
            }
            return date;
        }

        public static DateTime GetDate(string PersianDate)
        {
            DateTime date = new DateTime();
            if (string.IsNullOrEmpty(PersianDate) == false)
            {
                string[] str = PersianDate.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                var Persian = new System.Globalization.PersianCalendar();
                date = Persian.ToDateTime(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]), 0, 0, 0, 0);
            }
            return date;
        }

        public static DateTime GetDate(string Date,string Format)
        {
            DateTime date = new DateTime();
            if (string.IsNullOrEmpty(Date) == false)
                date = DateTime.ParseExact(Date, Format, System.Globalization.CultureInfo.InvariantCulture);
            return date;
        }

        public static DateTime GetSystemDate(string Date)
        {
            DateTime date = new DateTime();
            if (string.IsNullOrEmpty(Date) == false)
                date = DateTime.ParseExact(Date, DisplayFormat.DateStringFormat, System.Globalization.CultureInfo.InvariantCulture);
            return date;
        }

        public static DateTime? GetNullableDate(string PersianDate)
        {
            DateTime? date = null;
            if (string.IsNullOrEmpty(PersianDate) == false)
            {
                string[] str = PersianDate.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                var Persian = new System.Globalization.PersianCalendar();
                date = Persian.ToDateTime(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]), 0, 0, 0, 0);
            }
            return date;
        }

        public static DateTime? GetNullableDate(string Date, string Format)
        {
            DateTime? date = null;
            if (string.IsNullOrEmpty(Date) == false)
                date = DateTime.ParseExact(Date, Format, System.Globalization.CultureInfo.InvariantCulture);
            return date;
        }

        public static DateTime? GetNullableSystemDate(string Date)
        {
            DateTime? date = null;
            if (string.IsNullOrEmpty(Date) == false)
                date = DateTime.ParseExact(Date, DisplayFormat.DateStringFormat, System.Globalization.CultureInfo.InvariantCulture);
            return date;
        }

        public static string GetPersianDateTime(DateTime Date)
        {
            var Persian = new System.Globalization.PersianCalendar();
            return string.Format(DisplayFormat.DateTimeStringPersianFormat, Persian.GetYear(Date), Persian.GetMonth(Date), Persian.GetDayOfMonth(Date),
                Persian.GetHour(Date), Persian.GetMinute(Date));
        }
    }
}
