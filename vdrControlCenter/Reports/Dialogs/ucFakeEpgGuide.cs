namespace vdrControlCenterUI.Reports.Dialogs
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Reporting.WinForms;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class ucFakeEpgGuide : UserControl
    {
        private vdrControlCenterContext _context;

        public ucFakeEpgGuide()
        {
            InitializeComponent();
        }

        public void PostInit(vdrControlCenterContext context)
        {
            _context = context;
            DateTime max = _context.Epg.Max(x => x.StartTime).GetValueOrDefault();

            dtpEnde.Value = dtpStart.Value.CompareTo(max) <= 0 ? max.AddDays(-1) : dtpStart.Value.AddDays(1);
        }

        public ReportParameter[] RetrieveParameters()
        {
            ReportParameter[] reportParameters = null;

            reportParameters = new ReportParameter[]
            {
                new ReportParameter("Start", $"{dtpStart.Value:dd.MM.yyyy} 00:00:00.000"),
                new ReportParameter("Ende", $"{dtpEnde.Value:dd.MM.yyyy} 23:59:59.999"),
                new ReportParameter("HideShortDescription", $"{chbHideShortDescription.Checked}"),
                new ReportParameter("HideDescription", $"{chbHideDescription.Checked}"),
                new ReportParameter("ChannelLogoPath", Globals.ChannelLogoPath(_context))
            };
            
            return reportParameters;
        }

        public ReportDataSource RetrieveReportDataSource()
        {
            ReportDataSource reportDataSource = null;

            if (_context != null)
            {
                DateTime start = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0, 0);
                DateTime ende = dtpEnde.Value.AddDays(1); // Bei SQL-Abfrage ist der Zeitstempel vom Vortag bis 23:59:59.999
                ende = new DateTime(ende.Year, ende.Month, ende.Day, 0, 0, 0, 0);

                var channelLogoPath = Globals.ChannelLogoPath(_context);
                var data = _context.GetFakeEpgGuide(start, ende, chbFavouritesOnly.Checked);
                data.ForEach(d =>
                {
                    if (d.RowCounter == 1)
                    {
                        d.ChannelImage_1 = false;
                        d.ChannelImage_2 = false;
                        d.ChannelImage_3 = false;
                        d.ChannelImage_4 = false;
                        d.ChannelImage_5 = false;
                        d.ChannelImage_6 = false;
                        d.ChannelImage_7 = false;

                        if (!string.IsNullOrWhiteSpace(d.ChannelName_1))
                            d.ChannelImage_1 = System.IO.File.Exists($"{channelLogoPath}{d.ChannelName_1}.png");
                        if (!string.IsNullOrWhiteSpace(d.ChannelName_2))
                            d.ChannelImage_2 = System.IO.File.Exists($"{channelLogoPath}{d.ChannelName_2}.png");
                        if (!string.IsNullOrWhiteSpace(d.ChannelName_3))
                            d.ChannelImage_3 = System.IO.File.Exists($"{channelLogoPath}{d.ChannelName_3}.png");
                        if (!string.IsNullOrWhiteSpace(d.ChannelName_4))
                            d.ChannelImage_4 = System.IO.File.Exists($"{channelLogoPath}{d.ChannelName_4}.png");
                        if (!string.IsNullOrWhiteSpace(d.ChannelName_5))
                            d.ChannelImage_5 = System.IO.File.Exists($"{channelLogoPath}{d.ChannelName_5}.png");
                        if (!string.IsNullOrWhiteSpace(d.ChannelName_6))
                            d.ChannelImage_6 = System.IO.File.Exists($"{channelLogoPath}{d.ChannelName_6}.png");
                        if (!string.IsNullOrWhiteSpace(d.ChannelName_7))
                            d.ChannelImage_7 = System.IO.File.Exists($"{channelLogoPath}{d.ChannelName_7}.png");
                    }
                });

                reportDataSource = new ReportDataSource()
                {
                    Name = "FakeEpgGuideDS",
                	Value = data
                };
            }

            return reportDataSource;
        }

        public int Days
        {
            get => (dtpEnde.Value - dtpStart.Value).Days + 1;
        }

        private void dtpStart_ValueChanged(object sender, System.EventArgs e)
        {
            CheckDateValues();        }

        private void dtpEnde_ValueChanged(object sender, System.EventArgs e)
        {
            CheckDateValues();
        }

        private void CheckDateValues()
        {
            if (dtpStart.Value.CompareTo(dtpEnde.Value) > 0)
                dtpEnde.Value = dtpStart.Value;
        }
    }
}
