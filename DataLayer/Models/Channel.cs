namespace DataLayer.Models;

public partial class Channel
{
    public Channel()
    {
        Epg = new HashSet<Epg>();
        Timers = new HashSet<Timer>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long RecId { get; set; }

    [Required]
    public DateTime Modtime { get; set; }

    public int? Number { get; set; }

    [Required]
    [MaxLength(50)]
    public string ChannelId { get; set; }

    [MaxLength(100)]
    public string ChannelName { get; set; }

    [MaxLength(50)]
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
    public virtual ICollection<Timer> Timers { get; set; }       
}

