namespace vdrControlCenterUI.Controls;

using Microsoft.Reporting.WinForms;

public partial class ReportView : UserControl
{
    private readonly ReportViewer _reportViewer;

    public ReportViewer ReportViewer
    {
        get => _reportViewer;
    }

    public ReportView()
    {
        InitializeComponent();

        _reportViewer = new ReportViewer();
        _reportViewer.Dock = DockStyle.Fill;
        Controls.Add(_reportViewer);
    }
}

