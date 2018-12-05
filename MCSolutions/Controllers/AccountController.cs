using MCSolutions.CustomAuthentication;
using MCSolutions.DataAccess;
using MCSolutions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MCSolutions.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}

        /// <summary>
        /// 5433135     ::  _ssii
        /// 7624534     ::  _client
        /// 12055866    :: _consultant
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public ActionResult Index(string pid)
        {
            ViewData["pageName"] = pid;
            //View
            //string pageName = string.Empty;
            //switch (pid)
            //{
            //    case "5433135":
            //        pageName = "_ssii"
            //    default:
            //        break;
            //}

            HttpCookie authCookie = Request.Cookies["Cookie1"];
            if (authCookie != null)
            {
                return RedirectToAction("Admin", "CRA");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView loginView, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginView.UserName, loginView.Password))
                {
                    var user = (CustomMembershipUser)Membership.GetUser(loginView.UserName, false);
                    if (user != null)
                    {
                        CustomSerializeModel userModel = new Models.CustomSerializeModel()
                        {
                            UserId = user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            RoleLib = user.RoleName/*user.Roles.Select(r => r.RoleName).ToList()*/
                        };

                        string userData = JsonConvert.SerializeObject(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                            (
                            1, loginView.UserName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                            );

                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
                        Response.Cookies.Add(faCookie);
                    }

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        //return RedirectToAction("Index");
                        //return RedirectToAction("Index", "User");
                        //return RedirectToAction("Admin", "CRA");
                        return RedirectToAction("Index", "CRA");
                    }
                }
            }
            //ModelState.AddModelError("", "Quelque chose ne va pas : Username or Password invalid ^_^ ");
            ModelState.AddModelError("", "Quelque chose ne va pas: nom d'utilisateur ou mot de passe invalide ^_^ ");
            return View(loginView);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationView registrationView, FormCollection f)
        {
            bool statusRegistration = false;
            string messageRegistration = string.Empty;
            string styleRegistration = string.Empty;

            styleRegistration = "border: 1px solid red; display: block;";

            if (ModelState.IsValid)
            {
                // Email Verification
                string userName = Membership.GetUserNameByEmail(registrationView.Email);
                if (!string.IsNullOrEmpty(userName))
                {
                    //ModelState.AddModelError("Warning Email", "Sorry: Email already Exists");
                    ModelState.AddModelError("Avertissement Email ", "Désolé: l'e-mail existe déjà");

                    ViewBag.Message = "Avertissement Email, Désolé: l'e-mail existe déjà";
                    ViewBag.Style = styleRegistration;
                    ViewBag.Status = false;
                    return View(registrationView);
                }

                string roleName_tmp = f[7];

                int idtypeuser = usrPagemanager(roleName_tmp.ToLower());

                string roleName = userTypeNanager(idtypeuser).ToUpper();

                using (MCEntities dbContext = new MCEntities())
                {
                    bool _cgu_cgv = !string.IsNullOrEmpty(f["defaultCheck1"]) ? true : false;
                    bool _robot = !string.IsNullOrEmpty(f["defaultCheck2"]) ? true : false;
                    bool _partnersinfos = !string.IsNullOrEmpty(f["defaultCheck3"]) ? true : false;
                    bool _moncrainfos = !string.IsNullOrEmpty(f["defaultCheck4"]) ? true : false;

                    registrationView.ActivationCode = Guid.NewGuid();

                    var obj = dbContext.sp_Users_InsertUpdate(
                        null,
                        true,
                        _cgu_cgv,
                        _robot,
                        _partnersinfos,
                        _moncrainfos,
                        registrationView.ActivationCode,
                        registrationView.FirstName,
                        registrationView.LastName,
                        registrationView.Email,
                        registrationView.Password,
                        roleName_tmp,
                        "insert");
                }

                //Verification Email
                VerificationEmail(registrationView.Email, registrationView.ActivationCode.ToString());
                messageRegistration = "Votre compte a été créé avec succès. Vérifiez votre mail et confirmez votre compte. Car votre doit confirmé avant de pouvoir vous connecter.";
                styleRegistration = "border: 1px solid green; display: block;";
                statusRegistration = true;

                ViewBag.Message = messageRegistration;
                ViewBag.Status = statusRegistration;
                ViewBag.Style = styleRegistration;

                return View("Info");
            }
            else
            {
                messageRegistration = "Quelque chose ne va pas!";
            }
            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;
            ViewBag.Style = styleRegistration;

            return View(registrationView);
        }
        
        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }

        private int usrPagemanager(string userType)
        {
            int p_idtypeuser = 0;

            switch (userType.ToLower())
            {
                case "consultant":
                case "option1":
                    p_idtypeuser = 1;
                    break;
                case "clientfinal":
                case "option2":
                    p_idtypeuser = 2;
                    break;
                case "agent":
                case "option3":
                    p_idtypeuser = 6;
                    break;
            }

            return p_idtypeuser;
        }

        private string userTypeNanager(long userTypeId)
        {
            string resu = string.Empty;
            switch (userTypeId)
            {
                case 1:
                    resu = "consultant";
                    break;
                case 2:
                    resu = "clientfinal";
                    break;
                case 3:
                    resu = "agent";
                    break;
            }
            return resu;
        }

        [HttpGet]
        public ActionResult ActivationAccount(string id)
        {
            bool statusAccount = false;
            using (AuthenticationDB dbContext = new DataAccess.AuthenticationDB())
            {
                var userAccount = dbContext.Users.Where(u => u.ActivationCode.ToString().Equals(id)).FirstOrDefault();

                if (userAccount != null)
                {
                    userAccount.IsActive = true;
                    dbContext.SaveChanges();
                    statusAccount = true;
                }
                else
                {
                    ViewBag.Message = "Quelque chose ne va pas !!";
                }

            }
            ViewBag.Status = statusAccount;
            return View();
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

        [NonAction]
        public void VerificationEmail(string email, string activationCode)
        {
            var url = string.Format("/Account/ActivationAccount/{0}", activationCode);
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);

            var fromEmail = new MailAddress("mehdi.rami2012@gmail.com", "Activation Account - AKKA");
            var toEmail = new MailAddress(email);

            var fromEmailPassword = "******************";
            string subject = "Activation du compte!";

            string body = "<br/> Veuillez cliquer sur le lien suivant pour activer votre compte." + "<br/><a href='" + link + "'> Activation du compte! </a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            //using (var message = new MailMessage(fromEmail, toEmail)
            //{
            //    Subject = subject,
            //    Body = body,
            //    IsBodyHtml = true

            //})

            //    smtp.Send(message);

        }
    }
}
