using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSolutions.Models
{
    public class LoginView
    {
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Se rappeler de moi")]
        public bool RememberMe { get; set; }
    }

    public class CustomSerializeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> RoleName { get; set; }
        public string RoleLib { get; set; }

    }

    public class RegistrationView
    {
        //[Required(ErrorMessage = "Nom d'utilisateur obligatoire")]
        //[Display(Name ="Nom d'utilisateur")]
        //public string Username { get; set; }

        [Required(ErrorMessage = "Prénom obligatoire")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nom obligatoire")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email obligatoire")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public Guid ActivationCode { get; set; }

        [Required(ErrorMessage = "Mot de Passe obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de Passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mot de passe confirmé obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe confirmé ")]
        [Compare("Password", ErrorMessage = "Erreur : Le mot de passe est différent de celui confirmé")]
        public string ConfirmPassword { get; set; }



    }
}