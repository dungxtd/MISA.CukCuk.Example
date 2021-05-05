using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository): base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
        protected override void CustomValidate(CustomerGroup entity)
        {
            if (entity is CustomerGroup)
            {
                var customerGroup = entity;
                //Check các thông tin bắt buộc nhập

                //Check trùng tên nhóm khách hàng
                var customerGroupNameExists = _customerGroupRepository.CheckCustomerGroupNameExists(customerGroup.CustomerGroupName);
                if (customerGroupNameExists)
                {
                    throw new BadRequestException("Tên nhóm khách hàng đã tồn tại trên hệ thống.");
                }
            }
        }
    }
}
