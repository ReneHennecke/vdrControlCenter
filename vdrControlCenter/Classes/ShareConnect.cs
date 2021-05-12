namespace vdrControlCenterUI.Classes
{
    using System.Net;
    using vdrControlCenterUI.Enums;
    public class ShareConnect
    {
        public string MachineName { get; set; }
        public string HostAddress { get; set; }
        public int Port { get; set; }
        public ShareTyp ShareTyp { get; set; }
        public NetworkCredential NetworkCredential { get; set; }
        public ShareConnectState State { get; set; }
        public object Tag { get; set; }
        public string DisplayName
        {
            get
            {
                string retval = $"{MachineName} · {HostAddress}:{Port}";
                switch (ShareTyp)
                {
                    case ShareTyp.SMB:
                        retval += " · " + (State == ShareConnectState.DisConnected ? "Getrennt" : "Verbunden") + " · ";
                        break;
                    case ShareTyp.vdrControlService:
                        retval += " · ";
                        switch (State)
                        {
                            case ShareConnectState.DisConnected:
                                retval += "Getrennt";
                                break;
                            case ShareConnectState.Connected:
                                retval += "Verbunden";
                                break;
                            case ShareConnectState.Idle:
                                retval += "Im Leerlauf";
                                break;
                            case ShareConnectState.InRequest:
                                retval += "Abfrage läuft";
                                break;
                            case ShareConnectState.IsAlive:
                                retval += "Verfügbar";
                                break;
                            default: break;
                        }
                        retval += " · ";
                        break;
                    default:
                        break;
                }

                retval += "»" + FullPath;

                return retval;
            }
        }
        public string FullPath { get; set; }

        public string Entry
        {
            get => $"{MachineName}{HostAddress}:{Port}»{FullPath}";
        }

        public string Url
        {
            get => ShareTyp ==  ShareTyp.vdrControlService ? $"http://{HostAddress}:{Port}/api/" : string.Empty;
        }
    }
}
