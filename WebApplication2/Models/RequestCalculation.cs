using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RequestCalculation
    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Mac { get; set; }
        public RequestType Type { get; set; }

        public enum RequestType
        {
            day,
            month,
            year
        }
    }
}