namespace vdrControlCenterUI.Classes
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using vdrControlCenterUI.Controls;

    public class SvdrpClient : NetCoreServer.TcpClient
    {
        private SvdrpController _controller;
        private bool _stop;

        public SvdrpClient(SvdrpController controller, string address, int port) : base(address, port) 
        {
            _controller = controller;
        }

        public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }

        protected override void OnConnected()
        {
            _controller.OnConnect(Id);
        }

        protected override void OnDisconnected()
        {
            _controller.OnDisconnect(Id);

            Thread.Sleep(250);
            if (!_stop)
                ConnectAsync();
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            _controller.OnReceive(Encoding.UTF8.GetString(buffer, (int)offset, (int)size));
        }

        protected override void OnError(SocketError error)
        {
            _controller.OnError(error);
        }
    }
}
