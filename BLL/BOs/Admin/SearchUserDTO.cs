using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs.Admin
{
    public class SearchUserDTO
    {
        public int AuthId { get; set; }
        public string SearchBy { get; set; }
        public string SearchValue { get; set; }
    }
}
