using JKang.IpcServiceFramework.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using vdrControlServiceExtension;

namespace TestApp
{
    class Program
    {
        // private static IpcServiceClient<IVdrServiceController> _client;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            RunClient();

            Console.ReadLine();
        }

        private static async void RunClient()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
            //.AddNamedPipeIpcClient<IInterProcessService>("client1", pipeName: "pipeinternal")
.AddTcpIpcClient<IVdrServiceController>("client1", IPAddress.Parse("192.168.0.252"), 45684)
.BuildServiceProvider();

            // resolve IPC client factory
            IIpcClientFactory<IVdrServiceController> clientFactory = serviceProvider
                .GetRequiredService<IIpcClientFactory<IVdrServiceController>>();

            // create client
            IIpcClient<IVdrServiceController> client = clientFactory.CreateClient("client1");


            //IpcServiceClient<IVdrServiceController> client = new IpcServiceClientBuilder<IVdrServiceController>()
            //    .UseNamedPipe("pipeVdrControlService") 
            //    .UseTcp(IPAddress.Parse(IP_ADDRESS), IP_PORT) //to invoke using TCP
            //    .Build();

            try
            {
                string output = await client.InvokeAsync(x => x.ReverseString("ABCDEFGH"));

                Console.WriteLine(output);

                bool b = await client.InvokeAsync(x => x.IsAlive());

                Console.WriteLine(b);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
