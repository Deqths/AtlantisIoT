using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("v1/Device")]
    public class DeviceController : Controller
    {
        // POST: v1/Device
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return "hello";
            //add to DB
            //responses == 200 || 405
        }

        // POST: v1/Device
        [HttpPost("{id}/telemetry")]
        public string PostTelemetry([FromBody]string value)
        {
            return "Hello2";
            //add to DB
            //responses == 200 || 405
        }
    }
}
