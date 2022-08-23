using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class VacationDetailDTO
    {
        public int Id { get; set; }
        public int Verified { get; set; }
        public string Reason { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
