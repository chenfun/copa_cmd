using System;
using System.Globalization;

namespace CopaCmd.Extensions
{
    public static class StringExtensions
    {
        public enum DateType
        {
            Day,
            Min,
            Sec
        }

        #region "Date-related"

        public static string ToDateString(this string d)
        {
            if (string.IsNullOrWhiteSpace(d))
            {
                return null;
            }

            return DateTime.Parse(d).ToString("yyyy/MM/dd");
        }

        public static string ToDateTimeString(this string d)
        {
            return ToDateStringEx(DateTime.Parse(d), DateType.Sec);
        }

        public static string ToDateString(this DateTime d)
        {
            return ToDateStringEx(d, DateType.Day);
        }

        public static string ToDateTimeString(this DateTime d)
        {
            return ToDateStringEx(d, DateType.Sec);
        }

        public static string ToDateString(this DateTime d, DateType T)
        {
            string f = string.Empty;

            switch (T)
            {
                case DateType.Day:
                    f = "yyyy/MM/dd";
                    break;

                case DateType.Min:
                    f = "yyyy/MM/dd HH:mm";
                    break;

                case DateType.Sec:
                    f = "yyyy/MM/dd HH:mm:ss";
                    break;
            }

            return d.ToString(f);
        }

        public static string ToDateString(this DateTime? d)
        {
            return d.ToDateStringEx(DateType.Day);
        }

        public static string ToDateTimeString(this DateTime? d)
        {
            return d.ToDateStringEx(DateType.Sec);
        }

        public static string ToDateStringEx(this DateTime? d, DateType T)
        {
            if (!d.HasValue)
            {
                return "";
            }

            string f = string.Empty;

            switch (T)
            {
                case DateType.Day:
                    f = "yyyy/MM/dd";
                    break;

                case DateType.Min:
                    f = "yyyy/MM/dd HH:mm";
                    break;

                case DateType.Sec:
                    f = "yyyy/MM/dd HH:mm:ss";
                    break;
            }

            return d.GetValueOrDefault().ToString(f);
        }

        public static DateTime? ToDate(this string d)
        {
            return string.IsNullOrWhiteSpace(d) ? null : (DateTime?)DateTime.Parse(d);
        }

        public static string ToCurrency(this string str)
        {
            return str.ToCurrency("n0");
        }

        public static string ToCurrency(this string str, string formatStr)
        {
            double result;

            if (double.TryParse(str, out result))
            {
                return result.ToString(formatStr);
            }
            else
            {
                return str;
            }
        }

        #endregion "Date-related"

        #region "String processing"

        public static string RemoveFromEnd(this string str, string toRemove)
        {
            if (str.EndsWith(toRemove))
            {
                return str.Substring(0, str.Length - toRemove.Length);
            }
            else
            {
                return str;
            }
        }

        #endregion "String processing"

        public static void ShowLog(this string str)
        {
            Console.WriteLine(str);
        }
    }
}