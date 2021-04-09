namespace vdrControlCenterUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Enums;
    using vdrControlCenterUI.Controls;
    using Microsoft.EntityFrameworkCore.Storage;
    using DataLayer.Models;
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using DataLayer.Classes;

    public partial class frmMain : Form
    {
        private Point _imageLocation = new Point(20, 4);
        private Point _imgHitArea = new Point(20, 4);
        private Image _closeImage;
        private const int FRAME_MAXIMIZED = -1;
        
        private delegate void AddMessageCallback(string msg);
        
        public frmMain()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {
            Text = ApplicationInfoRaX.ProductName + " " + ApplicationInfoRaX.Version + " " + ApplicationInfoRaX.CopyrightHolder + " " + ApplicationInfoRaX.CompanyName;

            _closeImage = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.ClosePng}");
            tabWorkspace.Padding = new Point(20, 4);

            ImageList imageList = Globals.LoadImageList(ImageListType.MainForm);

            trvNavigation.ImageList = imageList;
            trvNavigation.Font = new Font("Calibri", 11.0f);

            tabWorkspace.ImageList = imageList;

            TreeNode node = new TreeNode()
            {
                Text = "Einstellungen",
                ImageIndex = (int)Navigation.Setup,
                SelectedImageIndex = (int)Navigation.Setup,
                Tag = Navigation.Setup
            };
            trvNavigation.Nodes.Add(node);
            
            node = new TreeNode()
            {
                Text = "SSH",
                ImageIndex = (int)Navigation.SSH,
                SelectedImageIndex = (int)Navigation.SSH,
                Tag = Navigation.SSH
            };
            trvNavigation.Nodes.Add(node);

            node = new TreeNode()
            {
                Text = "Service",
                ImageIndex = (int)Navigation.Service,
                SelectedImageIndex = (int)Navigation.Service,
                Tag = Navigation.Service
            };
            trvNavigation.Nodes.Add(node);

            node = new TreeNode()
            {
                Text = "VDR-Admin",
                ImageIndex = (int)Navigation.VDRAdmin,
                SelectedImageIndex = (int)Navigation.VDRAdmin,
                Tag = Navigation.VDRAdmin
            };
            trvNavigation.Nodes.Add(node);

            node = new TreeNode()
            {
                Text = "SVDRP",
                ImageIndex = (int)Navigation.SVDRP,
                SelectedImageIndex = (int)Navigation.SVDRP,
                Tag = Navigation.SVDRP
            };
            trvNavigation.Nodes.Add(node);

            node = new TreeNode()
            {
                Text = "Editoren",
                ImageIndex = (int)Navigation.Editor,
                SelectedImageIndex = (int)Navigation.Editor,
                Tag = Navigation.Editor
            };
            trvNavigation.Nodes.Add(node);


            node = new TreeNode()
            {
                Text = "EPG-Guide",
                ImageIndex = (int)Navigation.EPGGuide,
                SelectedImageIndex = (int)Navigation.EPGGuide,
                Tag = Navigation.EPGGuide
            };
            trvNavigation.Nodes.Add(node);

            node = new TreeNode()
            {
                Text = "Video",
                ImageIndex = (int)Navigation.Video,
                SelectedImageIndex = (int)Navigation.Video,
                Tag = Navigation.Video
            };
            trvNavigation.Nodes.Add(node);

            node = new TreeNode()
            {
                Text = "Datei Manager",
                ImageIndex = (int)Navigation.Commander,
                SelectedImageIndex = (int)Navigation.Commander,
                Tag = Navigation.Commander
            };
            trvNavigation.Nodes.Add(node);

            trvNavigation.SelectedNode = null;

            viewStations.PopulateData();
        }

        private TabPage FindTabPage(Navigation navigation)
        {
            TabPage tabPage = null;

            foreach (TabPage page in tabWorkspace.TabPages)
            {
                if ((Navigation)page.Tag == navigation)
                {
                    tabPage = page;
                    break;
                }
            }
                
            return tabPage;
        }

        private void tabWorkspace_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;
            int tabWidth = 0;
            tabWidth = tabWorkspace.GetTabRect(tabControl.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = tabWorkspace.GetTabRect(tabControl.SelectedIndex);
            r.Offset(tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (tabWorkspace.SelectedIndex >= 0)
            {
                if (r.Contains(p))
                {
                    TabPage page = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    Navigation navigation = (Navigation)page.Tag;
                    switch (navigation)
                    {
                        case Navigation.Setup:
                            SystemSettingsView systemSettingsView = (SystemSettingsView)page.Controls[0];
                            systemSettingsView.SaveData();
                            break;
                        default:
                            break;
                    }

                    tabControl.TabPages.Remove(page);
                }
            }
        }

        private void tabWorkspace_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            Rectangle r = e.Bounds;
            r = tabWorkspace.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = Font;
            string title = tabWorkspace.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X + 30, r.Y + 2));

            Image img = new Bitmap(_closeImage);
            e.Graphics.DrawImage(img, new Point(r.X + (tabWorkspace.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));

            TabPage page = tabWorkspace.TabPages[e.Index];
            if (page.ImageIndex > -1)
            {
                img = tabWorkspace.ImageList.Images[page.ImageIndex];
                e.Graphics.DrawImage(img, new Point(r.X, _imageLocation.Y));
            }
        }

        public void AddMessage(string msg)
        {
            if (teMessages.InvokeRequired)
            {
                AddMessageCallback amcb = new AddMessageCallback(AddMessage);
                Invoke(amcb, new object[] { msg });
            }
            else
            {
                teMessages.Text += $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}:{msg}{Environment.NewLine}";
                teMessages.SelectionStart = teMessages.Text.Length;
                teMessages.ScrollToCaret();
            }
        }

        private void trvNavigation_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Navigation navigation = (Navigation)e.Node.Tag;
            TabPage page = FindTabPage(navigation);
            if (page == null)
            {
                page = new TabPage()
                {
                    Tag = navigation
                };

                string title = string.Empty;
                switch (navigation)
                {
                    case Navigation.Setup:
                        page.Text = "Setup";
                        page.ImageIndex = (int)Navigation.Setup;
                        SystemSettingsView systemSettingsView = new SystemSettingsView();
                        systemSettingsView.MainForm = this;
                        systemSettingsView.Dock = DockStyle.Fill;
                        page.Controls.Add(systemSettingsView);
                        break;
                    case Navigation.SSH:
                        page.Text = "SSH";
                        page.ImageIndex = (int)Navigation.SSH;
                        SshController sshController = new SshController();
                        sshController.MainForm = this;
                        sshController.Dock = DockStyle.Fill;
                        page.Controls.Add(sshController);
                        break;
                    case Navigation.Service:
                        page.Text = "VDR-Service";
                        page.ImageIndex = (int)Navigation.Service;
                        ServiceController serviceControllerView = new ServiceController();
                        serviceControllerView.MainForm = this;
                        serviceControllerView.Dock = DockStyle.Fill;
                        page.Controls.Add(serviceControllerView);
                        break;
                    case Navigation.VDRAdmin:
                        page.Text = "VDR-Admin";
                        page.ImageIndex = (int)Navigation.VDRAdmin;
                        VDRAdmindView admindView = new VDRAdmindView();
                        admindView.Dock = DockStyle.Fill;
                        page.Controls.Add(admindView);
                        break;
                    case Navigation.SVDRP:
                        page.Text = "SVDRP";
                        page.ImageIndex = (int)Navigation.SVDRP;
                        SvdrpController svdrpController = new SvdrpController();
                        svdrpController.MainForm = this;
                        svdrpController.Dock = DockStyle.Fill;
                        page.Controls.Add(svdrpController);
                        break;
                    case Navigation.Editor:
                        page.Text = "Editoren";
                        page.ImageIndex = (int)Navigation.Editor;
                        break;
                    case Navigation.EPGGuide:
                        page.Text = "EPG-Guide";
                        page.ImageIndex = (int)Navigation.EPGGuide;
                        EpgGuideLineController epgGuideLineController = new EpgGuideLineController();
                        epgGuideLineController.MainForm = this;
                        epgGuideLineController.Dock = DockStyle.Fill;
                        page.Controls.Add(epgGuideLineController);
                        break;
                    case Navigation.Video:
                        page.Text = "Video";
                        page.ImageIndex = (int)Navigation.Video;
                        MediaView videoView = new MediaView();
                        videoView.MainForm = this;
                        videoView.Dock = DockStyle.Fill;
                        page.Controls.Add(videoView);
                        break;
                    case Navigation.Commander:
                        page.Text = "Datei Manager";
                        page.ImageIndex = (int)Navigation.Commander;
                        CommanderController commanderController = new CommanderController();
                        commanderController.MainForm = this;
                        commanderController.Dock = DockStyle.Fill;
                        page.Controls.Add(commanderController);
                        break;
                    default:
                        break;
                }

                tabWorkspace.TabPages.Add(page);
            }

            tabWorkspace.SelectedTab = page;
        }

        private void trvNavigation_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // Prevent node selection by any other means than the user
            if (e.Action != TreeViewAction.ByMouse && e.Action != TreeViewAction.ByKeyboard)
            {
                e.Cancel = true;
            }
        }
                
        private async void LoadSettings()
        {
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                try
                {
                    Configuration configuration = null;
                    SystemSettings systemSettings = await context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
                    if (systemSettings != null)
                    {
                        if (systemSettings.Configuration != null)
                            configuration = JsonConvert.DeserializeObject<Configuration>(systemSettings.Configuration);
                    }
                       
                    if (configuration == null)
                    {
                        WindowState = FormWindowState.Normal;
                        StartPosition = FormStartPosition.CenterScreen;
                    }
                    else 
                    { 
                        if (configuration.X == FRAME_MAXIMIZED && configuration.Y == FRAME_MAXIMIZED && configuration.Width == FRAME_MAXIMIZED && configuration.Height == FRAME_MAXIMIZED)
                            WindowState = FormWindowState.Maximized;
                        else 
                        {
                            Location = new Point(configuration.X, configuration.Y);
                            Size = new Size(configuration.Width, configuration.Height);
                        }
                    }
                }
                catch //(Exception ex)
                {

                }
            }
        }

        private async void SaveSettings()
        {
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    bool exists = true;
                    Configuration configuration = null;
                    SystemSettings systemSettings = await context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
                    if (systemSettings != null)
                        configuration = JsonConvert.DeserializeObject<Configuration>(systemSettings.Configuration);
                    else
                    {
                        systemSettings = new SystemSettings();
                        exists = false;
                    }

                    if (configuration == null)
                        configuration = new Configuration();

                    if (WindowState == FormWindowState.Maximized)
                    {
                        configuration.X = FRAME_MAXIMIZED;
                        configuration.Y = FRAME_MAXIMIZED;
                        configuration.Width = FRAME_MAXIMIZED;
                        configuration.Height = FRAME_MAXIMIZED;
                    }
                    else
                    {
                        configuration.X = Location.X;
                        configuration.Y = Location.Y;
                        configuration.Width = Size.Width;
                        configuration.Height = Size.Height;
                    }

                    systemSettings.Configuration = JsonConvert.SerializeObject(configuration, Formatting.Indented);
                    if (exists)
                        context.Entry(systemSettings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    else
                        context.SystemSettings.Add(systemSettings);

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch //(Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}
