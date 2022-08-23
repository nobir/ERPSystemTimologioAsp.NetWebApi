using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CustomerRepo : IRepo<Customer, int,bool>
    {
        private static TimologioContext db;

        public CustomerRepo(TimologioContext db)
        {
            CustomerRepo.db = db;
        }
        public bool Create(Customer obj)
        {
            CustomerRepo.db.Customers.Add(obj);

            return CustomerRepo.db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var customer = CustomerRepo.db.Customers.Find(id);

            if (customer == null)
            {
                return false;
            }
            customer.Invoices.Clear();
            CustomerRepo.db.Customers.Remove(customer);

            return CustomerRepo.db.SaveChanges() > 0;
        }

        public Customer Get(int id)
        {
            return CustomerRepo.db.Customers.Find(id);
        }

        public List<Customer> Gets()
        {
            return CustomerRepo.db.Customers.ToList();
        }

        public bool Update(Customer obj)
        {
            var customer = CustomerRepo.db.Customers.Where(u => u.Id == obj.Id).FirstOrDefault();

            if (customer == null)
            {
                return false;
            }

            CustomerRepo.db.Entry(customer).CurrentValues.SetValues(obj);

            return CustomerRepo.db.SaveChanges() > 0;
        }
    }
}
