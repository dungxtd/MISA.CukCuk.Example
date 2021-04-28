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
    public class CustomerGroupRepository : ICustomerGroupRepository
    {
        

        public IEnumerable<CustomerGroup> GetAll()
        {
            {
                String connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "convert zero datetime=true";

                IDbConnection dbConnection = new MySqlConnection(connectionString);
                var customerGroups = dbConnection.Query<CustomerGroup>("Proc_GetCustomerGroups", commandType: CommandType.StoredProcedure);
                return customerGroups;
            }
        }

        public CustomerGroup GetById(Guid customerGroupId)
        {
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
                dynamicParameters.Add("@CustomerGroupId", customerGroupId);
                var customerGroups = dbConnection.QueryFirstOrDefault<CustomerGroup>("Proc_GetCustomerGroupById", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return customerGroups;
            }
        }

        public int Insert(CustomerGroup customerGroup)
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
            dynamicParameters.Add("@customerGroup", customerGroup);
            var rowsAffect = dbConnection.Execute("Proc_InsertCustomerGroup", param: customerGroup, commandType: CommandType.StoredProcedure);
            return rowsAffect;

        }

        public int Update(CustomerGroup customerGroup)
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
            dynamicParameters.Add("@customerGroup", customerGroup);
            var rowsAffect = dbConnection.Execute("Proc_UpdateCustomerGroup", param: customerGroup, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public int Delete(Guid customerGroupId)
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
            dynamicParameters.Add("@customerGroupId", customerGroupId);
            var rowsAffect = dbConnection.Execute("Proc_DeleteCustomerGroup", param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
