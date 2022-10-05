using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.BusinnessLogic.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek endOfWeek)
        {
            int diff = (7 + (endOfWeek - dt.DayOfWeek)) % 7;
            return dt.AddDays(1 * diff).Date;
        }

        public static DateTime SetTime(this DateTime current, int hour, int minute, int second)
        {
            return SetTime(current, hour, minute, second, 0);
        }

        public static DateTime SetTime(this DateTime current, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(current.Year, current.Month, current.Day, hour, minute, second, millisecond);
        }

        public static double From100to60Time(this double time)
        {
            time = time / 60;
            var hours = Math.Floor(time);
            var mins = (60 * (time - hours))/100;
            return Math.Round(hours + mins,2);

        }


        public static double From100to60TimeHour(this double time)
        {
            var hours = Math.Floor(time);
            var mins = (60 * (time - hours)) / 100;
            return Math.Round(hours + mins, 2);

        }

        public static double From60to100TimeHour(this double time)
        {
            var hours = Math.Floor(time);
            var mins = ((time - hours) / 60) * 100;
            return Math.Round(hours + mins, 2);
        }
    }
}
