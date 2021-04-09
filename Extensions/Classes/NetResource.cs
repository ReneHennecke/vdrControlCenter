namespace Extensions.Classes
{
    using Extensions.Enums;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public class NetResource
    {
        public NetResourceScope Scope;
        public NetResourceType ResourceType;
        public NetResourceDisplayType DisplayType;
        public int Usage;
        public string LocalName;
        public string RemoteName;
        public string Comment;
        public string Provider;
    }
}
