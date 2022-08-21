using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<ClassType, PrimaryKeyType, MethodType>
    {
        List<ClassType> Gets();
        ClassType Get(PrimaryKeyType id);
        MethodType Create(ClassType obj);
        MethodType Update(ClassType obj);
        MethodType Delete(PrimaryKeyType id);
    }
}
