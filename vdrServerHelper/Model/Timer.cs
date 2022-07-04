using System.Globalization;

namespace vdrServerHelper.Model
{
    public class Timer
    {
        public int Number { get; set; }
        public int State { get; set; }
        public string? Channel { get; set; }
        public string? Day { get; set; }
        public DateTime  Start { get; set; }
        public DateTime Stop { get; set; }
        public int Lifetime { get; set; }
        public int Priority { get; set; }
        public string? File { get; set; }
        public string? Aux { get; set; }

        public Timer()
        {

        }

        public Timer(string data)
        {
            var prms = data.Split(":");
            if (prms.Length > 7)
            {
                var dt = CalcStartDate(prms[2]);

                int.TryParse(prms[0], out int state);
                Channel = prms[1];
                Day = prms[2];
                Start = CalcStartTime($"{dt:yyyy-MM-dd}", prms[3]);
                Stop = CalcEndTime($"{dt:yyyy-MM-dd}", prms[4], Start);
                int.TryParse(prms[5], out int priority);
                int.TryParse(prms[6], out int lifetime);
                Lifetime = lifetime;
                File = prms[7];
                Aux = prms[8];

                
            }
        }

        private static DateTime CalcStartTime(string startDate, string startTime)
        {
            return DateTime.ParseExact(startDate + " " + startTime, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);
        }

        private static DateTime CalcEndTime(string endDate, string endTime, DateTime startTime)
        {
            if (DateTime.TryParseExact(endDate + " " + endTime, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt) &&
                DateTime.Compare(startTime, dt) > 0)
            {
                dt = dt.AddDays(1);
            }

            return dt;
        }

        private static DateTime CalcStartDate(string startDate)
        {
            var retval = DateTime.MinValue;

            if (!DateTime.TryParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out retval))
            {
                var today = DateTime.Today;
                var repeated = startDate.Split("@");
                if (repeated.Length > 1)
                    startDate = repeated[1];

                if ((repeated[0].Substring(0, 1) == "M" && today.DayOfWeek == DayOfWeek.Monday) ||
                    (repeated[0].Substring(1, 1) == "T" && today.DayOfWeek == DayOfWeek.Tuesday) ||
                    (repeated[0].Substring(2, 1) == "W" && today.DayOfWeek == DayOfWeek.Wednesday) ||
                    (repeated[0].Substring(3, 1) == "T" && today.DayOfWeek == DayOfWeek.Thursday) ||
                    (repeated[0].Substring(4, 1) == "F" && today.DayOfWeek == DayOfWeek.Friday) ||
                    (repeated[0].Substring(5, 1) == "S" && today.DayOfWeek == DayOfWeek.Saturday) ||
                    (repeated[0].Substring(6, 1) == "S" && today.DayOfWeek == DayOfWeek.Sunday))
                    retval = today;

                if (repeated.Length > 1 &&
                    DateTime.TryParseExact(repeated[1], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tmp))
                    retval = tmp;
            }
            

            return retval;
        }
    }
}
