using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nito.AsyncEx;
using Newtonsoft.Json;

namespace ConsoleApp1
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
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("127.0.0.1", 1883) // Port is optional
                .Build();

            Console.WriteLine("### SETUP ###");
            Console.WriteLine("+TCP Server = 127.0.0.1");
            Console.WriteLine("+Port = 1883");

            Console.WriteLine("### TRYING TO CONNECT ###");
            await mqttClient.ConnectAsync(options);
            Console.WriteLine("### SUBSCRIBING TO TOPIC 'test' ###");
            await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("test").Build());

            mqttClient.UseDisconnectedHandler(async e =>
            {
                Console.WriteLine("### DISCONNECTED FROM SERVER ###");
                await Task.Delay(TimeSpan.FromSeconds(5));

                try
                {
                    await mqttClient.ConnectAsync(options);
                    await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("test").Build());
                }
                catch
                {
                    Console.WriteLine("### RECONNECTING FAILED ###");
                }
            });

            mqttClient.UseApplicationMessageReceivedHandler(e =>
            {

                Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                Console.WriteLine($"+ Other = {e.ApplicationMessage}");
                Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                Console.WriteLine();

                /* JSON SERIALIZE/DESERIALIZE
                dynamic json = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                json.name = "ok";
                Console.WriteLine(JsonConvert.SerializeObject(json));
                */
            });

        }
    }
}
