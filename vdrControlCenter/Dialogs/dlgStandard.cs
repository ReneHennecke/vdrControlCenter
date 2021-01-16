using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vdrControlCenterUI.Classes;

namespace vdrControlCenterUI.Dialogs
{
    public partial class dlgStandard : Form
    {
        public dlgStandard()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        {
            btnOK.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.DlgOkPng}");
            btnCancel.Image = Globals.LoadImage($"{Globals.ImageFolder}/{Globals.DlgCancelPng}");
        }

        private void dlgStandard_KeyDown(object sender, KeyEventArgs e)
        {
            KeyReact(e);
        }


        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            KeyReact(e);
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            KeyReact(e);
        }

        private void KeyReact(KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                default:
                    break;
                case Keys.Escape:
                    btnCancel_Click(null, null);
                    break;
                case Keys.F2:
                    if (btnOK.Enabled)
                        btnOK_Click(null, null);
                    break;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
