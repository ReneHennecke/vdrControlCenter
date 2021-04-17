namespace vdrControlCenterUI.Controls
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using DataLayer.Enums;
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Linq;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Dialogs;

    public partial class SystemSettingsController : UserControl
    {
        private vdrControlCenterContext _context;
        private bool _inTransaction;
        private frmMain frmMain;
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
            Disposed += SystemSettingsView_Disposed;

            btnNew.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SystemSettingsNewPng}");
            btnDel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SystemSettingsDelPng}");

            btnPathToChannelLogos.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SystemSettingsFindPng}");
            btnPathToRecordings.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.SystemSettingsFindPng}");

            picMacExclamation.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.ExclamationPng}");

            cmbChannelListTyp.DataSource = Enum.GetValues(typeof(ChannelType));
            cmbStationType.DataSource = Enum.GetValues(typeof(StationType));

            if (_context == null)
                _context = new vdrControlCenterContext();

            SystemSettings systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
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

            cmbStations.DataSource = await _context.Stations.OrderBy(x => x.HostAddress)
                                                            .ToListAsync();
            cmbStations.DisplayMember = "HostAddress";
        }

        private void SystemSettingsView_Disposed(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnPathToChannelLogos_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = tePathToChannelLogogs.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
                tePathToChannelLogogs.Text = dlg.SelectedPath;
        }

        private void LoadData()
        {
            if (cmbStations.SelectedIndex == -1)
                return;

            Stations stations = (Stations)cmbStations.CurrentValue;

            frmMain.AddMessage($"LOAD SETTINGS » {stations.HostAddress}");

            teMacAddress.Text = stations.MacAddress;
            chbEnableWOL.Checked = (stations.EnableWol.HasValue ? stations.EnableWol.Value : false);
            teMachineName.Text = stations.MachineName;
            cmbStationType.SelectedItem = (StationType)stations.StationType;
            teDescription.Text = stations.Description;

            teSshPort.Text = (stations.Sshport.HasValue ? Convert.ToString(stations.Sshport.Value) : "0");
            teSshUserName.Text = stations.SshuserName;
            teSshPassword.Text = stations.Sshpassword;

            teSambaUserName.Text = stations.SambaUserName;
            teSambaPassword.Text = stations.SambaPassword;

            teSvdrpPort.Text = (stations.Svdrpport.HasValue ? Convert.ToString(stations.Svdrpport.Value) : "0");
            tePathToRecordings.Text = stations.PathToRecordings;
            teVdrControlServicePort.Text = (stations.VdrControlServicePort.HasValue ? Convert.ToString(stations.VdrControlServicePort.Value) : "0");
            teVDRAdminPort.Text = (stations.VdradminPort.HasValue ? Convert.ToString(stations.VdradminPort.Value) : "0");
            teVDRAdminUserName.Text = stations.VdradminUserName;
            teVDRAdminPassword.Text = stations.VdradminPassword;

        }

        public void SaveData()
        {
            if (_inTransaction)
                return;

            Stations selected = (Stations)cmbStations.PreviousValue;
            if (selected == null)
                return;

            frmMain.AddMessage($"SAVE SETTINGS » {selected.HostAddress}");

            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _inTransaction = true;

                    SystemSettings systemSettings = _context.SystemSettings.FirstOrDefault();
                    if (systemSettings == null)
                        systemSettings = new SystemSettings();
                    else
                        _context.Entry(systemSettings).State = EntityState.Modified;

                    ChannelType type = (ChannelType)cmbChannelListTyp.SelectedItem;
                    systemSettings.ChannelListType = Convert.ToInt16(type);
                    systemSettings.FavouritesOnly = chbFavouritesOnly.Checked;
                    systemSettings.SaveBufferToFile = chbSaveBufferToFile.Checked;
                    systemSettings.EnableLogging = chbEnableLogging.Checked;
                    systemSettings.PathToChannelLogos = tePathToChannelLogogs.Text.Replace("\\", "/");

                    Stations stations = _context.Stations.FirstOrDefault(x => x.RecId == selected.RecId);
                    if (stations == null)
                        stations = new Stations();
                    else
                        _context.Entry(stations).State = EntityState.Modified;

                    StationType stationType = (StationType)cmbStationType.SelectedItem;
                    stations.MachineName = teMachineName.Text;
                    stations.StationType = Convert.ToInt16(stationType);
                    stations.Description = stations.Description;
                    stations.MacAddress = teMacAddress.Text;
                    stations.EnableWol = chbEnableWOL.Checked;

                    stations.Sshport = Convert.ToInt32(teSshPort.Text);
                    stations.SshuserName = teSshUserName.Text;
                    stations.Sshpassword = teSshPassword.Text;

                    stations.SambaUserName = teSambaUserName.Text;
                    stations.SambaPassword = teSambaPassword.Text;

                    stations.Svdrpport = Convert.ToInt32(teSvdrpPort.Text);
                    stations.PathToRecordings = tePathToRecordings.Text.Replace("\\", "/");
                    stations.VdrControlServicePort = Convert.ToInt32(teVdrControlServicePort.Text);
                    stations.VdradminPort = Convert.ToInt32(teVDRAdminPort.Text);
                    stations.VdradminUserName = teVDRAdminUserName.Text;
                    stations.VdradminPassword = teVDRAdminPassword.Text;

                    _context.SaveChanges();
                    transaction.CommitAsync();
                }
                catch
                {
                    transaction.Rollback();
                }
                _inTransaction = false;
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            dlgHostAddress dlg = new dlgHostAddress();
            dlg.Show();
            if (dlg.DialogResult == DialogResult.OK)
            {
                cmbStationType.SelectedIndex = 0;
                Stations stations = new Stations()
                {
                    HostAddress = $"{dlg.HostAddress}",
                    StationType = Convert.ToInt16(cmbStationType.SelectedValue)
                };
                cmbStations.Items.Add(stations);
                cmbStations.Sorted = true;
                cmbStations.SelectedValue = stations;
            }
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            Stations stations = (Stations)cmbStations.SelectedValue;
            if (MessageBox.Show("Host-Adresse löschen",
                                $"Möchten Sie die aktuelle Host-Adresse <{stations.HostAddress}> wirklich löschen ?",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
                {
                    _context.Stations.Remove(stations);
                    await _context.SaveChangesAsync();

                    cmbStations.Items.Remove(stations);
                    if (cmbStations.Items.Count > 0)
                        cmbStations.SelectedIndex = 0;
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

        private void cmbStations_SelectedValueChanged(object sender, EventArgs e)
        {
            SaveData();

            LoadData();
        }
    }
}
