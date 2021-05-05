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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        public bool CheckCustomerCodeExits(string customerCode)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_CustomerCode", customerCode);

                var rowsEffect = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerCodeExists", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowsEffect;
            }
        }

        public bool CheckPhoneNumberExits(string phoneNumber)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_PhoneNumber", phoneNumber);

                var rowsEffect = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckPhoneNumberExists", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowsEffect;
            }
        }

        public bool CheckEmailExists(string email)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_Email", email);

                var rowsEffect = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckEmailExists", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowsEffect;
            }
        }
    }
}
