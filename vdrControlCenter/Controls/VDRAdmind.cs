using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace vdrControlCenterUI.Controls
{
    public partial class VDRAdmindView : UserControl
    {
        public VDRAdmindView()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            //wcWebViewer.Navigate("about:blank");
        }
    }
}
