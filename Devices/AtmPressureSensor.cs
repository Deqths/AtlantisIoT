using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Devices
{
    class AtmPressureSensor : Device, INotifyPropertyChanged
    {
        public AtmPressureSensor()
        {
            id = "try";
            name = "AtmPressureSensor";
            type = "AtmPressure Sensor";
            metric = "0";
            generateMac();

        }
    }
}
