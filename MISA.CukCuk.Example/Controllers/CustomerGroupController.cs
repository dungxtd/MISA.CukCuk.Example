using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
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
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        ICustomerGroupService _customerGroupService;
        public CustomerGroupController(ICustomerGroupService customerGroupService) : base(customerGroupService)
        {
            _customerGroupService = customerGroupService;
        }
    }
}
