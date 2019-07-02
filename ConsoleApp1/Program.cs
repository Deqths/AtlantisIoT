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
using System.Threading;
using System.Collections;
using static ConsoleApp1.JMSSender;

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

            Dictionary<string, int> hashtable = new Dictionary<string, int>();
            Dictionary<string, int> average = new Dictionary<string, int>();
            Dictionary<string, int> averageEntries = new Dictionary<string, int>();

            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("127.0.0.1", 1883) // Port is optional
                .Build();

            Console.WriteLine("### SETUP ###");
            Console.WriteLine("+TCP Server = 127.0.0.1");
            Console.WriteLine("+Port = 1883");

            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    Console.WriteLine("### TRYING TO CONNECT ###");
                    await mqttClient.ConnectAsync(options);
                    break;
                }
                catch
                {
                    Console.WriteLine("### CONNECTION FAILED ###");
                }
            }

            Console.WriteLine("### SUBSCRIBING TO TOPIC '/device' ###");
            await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("/Device").Build());

            mqttClient.UseDisconnectedHandler(async e =>
            {
                Console.WriteLine("### DISCONNECTED FROM SERVER ###");
                await Task.Delay(TimeSpan.FromSeconds(5));

                try
                {
                    await mqttClient.ConnectAsync(options);
                    await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("/Device").Build());
                }
                catch
                {
                    Console.WriteLine("### RECONNECTING FAILED ###");
                }
            });

            mqttClient.UseApplicationMessageReceivedHandler(async e =>
            {
                dynamic json = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                string act = json.action.ToString();
                if (act == "metric")
                {

                    string name = json.name.ToString();
                    string metricDate = json.metricDate.ToString();
                    string mac = json.macAddress.ToString();
                    string deviceType = json.deviceType.ToString();
                    int value;
                    if (deviceType == "gpsSensor")
                    {
                        value = 0;
                    }
                    else
                    {
                        value = json.metricValue;
                    }

                    Console.WriteLine($"+ Device = {mac}");
                    Console.WriteLine($"+ Metric = {value}");
                    if (hashtable.ContainsKey(mac))
                    {
                        hashtable[mac] = hashtable[mac] + value;


                    }
                    else
                    {
                        hashtable.Add(mac, value);
                    }

                    if (average.ContainsKey(mac))
                    {
                        averageEntries[mac] = averageEntries[mac] + 1;
                        average[mac] = (hashtable[mac] / averageEntries[mac]);
                    }
                    else
                    {
                        average.Add(mac, value);
                        averageEntries.Add(mac, 1);

                    }

                    JMSSender.Send(mac, "Jms/AuthDevice");
                    JMSSender.Send(JsonConvert.SerializeObject(json), "");

                    //Console.WriteLine($"+ sum = {hashtable[mac]}");
                    //Console.WriteLine($"+ sum = {averageEntries[mac]}");
                    //Console.WriteLine($"+ avg = {average[mac]}");
                } else if (act == "Register")
                {
                    JMSSender.Send(json.mac.ToString());
                } else if (act == "")
                {

                }
            });

        }
    }
}
