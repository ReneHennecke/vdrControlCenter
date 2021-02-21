namespace vdrControlService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class FileSystemResponse : ApiResponse
    {
        [DataMember]
        public FileSystemEntry FileSystemEntry { get; set; }

        [DataMember]
        public FileContent FileContent { get; set; }
    }
}
