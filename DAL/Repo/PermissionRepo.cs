using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class PermissionRepo : IRepo<Permission, int, bool>
    {
        private static TimologioContext db;
        public PermissionRepo(TimologioContext db)
        {
            PermissionRepo.db = db;
        }
        public bool Create(Permission obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Permission Get(int id)
        {
            return db.Permissions.Find(id);
        }

        public List<Permission> Gets()
        {
            throw new NotImplementedException();
        }

        public bool Update(Permission obj)
        {
            throw new NotImplementedException();
        }
    }
}
