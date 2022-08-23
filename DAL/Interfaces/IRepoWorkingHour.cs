using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepoWorkingHour<ClassType, PrimaryKey, MethodType> : IRepo<ClassType, PrimaryKey, MethodType>
    {
        ClassType GetByUserIdExitNull(int user_id);
    }
}
