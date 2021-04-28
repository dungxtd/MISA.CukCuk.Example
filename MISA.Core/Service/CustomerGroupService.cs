using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    public class CustomerGroupService : ICustomerGroupService
    {
        ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;

        }
        public int Delete(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerGroup> GetAll()
        {
            return _customerGroupRepository.GetAll();
        }

        public CustomerGroup GetById(Guid customerGroupId)
        {
            return _customerGroupRepository.GetById(customerGroupId);
        }

        public int Insert(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }

        public int Update(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }
    }
}
