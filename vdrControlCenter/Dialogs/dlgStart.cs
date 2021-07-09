namespace vdrControlCenterUI.Dialogs
{
    using System;
    using System.Windows.Forms;

    public partial class dlgStart : Form
    {
        public DateTime Start
        {
            get => dtpStart.Value.Date;
            set => dtpStart.Value = value;
        }

        public dlgStart()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
