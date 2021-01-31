using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vdrControlCenterUI.Dialogs
{
    public partial class dlgDebug : Form
    {
        public dlgDebug(string s)
        {
            InitializeComponent();

            teMsg.Text = s;
        }
    }
}
