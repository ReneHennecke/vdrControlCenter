namespace DataLayer.Classes
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Configuration
    {
        [DataMember]
        public CommanderPanelView LastCommanderPanelViewLeft { get; set; }
        [DataMember]
        public CommanderPanelView LastCommanderPanelViewRight { get; set; }
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }
        [DataMember]
        public int Width { get; set; }
        [DataMember]
        public int Height { get; set; }
    }
}
