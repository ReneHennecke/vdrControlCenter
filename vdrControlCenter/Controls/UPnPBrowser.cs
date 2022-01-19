using LibVLCSharp.Shared;

namespace vdrControlCenterUI.Controls;

public partial class UPnPBrowser : UserControl
{

    private LibVLC _libVLC;
    private delegate void MediaItemAddCallback(MediaItem mediaItem);
    private frmMain _mainForm;
    private HttpClientDownloadWithProgress _downloadWithProgress;
    private const string BTN_DL_DOWN = "Start Download";
    private const string BTN_DL_CANCEL = "Abbrechen";
    private vdrControlCenterContext _context;

    public frmMain MainForm
    {
        set => _mainForm = value;
    }

    public UPnPBrowser()
    {
        PreInit();

        InitializeComponent();

        PostInit();
    }

    private void PreInit()
    {
        //SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        if (!DesignMode)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = Path.GetDirectoryName(currentAssembly.Location);
            var libPath = Path.Combine(currentDirectory, "libvlc", AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86 ? "win-x86" : "win-x64");
            Core.Initialize(libPath);
        }
    }

    private void PostInit()
    {
        if (_context == null)
            _context = new vdrControlCenterContext();

        _libVLC = new LibVLC(enableDebugLogs: true, options: "--verbose=2");
        _libVLC.Log += (_, args) =>
        {
            string message = $"libVlc : args.Level args.Message @ args.Module";
            Debug.WriteLine(message);
        };

        trvBrowser.ImageList = Globals.LoadImageList(ImageListType.UPnPBrowser);

        foreach (var md in _libVLC.MediaDiscoverers(MediaDiscovererCategory.Lan))
        {
            var discoverer = new MediaDiscoverer(_libVLC, md.Name);
            discoverer.MediaList.ItemAdded += ServiceMediaItemAdded;
            discoverer.MediaList.ItemDeleted += ServiceMediaItemDeleted;
            discoverer.Start();
        }
    }

    private void ServiceMediaItemAdded(object sender, MediaListItemAddedEventArgs e)
    {
        var mediaItem = new MediaItem(e.Media)
        {
            MediaSourceTyp = MediaSourceTyp.Service
        };
        MediaItemAdd(mediaItem);
    }

    private void ServiceMediaItemDeleted(object sender, MediaListItemDeletedEventArgs e)
    {
        var treeNode = trvBrowser.SelectedNode;
        if (treeNode != null)
        {
            var mediaItem = (MediaItem)treeNode.Tag;
        }
    }

    private void MediaItemAdd(MediaItem mediaItem)
    {
        if (trvBrowser.InvokeRequired)
        {
            var smcb = new MediaItemAddCallback(MediaItemAdd);
            Invoke(smcb, new object[] { mediaItem });
        }
        else
        {
            var treeNode = new TreeNode();
            treeNode.Text = mediaItem.Media.Meta(MetadataType.Title);
            treeNode.Tag = mediaItem;
            treeNode.ImageIndex = mediaItem.MediaSourceTyp switch 
            {
                MediaSourceTyp.Service => 0,
                _ => -1
            };
            trvBrowser.Nodes.Add(treeNode);
        }
    }

    private async void btnDownload_Click(object sender, EventArgs e)
    {
        var systemSetting = await _context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
        if (systemSetting == null)
            return;

        if (btnDownload.Text == BTN_DL_CANCEL)
        {
            _downloadWithProgress.CancelDownload();
            btnDownload.Text = BTN_DL_DOWN;
            return;
        }
        
        btnDownload.Text = BTN_DL_CANCEL;
        
        if (!string.IsNullOrWhiteSpace(lblMrlValue.Text) && !string.IsNullOrWhiteSpace(lblNameValue.Text))
        {
            var path = $"{systemSetting.UPnPDownloadPath}";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //var mediaItem = (MediaItem)trvBrowser.SelectedNode.Tag;
            

            var source = lblMrlValue.Text;
            var target = $"{path}/{lblNameValue.Text}.mpeg";
            if (!systemSetting.OverwriteUPnPDownload.HasValue || !systemSetting.OverwriteUPnPDownload.Value)
            {
                if (File.Exists(target))
                {
                    var sinceMidnight = DateTime.Now - DateTime.Today;
                    target = target.Replace(".", $".{(int)sinceMidnight.TotalSeconds}.");
                }
            }

            _downloadWithProgress = new HttpClientDownloadWithProgress(source, target);
            _downloadWithProgress.ProgressChanged += OnProgressChanged;
            await _downloadWithProgress.StartDownload();

            btnDownload.Text = BTN_DL_DOWN;
        }
    }

    private void OnProgressChanged(long? totalFileSize, long totalBytesDownloaded, double? progressPercentage, double mbps)
    {
        if (_downloadWithProgress != null)
        {
            if (totalFileSize.HasValue)
                lblMbps.Text = totalFileSize.Value.ToString();

            lblTotalBytesDownLoaded.Text = $"{totalBytesDownloaded:n0}";

            if (progressPercentage.HasValue)
                pbProgress.Value = (int)progressPercentage.Value;

            lblMbps.Text = $"{mbps: 0.00} MB/s";
        }
    }

    private async void trvBrowser_AfterSelect(object sender, TreeViewEventArgs e)
    {
        var node = e.Node;
        node.SelectedImageIndex = node.ImageIndex;
        var mediaItem = (MediaItem)node.Tag;
        if (mediaItem.Media.Type != MediaType.File)
        {
            node.Nodes.Clear();
            grbDetails.Visible = false;

            await mediaItem.Media.Parse(MediaParseOptions.ParseNetwork, 2000, CancellationToken.None);
            foreach (var mi in mediaItem.Media.SubItems)
            {
                var item = new MediaItem(mi)
                {
                    MediaSourceTyp = mi.Type != MediaType.File ? MediaSourceTyp.Directory : MediaSourceTyp.File
                };

                var treeNode = new TreeNode();
                treeNode.Text = item.IsDirectory ? item.Media.Meta(MetadataType.Title) : item.Name;
                treeNode.Tag = item;
                treeNode.ImageIndex = item.IsDirectory ? 1 : 2;
                node.Nodes.Add(treeNode);
            }
            node.Expand();
        }
        else
        {
            var media = mediaItem.Media;

            if (!media.IsParsed)
                await media.Parse(MediaParseOptions.ParseNetwork, 2000, CancellationToken.None);

            lblNameValue.Text = mediaItem.Name;
            lblMrlValue.Text = mediaItem.Media.Mrl;

            lblDurationValue.Text = media.Duration == -1 ? string.Empty : $"{TimeSpan.FromMilliseconds(media.Duration)}";

            grbDetails.Visible = true;
        }
    }
}
















