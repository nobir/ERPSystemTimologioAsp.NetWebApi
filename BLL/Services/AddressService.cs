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
    public class AddressService
    {
        public static bool Create(AddressDTO address)
        {
            var _address = Mapping.Mapper.Map<Address>(address);

            return DataAccessFactory.GetAddressDataAccess().Create(_address);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GetAddressDataAccess().Delete(id);
        }

        public static AddressDTO Get(int id)
        {
            return Mapping.Mapper.Map<AddressDTO>(DataAccessFactory.GetAddressDataAccess().Get(id));
        }

        public static List<AddressDTO> Gets()
        {
            return Mapping.Mapper.Map<List<AddressDTO>>(DataAccessFactory.GetAddressDataAccess().Gets());
        }

        public static bool Update(AddressDTO address)
        {
            var _address = Mapping.Mapper.Map<Address>(address);

            return DataAccessFactory.GetAddressDataAccess().Update(_address);
        }
    }
}
