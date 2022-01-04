namespace Extensions.Classes;

public class ConnectToSharedFolder : IDisposable
{
    [DllImport("mpr.dll")]
    private static extern int WNetAddConnection2(NetResource netResource, string password, string userName, int flags);

    [DllImport("mpr.dll")]
    private static extern int WNetCancelConnection2(string name, int flags, bool force);

    private readonly string _networkName;

    public ConnectToSharedFolder(string networkName, NetworkCredential credential)
    {
        _networkName = networkName;

        var netResource = new NetResource
        {
            Scope = NetResourceScope.GlobalNetwork,
            ResourceType = NetResourceType.Disk,
            DisplayType = NetResourceDisplayType.Share,
            RemoteName = _networkName
        };

        var userName = string.IsNullOrEmpty(credential.Domain) ? credential.UserName : string.Format(@"{0}\{1}", credential.Domain, credential.UserName);

        var result = WNetAddConnection2(netResource, credential.Password, userName, 0);

        if (result != 0)
            throw new IOException("Error connecting to remote share", result);
    }

    ~ConnectToSharedFolder()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        WNetCancelConnection2(_networkName, 0, true);
    }
}

