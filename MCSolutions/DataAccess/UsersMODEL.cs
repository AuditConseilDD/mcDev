using MCSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess
{
    public class UsersMODEL : Users
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public int UserId { get => this.Id; }
        public virtual ICollection<Users_RolesMODEL> Roles { get; set; }

    }
}