using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApplication2.Controllers
{
    public class DeviceController : ApiController
    {
        // GET: api/Device
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Device/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Device
        public JsonResult<Device> Post([FromBody]string value)
        {
            return Json(new { name = "ok", id = "okok" })
        }

        // PUT: api/Device/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Device/5
        public void Delete(int id)
        {
        }
    }
}
