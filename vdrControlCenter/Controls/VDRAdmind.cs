namespace vdrControlCenterUI.Controls
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;

    public partial class VDRAdmindView : UserControl
    {
        WebBrowser _webBrowser;
        vdrControlCenterContext _context;

        public VDRAdmindView()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private async void PostInit()
        {

            _webBrowser = new WebBrowser();
            _webBrowser.Location = new Point(Location.X + 2, Location.Y + 40);
            _webBrowser.Size = new Size(Width - 6, Height - 42);
            _webBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            _webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;

            Controls.Add(_webBrowser);

            _context = new vdrControlCenterContext();
            Stations stations = await _context.Stations.FirstOrDefaultAsync(e => e.MachineName == Environment.MachineName && e.VdradminPort > 0);
            if (stations != null)
            {
                lblAddressValue.Text = $"http://{stations.HostAddress}:{stations.VdradminPort}";
                _webBrowser.Navigate(lblAddressValue.Text.Replace("//", $"//{stations.VdradminUserName}:{stations.VdradminPassword}@"));
            }
            else
                _webBrowser.Navigate("about:blank");   
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           if (_webBrowser.ReadyState == WebBrowserReadyState.Complete)
           {

           }

        }
    }
}
