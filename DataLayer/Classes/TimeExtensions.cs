namespace DataLayer.Classes
{
    using System;
    using System.Globalization;

    public static class TimeExtension
    {
        public static DateTime CalcStartTime(string startDate, string startTime)
        {
            return DateTime.ParseExact(startDate + " " + startTime, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);
        }

        public static DateTime CalcEndTime(string endDate, string endTime, DateTime startTime)
        {
            DateTime dt = DateTime.ParseExact(endDate + " " + endTime, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);
            if (DateTime.Compare(startTime, dt) > 0)
            {
                dt = dt.AddDays(1);
            }

            return dt;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unixTimeStamp).ToLocalTime();

            return dt;
        }

        public static double DateTimeToUnixTimeStamp(DateTime dt)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dt) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public static DateTime UnixTimeStamp()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        }
    }
}
