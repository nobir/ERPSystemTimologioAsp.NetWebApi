using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class WorkingHourDTO
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime EntryTime { get; set; }
        public Nullable<System.DateTime> ExitTime { get; set; }
        public int UserId { get; set; }

        public virtual UserDTO User { get; set; }
    }
}
