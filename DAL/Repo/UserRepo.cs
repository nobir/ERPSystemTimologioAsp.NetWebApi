using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepoUser<User, int, bool>
    {
        private static TimologioContext db;

        public UserRepo(TimologioContext db)
        {
            UserRepo.db = db;
        }

        public bool Create(User obj)
        {
            var _ps = new List<Permission>();
            foreach(var permission in obj.Permissions)
            {
                var _permission = db.Permissions.Find(permission.Id);
                var _p = db.Permissions.Attach(_permission);
                _ps.Add(_p);
            }
            obj.Permissions = _ps;
            db.Users.Add(obj);

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var user = db.Users.Find(id);

            if (user == null)
            {
                return false;
            }

            db.Addresses.Remove(user.Address);
            if (user.Region != null) db.Regions.Attach(user.Region);
            if (user.Branch != null) db.Branches.Attach(user.Branch);

            user.Permissions.Clear();

            db.Users.Remove(user);

            return db.SaveChanges() > 0;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public User GetByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return db.Users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public List<User> Gets()
        {
            return db.Users.ToList();
        }

        public bool Update(User obj)
        {
            var user = db.Users.Where(u => u.Id == obj.Id).SingleOrDefault();

            if (user == null)
            {
                return false;
            }

            var _ps = new List<Permission>();
            user.Permissions.Clear();
            foreach (var permission in obj.Permissions)
            {
                var _permission = db.Permissions.Find(permission.Id);
                var _p = db.Permissions.Attach(_permission);
                _ps.Add(_p);
            }
            user.Permissions = _ps;

            obj.Address = null;
            obj.AddressId = user.AddressId;
            obj.Permissions = _ps;

            db.Entry(user).CurrentValues.SetValues(obj);

            return db.SaveChanges() > 0;
        }
    }
}
