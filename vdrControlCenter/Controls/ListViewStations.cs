namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Dialogs;

    public class ListViewStations : ListView
    {
        // TODO : Schriftarten nachbearbeiten

        public delegate void RefreshPingStatusCallback(List<Classes.PingReplyRaX> lpr);

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

        public void RefreshPingStatus(List<PingReplyRaX> lpr)
        {
            if (InvokeRequired)
            {
                var d = new RefreshPingStatusCallback(RefreshPingStatus);
                Invoke(d, new object[] { lpr });
            }
            else
            {
                foreach (PingReplyRaX pr in lpr)
                {
                    ListViewItem item = FindItemWithText(pr.PingedHostAddress.ToString());
                    if (item != null)
                        item.ImageIndex = pr.Reply.Status == System.Net.NetworkInformation.IPStatus.Success ? 1 : 0;
                }
            }
        }

        private void PostInit()
        {
            _itemDesignConfig = new ItemDesignConfig()
            {
                ForeColor = ForeColor,
                BackColor = BackColor,
                SelectedBackground1 = Color.LightGray,
                SelectedBackground2 = Color.White,
                Font = new Font("Forte", 8.0f, FontStyle.Regular)
            };

            DoubleBuffered = true;
            OwnerDraw = true;
            MultiSelect = false;
            FullRowSelect = true;
            HeaderStyle = ColumnHeaderStyle.None;
            View = View.Details;
            ShowItemToolTips = true;
                        
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
            if (e.Item.ImageIndex >= 0 && e.Item.ImageIndex < SmallImageList.Images.Count)
            {
                Rectangle rectangle = new Rectangle(e.Bounds.X, e.Bounds.Y, 16, 16);
                e.Graphics.DrawImage(SmallImageList.Images[e.Item.ImageIndex], rectangle);
            }


            using (SolidBrush brush = new SolidBrush(_itemDesignConfig.ForeColor))
            {
                e.Graphics.DrawString(e.Item.Text, _itemDesignConfig.Font, brush, new PointF(e.Bounds.X + 30, e.Bounds.Y));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
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
                        byte[] b = StringRaX.HexStringToByteArray(macAddress);
                        NetworkRaX.WakeOnLan(b);

                        macAddress = string.Join(":", Enumerable.Range(0, 6).Select(i => macAddress.Substring(i * 2, 2)));

                        dlgMessageBoxExtended dlg = new dlgMessageBoxExtended("WakeOnLAN", $"Das Magic-Paket wurde an {macAddress} gesendet.", 3);
                        dlg.ShowDialog();
                    }
                }
            }
        }

        protected override void OnItemMouseHover(ListViewItemMouseHoverEventArgs e)
        {
            if (e.Item == null)
                return;

            Stations station = (Stations)e.Item.Tag;
            if (station != null)
            {
                bool wakeOnLan = station.EnableWol.GetValueOrDefault() && !string.IsNullOrWhiteSpace(station.MacAddress);
                if (e.Item.ImageIndex == 0 && wakeOnLan)
                    e.Item.ToolTipText = "Rechte Maustaste = WakeOnLAN";
            }
        }
    }
}
