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
    public class WorkingHourService
    {
        public static bool Create(WorkingHourDTO working_hour)
        {
            working_hour.Date = DateTime.Now;
            working_hour.EntryTime = DateTime.Now;
            working_hour.ExitTime = null;

            var _working_hour = Mapping.Mapper.Map<WorkingHour>(working_hour);

            return DataAccessFactory.GetWorkingHourDataAccess().Create(_working_hour);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GetWorkingHourDataAccess().Delete(id);
        }

        public static WorkingHourDTO Get(int id)
        {
            var _working_hour = Mapping.Mapper.Map<WorkingHourDTO>(DataAccessFactory.GetWorkingHourDataAccess().Get(id));

            return _working_hour;
        }
        public static WorkingHourDTO GetByUserIdExitNull(int user_id)
        {
            var _working_hour = Mapping.Mapper.Map<WorkingHourDTO>(DataAccessFactory.GetWorkingHourDataAccess().GetByUserIdExitNull(user_id));

            return _working_hour;
        }

        public static List<WorkingHourDTO> Gets()
        {
            var _working_hours = Mapping.Mapper.Map<List<WorkingHourDTO>>(DataAccessFactory.GetWorkingHourDataAccess().Gets());

            return _working_hours;
        }

        public static bool Update(WorkingHourDTO working_hour)
        {
            var _working_hour = Mapping.Mapper.Map<WorkingHour>(working_hour);

            return DataAccessFactory.GetWorkingHourDataAccess().Update(_working_hour);
        }
    }
}
