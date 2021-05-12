namespace vdrControlCenterUI.Dialogs
{
    using DataLayer.Models;
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

        public void PostInit(ReportType reportType, vdrControlCenterContext context)
        {
            _reportType = reportType;
            _context = context;
            switch (_reportType)
            {
                default:
                    break;
                case ReportType.EpgGuide:
                    ucFakeEpgGuide ucFakeEpgGuide = new ucFakeEpgGuide();
                    ucFakeEpgGuide.PostInit(context);
                    ucFakeEpgGuide.Location = new Point(4, 6);
                    Controls.Add(ucFakeEpgGuide);
                    Size = new Size(Size.Width, ucFakeEpgGuide.Size.Height + 60);
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
                    ucFakeEpgGuide ucFakeEpgGuide = (ucFakeEpgGuide)Controls.OfType<ucFakeEpgGuide>().FirstOrDefault();
                    Cursor = Cursors.WaitCursor;
                    _reportParameters = ucFakeEpgGuide.RetrieveParameters();
                    _reportDataSource = ucFakeEpgGuide.RetrieveReportDataSource();
                    Cursor = Cursors.Default;
                    break;
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
