using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepoUser<ClassType, PrimaryKey, MethodType> : IRepo<ClassType, PrimaryKey, MethodType>
    {
        ClassType GetByEmail(string email);
        ClassType GetById(int id);
    }
}
