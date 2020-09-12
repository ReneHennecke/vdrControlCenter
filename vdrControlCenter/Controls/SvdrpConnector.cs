using System;
namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Drawing;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class SvdrpConnector : UserControl
    {
        private const string _connect = "Verbinden";
        private const string _disconnect = "Trennen";
        private Image _connectPng;
        private Image _disconnectPng;

        public SvdrpController Owner { get; set; }


        public SvdrpConnector()
        {
            InitializeComponent();

            PostInit();
        }

        private async void PostInit()
        {
            _connectPng = Globals.LoadImage($"{Globals.ImageFolder}{Globals.ConnectPng}");
            _disconnectPng = Globals.LoadImage($"{Globals.ImageFolder}{Globals.DisconnectPng}");
            btnConnect_Disconnect.Image = _connectPng;

            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                Stations station = await context.Stations.FirstOrDefaultAsync(station => station.Svdrpport > 0);
                if (station != null)
                    lblSvdrpAddressValue.Text = $"svdrp://{station.HostAddress}:{station.Svdrpport}";
            }
        }

        private void btnConnect_Disconnect_Click(object sender, EventArgs e)
        {
            if (btnConnect_Disconnect.Text == _connect)
                Owner.SendConnectRequest();
            else
                Owner.SendDisconnectRequest();
        }
        
        public void ShowConnection(SvdrpConnectionInfo connectionInfo)
        {
            lblStateValue.Text = connectionInfo.ConnectionString;
            if (connectionInfo.IsConnected)
            {
                btnConnect_Disconnect.Text = _disconnect;
                btnConnect_Disconnect.Image = _connectPng;
            }
            else
            {
                btnConnect_Disconnect.Text = _connect;
                btnConnect_Disconnect.Image = _connectPng;
            }
        }

    }
}
