using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Example.Controllers
{
    [Route("api/v1/customer-group")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        ICustomerGroupRepository _customerGroupRepository;
        ICustomerGroupService _customerGroupService;
        public CustomerGroupController(ICustomerGroupRepository customerGroupRepository,
            ICustomerGroupService customerGroupService)
        {
            _customerGroupService = customerGroupService;
            _customerGroupRepository = customerGroupRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var customerGroups = _customerGroupRepository.GetAll();
            if (customerGroups.Count() > 0)
            {
                return Ok(customerGroups);
            }
            else return NoContent();
        }
    }
}
