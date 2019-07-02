using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Devices
{
    class AtmPressureSensor : Device
    {
        public AtmPressureSensor()
        {
            id = "";
            name = "";
            type = Types.atmosphericPressureSensor.ToString();
            metric = "0";
            generateMac();

        }
    }
}
