namespace vdrControlService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class FileSystemEntryRequest : ApiRequest
    {
        [DataMember]
        public FileSystemEntry Source { get; set; }
        [DataMember]
        public FileSystemEntry Target { get; set; }

        [DataMember]
        public string Content { get; set; }
    }
}
