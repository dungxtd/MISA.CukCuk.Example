using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Example.Model;
using MySqlConnector;
using System;
using System.Data;
using System.Linq;


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
                "Password = 12345678;" +
                "convert zero datetime=true";

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
            "Password = 12345678;" +
            "convert zero datetime=true";

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

        [HttpGet("{customerId}")]
        public ActionResult Get(Guid customerId)
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
            dynamicParameters.Add("@customerId", customerId.ToString());
            var customerById = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", dynamicParameters, commandType: CommandType.StoredProcedure);
            if (customerById != null)
            {
                return Ok(customerById);
            }
            else return NoContent();
        }

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

        [HttpDelete]
        public ActionResult Delete(Guid customerId)
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
            dynamicParameters.Add("@CustomerId", customerId.ToString());
            var deleteStatus = dbConnection.Execute("Proc_DeleteCustomer", dynamicParameters, commandType: CommandType.StoredProcedure);
            var response = new
            {
                devMsg = "Mã khách hàng không tồn tại trong hệ thống.",
                MISACode = "003",
            };
            if (deleteStatus == 1)
                return StatusCode(200, 1);
            return StatusCode(400, response);
        }



    }
}
