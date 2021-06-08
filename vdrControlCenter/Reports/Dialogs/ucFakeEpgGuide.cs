namespace vdrControlCenterUI.Reports.Dialogs
{
    using DataLayer.Models;
    using Microsoft.Reporting.WinForms;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using vdrControlCenterUI.Dialogs;

    public partial class ucFakeEpgGuide : UserControl
    {
        private vdrControlCenterContext _context;
        private string _channelLogoPath = string.Empty;

        public string ChannelLogoPath
        {
            get => _channelLogoPath;
        }

        public DateTime Start
        {
            get => dtpStart.Value;
        }

        public DateTime Ende
        {
            get => dtpEnde.Value;
        }

        public bool FavouritesOnly
        {
            get => chbFavouritesOnly.Checked;
        }

        public bool HideDescription
        {
            get => chbHideDescription.Checked;
        }

        public bool HideShortDescription
        {
            get => chbHideShortDescription.Checked;
        }

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

       

        private void btnStart_Click(object sender, EventArgs e)
        {
            dlgReports owner = (dlgReports)Parent;
            owner.StartReporting();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dlgReports owner = (dlgReports)Parent;
            owner.Cancel = true;
        }

        public void Enabler(bool startEnable, bool cancelEnable)
        {
            btnStart.Enabled = startEnable;
            btnCancel.Enabled = cancelEnable;
        }
    }
}
