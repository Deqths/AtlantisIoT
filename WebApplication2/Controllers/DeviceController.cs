using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using WebApplication2.Models;
using static WebApplication2.Models.MQTTuser;
using MQTTnet;
using MQTTnet.Client;
using System.Threading.Tasks;
using MQTTnet.Client.Options;

namespace WebApplication2.Controllers 
{
    public class DeviceController : ApiController
    {
        // POST: api/Device
        public Device Post(Device device)
        {
            device.id = Guid.NewGuid().ToString();
            device.name = "Default" + device.deviceType.ToString();
            return device;

        }

        // POST: v1/{id}/Telemetry
        [HttpPost]
        [Route("v1/device/{id}/Telemetry")]
        [ActionName("Telemetry")]
        public async Task<string> TelemetryAsync(int id, Telemetry value)
        {
            await InitializeMQTT();
            await publish(value);

            return "ok";
        }

        //public async Task TelemetryAsync(int id, Telemetry value)
        //{
        //    await InitializeMQTT();
        //    await publish(value);
        //}

    }
}
