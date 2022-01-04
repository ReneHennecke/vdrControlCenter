namespace DataLayer.Models;

public partial class FindEntry
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long RecId { get; set; }
    public int SymbolIndex { get; set; }
    public long? ChannelRecId { get; set; }
    public DateTime? StartTime { get; set; }
    public int? DurationMinutes { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public DateTime? Vps { get; set; }
    public string ChannelName { get; set; }
    public string GenreCodes { get; set; }
    public int? ParentalRating { get; set; }
}

