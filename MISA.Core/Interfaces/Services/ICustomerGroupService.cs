using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface ICustomerGroupService
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public IEnumerable<CustomerGroup> GetAll();
        /// <summary>
        /// Lấy dữ liệu khách hàng theo Id
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public CustomerGroup GetById(Guid customerGroupId);
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public int Insert(CustomerGroup customerGroup);
        /// <summary>
        /// Sửa dữ liệu khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public int Update(CustomerGroup customerGroup);
        /// <summary>
        /// Xoá dữ liệu khách hàng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TDDUNG(27/01/2021)
        public int Delete(Guid customerGroupId);
    }
}
