using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs.Admin
{
    public class CreateUserDTO
    {
        public CreateUserDTO()
        {
            Permissions = new List<PermissionAttachDTO>();
        }
        [Required]
        public int AuthId { get; set; }
        [Required]
        public UserDTO User { get; set; }
        [Required]
        public AddressDTO Address { get; set; }
        public virtual BranchDTO Branch { get; set; }
        public virtual RegionDTO Region { get; set; }
        public virtual List<int> PermissionIds { get; set; }
        public virtual List<PermissionAttachDTO> Permissions { get; set; }
    }
}
