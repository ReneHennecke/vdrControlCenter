namespace vdrControlCenterUI.Classes;

public class SvdrpRecordingList
{
    public List<Recording> Recordings { get; private set; }

    public SvdrpRecordingList()
    {
        Recordings = new List<Recording>();
    }

    public void ParseMessage(string[] response)
    {
        string[] prms;
        foreach (string row in response)
        {
            if (row.Length < 5)
                continue;

            string resp = row.Substring(4);
            if (resp.Length > 0)
            {
                prms = resp.Split(' ');
                if (prms.Length > 0)
                {
                    int.TryParse(prms[0], out int j);

                    Recording recording = new Recording();
                    recording.Number = j;
                    recording.Title = prms[4];
                    for (int i = 5; i < prms.Length; i++)
                    {
                        recording.Title += " " + prms[i];
                    }
                    recording.Title = recording.Title.TrimStart();

                    TimeExtensionHelper helper = new TimeExtensionHelper(prms[1], prms[2], prms[3]);
                    recording.RecordingTime = helper.RecordingTime;
                    recording.Duration = helper.Duration;
                    recording.Modtime = DateTime.Now;
                    string[] p = recording.Title.Split('~');
                    if (p.Length > 1)
                    {
                        recording.RecordingPath = p[0];
                        recording.Title = p[1];
                    }

                    Recordings.Add(recording);
                }
            }
        }
    }
}

