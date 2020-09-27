namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Dialogs;

    public partial class EPGListView : UserControl
    {
        private SvdrpController _controller;
        private vdrControlCenterContext _context;

        public bool RequestEnable
        {
            get { return btnRequest.Enabled; }
            set { btnRequest.Enabled = value; }
        }

        public EPGListView()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {
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
            imageColumn.Name = "ImageComputed";
            imageColumn.Width = 30;
            imageColumn.DisplayIndex = 0;
            dgvEPG.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Kanal";
            textColumn.DataPropertyName = "ChannelNameComputed";
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
            textColumn.DataPropertyName = "EndTimeComputed";
            textColumn.Name = "EndTimeComputed";
            textColumn.Width = 120;
            textColumn.DisplayIndex = 3;
            dgvEPG.Columns.Add(textColumn);

            textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Dauer";
            textColumn.DataPropertyName = "DurationComputed";
            textColumn.Name = "DurationComputed";
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
            textColumn.HeaderText = "RecId";
            textColumn.DataPropertyName = "RecId";
            textColumn.Width = 100;
            textColumn.DisplayIndex = 7;
            textColumn.Visible = false;
            dgvEPG.Columns.Add(textColumn);

            btnFind.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.FindPng}");
            btnTimer.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.TimerPng}");
            btnRequest.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.RequestPng}");
        }

        public void LoadData(SvdrpController controller, vdrControlCenterContext context)
        {
            _controller = controller;
            _context = context;

            ReLoad();

            btnRequest.Enabled = false;
        }

        public async void RefreshEPGList(SvdrpEPGList epgList)
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

            if (e.ColumnIndex == dgvEPG.Columns["ChannelName"].Index)
            {

            }
            else if (e.ColumnIndex == dgvEPG.Columns["DurationComputed"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (e.ColumnIndex == dgvEPG.Columns["StartTime"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (e.ColumnIndex == dgvEPG.Columns["EndTimeComputed"].Index)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ReLoad()
        {
            dgvEPG.DataSource = null;
            dgvEPG.DataSource = _context.Epg
                                    .Where(e => DateTime.Compare(e.StartTime.Value, DateTime.Now) >= 0)
                                    .OrderBy(e => e.StartTime)
                                    .ToList();
        }
    }
}
