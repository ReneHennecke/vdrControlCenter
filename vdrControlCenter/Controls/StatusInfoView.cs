﻿namespace vdrControlCenterUI.Controls
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class StatusInfoView : UserControl
    {
        private SvdrpController _controller;
        private vdrControlCenterContext _context;
        private int _width;

        public bool RequestEnable
        {
            get { return btnRequest.Enabled; }
            set { btnRequest.Enabled = value; }
        }

        public StatusInfoView()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        public void LoadData(SvdrpController controller, vdrControlCenterContext con)
        {
            _controller = controller;
            _context = con;

            ReLoad();

            btnRequest.Enabled = false;
        }

        public async void RefreshData(SvdrpStatusInfo svdrpStatusInfo)
        {
            bool reload = false;
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    SystemSettings systemSettings = _context.SystemSettings.FirstOrDefault(e => e.MachineName == Environment.MachineName);
                    if (systemSettings != null)
                    {
                        StatusInfo statusInfo = _context.StatusInfo.FirstOrDefault(e => e.SystemSettingsRecId == systemSettings.RecId);
                        if (statusInfo != null)
                        {
                            statusInfo.TotalDiskSpace = svdrpStatusInfo.Total;
                            statusInfo.FreeDiskSpace = svdrpStatusInfo.Free;
                            statusInfo.UsedPercent = svdrpStatusInfo.Percent;
                            _context.Entry(statusInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                            await _context.SaveChangesAsync();

                            systemSettings.LastUpdateStatus = DateTime.Now;
                            _context.Entry(systemSettings).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                            await _context.SaveChangesAsync();

                            await transaction.CommitAsync();

                            reload = true;
                        }
                    }
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }

            if (reload)
                ReLoad();
        }

        private void PostInit()
        {
            _width = lblRed.Width;
            Reset();
            btnRequest.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.RequestPng}");
        }

        private void btnRequest_Click(object sender, System.EventArgs e)
        {
            _controller.SendStatusInfoRequest();
        }

        private void Reset()
        {
            lblGreen.Visible = false;
            lblGreen.Width = _width;
            lblRed.Visible = false;
            lblRed.Width = _width;
        }

        private void ReLoad()
        {
            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                SystemSettings systemSettings = context.SystemSettings.FirstOrDefault(e => e.MachineName == Environment.MachineName);
                if (systemSettings != null)
                {
                    StatusInfo statusInfo = context.StatusInfo.FirstOrDefault(e => e.SystemSettingsRecId == systemSettings.RecId);
                    if (systemSettings.LastUpdateStatus.HasValue &&
                        statusInfo.TotalDiskSpace.HasValue &&
                        statusInfo.FreeDiskSpace.HasValue &&
                        statusInfo.UsedPercent.HasValue)
                    {
                        lblGreen.Visible = true;
                        lblRed.Visible = true;

                        lblTotalValue.Text = $"{statusInfo.TotalDiskSpace / 1024:0,0} GB";
                        lblFreeValue.Text = $"{statusInfo.FreeDiskSpace / 1024:0,0} GB";
                        lblPercentValue.Text = $"{statusInfo.UsedPercent:0.0} %";

                        int maxLength = lblPercentValue.Size.Width;
                        int height = lblRed.Size.Height;
                        int calcRed = (int)(maxLength * statusInfo.UsedPercent / 100);

                        lblRed.Size = new Size(calcRed - 1, height);
                        lblGreen.Location = new Point(lblGreen.Location.X + calcRed + 1, lblGreen.Location.Y);
                        lblGreen.Size = new Size(maxLength - calcRed - 2, height);
                    }
                }
            }
        }
    }
}
