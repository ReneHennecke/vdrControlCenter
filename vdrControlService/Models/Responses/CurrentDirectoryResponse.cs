namespace vdrControlService.Models.Responses
{
    using System.IO;
    using System.Runtime.Serialization;

    [DataContract]
    public class CurrentDirectoryResponse : ApiResponse
    {
        [DataMember]
        public string FullPath { get; set; }

        [DataMember]
        public DirEntryInfoResult DirEntryInfoResult { get; set; }

        [DataMember]
        public string Irgendwas { get; set; }
    }
}
