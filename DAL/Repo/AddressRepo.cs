using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AddressRepo : IRepo<Address, int, bool>
    {
        private static TimologioContext db;

        public AddressRepo(TimologioContext db)
        {
            AddressRepo.db = db;
        }

        public bool Create(Address obj)
        {
            db.Addresses.Add(obj);

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var address = db.Addresses.Find(id);

            db.Addresses.Remove(address);

            return db.SaveChanges() > 0;
        }

        public Address Get(int id)
        {
            return db.Addresses.Find(id);
        }

        public List<Address> Gets()
        {
            return db.Addresses.ToList();
        }

        public bool Update(Address obj)
        {
            var address = db.Addresses.Where(a => a.Id == obj.Id).FirstOrDefault();

            if (address == null)
            {
                return false;
            }

            db.Entry(address).CurrentValues.SetValues(obj);

            return db.SaveChanges() > 0;
        }
    }
}
