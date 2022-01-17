namespace vdrControlCenterUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Enums;
    using vdrControlCenterUI.Controls;
    using DataLayer.Classes;

    public partial class frmMain : Form
    {
        private Point _imageLocation = new Point(20, 4);
        private Point _imgHitArea = new Point(20, 4);
        private Image _closeImage;
        private const int FRAME_MAXIMIZED = -1;

        private delegate void AddMessageCallback(string msg);

        // Winuser.h Konstanten
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_RESTORE = 0xF120;
        
        public frmMain()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {
            Visible = false;

            Text = RaX.Extensions.Data.ApplicationInfo.ProductName + " " + RaX.Extensions.Data.ApplicationInfo.Version + " " + RaX.Extensions.Data.ApplicationInfo.CopyrightHolder + " " + RaX.Extensions.Data.ApplicationInfo.CompanyName;

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
                Text = "Datei Manager",
                ImageIndex = (int)Navigation.Commander,
                SelectedImageIndex = (int)Navigation.Commander,
                Tag = Navigation.Commander
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
                Text = "UPnP - Manager",
                ImageIndex = (int)Navigation.UPnPBrowser,
                SelectedImageIndex = (int)Navigation.UPnPBrowser,
                Tag = Navigation.UPnPBrowser
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

        private async void tabWorkspace_MouseClick(object sender, MouseEventArgs e)
        {
            // TabPage schliessen
            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;
            int tabWidth = 0;
            tabWidth = tabWorkspace.GetTabRect(tabControl.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = tabWorkspace.GetTabRect(tabControl.SelectedIndex);
            r.Offset(tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            bool closePanels = false;
            if (tabWorkspace.SelectedIndex >= 0)
            {
                if (r.Contains(p))
                {
                    TabPage page = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    Navigation navigation = (Navigation)page.Tag;
                    switch (navigation)
                    {
                        case Navigation.Setup:
                            var systemSettingsView = (SystemSettingsController)page.Controls[0];
                            await systemSettingsView.SaveData();
                            closePanels = true;
                            break;
                        case Navigation.Commander:
                            var commanderController = (CommanderController)page.Controls[0];
                            commanderController.SaveConfig();
                            break;
                        case Navigation.SVDRP:
                            var svdrpController = (SvdrpController)page.Controls[0];
                            svdrpController.Disconnect();
                            break;
                        default:
                            break;
                    }

                    tabControl.TabPages.Remove(page);
                    if (closePanels)
                    {
                        MessageBox.Show("Zum Laden der neuen Einstellungen werden alle geöffneten Panels geschlossen.",
                                        "Einstellungen geändert",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        ClosePanels();

                        viewStations.PopulateData();
                    }
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
                bool resize = false;
                switch (navigation)
                {
                    case Navigation.Setup:
                        {
                            page.Text = "Setup";
                            page.ImageIndex = (int)Navigation.Setup;
                            var controller = new SystemSettingsController();
                            controller.MainForm = this;
                            controller.Dock = DockStyle.Fill;
                            page.Controls.Add(controller);
                        }
                        break;
                    case Navigation.SSH:
                        {
                            page.Text = "SSH";
                            page.ImageIndex = (int)Navigation.SSH;
                            var controller = new SshController();
                            controller.MainForm = this;
                            controller.Dock = DockStyle.Fill;
                            page.Controls.Add(controller);
                        }
                        break;
                    case Navigation.VDRAdmin:
                        {
                            page.Text = "VDR-Admin";
                            page.ImageIndex = (int)Navigation.VDRAdmin;
                            var controller = new VDRAdmindController();
                            controller.Dock = DockStyle.Fill;
                            page.Controls.Add(controller);
                        }
                        break;
                    case Navigation.SVDRP:
                        {
                            page.Text = "SVDRP";
                            page.ImageIndex = (int)Navigation.SVDRP;
                            var controller = new SvdrpController();
                            controller.MainForm = this;
                            controller.Dock = DockStyle.Fill;
                            page.Controls.Add(controller);
                        }
                        break;
                    case Navigation.Editor:
                        page.Text = "Editoren";
                        page.ImageIndex = (int)Navigation.Editor;
                        break;
                    case Navigation.EPGGuide:
                        {
                            page.Text = "EPG-Guide";
                            page.ImageIndex = (int)Navigation.EPGGuide;
                            var controller = new EpgGuideLineController();
                            controller.MainForm = this;
                            controller.Dock = DockStyle.Fill;
                            page.Controls.Add(controller);
                            controller.LoadData();
                            resize = true;
                        }
                        break;
                    case Navigation.Video:
                        {
                            page.Text = "Video";
                            page.ImageIndex = (int)Navigation.Video;
                            var controller = new MediaController();
                            controller.MainForm = this;
                            controller.Dock = DockStyle.Fill;
                            page.Controls.Add(controller);
                        }
                        break;
                    case Navigation.Commander:
                        {
                            page.Text = "Datei Manager";
                            page.ImageIndex = (int)Navigation.Commander;
                            var controller = new CommanderController();
                            controller.MainForm = this;
                            controller.Dock = DockStyle.Fill;
                            page.Controls.Add(controller);
                        }
                        break;
                    case Navigation.UPnPBrowser:
                        {
                            page.Text = "UPNP Manager";
                            page.ImageIndex = (int)Navigation.UPnPBrowser;
                            var controller = new UPnPBrowser();
                            controller.MainForm = this;
                            controller.Dock = DockStyle.Fill;
                            page.Controls.Add(controller);
                        }
                        break;
                    default:
                        break;
                }

                tabWorkspace.TabPages.Add(page);
                if (resize)
                    frmMain_ResizeEnd(null, null);
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
                
        private void LoadSettings()
        {
            Configuration configuration = ConfigurationHelper.CurrentConfig;
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

        private void SaveSettings()
        {
            Configuration configuration = ConfigurationHelper.CurrentConfig;
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
            
            ConfigurationHelper.CurrentConfig = configuration;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosePanels();
            SaveSettings();
        }

        private async void ClosePanels()
        {
            foreach (TabPage page in tabWorkspace.TabPages)
            {
                if (page.Controls.Count > 0)
                {
                    if (page.Controls[0] is SystemSettingsController)
                    {
                        SystemSettingsController controller = (SystemSettingsController)page.Controls[0];
                        await controller.SaveData();
                    }
                    else if (page.Controls[0] is CommanderController)
                    {
                        CommanderController controller = (CommanderController)page.Controls[0];
                        controller.SaveConfig();
                    }
                    else if (page.Controls[0] is SvdrpController)
                    {
                        SvdrpController controller = (SvdrpController)page.Controls[0];
                        controller.Disconnect();
                    }
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadSettings();
            Visible = true;
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            foreach (TabPage page in tabWorkspace.TabPages)
            {
                if (page.Controls.Count > 0)
                {
                    if (page.Controls[0] is EpgGuideLineController)
                    {
                        EpgGuideLineController controller = (EpgGuideLineController)page.Controls[0];
                        controller.Redraw();
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam == new IntPtr(SC_MAXIMIZE) || m.WParam == new IntPtr(SC_RESTORE))
                    frmMain_ResizeEnd(null, null);
            }
        }
    }
}
