namespace DataLayer.Models;

public partial class SystemSetting
{
    public SystemSetting()
    {
        StatusInfo = new HashSet<StatusInfo>();
    }

    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long RecId { get; set; }

    [Required]
    [MaxLength(15)]
    public string MachineName { get; set; }

    public short? ChannelListType { get; set; }

    public bool? FavouritesOnly { get; set; }

    public bool? SaveBufferToFile { get; set; }

    public bool? EnableLogging { get; set; }

    public DateTime? LastUpdateChannels { get; set; }

    public DateTime? LastUpdateEpg { get; set; }

    public DateTime? LastUpdateTimers { get; set; }

    public DateTime? LastUpdateRecordings { get; set; }

    public DateTime? LastUpdateStatus { get; set; }

    [MaxLength(255)]
    public string PathToChannelLogos { get; set; }

    public virtual ICollection<StatusInfo> StatusInfo { get; set; }

    public string Configuration { get; set; }


    [MaxLength(255)]
    public string UPnPDownloadPath { get; set; }

    public bool? OverwriteUPnPDownload { get; set; }
}
