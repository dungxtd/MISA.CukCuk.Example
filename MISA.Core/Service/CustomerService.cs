using MISA.Core.AttributeCustom;
using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections;
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
                //Check các thông tin bắt buộc nhập

                //Check trùng mã
                var codeIsExits = _customerRepository.CheckCustomerCodeExits(customer.CustomerCode);

                //Check trùng số điện thoại
                var phoneNumberIsExits = _customerRepository.CheckPhoneNumberExits(customer.PhoneNumber);

                //Check trùng email
                var emailExists = _customerRepository.CheckEmailExists(customer.Email);

                var checkExitsOptions = new Dictionary<string, bool>();
                    checkExitsOptions["Mã nhân viên"] = codeIsExits;
                    checkExitsOptions["Số điện thoại"] = phoneNumberIsExits;
                    checkExitsOptions["Email"] = emailExists;
                string errorString = string.Empty;
                foreach (KeyValuePair<string, bool> option in checkExitsOptions)
                {
                    if (option.Value)
                    {
                        errorString += option.Key + ", ";
                    }
                }
                if (!string.IsNullOrEmpty(errorString))
                {
                    errorString = errorString.Substring(0, errorString.Length - 2);
                    errorString += " đã tồn tại trên hệ thống.";
                    throw new BadRequestException(errorString);
                }
            }
        }
    }
}
