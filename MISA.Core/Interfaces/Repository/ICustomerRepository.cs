using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        public bool CheckCustomerCodeExits(String customerCode);
        public bool CheckPhoneNumberExits(String phoneNumber);
        public bool CheckEmailExists(String email);
    }
}
