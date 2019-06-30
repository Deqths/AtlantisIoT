using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class SoundLevelSensor : Device
    {
        public SoundLevelSensor()
        {
            id = null;
            name = "SoundLevelSensor";
            type = "SoundLevel Sensor";
            metric = "0";

            generateMac();
        }
    }
}
