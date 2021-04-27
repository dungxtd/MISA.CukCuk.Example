using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var customer = new Customer();
            return customer.Fullname;
        }

        [HttpGet("filter")]
        public int? GetName([FromQuery] string name, [FromQuery] int? age)
        {
            return age;
        }

        [HttpPost]
        public string Post([FromBody] string name)
        {
            var customer = new Customer();
            return customer.Fullname;
        }
    }
}
