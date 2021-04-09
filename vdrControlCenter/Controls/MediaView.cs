namespace vdrControlCenterUI.Controls
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using LibVLCSharp.Shared;

    public partial class MediaView : UserControl
    {
        private LibVLC _libVLC;
        private MediaPlayer _mp;

        private bool _isFullScreen = false;
        private Point _oldVideoLocation;
        private Size _oldVideoSize;

        private delegate void SafeCallDelegateDisplayActionText(string text);
        private delegate void SafeCallDelegateDisplayTimeText(long time);
        private delegate void SafeCallDelegateDisplayLength(long length);

        private DateTime _startTime;
        private DateTime _endTime;

        private frmMain _mainForm;
        public frmMain MainForm
        {
            set { _mainForm = value; }
        }

        public MediaView()
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

            _mp = new MediaPlayer(_libVLC);

            _mp.AudioDevice += MediaPlayer_AudioChanged;
            _mp.Backward += Mediaplayer_Backward;
            _mp.Buffering += Mediaplayer_Buffering;
            _mp.ChapterChanged += Mediaplayer_ChapterChanged;
            _mp.Corked += Mediaplayer_Corked;
            _mp.EncounteredError += Mediaplayer_EncounteredError;
            _mp.EndReached += Mediaplayer_EndReached;

            _mp.Forward += Mediaplayer_Forward;
            _mp.Opening += Mediaplayer_Opening;
            _mp.Playing += OnPlaying;

            _mp.LengthChanged += OnLengthChanged;
            _mp.PositionChanged += OnPositionChanged;

            _mp.TimeChanged += OnTimeChanged;
            _mp.Uncorked += Oncorked;
            _mp.Unmuted += OnMuted;

            // Sonst kommen keine Events im Control an
            _mp.EnableKeyInput = false;
            _mp.EnableMouseInput = false;
            
            videoViewer.MediaPlayer = _mp;
            
            Focus();
        }

        private void OnMuted(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Oncorked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnPositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
           // var frameposition = e.Position * (selVideoRange.FrameMax - selVideoRange.FrameMin);
        }

        private void OnLengthChanged(object sender, MediaPlayerLengthChangedEventArgs e)
        {
            DisplayLengthText(e.Length);
        }

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

        private void OnTimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            DisplayTimeText(e.Time);

        }

        private void DisplayTimeText(long time)
        {
            //if (lblTime.InvokeRequired)
            //{
            //    var d = new SafeCallDelegateDisplayTimeText(DisplayTimeText);
            //    lblTime.Invoke(d, new object[] { time });
            //}
            //else
            //{
            //    TimeSpan ts = TimeSpan.FromMilliseconds(time);
            //    lblTime.Text = ts.ToString().Substring(0, 8);
            //}
        }

        private void MediaPlayer_PositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void OnPlaying(object sender, EventArgs e)
        {
            _startTime = DateTime.Now;
            _endTime = _startTime.AddMilliseconds(_mp.Media.Duration);
            DisplayActionText("Playing...");
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

        private void Mediaplayer_Opening(object sender, EventArgs e)
        {
            DisplayActionText("Opening...");
        }

        private void Mediaplayer_Forward(object sender, EventArgs e)
        {
            //   throw new NotImplementedException();
            DisplayActionText("Forwarding...");
        }

        private void Mediaplayer_EndReached(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
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

        private void Mediaplayer_Backward(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DisplayActionText("Backwarding...");
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

        private void videoViewer_MouseClick(object sender, MouseEventArgs e)
        {
            // Controller anzeigen bei Click in linke obere Ecke
            if (e.Button == MouseButtons.Left)
            {
                if (!panController.Visible && e.Location.X > 0 && e.Location.X < 20 && e.Location.Y > 0 && e.Location.Y < 20)
                    panController.Visible = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                OpenMediaFile();
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
                    OpenMediaFile();
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

        private void OpenMediaFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = "Medien öffnen";
            if (dlg.ShowDialog() == DialogResult.OK && File.Exists(dlg.FileName))
            {
                FileInfo fi = new FileInfo(dlg.FileName);
                //                (_libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
                // new Media(_libVLC, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", FromType.FromLocation);
                var media = new Media(_libVLC, fi.FullName, FromType.FromPath);
                _mp.Play(media);
                media.Dispose();
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
    }
}
