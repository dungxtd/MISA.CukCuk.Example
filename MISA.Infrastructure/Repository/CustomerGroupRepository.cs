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
    public class CustomerGroupRepository :BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
        public bool CheckCustomerGroupNameExists(string customerGroupName)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_CustomerGroupName", customerGroupName);

                var rowsEffect = dbConnection.QueryFirstOrDefault<bool>("Proc_CheckCustomerGroupNameExists", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowsEffect;
            }
        }
    }
}
