namespace vdrControlCenterUI.Controls
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using vdrControlService.Models;
    using vdrControlService.Models.Requests;
    using vdrControlService.Models.Responses;

    public partial class ServiceController : UserControl
    {
        private frmMain _mainForm;
        public frmMain MainForm
        {
            set => _mainForm = value;
        }

        private HttpClient _httpClient;
        
        private string _url;
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

            //serviceConnector.LoadData(this);
            _url = "https://localhost:5001/api/";
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

        private async void button1_Click(object sender, System.EventArgs e)
        {
            CurrentDirectoryRequest request = new CurrentDirectoryRequest();
            string action = $"{_url}FileSystem/GetCurrentDirectory";
            
            string json = await PostData(action, request);

            var response = JsonConvert.DeserializeObject<DirectoryInfo>(json);
            if (response != null)
            {
                //teResponse.Text += response.DirEntryInfoResult.DirEntryInfo.FullName + "\r\n";
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

        private void button2_Click(object sender, EventArgs e)
        {
            tmConnector_Tick(null, null);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            CurrentDirectoryRequest request = new CurrentDirectoryRequest();
            request.FullPath = "/etc";
            string action = $"{_url}FileSystem/SetCurrentDirectory";

            string json = await PostData(action, request);

            var response = JsonConvert.DeserializeObject<CurrentDirectoryResponse>(json);
            if (response != null)
            {
                teResponse.Text += response.DirEntryInfoResult.DirEntryInfo.FullName + "\r\n";
            }
        }
    }
}
