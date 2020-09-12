namespace vdrControlCenterUI
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Enums;
    using System.Linq;
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Drawing.Drawing2D;
    using System.Globalization;
    using vdrControlCenterUI.Dialogs;
    using vdrControlCenterUI.Controls;

    public partial class frmMain : Form
    {
        private bool _inInit;
        private Point _imageLocation = new Point(20, 4);
        private Point _imgHitArea = new Point(20, 4);
        private Image _closeImage;

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

            trvNavigation.ExpandAll();

            viewStations.PopulateData();

            LoadData();

            _inInit = true;
        }

        private void trvNavigation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_inInit)
            {
                _inInit = false;
                return;
            }

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
                        break;
                    case Navigation.SSH:
                        page.Text = "SSH";
                        break;
                    case Navigation.Service:
                        page.Text = "VDR-Service";
                        break;
                    case Navigation.VDRAdmin:
                        page.Text = "VDR-Admin";
                        break;
                    case Navigation.SVDRP:
                        page.Text = "SVDRP";
                        SvdrpConnector svdrpConnector = new SvdrpConnector();
                        page.Controls.Add(svdrpConnector);
                        break;
                    case Navigation.Editor:
                        page.Text = "Editoren";
                        break;
                    case Navigation.EPGGuide:
                        page.Text = "EPG-Guide";
                        break;
                    default:
                        break;
                }

                tabWorkspace.TabPages.Add(page);
            }
            else
                tabWorkspace.SelectedTab = page;
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
            Image img = new Bitmap(_closeImage);
            Rectangle r = e.Bounds;
            r = tabWorkspace.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = Font;
            string title = tabWorkspace.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(img, new Point(r.X + (tabWorkspace.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
        }

        private void LoadData()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dlgSetup dlg = new dlgSetup();
            dlg.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
