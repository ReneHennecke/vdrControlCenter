namespace vdrControlCenterUI.Controls;

public partial class SshConnectorView : UserControl
{
    private SshController _controller;
    private vdrControlCenterContext _context;
    private const string _connect = "Verbinden";
    private const string _disconnect = "Trennen";
    private Image _connectPng;
    private Image _disconnectPng;

    public SshConnectorView()
    {
        InitializeComponent();

        if (!DesignMode)
            PostInit();
    }

    private void PostInit()
    {
        _connectPng = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SshConnectPng}");
        _disconnectPng = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SshDisconnectPng}");
        btnConnect_Disconnect.Image = _connectPng;
    }

    private async void btnConnect_Disconnect_Click(object sender, EventArgs e)
    {
        if (btnConnect_Disconnect.Text == _connect)
            await _controller.SendConnectRequest();
        else
            _controller.SendDisconnectRequest();
    }

    public async void LoadData(SshController controller)
    {
        _controller = controller;

        if (_context == null)
            _context = new vdrControlCenterContext();

        List<Station> stations = await _context.Stations
                                                    .Where(station => station.Sshport > 0 && !string.IsNullOrWhiteSpace(station.SshuserName))
                                                    .OrderBy(stations => stations.HostAddress)
                                                    .ToListAsync();
        cmbSshAddressValue.DataSource = stations;
        cmbSshAddressValue.DisplayMember = 
        cmbSshAddressValue.ValueMember = "RecId";
    }

    public void ShowConnection(SshClient sshClient)
    {
        if (sshClient.IsConnected)
        {
            lblConnectionString.Text = $"Server-Version:{sshClient.ConnectionInfo.ServerVersion} Client-Version:{sshClient.ConnectionInfo.ClientVersion}";
            btnConnect_Disconnect.Text = _disconnect;
            btnConnect_Disconnect.Image = _connectPng;
        }
        else
        {
            lblConnectionString.Text = string.Empty;
            btnConnect_Disconnect.Text = _connect;
            btnConnect_Disconnect.Image = _disconnectPng;
        }
    }

    private void cmbSshAddressValue_Format(object sender, ListControlConvertEventArgs e)
    {
        Station stations = (Station)e.ListItem;
        e.Value = $"ssh://{stations.HostAddress}:{stations.Sshport}";
    }

    public Station GetSshValue()
    {
        Station stations = (Station)cmbSshAddressValue.SelectedItem;
        return stations;
    }
}

