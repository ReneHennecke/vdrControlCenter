using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class StatusInfo
    {
        public long RecId { get; set; }
        public int? TotalDiskSpace { get; set; }
        public int? FreeDiskSpace { get; set; }
        public decimal? UsedPercent { get; set; }
        public long SystemSettingsRecId { get; set; }

        public virtual SystemSettings SystemSettingsRec { get; set; }
    }
}
