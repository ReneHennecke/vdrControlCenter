namespace vdrControlCenterUI.Classes
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// Erweiterte Netzwerkfunktionen
    /// </summary>
    public static class NetworkRaX
    {
        /// <summary>
        /// Konvertiert einen IP String in einen uint Wert
        /// </summary>
        /// <param name="ipString"></param>
        /// <returns>uint IP Adresse</returns>
        public static uint GetIpAsUInt32(string ipString)
        {
            IPAddress address = IPAddress.Parse(ipString);

            byte[] ipBytes = address.GetAddressBytes();

            Array.Reverse(ipBytes);

            return BitConverter.ToUInt32(ipBytes, 0);
        }

        /// <summary>
        /// Konvertiert eine uint IP Adresse in einen IP String
        /// </summary>
        /// <param name="ipVal"></param>
        /// <returns>string IP Adresse</returns>
        public static string GetIpAsString(uint ipVal)
        {
            byte[] ipBytes = BitConverter.GetBytes(ipVal);

            Array.Reverse(ipBytes);

            return new IPAddress(ipBytes).ToString();
        }

        /// <summary>
        /// Konvertiert eine uint Mac Adresse in einen Mac String
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns>string Mac Adresse</returns>
        public static string GetMacAsString(ulong macAddress)
        {
            return GetMacAsString(macAddress, ":");
        }

        /// <summary>
        /// Konvertiert eine uint Mac Adresse in einen Mac String
        /// </summary>
        /// <param name="macAddress"></param>
        /// <param name="byteDelimiter"></param>
        /// <returns>string Mac Adresse</returns>
        public static string GetMacAsString(ulong macAddress, string byteDelimiter)
        {
            return string.Join(byteDelimiter, BitConverter.GetBytes(macAddress).Reverse().Select(b => b.ToString("X2"))).Substring(6);
        }

        /// <summary>
        /// Konvertiert einen Mac String in einen uint Wert
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns>uint Mac Adresse</returns>
        public static ulong GetMacAsULong(string macAddress)
        {
            return GetMacAsULong(macAddress, ":");
        }

        /// <summary>
        /// Konvertiert einen Mac String in einen uint Wert
        /// </summary>
        /// <param name="macAddress"></param>
        /// <param name="byteDelimiter"></param>
        /// <returns>uint Mac Adresse</returns>
        public static ulong GetMacAsULong(string macAddress, string byteDelimiter)
        {
            string hex = macAddress.Replace(byteDelimiter, string.Empty);
            return Convert.ToUInt64(hex, 16);
        }

        /// <summary>
        /// Sendet das magic packet für die WakeOnLan an die macAddresse
        /// </summary>
        /// <param name="macAddress"></param>
        public static void WakeOnLan(byte[] macAddress)
        {
            // WOL packet is sent over UDP 255.255.255.0:40000.
            UdpClient client = new UdpClient();
            client.Connect(IPAddress.Broadcast, 40000);

            // WOL packet contains a 6-bytes trailer and 16 times a 6-bytes sequence containing the MAC address.
            byte[] packet = new byte[17 * 6];

            // Trailer of 6 times 0xFF.
            for (int i = 0; i < 6; i++)
                packet[i] = 0xFF;

            // Body of magic packet contains 16 times the MAC address.
            for (int i = 1; i <= 16; i++)
                for (int j = 0; j < 6; j++)
                    packet[i * 6 + j] = macAddress[j];

            // Send WOL packet.
            client.Send(packet, packet.Length);
        }

        /// <summary>
        /// Sort list of ip addresses
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int CompareTo(this IPAddress x, IPAddress y)
        {
            var result = x.AddressFamily.CompareTo(y.AddressFamily);
            if (result != 0)
                return result;

            var xBytes = x.GetAddressBytes();
            var yBytes = y.GetAddressBytes();

            var octets = Math.Min(xBytes.Length, yBytes.Length);
            for (var i = 0; i < octets; i++)
            {
                var octetResult = xBytes[i].CompareTo(yBytes[i]);
                if (octetResult != 0)
                    return octetResult;
            }
            return 0;
        }

        /// <summary>
        /// Get local Iip address
        /// </summary>
        public static IPAddress LocalAddress
        {
            get
            {
                IPAddress retval = null;
                var localHost = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in localHost.AddressList)
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
