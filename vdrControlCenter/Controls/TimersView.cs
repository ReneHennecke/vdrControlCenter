﻿namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class TimersView : UserControl
    {
        private SvdrpController _controller;
        private vdrControlCenterContext _context;
        private ImageList _imageList;

        public bool RequestEnable
        {
            get { return btnRequest.Enabled; }
            set { 
                    btnNew.Enabled = btnDel.Enabled = btnRequest.Enabled = value;
                }
        }

        public TimersView()
        {
            InitializeComponent();

            Disposed += OnDispose;

            if (!DesignMode)
                PostInit();
        }

        private void OnDispose(object sender, EventArgs e)
        {
            _context?.DisposeAsync();
        }

        private void PostInit()
        {
            _imageList = Globals.LoadImageList(Enums.ImageListType.EPGListView);

            dgvTimers.AutoGenerateColumns = false;
            dgvTimers.RowTemplate.Height = 25;
            dgvTimers.AllowUserToResizeRows = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.SteelBlue,
                ForeColor = Color.WhiteSmoke,
                SelectionBackColor = Color.LightSteelBlue,
                SelectionForeColor = Color.WhiteSmoke,
                Font = new Font("Calibri", 8.0f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvTimers.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightGray,
                SelectionForeColor = Color.Black,
                Font = new Font("Segoe UI", 8.0f, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dgvTimers.RowsDefaultCellStyle = cellStyle;

            DataGridViewCellStyle cellCenterStyle = new DataGridViewCellStyle(cellStyle);
            cellCenterStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "·";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
            imageColumn.Name = "DisplayActive";
            imageColumn.Width = 30;
            imageColumn.DisplayIndex = 0;
            dgvTimers.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Kanal";
            textColumn.DataPropertyName = "ChannelName";
            textColumn.Name = "ChannelName";
            textColumn.Width = 150;
            textColumn.DisplayIndex = 1;
            dgvTimers.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Titel";
            textColumn.DataPropertyName = "Title";
            textColumn.Name = "Title";
            textColumn.Width = 250;
            textColumn.DisplayIndex = 2;
            dgvTimers.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Start";
            textColumn.DataPropertyName = "StartTime";
            textColumn.Name = "StartTime";
            textColumn.Width = 120;
            textColumn.DisplayIndex = 3;
            dgvTimers.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Ende";
            textColumn.DataPropertyName = "EndTime";
            textColumn.Name = "EndTime";
            textColumn.Width = 120;
            textColumn.DisplayIndex = 4;
            dgvTimers.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Dauer";
            textColumn.DataPropertyName = "Duration";
            textColumn.Name = "Duration";
            textColumn.Width = 70;
            textColumn.DisplayIndex = 5;
            dgvTimers.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "RecId";
            textColumn.Name = "RecId";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 6;
            textColumn.Visible = false;
            dgvTimers.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "Active";
            textColumn.Name = "Active";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 7;
            textColumn.Visible = false;
            dgvTimers.Columns.Add(textColumn);

            btnNew.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.FindPng}");
            btnDel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.TimerPng}");
            btnRequest.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.RequestPng}");

            _context = new vdrControlCenterContext();
        }

        public void LoadData(SvdrpController controller)
        {
            _controller = controller;

            ReLoad();

            btnNew.Enabled = btnDel.Enabled = btnRequest.Enabled = false;
        }

        public async void RefreshData(SvdrpTimerList timerList)
        {
            bool reload = false;
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    await context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [Timers];");

                    await context.Timers.AddRangeAsync(timerList.Timers);
                    await context.SaveChangesAsync();

                    SystemSettings settings = _context.SystemSettings.FirstOrDefault(e => e.MachineName == Environment.MachineName);
                    if (settings != null)
                    {
                        settings.LastUpdateTimers = DateTime.Now;
                        context.Entry(settings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        await context.SaveChangesAsync();
                    }

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
//            _controller.SendEPGRequest();
        }

        private void ReLoad()
        {
            dgvTimers.DataSource = null;
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                SystemSettings systemSettings = context.SystemSettings.FirstOrDefault(e => e.MachineName == Environment.MachineName);
                if (systemSettings != null)
                    lblRequestInfo.Text = $"{systemSettings.LastUpdateTimers:dd.MM.yyyy HH:mm:ss}";


                dgvTimers.DataSource = context.Timers.OrderBy(e => e.StartTime).ToList();
            }
        }

        private void dgvChannels_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            { 
                if (e.ColumnIndex == dgvTimers.Columns["DisplayActive"].Index)
                {
                    bool active = (bool)dgvTimers.Rows[e.RowIndex].Cells["Active"].Value;
                    SolidBrush gridBrush = new SolidBrush(dgvTimers.GridColor);
                    Pen gridLinePen = new Pen(gridBrush);
                    SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    // Draw lines over cell  
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    // Draw the image over cell at specific location.  
                    Point point = new Point(e.CellBounds.X + 7, e.CellBounds.Y + 3);
                    e.Graphics.DrawImage(active ? _imageList.Images[1] : _imageList.Images[0], point);
                    dgvTimers.Rows[e.RowIndex].Cells["DisplaySymbol"].ReadOnly = true; // make cell readonly so below text will not dispaly on double click over cell.  
                }

                e.Handled = true;
            }
        }

        private void dgvTimers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (e.ColumnIndex == dgvTimers.Columns["Duration"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (e.ColumnIndex == dgvTimers.Columns["StartTime"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (e.ColumnIndex == dgvTimers.Columns["EndTime"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
