using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CalculationController : ApiController
    {
        // POST: api/Calculation
        [HttpPost]
        [ActionName("Calculation")]
        [Route("v1/calculation")]
        public IEnumerable<int> Post(RequestCalculation req)
        {
            if (req.Type.ToString() == RequestCalculation.RequestType.day.ToString())
            {
                //SQL select Avg where Date
                return new int[] { 3, 4 };
            } else if (req.Type.ToString() == RequestCalculation.RequestType.month.ToString())
            {
                //SQL select AVG where Date > BeginTime && < EndTime, group by day
                return new int[] { 4, 5 };
            } else if (req.Type.ToString() == RequestCalculation.RequestType.day.ToString())
            {
                //SQL select AVG where Date > BeginTime && < EndTime, group by day
                return new int[] { 5, 6 };
            } else
            {
                return null;
            }
        }
    }
}
