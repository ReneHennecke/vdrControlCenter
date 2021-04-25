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
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlService.Models;

    public partial class CommanderView : UserControl
    {
        private ServiceController _controller;
        private vdrControlCenterContext _context;
        private int _prevIndex = -1;
        private FileSystemEntry _fileSystemEntry;
        private CommanderPanelView _commanderPanelView;
        private List<CommanderPanelView> _commanderList;

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

        // Wieder entfernen
        public ServiceController Controller
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
        }

        public async void LoadData(CommanderPanelView view, List<CommanderPanelView> list)
        {
            if (_context == null)
                _context = new vdrControlCenterContext();

            List<ShareConnect> shareConnects = new List<ShareConnect>();
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
                    shareConnects.Add(shareConnect);
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
                shareConnects.Add(shareConnect);
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
                shareConnects.Add(shareConnect);
            }


            ComboBoxItem item = null;
            int index = 0;
            int selected = -1;
            foreach (ShareConnect sc in shareConnects)
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
        }

        private void LoadFileSystemEntries()
        {
            if (_fileSystemEntry == null || !Directory.Exists(_fileSystemEntry.FullPath))
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
                //_controller.Execute(kea, _isLocal, (FileSystemEntry)item.Tag);
            }
        }

        private void livFileSystem_KeyDown(object sender, KeyEventArgs e)
        {
            ListViewItem item = livFileSystem.FocusedItem;
            if (item != null)
            {
                if (item.Tag != null && item.Tag is FileSystemEntry)
                {
                    FileSystemEntry fse = (FileSystemEntry)item.Tag;
                  //  _controller.Execute(e, _isLocal, fse);
                }
            }
        }

        private void tmCheckConnect_Tick(object sender, EventArgs e)
        {
            tmCheckConnect.Enabled = false;
            foreach (ComboBoxItem item in cmbFullPath.Items)
            {
                ShareConnect shareConnect = (ShareConnect)item.Value;
                switch (shareConnect.ShareTyp)
                {
                    case Enums.ShareTyp.Local:
                        break;
                    case Enums.ShareTyp.SMB:
                        break;
                    case Enums.ShareTyp.vdrControlService:
                        break;
                    default:
                        break;

                }
            }
            tmCheckConnect.Enabled = true;
        }

        private void cmbFullPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prevIndex != cmbFullPath.SelectedIndex)
            {
                ComboBoxItem item = (ComboBoxItem)cmbFullPath.SelectedItem;
                ShareConnect shareConnect = (ShareConnect)item.Value;
                //if (shareConnect.ShareTyp != Enums.ShareTyp.Local && shareConnect.Connected)
                //{

                //}

                if (Directory.Exists(shareConnect.FullPath))
                {
                    _prevIndex = cmbFullPath.SelectedIndex;
                    _fileSystemEntry = new FileSystemEntry(shareConnect.FullPath);
                    LoadFileSystemEntries();
                }
                else
                {
                    if (_prevIndex > -1)
                        cmbFullPath.SelectedIndex = _prevIndex;
                }
            }
            else
            {
                if (_prevIndex > -1)
                    cmbFullPath.SelectedIndex = _prevIndex;
            }
        }
    }
}
