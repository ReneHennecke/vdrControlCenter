namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Renci.SshNet;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

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
            _connectPng = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.ConnectPng}");
            _disconnectPng = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.DisconnectPng}");
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

            Stations station = await _context.Stations.FirstOrDefaultAsync(station => station.Sshport > 0);
            if (station != null)
                lblSshAddressValue.Text = $"ssh://{station.HostAddress}:{station.Sshport}";
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
    }
}
