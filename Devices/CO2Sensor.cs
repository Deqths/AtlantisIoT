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
            type = "CO2 Sensor";
            metric = "0";

            generateMac();
        }
    }
}
