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

    // Transcode
    public int? TcAudioBitRate { get; set; }
    public bool TcRemoveAudio { get; set; }

    [MaxLength(255)]
    public string TcTarget { get; set; }

    public int? TcVideoBitRate { get; set; }
    public int? TcAudioChannel { get; set; }

    public int? TcVideoFps { get; set; }

    public double? TcVideoTimeScale { get; set; }

    public TimeSpan? TcMaxVideoDuration { get; set; }

    public int? TcVideoSize { get; set; }

    public int TcVideoCodec { get; set; }

    public int TcVideoFormat { get; set; }

    [MaxLength(30)]
    public string TcPixelFormat { get; set; }

    public int TcVideoAspectRatio { get; set;}    

    public int TcThreads { get; set; }

    public int? TcAudioSampleRate { get; set; }
}
