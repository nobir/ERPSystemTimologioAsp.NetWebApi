using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepo<User, int, bool>
    {
        private static TimologioContext db;

        public UserRepo(TimologioContext db)
        {
            UserRepo.db = db;
        }

        public bool Create(User obj)
        {
            UserRepo.db.Users.Add(obj);

            return UserRepo.db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var user = UserRepo.db.Users.Find(id);

            if (user == null)
            {
                return false;
            }

            UserRepo.db.Users.Remove(user);

            return UserRepo.db.SaveChanges() > 0;
        }

        public User Get(int id)
        {
            return UserRepo.db.Users.Find(id);
        }

        public List<User> Gets()
        {
            return UserRepo.db.Users.ToList();
        }

        public bool Update(User obj)
        {
            var user = UserRepo.db.Users.Where(u => u.Id == obj.Id).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            UserRepo.db.Entry(user).CurrentValues.SetValues(obj);

            return UserRepo.db.SaveChanges() > 0;
        }

    }
}
