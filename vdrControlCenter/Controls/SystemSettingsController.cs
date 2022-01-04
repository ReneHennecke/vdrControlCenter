namespace vdrControlCenterUI.Controls;

public partial class SystemSettingsController : UserControl
{
    private vdrControlCenterContext _context;
    private frmMain frmMain;
    private int _prevSelectedIndex = -1;

    public frmMain MainForm
    {
        set { frmMain = value; }
    }

    public SystemSettingsController()
    {
        InitializeComponent();

        if (!DesignMode)
            PostInit();
    }

    private async void PostInit()
    {
        btnNew.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SystemSettingsNewPng}");
        btnDel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SystemSettingsDelPng}");

        btnPathToChannelLogos.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SystemSettingsFindPng}");
        btnPathToRecordings.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SystemSettingsFindPng}");

        picMacExclamation.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.ExclamationPng}");

        cmbChannelListTyp.DataSource = Enum.GetValues(typeof(ChannelType));
        cmbStationType.DataSource = Enum.GetValues(typeof(StationType));

        if (_context == null)
            _context = new vdrControlCenterContext();

        SystemSetting systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
        if (systemSettings != null)
        {

            cmbChannelListTyp.SelectedItem = (ChannelType)systemSettings.ChannelListType;
            chbFavouritesOnly.Checked = systemSettings.FavouritesOnly.Value;
            chbSaveBufferToFile.Checked = systemSettings.SaveBufferToFile.Value;
            chbEnableLogging.Checked = systemSettings.EnableLogging.Value;

            lblLastUpdateChannelsValue.Text = $"{systemSettings.LastUpdateChannels:dd.MM.yyyy HH:mm:ss}";
            lblLastUpdateEPGValue.Text = $"{systemSettings.LastUpdateEpg:dd.MM.yyyy HH:mm:ss}";
            lblLastUpdateTimersValue.Text = $"{systemSettings.LastUpdateTimers:dd.MM.yyyy HH:mm:ss}";
            lblLastUpdateRecordingsValue.Text = $"{systemSettings.LastUpdateRecordings:dd.MM.yyyy HH:mm:ss}";
            lblLastupdateStatusValue.Text = $"{systemSettings.LastUpdateStatus:dd.MM.yyyy HH:mm:ss}";
            tePathToChannelLogogs.Text = systemSettings.PathToChannelLogos;
        }

        List<Station> stations = await _context.Stations
                                                    .OrderBy(x => x.HostAddress)
                                                    .ToListAsync();
        cmbStations.BeginUpdate();
        foreach (var station in stations)
        {
            var item = new ComboBoxItem();
            item.Text = station.HostAddress;
            item.Value = station.RecId;
            cmbStations.Items.Add(item);
        }
        cmbStations.EndUpdate();

        if (cmbStations.Items.Count > 0)
            cmbStations.SelectedIndex = 0;
    }

    private void btnPathToChannelLogos_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog dlg = new FolderBrowserDialog();
        dlg.SelectedPath = tePathToChannelLogogs.Text;
        if (dlg.ShowDialog() == DialogResult.OK)
            tePathToChannelLogogs.Text = dlg.SelectedPath;
    }

    private async Task LoadData()
    {
        if (cmbStations.SelectedIndex == -1)
            return;
        
        var item = (ComboBoxItem)cmbStations.SelectedItem;
        var recId = (long)item.Value;
        var station = await _context.Stations.FirstOrDefaultAsync(x => x.RecId == recId);
        if (station != null)
        {
            frmMain.AddMessage($"LOAD SETTINGS » {station.HostAddress}");

            teMacAddress.Text = station.MacAddress;
            chbEnableWOL.Checked = (station.EnableWol.HasValue ? station.EnableWol.Value : false);
            teMachineName.Text = station.MachineName;
            cmbStationType.SelectedItem = (StationType)station.StationType;
            teDescription.Text = station.Description;

            teSshPort.Text = (station.Sshport.HasValue ? Convert.ToString(station.Sshport.Value) : "0");
            teSshUserName.Text = station.SshuserName;
            teSshPassword.Text = station.Sshpassword;

            teSambaUserName.Text = station.SambaUserName;
            teSambaPassword.Text = station.SambaPassword;

            teSvdrpPort.Text = (station.Svdrpport.HasValue ? Convert.ToString(station.Svdrpport.Value) : "0");
            tePathToRecordings.Text = station.PathToRecordings;
            teVdrControlServicePort.Text = (station.VdrControlServicePort.HasValue ? Convert.ToString(station.VdrControlServicePort.Value) : "0");
            teVDRAdminPort.Text = (station.VdradminPort.HasValue ? Convert.ToString(station.VdradminPort.Value) : "0");
            teVDRAdminUserName.Text = station.VdradminUserName;
            teVDRAdminPassword.Text = station.VdradminPassword;
        }
    }

    public async Task SaveData()
    {
        var item = (ComboBoxItem)cmbStations.Items[_prevSelectedIndex];
        var recId = (long)item.Value;

        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                frmMain.AddMessage($"SAVE SETTINGS » {RaX.Extensions.Network.NetHelper.LocalAddress}");
                SystemSetting systemSettings = await _context.SystemSettings.FirstOrDefaultAsync();
                if (systemSettings == null)
                    systemSettings = new SystemSetting();
                else
                    _context.Entry(systemSettings).State = EntityState.Modified;

                ChannelType type = (ChannelType)cmbChannelListTyp.SelectedItem;
                systemSettings.ChannelListType = Convert.ToInt16(type);
                systemSettings.FavouritesOnly = chbFavouritesOnly.Checked;
                systemSettings.SaveBufferToFile = chbSaveBufferToFile.Checked;
                systemSettings.EnableLogging = chbEnableLogging.Checked;
                systemSettings.PathToChannelLogos = tePathToChannelLogogs.Text.Replace("\\", "/");

                var station = await _context.Stations.FirstOrDefaultAsync(x => x.RecId == recId);
                frmMain.AddMessage($"SAVE SETTINGS » {station.HostAddress}");
                if (station == null)
                    station = new Station();
                else
                    _context.Entry(station).State = EntityState.Modified;

                StationType stationType = (StationType)cmbStationType.SelectedItem;
                station.MachineName = teMachineName.Text;
                station.StationType = Convert.ToInt16(stationType);
                station.Description = teDescription.Text;
                station.MacAddress = teMacAddress.Text;
                station.EnableWol = chbEnableWOL.Checked;

                station.Sshport = Convert.ToInt32(teSshPort.Text);
                station.SshuserName = teSshUserName.Text;
                station.Sshpassword = teSshPassword.Text;

                station.SambaUserName = teSambaUserName.Text;
                station.SambaPassword = teSambaPassword.Text;

                station.Svdrpport = Convert.ToInt32(teSvdrpPort.Text);
                station.PathToRecordings = tePathToRecordings.Text.Replace("\\", "/");
                station.VdrControlServicePort = Convert.ToInt32(teVdrControlServicePort.Text);
                station.VdradminPort = Convert.ToInt32(teVDRAdminPort.Text);
                station.VdradminUserName = teVDRAdminUserName.Text;
                station.VdradminPassword = teVDRAdminPassword.Text;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }
    }

    private void btnPathToRecordings_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog dlg = new FolderBrowserDialog();
        dlg.SelectedPath = tePathToRecordings.Text;
        if (dlg.ShowDialog() == DialogResult.OK)
            tePathToRecordings.Text = dlg.SelectedPath;
    }

     
    private void cmbStationType_SelectedValueChanged(object sender, EventArgs e)
    {
        StationType stationType = (StationType)cmbStationType.SelectedValue;
        grbServer.Visible = (stationType == StationType.Server);
    }

    private async void btnNew_Click(object sender, EventArgs e)
    {
        dlgHostAddress dlg = new dlgHostAddress();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            var hostAddress = $"{dlg.HostAddress}";
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Station station = new Station()
                    {
                        HostAddress = hostAddress,
                        MachineName = hostAddress,
                        StationType = Convert.ToInt16(cmbStationType.SelectedValue)
                    };

                    await _context.Stations.AddAsync(station);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    var item = new ComboBoxItem();
                    item.Text = station.HostAddress;
                    item.Value = station.RecId;
                    cmbStations.Items.Add(item);

                    int index = -1;
                    int i = 0;
                    foreach (ComboBoxItem find in cmbStations.Items)
                    {
                        if (find.Text == hostAddress)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    if (i > -1)
                        cmbStations.SelectedIndex = i;
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
        }
    }

    private async void btnDel_Click(object sender, EventArgs e)
    {
        var item = (ComboBoxItem)cmbStations.SelectedItem;
        var recId = (long)item.Value;
        Station station = await _context.Stations.FirstOrDefaultAsync(x => x.RecId == recId);
        if (station != null)
        {
            if (MessageBox.Show($"Möchten Sie die aktuelle Host-Adresse <{station.HostAddress}> und deren Einstellungen wirklich löschen ?",
                                "Host-Adresse löschen",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        _context.Stations.Remove(station);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        cmbStations.Items.Remove(item);
                        if (cmbStations.Items.Count > 0)
                        {
                            _prevSelectedIndex = -1;
                            cmbStations.SelectedIndex = 0;
                        }
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                    }
                }
            }
        }
    }

    private bool IsMAC(string mac)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(mac, @"(([a-f]|[0-9]|[A-F]){2}\:){5}([a-f]|[0-9]|[A-F]){2}\b");
    }

    private void teMacAddress_TextChanged(object sender, EventArgs e)
    {
        picMacExclamation.Visible = (!string.IsNullOrWhiteSpace(teMacAddress.Text) && !IsMAC(teMacAddress.Text));
    }

    private async void cmbStations_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_prevSelectedIndex == -1)
        {
            _prevSelectedIndex = cmbStations.SelectedIndex;
            await LoadData();
        }
    }

    private async void cmbStations_SelectionChangeCommitted(object sender, EventArgs e)
    {
        await SaveData();
        _prevSelectedIndex = cmbStations.SelectedIndex;
        await LoadData();
    }
}

