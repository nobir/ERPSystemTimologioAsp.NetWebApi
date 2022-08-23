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
    public class UserService
    {
        public static bool Create(UserDTO user)
        {
            var _user = Mapping.Mapper.Map<User>(user);

            return DataAccessFactory.GetUserDataAccess().Create(_user);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GetUserDataAccess().Delete(id);
        }

        public static UserDTO Get(int id)
        {
            var user = Mapping.Mapper.Map<UserDTO>(DataAccessFactory.GetUserDataAccess().Get(id));

            return user;
        }

        public static UserDTO GetByEmail(string email)
        {
            var user = Mapping.Mapper.Map<UserDTO>(DataAccessFactory.GetUserDataAccess().GetByEmail(email));

            return user;
        }

        public static List<UserDTO> Gets()
        {
            var users = Mapping.Mapper.Map<List<UserDTO>>(DataAccessFactory.GetUserDataAccess().Gets());

            return users;
        }

        public static bool Update(UserDTO user)
        {
            var _user = Mapping.Mapper.Map<User>(user);

            return DataAccessFactory.GetUserDataAccess().Update(_user);
        }
    }
}
