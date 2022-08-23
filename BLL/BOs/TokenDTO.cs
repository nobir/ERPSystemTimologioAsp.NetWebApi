using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public string Token1 { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> ExpiredAt { get; set; }
        public int UserId { get; set; }

        public virtual UserDTO User { get; set; }
    }
}
