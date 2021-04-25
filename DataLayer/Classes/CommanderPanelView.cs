namespace DataLayer.Classes
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CommanderPanelView
    {
        [DataMember]
        public string View { get; set; }
        [DataMember]
        public string FullPath { get; set; }
    }
}
