using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SalaryManageRepo : IRepo<Payment, int, bool>
    {

        private static TimologioContext db;

        public SalaryManageRepo(TimologioContext db)
        {
            SalaryManageRepo.db = db;
        }
        public bool Create(Payment obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Payment Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> Gets()
        {
            throw new NotImplementedException();
        }

        public bool Update(Payment obj)
        {
            var payment = SalaryManageRepo.db.Payments.Where(a => a.Id == obj.Id).FirstOrDefault();

            if (payment == null)
            {
                return false;
            }
            
            SalaryManageRepo.db.Entry(payment).CurrentValues.SetValues(obj);

            return SalaryManageRepo.db.SaveChanges() > 0;
        }
    }
}
