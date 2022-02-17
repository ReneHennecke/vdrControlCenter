namespace vdrControlCenterUI.Controls;

public partial class VDRAdmindController : UserControl
{
    private WebBrowser _webBrowser;
    private vdrControlCenterContext _context;
    private frmMain _frmMain;

    public frmMain MainForm
    {
        set => _frmMain = value;
    }

    public VDRAdmindController()
    {
        InitializeComponent();

        if (!DesignMode)
            PostInit();
    }

    private async void PostInit()
    {
        _frmMain.AddMessage("LOAD VDRADMIN");

        _webBrowser = new WebBrowser();
        _webBrowser.Location = new Point(Location.X + 2, Location.Y + 40);
        _webBrowser.Size = new Size(Width - 6, Height - 42);
        _webBrowser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

        _webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;

        Controls.Add(_webBrowser);

        _context = new vdrControlCenterContext();
        Station stations = await _context.Stations.FirstOrDefaultAsync(e => e.VdradminPort > 0);
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

