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
    public class PaymentService
    {
        public static bool Update(PaymentDTO Payment)
        {
            var _payment = Mapping.Mapper.Map<Payment>(Payment);

            return DataAccessFactory.GetPaymentDataAccess().Update(_payment);
        }
    }
}
