namespace vdrControlCenterUI.Controls;

public partial class SvdrpStatusInfoView : UserControl
{
    private SvdrpController _controller;
    private vdrControlCenterContext _context;

    public bool RequestEnable
    {
        get { return btnRequest.Enabled; }
        set { btnRequest.Enabled = value; }
    }

    public SvdrpStatusInfoView()
    {
        InitializeComponent();

        if (!DesignMode)
            PostInit();
    }

    public void LoadData(SvdrpController controller)
    {
        _controller = controller;

        if (_context == null)
            _context = new vdrControlCenterContext();

        ReLoad();

        btnRequest.Enabled = false;
    }

    public async void RefreshData(SvdrpStatusInfo svdrpStatusInfo)
    {
        bool reload = false;
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                SystemSetting systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(e => e.MachineName == Environment.MachineName);
                if (systemSettings != null)
                {
                    StatusInfo statusInfo = await _context.StatusInfo.FirstOrDefaultAsync(e => e.SystemSettingsRecId == systemSettings.RecId);
                    if (statusInfo != null)
                    {
                        statusInfo.TotalDiskSpace = svdrpStatusInfo.Total;
                        statusInfo.FreeDiskSpace = svdrpStatusInfo.Free;
                        statusInfo.UsedPercent = svdrpStatusInfo.Percent;
                        _context.Entry(statusInfo).State = EntityState.Modified;

                        systemSettings.LastUpdateStatus = DateTime.Now;
                        _context.Entry(systemSettings).State = EntityState.Modified;

                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        reload = true;
                    }
                }
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        if (reload)
            ReLoad();
    }

    private void PostInit()
    {
        btnRequest.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SsivRequestPng}");
    }

    private void btnRequest_Click(object sender, System.EventArgs e)
    {
        _controller.SendStatusInfoRequest();
    }

    private async void ReLoad()
    {
        SystemSetting systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(e => e.MachineName == Environment.MachineName);
        if (systemSettings != null)
        {
            StatusInfo statusInfo = await _context.StatusInfo.FirstOrDefaultAsync(e => e.SystemSettingsRecId == systemSettings.RecId);
            if (systemSettings.LastUpdateStatus.HasValue &&
                statusInfo.TotalDiskSpace.HasValue &&
                statusInfo.FreeDiskSpace.HasValue &&
                statusInfo.UsedPercent.HasValue)
            {
                lblGreen.Visible = (lblGreen.Width > 0);
                lblRed.Visible = (lblRed.Width > 0);

                lblTotalValue.Text = $"{statusInfo.TotalDiskSpace / 1024:0,0} GB";
                lblFreeValue.Text = $"{statusInfo.FreeDiskSpace / 1024:0,0} GB";
                lblPercentValue.Text = $"{statusInfo.UsedPercent:0.0} %";
                    
                int maxLength = lblPercentValue.Size.Width; // Das Label hat dieselbe Breite wie die Balken-Label
                int height = lblRed.Size.Height;
                int calcRed = (int)(maxLength * statusInfo.UsedPercent / 100);

                lblRed.Size = new Size(calcRed - 1, height); // Etwas kleiner darstellen, um einen Zwischenraum anzuzeigen
                lblGreen.Location = new Point(lblRed.Location.X + calcRed + 1, lblGreen.Location.Y); // Etwas größer...
                lblGreen.Size = new Size(maxLength - calcRed - 2, height);
            }

            lblRequestInfo.Text = $"{systemSettings.LastUpdateStatus:dd.MM.yyyy HH:mm:ss}";
        }
    }
}

