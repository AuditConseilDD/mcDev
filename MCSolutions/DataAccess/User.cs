using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSolutions.DataAccess
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public bool CGU_CGV { get; set; }
        public bool Robot { get; set; }
        public bool PartnersInfos { get; set; }
        public bool MonCRAInfos { get; set; }

        //public bool CGU_CGV { get; set; }
        //public bool IAmARobot { get; set; }
        //public bool WouldRecievePartnersInfos { get; set; }
        //public bool WouldRecieveMonCRAInfos { get; set; }

        public Guid ActivationCode { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

    }
}