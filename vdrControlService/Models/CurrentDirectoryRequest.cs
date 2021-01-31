namespace vdrControlService.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CurrentDirectoryRequest : ApiRequest
    {
        [DataMember]
        public string FullPath { get; set; }
    }
}
