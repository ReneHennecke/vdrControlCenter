namespace vdrControlCenterUI.Controls
{
    using DataLayer.Classes;
    using DataLayer.Models;
    using Extensions.Classes;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Dialogs;
    using vdrControlService.Models;

    public partial class CommanderView : UserControl
    {
        private CommanderController _controller;
        private vdrControlCenterContext _context;
        private int _prevIndex = -1;
        List<ShareConnect> _shareConnects;
        private FileSystemEntry _fileSystemEntry;
        private CommanderPanelView _commanderPanelView;
        private List<CommanderPanelView> _commanderList;
        private HttpClient _httpClient;
        private Ping _ping;

        public CommanderPanelView CommanderPanelView
        {
            get => _commanderPanelView;
            set => _commanderPanelView = value;
        }

        public List<CommanderPanelView> CommanderList
        {
            get => _commanderList;
            //{
            //    List<CommanderPanelView> retval = new List<CommanderPanelView>();
            //    foreach (ComboBoxItem item in cmbFullPath.Items)
            //    {
            //        ShareConnect shareConnect = (ShareConnect)item.Value;
            //        CommanderPanelView view = new CommanderPanelView()
            //        {
            //            View = shareConnect.Entry,
            //            FullPath = shareConnect.FullPath
            //        };
            //        retval.Add(view);
            //    }

            //    return retval;
            //}
        }

        public bool Switch { get; set; }



        // Wieder entfernen
        public CommanderController Controller
        {
            get => _controller;
            set => _controller = value;
        }

        public CommanderView()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            livFileSystem.SmallImageList = Globals.LoadImageList(Enums.ImageListType.CommandView);

            _commanderList = new List<CommanderPanelView>();

            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(2);

            _ping = new Ping();
        }

        public async void LoadData(CommanderPanelView view, List<CommanderPanelView> list)
        {
            if (_context == null)
                _context = new vdrControlCenterContext();

            _shareConnects = new List<ShareConnect>();
            ShareConnect shareConnect = null;

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo di in drives)
            {
                if (di.DriveType == DriveType.Fixed || di.DriveType == DriveType.Network)
                {
                    shareConnect = new ShareConnect()
                    {
                        MachineName = Environment.MachineName,
                        HostAddress = NetworkExtension.LocalAddress.ToString(),
                        ShareTyp = Enums.ShareTyp.Local,
                        FullPath = $"{di.Name.Substring(0, 1)}:/"
                    };
                    _shareConnects.Add(shareConnect);
                }
            }

            const int SMB_PORT = 445;
            List<Stations> stations = await _context.Stations.Where(x => x.MachineName != Environment.MachineName && !string.IsNullOrWhiteSpace(x.SambaUserName)).ToListAsync();
            foreach (Stations station in stations)
            {
                shareConnect = new ShareConnect()
                {
                    MachineName = station.MachineName,
                    HostAddress = station.HostAddress,
                    Port = SMB_PORT,
                    ShareTyp = Enums.ShareTyp.SMB,
                    NetworkCredential = new NetworkCredential(station.SambaUserName, station.SambaPassword)
                };
                _shareConnects.Add(shareConnect);
            }

            stations = await _context.Stations.Where(x => x.MachineName != Environment.MachineName && x.VdrControlServicePort > 0).ToListAsync(); 
            foreach (Stations station in stations)
            {
                
                shareConnect = new ShareConnect()
                {
                    MachineName = station.MachineName,
                    HostAddress = station.HostAddress,
                    Port = station.VdrControlServicePort.Value,
                    ShareTyp = Enums.ShareTyp.vdrControlService
                };
                _shareConnects.Add(shareConnect);
            }


            ComboBoxItem item = null;
            int index = 0;
            int selected = -1;
            foreach (ShareConnect sc in _shareConnects)
            {
                item = new ComboBoxItem();
                item.Text = sc.DisplayName;
                item.Value = sc;
                cmbFullPath.Items.Add(item);
                if (view != null && sc.Entry == view.View)
                    selected = index;
                index++;
            }

            cmbFullPath.SelectedIndex = selected == -1 ? 0 : selected;
            cmbFullPath_SelectionChangeCommitted(null, null);

            tmCheckConnect.Interval = 10000;
            tmCheckConnect.Enabled = true;
            tmCheckConnect_Tick(null, null);
        }

        private void LoadFileSystemEntries()
        {
            if (_fileSystemEntry == null)
                return;

            livFileSystem.SuspendLayout();
            livFileSystem.Items.Clear();

            if (!string.IsNullOrWhiteSpace(_fileSystemEntry.ParentPath))
            {
                FileSystemEntry f = new FileSystemEntry()
                {
                    FullPath = _fileSystemEntry.ParentPath,
                    Name = "..",
                    Attributes = FileAttributes.Directory
                };

                ListViewItem item = new ListViewItem();
                item.Text = f.Name;
                item.SubItems.Add(string.Empty);
                item.SubItems.Add("<DIR>");
                item.SubItems.Add("D");
                item.Tag = f;
                item.ImageIndex = 0;
                livFileSystem.Items.Add(item);
            }

            if (_fileSystemEntry.Directories != null && _fileSystemEntry.Directories.Count > 0)
            {
                foreach (var fse in _fileSystemEntry.Directories)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = fse.Name;
                    item.SubItems.Add(string.Empty);
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add($"{fse.AttributeString}");
                    item.Tag = fse;
                    item.ImageIndex = 0;
                    livFileSystem.Items.Add(item);
                }
            }

            if (_fileSystemEntry.Files != null && _fileSystemEntry.Files.Count > 0)
            {
                foreach (var fse in _fileSystemEntry.Files)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = fse.Name;
                    item.SubItems.Add($"{fse.Extension}");
                    item.SubItems.Add($"{fse.Size}");
                    item.SubItems.Add($"{fse.AttributeString}");
                    item.Tag = fse;
                    item.ImageIndex = 1;
                    livFileSystem.Items.Add(item);
                }
            }

            livFileSystem.ResumeLayout();

            // Zum Speichern der Auswahl
            ComboBoxItem currentItem = (ComboBoxItem)cmbFullPath.SelectedItem;
            ShareConnect shareConnect = (ShareConnect)currentItem.Value;
            shareConnect.FullPath = _fileSystemEntry.FullPath;
            RefreshItem(cmbFullPath.SelectedIndex, shareConnect);

            _commanderPanelView = new CommanderPanelView()
            {
                View = shareConnect.Entry,
                FullPath = _fileSystemEntry.FullPath
            };

            _commanderList.Add(_commanderPanelView);
        }


        private void livFileSystem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = livFileSystem.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null && item.Tag != null && item.Tag is FileSystemEntry)
            { 
                KeyEventArgs kea = new KeyEventArgs(Keys.Enter);
                Execute(kea, item);
            }
        }

        private void livFileSystem_KeyDown(object sender, KeyEventArgs e)
        {
            ListViewItem item = livFileSystem.FocusedItem;
            if (item != null)
            {
                if (item.Tag != null && item.Tag is FileSystemEntry)
                  Execute(e, item);
            }
        }

        private async void tmCheckConnect_Tick(object sender, EventArgs e)
        {
            tmCheckConnect.Enabled = false;

            int index = 0;
            foreach (ShareConnect shareConnect in _shareConnects)
            {
                switch (shareConnect.ShareTyp)
                {
                    case Enums.ShareTyp.Local:
                        break;
                    case Enums.ShareTyp.SMB:
                        if (shareConnect.NetworkCredential != null)
                        {
                            if (shareConnect.State == Enums.ShareConnectState.DisConnected || shareConnect.Tag == null)
                            {
                                shareConnect.State = Enums.ShareConnectState.DisConnected;
                                RefreshItem(index, shareConnect);

                                var reply = await _ping.SendPingAsync(shareConnect.HostAddress, 100);
                                if (reply.Status == IPStatus.Success)
                                {
                                    string address = $"\\\\{shareConnect.HostAddress}\\data";
                                    ConnectToSharedFolder cs = null;
                                    try
                                    {
                                        cs = new ConnectToSharedFolder(address, shareConnect.NetworkCredential);
                                    }
                                    catch
                                    {
                                        if (shareConnect.Tag != null)
                                            ((ConnectToSharedFolder)shareConnect.Tag).Dispose();
                                    }

                                    shareConnect.Tag = cs;
                                    if (cs != null)
                                    {
                                        shareConnect.State = Enums.ShareConnectState.Connected;
                                        shareConnect.FullPath = address;
                                        RefreshItem(index, shareConnect);
                                    }
                                }
                            }
                        }
                        break;
                    case Enums.ShareTyp.vdrControlService:
                        {
                            string url = shareConnect.Url;
                            if (string.IsNullOrWhiteSpace(url) || shareConnect.State == Enums.ShareConnectState.Idle || shareConnect.State == Enums.ShareConnectState.InRequest)
                                return;

                            shareConnect.State = Enums.ShareConnectState.IsAlive;
                            RefreshItem(index, shareConnect);

                            url += $"Extensions/IsAlive";
                            bool isAlive = false;

                            try
                            {
                                using (HttpResponseMessage response = await _httpClient.GetAsync(url))
                                using (HttpContent content = response.Content)
                                {
                                    string result = await content.ReadAsStringAsync();
                                    if (result != null)
                                        bool.TryParse(result, out isAlive);
                                }
                            }
                            catch //(Exception ex)
                            {

                            }

                            shareConnect.State = Enums.ShareConnectState.Idle;
                            RefreshItem(index, shareConnect);
                        }
                        break;
                    default:
                        break;

                }

                index++;
            }
            
            tmCheckConnect.Enabled = true;
        }

        private async Task<string> PostData(string action, object json)
        {
            string retval = string.Empty;
            using (var content = new StringContent(JsonConvert.SerializeObject(json, Formatting.Indented), System.Text.Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage result = await _httpClient.PostAsync(action, content);
                if (!result.IsSuccessStatusCode)
                {
                    // Fehlermeldung
                    return retval;
                }

                retval = result.Content.ReadAsStringAsync().Result;
            }

            return retval;
        }

        private void cmbFullPath_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbFullPath.SelectedIndex == _prevIndex)
                return;

            ComboBoxItem item = (ComboBoxItem)cmbFullPath.SelectedItem;
            ShareConnect shareConnect = (ShareConnect)item.Value;
            bool resetSelection = ChangeDirectory(shareConnect, _fileSystemEntry).Result;

            if (resetSelection)
                cmbFullPath.SelectedIndex = _prevIndex;
            else
                _prevIndex = cmbFullPath.SelectedIndex;
        }

        private void Execute(KeyEventArgs ea, ListViewItem lvitem)
        {
            ComboBoxItem item = (ComboBoxItem)cmbFullPath.SelectedItem;
            ShareConnect shareConnect = (ShareConnect)item.Value;
            FileSystemEntry fse = (FileSystemEntry)lvitem.Tag;

            switch (ea.KeyCode)
            {
                default:
                    break;
                case Keys.Enter:
                    {
                        string path = shareConnect.FullPath;
                        if (fse.Attributes.HasFlag(FileAttributes.Directory))
                        {
                            if (shareConnect.ShareTyp != Enums.ShareTyp.vdrControlService)
                            {
                                if (Directory.Exists(fse.FullPath))
                                    Directory.SetCurrentDirectory(fse.FullPath);

                                path = fse.FullPath;

                                _fileSystemEntry = new FileSystemEntry(path);
                                LoadFileSystemEntries();
                            }
                            else
                            {

                            }
                        }
                    }
                    break;

                case Keys.F3:
                    if (fse.Attributes.HasFlag(FileAttributes.Directory))
                        return;
                        
                    OpenFile(shareConnect, fse, false);

                    break;
                
                case Keys.F4:
                    if (fse.Attributes.HasFlag(FileAttributes.Directory))
                        return;

                    OpenFile(shareConnect, fse, true);

                    break;
            }
        }

        private void RefreshItem(int index, ShareConnect shareConnect)
        {
            ComboBoxItem item = (ComboBoxItem)cmbFullPath.Items[index];

            item.Text = shareConnect.DisplayName;
            item.Value = shareConnect;
            cmbFullPath.Items[index] = item;
        }

        private async Task<bool> ChangeDirectory(ShareConnect shareConnect, FileSystemEntry fse)
        {
            bool retval = false;

            string path = shareConnect.FullPath;

            if (shareConnect.ShareTyp != Enums.ShareTyp.vdrControlService)
            {
                // Lokale oder SMB-Verzeichnisse
                if (Directory.Exists(shareConnect.FullPath))
                {
                    _prevIndex = cmbFullPath.SelectedIndex;
                    _fileSystemEntry = new FileSystemEntry(path);
                    LoadFileSystemEntries();
                }
                else
                    retval = true;
            }
            else
            {
                string url = shareConnect.Url;
                if (string.IsNullOrWhiteSpace(url) || shareConnect.State != Enums.ShareConnectState.Idle)
                    return true;

                shareConnect.State = Enums.ShareConnectState.InRequest;
                RefreshItem(cmbFullPath.SelectedIndex, shareConnect);

                try
                {
                    FileSystemEntryRequest request = new FileSystemEntryRequest();
                    request.FullPath = string.IsNullOrWhiteSpace(path) ? "/" : path; // Kein Pfad vorhanden, dann root-Verzeichnis
                    string action = $"{url}FileSystem/GetDirectory";

                    string json = await PostData(action, request);

                    var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                    if (response != null)
                    {
                        _fileSystemEntry = response.FileSystemEntry;
                        LoadFileSystemEntries();
                    }
                    else
                        retval = false;
                }
                catch //(Exception ex)
                {
                    retval = true;
                }

                shareConnect.State = Enums.ShareConnectState.Idle;
                RefreshItem(cmbFullPath.SelectedIndex, shareConnect);
            }

            return retval;
        }

        private async void OpenFile(ShareConnect shareConnect, FileSystemEntry fse, bool toWrite = false)
        {
            if (shareConnect.ShareTyp != Enums.ShareTyp.vdrControlService)
            {
                switch (fse.Extension.ToLower())
                {
                    case ".txt":
                    case ".conf":
                    case ".config":
                    case ".cs":
                        string content = await File.ReadAllTextAsync(fse.FullPath);
                        dlgEditor dlg = new dlgEditor();
                        dlg.PostInit(this, fse, content, toWrite);
                        if (dlg.ShowDialog() == DialogResult.OK)
                        { 
                            //await File.WriteAllTextAsync(dlg.cont fse.FullPath);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //                switch (fse.Extension.ToLower())
                //                {
                //                    case ".txt":
                //                    case ".conf":
                //                    case ".config":
                //                        FileSystemEntryRequest request = new FileSystemEntryRequest();
                //                        request.FullPath = fse.FullPath;
                //                        string action = $"{_url}FileSystem/ReadFileContent";

                //                        string json = await PostData(action, request);

                //                        var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                //                        if (response != null)
                //                        {
                //                            byte[] bytes = Convert.FromBase64String(response.FileContent.Content);
                //                            string content = Encoding.UTF8.GetString(bytes);

                //                            dlgEditor dlg = new dlgEditor();
                //                            dlg.PostInit(this, local, fse, content, true);
                //                            dlg.Show();
                //                        }
                //                        break;
                //                    default:

                //                        break;
                //                }
            }

        }
    }
}
