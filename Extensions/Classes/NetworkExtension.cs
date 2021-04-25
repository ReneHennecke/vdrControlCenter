namespace Extensions.Classes
{
    using System.Net;

    public static class NetworkExtension
    {
        public static IPAddress LocalAddress
        {
            get 
            {
                IPAddress retval = null;
                var localHost = Dns.GetHostEntry(Dns.GetHostName());
                foreach(var ip in localHost.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        retval = ip;
                        break;
                    }
                }

                return retval;
            }
        }
    }
}
