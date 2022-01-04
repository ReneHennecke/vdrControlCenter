namespace vdrControlCenterUI
{
    using DataLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SvdrpEPGList
    {
        public List<Epg> EPGList { get; private set; }

        public SvdrpEPGList()
        {
            EPGList = new List<Epg>();
        }

        public void ParseMessage(string[] response)
        {
            List<Channel> channels = new List<Channel>();
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                channels = context.Channels.ToList();
            }

            Epg epg = null;
            string channelID = string.Empty;
            string channelName = string.Empty;
            double d = 0D;
            string[] prms;
            int i = 0;
            DateTime now = DateTime.Now;

            foreach (string row in response)
            {
                if (row.Length < 5)
                    continue;

                string resp = row.Substring(4);
                if (resp.Length > 0)
                {
                    switch (resp.Substring(0, 1))
                    {
                        case "C":
                            prms = resp.Substring(2).Split(' ');
                            if (prms.Length > 0)
                            {
                                channelID = prms[0];
                                if (prms.Length > 1)
                                    channelName = prms[1];
                                else
                                    channelName = string.Empty;
                            }
                            else
                                channelID = string.Empty;

                            break;

                        case "E":
                            if (channelID.Length == 0)
                                continue;

                            prms = resp.Substring(2).Split(' ');
                            if (prms.Length < 5)
                            {
                                channelID = string.Empty;
                                continue;
                            }

                            Channel channel = channels.FirstOrDefault(x => x.ChannelId == channelID);
                            if (channel != null)
                            {
                                epg = new Epg();
                                int.TryParse(prms[0], out i);
                                epg.EventId = i;
                                double.TryParse(prms[1], out d);
                                epg.StartTime = DataLayer.Classes.TimeExtension.UnixTimeStampToDateTime(d);
                                int.TryParse(prms[2], out i);
                                epg.Duration = i;
                                epg.TableId = prms[3];
                                epg.Version = prms[4];
                                epg.ChannelRecId = channel.RecId;
                                epg.Modtime = DateTime.Now;
                            }
                            break;

                        case "T":
                            if (epg == null)
                                continue;

                            epg.Title = resp.Substring(2);
                            break;

                        case "S":
                            if (epg == null)
                                continue;

                            epg.ShortDescription = resp.Substring(2);
                            break;

                        case "D":
                            if (epg == null)
                                continue;

                            epg.Description = resp.Substring(2).Replace("|", "\r\n");
                            break;

                        case "G":
                            if (epg == null)
                                continue;

                            epg.GenreCodes = resp.Substring(2);
                            break;

                        case "R":
                            if (epg == null)
                                continue;

                            int.TryParse(resp.Substring(2), out i);
                            epg.ParentalRating = i;
                            break;

                        case "X":
                            if (epg == null)
                                continue;

                            if (epg.Stream != null && epg.Stream.Length > 0)
                                epg.Stream += "|";
                            else
                                epg.Stream = string.Empty;

                            epg.Stream += resp.Substring(2);
                            break;

                        case "V":
                            if (epg == null)
                                continue;

                            double.TryParse(resp.Substring(2), out d);
                            epg.Vps = DataLayer.Classes.TimeExtension.UnixTimeStampToDateTime(d);
                            break;

                        case "e":
                            if (epg != null && epg.StartTime >= now)
                                EPGList.Add(epg);

                            epg = null;
                            break;

                        case "c":
                            channelID = string.Empty;
                            epg = null;
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}
