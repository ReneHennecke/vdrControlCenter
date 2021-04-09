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

    public partial class CommanderController : UserControl
    {
        private vdrControlCenterContext _context;

        private frmMain _mainForm;
        public frmMain MainForm
        {
            set => _mainForm = value;
        }

        public CommanderController()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            string local = $"{Environment.MachineName} # ";
            lblLeft.Text = local;
            cmbRight.Items.Add(local);
            cmbRight.SelectedIndex = 0;

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

            }

            
            LoadDirectoryLeft();
            LoadDirectoryRight();
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
//                            LocalFolder = cvLocal.FileSystemEntry.FullPath,
//                            RemoteFolder = cvRemote.FileSystemEntry.FullPath
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

  

        private void LoadDirectoryLeft()
        {
            try
            {
                //FileSystemEntry fse = new FileSystemEntry(_folderLocal);
                //cvLeft.FileSystemEntry = fse;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                    "Filesystem-Fehler",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        private void LoadDirectoryRight()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Remote Filesystem-Fehler",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

            }

        }

        public void Execute(KeyEventArgs ea, bool  local, FileSystemEntry fse)
        {
            //switch (ea.KeyCode)
            //{
            //    case Keys.Enter:
            //        if (fse.Attributes.HasFlag(FileAttributes.Directory))
            //        {
            //            try
            //            {
            //                if (local)
            //                {
            //                    if (Directory.Exists(fse.FullPath))
            //                        Directory.SetCurrentDirectory(fse.FullPath);

            //                    cvLocal.FileSystemEntry = fse;
            //                }
            //                else
            //                {
            //                    FileSystemEntryRequest request = new FileSystemEntryRequest();
            //                    request.FullPath = fse.FullPath;
            //                    string action = $"{_url}FileSystem/SetDirectory";

            //                    string json = await PostData(action, request);

            //                    var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
            //                    if (response != null)
            //                        cvRemote.FileSystemEntry = response.FileSystemEntry;
            //                }

            //                SaveData();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message,
            //                                "Remote Filesystem-Fehler",
            //                                MessageBoxButtons.OK,
            //                                MessageBoxIcon.Error);
            //            }
            //        }
            //        else
            //        {
            //            try
            //            {
            //                if (local)
            //                {
            //                    switch (fse.Extension.ToLower())
            //                    {
            //                        case "txt":
            //                        case "conf":

            //                        default:

            //                            break;
            //                    }
                                
            //                }
            //                else
            //                {

            //                }

            //            }
            //            catch //(Exception ex)
            //            {

            //            }
            //        }

            //        break;
            //    case Keys.F3:
            //        try
            //        {
            //            if (local)
            //            {
            //                switch (fse.Extension.ToLower())
            //                {
            //                    case ".txt":
            //                    case ".conf":
            //                    case ".config":
            //                    case ".cs":
            //                        string content = await File.ReadAllTextAsync(fse.FullPath);
            //                        dlgEditor dlg = new dlgEditor();
            //                        dlg.PostInit(this, local, fse, content, true);
            //                        dlg.Show();
            //                        break;
            //                    default:

            //                        break;
            //                }
            //            }
            //            else
            //            {
            //                switch (fse.Extension.ToLower())
            //                {
            //                    case ".txt":
            //                    case ".conf":
            //                    case ".config":
            //                        FileSystemEntryRequest request = new FileSystemEntryRequest();
            //                        request.FullPath = fse.FullPath;
            //                        string action = $"{_url}FileSystem/ReadFileContent";

            //                        string json = await PostData(action, request);

            //                        var response = JsonConvert.DeserializeObject<FileSystemResponse>(json);
            //                        if (response != null)
            //                        {
            //                            byte[] bytes = Convert.FromBase64String(response.FileContent.Content);
            //                            string content = Encoding.UTF8.GetString(bytes);

            //                            dlgEditor dlg = new dlgEditor();
            //                            dlg.PostInit(this, local, fse, content, true);
            //                            dlg.Show();
            //                        }
            //                        break;
            //                    default:

            //                        break;
            //                }
            //            }

            //        }
            //        catch //(Exception ex)
            //        {

            //        }
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
