﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class LightSensor : Device
    {
        public LightSensor()
        {
            id = null;
            name = "LightSensor";
            type = Types.brightnessSensor.ToString();
            metric = "0";

            generateMac();
        }
    }
}
