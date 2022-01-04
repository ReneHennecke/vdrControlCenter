namespace Extensions.Classes;

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

