namespace vdrControlService.Models.Requests
{
    using System.Runtime.Serialization;

    [DataContract]
    public class DirEntriesInfoRequest : ApiRequest
    {
        [DataMember]
        public string FullPath { get; set; }
    }
}
