using MCSolutions.DataAccess;
using MCSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MCSolutions.CustomAuthentication
{
    public class CustomMembership : MembershipProvider
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Mot de Passe"></param>
        /// <returns></returns>
        public override bool ValidateUser(string email, string Password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            using (MCEntities dbContext = new MCEntities())
            {
                var obj = dbContext.ValidateUser(email, Password);

                return obj;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Mot de Passe"></param>
        /// <param name="email"></param>
        /// <param name="Mot de PasseQuestion"></param>
        /// <param name="Mot de PasseAnswer"></param>
        /// <param name="isApproved"></param>
        /// <param name="providerUserKey"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public override MembershipUser CreateUser(string username, string Password, string email, string PasswordQuestion, string PasswordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userIsOnline"></param>
        /// <returns></returns>
        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            using (MCEntities dbContext = new MCEntities())
            {
                var user = dbContext.GetUser(email);
                if (user == null)
                {
                    return null;
                }

                UsersMODEL u = new UsersMODEL()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,

                    IsActive = user.IsActive,
                    CGU_CGV = user.CGU_CGV,
                    Robot = user.Robot,
                    PartnersInfos = user.PartnersInfos,
                    MonCRAInfos = user.MonCRAInfos,
                    ActivationCode = user.ActivationCode,
                    Email = user.Email,
                    RoleName = user.RoleLib
                };

                var selectedUser = new CustomMembershipUser(u);

                return selectedUser;
            }
        }

        public override string GetUserNameByEmail(string email)
        {
            using (MCEntities dbContext = new MCEntities())
            {
                //var obj = dbContext.sp_Users_GetByEmail(email);
                bool resu = dbContext.ValidateEmail(email);

                return !resu ? string.Empty : email;

                //return "csd";
            }


            //using (AuthenticationDB dbContext = new DataAccess.AuthenticationDB())
            //{

            //    //SqlParameter param1 = new SqlParameter("@EmployeeID", 6);
            //    //dbContext.Users.SqlQuery
            //    string username = (from u in dbContext.Users
            //                       where string.Compare(email, u.Email) == 0
            //                       select u.Username).FirstOrDefault();

            //    return !string.IsNullOrEmpty(username) ? username : string.Empty;
            //}
        }

        #region Overrides of Membership Provider

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string Password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}