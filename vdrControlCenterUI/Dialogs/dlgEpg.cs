namespace vdrControlCenterUI.Dialogs
{
    using DataLayer.Models;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class dlgEpg : Form
    {
        public dlgEpg()
        {
            InitializeComponent();
        }

        public void PostInit(FakeEpg epg)
        {
            lblTitleValue.Text = epg.Title;
            lblChannelNameValue.Text = epg.ChannelName;
            lblStartTimeValue.Text = $"{epg.StartTime:dd.MM.yyyy HH:mm}";
            lblDurationValue.Text = $"{epg.Duration / 60}";
            lblEndTimeValue.Text = $"{epg.StartTime.Value.AddSeconds(epg.Duration.Value):dd.MM.yyyy HH:mm}";
            lblShortDescriptionValue.Text = epg.ShortDescription;
            lblVpsValue.Text = $"{epg.Vps:dd.MM.yyyy HH:mm}";
            lblEventIdValue.Text = $"{epg.EventId}";
            teDescription.Text = epg.Description;

            btnTimer.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.Epg_TimerPng}");
            btnCancel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.Epg_CancelPng}");
        }

        private void btnTimer_Click(object sender, System.EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {

        }
    }
}
