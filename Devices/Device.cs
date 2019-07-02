using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Devices
{
    public abstract class Device : INotifyPropertyChanged
    {
        // ID Of the Device
        public string id;
        public string ID { get { return id; } set { id = value; OnPropertyChanged(ID); } }
        // Name of the Device
        public string name;        
        public string Name { get { return name; } set { name = value; OnPropertyChanged(Name); } }
        // MAC address of the Device
        public string macAddress;
        public string Mac { get { return macAddress; } }
        // Type of the Device
        public string type;        
        public string Type { get { return type; } }
        // Metrics percieveed (or State for non-sensors)
        public string metric;      
        public string Metric { get { return metric; } set { metric = value; OnPropertyChanged(Metric.ToString());  } }
        // Defines if the Device is sending metrics or not
        public bool sendState = false;     
        public bool SendState { get { return sendState; } set { sendState = value; OnPropertyChanged(sendState.ToString()); } }
        // Defines if the Device is sending metrics or not
        public bool power = true;     
        public bool Power { get { return power; } set { power = value; OnPropertyChanged(Power.ToString()); } }
        // Static Random for all instances
        protected static Random rand = new Random();

        public bool MQTTReady = false;
        public IMqttClient MQTTClient = null;

        public enum Types
        {
            presenceSensor,
            temperatureSensor,
            brightnessSensor,
            atmosphericPressureSensor,
            humiditySensor,
            soundLevelSensor,
            gpsSensor,
            co2Sensor,
            ledDevice,
            beeperDevice
        }

        // Property change notification handling
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        //MQTT
        public async Task InitializeMQTT()
        {
            var factory = new MqttFactory();
            MQTTClient = factory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()

                .WithTcpServer("127.0.0.1", 1883) // Port is optional
                .Build();
            try
            {
                await MQTTClient.ConnectAsync(options);
                await MQTTClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("/" + macAddress).Build());
                MQTTReady = true;
    }
            catch
            {
                Console.WriteLine("### CONNECTION OR SUBSCRUPTION FAILED ###");
                MQTTReady = false;
            }

            MQTTClient.UseApplicationMessageReceivedHandler(async e =>
            {
                string k = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                if (k == "on")
                {
                    Metric = "1";
                }
                else if (k == "off")
                {
                    Metric = "0";
                }
            });
        }

        /**
         * 
         * RegisterDevice()
         * Function to register the device on the platforms
         * This function is called when the device starts
         * the function returns true or false depending on
         * the success of the operation which will be used
         * to determine if it has to be called again or not
         * 
         */
        public bool RegisterDevice()
        {
            WebRequest request = WebRequest.Create("http://localhost:59885/v1/device");
            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{ \"ID\" : \" "+id+"\", \"Name\" : \""+name+ "\", \"deviceType\" : \""+type+"\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                dynamic json = JsonConvert.DeserializeObject(responseText);
                ID = json.id;
                Name = json.name;
                SendState = true;
            }

            if (sendState == true)
            {
                InitializeMQTT();
            }
            return true;
        }

        // Send metrics
        public async Task SendMetricsAsync()
        {
            if (MQTTReady)
            {
                string telemetry = "{  \"metricDate\" : \" " + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ") 
                    + "\", \"name\" : \"" + name
                    + "\", \"macAddress\" : \"" + macAddress
                    + "\", \"deviceType\" : \"" + type 
                    + "\", \"metricValue\" : \"" + metric + "\"}";

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("/Device")
                    .WithPayload(telemetry)
                    .Build();

                await MQTTClient.PublishAsync(message);
            } else
            {
                if (SendState)
                {
                    InitializeMQTT();
                }
                else
                {
                    RegisterDevice();
                }
            }
        }

        // Send metrics
        public async Task SendMetricsHTTP()
        {
            if (MQTTReady)
            {
                WebRequest request = WebRequest.Create("http://localhost:59885/v1/device/"+id+"/telemetry");
                request.ContentType = "application/json";
                request.Method = "POST";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {

                    //string json = "{ \"metricDate\" : \" " + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ") + "\", \"deviceType\" : \"" + type + "\", \"metricValue\" : \"" + metric + "\"}";

                    string telemetry = "{  \"metricDate\" : \" " + DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
                        + "\", \"name\" : \"" + name
                        + "\", \"macAddress\" : \"" + macAddress
                        + "\", \"deviceType\" : \"" + type
                        + "\", \"metricValue\" : \"" + metric + "\"}";

                    streamWriter.Write(telemetry);
                    streamWriter.Flush();
                }
            }
            else
            {
                if (SendState)
                {
                    InitializeMQTT();
                }
                else
                {
                    RegisterDevice();
                }
            }
        }

        public void generateMac()
        {
            const string chars = "ABCDEF0123456789";
            for (int i = 0; i < 6; i++)
            {
                string macpart = new string(Enumerable.Repeat(chars, 2).Select(s => s[rand.Next(chars.Length)]).ToArray());
                macAddress += macpart;
                if (i != 5)
                {
                    macAddress += ":";
                }
            }
        }

        public void tick()
        {

            if (power)
            {
                if (sendState)
                {
                    SendMetricsAsync();
                } else
                {
                    //RegisterDevice();
                }
            }
        }

        public void generateMetric()
        {
            metric = rand.Next(0, 100).ToString();
            OnPropertyChanged(metric);
        }
            
    }
}
