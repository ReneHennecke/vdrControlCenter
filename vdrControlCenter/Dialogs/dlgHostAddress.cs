namespace vdrControlCenterUI.Dialogs
{
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Net;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;

    public partial class dlgHostAddress : Form
    {
        public IPAddress HostAddress
        {
            get { return IPAddress.Parse(teHostAddress.Text); }
        }

        public dlgHostAddress()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            btnOK.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.DlgOkPng}");
            btnCancel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.DlgCancelPng}");
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private async void teHostAddress_TextChanged(object sender, System.EventArgs e)
        {
            btnOK.Enabled = IPAddress.TryParse(teHostAddress.Text, out IPAddress ip);
            if (btnOK.Enabled)
            {
                using (vdrControlCenterContext context = new vdrControlCenterContext())
                {
                    btnOK.Enabled = (await context.Stations.FirstOrDefaultAsync(s => s.HostAddress == $"{ip}") == null);
                }
            }
        }
    }
}
