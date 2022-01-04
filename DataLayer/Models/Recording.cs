namespace DataLayer.Models;

public partial class Recording
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long RecId { get; set; }

    [Required]
    public DateTime Modtime { get; set; }

    public int? Number { get; set; }

    public DateTime? RecordingTime { get; set; }

    public int? Duration { get; set; }

    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(255)]
    public string RecordingPath { get; set; }
}

