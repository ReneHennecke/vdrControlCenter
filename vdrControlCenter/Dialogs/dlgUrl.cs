namespace vdrControlCenterUI.Dialogs
{
    using System;
    using System.Windows.Forms;

    public partial class dlgUrl : Form
    {
        public string Url
        {
            get => teUrl.Text;
            set => teUrl.Text = value;
        }

        public dlgUrl()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {
            teUrl_TextChanged(null, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void teUrl_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (Uri.IsWellFormedUriString(teUrl.Text, UriKind.Absolute));
        }
    }
}
