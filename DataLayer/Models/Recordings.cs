using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Recordings
    {
        public long RecId { get; set; }
        public DateTime? Modtime { get; set; }
        public int? Number { get; set; }
        public DateTime? RecordingTime { get; set; }
        public int? Duration { get; set; }
        public string Title { get; set; }
        public string RecordingPath { get; set; }
    }
}
