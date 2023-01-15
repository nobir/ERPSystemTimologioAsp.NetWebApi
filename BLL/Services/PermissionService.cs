using BLL.BOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PermissionService
    {
        public static PermissionDTO Get(int id)
        {
            var token = Mapping.Mapper.Map<PermissionDTO>(DataAccessFactory.GetPermissionDataAccess().Get(id));

            return token;
        }
    }
}
