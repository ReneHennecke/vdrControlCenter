namespace vdrControlService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class FileSystemEntryRequest : ApiRequest
    {
        [DataMember]
        public string FullPath { get; set; }

        [DataMember]
        public string FormerFullPath { get; set; }
    }
}
