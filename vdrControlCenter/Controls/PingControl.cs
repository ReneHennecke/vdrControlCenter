namespace vdrControlCenterUI.Controls;

using System.Diagnostics;
using System.Net.NetworkInformation;

public partial class PingControl : UserControl
{
    private static readonly object _lockObject = new object();
    private int _timeout = 100;
    public int TimeOut
    {
        set { _timeout = value; }
    }

    private Stopwatch _stopWatch;
    private List<Task> _tasks;
    private PingReplyEventArgsRaX _pingReplyEventArgs;

    public event PingReplyEventHandler PingReply;
    public delegate void PingReplyEventHandler(object sender, PingReplyEventArgsRaX e);

    public PingControl()
    {
        InitializeComponent();

        if (!DesignMode)
            Visible = false;
    }

    public void Ping(string hostAddress)
    {
        PingInit();
        PingCreate(hostAddress);
        PingStart();
    }

    public void PingList(List<string> hostAddresses)
    {
        PingInit();
        foreach (string hostAddress in hostAddresses)
            PingCreate(hostAddress);
        PingStart();
    }

    public void Scan(string baseHostAddress, ushort from, ushort to)
    {
        if (from > to || to > 255)
            return;

        PingInit();
        for (ushort i = from; i < to; i++)
        {
            string hostAddress = $"{baseHostAddress}{i}";
            PingCreate(hostAddress);
        }
        PingStart();
    }

    protected virtual void OnPingReply(PingReplyEventArgsRaX e)
    {
        PingReply?.Invoke(this, e);
    }

    private void PingInit()
    {
        _stopWatch = new Stopwatch();
        _stopWatch.Start();

        _tasks = new List<Task>();
        _pingReplyEventArgs = new PingReplyEventArgsRaX();
    }

    private void PingCreate(string hostAddress)
    {
        Ping ping = new Ping();
        Task task = PingUpdateAsync(ping, hostAddress);
        _tasks.Add(task);
    }

    private async void PingStart()
    {
        await Task.WhenAll(_tasks).ContinueWith(t =>
        {
            _stopWatch.Stop();
            _pingReplyEventArgs.Elapsed = _stopWatch.Elapsed;
            PingStop();
        });
    }

    private async Task PingUpdateAsync(Ping ping, string ip)
    {
        PingReply reply = await ping.SendPingAsync(ip, _timeout);
        PingReplyRaX pingReplyRaX = new PingReplyRaX()
        {
            PingedHostAddress = System.Net.IPAddress.Parse(ip),
            Reply = reply
        };
        _pingReplyEventArgs.ReplyList.Add(pingReplyRaX);

        if (reply.Status == IPStatus.Success)
        {
            lock (_lockObject)
            {
                _pingReplyEventArgs.Found++;
            }
        }

    }
    private void PingStop()
    {
        OnPingReply(_pingReplyEventArgs);
    }
}

