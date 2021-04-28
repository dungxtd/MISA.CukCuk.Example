using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool CheckCustomerCodeExits(string customerCode)
        {
            // Khởi tạo kết nối
            //Check dữ liệu
            return true;
        }

        public bool CheckPhoneNumberExits(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid customerId)
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
            var rowsAffect = dbConnection.Execute("Proc_DeleteCustomer", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public IEnumerable<Customer> GetAll()
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
            return customers;
        }

        public Customer GetById(Guid customerId)
        {
            String connectionString = "" +
               "Host = 47.241.69.179;" +
               "Port = 3306;" +
               "Database = MF0_NVManh_CukCuk02;" +
               "User Id = dev;" +
               "Password = 12345678;";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@customerId", customerId);
            var customer = dbConnection.QueryFirstOrDefault<Customer>("Proc_GetCustomerById", dynamicParameters, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public int Insert(Customer customer)
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
            var rowsAffect = dbConnection.Execute("Proc_InsertCustomer", param: customer, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public int Update(Customer customer)
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
            var rowsAffect = dbConnection.Execute("Proc_UpdateCustomer", param: customer, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
