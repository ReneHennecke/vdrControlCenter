using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Channels
    {
        public Channels()
        {
            Epg = new HashSet<Epg>();
            Timers = new HashSet<Timers>();
        }

        public long RecId { get; set; }
        public DateTime Modtime { get; set; }
        public int? Number { get; set; }
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string ProviderName { get; set; }
        public int? Frequency { get; set; }
        public string Parameter { get; set; }
        public string SignalSource { get; set; }
        public int? SymbolRate { get; set; }
        public string Vpid { get; set; }
        public string Apid { get; set; }
        public string Tpid { get; set; }
        public string Caid { get; set; }
        public string Sid { get; set; }
        public string Nid { get; set; }
        public string Tid { get; set; }
        public string Rid { get; set; }
        public string Params { get; set; }
        public bool? Favourite { get; set; }

        public virtual ICollection<Epg> Epg { get; set; }
        public virtual ICollection<Timers> Timers { get; set; }
    }
}
