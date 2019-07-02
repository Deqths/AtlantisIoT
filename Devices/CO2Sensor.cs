using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class CO2Sensor : Device
    {
        public CO2Sensor()
        {
            id = null;
            name = "CO2Sensor";
            type = Types.co2Sensor.ToString();
            metric = "0";

            generateMac();
        }
    }
}
