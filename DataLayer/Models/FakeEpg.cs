using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public partial class FakeEpg
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
        public bool? Favourite { get; set; }
        public DateTime? EndTime { get; set; }
        public int? DurationMinutes { get; set; }
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public long ChannelsRecId { get; set; }
        public string VPID { get; set; }
        public long TimersRecId { get; set; }
        public long RecordingsRecId { get; set; }
        public int SymbolIndex { get; set; }
    }
}
