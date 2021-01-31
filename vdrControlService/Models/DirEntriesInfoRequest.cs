namespace vdrControlService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class DirEntriesInfoRequest : ApiRequest
    {
        [DataMember]
        public string FullPath { get; set; }
    }
}
