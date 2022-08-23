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

            db.Addresses.Attach(user.Address);
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
            return db.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
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

            db.Entry(user).CurrentValues.SetValues(obj);

            return db.SaveChanges() > 0;
        }
    }
}
