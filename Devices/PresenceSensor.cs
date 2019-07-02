using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class PresenceSensor : Device
    {
        public PresenceSensor()
        {
            id = null;
            name = "PresenceSensor";
            type = Types.presenceSensor.ToString();
            metric = "0";

            generateMac();
        }
    }
}
