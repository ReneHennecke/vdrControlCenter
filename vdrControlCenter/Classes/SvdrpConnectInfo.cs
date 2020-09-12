namespace vdrControlCenterUI.Classes
{
    public class SvdrpConnectionInfo
    {
        public string ConnectionString { get; private set; }
        public bool IsConnected
        {
            get { return !string.IsNullOrWhiteSpace(ConnectionString); }
        }

        public SvdrpConnectionInfo()
        {
            ConnectionString = string.Empty;
        }

        public SvdrpConnectionInfo(string[] response)
        {
            if (response.Length > 0 && response[0].Length > 0)
            {
                string prm = response[0];
                prm = prm.Substring(prm.IndexOf(' ') + 1);
                if (response.Length > 0)
                {
                    ConnectionString = prm;
                }
            }
        }
    }
}
