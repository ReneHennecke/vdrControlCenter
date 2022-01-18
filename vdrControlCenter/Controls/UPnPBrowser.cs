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
        _libVLC = new LibVLC(enableDebugLogs: true, options: "--verbose=2");
        _libVLC.Log += (_, args) =>
        {
            string message = $"libVlc : args.Level args.Message @ args.Module";
            System.Diagnostics.Debug.WriteLine(message);
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

    private async void trvBrowser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        var node = e.Node;
        var mediaItem = (MediaItem)node.Tag;
        if (mediaItem.Media.Type != MediaType.File)
        {
            node.Nodes.Clear();
            grbDetails.Visible = false;

            await mediaItem.Media.Parse(MediaParseOptions.ParseNetwork);
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
            
            lblNameValue.Text = mediaItem.Name;
            lblMrlValue.Text = mediaItem.Media.Mrl;
            lblDurationValue.Text = mediaItem.Media.Duration > -1 ? $"{mediaItem.Media.Duration}" : string.Empty;  

            // $"{mediaItem.Media.Meta(MetadataType.DiscTotal)}";


            grbDetails.Visible = true;

           
        }
    }

    private async void btnDownload_Click(object sender, EventArgs e)
    {
        if (btnDownload.Text == BTN_DL_CANCEL)
        {
            _downloadWithProgress.CancelDownload();
            btnDownload.Text = BTN_DL_DOWN;
            return;
        }
        
        btnDownload.Text = BTN_DL_CANCEL;
        
        if (!string.IsNullOrWhiteSpace(lblMrlValue.Text) && !string.IsNullOrWhiteSpace(lblNameValue.Text))
        {
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}/Downloads";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var source = lblMrlValue.Text;
            var target = $"{path}/{lblNameValue.Text}.mpeg";
            _downloadWithProgress = new HttpClientDownloadWithProgress(source, target);
            _downloadWithProgress.ProgressChanged += OnProgressChanged;
            await _downloadWithProgress.StartDownload();

            btnDownload.Text = BTN_DL_DOWN;
        }
    }

    private void OnProgressChanged(long? totalFileSize, long totalBytesDownloaded, double? progressPercentage)
    {
        if (_downloadWithProgress != null)
        {
            if (totalFileSize.HasValue)
                lblTotalFileSize.Text = totalFileSize.Value.ToString();

            lblTotalBytesDownLoaded.Text = $"{totalBytesDownloaded:n0}";

            if (progressPercentage.HasValue)
                pbProgress.Value = (int)progressPercentage.Value;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var node = trvBrowser.SelectedNode;
        var mediaItem = (MediaItem)node.Tag;
            
        var pl = new MediaPlayer(mediaItem.Media);
        pl.Play();
        Task.Delay(3000);
        pl.Stop();

        var t = pl.Media.Duration;
    }
}
















