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
    using vdrControlCenterUI.Enums;

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
                    List<Channels> removeChannels = new List<Channels>();
                    foreach (var c in _context.Channels)
                    {
                        if (!channelList.Channels.Exists(x => x.ChannelId == c.ChannelId))
                            removeChannels.Add(c);
                    }

                    _context.Channels.RemoveRange(removeChannels);

                    foreach (Channels channel in channelList.Channels)
                    {
                        
                        Channels channelEntry = existingChannels.Find(delegate(Channels f)
                        {
                            return f.ChannelId == channel.ChannelId;
                        });

                        bool found = (channelEntry != null);
                        if (!found)
                            channelEntry = new Channels();

                        channelEntry.Apid = channel.Apid;
                        channelEntry.Caid = channel.Caid;
                        channelEntry.ChannelId = channel.ChannelId;
                        channelEntry.ChannelName = channel.ChannelName;
                        channelEntry.Favourite = found ? channel.Favourite : false;
                        channelEntry.Frequency = channel.Frequency;
                        channelEntry.Nid = channel.Nid;
                        channelEntry.Number = channel.Number;
                        channelEntry.Parameter = channel.Parameter;
                        channelEntry.Params = channel.Params;
                        channelEntry.ProviderName = channel.ProviderName;
                        channelEntry.Sid = channel.Sid;
                        channelEntry.SignalSource = channel.SignalSource;
                        channelEntry.SymbolRate = channel.SymbolRate;
                        channelEntry.Rid = channel.Rid;
                        channelEntry.Tid = channel.Tid;
                        channelEntry.Tpid = channel.Tpid;
                        channelEntry.Vpid = channel.Vpid;

                        if (!found)
                            _context.Channels.Add(channelEntry);
                        else
                        {
                            _context.Channels.Attach(channelEntry);
                            _context.Entry(channelEntry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        }
                    }

                    SystemSettings systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(e => e.MachineName == Environment.MachineName);
                    if (systemSettings != null)
                    {
                        systemSettings.LastUpdateChannels = DateTime.Now;
                        _context.Entry(systemSettings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    reload = true;
                }
                catch //(Exception ex)
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

                List<Channels> channelList = await _context.Channels.OrderBy(e => e.ChannelName).ToListAsync();

                if (systemSettings.ChannelListType == (short)ChannelType.TV)
                    channelList = channelList.Where(x => x.Vpid.Contains("=")).ToList();
                else if (systemSettings.ChannelListType == (short)ChannelType.Radio)
                    channelList = channelList.Where(x => !x.Vpid.Contains("=")).ToList();

                dgvChannels.DataSource = channelList;
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
                            try
                            {
                                SvgDocument svgDocument = SvgDocument.Open(svg);
                                if (svg != null)
                                {
                                    Bitmap img = svgDocument.Draw(20, 15);
                                    if (img != null)
                                        e.Graphics.DrawImage(img, point);
                                }
                            }
                            catch
                            {

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

        private async void dgvChannels_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.ColumnIndex;
            int y = dgvChannels.Columns["DisplayFavourite"].Index;

            if (e.RowIndex > -1 && e.ColumnIndex == dgvChannels.Columns["DisplayFavourite"].Index)
            {
                long recId = (long)dgvChannels.Rows[e.RowIndex].Cells["RecId"].Value;
                Channels channels = await _context.Channels.FirstOrDefaultAsync(x => x.RecId == recId);
                if (channels != null)
                {
                    bool b = !(bool)dgvChannels.Rows[e.RowIndex].Cells["Favourite"].Value;
                    using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            dgvChannels.Rows[e.RowIndex].Cells["Favourite"].Value = b;

                            channels.Favourite = b;
                            _context.Channels.Attach(channels);
                            _context.Entry(channels).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                        }
                        catch //(Exception ex)
                        {
                            await transaction.RollbackAsync();
                        }
                    }
                }
            }
        }
    }
}
