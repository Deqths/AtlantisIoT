using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class GpsSensor : Device
    {
        public GpsSensor()
        {
            id = null;
            name = "GpsSensor";
            type = Types.gpsSensor.ToString();

            generateGPSMetric();
            generateMac();
        }
        public void generateGPSMetric() {
            metric = $"N;{rand.Next(-100, 100)};{rand.Next(-100, 100)};{rand.Next(-100, 100)}.{rand.Next(0, 99)};E;{rand.Next(-100, 100)};{rand.Next(-100, 100)};{rand.Next(-100, 100)}.{rand.Next(0, 99)}";
            OnPropertyChanged(metric);
        }
    }
}
