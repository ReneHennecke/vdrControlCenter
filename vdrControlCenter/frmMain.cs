namespace vdrControlCenterUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Enums;
    using vdrControlCenterUI.Dialogs;
    using vdrControlCenterUI.Controls;

    public partial class frmMain : Form
    {
        private Point _imageLocation = new Point(20, 4);
        private Point _imgHitArea = new Point(20, 4);
        private Image _closeImage;


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

            trvNavigation.SelectedNode = null;
            
            viewStations.PopulateData();

            LoadData();
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
                    TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    tabControl.TabPages.Remove(tabPage);
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

        private void LoadData()
        {
            
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
    }
}
