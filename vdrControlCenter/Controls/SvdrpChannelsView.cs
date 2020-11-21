namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Svg;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Dialogs;

    public partial class SvdrpChannelsView : UserControl
    {
        private SvdrpController _controller;
        private vdrControlCenterContext _context;
        private ImageList _imageListLeft;
        private ImageList _imageListRight;
        private Image _imageNoLogo;

        public bool RequestEnable
        {
            get { return btnRequest.Enabled; }
            set { 
                    btnNew.Enabled = btnDel.Enabled = btnRequest.Enabled = value;
                }
        }

        public SvdrpChannelsView()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            _imageListLeft = Globals.LoadImageList(vdrControlCenterUI.Enums.ImageListType.SvdrpChannelsViewLeft);
            _imageListRight = Globals.LoadImageList(vdrControlCenterUI.Enums.ImageListType.SvdrpChannelsViewRight);

            _imageNoLogo = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.ScvNoLogoPng}");

            dgvChannels.AutoGenerateColumns = false;
            dgvChannels.RowTemplate.Height = 32;
            dgvChannels.AllowUserToResizeRows = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.SteelBlue,
                ForeColor = Color.WhiteSmoke,
                SelectionBackColor = Color.LightSteelBlue,
                SelectionForeColor = Color.WhiteSmoke,
                Font = new Font("Calibri", 8.0f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvChannels.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightGray,
                SelectionForeColor = Color.Black,
                Font = new Font("Segoe UI", 8.0f, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dgvChannels.RowsDefaultCellStyle = cellStyle;

            DataGridViewCellStyle cellCenterStyle = new DataGridViewCellStyle(cellStyle);
            cellCenterStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "·";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
            imageColumn.Name = "DisplayType";
            imageColumn.Width = 30;
            imageColumn.DisplayIndex = 0;
            dgvChannels.Columns.Add(imageColumn);

            imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "·";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
            imageColumn.Name = "DisplayFavourite";
            imageColumn.Width = 34;
            imageColumn.DisplayIndex = 1;
            dgvChannels.Columns.Add(imageColumn);

            imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "·";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
            imageColumn.Name = "DisplayLogo";
            imageColumn.Width = 40;
            imageColumn.DisplayIndex = 2;
            imageColumn.Image = _imageNoLogo;
            dgvChannels.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Kanal";
            textColumn.DataPropertyName = "ChannelName";
            textColumn.Name = "ChannelName";
            textColumn.Width = 350;
            textColumn.DisplayIndex = 3;
            dgvChannels.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "RecId";
            textColumn.Name = "RecId";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 4;
            textColumn.Visible = false;
            dgvChannels.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "VPID";
            textColumn.Name = "VPID";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 5;
            textColumn.Visible = false;
            dgvChannels.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "Favourite";
            textColumn.Name = "Favourite";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 6;
            textColumn.Visible = false;
            dgvChannels.Columns.Add(textColumn);

            btnNew.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.ScvNewPng}");
            btnDel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.ScvDelPng}");
            btnRequest.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.ScvRequestPng}");
        }

        public void LoadData(SvdrpController controller)
        {
            _controller = controller;

            if (_context == null)
                _context = new vdrControlCenterContext();

            ReLoad();

            btnNew.Enabled = btnDel.Enabled = btnRequest.Enabled = false;
        }

        public async void RefreshData(SvdrpChannelList channelList)
        {
            bool reload = false;
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    List<Channels> existingChannels = await _context.Channels.ToListAsync();

                    foreach (Channels channel in channelList.Channels)
                    {
                        bool found = false;
                        Channels entry = existingChannels.Find(delegate(Channels f)
                        {
                            return f.ChannelId == channel.ChannelId;
                        });

                        found = (entry != null);
                        if (!found)
                            entry = new Channels();

                        entry.Apid = channel.Apid;
                        entry.Caid = channel.Caid;
                        entry.ChannelId = channel.ChannelId;
                        entry.ChannelName = channel.ChannelName;
                        entry.Favourite = channel.Favourite;
                        entry.Frequency = channel.Frequency;
                        entry.Nid = channel.Nid;
                        entry.Number = channel.Number;
                        entry.Parameter = channel.Parameter;
                        entry.Params = channel.Params;
                        entry.ProviderName = channel.ProviderName;
                        entry.Sid = channel.Sid;
                        entry.SignalSource = channel.SignalSource;
                        entry.SymbolRate = channel.SymbolRate;
                        entry.Rid = channel.Rid;
                        entry.Tid = channel.Tid;
                        entry.Tpid = channel.Tpid;
                        entry.Vpid = channel.Vpid;

                        if (!found)
                            _context.Channels.Add(entry);
                        else
                            _context.Entry(existingChannels).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                    SystemSettings settings = _context.SystemSettings.FirstOrDefault(e => e.MachineName == Environment.MachineName);
                    if (settings != null)
                    {
                        settings.LastUpdateChannels = DateTime.Now;
                        _context.Entry(settings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    reload = true;
                }
                catch 
                {
                    await transaction.RollbackAsync();
                }
            }

            if (reload)
                ReLoad();

        }

        private void btnRequest_Click(object sender, System.EventArgs e)
        {
            _controller.SendGetChannelListRequest();
        }

        private async void ReLoad()
        {
            dgvChannels.DataSource = null;
            
            SystemSettings systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(e => e.MachineName == Environment.MachineName);
            if (systemSettings != null)
            {
                lblRequestInfo.Text = $"{systemSettings.LastUpdateChannels:dd.MM.yyyy HH:mm:ss}";

                dgvChannels.DataSource = await _context.Channels.OrderBy(e => e.ChannelName).ToListAsync();
            }
        }

        private void dgvChannels_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex >= 0 && e.ColumnIndex < 3)
                {
                    SolidBrush gridBrush = new SolidBrush(dgvChannels.GridColor);
                    Pen gridLinePen = new Pen(gridBrush);
                    SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);

                    // Fill rectangle
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    // Draw lines over cell  
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    // Draw the image over cell at specific location.                      
                    Point point = new Point(e.CellBounds.X + 7, e.CellBounds.Y + 3);

                    if (e.ColumnIndex == dgvChannels.Columns["DisplayType"].Index)
                    {
                        string vpid = (string)dgvChannels.Rows[e.RowIndex].Cells["VPID"].Value;

                        e.Graphics.DrawImage(vpid == "0" ? _imageListLeft.Images[0] : _imageListLeft.Images[1], point);
                    }
                    else if (e.ColumnIndex == dgvChannels.Columns["DisplayFavourite"].Index)
                    {
                        bool favourite = (bool)dgvChannels.Rows[e.RowIndex].Cells["Favourite"].Value;

                        e.Graphics.DrawImage(favourite ? _imageListRight.Images[1] : _imageListRight.Images[0], point);
                    }
                    else if (e.ColumnIndex == dgvChannels.Columns["DisplayLogo"].Index)
                    {
                        string name = (string)dgvChannels.Rows[e.RowIndex].Cells["ChannelName"].Value;
                        string svg = $"{Globals.LogoFolder}{name}.svg";
                        if (File.Exists(svg))
                        {
                            SvgDocument svgDocument = SvgDocument.Open(svg);
                            if (svg != null)
                            {
                                Bitmap img = svgDocument.Draw(20, 15);
                                if (img != null)
                                    e.Graphics.DrawImage(img, point);
                            }
                        }
                    }
                    dgvChannels.Rows[e.RowIndex].Cells["DisplayFavourite"].ReadOnly = true; // make cell readonly so below text will not dispaly on double click over cell.  

                    e.Handled = true;
                }
            }
        }

        private void dgvChannels_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
        }
    }
}
