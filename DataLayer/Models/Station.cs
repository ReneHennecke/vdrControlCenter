namespace DataLayer.Models;

public partial class Station
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long RecId { get; set; }

    [Required]
    [MaxLength(15)]
    public string MachineName { get; set; }

    [Required]
    [MaxLength(15)]
    public string HostAddress { get; set; }

    [Required]
    public int StationType { get; set; }

    public string Description { get; set; }
    
    public int? Sshport { get; set; }

    [MaxLength(30)]
    public string SshuserName { get; set; }

    [MaxLength(1024)]
    public string Sshpassword { get; set; }

    public int? Svdrpport { get; set; }

    [MaxLength(30)]
    public string SambaUserName { get; set; }

    [MaxLength(1024)]
    public string SambaPassword { get; set; }

    [MaxLength(255)]
    public string PathToRecordings { get; set; }

    public int? VdrControlServicePort { get; set; }

    [MaxLength(17)]
    public string MacAddress { get; set; }

    public bool? EnableWol { get; set; }

    public int? VdradminPort { get; set; }

    [MaxLength(30)]
    public string VdradminUserName { get; set; }

    [MaxLength(1024)]
    public string VdradminPassword { get; set; }
}

