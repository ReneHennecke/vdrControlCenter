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

    public partial class RecordingsView : UserControl
    {
        private SvdrpController _controller;
        private vdrControlCenterContext _context;
        private ImageList _imageList;

        public bool RequestEnable
        {
            get { return btnRequest.Enabled; }
            set { 
                    btnNew.Enabled = btnDel.Enabled = btnRequest.Enabled = value;  // btnNew => btnCut
                }
        }

        public RecordingsView()
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
            _imageList = Globals.LoadImageList(Enums.ImageListType.RecordingsView);

            dgvRecordings.AutoGenerateColumns = false;
            dgvRecordings.RowTemplate.Height = 25;
            dgvRecordings.AllowUserToResizeRows = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.SteelBlue,
                ForeColor = Color.WhiteSmoke,
                SelectionBackColor = Color.LightSteelBlue,
                SelectionForeColor = Color.WhiteSmoke,
                Font = new Font("Calibri", 8.0f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvRecordings.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightGray,
                SelectionForeColor = Color.Black,
                Font = new Font("Segoe UI", 8.0f, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dgvRecordings.RowsDefaultCellStyle = cellStyle;

            DataGridViewCellStyle cellCenterStyle = new DataGridViewCellStyle(cellStyle);
            cellCenterStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "·";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
            imageColumn.Name = "DisplayCut";
            imageColumn.Width = 30;
            imageColumn.DisplayIndex = 0;
            dgvRecordings.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Ordner";
            textColumn.DataPropertyName = "RecordingPath";
            textColumn.Name = "RecordingPath";
            textColumn.Width = 80;
            textColumn.DisplayIndex = 1;
            dgvRecordings.Columns.Add(textColumn);


            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Titel";
            textColumn.DataPropertyName = "Title";
            textColumn.Name = "Title";
            textColumn.Width = 350;
            textColumn.DisplayIndex = 2;
            dgvRecordings.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Aufnahme am";
            textColumn.DataPropertyName = "RecordingTime";
            textColumn.Name = "RecordingTime";
            textColumn.Width = 120;
            textColumn.DisplayIndex = 3;
            dgvRecordings.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Dauer";
            textColumn.DataPropertyName = "Duration";
            textColumn.Name = "Duration";
            textColumn.Width = 70;
            textColumn.DisplayIndex = 4;
            dgvRecordings.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "RecId";
            textColumn.Name = "RecId";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 5;
            textColumn.Visible = false;
            dgvRecordings.Columns.Add(textColumn);


            btnNew.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.FindPng}");
            btnDel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.TimerPng}");
            btnRequest.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.RequestPng}");

            _context = new vdrControlCenterContext();
        }

        public void LoadData(SvdrpController controller)
        {
            _controller = controller;

            ReLoad();

            btnRequest.Enabled = btnDel.Enabled = false;
        }

        public async void RefreshData(SvdrpRecordingList recordingList)
        {
            bool reload = false;
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    await context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [Recordings];");

                    await context.Recordings.AddRangeAsync(recordingList.Recordings);
                    await context.SaveChangesAsync();

                    SystemSettings settings = context.SystemSettings.FirstOrDefault(e => e.MachineName == Environment.MachineName);
                    if (settings != null)
                    {
                        settings.LastUpdateRecordings = DateTime.Now;
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
            _controller.SendGetRecordingsRequest();
        }

        private void ReLoad()
        {
            dgvRecordings.DataSource = null;
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                SystemSettings systemSettings = context.SystemSettings.FirstOrDefault(e => e.MachineName == Environment.MachineName);
                if (systemSettings != null)
                    lblRequestInfo.Text = $"{systemSettings.LastUpdateRecordings:dd.MM.yyyy HH:mm:ss}";

                dgvRecordings.DataSource = context.Recordings.OrderBy(e => e.RecordingPath)
                                                             .ThenBy(e => e.Title)
                                                             .ToList();
            }
        }

        private void dgvChannels_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == dgvRecordings.Columns["DisplayCut"].Index)
                {
                    string title = (string)dgvRecordings.Rows[e.RowIndex].Cells["Title"].Value;
                    SolidBrush gridBrush = new SolidBrush(dgvRecordings.GridColor);
                    Pen gridLinePen = new Pen(gridBrush);
                    SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    // Draw lines over cell  
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    // Draw the image over cell at specific location.  
                    Point point = new Point(e.CellBounds.X + 7, e.CellBounds.Y + 3);
                    e.Graphics.DrawImage(title.StartsWith("%") ? _imageList.Images[1] : _imageList.Images[0], point);
                    dgvRecordings.Rows[e.RowIndex].Cells["DisplayCut"].ReadOnly = true; // make cell readonly so below text will not dispaly on double click over cell.  

                    e.Handled = true;
                }
            }
        }

        private void dgvRecordings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (e.ColumnIndex == dgvRecordings.Columns["Duration"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (e.ColumnIndex == dgvRecordings.Columns["RecordingTime"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
