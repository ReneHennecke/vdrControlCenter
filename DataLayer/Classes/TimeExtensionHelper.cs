namespace DataLayer.Classes;

public class TimeExtensionHelper
{
    public int Duration { get; set; }

    public DateTime RecordingTime { get; set; }

    public TimeExtensionHelper(string date, string time, string durationTime)
    {
        int day;
        int month;
        int year;
        int hour;
        int minute;

        int.TryParse(date.Substring(0, 2), out day);
        int.TryParse(date.Substring(3, 2), out month);
        int.TryParse(date.Substring(6, 2), out year);
        int.TryParse(time.Substring(0, 2), out hour);
        int.TryParse(time.Substring(3, 2), out minute);
        RecordingTime = new DateTime(year + 2000, month, day, hour, minute, 0);

        int.TryParse(durationTime.Substring(0, 1), out hour);
        int.TryParse(durationTime.Substring(2, 2), out minute);
        Duration = hour * 60 + minute;
    }
}

