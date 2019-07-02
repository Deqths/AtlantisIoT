using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public static class MQTTuser
    {

        public static IMqttClient MQTTClient = null;

        public static async Task InitializeMQTT()
        {
            if (MQTTClient != null)
            {
                var factory = new MqttFactory();
                MQTTClient = factory.CreateMqttClient();
            }
            if (!MQTTClient.IsConnected)
            {
                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer("127.0.0.1", 1883) // Port is optional
                    .Build();
                await MQTTClient.ConnectAsync(options);
            }
        }

        public static async Task publish(Telemetry value)
        {
            string telemetry = "{  \"metricDate\" : \" " + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
                    + "\", \"name\" : \"" + value.name
                    + "\", \"macAddress\" : \"" + value.macAddress
                    + "\", \"deviceType\" : \"" + value.deviceType
                    + "\", \"metricValue\" : \"" + value.metricValue + "\"}";

            var message = new MqttApplicationMessageBuilder()
                .WithTopic("/Device")
                .WithPayload(telemetry)
                .Build();

            await MQTTClient.PublishAsync(message);
        }

    }
}