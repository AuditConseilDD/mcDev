//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCSolutions.Models
{
    using System;
    
    public partial class sp_Users_GetById_Result
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool CGU_CGV { get; set; }
        public bool Robot { get; set; }
        public bool PartnersInfos { get; set; }
        public bool MonCRAInfos { get; set; }
        public System.Guid ActivationCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleLib { get; set; }
    }
}
