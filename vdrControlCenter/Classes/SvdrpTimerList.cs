namespace vdrControlCenterUI.Classes;

public class SvdrpTimerList
{
    public List<DataLayer.Models.Timer> Timers { get; private set; }

    public SvdrpTimerList()
    {
        Timers = new List<DataLayer.Models.Timer>();
    }

    public void ParseMessage(string[] response)
    {
        List<Channel> channels = new List<Channel>();
        using (vdrControlCenterContext context = new vdrControlCenterContext())
        {
            channels = context.Channels.ToList();
        }

        DataLayer.Models.Timer timer;
        string[] prms;
        string[] prm;

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
                    int.TryParse(prms[0], out int number);
                    prm = prms[1].Split(':');
                    if (prm.Length > 7)
                    {
                        // ChannelRecId via Kanalnummer ermitteln 
                        int.TryParse(prm[1], out int j);
                        Channel channel = channels.FirstOrDefault(x => x.Number == j);
                        if (channel != null)
                        {
                            timer = new DataLayer.Models.Timer();
                            timer.Number = number;
                            timer.ChannelRecId = channel.RecId;

                            int.TryParse(prm[0], out j);
                            timer.Active = (j == 1);

                            timer.StartTime = TimeExtension.CalcStartTime(prm[2], prm[3]);
                            timer.EndTime = TimeExtension.CalcEndTime(prm[2], prm[4], timer.StartTime.Value);
                            TimeSpan duration = timer.EndTime.Value - timer.StartTime.Value;

                            int.TryParse(prm[5], out j);
                            timer.Priority = j;
                            int.TryParse(prm[6], out j);
                            timer.Duration = (int)duration.TotalMinutes;
                            string title = prm[7];
                            for (int i = 2; i < prms.Length; i++)
                            {
                                string s = prms[i];
                                if (s.Contains(":"))
                                    s = s.Substring(0, s.IndexOf(':'));
                                title += $" {s}";
                            }
                            timer.Title = title.Replace("\r", string.Empty);
                            timer.Modtime = DateTime.Now;

                            Timers.Add(timer);
                        }
                    }
                }
            }
        }
    }
}

