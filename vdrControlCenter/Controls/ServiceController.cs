namespace vdrControlCenterUI.Controls
{
    using DataLayer.Classes;
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Newtonsoft.Json;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using vdrControlService.Models;

    public partial class ServiceController : UserControl
    {
        private frmMain _mainForm;
        public frmMain MainForm
        {
            set => _mainForm = value;
        }

        private HttpClient _httpClient;
        private string _url;
        private vdrControlCenterContext _context;


        private FileSystemEntry _fileSystemEntryLocal = null;
        private FileSystemEntry _fileSystemEntryRemote = null;


        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                //tmConnector.Enabled = (!string.IsNullOrWhiteSpace(_url));
            }
        }

        public ServiceController()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(2);

            serviceConnector.LoadData(this);
            //_url = "https://localhost:5001/api/";

            cvLocal.Controller = this;
            cvLocal.IsLocal = true;
            cvRemote.Controller = this;
            cvRemote.IsLocal = false;

            if (_context == null)
                _context = new vdrControlCenterContext();

            LoadData();
        }

        private async void LoadData()
        {
            SystemSettings systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
            if (systemSettings != null)
            {
                Configuration configuration = null;
                if (systemSettings.Configuration != null)
                    configuration = JsonConvert.DeserializeObject<Configuration>(systemSettings.Configuration);

                _fileSystemEntryLocal = new FileSystemEntry();
                _fileSystemEntryLocal.ReInit(configuration.LocalFolder);

                _fileSystemEntryRemote = new FileSystemEntry();
                _fileSystemEntryRemote.FullPath = configuration.RemoteFolder;
            }

            LoadDirectoryLocal();
            LoadDirectoryRemote();
        }

        private async void SaveData()
        {
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    SystemSettings systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
                    if (systemSettings != null)
                    {
                        Configuration configuration = new Configuration()
                        {
                            LocalFolder = cvLocal.FileSystemEntry.FullPath,
                            RemoteFolder = cvRemote.FileSystemEntry.FullPath
                        };

                        systemSettings.Configuration = JsonConvert.SerializeObject(configuration, Formatting.Indented);
                        _context.Entry(systemSettings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch //(Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }
        }

        private async void tmConnector_Tick(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_url))
            {
                string url = $"{_url}Extensions/IsAlive";
                bool isAlive = false;
                using (HttpResponseMessage response = await _httpClient.GetAsync(url))
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    if (result != null)
                        bool.TryParse(result, out isAlive);
                }
                serviceConnector.ShowConnection(isAlive);
            }
        }



        private void LoadDirectoryLocal()
        {
            try
            {
                if (_fileSystemEntryLocal == null)
                    _fileSystemEntryLocal = new FileSystemEntry(Directory.GetCurrentDirectory());

                cvLocal.FileSystemEntry = _fileSystemEntryLocal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                    "Filesystem-Fehler",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        private async void LoadDirectoryRemote()
        {
            try
            {
                FileSystemEntryRequest request = new FileSystemEntryRequest();
                request.FullPath = _fileSystemEntryRemote.FullPath;
                string action = $"{_url}FileSystem/GetDirectory";

                string json = await PostData(action, request);

                var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                if (response != null)
                    cvRemote.FileSystemEntry = response.FileSystemEntry;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Remote Filesystem-Fehler",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

            }
        }

        public async void Execute(bool local, FileSystemEntry fileSystemEntry)
        {
            if (fileSystemEntry.Attributes.HasFlag(FileAttributes.Directory))
            {
                try
                {
                    if (local)
                    {

                        if (Directory.Exists(fileSystemEntry.FullPath))
                            Directory.SetCurrentDirectory(fileSystemEntry.FullPath);

                        _fileSystemEntryLocal = new FileSystemEntry();
                        _fileSystemEntryLocal.ReInit(fileSystemEntry.FullPath);

                        cvLocal.FileSystemEntry = _fileSystemEntryLocal;
                    }
                    else
                    {
                        FileSystemEntryRequest request = new FileSystemEntryRequest();
                        request.FullPath = fileSystemEntry.FullPath;
                        string action = $"{_url}FileSystem/SetDirectory";

                        string json = await PostData(action, request);

                        var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                        if (response != null)
                            cvRemote.FileSystemEntry = response.FileSystemEntry;
                    }

                    SaveData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Remote Filesystem-Fehler",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {

            }
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
    }
}
