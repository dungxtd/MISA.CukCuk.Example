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
            // Khởi tạo kết nối
            //Check dữ liệu
            return true;
        }

        public bool CheckPhoneNumberExits(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetInRange(int fromIndex, int numberOfRecords, string fullName, Guid? groupId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                string cmdString = "";
                if (groupId != null)
                    cmdString = $"SELECT * FROM Customer c WHERE " + "c.FullName LIKE CONCAT(\"%\", " + "\"" + fullName + "\"" + $" ,\"%\") AND c.CustomerGroupId = '{groupId}'" + " LIMIT " + fromIndex + " , " + numberOfRecords + " ; ";
                else
                    cmdString = $"SELECT * FROM Customer c WHERE " + "c.FullName LIKE CONCAT(\"%\", " + "\"" + fullName + "\"" + $" ,\"%\")" + " LIMIT " + fromIndex + " , " + numberOfRecords + " ; ";
                var customers = dbConnection.Query<Customer>(cmdString, commandType: CommandType.Text);
                return customers;
            }
        }
    }
}
