using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class DataAccessFactory
    {
        private static readonly TimologioContext db = new TimologioContext();

        private DataAccessFactory() { }

        public static IRepoToken<Token, string, bool> GetTokenDataAccess()
        {
            return new TokenRepo(db);
        }

        public static IRepoUser<User, int, bool> GetUserDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepoWorkingHour<WorkingHour, int, bool> GetWorkingHourDataAccess()
        {
            return new WorkingHourRepo(db);
        }
    }
}
