using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class WorkingHourRepo : IRepoWorkingHour<WorkingHour, int, bool>
    {
        private static TimologioContext db;

        public WorkingHourRepo(TimologioContext db)
        {
            WorkingHourRepo.db = db;
        }

        public bool Create(WorkingHour obj)
        {
            db.WorkingHours.Add(obj);

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var working_hour = db.WorkingHours.Find(id);

            if (working_hour == null)
            {
                return false;
            }

            db.Users.Attach(working_hour.User);

            db.WorkingHours.Remove(working_hour);

            return db.SaveChanges() > 0;
        }

        public WorkingHour Get(int id)
        {
            return db.WorkingHours.Find(id);
        }

        public WorkingHour GetByUserIdExitNull(int user_id)
        {
            return db.WorkingHours.ToList().LastOrDefault(wh => wh.UserId == user_id && wh.ExitTime == null);
        }

        public List<WorkingHour> Gets()
        {
            return db.WorkingHours.ToList();
        }

        public bool Update(WorkingHour obj)
        {
            var user = db.WorkingHours.Where(wh => wh.Id == obj.Id).SingleOrDefault();

            if (user == null)
            {
                return false;
            }

            db.Entry(user).CurrentValues.SetValues(obj);

            return db.SaveChanges() > 0;
        }
    }
}
