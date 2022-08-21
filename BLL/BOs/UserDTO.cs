using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int Verified { get; set; }
        public int VerifyEmail { get; set; }
        public string Username { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<double> Salary { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public string Avatar { get; set; }
        public Nullable<int> AddressId { get; set; }
        public Nullable<int> RegionId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public virtual AddressDTO Address { get; set; }
        public virtual BranchDTO Branch { get; set; }
        public virtual RegionDTO Region { get; set; }
    }
}
