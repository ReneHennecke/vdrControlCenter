using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using vdrControlCenterUI.Classes;
using vdrControlCenterUI.Enums;
using DataLayer.Models;
using System.Linq;
using vdrControlCenterUI.Dialogs;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace vdrControlCenterUI.Controls
{
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

        public delegate void OnConnectCallback(Guid id);
        public delegate void OnDisconnectCallback(Guid id);
        public delegate void OnReceiveCallback(string data);
        public delegate void OnErrorCallback(SocketError error);

        public SvdrpController()
        {
            InitializeComponent();

            PostInit();
        }

        private void PostInit()
        { 
            Disposed += OnDispose;

            if (!DesignMode)
            {
                _context = new vdrControlCenterContext();
                //               _context.pr.Configuration.ProxyCreationEnabled = true;
                //             _context.Configuration.LazyLoadingEnabled = true;

                using (vdrControlCenterContext context = new vdrControlCenterContext())
                {
                    if (_context.Stations.Count(station => station.Svdrpport > 0) > 1)
                    {
                        dlgMessageBoxExtended dlg = new dlgMessageBoxExtended("SVDRP-Fehler", "Es sind mehrere Server als SVDRP-Endpunkt definiert.", 0);
                        dlg.ShowDialog();

                        return;
                    }
                }

                ReloadData();



                //svdrpStatusInfoCtrl.Owner = this;
                //svdrpChannelCtrl.Owner = this;
                //svdrpTimerCtrl.Owner = this;
                //svdrpRecordingCtrl.Owner = this;
                //svdrpEPGCtrl.Owner = this;

                //_context = new DataLayer.EF.vdrControlCenterEntities();
                //_context.Configuration.ProxyCreationEnabled = true;
                //_context.Configuration.LazyLoadingEnabled = true;

                //LoadData();

                _svdrpBuffer = new SvdrpBuffer();
#if DEBUG
                _svdrpBuffer.EnableDebug = true;
                grbBuffer.Visible = true;
#else
                grbBuffer.Visible = false;
#endif

                using (vdrControlCenterContext context = new vdrControlCenterContext())
                {
                    Stations station = context.Stations.FirstOrDefault(s => s.Svdrpport > 0);
                    _client = new SvdrpClient(this, station.HostAddress, station.Svdrpport.GetValueOrDefault());
                }
            }
        }

        private void ReloadData()
        {
            svdrpConnector.LoadData(this, _context);
            svdrpStatusInfo.LoadData(this, _context);
            svdrpEPGList.LoadData(this, _context);
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
            svdrpStatusInfo.RequestEnable = enabled;
            svdrpEPGList.RequestEnable = enabled;
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

                        svdrpStatusInfo.RefreshData(statusInfo);
                        RefreshRequestControls(true);
                        
                        _svdrpRequest = SvdrpRequest.Undefined;
                        break;
                    case SvdrpRequest.GetEPGList:
                        if (_svdrpBuffer.Content.Contains(REQ_MSG_END_OF_EPG_DATA))
                        {
                            SvdrpEPGList epgList = new SvdrpEPGList();
                            epgList.ParseMessage(_svdrpBuffer.Splitter);
                            
                            svdrpEPGList.RefreshData(epgList);
                            RefreshRequestControls(true);
                            _svdrpRequest = SvdrpRequest.Undefined;
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

        private void svdrpCtrl_RefreshConnectionInfo(object sender, SvdrpConnectionInfoEventArgs e)
        {
            svdrpConnector.ShowConnection(e.ConnectionInfo);

            svdrpEPGList.Enabled = true;
            //svdrpStatusInfoCtrl.EnableRequests = svdrpChannelCtrl.EnableRequests = svdrpTimerCtrl.EnableRequests =
            //svdrpRecordingCtrl.EnableRequests = svdrpEPGCtrl.EnableRequests = e.ConnectionInfo.IsConnected;
        }



        #endregion

       
    }
}
