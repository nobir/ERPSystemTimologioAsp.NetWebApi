using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class PermissionDTO
    {
        public PermissionDTO()
        {
            Users = new List<UserDTO>();
        }

        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }
        public int InvoiceAdd { get; set; }
        public int InvoiceManage { get; set; }
        public int InventoryManage { get; set; }
        public int CategoryManage { get; set; }
        public int StationManage { get; set; }
        public int OperationManage { get; set; }
        public int UserManage { get; set; }
        public int PermissionManage { get; set; }

        public List<UserDTO> Users { get; set; }
    }
}
