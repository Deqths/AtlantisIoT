﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class TemperatureSensor : Device
    {
        public TemperatureSensor()
        {
            id = null;
            name = "TemperatureSensor";
            type = Types.temperatureSensor.ToString();
            metric = "0";

            generateMac();
        }
    }
}
