using System;
using MCSolutions.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MCSolutions.CustomAuthentication
{
    public class CustomMembershipUser : MembershipUser
    {
        #region User Properties

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Users_RolesMODEL> Roles { get; set; }
        public string RoleName { get; set; }

        #endregion

        public CustomMembershipUser(UsersMODEL user):base("CustomMembership", user.Username, user.UserId, user.Email, user.RoleName, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Roles = user.Roles;
            RoleName = user.RoleName;
        }
    }
}