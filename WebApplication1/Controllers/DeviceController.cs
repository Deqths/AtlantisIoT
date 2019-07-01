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
        // GET: v1/Device
        [HttpGet()]
        public string get()
        {
            httpResponse.ContentType("plain/text");
            return "Hello2";
            //add to DB
            //responses == 200 || 405
        }

        // POST: v1/Device
        [HttpPost]
        public string Post([FromBody]string value)
        {
            Guid guid = new Guid();
            string name = "testname";
            string deviceType = "PresenceSensor";
            string json = "{ \"id\": \"" + guid + "\", " + " \"name\": \"" + name + "\", \"deviceType\": \"" + deviceType + "\" }";

            Response.Clear();
            Response.ContentType = "application/json";
            return json;
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
