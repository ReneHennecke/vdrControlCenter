namespace vdrControlCenterUI.Dialogs
{
    using DataLayer.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Reporting.WinForms;
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using vdrControlCenterUI.Enums;
    using vdrControlCenterUI.Reports.Dialogs;

    public partial class dlgReports : Form
    {
        private ReportType _reportType;
        private vdrControlCenterContext _context;

        private TabPage _previewPage;
        private bool _cancel;

        public bool Cancel
        {
            set => _cancel = value;
        }

        public dlgReports()
        {
            InitializeComponent();
        }

        public void PostInit(ReportType reportType, vdrControlCenterContext context)
        {
            _reportType = reportType;
            _context = context;

            // Voransicht erstmal verstecken
            _previewPage = pagePreview;
            tabReport.TabPages.Remove(_previewPage);

            switch (_reportType)
            {
                default:
                    break;
                case ReportType.EpgGuide:
                    Text += "«EPG-Guide»";
                    ucFakeEpgGuide ucFakeEpgGuide = new ucFakeEpgGuide();
                    ucFakeEpgGuide.PostInit(_context);
                    ucFakeEpgGuide.Location = new Point(4, 6);
                    pageParameters.Controls.Add(ucFakeEpgGuide);
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            const string PERCENT_COMPLETED = " PERCENT COMPLETED";

            var message = e.Message;
            if (!message.Contains(PERCENT_COMPLETED))
                return;

            message = message.Replace(PERCENT_COMPLETED, string.Empty);
            if (!int.TryParse(message, out int percent))
                return;

            if (lblProgress.InvokeRequired)
                lblProgress.Invoke((MethodInvoker)delegate
                {
                    lblProgress.Text = $"{message} %";
                });
            else
                lblProgress.Text = $"{message} %";


            if (pbProgress.InvokeRequired)
                pbProgress.Invoke((MethodInvoker)delegate
                {
                    pbProgress.Value = percent;
                });
            else
                pbProgress.Value = percent;
        }

        private void HandlePreview()
        {
            if (!tabReport.TabPages.Contains(_previewPage))
                tabReport.TabPages.Add(_previewPage);
            else
                rptViewer.ReportViewer.Clear();

            tabReport.SelectedTab = _previewPage;
        }

        public async void StartReporting()
        {
            switch (_reportType)
            {
                default:
                    break;
                case ReportType.EpgGuide:
                    {

                        HandlePreview();

                        ucFakeEpgGuide ucFakeEpgGuide = (ucFakeEpgGuide)Controls.OfType<ucFakeEpgGuide>().FirstOrDefault();
                        ucFakeEpgGuide.Enabler(false, true);

                        string channelLogoPath = string.Empty;
                        SystemSettings systemSettings = await _context.SystemSettings.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName);
                        if (systemSettings != null)
                        {
                            channelLogoPath = systemSettings.PathToChannelLogos;
                            if (!string.IsNullOrWhiteSpace(channelLogoPath) && !channelLogoPath.EndsWith("/"))
                                channelLogoPath += "/";
                        }

                        ReportParameter[] reportParameters = new ReportParameter[]
                        {
                            new ReportParameter("Start", $"{ucFakeEpgGuide.Start:dd.MM.yyyy} 00:00:00.000"),
                            new ReportParameter("Ende", $"{ucFakeEpgGuide.Ende:dd.MM.yyyy} 23:59:59.999"),
                            new ReportParameter("HideShortDescription", $"{ucFakeEpgGuide.HideShortDescription}"),
                            new ReportParameter("HideDescription", $"{ucFakeEpgGuide.HideDescription}"),
                            new ReportParameter("ChannelLogoPath", channelLogoPath)
                        };

                        ReportDataSource reportDataSource = null;
                        var connection = (SqlConnection)_context.Database.GetDbConnection();
                        if (connection != null)
                        {
                            connection.FireInfoMessageEventOnUserErrors = true;
                            connection.InfoMessage += Connection_InfoMessage;
                        }

                        _cancel = false;
                        lblProgress.Visible = true;
                        pbProgress.Visible = true;

                        var task = Task.Factory.StartNew(() =>
                        {
                            if (_context != null)
                            {
                                DateTime start = new DateTime(ucFakeEpgGuide.Start.Year, ucFakeEpgGuide.Start.Month, ucFakeEpgGuide.Start.Day, 0, 0, 0, 0);
                                DateTime ende = ucFakeEpgGuide.Ende.AddDays(1); // Bei SQL-Abfrage ist der Zeitstempel vom Vortag bis 23:59:59.999
                                ende = new DateTime(ende.Year, ende.Month, ende.Day, 0, 0, 0, 0);

                                var data = _context.GetFakeEpgGuide(start, ende, ucFakeEpgGuide.FavouritesOnly);
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
                                            d.ChannelImage_1 = System.IO.File.Exists($"{ucFakeEpgGuide.ChannelLogoPath}{d.ChannelName_1}.png");
                                        if (!string.IsNullOrWhiteSpace(d.ChannelName_2))
                                            d.ChannelImage_2 = System.IO.File.Exists($"{ucFakeEpgGuide.ChannelLogoPath}{d.ChannelName_2}.png");
                                        if (!string.IsNullOrWhiteSpace(d.ChannelName_3))
                                            d.ChannelImage_3 = System.IO.File.Exists($"{ucFakeEpgGuide.ChannelLogoPath}{d.ChannelName_3}.png");
                                        if (!string.IsNullOrWhiteSpace(d.ChannelName_4))
                                            d.ChannelImage_4 = System.IO.File.Exists($"{ucFakeEpgGuide.ChannelLogoPath}{d.ChannelName_4}.png");
                                        if (!string.IsNullOrWhiteSpace(d.ChannelName_5))
                                            d.ChannelImage_5 = System.IO.File.Exists($"{ucFakeEpgGuide.ChannelLogoPath}{d.ChannelName_5}.png");
                                        if (!string.IsNullOrWhiteSpace(d.ChannelName_6))
                                            d.ChannelImage_6 = System.IO.File.Exists($"{ucFakeEpgGuide.ChannelLogoPath}{d.ChannelName_6}.png");
                                        if (!string.IsNullOrWhiteSpace(d.ChannelName_7))
                                            d.ChannelImage_7 = System.IO.File.Exists($"{ucFakeEpgGuide.ChannelLogoPath}{d.ChannelName_7}.png");
                                    }
                                });

                                reportDataSource = new ReportDataSource()
                                {
                                    Name = "FakeEpgGuideDS",
                                    Value = data
                                };
                            }
                        });

                        await task.ContinueWith(resultTask =>
                        {
                            _cancel = false;
                            lblProgress.Visible = false;
                            pbProgress.Visible = false;
                        }, TaskScheduler.FromCurrentSynchronizationContext());

                        const int margin = 15;
                        PageSettings pageSettings = new PageSettings()
                        {
                            Landscape = true,
                            Margins = new Margins(margin, margin, margin, margin)
                        };

                        rptViewer.ReportViewer.SetPageSettings(pageSettings);
                        
                        rptViewer.ReportViewer.LocalReport.EnableExternalImages = true;
                        rptViewer.ReportViewer.LocalReport.ReportPath = $"{Environment.CurrentDirectory}\\Reports\\EpgGuide.rdlc";

                        rptViewer.ReportViewer.LocalReport.SetParameters(reportParameters);
                        rptViewer.ReportViewer.LocalReport.DataSources.Add(reportDataSource);

                        rptViewer.ReportViewer.RefreshReport();
                    }
                    break;
            }
        }

    }
}
