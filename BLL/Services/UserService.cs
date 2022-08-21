using BLL.BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static List<UserDTO> Gets()
        {
            var users = Mapping.Mapper.Map<List<UserDTO>>(DataAccessFactory.GetUserDataAccess().Gets());

            return users;
        }
    }
}
