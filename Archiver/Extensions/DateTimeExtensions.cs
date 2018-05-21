using System;

namespace Archiver.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToArhiveTimestamp(this DateTime dateTime) => dateTime.ToString("yyyy_dd_M__HH_mm_ss");
    }
}
