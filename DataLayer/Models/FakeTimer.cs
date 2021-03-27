namespace DataLayer.Models
{
    using System;

    public class FakeTimer
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
        public string ChannelName { get; set; }
    }
}
