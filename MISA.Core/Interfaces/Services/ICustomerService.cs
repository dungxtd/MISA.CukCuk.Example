﻿using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Service phục vụ cho khách hàng
    /// </summary>
    /// CreatedBy: TDDUNG (27/4/2021)
    public interface ICustomerService
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public IEnumerable<Customer> GetAll();
        /// <summary>
        /// Lấy dữ liệu khách hàng theo Id
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public Customer GetById(Guid customerId);
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public int Insert(Customer customer);
        /// <summary>
        /// Sửa dữ liệu khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public int Update(Customer customer);
        /// <summary>
        /// Xoá dữ liệu khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public int Delete(Guid customerId);

    }
}