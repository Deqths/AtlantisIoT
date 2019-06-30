using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        public string Metric { get { return metric; } set { metric = value; OnPropertyChanged(Metric);  } }
        // Defines if the Device is sending metrics or not
        public bool sendState = false;     
        public bool SendState { get { return sendState; } set { SendState = value; OnPropertyChanged(SendState.ToString()); } }
        // Defines if the Device is sending metrics or not
        public bool power = true;     
        public bool Power { get { return power; } set { power = value; OnPropertyChanged(Power.ToString()); } }
        // Static Random for all instances
        protected static Random rand = new Random();


        // Property change notification handling
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
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
            try
            {
                //
                return true;
            }
            catch
            {
                //
                return false;
            }
        }

        // Starts the process of sending metrics
        public void MetricStart()
        {

        }

        // Stops the process of sending metrics
        public void MetricStop()
        {
            
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
                generateMetric();
                if (sendState)
                {
                    Console.WriteLine("Sending metrics");
                } else
                {
                    Console.WriteLine("Trying to register");
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
