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
        public bool Connected { get; set; }
        public string DisplayName
        {
            get
            {
                string retval = $"{MachineName} · {HostAddress}:{Port}";
                if (ShareTyp != ShareTyp.Local)
                    retval += " · " + (Connected ? "Verbunden" : "Getrennt") + " · ";

                retval += "»" + FullPath;

                return retval;
            }
        }
        public string FullPath { get; set; }

        public string Entry
        {
            get => $"{MachineName}{HostAddress}:{Port}»{FullPath}";
        }
    }
}
