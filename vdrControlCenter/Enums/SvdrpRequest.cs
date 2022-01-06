namespace vdrControlCenterUI.Enums;

public enum SvdrpRequest : ushort
{
    // Verbindung
    Connect,
    Disconnect,

    // Status
    GetStatusInfo,

    // Kanäle
    GetChannelList,
    AddChannel,
    RemoveChannel,

    // Aufnahmen
    GetRecordings,
    GetRecording,
    RemoveRecording,
    UpdateRecordings,
    CutRecording,

    // Timer
    GetTimerList,
    AddTimer,
    RemoveTimer,
    CheckTimer,
        
    // EPG
    GetEPGList,

    // Weiteres
    Check,
    Send_message,
    Hitk,
    Undefined = 999
};


