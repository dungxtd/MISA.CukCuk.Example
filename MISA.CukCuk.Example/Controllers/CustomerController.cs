using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;
using System.Data;
using MISA.CukCuk.Example.Model;


namespace MISA.CukCuk.Example.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            String connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password = 12345678;";

            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);

            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            else return NoContent();
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {

            String connectionString = "" +
            "Host = 47.241.69.179;" +
            "Port = 3306;" +
            "Database = MF0_NVManh_CukCuk02;" +
            "User Id = dev;" +
            "Password = 12345678;";

            IDbConnection dbConnection = new MySqlConnection(connectionString);

            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@m_CustomerCode", customer.CustomerCode);

            var customersCodeExists = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", dynamicParameters, commandType: CommandType.StoredProcedure);
            if (customersCodeExists == true)
            {
                var response = new
                {
                    devMsg = "Mã khách hàng đã tồn tại trong hệ thống.",
                    MISACode = "002",
                };
                return BadRequest(response);
            }

            var rowsAffect = dbConnection.Execute("Proc_InsertCustomer", param: customer, commandType: CommandType.StoredProcedure);
            if (rowsAffect > 0)
            {
                return StatusCode(201, rowsAffect);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
