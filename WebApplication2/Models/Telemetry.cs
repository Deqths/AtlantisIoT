using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Telemetry
    {
        public string name { get; set; } = "";
        public string macAddress { get; set; } = "";
        public string metricDate { get; set; } = "";
        public string deviceType { get; set; } = "";
        public string metricValue { get; set; } = "";
    }
}