using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
   public class PaymentDTO
    {
        public int Id { get; set; }
        public System.DateTime IssueDate { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public double Bonus { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
