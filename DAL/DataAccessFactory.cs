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

        public static IRepo<Address, int, bool> GetAddressDataAccess()
        {
            return new AddressRepo(db);
        }

        public static IRepoUser<User, int, bool> GetUserDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepo<Permission, int, bool> GetPermissionDataAccess()
        {
            return new PermissionRepo(db);
        }

        public static IRepoWorkingHour<WorkingHour, int, bool> GetWorkingHourDataAccess()
        {
            return new WorkingHourRepo(db);
        }

        public static IRepo<Customer, int,bool> GetCustomerDataAccess()
        {
            return new CustomerRepo(DataAccessFactory.db);
        }
        public static IRepo<Invoice, int,bool> GetInvoiceDataAccess()
        {
            return new InvoiceRepo(DataAccessFactory.db);
        }

        public static IRepo<CategoryInvoice, int,bool> GetCategoryInvoiceDataAccess()
        {
            return new CategoryInvoiceRepo(DataAccessFactory.db);
        }

        public static IRepo<VacationDetail, int, bool> GetVacationDetailDataAccess()
        {
            return new VacationDetailRepo(DataAccessFactory.db);
        }

        public static IRepo<Payment, int, bool> GetPaymentDataAccess()
        {
            return new SalaryManageRepo(DataAccessFactory.db);
        }
    }
}
