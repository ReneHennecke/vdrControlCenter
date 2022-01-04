namespace vdrControlCenterUI.Controls;

using LibVLCSharp.Shared;

public partial class MediaController : UserControl
{
    private LibVLC _libVLC;
    private MediaPlayer _mp;

    private bool _isFullScreen = false;
    private Point _oldVideoLocation;
    private Size _oldVideoSize;

    private delegate void SafeCallDelegateDisplayMediaInfo();

    private delegate void SafeCallDelegateDisplayActionText(string text);

    private delegate void SafeCallDelegateDisplayStartTime(DateTime dt);
    private delegate void SafeCallDelegateDisplayTimeText(long time);
    private delegate void SafeCallDelegateDisplayEndTime(DateTime dt);
    private delegate void SafeCallDelegateDisplayLength(long length);

    private delegate void SafeCallDelegateDisplayTrackPosition(double position);

    private DateTime _startTime;
    private DateTime _endTime;

    private float _step = .01f;

    private frmMain _mainForm;
    public frmMain MainForm
    {
        set { _mainForm = value; }
    }

    public MediaController()
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
        ToolTip tt = new ToolTip();

        // Set up the delays for the ToolTip.
        tt.AutoPopDelay = 5000;
        tt.InitialDelay = 1000;
        tt.ReshowDelay = 500;
            
        //toolTip1.ShowAlways = true;

        // Set up the ToolTip text for the Button and Checkbox.
        tt.SetToolTip(btnClose, "Controller schliessen");
        tt.SetToolTip(btnOpenMedia, "Medium-Datei öffnen");
        tt.SetToolTip(btnOpenMediaFromLocation, "Netzwerkstream öffnen");
        tt.SetToolTip(btnBackwardChapter, "Kapitel zurück");
        tt.SetToolTip(btnBackward, "Rückwärts");
        tt.SetToolTip(btnPlayStop, "Abspielen");
        tt.SetToolTip(btnForward, "Vorwärts");
        tt.SetToolTip(btnForwardChapter, "Kapitel vorwärts");
        tt.SetToolTip(btnMute, "Stummschaltung");

        _libVLC = new LibVLC(enableDebugLogs: true, options: "--verbose=2");
        _libVLC.Log += (_, args) =>
        {
            string message = $"libVlc : args.Level args.Message @ args.Module";
            System.Diagnostics.Debug.WriteLine(message);
        };

        _mp = new MediaPlayer(_libVLC);

        _mp.AudioDevice += MediaPlayer_AudioChanged;
        _mp.Backward += OnBackward;
        //_mp.Buffering += Mediaplayer_Buffering;
        //_mp.ChapterChanged += Mediaplayer_ChapterChanged;
        //_mp.Corked += Mediaplayer_Corked;
        //_mp.EncounteredError += Mediaplayer_EncounteredError;
        _mp.EndReached += OnEndReached;

        _mp.Forward += OnForward;
        _mp.Opening += OnOpening;
             
        _mp.Muted += OnMuted;
        _mp.Playing += OnPlaying;

        _mp.LengthChanged += OnLengthChanged;
        _mp.PositionChanged += OnPositionChanged;

        _mp.TimeChanged += OnTimeChanged;
        _mp.Unmuted += OnUnMuted;

        // Sonst kommen keine Events im Control an
        _mp.EnableKeyInput = false;
        _mp.EnableMouseInput = false;
            
        videoViewer.MediaPlayer = _mp;
            
        Focus();
    }

    #region Mediaplyer Events
    private void OnUnMuted(object sender, EventArgs e)
    {
        btnMute.ForeColor = Color.Black;
    }

    private void OnMuted(object sender, EventArgs e)
    {
        btnMute.ForeColor = Color.Red;
    }

    private void OnPositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
    {
        DisplayTrackPosition(e.Position);
    }

    private void OnLengthChanged(object sender, MediaPlayerLengthChangedEventArgs e)
    {
        DisplayLengthText(e.Length);
    }

    private void OnTimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
    {
        DisplayTimeText(e.Time);

    }
    #endregion

    #region Display - Functions
    private void DisplayLengthText(long length)
    {
        if (lblLength.InvokeRequired)
        {
            var d = new SafeCallDelegateDisplayTimeText(DisplayLengthText);
            lblLength.Invoke(d, new object[] { length });
        }
        else
        {
            lblLength.Text = $"{length}";
        }
    }

    private void DisplayTrackPosition(double position)
    {
        if (tbPosition.InvokeRequired)
        {
            var d = new SafeCallDelegateDisplayTrackPosition(DisplayTrackPosition);
            tbPosition.Invoke(d, new object[] { position });
        }
        else
            tbPosition.Value = (int)Math.Round(position * 100, 0);
    }

    private void DisplayMediaInfo()
    {
        if (lblMedia.InvokeRequired)
        {
            var d = new SafeCallDelegateDisplayMediaInfo(DisplayMediaInfo);
            lblMedia.Invoke(d, new object[] { });
        }
        else
        {
            ToolTip tt = new ToolTip();
            if (_mp.ChapterCount == 0)
            {
                tt.SetToolTip(btnBackwardChapter, "Anfang");
                tt.SetToolTip(btnForwardChapter, "Ende");
            }
            else
            {
                tt.SetToolTip(btnBackwardChapter, "Kapitel zurück");
                tt.SetToolTip(btnForwardChapter, "Kaptiel vorwärts");
            }

            btnBackwardChapter.Enabled = btnBackward.Enabled = btnPlayStop.Enabled = btnForward.Enabled = btnForwardChapter.Enabled =
            btnMute.Enabled = true;

            const string FILE_INDICATOR = "file:///";
            string media = _mp.Media.Mrl;
            if (media.StartsWith(FILE_INDICATOR))
            {
                media = media.Trim().Substring(FILE_INDICATOR.Length).Replace("%20", " ");
                media = media.Replace("%27", "'");
                media = media.Replace("%28", "(");
                media = media.Replace("%29", ")");
            }
            lblMedia.Text = media;
            lblStartTime.Text = $"{_startTime:HH:mm:ss}";
            lblEndTime.Text = $"{_endTime:HH:mm:ss}";

            // Info Box
            TimeSpan ts = TimeSpan.FromMilliseconds(_mp.Media.Duration);
            lblDisplayDuration.Text = ts.ToString(@"hh\:mm\:ss");
        }
    }


    private void DisplayTimeText(long time)
    {
        if (lblTime.InvokeRequired)
        {
            var d = new SafeCallDelegateDisplayTimeText(DisplayTimeText);
            lblTime.Invoke(d, new object[] { time });
        }
        else
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(time);
            lblTime.Text = ts.ToString().Substring(0, 8);
        }
    }
    #endregion

    private void MediaPlayer_PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
    {
        //throw new NotImplementedException();
            
    }

    private void OnPlaying(object sender, EventArgs e)
    {
        _startTime = DateTime.Now;
        _endTime = _startTime.AddMilliseconds(_mp.Media.Duration);
    }

    private void DisplayActionText(string text)
    {
        if (lblAction.InvokeRequired)
        {
            var d = new SafeCallDelegateDisplayActionText(DisplayActionText);
            lblAction.Invoke(d, new object[] { text });
        }
        else
            lblAction.Text = text;
    }

    private void OnOpening(object sender, EventArgs e)
    {
        DisplayMediaInfo();
    }

    private void OnForward(object sender, EventArgs e)
    {
        btnForward.Enabled = (_mp.Position <= 0.99);
    }

    private void OnEndReached(object sender, EventArgs e)
    {
           
    }

    private void Mediaplayer_EncounteredError(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void Mediaplayer_Corked(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void Mediaplayer_ChapterChanged(object sender, MediaPlayerChapterChangedEventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void Mediaplayer_Buffering(object sender, MediaPlayerBufferingEventArgs e)
    {
        //throw new NotImplementedException();
        DisplayActionText("Buffering...");
    }

    private void OnBackward(object sender, EventArgs e)
    {
        btnBackward.Enabled = (_mp.Position >= .01f);
    }

    private void MediaPlayer_AudioChanged(object sender, MediaPlayerAudioDeviceEventArgs e)
    {
        //throw new NotImplementedException();
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        _mp.Stop();
        _mp.Dispose();
        _libVLC.Dispose();

        base.OnHandleDestroyed(e);
    }

    private void videoViewer_MouseClick(object sener, MouseEventArgs e)
    {
        // Controller anzeigen bei Click in linke obere Ecke
        if (e.Button == MouseButtons.Left)
        {
            if (!panController.Visible && e.Location.X > 0 && e.Location.X < 20 && e.Location.Y > 0 && e.Location.Y < 20)
                panController.Visible = true;
        }
    }



    private void videoViewer_KeyDown(object sender, KeyEventArgs e)
    {
        KeyReact(e);
    }

    private void KeyReact(KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            //case Keys.D:
            //    ToggleFullScreen();
            //    break;

            case Keys.O:
                btnOpenMedia_Click(null, null);
                break;
            case Keys.Left: 
                _mp.Position -= .01f;
                break;
            case Keys.Right:
                _mp.Position += .01f;
                break;
            case Keys.M:
                _mp.Mute = !_mp.Mute;
                break;
            default:
                break;
        }

    }

    private void videoViewer_KeyPress(object sender, KeyPressEventArgs e)
    {
            
    }

    private void videoViewer_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            KeyReact(e);
    }

    private void ToggleFullScreen()
    {
        if (_mp.State == VLCState.Playing)
        {
            if (!_isFullScreen)
            {
                _oldVideoLocation = videoViewer.Location;
                _oldVideoSize = videoViewer.Size;

                videoViewer.Location = new Point(0, 0);
                videoViewer.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    
                _isFullScreen = true;
            }
            else
            {
                videoViewer.Location = _oldVideoLocation;
                videoViewer.Size = _oldVideoSize;

                _isFullScreen = false;
            }
        }

    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        panController.Visible = false;
    }

    private void btnPlayStop_Click(object sender, EventArgs e)
    {
        if (_mp.IsPlaying)
        {
            btnPlayStop.ForeColor = Color.MediumSeaGreen;
            btnPlayStop.Text = "A";
            _mp.Pause();

        }
        else
        {
            btnPlayStop.ForeColor = Color.Red;
            btnPlayStop.Text = "B";
            _mp.Play();
        }
    }

    private void btnMute_Click(object sender, EventArgs e)
    {
        if (_mp.IsPlaying)
            _mp.Mute = !_mp.Mute;
    }

    private void btnBackward_Click(object sender, EventArgs e)
    {
        if (_mp.IsPlaying && _mp.IsSeekable && _mp.Position >= _step)
            _mp.Position -= _step;
    }

    private void btnForward_Click(object sender, EventArgs e)
    {
        if (_mp.IsPlaying && _mp.IsSeekable && _mp.Position <= 1.0f - _step)
            _mp.Position += _step;
    }

    private void OpenMedia(Media media)
    {
        if (media != null)
        {
            _mp.Media = media;
            btnPlayStop_Click(null, null);
            media.Dispose();
        }
    }

    private void btnOpenMedia_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();
        dlg.Multiselect = false;
        dlg.RestoreDirectory = true;
        dlg.Title = "Medium öffnen";
        if (dlg.ShowDialog() == DialogResult.OK && File.Exists(dlg.FileName))
        {
            FileInfo fi = new FileInfo(dlg.FileName);
            var media = new Media(_libVLC, fi.FullName, FromType.FromPath);
            OpenMedia(media);
        }
    }

    private void btnOpenMediaFromLocation_Click(object sender, EventArgs e)
    {
        dlgUrl dlg = new dlgUrl();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            // string url = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";
            var media = new Media(_libVLC, dlg.Url, FromType.FromLocation);
            OpenMedia(media);
        }
    }

    private void btnBackwardChapter_Click(object sender, EventArgs e)
    {
        if (_mp.ChapterCount == 0)
            _mp.Position = 0.0f;
        else
        {
            if (_mp.Chapter > 0)
                _mp.PreviousChapter();
        }
    }

    private void btnForwardChapter_Click(object sender, EventArgs e)
    {
        if (_mp.ChapterCount == 0)
            _mp.Position = 1.0f;
        else
        {
            if (_mp.Chapter < _mp.ChapterCount - 1)
                _mp.NextChapter();
        }
    }
}

