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
    public class VacationDetailService
    {
        public static bool Create(VacationDetailDTO branch)
        {
            var _vac = Mapping.Mapper.Map<VacationDetail>(branch);

            return DataAccessFactory.GetVacationDetailDataAccess().Create(_vac);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GetVacationDetailDataAccess().Delete(id);
        }

        public static VacationDetailDTO Get(int id)
        {
            return Mapping.Mapper.Map<VacationDetailDTO>(DataAccessFactory.GetVacationDetailDataAccess().Get(id));
        }

        public static List<VacationDetailDTO> Gets()
        {
            return Mapping.Mapper.Map<List<VacationDetailDTO>>(DataAccessFactory.GetVacationDetailDataAccess().Gets());
        }

        public static bool Update(VacationDetailDTO vac)
        {
            var _vac = Mapping.Mapper.Map<VacationDetail>(vac);

            return DataAccessFactory.GetVacationDetailDataAccess().Update(_vac);
        }
    }
}
