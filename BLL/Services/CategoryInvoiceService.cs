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
    public class CategoryInvoiceService
    {
        public static bool Create(CategoryInvoiceDTO invoice)
        {
            var _invoice = Mapping.Mapper.Map<CategoryInvoice>(invoice);

            return DataAccessFactory.GetCategoryInvoiceDataAccess().Create(_invoice);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GetCategoryInvoiceDataAccess().Delete(id);
        }

        public static CategoryInvoiceDTO Get(int id)
        {
            return Mapping.Mapper.Map<CategoryInvoiceDTO>(DataAccessFactory.GetCategoryInvoiceDataAccess().Get(id));
        }

        public static List<CategoryInvoiceDTO> Gets()
        {
            return Mapping.Mapper.Map<List<CategoryInvoiceDTO>>(DataAccessFactory.GetCategoryInvoiceDataAccess().Gets());
        }

        public static bool Update(CategoryInvoiceDTO invoice)
        {
            var _invoice = Mapping.Mapper.Map<CategoryInvoice>(invoice);

            return DataAccessFactory.GetCategoryInvoiceDataAccess().Update(_invoice);
        }
    }
}
