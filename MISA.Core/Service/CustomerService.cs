using MISA.Core.AttributeCustom;
using MISA.Core.Entities;
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
        //public int Delete(Guid customerId)
        //{
        //    var rowsAffect = _customerRepository.Delete(customerId);
        //    return rowsAffect;
        //}

        //public IEnumerable<Customer> GetAll()
        //{
        //    var customers = _customerRepository.GetAll();
        //    return customers;
        //}

        //public Customer GetById(Guid customerId)
        //{
        //    //var customer = _customerRepository.GetById(customerId);
        //    var customer = _customerRepository.GetById(customerId);
        //    return customer;
        //}

        //public int Insert(Customer customer)
        //{

        //    //Validate dữ liệu
        //    //Check các thong tin bắt buộc phải nhập
        //    if (string.IsNullOrEmpty(customer.CustomerCode))
        //    {
        //        var response = new
        //        {
        //            devMsg = "Mã khách hàng không được phép để trống",
        //            MISACode = "001",
        //        };
        //        throw new Exception("Có lỗi xảy ra vui lòng liên hệ MISA.");
        //    }
        //    var rowsAffect = _customerRepository.Insert(customer);
        //    return rowsAffect;
        //}

        //public int Update(Customer customer)
        //{
        //    var rowsAffect = _customerRepository.Update(customer);
        //    return rowsAffect;
        //}
    }
}
