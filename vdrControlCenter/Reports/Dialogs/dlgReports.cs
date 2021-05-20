namespace vdrControlCenterUI.Dialogs
{
    using DataLayer.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Reporting.WinForms;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Enums;
    using vdrControlCenterUI.Reports.Dialogs;

    public partial class dlgReports : Form
    {
        private ReportType _reportType;
        private vdrControlCenterContext _context;
        private ReportParameter[] _reportParameters;
        private ReportDataSource _reportDataSource;

        private int _max;
        private int _counter;

        public ReportParameter[] ReportParameters
        {
            get => _reportParameters;
        }

        public ReportDataSource ReportDataSource
        {
            get => _reportDataSource;
        }

        public dlgReports()
        {
            InitializeComponent();
        }

        public void PostInit(ReportType reportType)
        {
            _reportType = reportType;
            _context = new vdrControlCenterContext();

            switch (_reportType)
            {
                default:
                    break;
                case ReportType.EpgGuide:
                    Text += "«EPG-Guide»";
                    ucFakeEpgGuide ucFakeEpgGuide = new ucFakeEpgGuide();
                    ucFakeEpgGuide.PostInit(_context);
                    ucFakeEpgGuide.Location = new Point(4, 6);
                    Controls.Add(ucFakeEpgGuide);
                    Size = new Size(Size.Width, ucFakeEpgGuide.Size.Height + 90);
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (_reportType)
            {
                default:
                    break;
                case ReportType.EpgGuide:
                    {
                        panState.Visible = true;

                        var connection = (SqlConnection)_context.Database.GetDbConnection(); 
                        if (connection != null)
                            connection.InfoMessage += FakeEpgGuideInfoMessage;

                        ucFakeEpgGuide ucFakeEpgGuide = (ucFakeEpgGuide)Controls.OfType<ucFakeEpgGuide>().FirstOrDefault();
                        Cursor = Cursors.WaitCursor;

                        _max = ucFakeEpgGuide.Days;
                        _counter = 0;

                        _reportParameters = ucFakeEpgGuide.RetrieveParameters();
                        _reportDataSource = ucFakeEpgGuide.RetrieveReportDataSource();
                        Cursor = Cursors.Default;

                        //panState.Visible = false;
                    }
                    break;
            }

            //DialogResult = DialogResult.OK;
            //Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            Close();
        }

        public void FakeEpgGuideInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            _counter++;
            decimal percent = Math.Round((decimal)(_counter / _max * 100), 2);
            lblPercent.Text = $"{percent}%";
            pbProgress.Value = _counter / _max * 100;
            lblMessage.Text = e.Message;
        }

        private async void dlgReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _context.DisposeAsync();
        }
    }
}
