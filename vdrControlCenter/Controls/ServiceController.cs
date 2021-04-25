namespace vdrControlCenterUI.Controls
{
    using DataLayer.Classes;
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using vdrControlCenterUI.Dialogs;
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


        private string _folderLocal;
        private string _folderRemote;
        private bool _inRequest;
        private bool _isAlive;

        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                tmConnector.Enabled = (!string.IsNullOrWhiteSpace(_url));
                if (tmConnector.Enabled)
                    tmConnector_Tick(null, null);
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
            cvRemote.Controller = this;

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

                //_folderLocal = configuration.LocalFolder;
                //_folderRemote = configuration.RemoteFolder;
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
                            //LocalFolder = cvLocal.FileSystemEntry.FullPath,
                            //RemoteFolder = cvRemote.FileSystemEntry.FullPath
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
            if (string.IsNullOrWhiteSpace(_url) || _inRequest)
                return;

            tmConnector.Enabled = false;
            string url = $"{_url}Extensions/IsAlive";
            _isAlive = false;
            try
            {
                using (HttpResponseMessage response = await _httpClient.GetAsync(url))
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    if (result != null)
                        bool.TryParse(result, out _isAlive);
                }
            }
            catch
            {

            }
            serviceConnector.ShowConnection(_isAlive);
            tmConnector.Enabled = true;
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


        private void LoadDirectoryLocal()
        {
            try
            {
                FileSystemEntry fse = new FileSystemEntry(_folderLocal);
                //cvLocal.FileSystemEntry = fse;
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
            if (string.IsNullOrWhiteSpace(_url) || _inRequest)
                return;

            _inRequest = true;

            try
            {
                FileSystemEntryRequest request = new FileSystemEntryRequest();
                request.FullPath = _folderRemote;
                string action = $"{_url}FileSystem/GetDirectory";

                string json = await PostData(action, request);

                var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                //if (response != null)
                //    cvRemote.FileSystemEntry = response.FileSystemEntry;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Remote Filesystem-Fehler",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

            }

            _inRequest = false;
        }

        public async void Execute(KeyEventArgs ea, bool  local, FileSystemEntry fse)
        {
            switch (ea.KeyCode)
            {
                case Keys.Enter:
                    if (fse.Attributes.HasFlag(FileAttributes.Directory))
                    {
                        try
                        {
                            if (local)
                            {
                                if (Directory.Exists(fse.FullPath))
                                    Directory.SetCurrentDirectory(fse.FullPath);

                                //cvLocal.FileSystemEntry = fse;
                            }
                            else
                            {
                                FileSystemEntryRequest request = new FileSystemEntryRequest();
                                request.FullPath = fse.FullPath;
                                string action = $"{_url}FileSystem/SetDirectory";

                                string json = await PostData(action, request);

                                var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                                //if (response != null)
                                //    cvRemote.FileSystemEntry = response.FileSystemEntry;
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
                        try
                        {
                            if (local)
                            {
                                switch (fse.Extension.ToLower())
                                {
                                    case "txt":
                                    case "conf":

                                    default:

                                        break;
                                }
                                
                            }
                            else
                            {

                            }

                        }
                        catch //(Exception ex)
                        {

                        }
                    }

                    break;
                case Keys.F3:
                    try
                    {
                        if (local)
                        {
                            switch (fse.Extension.ToLower())
                            {
                                case ".txt":
                                case ".conf":
                                case ".config":
                                case ".cs":
                                    string content = await File.ReadAllTextAsync(fse.FullPath);
                                    dlgEditor dlg = new dlgEditor();
                                    dlg.PostInit(this, local, fse, content, true);
                                    dlg.Show();
                                    break;
                                default:

                                    break;
                            }
                        }
                        else
                        {
                            switch (fse.Extension.ToLower())
                            {
                                case ".txt":
                                case ".conf":
                                case ".config":
                                    FileSystemEntryRequest request = new FileSystemEntryRequest();
                                    request.FullPath = fse.FullPath;
                                    string action = $"{_url}FileSystem/ReadFileContent";

                                    string json = await PostData(action, request);

                                    var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
                                    if (response != null)
                                    {
                                        byte[] bytes = Convert.FromBase64String(response.FileContent.Content);
                                        string content = Encoding.UTF8.GetString(bytes);

                                        dlgEditor dlg = new dlgEditor();
                                        dlg.PostInit(this, local, fse, content, true);
                                        dlg.Show();
                                    }
                                    break;
                                default:

                                    break;
                            }
                        }

                    }
                    catch //(Exception ex)
                    {

                    }
                    break;
                default:
                    break;
            }
        }
    }
}
