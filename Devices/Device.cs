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
        public string id;          // ID Of the Device
        public string ID { get { return id; } }
        public string name;        // Name of the Device
        public string Name { get { return name; } }
        public string macAddress;  // MAC address of the Device
        public string Mac { get { return macAddress; } }
        public string type;        // Type of the Device
        public string Type { get { return type; } }
        public string metric;      // Metrics percieveed (or State for non-sensors)
        public string Metric { get { return metric; } }
        public bool sendState;     // Defines if the Device is sending metrics or not
        public bool SendState { get { return sendState; } }

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
            Random rand = new Random();
            const string chars = "ABCDEF0123456789";
            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(rand.Next(20, 100));
                string macpart = new string(Enumerable.Repeat(chars, 2).Select(s => s[rand.Next(chars.Length)]).ToArray());
                macAddress += macpart;
                if (i != 5)
                {
                    macAddress += ":";
                }
            }
        }

        public void generateMetric()
        {
            Random rand = new Random();
            metric = "0";
        }
            
    }
}
