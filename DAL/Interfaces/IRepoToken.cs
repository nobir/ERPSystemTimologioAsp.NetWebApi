using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepoToken<ClassType, PrimaryKey, MethodType> : IRepo<ClassType, PrimaryKey, MethodType>
    {
        ClassType GetByTokenKeyUserIdExpiredNull(int user_id, string key);
    }
}
