using FFmpeg.NET;
using FFmpeg.NET.Enums;
using FFmpeg.NET.Events;

namespace vdrControlCenterUI.Controls
{
    public partial class Transcoder : UserControl
    {
        private Engine _ffmpeg;
        private CancellationTokenSource _cts;
        private frmMain _frmMain;
        public frmMain MainForm
        {
            set { _frmMain = value; }
        }

        public Transcoder()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}ffmpeg{Path.DirectorySeparatorChar}";
            path += AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86 ? "win-x86" : "win-x64" + 
                $"{Path.DirectorySeparatorChar}ffmpeg.exe";

            try
            {
                _ffmpeg = new Engine(path);
                _ffmpeg.Progress += OnProgress;
                _ffmpeg.Data += OnData;
                _ffmpeg.Error += OnError;
                _ffmpeg.Complete += OnComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Initialisieren des Transcoders{Environment.NewLine}{ex.Message}",
                                "Fehler beim Initialisieren ffmpeg",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                btnInput.Enabled = false;
                btnTranscode.Enabled = false;
            }

            _cts = new CancellationTokenSource();
        }

        private void OnComplete(object sender, ConversionCompleteEventArgs e)
        {
            //Console.WriteLine("Completed conversion from {0} to {1}", e.Input.FileInfo.FullName, e.Output.FileInfo.FullName);

            try
            {
                Invoke(() => Reset());
            }
            catch //(Exception ex)
            {

            }
        }

        private void OnError(object sender, ConversionErrorEventArgs e)
        {
            // Console.WriteLine("[{0} => {1}]: Error: {2}\n{3}", e.Input.FileInfo.Name, e.Output.FileInfo.Name, e.Exception.ExitCode, e.Exception.InnerException);

            MessageBox.Show(e.Exception.Message);
        }

        private void OnData(object sender, ConversionDataEventArgs e)
        {
            //Console.WriteLine("[{0} => {1}]: {2}", e.Input.FileInfo.Name, e.Output.FileInfo.Name, e.Data);
        }

        private void OnProgress(object sender, ConversionProgressEventArgs e)
        {
            try
            {
                Invoke(new Action(() => 
                {
                    lblInputValue.Text = e.Input.Name;
                    lblOutputValue.Text = e.Output.Name;
                    lblBitrateValue.Text = $"{e.Bitrate:0.0}";
                    lblFpsValue.Text = $"{e.Fps}";
                    lblFrameValue.Text = $"{e.Frame}";
                    lblSizeValue.Text = $"{e.SizeKb:N0}";
                    lblTotalDurationValue.Text = $"{e.TotalDuration:hh\\:mm\\:ss}";
                    lblProcessedDurationValue.Text = $"{e.ProcessedDuration:hh\\:mm\\:ss}";
                }));
            }
            catch //(Exception ex)
            {

            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Dateiliste laden...";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                livInput.SuspendLayout();
                livInput.Items.Clear();

                var files = new DirectoryInfo(dlg.SelectedPath).GetFiles("*.*");
                foreach (var file in files)
                {
                    var item = new ListViewItem();
                    item.Text = file.FullName;
                    item.SubItems.Add($"{file.Length:N0}");
                    item.SubItems.Add($"{file.LastWriteTime:dd.MM.yyyy HH:mm:ss}");
                    item.Tag = file;
                    livInput.Items.Add(item);   
                }

                livInput.ResumeLayout();
            }

        }

        private async void btnTranscode_Click(object sender, EventArgs e)
        {
            if (livInput.CheckedItems.Count == 0)
                return;

            if (btnTranscode.Text == "Abbrechen")
            {
                _cts.Cancel();
                return;
            }

            btnInput.Enabled = false;
            btnTranscode.Text = "Abbrechen";

            var conversionOptions = new ConversionOptions
            {
                MaxVideoDuration = TimeSpan.FromSeconds(30),
                VideoAspectRatio = VideoAspectRatio.R16_9,
                VideoSize = VideoSize.Hd1080,
                AudioSampleRate = AudioSampleRate.Hz44100
            };

            var tasks = new List<Task>();
            foreach (ListViewItem item in livInput.CheckedItems)
            {
                var file = (FileInfo)item.Tag;

                var inputFile = new InputFile(file.FullName);
                var outputFile = new OutputFile($"{file.FullName}.mp4");

                tasks.Add(_ffmpeg.ConvertAsync(inputFile, outputFile, _cts.Token));
            }

            try
            {
                await Task.WhenAll(tasks);
            }
            catch
            {
                
                
            }

            Reset();
        }

        private void Reset()
        {
            btnInput.Enabled = true;

            lblInputValue.Text = string.Empty;
            lblOutputValue.Text = string.Empty;
            lblBitrateValue.Text = string.Empty;
            lblFpsValue.Text = string.Empty;
            lblSizeValue.Text = string.Empty;
            lblFrameValue.Text = string.Empty;
            lblTotalDurationValue.Text = string.Empty;
            lblProcessedDurationValue.Text = string.Empty;

            btnInput.Enabled = true;
            btnTranscode.Text = "Transcode";
        }
    }
}
