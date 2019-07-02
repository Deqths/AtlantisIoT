using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Device
    {
        public string id { get; set; } = "";
        public string name { get; set; } = "";
        public Types deviceType { get; set; }
        public enum Types
        {
            presenceSensor,
            temperatureSensor,
            brightnessSensor,
            atmosphericPressureSensor,
            humiditySensor,
            soundLevelSensor,
            gpsSensor,
            co2Sensor,
            ledDevice,
            beeperDevice
        }
    }
}