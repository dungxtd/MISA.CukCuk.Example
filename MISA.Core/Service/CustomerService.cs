﻿using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        public int Delete(Guid customerId)
        {
            var rowsAffect = _customerRepository.Delete(customerId);
            return rowsAffect;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        public Customer GetById(Guid customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            return customer;
        }

        public int Insert(Customer customer)
        {

            //Validate dữ liệu
            //C
            var rowsAffect = _customerRepository.Insert(customer);
            return rowsAffect;
        }

        public int Update(Customer customer)
        {
            var rowsAffect = _customerRepository.Update(customer);
            return rowsAffect;
        }
    }
}
