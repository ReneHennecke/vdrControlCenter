namespace vdrControlCenterUI.Dialogs
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class dlgMessageBoxExtended : Form
    {
        public dlgMessageBoxExtended(string title, string message, int timeout)
        {
            InitializeComponent();

            Text = title;
            mleMessage.Text = message;
            if (timeout > 0)
            {
                tmTimer.Interval = timeout;
                tmTimer.Enabled = true;
            }
        }

        private void tmTimout_Tick(object sender, EventArgs e)
        {
            btnOK_Click(null, null);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            tmTimer.Enabled = false;
            base.OnClosing(e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
