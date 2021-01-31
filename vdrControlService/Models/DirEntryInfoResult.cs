namespace vdrControlService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class DirEntryInfoResult : InfoResult
    {
        [DataMember]
        public DirEntryInfo DirEntryInfo { get; set; }
    }
}
