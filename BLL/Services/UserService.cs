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

        public static List<UserDTO> GetBySearch(string search_by, string search_value)
        {
            var users = Mapping.Mapper.Map<List<UserDTO>>(DataAccessFactory.GetUserDataAccess().Gets());

            if (search_by.Trim().Length == 0)
            {
                users = users.Where(u => u.Verified == 1).ToList();
            }
            else if (search_by.Equals("Id"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Id.ToString().ToLower() == search_value.ToString().ToLower()) select user).ToList();
            }
            else if (search_by.Equals("Username"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Username.ToString().ToLower() == search_value.ToString().ToLower()) select user).ToList();
            }
            else if (search_by.Equals("Name"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where user.Name.ToString().ToLower().Contains(search_value.ToString().ToLower()) select user).ToList();
            }
            else if (search_by.Equals("Email"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Name.ToString().ToLower() == search_value.ToString().ToLower()) select user).ToList();
            }
            else if (search_by.Equals("LocalAddress"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Address.LocalAddress.ToString().ToLower().Contains(search_value.ToString().ToLower())) select user).ToList();
            }
            else if (search_by.Equals("PoliceStation"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Address.PoliceStation.ToString().ToLower().Contains(search_value.ToString().ToLower())) select user).ToList();
            }
            else if (search_by.Equals("City"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Address.City.ToString().ToLower().Contains(search_value.ToString().ToLower())) select user).ToList();
            }
            else if (search_by.Equals("ZipCode"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Address.ZipCode.ToString().ToLower().Contains(search_value.ToString().ToLower())) select user).ToList();
            }
            else if (search_by.Equals("Country"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Address.Country.ToString().ToLower().Contains(search_value.ToString().ToLower())) select user).ToList();
            }
            else if (search_by.Equals("Region"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Region != null && user.Region.Name.ToString().ToLower().Contains(search_value.ToString().ToLower())) select user).ToList();
            }
            else if (search_by.Equals("Branch"))
            {
                users = users.Where(u => u.Verified == 1).ToList();
                users = (from user in users where (user.Branch != null && user.Branch.Name.ToString().ToLower().Contains(search_value.ToString().ToLower())) select user).ToList();
            }
            else if (search_by.Equals("Permission"))
            {
                users = (from user in users.Where(u => u.Verified == 0).ToList() where user.Permissions.Any(p => p.Name.ToString().ToLower().Contains(search_value.ToString().ToLower())) select user).ToList();
            }
            else
            {
                users = users.ToList();
            }

            return users;
        }

        public static UserDTO GetByUsername(string username)
        {
            var user = Mapping.Mapper.Map<UserDTO>(DataAccessFactory.GetUserDataAccess().GetByUsername(username));

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
