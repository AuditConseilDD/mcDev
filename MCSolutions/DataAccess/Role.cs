using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}