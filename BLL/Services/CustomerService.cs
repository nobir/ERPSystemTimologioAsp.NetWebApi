using BLL.BOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   public class CustomerService
    {
        public static bool Create(CustomerDTO Customer)
        {
            var _customer = Mapping.Mapper.Map<Customer>(Customer);

            return DataAccessFactory.GetCustomerDataAccess().Create(_customer);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GetCustomerDataAccess().Delete(id);
        }

        public static CustomerDTO Get(int id)
        {
            return Mapping.Mapper.Map<CustomerDTO>(DataAccessFactory.GetCustomerDataAccess().Get(id));
        }

        public static List<CustomerDTO> Gets()
        {

            return Mapping.Mapper.Map<List<CustomerDTO>>(DataAccessFactory.GetCustomerDataAccess().Gets());
        }

        public static bool Update(CustomerDTO Customer)
        {
            var _customer = Mapping.Mapper.Map<Customer>(Customer);

            return DataAccessFactory.GetCustomerDataAccess().Update(_customer);
        }
    }
}
