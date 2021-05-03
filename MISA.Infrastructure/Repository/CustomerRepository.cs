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
    }
}
