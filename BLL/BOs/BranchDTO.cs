using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class BranchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public int AddressId { get; set; }
        public virtual AddressDTO Address { get; set; }
        public virtual RegionDTO Region { get; set; }
    }
}
