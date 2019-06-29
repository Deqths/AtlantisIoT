using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class HumiditySensor : Device
    {
        public HumiditySensor()
        {
            id = null;
            name = "HumiditySensor";
            type = "Humidity Sensor";
            metric = "0";

            generateMac();
        }
    }
}
