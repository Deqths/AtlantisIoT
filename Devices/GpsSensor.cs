using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class GpsSensor : Device
    {
        public GpsSensor()
        {
            Random rand = new Random();
            id = null;
            name = "GpsSensor";
            type = "GPS Sensor";

            generateGPSMetric();
            generateMac();
        }
        public void generateGPSMetric() {
            Random rand = new Random();
            metric = $"N;{rand.Next(-100, 100)};{rand.Next(-100, 100)};{rand.Next(-100, 100)}.{rand.Next(0, 99)};E;{rand.Next(-100, 100)};{rand.Next(-100, 100)};{rand.Next(-100, 100)}.{rand.Next(0, 99)}";
            OnPropertyChanged(metric);
        }
    }
}
