using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class VacationDetailRepo : IRepo<VacationDetail, int, bool>
    {
        private static TimologioContext db;

        public VacationDetailRepo(TimologioContext db)
        {
            VacationDetailRepo.db = db;
        }

        public bool Create(VacationDetail obj)
        {
            VacationDetailRepo.db.VacationDetails.Add(obj);

            return VacationDetailRepo.db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var EmployeeLeave = VacationDetailRepo.db.VacationDetails.Find(id);

            if (EmployeeLeave == null)
            {
                return false;
            }


            VacationDetailRepo.db.VacationDetails.Remove(EmployeeLeave);

            return VacationDetailRepo.db.SaveChanges() > 0;
        }

        public VacationDetail Get(int id)
        {
            return VacationDetailRepo.db.VacationDetails.Find(id);
        }

        public List<VacationDetail> Gets()
        {
            return VacationDetailRepo.db.VacationDetails.ToList();
        }

        public bool Update(VacationDetail obj)
        {
            var EmployeeLeave = VacationDetailRepo.db.VacationDetails.Where(b => b.Id == obj.Id).FirstOrDefault();

            if (EmployeeLeave == null)
            {
                return false;

                
            }
            VacationDetailRepo.db.Entry(EmployeeLeave).CurrentValues.SetValues(obj);

            return VacationDetailRepo.db.SaveChanges() > 0;
        }
    }
}


