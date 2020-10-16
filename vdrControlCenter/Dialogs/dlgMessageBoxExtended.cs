namespace vdrControlCenterUI.Dialogs
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class dlgMessageBoxExtended : Form
    {
        private int _countDown;

        public dlgMessageBoxExtended(string title, string message, int countDown)
        {
            InitializeComponent();

            Text = title;
            mleMessage.Text = message;
            if (countDown > 0)
            {
                _countDown = countDown;
                btnOK.Visible = btnCancel.Visible = false;
                ShowCountDown();
                tmTimer.Enabled = true;
            }
            else
                btnOKOnly.Visible = false;
        }

        private void tmTimout_Tick(object sender, EventArgs e)
        {
            _countDown--;
            ShowCountDown();
            if (_countDown == 0)
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

        private void btnOKOnly_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowCountDown()
        {
            btnOKOnly.Text = $"OK ({_countDown} sec)";
        }

        private void dlgMessageBoxExtended_Shown(object sender, EventArgs e)
        {
            if (btnOKOnly.Visible)
                btnOKOnly.Focus();
            else
                btnOK.Focus();
        }
    }
}
