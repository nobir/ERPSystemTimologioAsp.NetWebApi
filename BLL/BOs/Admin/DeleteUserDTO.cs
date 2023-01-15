using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs.Admin
{
    public class DeleteUserDTO
    {
        [Required]
        public int AuthId { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
