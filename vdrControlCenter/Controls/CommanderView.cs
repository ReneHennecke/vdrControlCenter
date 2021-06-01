namespace vdrControlCenterUI.Controls
{
    using DataLayer.Classes;
    using DataLayer.Models;
    using Extensions.Classes;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.NetworkInformation;
    using System.Text;
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
        private string _name;

        public CommanderPanelView CommanderPanelView
        {
            get => _commanderPanelView;
            set => _commanderPanelView = value;
        }

        public List<CommanderPanelView> CommanderList
        {
            get => _commanderList;
        }

        public FileSystemEntry CurrentFileSystemEntry
        {
            get => _fileSystemEntry;
        }

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

        public async void LoadData(CommanderPanelView view, string name)
        {
            _name = name;
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
                        else
                        {
                            ea = new KeyEventArgs(Keys.F3);
                            Execute(ea, lvitem); // Wenn Datei, versuchen die Datei im Anzeigemodus zu öffnen
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

                case Keys.F5:
                    DoCopyOrMove(shareConnect, fse, false, false);
                    break;

                case Keys.F6:
                    DoCopyOrMove(shareConnect, fse, true, false);
                    break;

                case Keys.F8:
                case Keys.Delete:
                    string title = "%1 löschen";
                    string text = $"Möchten Sie %1 «{fse.FullPath}» wirklich löschen ?";
                    if (fse.Attributes.HasFlag(FileAttributes.Directory))
                    {
                        title = title.Replace("%1", "Verzeichnis");
                        text = text.Replace("%1", "das Verzeichnis");
                    }
                    else
                    {
                        title = title.Replace("%1", "Datei");
                        text = text.Replace("%1", "die Datei");
                    }
                    if (MessageBox.Show(text, 
                                        title,
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    DoDelete(shareConnect, fse);

                    break;

                case Keys.F10:
                    RefreshView();
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
                    request.Source.FullPath = string.IsNullOrWhiteSpace(path) ? "/" : path; // Kein Pfad vorhanden, dann root-Verzeichnis
                    string action = $"{url}FileSystem/GetDirectory";

                    string json = await PostData(action, request);

                    var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                    if (response != null)
                    {
                        _fileSystemEntry = response.Source;
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
            switch (fse.Extension.ToLower())
            {
                case ".txt":
                case ".conf":
                case ".config":
                case ".cs":
                    string url = shareConnect.Url;
                    FileSystemEntryRequest request = null;
                    if (shareConnect.ShareTyp == Enums.ShareTyp.vdrControlService)
                    {
                        request = new FileSystemEntryRequest();
                        request.Source.FullPath = fse.FullPath;

                        if (string.IsNullOrWhiteSpace(url) || shareConnect.State != Enums.ShareConnectState.Idle)
                            return;
                    }

                    string content = string.Empty;
                    if (shareConnect.ShareTyp != Enums.ShareTyp.vdrControlService)
                        content = await File.ReadAllTextAsync(fse.FullPath);
                    else if (request != null)
                    {
                        string action = $"{url}FileSystem/ReadFileContent";
                        string json = await PostData(action, request);

                        var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                        if (response == null)
                            ShowApiError();
                        else if (!response.ErrorResult.Success)
                            ShowApiError(response.ErrorResult);
                        else
                        {
                            byte[] bytes = Convert.FromBase64String(response.Content);
                            content = Encoding.UTF8.GetString(bytes);
                        }
                    }
                    dlgEditor dlg = new dlgEditor();
                    dlg.PostInit(this, fse, content, toWrite);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (shareConnect.ShareTyp != Enums.ShareTyp.vdrControlService)
                            await File.WriteAllTextAsync(fse.FullPath, dlg.Content);
                        else if (request != null)
                        {
                            byte[] bytes = Encoding.UTF8.GetBytes(dlg.Content);
                            request.Content = Convert.ToBase64String(bytes);
                            string action = $"{url}FileSystem/WriteFileContent";
                            string json = await PostData(action, request);

                            var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                            if (response == null)
                                ShowApiError();
                            else if (!response.ErrorResult.Success)
                                ShowApiError(response.ErrorResult);
                        }
                    }
                    break;

                case ".pdf":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".tif":
                case ".mp3":
                case ".mp4":
                    if (shareConnect.ShareTyp == Enums.ShareTyp.vdrControlService)
                        return;

                    string fullPath = fse.FullPath;
                    if (string.IsNullOrWhiteSpace(fullPath))
                        return;

                    ProcessStartInfo info = new ProcessStartInfo(fullPath)
                    {
                        UseShellExecute = true
                    };
                    Process.Start(info);
                    break;

                default:
                    break;
            }
        }

        private void DoCopyOrMove(ShareConnect shareConnect, FileSystemEntry fse, bool move, bool overwrite)
        {
            FileSystemEntry target = _controller.GetTargetFileSystemEntry(_name);
            if (_fileSystemEntry.FullPath == target.FullPath)
                return;

            if (shareConnect.ShareTyp != Enums.ShareTyp.vdrControlService)
            {
                if (!move)
                    File.Copy(_fileSystemEntry.FullPath, target.FullPath, overwrite);
                else
                    File.Move(_fileSystemEntry.FullPath, target.FullPath, overwrite);
            }
            else
            {

            }

            _controller.RefreshTarget(_name);
        }

        private async void DoDelete(ShareConnect shareConnect, FileSystemEntry fse)
        {
            if (shareConnect.ShareTyp != Enums.ShareTyp.vdrControlService)
                File.Delete(fse.FullPath);
            else
            {
                string url = shareConnect.Url;
                if (string.IsNullOrWhiteSpace(url) || shareConnect.State != Enums.ShareConnectState.Idle)
                    return;

                FileSystemEntryRequest request = new FileSystemEntryRequest()
                {
                    Source = new FileSystemEntry(fse.FullPath)
                };

                string action = $"{url}FileSystem/DeleteFileSystemEntry";
                string json = await PostData(action, request);

                var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                if (response == null)
                    ShowApiError();
                else if (!response.ErrorResult.Success)
                    ShowApiError(response.ErrorResult);

            }

            RefreshView();
        }


        public void RefreshView()
        {
            FileSystemEntry fse = _fileSystemEntry;
            if (!fse.Attributes.HasFlag(FileAttributes.Directory))
            {
                string separator = fse.ReplaceDosPathSeparator ? "/" : "\\";
                fse = new FileSystemEntry(fse.FullPath.Substring(0, fse.FullPath.LastIndexOf(separator)));
            }

            _fileSystemEntry = new FileSystemEntry(fse.FullPath);
            LoadFileSystemEntries();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            KeyEventArgs ea = new KeyEventArgs(Keys.F5);
            livFileSystem_KeyDown(null, ea);
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            KeyEventArgs ea = new KeyEventArgs(Keys.F6);
            livFileSystem_KeyDown(null, ea);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            KeyEventArgs ea = new KeyEventArgs(Keys.F8);
            livFileSystem_KeyDown(null, ea);
        }

        private void ShowApiError(ErrorResult result = null)
        {
            string title = "API-Fehler" + result == null ? string.Empty : $" «{result.ErrorCode}»";
            string text = result == null ? "Die Abfrage konnte nicht erfolgreich ausgeführt werden." : 
                                          $"Bei der Abfrage trat der Fehler «{result.ErrorMessage}»{Environment.NewLine}{result.ErrorException.Message}";
            MessageBox.Show(text,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

        }
    }
}
