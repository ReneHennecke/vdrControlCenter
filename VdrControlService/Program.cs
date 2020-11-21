namespace VdrControlService
{
    using JKang.IpcServiceFramework;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Serilog;
    using Serilog.Enrichers;
    using Serilog.Events;
    using Serilog.Sinks.SystemConsole.Themes;
    using System;
    using System.IO;
    using System.Net;
    using vdrControlServiceExtension;

    class Program
    {
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            const string loggerTemplate = @"{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u4}]<{ThreadId}> [{SourceContext:l}] {Message:lj}{NewLine}{Exception}";
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var logfile = Path.Combine(baseDir, "logs", "log.txt");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.With(new ThreadIdEnricher())
                .Enrich.FromLogContext()
                //.WriteTo.ColoredConsole()
                .WriteTo.Console(LogEventLevel.Information, loggerTemplate, theme: AnsiConsoleTheme.Literate)
                .WriteTo.File(logfile, LogEventLevel.Information, loggerTemplate,
                    rollingInterval: RollingInterval.Day, retainedFileCountLimit: 90)
                .CreateLogger();

            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .AddEnvironmentVariables();

            Configuration = builder.Build();

            try
            {

                IPAddress ipAddress = IPAddress.Parse(Configuration["IPAddress"]);
                int ipPort = Convert.ToInt32(Configuration["IPPort"]);

                Log.Information("====================================================================");
                Log.Information($"Application Starts. Version: {System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version}");
                Log.Information($"Application Directory: {AppDomain.CurrentDomain.BaseDirectory}");
                Log.Information($"Application IP-Address/Port: {ipAddress}/{ipPort}");

                IServiceCollection services = ConfigureServices(new ServiceCollection());

                IServiceProvider provider = services.BuildServiceProvider();
                ILogger<VdrServiceController> logger = provider.GetService<ILogger<VdrServiceController>>();

                IIpcServiceHost host = new IpcServiceHostBuilder(provider)
                                                 .AddNamedPipeEndpoint<IVdrServiceController>(name: "endpoint1", pipeName: "pipeName")
                                                 .AddTcpEndpoint<IVdrServiceController>(name: "endpoint2", ipEndpoint: ipAddress, port: ipPort)
                                                 .Build();
                
                host.Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Application terminated unexpectedly");
            }
            finally
            {
                Log.Information("====================================================================\r\n");
                Log.CloseAndFlush();
            }
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services) =>
            services
                .AddLogging(configure => configure.AddSerilog())
                .AddTransient<VdrServiceController>()
                .AddSingleton(Configuration) ///
                .AddIpc(builder =>
                {
                    builder
                        .AddNamedPipe(options =>
                        {
                            options.ThreadCount = 2;
                        })
                        .AddService<IVdrServiceController, VdrServiceController>();
                });
            
    }
}
