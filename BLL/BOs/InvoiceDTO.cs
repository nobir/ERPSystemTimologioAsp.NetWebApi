using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class InvoiceDTO
    {
        public int? Id { get; set; }
        [Required]
        public System.DateTime Date { get; set; }

        public int CutomerId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]

        public int quantity { get; set; }

        public string category { get; set; }
        public virtual CustomerDTO Customer { get; set; }
    }
}
