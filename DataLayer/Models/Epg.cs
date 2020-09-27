using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public partial class Epg
    {
        public long RecId { get; set; }
        public DateTime? Modtime { get; set; }
        public long? ChannelRecId { get; set; }
        public int? EventId { get; set; }
        public DateTime? StartTime { get; set; }
        public int? Duration { get; set; }
        public string TableId { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string GenreCodes { get; set; }
        public int? ParentalRating { get; set; }
        public string Stream { get; set; }
        public DateTime? Vps { get; set; }
        public int? DurationComputed { get; private set; }
        public DateTime? EndTimeComputed { get; private set; }
        public string ChannelNameComputed
        {
            get
            {
                string channelName = string.Empty;
                if (ChannelRec != null && ChannelRec.ChannelName != null)
                    channelName = ChannelRec.ChannelName;

                return channelName;
            }
        }

        public virtual Channels ChannelRec { get; set; }
    }
}
