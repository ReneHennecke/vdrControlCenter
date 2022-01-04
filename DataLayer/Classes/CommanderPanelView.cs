namespace DataLayer.Classes;

[DataContract]
public class CommanderPanelView
{
    [DataMember]
    public string View { get; set; }
    [DataMember]
    public string FullPath { get; set; }
}

