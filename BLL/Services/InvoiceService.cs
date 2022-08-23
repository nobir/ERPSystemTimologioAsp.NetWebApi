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
    public class InvoiceService
    {
        public static bool Create(InvoiceDTO invoice)
        {
            var _invoice = Mapping.Mapper.Map<Invoice>(invoice);

            return DataAccessFactory.GetInvoiceDataAccess().Create(_invoice);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GetInvoiceDataAccess().Delete(id);
        }

        public static InvoiceDTO Get(int id)
        {
            return Mapping.Mapper.Map<InvoiceDTO>(DataAccessFactory.GetInvoiceDataAccess().Get(id));
        }

        public static List<InvoiceDTO> Gets()
        {
            return Mapping.Mapper.Map<List<InvoiceDTO>>(DataAccessFactory.GetInvoiceDataAccess().Gets());
        }

        public static bool Update(InvoiceDTO invoice)
        {
            var _invoice = Mapping.Mapper.Map<Invoice>(invoice);

            return DataAccessFactory.GetInvoiceDataAccess().Update(_invoice);
        }
    }
}
