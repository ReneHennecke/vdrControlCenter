namespace vdrControlCenterUI.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using vdrControlCenterUI.Classes;
    using vdrControlCenterUI.Enums;
    using DataLayer.Models;
    using System.Linq;
    using vdrControlCenterUI.Dialogs;
    using Microsoft.EntityFrameworkCore;
    using System.Net.Sockets;

    public partial class SvdrpController : UserControl
    {
        private vdrControlCenterContext _context;

        private SvdrpClient _client;

        private delegate void TranslateDataCallback(string text);
        private delegate void ShowBufferLengthCallback();

        private SvdrpRequest _svdrpRequest = SvdrpRequest.Undefined;
        private SvdrpBuffer _svdrpBuffer;
        private SvdrpConnectionInfo _svdrpConnectionInfo;

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

        private int _received = 0;
        private System.Drawing.Size _bufferControlSize;

        public delegate void OnConnectCallback(Guid id);
        public delegate void OnDisconnectCallback(Guid id);
        public delegate void OnReceiveCallback(string data);
        public delegate void OnErrorCallback(SocketError error);

        public SvdrpController()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private async void PostInit()
        { 
            if (_context == null)
                _context = new vdrControlCenterContext();

            if (await _context.Stations.CountAsync(station => station.Svdrpport > 0) > 1)
            {
                dlgMessageBoxExtended dlg = new dlgMessageBoxExtended("SVDRP-Fehler", "Es sind mehrere Server als SVDRP-Endpunkt definiert.", 0);
                dlg.ShowDialog();

                return;
            }

            ReloadData();

            _svdrpBuffer = new SvdrpBuffer();

            grbBuffer.MouseClick += grbBuffer_MouseClick;
            _bufferControlSize = grbBuffer.Size;

#if DEBUG
            _svdrpBuffer.EnableDebug = true;
            grbBuffer.Visible = true;
#else
            grbBuffer.Visible = false;
#endif

            Stations station = await _context.Stations.FirstOrDefaultAsync(s => s.Svdrpport > 0);
            _client = new SvdrpClient(this, station.HostAddress, station.Svdrpport.GetValueOrDefault());
        }

        private void ReloadData()
        {
            svdrpConnector.LoadData(this);
            svdrpChannelsView.LoadData(this);
            svdrpTimersView.LoadData(this);
            svdrpRecordingsView.LoadData(this);
            svdrpStatusInfoView.LoadData(this);
            svdrpEpgListView.LoadData(this);
        }

        private void OnDispose(object sender, EventArgs e)
        {
            if (_client.IsConnected)
                _client.DisconnectAndStop();
            _context?.Dispose();
        }

        private void AddBuffer(string data)
        {
            if (!grbBuffer.Visible || mleBuffer.IsDisposed
                )
                return;

            mleBuffer.AppendText($"{data}{Environment.NewLine}");
            mleBuffer.SelectionStart = mleBuffer.Text.Length;
            mleBuffer.ScrollToCaret();

            lblBufferLength.Text = $"{mleBuffer.Text.Length}";
        }

        private void RefreshRequestControls(bool enabled)
        {
            svdrpChannelsView.RequestEnable = enabled;
            svdrpTimersView.RequestEnable = enabled;
            svdrpRecordingsView.RequestEnable = enabled;
            svdrpStatusInfoView.RequestEnable = enabled;
            svdrpEpgListView.RequestEnable = enabled;
        }

        #region Client Events
        public void OnConnect(Guid id)
        {
            if (InvokeRequired)
            {
                OnConnectCallback cb = new OnConnectCallback(OnConnect);
                Invoke(cb, new object[] { id });
            }
            else
            {
                AddBuffer($"Verbunden : {id}{Environment.NewLine}");

                _svdrpConnectionInfo = new SvdrpConnectionInfo(id);
            }
        }

        public void OnDisconnect(Guid id)
        {
            if (InvokeRequired)
            {
                OnDisconnectCallback cb = new OnDisconnectCallback(OnDisconnect);
                Invoke(cb, new object[] { id });
            }
            else
            {
                AddBuffer($"Getrennt : {id}{Environment.NewLine}");

                _svdrpConnectionInfo = new SvdrpConnectionInfo();
                svdrpConnector.ShowConnection(_svdrpConnectionInfo);
                _svdrpRequest = SvdrpRequest.Undefined;
            }
        }

        public void OnReceive(string data)
        {
            if (InvokeRequired)
            {
                OnReceiveCallback cb = new OnReceiveCallback(OnReceive);
                Invoke(cb, new object[] { data });
            }
            else
            {
                AddBuffer($"{data}{Environment.NewLine}");

                _svdrpBuffer.Add(data);
                _svdrpBuffer.Save2File();

                switch (_svdrpRequest)
                {
                    case SvdrpRequest.Connect:
                        if (_svdrpBuffer.Content.StartsWith(REQ_220))
                        {
                            _svdrpConnectionInfo.ParseMessage(_svdrpBuffer.Splitter);
                            if (_client.IsConnected)
                            {
                                svdrpConnector.ShowConnection(_svdrpConnectionInfo);

                                RefreshRequestControls(true);
                            }
                        }
                        _svdrpRequest = SvdrpRequest.Undefined;
                        break;
                    case SvdrpRequest.Disconnect:
                        RefreshRequestControls(false);
                        break;
                    case SvdrpRequest.GetStatusInfo:
                        SvdrpStatusInfo statusInfo = new SvdrpStatusInfo();
                        statusInfo.ParseMessage(_svdrpBuffer.Splitter);

                        svdrpStatusInfoView.RefreshData(statusInfo);
                        RefreshRequestControls(true);
                        
                        _svdrpRequest = SvdrpRequest.Undefined;
                        break;
                    case SvdrpRequest.GetChannelList:
                        if (_svdrpBuffer.Content.StartsWith(REQ_250))
                        {
                            tmTimeOut.Interval = 2000;
                            tmTimeOut.Enabled = true;
                        }
                        break;
                    case SvdrpRequest.GetTimerList:
                        if (_svdrpBuffer.Content.Contains(REQ_MSG_NO_TIMERS_DEFINED))
                        {
                            dlgMessageBoxExtended dlg = new dlgMessageBoxExtended("Timer", "Es sind keine Timer definiert.", 3);
                            dlg.ShowDialog();

                            RefreshRequestControls(true);
                        }
                        else if (_svdrpBuffer.Content.StartsWith(REQ_250))
                        {
                            tmTimeOut.Interval = 2000;
                            tmTimeOut.Enabled = true;
                        }
                        break;
                    case SvdrpRequest.GetRecordings:
                        if (_svdrpBuffer.Content.StartsWith(REQ_250))
                        {
                            tmTimeOut.Interval = 2000;
                            tmTimeOut.Enabled = true;
                        }
                        break;
                    case SvdrpRequest.GetEPGList:
                        if (_svdrpBuffer.Content.Contains(REQ_MSG_END_OF_EPG_DATA))
                        {
                            SvdrpEPGList svdrpEPGList = new SvdrpEPGList();
                            svdrpEPGList.ParseMessage(_svdrpBuffer.Splitter);
                            
                            svdrpEpgListView.RefreshData(svdrpEPGList);
                            RefreshRequestControls(true);
                            _svdrpRequest = SvdrpRequest.Undefined;
                        }
                        break;
                    case SvdrpRequest.AddTimer:
                        if (_svdrpBuffer.Content.StartsWith(REQ_250))
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void OnError(SocketError error)
        {
            if (InvokeRequired)
            {
                OnErrorCallback cb = new OnErrorCallback(OnError);
                Invoke(cb, new object[] { error });
            }
            else
                AddBuffer($"Fehler : {error.ToString()}{Environment.NewLine}");
        }
        #endregion 

        #region Connection
        public void SendConnectRequest() //string hostAddress, int port)
        {
            if (_client.IsConnected)
                return;
            //MainForm.AddMessage($"CONNECT SVDRP.");

            _svdrpRequest = SvdrpRequest.Connect;
            _svdrpBuffer.Clear();
            _client.ConnectAsync();
        }

        public void SendDisconnectRequest()
        {
            if (!_client.IsConnected)
                return;

            //MainForm.AddMessage($"DISCONNECT SVDRP.");

            _svdrpRequest = SvdrpRequest.Disconnect;
            _svdrpBuffer.Clear();
            _client.SendAsync($"QUIT{EOL}");
            _client.DisconnectAndStop();
        }
        #endregion

        #region StatusInfo
        public void SendStatusInfoRequest()
        {
            if (!_client.IsConnected)
                return;

            RefreshRequestControls(false);
            //MainForm.AddMessage($"GET StatusInfo.");
            _svdrpRequest = SvdrpRequest.GetStatusInfo;
            _svdrpBuffer.Clear();
            _client.SendAsync($"STAT disk{EOL}");
        }
        #endregion

        #region Channels
        public void SendGetChannelListRequest()
        {
            if (!_client.IsConnected)
                return;

            RefreshRequestControls(false);
            //MainForm.AddMessage($"EPG Request.");

            _svdrpRequest = SvdrpRequest.GetChannelList;
            _svdrpBuffer.Clear();
            _client.SendAsync($"LSTC{EOL}");
        }
        #endregion

        #region Timers
        public void SendGetTimerListRequest()
        {
            if (!_client.IsConnected)
                return;

            RefreshRequestControls(false);
            //MainForm.AddMessage($"EPG Request.");

            _svdrpRequest = SvdrpRequest.GetTimerList;
            _svdrpBuffer.Clear();
            _client.SendAsync($"LSTT{EOL}");
        }

        public async void SendAddTimerRequest(List<long> selectedItems)
        {
            if (!_client.IsConnected)
                return;

            using (vdrControlCenterContext context = new vdrControlCenterContext())
            {
                foreach (long item in selectedItems)
                {
                    Epg epg = await context.Epg.FirstOrDefaultAsync(e => e.RecId == item);
                    if (epg != null)
                    {
                        Channels channel = await context.Channels.FirstOrDefaultAsync(e => e.RecId == epg.ChannelRecId);
                        if (channel == null || channel.Number == 0)
                            continue;

                        DateTime dayOfMonth = epg.StartTime.Value;

                        string timer = "1:" +   // Aktiv
                                       $"{channel.Number}:{dayOfMonth:yyyy-MM-dd}:" +
                                       $"{epg.StartTime:HHmm}:" +
                                       $"{epg.StartTime.Value.AddSeconds((double)epg.Duration):HHmm}:" +
                                       "51:" +
                                       "50:" +
                                       $"{epg.Title}:";

                        _svdrpRequest = SvdrpRequest.AddTimer;
                        _svdrpBuffer.Clear();

                        _client.SendAsync($"NEWT {timer}{EOL}");
                    }
                }
            }
        }
        #endregion

        #region Recordings
        public void SendGetRecordingsRequest()
        {
            if (!_client.IsConnected)
                return;

            RefreshRequestControls(false);
            //MainForm.AddMessage($"EPG Request.");

            _svdrpRequest = SvdrpRequest.GetRecordings;
            _svdrpBuffer.Clear();
            _client.SendAsync($"LSTR{EOL}");
        }
        #endregion

        #region  EPG
        public void SendEPGRequest()
        {
            if (!_client.IsConnected)
                return;

            RefreshRequestControls(false);
            //MainForm.AddMessage($"EPG Request.");

            _svdrpRequest = SvdrpRequest.GetEPGList;
            _svdrpBuffer.Clear();
            _client.SendAsync($"LSTE{EOL}");
        }
        #endregion

        private void tmTimeOut_Tick(object sender, EventArgs e)
        {
            int received = Convert.ToInt32(lblBufferLength.Text ?? "0");
            if (received != _received)
            { 
                _received = received;
                return;
            }

            tmTimeOut.Enabled = false;

            switch (_svdrpRequest)
            {
                case SvdrpRequest.GetChannelList:
                    SvdrpChannelList svdrpChannelList = new SvdrpChannelList();
                    svdrpChannelList.ParseMessage(_svdrpBuffer.Splitter);

                    if (svdrpChannelList != null)
                        svdrpChannelsView.RefreshData(svdrpChannelList);
        
                    break;
                case SvdrpRequest.GetTimerList:
                    SvdrpTimerList svdrpTimerList = new SvdrpTimerList();
                    svdrpTimerList.ParseMessage(_svdrpBuffer.Splitter);

                    if (svdrpTimerList != null)
                        svdrpTimersView.RefreshData(svdrpTimerList);

                    break;
                case SvdrpRequest.GetRecordings:
                    SvdrpRecordingList svdrpRecordingList = new SvdrpRecordingList();
                    svdrpRecordingList.ParseMessage(_svdrpBuffer.Splitter);

                    if (svdrpRecordingList != null)
                        svdrpRecordingsView.RefreshData(svdrpRecordingList);

                    break;
            }

            RefreshRequestControls(true);
            _svdrpRequest = SvdrpRequest.Undefined;
        }

        private void grbBuffer_MouseClick(object sender, EventArgs e)
        {
            int height = grbBuffer.Size.Height;
            if (height > 15)
                grbBuffer.Size = new System.Drawing.Size(150, 15);
            else
                grbBuffer.Size = _bufferControlSize;
        }
    }
}
