namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Windows.Forms;

    public partial class ServiceConnectorView : UserControl
    {
        private ServiceController _controller;
        private vdrControlCenterContext _context;
        
        public ServiceConnectorView()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {

        }


        public async void LoadData(ServiceController controller)
        {
            _controller = controller;

            if (_context == null)
                _context = new vdrControlCenterContext();

            Stations stations = await _context.Stations.FirstOrDefaultAsync(station => station.VdrControlServicePort > 0);
            if (stations != null)
            {
                lblServiceAddressValue.Text = $"http://{stations.HostAddress}:{stations.VdrControlServicePort}";
                _controller.Url = $"{lblServiceAddressValue.Text}/api/";
            }
        }

        public void ShowConnection(bool isAlive)
        {
            lblConnectionString.Text = isAlive ? "Verbunden" : "Getrennt";
        }
    }
}
