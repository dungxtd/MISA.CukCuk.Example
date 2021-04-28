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



        /// <summary>
        /// Lấy dữ liệu toàn bộ nhóm khách hàng
        /// </summary>
        /// <returns>
        /// StatusCode: 200 - có dữ liệu trả về
        /// StatusCode: 204 - không có dữ liệu trả về
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            var customerGroups = _customerGroupRepository.GetAll();
            if (customerGroups.Count() > 0)
            {
                return Ok(customerGroups);
            }
            else return NoContent();
        }


        /// <summary>
        /// Lấy dữ liệu nhóm khách hàng theo Id  
        /// </summary>
        /// <returns>
        /// StatusCode: 200 - có dữ liệu trả về
        /// StatusCode: 204 - không có dữ liệu trả về
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpGet("customerGroupId")]
        public IActionResult GetById(Guid customerGroupId)
        {
            var customerGroupById = _customerGroupRepository.GetById(customerGroupId);
            if (customerGroupById != null)
            {
                return Ok(customerGroupById);
            }
            else return NoContent();
        }

        /// <summary>
        /// Sửa thông tin nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">Thông tin đối lượng nhóm khách hàng</param>
        /// <returns>
        /// StatusCode: 200 - Sửa thành công
        /// StatusCode: 204 - Không sửa được ở data base
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpPut]
        public IActionResult Update(CustomerGroup customerGroup)
        {
            var res = _customerGroupService.Update(customerGroup);
            if (res > 0)
            {
                return Ok( res);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Thêm mới nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">Thông tin đối tượng nhóm khách hàng</param>
        /// <returns>
        /// StatusCode: 200 - Thêm mới thành công
        /// StatusCode: 204 - Không thêm mới được vào data base
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpPost]
        public IActionResult Post(CustomerGroup customerGroup)
        {
            var res = _customerGroupService.Insert(customerGroup);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }


        /// <summary>
        /// Xoá nhóm khách hàng
        /// </summary>
        /// <param name="customerGroupId">Id của nhóm khách hàng</param>
        /// <returns>
        /// StatusCode: 200 - Xoá thành công
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpDelete]
        public IActionResult Delete(Guid customerGroupId)
        {
            var res = _customerGroupService.Delete(customerGroupId);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
