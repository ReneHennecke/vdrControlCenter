namespace DataLayer.Classes
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Configuration
    {
        [DataMember]
        public string LocalFolder { get; set; }
        [DataMember]
        public string RemoteFolder { get; set; }
    }
}
