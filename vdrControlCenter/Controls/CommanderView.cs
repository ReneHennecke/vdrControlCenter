namespace vdrControlCenterUI.Controls
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlService.Models;

    public partial class CommanderView : UserControl
    {
        private ServiceController _controller;
        private FileSystemEntry _fileSystemEntry;

        public FileSystemEntry FileSystemEntry
        {
            get => _fileSystemEntry;
            set
            {
                _fileSystemEntry = value;
                LoadFileSystemEntries();
            }
        }

        private bool _isLocal;
        public bool IsLocal
        {
            get => _isLocal;
            set => _isLocal = value;
        }


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
        }

        private void LoadFileSystemEntries()
        {
            if (_fileSystemEntry == null)
                return;

            teFullPath.Text = _fileSystemEntry.FullPath;
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
        }


        private void livFileSystem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = livFileSystem.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
                _controller.Execute(_isLocal, (FileSystemEntry)item.Tag);
        }
    }
}
