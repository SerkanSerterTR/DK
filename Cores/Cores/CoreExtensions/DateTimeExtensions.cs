using System;

namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {
        #region DateTimeFormat
        public enum DateTimeFormat
        {
            DayMonthYear,
            DayMonthShortYear,
            DayMonthYearDayName,
            DayMonthNameYear,
            DayMonthNameYearDayName,
            DayMonthNameYearDayNameHourMinute,
            DayMonthNameYearDayNameHourMinuteSecond,
            DayMonthYearHourMinute,
            DayMonthYearDayNameHourMinute,
            DayMonthYearHourMinuteSecond,
            DayMonthYearHourDayNameMinuteSecond,
            MonthDayYear,
            MonthDayYearDayName,
            MonthDayYearHourMinute,
            MonthDayYearDayNameHourMinute,
            MonthDayYearHourMinuteSecond,
            MonthDayYearDayNameHourMinuteSecond,
            MonthNameDayYear,
            MonthNameDayYearDayName,
            MonthNameDayYearHourMinute,
            MonthNameDayYearDayNameHourMinute,
            MonthNameDayYearHourMinuteSecond,
            MonthNameDayYearHourDayNameMinuteSecond,
        }

        private static string GetDateFormat(DateTimeFormat format, char dateSeperator = '.')
        {
            string dFormat = "";
            switch (format)
            {
                case DateTimeFormat.DayMonthYear:
                    dFormat = $"dd{dateSeperator}MM{dateSeperator}yyyy";
                    break;
                case DateTimeFormat.DayMonthShortYear:
                    dFormat = $"dd{dateSeperator}MM{dateSeperator}yy";
                    break;
                case DateTimeFormat.DayMonthNameYear:
                    dFormat = "dd MMMM yyyy";
                    break;
                case DateTimeFormat.DayMonthNameYearDayName:
                    dFormat = "dd MMMM yyyy dddd";
                    break;
                case DateTimeFormat.DayMonthNameYearDayNameHourMinute:
                    dFormat = "dd MMMM yyyy dddd HH:mm";
                    break;
                case DateTimeFormat.DayMonthNameYearDayNameHourMinuteSecond:
                    dFormat = "dd MMMM yyyy dddd HH:mm:ss";
                    break;
                case DateTimeFormat.DayMonthYearDayName:
                    dFormat = $"dd{dateSeperator}MM{dateSeperator}yyyy dddd";
                    break;
                case DateTimeFormat.DayMonthYearHourMinute:
                    dFormat = $"dd{dateSeperator}MM{dateSeperator}yyyy HH:mm";
                    break;
                case DateTimeFormat.DayMonthYearDayNameHourMinute:
                    dFormat = $"dd{dateSeperator}MM{dateSeperator}yyyy dddd HH:mm";
                    break;
                case DateTimeFormat.DayMonthYearHourMinuteSecond:
                    dFormat = $"dd{dateSeperator}MM{dateSeperator}yyyy HH:mm:ss";
                    break;
                case DateTimeFormat.DayMonthYearHourDayNameMinuteSecond:
                    dFormat = $"dd{dateSeperator}MM{dateSeperator}yyyy dddd HH:mm:ss";
                    break;
                case DateTimeFormat.MonthDayYear:
                    dFormat = $"MM{dateSeperator}dd{dateSeperator}yyyy";
                    break;
                case DateTimeFormat.MonthDayYearDayName:
                    dFormat = "MMMM dd yyyy";
                    break;
                case DateTimeFormat.MonthDayYearHourMinute:
                    dFormat = "MMMM dd yyyy HH:mm";
                    break;
                case DateTimeFormat.MonthDayYearDayNameHourMinute:
                    dFormat = "MMMM dd yyyy dddd HH:mm";
                    break;
                case DateTimeFormat.MonthDayYearHourMinuteSecond:
                    dFormat = $"MM{dateSeperator}dd{dateSeperator}yyyy HH:mm:ss";
                    break;
                case DateTimeFormat.MonthDayYearDayNameHourMinuteSecond:
                    dFormat = $"MM{dateSeperator}dd{dateSeperator}yyyy HH:mm:ss";
                    break;
                case DateTimeFormat.MonthNameDayYear:
                    dFormat = "MMMM dd yyyy";
                    break;
                case DateTimeFormat.MonthNameDayYearDayName:
                    dFormat = "MMMM dd yyyy dddd";
                    break;
                case DateTimeFormat.MonthNameDayYearHourMinute:
                    dFormat = "MMMM dd yyyy HH:mm";
                    break;
                case DateTimeFormat.MonthNameDayYearDayNameHourMinute:
                    dFormat = "MMMM dd yyyy dddd HH:mm";
                    break;
                case DateTimeFormat.MonthNameDayYearHourMinuteSecond:
                    dFormat = "MMMM dd yyyy HH:mm:ss";
                    break;
                case DateTimeFormat.MonthNameDayYearHourDayNameMinuteSecond:
                    dFormat = "MMMM dd yyyy dddd HH:mm:ss";
                    break;
                default:
                    break;
            }
            return dFormat;
        }
        #endregion

        /// <summary>
        /// DateTime nesnesini formatıyla string türüne çevirir.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateTimeFormat"></param>
        /// <returns>DateTime</returns>
        public static string ToString(this DateTime date, DateTimeFormat dateTimeFormat = DateTimeFormat.DayMonthYear, char dateSeperator = '.')
        {
            return string.Format(GetDateFormat(dateTimeFormat, dateSeperator), date);
        }

        /// <summary>
        /// Datetime değerinin gün başlangıç değerini döner.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetStartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }

        /// <summary>
        /// Datetime değerinin gün sonu değerini döner.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>DateTime</returns>
        public static DateTime GetEndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }

        /// <summary>
        /// Datetime değerinin hafta başlangıç değerini döner.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="startOfWeek"></param>
        /// <returns>DateTime</returns>
        public static DateTime GetStartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (dateTime.DayOfWeek - startOfWeek)) % 7;
            return dateTime.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Datetime değerinin haftasonu değerini döner.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="startOfWeek"></param>
        /// <returns>DateTime</returns>
        public static DateTime GetEndOfWeek(this DateTime dateTime, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            return GetStartOfWeek(dateTime, startOfWeek).AddDays(6);
        }

        /// <summary>
        /// Datetime değerinin ay başlangıç değerini döner.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>DateTime</returns>
        public static DateTime GetStartOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0);
        }

        /// <summary>
        /// Datetime değerinin ay sonu değerini döner.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>DateTime</returns>
        public static DateTime GetEndOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), 23, 59, 59);
        }

        /// <summary>
        /// Datetime değerinin yıl başlangıç değerini döner.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>DateTime</returns>
        public static DateTime GetStartOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 1, 1, 0, 0, 0);
        }

        /// <summary>
        /// Datetime değerinin yıl sonu değerini döner.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>DateTime</returns>
        public static DateTime GetEndOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 12, 31, 23, 59, 59);
        }

        /// <summary>
        /// İki datetime fakını TimeSpan olarak döner.
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns>TimeSpan</returns>
        public static TimeSpan DateDiffrence(this DateTime date1, DateTime date2)
        {
            TimeSpan span;
            if (date1 < date2)
                span = date2.Subtract(date1);
            else
                span = date1.Subtract(date2);
            return span;
        }
    }
}
