using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class CustomerDTO
    {
        public int? Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be 3 character or greater")]
        public string Name { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        public string LocalAddress { get; set; }
    }
}
