namespace DataLayer.Models;

public partial class StatusInfo
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long RecId { get; set; }
    public int? TotalDiskSpace { get; set; }
    public int? FreeDiskSpace { get; set; }
    public decimal? UsedPercent { get; set; }
    public long SystemSettingsRecId { get; set; }

    public virtual SystemSetting SystemSettingsRec { get; set; }
}

