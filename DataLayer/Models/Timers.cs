using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Timers
    {
        public long RecId { get; set; }
        public DateTime? Modtime { get; set; }
        public int? Number { get; set; }
        public bool? Active { get; set; }
        public long? ChannelRecId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Priority { get; set; }
        public int? Duration { get; set; }
        public string Title { get; set; }

        public virtual Channels ChannelRec { get; set; }
    }
}
