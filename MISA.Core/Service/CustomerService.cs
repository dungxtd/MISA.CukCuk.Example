using MISA.Core.AttributeCustom;
using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MISA.Core.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        /// <summary>
        /// Validate
        /// </summary>
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected override void CustomValidate(Customer entity)
        {
            if(entity is Customer)
            {
                var customer = entity;
                //Tên khách hàng không được phép để trống
                if (string.IsNullOrEmpty(customer.Fullname))
                {
                    throw new Exception("Tên khách hàng không được phép để trống");
                }

                //Check các thông tin bắt buộc nhập


                //Check trùng mã
                var isExits = _customerRepository.CheckCustomerCodeExits(customer.CustomerCode);
                if (isExits)
                {
                    //throw new Exception("Mã khách hàng đã tồn tại trên hệ thống.");
                }
            }
        }

        public IEnumerable<Customer> GetPaging(int pageIndex, int pageSize)
        {
            if (pageIndex <= 0 || pageSize <= 0) throw new BadRequestException("Page size và page index phải là số nguyên");
            var customers = _customerRepository.GetPaging(pageIndex, pageSize);
            return customers;
        }
    }
}
