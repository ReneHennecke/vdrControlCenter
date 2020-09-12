using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using vdrControlCenterUI.Enums;
using vdrControlCenterUI.Classes;

namespace vdrControlCenterUI.Controls
{
    public partial class SvdrpController : UserControl
    {
        private delegate void TranslateDataCallback(string text);
        private delegate void ShowBufferLengthCallback();

        private delegate void DisconnectCallback();
        private SvdrpRequest _enumRequest = SvdrpRequest.Undefined;
        private SvdrpBuffer _svdrpBuffer;
        private bool _isConnected;

        private const string EOL = "\n";
        private const string REQ_215 = "215";
        private const string REQ_220 = "220";
        private const string REQ_221 = "221";
        private const string REQ_250 = "250";
        private const string REQ_500 = "500";
        private const string REQ_550 = "550";

        private const string REQ_MSG_CONNECTION_CLOSING = "closing connection";
        private const string REQ_MSG_END_OF_EPG_DATA = "End of EPG data";
        private const string REQ_MSG_NO_TIMERS_DEFINED = "No timers defined";
        private const string REQ_MSG_TIMER = "Timer";
        private const string REQ_MSG_DELETED = "deleted";
        private const string REQ_MSG_UPD_REC = "Re-read of recordings directory triggered";

        public SvdrpController Owner { get; set; }

        public event RefreshConnectionEventHandler RefreshConnectionInfo;
        public delegate void RefreshConnectionEventHandler(object sender, SvdrpConnectionInfoEventArgs e);

        //public event RefreshStatusEventHandler RefreshStatusInfo;
        //public delegate void RefreshStatusEventHandler(object sender, SvdrpStatusInfoEventArgs e);

        //public event RefreshChannelListEventHandler RefreshChannelList;
        //public delegate void RefreshChannelListEventHandler(object sender, SvdrpChannelListEventArgs e);

        //public event RefreshTimerListEventHandler RefreshTimerList;
        //public delegate void RefreshTimerListEventHandler(object sender, SvdrpTimerListEventArgs e);

        //public event RefreshEPGListEventHandler RefreshEPGList;
        //public delegate void RefreshEPGListEventHandler(object sender, SvdrpEPGListEventArgs e);

        //public event RefreshRecordingListEventHandler RefreshRecordingList;
        //public delegate void RefreshRecordingListEventHandler(object sender, SvdrpRecordingListEventArgs e);

        //public event RefreshCheckEventHandler RefreshCheck;
        //public delegate void RefreshCheckEventHandler(object sender, SvdrpCheckEventArgs e);

        public SvdrpController()
        {
            InitializeComponent();
        }

        public void SendConnectRequest()
        {

        }

        public void SendDisconnectRequest()
        {

        }
    }
}
