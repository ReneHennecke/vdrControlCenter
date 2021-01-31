namespace vdrControlCenterUI
{
    using DataLayer.Models;
    using System;
    using System.Collections.Generic;

    public class SvdrpChannelList
    {
        public List<Channels> Channels { get; private set; }

        public SvdrpChannelList()
        {
            Channels = new List<Channels>();
        }

        public void ParseMessage(string[] response)
        {
            Channels channel;
            string[] prms;
            string[] nm;
            foreach (string row in response)
            {
                if (row.Length < 5)
                    continue;

                string resp = row.Substring(4);
                resp = resp.Remove(resp.Length - 1);
                if (resp.Length > 0)
                {
                    int j;
                    int pos = resp.IndexOf(' ');
                    string number = resp.Substring(0, pos);
                    prms = resp.Substring(pos + 1).Split(':');
                    nm = prms[0].Split(';');

                    channel = new Channels();
                    int.TryParse(number, out j);
                    channel.Number = j;
                    channel.ChannelName = nm[0].Replace("|", ":");
                    if (nm.Length > 1)
                        channel.ProviderName = nm[1].Replace("|", ":");
                    else
                        channel.ProviderName = string.Empty;
                    int.TryParse(prms[1], out j);
                    channel.Frequency = j;
                    channel.Parameter = prms[2];
                    channel.SignalSource = prms[3];
                    int.TryParse(prms[4], out j);
                    channel.SymbolRate = j;
                    channel.Vpid = prms[5];
                    channel.Apid = prms[6];
                    channel.Tpid = prms[7];
                    channel.Caid = prms[8];
                    channel.Sid = prms[9];
                    channel.Nid = prms[10];
                    channel.Tid = prms[11];
                    channel.Rid = prms[12];
                    channel.Params = resp;
                    channel.ChannelId = $"{channel.SignalSource}-{channel.Nid}-{channel.Tid}-{channel.Sid}";
                    channel.Favourite = false;
                    channel.Modtime = DateTime.Now;

                    Channels.Add(channel);
                }
            }
        }
    }
}
