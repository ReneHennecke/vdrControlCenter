using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using vdrServerHelper.Extensions;

namespace vdrServerHelper
{
    internal class Program
    {
        private static StreamWriter? streamWriterLog = null;

        static async Task Main(string[] args)
        {
            Console.WriteLine($"{ApplicationInfo.ProductName} {ApplicationInfo.Version} {ApplicationInfo.CopyrightHolder} {ApplicationInfo.CompanyName}");

            await OpenLogFileAsync();

            var ignoreShutdown = false;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                // Checking ports
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                var reverseLoop = IPAddress.Parse("127.0.1.1");
                var ip = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork && !ip.Equals(reverseLoop));
                if (ip != null)
                {
                    IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                    TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();

                    const int TCP_PORT_SSH = 22;
                    const int TCP_PORT_SAMBA = 445;
                    const int TCP_PORT_VNSI = 34890;

                    if (!ignoreShutdown)
                        ignoreShutdown = await IsPortAvailableAsync(ip, connections, TCP_PORT_SSH);

                    if (!ignoreShutdown)
                        ignoreShutdown = await IsPortAvailableAsync(ip, connections, TCP_PORT_SAMBA);

                    if (!ignoreShutdown)
                        ignoreShutdown = await IsPortAvailableAsync(ip, connections, TCP_PORT_VNSI);
                }
            }

            if (!ignoreShutdown)
                // Checking for VDR recordings ?
                ignoreShutdown = await HasRecordingsAsync();

            if (!ignoreShutdown)
            {
                // Checking timers
                var list = await GetTimerListAsync();
                
                // Checking very close timer
                ignoreShutdown = await HasNextOrVeryCloseTimerAsync(list, 20 * 60); // 20 min

                if (!ignoreShutdown)
                    ignoreShutdown = await HasNextOrVeryCloseTimerAsync(list, 5 * 60); // 5 min
            }

            if (!ignoreShutdown)
            {
                // Checking running processes
                var processes = Process.GetProcesses();
                ignoreShutdown = await IsProcessRunningAsync(processes, "firefox");
            }

            if (!ignoreShutdown)
                // Checking min up time
                ignoreShutdown = await IsMinUpTimeAsync(30 * 60); // min 30 minutes

            if (!ignoreShutdown)
                await WriteLogAsync("Try shutdown.");

            await CloseLogFileAsync();

#if !DEBUG
            if (!ignoreShutdown)
            { 
                // shutdown required
                try
                {
                    using (Process p = new())
                    {
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.FileName = "/sbin/shutdown";
                        p.StartInfo.Arguments = "-h now";
                        p.StartInfo.CreateNoWindow = true;

                        p.Start();
        }
    }
                catch (Exception ex)
                {
                    await WriteLogAsync(ex.Message);
                }
            }
#else
            Console.ReadLine();
#endif
        }

        #region Logging
        private static async Task OpenLogFileAsync()
        {
            await CloseLogFileAsync();

            if (streamWriterLog == null)
            {
                var path = $"{AppDomain.CurrentDomain.BaseDirectory}/log/opt";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    path = "/var/log/opt";

                path = path.Replace("\\", "/");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var file = Path.Combine(path, $"{Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location)}-{DateTime.UtcNow:ddMMyyyy}.log");
                var utf8NoBom = new UTF8Encoding(false);
                streamWriterLog = new StreamWriter(file, true, utf8NoBom);
                await WriteLogAsync("Start logging.");
            }
        }

        private static async Task CloseLogFileAsync()
        {
            if (streamWriterLog != null)
            {
                await WriteLogAsync("Stop logging.");
                await streamWriterLog.FlushAsync();
                streamWriterLog.Close();
                await streamWriterLog.DisposeAsync();
            }
        }

        private static async Task WriteLogAsync(string msg)
        {
            msg = $"{DateTime.UtcNow:dd.MM.yyyy HH:mm:ss}\t|\t{msg}";
            Console.WriteLine( msg);
            if (streamWriterLog != null)
            {
                await streamWriterLog.WriteLineAsync(msg);
                await streamWriterLog.FlushAsync();
            }
        }
        #endregion



        #region Port checking
        private static async Task<bool> IsPortAvailableAsync(IPAddress ip, TcpConnectionInformation[] tcpConnectionInformations, int port)
        {
            await WriteLogAsync($"Checking state of port {port}.");
            var active = tcpConnectionInformations.Any(c => c.LocalEndPoint.Address.Equals(IPAddress.Parse(ip.ToString())) &&
                                                            c.LocalEndPoint.Port == port &&
                                                            c.State == TcpState.Established);
            await WriteLogAsync($"Port state {port} = {ActiveToString(active)}.");

            return active;
        }
        #endregion


        #region Recordings check
        private static async Task<bool> HasRecordingsAsync()
        {
            bool retval = false;

            // Checking for VDR recordings ?
            await WriteLogAsync("Checking VDR started recordings.");
            try
            {
                var di = new DirectoryInfo("/tmp");
                var recordings = di.GetDirectories("vdrec_*");
                var count = recordings != null ? recordings.Length : 0;
                await WriteLogAsync($"{count} VDR recordings found.");
                retval = count > 0;
            }
            catch (Exception ex)
            {
                await WriteLogAsync(ex.Message);
            }

            return retval;
        }
        #endregion

        #region VDR timer
        private static async Task<List<Model.Timer>> GetTimerListAsync()
        {
            var list = new List<Model.Timer>();
            try
            {
                var count = 1;
                using (var sr = new StreamReader("/var/lib/vdr/timers.conf"))
                {
                    string? line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        var timer = new Model.Timer(line);
                        list.Add(timer);
                        var ts = timer.Stop - timer.Start;
                        await WriteLogAsync($"Get timer {count} {timer.Number} # { timer.Start} - {timer.Stop} {ts.TotalMinutes}");
                        count++;
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                await WriteLogAsync(ex.Message);
            }

            return list;
        }

        private static async Task<bool> HasNextOrVeryCloseTimerAsync(List<Model.Timer> list, int seconds)
        {
            await WriteLogAsync($"Checking next or very close timer.");
            var now = DateTime.Now;
            var retval = list.FirstOrDefault(t => (now - t.Start).TotalSeconds > 0 && (now - t.Start).TotalSeconds <= seconds);
            await WriteLogAsync($"Next or very close timer {TimerToString(retval)}.");

            return retval != null;
        }
        #endregion

        #region Process checking
        private static async Task<bool> IsProcessRunningAsync(Process[] processes, string processName)
        {
            await WriteLogAsync($"Checking process {processName}.");
            var running = processes.Any(p => p.ProcessName == processName);
            await WriteLogAsync($"Process {processName} {RunningToString(running)}.");

            return running;
        }
        #endregion

        #region UpTime checking
        private static async Task<bool> IsMinUpTimeAsync(int seconds)
        {
            var reached = false;

            await WriteLogAsync($"Checking minimum up time min {seconds} sec.");
            try
            {
                var up = 0;
                using (var sr = new StreamReader("/proc/uptime"))
                {
                    string? line = await sr.ReadLineAsync();
                    if (line != null)
                    {
                        var parts = line.Split(" ");
                        up = Convert.ToInt32(Convert.ToDouble(parts[0]));

                        reached = (up >= seconds);
                    }
                    sr.Close();
                }
                await WriteLogAsync($"Up/min time {up}/{seconds} sec {ReachedToString(reached)}.");
            }
            catch (Exception ex)
            {
                await WriteLogAsync(ex.Message);
            }

            return !reached;
        }
        #endregion

        #region Helper
        private static string ActiveToString(bool active)
        {
            return active ? "Active" : "Inactive";
        }

        private static string ReachedToString(bool reached)
        {
            return reached ? "Reached" : "Unreached";
        }

        private static string RunningToString(bool running)
        {
            return running ? "Running" : "Unknown";
        }

        private static string TimerToString(Model.Timer? timer)
        {
            return timer != null ? $"Found at {timer.Start}" : "Not found";
        }
        #endregion
    }
}