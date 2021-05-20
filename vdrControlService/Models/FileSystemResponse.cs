namespace vdrControlService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class FileSystemResponse : ApiResponse
    {
        [DataMember]
        public FileSystemEntry Source { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public FileSystemEntry Target { get; set; }
    }
}
