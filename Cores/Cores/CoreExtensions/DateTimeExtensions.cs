using System;

namespace Cores.CoreExtensions
{
    public static partial class Extensions
    {

        public enum DateTimeFormat
        {
            DayMonthYear,
            DayMonthShortYear,
            DayNameDayMonthYear,
            DayMonthNameYear,
            DayNameDayMonthNameYear,
            DayNameDayMonthNameYearHourMinute,
            DayNameDayMonthNameYearHourMinuteSecond,
            DayMonthYearHourMinute,
            DayNameDayMonthYearHourMinute,
            DayMonthYearHourMinuteSecond,
            DayNameDayMonthYearHourMinuteSecond
        }

        private static string GetDateFormat(DateTimeFormat format)
        {
            string dFormat = "";
            switch (format)
            {
                case DateTimeFormat.DayMonthYear:
                    dFormat = "dd.MM.yyyy";
                    break;
                case DateTimeFormat.DayMonthShortYear:
                    dFormat = "dd.MM.yy";
                    break;
                case DateTimeFormat.DayMonthNameYear:
                    dFormat = "dd MMMM yyyy";
                    break;
                case DateTimeFormat.DayNameDayMonthNameYear:
                    dFormat = "dddd dd MMMM yyyy";
                    break;
                case DateTimeFormat.DayNameDayMonthNameYearHourMinute:
                    dFormat = "dddd dd MMMM yyyy HH:mm";
                    break;
                case DateTimeFormat.DayNameDayMonthNameYearHourMinuteSecond:
                    dFormat = "dddd dd MMMM yyyy HH:mm:ss";
                    break;
                case DateTimeFormat.DayNameDayMonthYear:
                    dFormat = "dddd dd.MM.yyyy";
                    break;
                case DateTimeFormat.DayMonthYearHourMinute:
                    dFormat = "dd.MM.yyyy HH:mm";
                    break;
                case DateTimeFormat.DayNameDayMonthYearHourMinute:
                    dFormat = "dddd dd.MM.yyyy HH:mm";
                    break;
                case DateTimeFormat.DayMonthYearHourMinuteSecond:
                    dFormat = "dd.MM.yyyy HH:mm:ss";
                    break;
                case DateTimeFormat.DayNameDayMonthYearHourMinuteSecond:
                    dFormat = "dddd dd.MM.yyyy HH:mm:ss";
                    break;
                default:
                    dFormat = string.Empty;
                    break;
            }
            return dFormat;
        }

        /// <summary>
        /// DateTime nesnesini formatıyla string türüne çevirir.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateTimeFormat"></param>
        /// <returns></returns>
        public static string xToString(this DateTime date, DateTimeFormat dateTimeFormat = DateTimeFormat.DayMonthYear)
        {
            return string.Format(GetDateFormat(dateTimeFormat), date);
        }
    }
}
