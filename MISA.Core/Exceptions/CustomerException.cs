using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Exceptions
{
    public class CustomerException: SystemException
    {
        public CustomerException(string msg) : base(msg)
        {

        }
        public static void CheckCustomerCodeEmpty(string CustomerCode)
        {
            if (string.IsNullOrEmpty(CustomerCode))
            {
                var response = new
                {
                    devMsg = "Mã khách hàng không được phép để trống",
                    MISACode = "001"
                };
                throw new CustomerException("Mã khách hàng không được phép để trống");
            }
        }
        ///<summary>
        /// Hàm kiểm tra tồn tại của Id khách hàng.
        /// </summary>
        /// <param name="customerId">Id của khách hàng</param>

        public static void CheckCustomerIdEmpty(Guid customerId)
        {
            if (string.IsNullOrEmpty(customerId.ToString()))
            {
                throw new CustomerException("Id khách hàng không được để trống.");
            }
        }

        ///<summary>
        /// Hàm kiểm tra tồn tại của Id khách hàng.
        /// </summary>
        /// <param name="Email">Id của khách hàng</param>

        public static void CheckCustomerEmailEmpty(string Email)
        {
            if (string.IsNullOrEmpty(Email.ToString()))
            {
                throw new CustomerException("Email khách hàng không được để trống.");
            }
        }
    }
}
