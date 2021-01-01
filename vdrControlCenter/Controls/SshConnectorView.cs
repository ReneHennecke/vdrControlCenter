namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Renci.SshNet;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
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

            List<Stations> stations = await _context.Stations
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
            Stations stations = (Stations)e.ListItem;
            e.Value = $"ssh://{stations.HostAddress}:{stations.Sshport}";
        }

        public Stations GetSshValue()
        {
            Stations stations = (Stations)cmbSshAddressValue.SelectedItem;
            return stations;
        }
    }
}
