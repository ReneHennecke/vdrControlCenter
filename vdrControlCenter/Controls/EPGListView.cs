﻿namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Dialogs;

    public partial class EPGListView : UserControl
    {
        private SvdrpController _controller;
        private vdrControlCenterContext _context;
        private ImageList _imageList;

        public bool RequestEnable
        {
            get { return btnRequest.Enabled; }
            set { btnRequest.Enabled = value; }
        }

        public EPGListView()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            _imageList = Globals.LoadImageList(Enums.ImageListType.EPGListView);


            dgvEPG.AutoGenerateColumns = false;
            dgvEPG.RowTemplate.Height = 25;
            dgvEPG.AllowUserToResizeRows = false;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.SteelBlue,
                ForeColor = Color.WhiteSmoke,
                SelectionBackColor = Color.LightSteelBlue,
                SelectionForeColor = Color.WhiteSmoke,
                Font = new Font("Calibri", 8.0f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvEPG.ColumnHeadersDefaultCellStyle = headerStyle;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.WhiteSmoke,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightGray,
                SelectionForeColor = Color.Black,
                Font = new Font("Segoe UI", 8.0f, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dgvEPG.RowsDefaultCellStyle = cellStyle;

            DataGridViewCellStyle cellCenterStyle = new DataGridViewCellStyle(cellStyle);
            cellCenterStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "·";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Normal;
            imageColumn.Name = "DisplaySymbol";
            imageColumn.Width = 30;
            imageColumn.DisplayIndex = 0;
            imageColumn.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.EmptyPng}");
            dgvEPG.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Kanal";
            textColumn.DataPropertyName = "ChannelName";
            textColumn.Name = "ChannelName";
            textColumn.Width = 150;
            textColumn.DisplayIndex = 1;
            
            dgvEPG.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Start";
            textColumn.DataPropertyName = "StartTime";
            textColumn.Name = "StartTime";
            textColumn.Width = 120;
            textColumn.DisplayIndex = 2;
            dgvEPG.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Ende";
            textColumn.DataPropertyName = "EndTime";
            textColumn.Name = "EndTime";
            textColumn.Width = 120;
            textColumn.DisplayIndex = 3;
            dgvEPG.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Dauer";
            textColumn.DataPropertyName = "DurationMinutes";
            textColumn.Name = "DurationMinutes";
            textColumn.Width = 70;
            textColumn.DisplayIndex = 4;
            dgvEPG.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Titel";
            textColumn.DataPropertyName = "Title";
            textColumn.Name = "Title";
            textColumn.Width = 250;
            textColumn.DisplayIndex = 5;
            dgvEPG.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Kurzbeschreibung";
            textColumn.DataPropertyName = "ShortDescription";
            textColumn.Name = "ShortDescription";
            textColumn.Width = 300;
            textColumn.DisplayIndex = 6;
            dgvEPG.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "RecId";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 7;
            textColumn.Visible = false;
            dgvEPG.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "SymbolIndex";
            textColumn.Name = "SymbolIndex";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 8;
            textColumn.Visible = false;
            dgvEPG.Columns.Add(textColumn);

            btnFind.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.FindPng}");
            btnTimer.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.TimerPng}");
            btnRequest.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.RequestPng}");
        }

        public void LoadData(SvdrpController controller, vdrControlCenterContext con)
        {
            _controller = controller;
            _context = con;

            ReLoad();

            btnRequest.Enabled = false;
        }

        public async void RefreshData(SvdrpEPGList epgList)
        {
            bool reload = false;
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // EPG-Liste von zukünftigen Einträgen bereinigen
                    _context.RemoveRange(_context.Epg.Where(e => e.StartTime.Value.CompareTo(DateTime.Now) >= 0));
                    await _context.SaveChangesAsync();

                    _context.Epg.AddRange(epgList.EPGList);
                    await _context.SaveChangesAsync();

                    SystemSettings settings = _context.SystemSettings.FirstOrDefault(e => e.MachineName == Environment.MachineName);
                    if (settings != null)
                    {
                        settings.LastUpdateEpg = DateTime.Now;
                        _context.Entry(settings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        await _context.SaveChangesAsync();
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

        private void btnFind_Click(object sender, System.EventArgs e)
        {
            dlgFindEPG dlg = new dlgFindEPG();
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnTimer_Click(object sender, System.EventArgs e)
        {
            btnRequest.Enabled = false;
        }

        private void btnRequest_Click(object sender, System.EventArgs e)
        {
            _controller.SendEPGRequest();
        }

        private void dgvEPG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (e.ColumnIndex == dgvEPG.Columns["DurationMinutes"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (e.ColumnIndex == dgvEPG.Columns["StartTime"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (e.ColumnIndex == dgvEPG.Columns["EndTime"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ReLoad()
        {
            dgvEPG.DataSource = null;
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                dgvEPG.DataSource = context.GetFakeEpgs(DateTime.Now, 0, false);
            }
        }

        private void dgvEPG_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dgvEPG.Columns["DisplaySymbol"].Index)
            {

                int i = (int)dgvEPG.Rows[e.RowIndex].Cells["SymbolIndex"].Value;
                if (i < 0 || i >= _imageList.Images.Count)
                    i = 0;

                Image cellImage = _imageList.Images[i];
                if (cellImage != null)
                {
                    SolidBrush gridBrush = new SolidBrush(dgvEPG.GridColor);
                    Pen gridLinePen = new Pen(gridBrush);
                    SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    // Draw lines over cell  
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    // Draw the image over cell at specific location.  
                    Point point = new Point(e.CellBounds.X + 7, e.CellBounds.Y + 3);
                    e.Graphics.DrawImage(cellImage, point);
                    dgvEPG.Rows[e.RowIndex].Cells["DisplaySymbol"].ReadOnly = true; // make cell readonly so below text will not dispaly on double click over cell.  
                }

                e.Handled = true;
            }
        }

    }
}
