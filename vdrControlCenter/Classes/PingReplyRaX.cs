namespace vdrControlCenterUI.Classes
{
    using System.Net;
    using System.Net.NetworkInformation;

    public class PingReplyRaX
    {
        public IPAddress PingedHostAddress { get; set; }
        public PingReply Reply { get; set; }
    }
}
