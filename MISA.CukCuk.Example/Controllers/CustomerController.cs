using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Data;
using System.Linq;
using MISA.Core.Interfaces.Services;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Entities;
using MISA.Core.Service;

namespace MISA.CukCuk.Example.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]


    public class CustomerController : BaseController<Customer>
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService): base(customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("paging")]
        public IActionResult GetPaging(int pageIndex, int pageSize)
        {
            var customers = _customerService.GetPaging( pageIndex,  pageSize);
            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
