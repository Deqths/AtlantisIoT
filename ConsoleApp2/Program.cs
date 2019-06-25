using MQTTnet;
using MQTTnet.Server;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
                        /* Server */
            var serverOptions = new MqttServerOptions();

            var mqttServer = new MqttFactory().CreateMqttServer();
            await mqttServer.StartAsync(serverOptions);
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
            await mqttServer.StopAsync();
            

            
        }
    }
}
