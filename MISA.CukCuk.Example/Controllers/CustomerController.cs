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


    public class CustomerController : ControllerBase
    {


        ICustomerService _customerService;
        ICustomerRepository _customerRepository;



        public CustomerController(ICustomerService customerService, ICustomerRepository customerRepository)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
        }


        /// <summary>
        /// Lấy dữ liệu toàn bộ khách hàng
        /// </summary>
        /// <returns>
        /// StatusCode: 200 - có dữ liệu trả về
        /// StatusCode: 204 - không có dữ liệu trả về
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerRepository.GetAll();

            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            else return NoContent();
        }


        /// <summary>
        /// Lấy dữ liệu khách hàng theo Id  
        /// </summary>
        /// <returns>
        /// StatusCode: 200 - có dữ liệu trả về
        /// StatusCode: 204 - không có dữ liệu trả về
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpGet("{customerId}")]
        public ActionResult GetById(Guid customerId)
        {
            var customer = _customerService.GetById(customerId);
            if (customer != null)
            {
                return Ok(customer);
            }
            else return NoContent();
        }


        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thông tin đối lượng khách hàng</param>
        /// <returns>
        /// StatusCode: 200 - Thêm mới thành công
        /// StatusCode: 204 - Không thêm mới được vào data base
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var res = _customerService.Insert(customer);
            if (res > 0)
            {
                return StatusCode(201, res);
            }
            else
            {
                return NoContent();
            }
        }



        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin đối lượng khách hàng</param>
        /// <returns>
        /// StatusCode: 200 - Thêm mới thành công
        /// StatusCode: 204 - Không thêm mới được vào data base
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpPut]
        public ActionResult Put(Customer customer)
        {
            String connectionString = "" +
               "Host = 47.241.69.179;" +
               "Port = 3306;" +
               "Database = MF0_NVManh_CukCuk02;" +
               "User Id = dev;" +
               "Password = 12345678;" +
               "convert zero datetime=true";
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@customer", customer);
            var customerPut = dbConnection.Execute("Proc_UpdateCustomer", param: customer, commandType: CommandType.StoredProcedure);
            var response = new
            {
                devMsg = "Mã khách hàng không tồn tại trong hệ thống.",
                MISACode = "002",
            };
            if (customerPut == 1)
            {
                return StatusCode(200, customerPut);
            }
            else return BadRequest(response);



        }



        /// <summary>
        /// Xoá khách hàng
        /// </summary>
        /// <param name="customerId">Id của khách hàng</param>
        /// <returns>
        /// StatusCode: 200 - Thêm mới thành công
        /// StatusCode: 204 - Không thêm mới được vào data base
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpDelete]
        public ActionResult Delete(Guid customerId)
        {
            var res = _customerService.Delete(customerId);  
            if (res > 0)
                return Ok(res);
            else return NoContent();
        }



    }
}
