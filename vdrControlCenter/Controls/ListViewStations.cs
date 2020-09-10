namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public class ListViewStations : ListView
    {
        private ItemDesignConfig _itemDesignConfig;
        public ItemDesignConfig ItemDesignConfig
        {
            get { return _itemDesignConfig; }
            set
            {
                _itemDesignConfig = value;
                Invalidate();
            }
        }

        public ListViewStations()
        {
            PostInit();
        }

        private void PostInit()
        {
            _itemDesignConfig = new ItemDesignConfig()
            {
                ForeColor = ForeColor,
                BackColor = BackColor,
                SelectedBackground1 = Color.LightGray,
                SelectedBackground2 = Color.White,
                Font = new Font("Calibri", 11.0f, FontStyle.Bold)
            };

            DoubleBuffered = true;
            OwnerDraw = true;
            MultiSelect = false;
            FullRowSelect = true;
            HeaderStyle = ColumnHeaderStyle.None;
            View = View.Details;
                        
            SmallImageList = Globals.LoadImageList(Enums.ImageListType.StationView);

            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.TextAlign = HorizontalAlignment.Center;
            columnHeader.Width = 300;
            Columns.Add(columnHeader);
        }


        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            if (!e.Item.Selected)
            {
                using (SolidBrush brush = new SolidBrush(_itemDesignConfig.BackColor))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                    e.DrawFocusRectangle();
                }
            }
            else
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, _itemDesignConfig.SelectedBackground1, _itemDesignConfig.SelectedBackground2, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                TextFormatFlags flags = TextFormatFlags.LeftAndRightPadding | TextFormatFlags.VerticalCenter;

                if (e.Item.ImageIndex >= 0 && e.Item.ImageIndex < SmallImageList.Images.Count)
                {
                    Rectangle rectangle = new Rectangle(e.Bounds.X, e.Bounds.Y, 16, 16);
                    e.Graphics.DrawImage(SmallImageList.Images[e.Item.ImageIndex], rectangle);
                }

                e.DrawText(flags);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = (ListViewItem)GetItemAt(e.X, e.Y);
                if (item != null && item.ImageIndex == 0)   // IP nicht aktiv
                {
                    const int MAC_ADDRESS_LEN = 17;

                    Stations stations = (Stations)item.Tag;
                    string macAddress = (string)stations.MacAddress;
                    if (macAddress?.Length == MAC_ADDRESS_LEN)
                    {
                        macAddress = macAddress.Replace("-", string.Empty).Replace(":", string.Empty);
                        byte[] b = StringRaX.HexStringToByteArray(stations.MacAddress);
                        NetworkRaX.WakeOnLan(b);
                    }
                }
            }
        }
    }
}
