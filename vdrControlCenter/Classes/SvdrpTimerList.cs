namespace vdrControlCenterUI
{
    using DataLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SvdrpTimerList
    {
        public List<Timers> Timers { get; private set; }

        public SvdrpTimerList()
        {
            Timers = new List<Timers>();
        }

        public void ParseMessage(string[] response)
        {
            List<Channels> channels = new List<Channels>();
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                channels = context.Channels.ToList();
            }

            Timers timer;
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
                            Channels channel = channels.FirstOrDefault(x => x.Number == j);
                            if (channel != null)
                            {
                                timer = new Timers();
                                timer.Number = number;
                                timer.ChannelRecId = channel.RecId;

                                int.TryParse(prms[0], out j);
                                timer.Active = (j == 1);

                                timer.StartTime = DataLayer.Classes.TimeExtension.CalcStartTime(prm[2], prm[3]);
                                timer.EndTime = DataLayer.Classes.TimeExtension.CalcEndTime(prm[2], prm[4], timer.StartTime.Value);
                                TimeSpan duration = timer.EndTime.Value - timer.StartTime.Value;

                                int.TryParse(prm[5], out j);
                                timer.Priority = j;
                                int.TryParse(prm[6], out j);
                                timer.Duration = (int)duration.TotalMinutes;
                                timer.Title = prm[7].Replace("\r", string.Empty);
                                for (int i = 2; i < prms.Length; i++)
                                {
                                    string s = prms[i];
                                    if (s.Contains(":"))
                                        s = s.Substring(0, s.IndexOf(':'));
                                    timer.Title += $" {s}";
                                }
                                timer.Modtime = DateTime.Now;

                                Timers.Add(timer);
                            }
                        }
                    }
                }
            }
        }
    }
}
