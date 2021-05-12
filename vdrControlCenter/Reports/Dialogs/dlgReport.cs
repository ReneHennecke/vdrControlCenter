namespace vdrControlCenterUI.Dialogs
{
    using Microsoft.Reporting.WinForms;
    using System;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using vdrControlCenterUI.Enums;

    public partial class dlgReport : Form
    {
        public string Title
        {
            set => Text += $" «{value}»";
        }

        public PageSettings PageSettings
        {
            get => rpvViewer.ReportViewer.GetPageSettings();
            set => rpvViewer.ReportViewer.SetPageSettings(value);
        }

        public dlgReport()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void PostInit(ReportType reportType, Microsoft.Reporting.WinForms.ReportParameter[] reportParameters, ReportDataSource reportDataSource)
        {
            switch (reportType)
            {
                default:
                    break;
                case ReportType.EpgGuide:
                    rpvViewer.ReportViewer.LocalReport.EnableExternalImages = true;
                    rpvViewer.ReportViewer.LocalReport.ReportPath = $"{Environment.CurrentDirectory}\\Reports\\EpgGuide.rdlc";

                    rpvViewer.ReportViewer.LocalReport.SetParameters(reportParameters);
                    rpvViewer.ReportViewer.LocalReport.DataSources.Add(reportDataSource);

                    rpvViewer.ReportViewer.RefreshReport();
                    break;
            }
        }
    }
}
