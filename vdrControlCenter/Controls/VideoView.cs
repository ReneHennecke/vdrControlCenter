using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vdrControlCenterUI.Controls
{
    public partial class VideoView : UserControl
    {
        private frmMain _mainForm;
        public frmMain MainForm
        {
            set { _mainForm = value; }
        }

        public VideoView()
        {
            InitializeComponent();
        }
    }
}
