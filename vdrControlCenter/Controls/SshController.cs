namespace vdrControlCenterUI.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using DataLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using Renci.SshNet;
    using vdrControlCenterUI.Classes;

    public partial class SshController : UserControl
    {
        private vdrControlCenterContext _context;
        private SshClient _sshClient = null;
        private ShellStream _shellStream = null;
        private List<string> _commandList;
        private int _currentCommand;
        

        public SshController()
        {
            InitializeComponent();

            if (!DesignMode)
                PostInit();
        }

        private void PostInit()
        {
            _commandList = new List<string>();

            if (_context == null)
                _context = new vdrControlCenterContext();

            sshConnector.LoadData(this);
        }

        private void SshController_Load(object sender, EventArgs e)
        {
            System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(RecvSSHData);
            System.Threading.Thread thread = new System.Threading.Thread(threadStart);

            thread.IsBackground = true;
            thread.Start();
        }

        private void RecvSSHData()
        {
            while (true)
            {
                try
                {
                    if (_shellStream != null && _shellStream.DataAvailable)
                    {
                        string data = _shellStream.Read();

                        AppendTextBoxInThread(bccConsole, data);
                    }
                }
                catch
                {

                }

                System.Threading.Thread.Sleep(200);
            }

        }

        private void AppendTextBoxInThread(BashColorConsole consoleControl, string s)
        {
            if (consoleControl.InvokeRequired)
            {
                consoleControl.Invoke(new Action<BashColorConsole, string>(AppendTextBoxInThread), new object[] { consoleControl, s });
            }
            else
            {
                if (s.Contains("\u001b[H"))
                    consoleControl.Text = string.Empty;
                else
                {
                    List<BashColorConsoleTextRaX> text = consoleControl.PrepareConsoleString(s);
                    foreach (BashColorConsoleTextRaX bcct in text)
                    {
                        consoleControl.AppendText(bcct.Text, bcct.Color, false);
                    }

                    //consoleControl.AppendText(s, consoleControl.ForeColor, false);
                }
            }
        }

        private void teCommand_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (_commandList.FindIndex(x => x == teCommand.Text) == -1)
                        _commandList.Add(teCommand.Text);

                    _shellStream.Write(teCommand.Text + "\n");
                    _shellStream.Flush();

                    teCommand.Text = string.Empty;
                    teCommand.Focus();
                    break;
                case Keys.Down:
                    if (_commandList.Count > 0)
                    {
                        if (_currentCommand == -1)
                            _currentCommand = _commandList.Count - 1;
                        else if (_currentCommand > 0)
                            _currentCommand--;
                        teCommand.Text = _commandList[_currentCommand];
                    }
                    break;
                case Keys.Up:
                    if (_commandList.Count > 0)
                    {
                        if (_currentCommand == -1)
                            _currentCommand = 0;
                        else if (_currentCommand < _commandList.Count - 1)
                            _currentCommand++;
                        teCommand.Text = _commandList[_currentCommand];

                    }
                    break;
                default:
                    break;
            }
        }

        public async Task<bool> SendConnectRequest()
        {
            bool connected = false;

            try
            {

                Stations stations = await _context.Stations.FirstOrDefaultAsync(x => x.MachineName == Environment.MachineName && x.StationType == 2 && x.Sshport > 0);
                if (stations != null)
                {
                    ConnectionInfo connectionInfo = new ConnectionInfo(stations.HostAddress,
                                                                       stations.Sshport.Value,
                                                                       stations.SshuserName,
                                                                       new PasswordAuthenticationMethod(stations.SshuserName,
                                                                                                        stations.Sshpassword));
                    connectionInfo.Encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                    _sshClient = new SshClient(connectionInfo);

                    _sshClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(120);
                    _sshClient.Connect();

                    connected = _sshClient.IsConnected;
                    sshConnector.ShowConnection(_sshClient);

                    // terminal vt100, xterm-256color, dumb, bash
                    _shellStream = _sshClient.CreateShellStream("vt100", 80, 60, 800, 600, 65536);

                    bccConsole.ReadOnly = teCommand.ReadOnly = false;
                    teCommand_KeyDown(null, new KeyEventArgs(Keys.Enter));
                    teCommand.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return connected;

        }

        public void SendDisconnectRequest()
        {
            try
            {
                _shellStream.Close();
            }
            catch
            {

            }

            try
            {
                _sshClient.Disconnect();
                bccConsole.ReadOnly = teCommand.ReadOnly = true;
                sshConnector.ShowConnection(_sshClient);
            }
            catch
            {

            }
        }
    }
}
