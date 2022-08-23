using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class CategoryInvoiceDTO
    {
        [Required]
        public int CategoryId { get; set; }
        public int InvoiceId { get; set; }
        [Required]
        public int Quantity { get; set; }


        public virtual InvoiceDTO Invoice { get; set; }
    }
}
