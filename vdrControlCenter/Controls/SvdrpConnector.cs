using System;
namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class SvdrpConnector : UserControl
    {
        private const string _connect = "Verbinden";
        private const string _disconnect = "Trennen";
        private Image _connectPng;
        private Image _disconnectPng;
        private SvdrpController _controller;
        private vdrControlCenterContext _context;


        public SvdrpConnector()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {
            _connectPng = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.ConnectPng}");
            _disconnectPng = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.DisconnectPng}");
            btnConnect_Disconnect.Image = _connectPng;
        }

        private void btnConnect_Disconnect_Click(object sender, EventArgs e)
        {
            if (btnConnect_Disconnect.Text == _connect)
                _controller.SendConnectRequest();
            else
                _controller.SendDisconnectRequest();
        }

        public void LoadData(SvdrpController controller, vdrControlCenterContext con)
        {
            _controller = controller;
            _context = con;

            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                Stations station = _context.Stations.FirstOrDefault(station => station.Svdrpport > 0);
                if (station != null)
                    lblSvdrpAddressValue.Text = $"svdrp://{station.HostAddress}:{station.Svdrpport}";
            }
        }

        public void ShowConnection(SvdrpConnectionInfo connectionInfo)
        {
            if (connectionInfo.IsConnected)
            {
                lblIdValue.Text = $"{connectionInfo.Id}";
                lblStateValue.Text = $"{connectionInfo.ConnectionString}";
                btnConnect_Disconnect.Text = _disconnect;
                btnConnect_Disconnect.Image = _disconnectPng;
            }
            else
            {
                lblIdValue.Text = string.Empty;
                lblStateValue.Text = string.Empty;
                btnConnect_Disconnect.Text = _connect;
                btnConnect_Disconnect.Image = _connectPng;
            }
        }

    }
}
