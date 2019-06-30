using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class LED : Device
    {
        public LED()
        {
            id = null;
            name = "LED";
            type = "LED";
            metric = "0";

            generateMac();
        }
    }
}
