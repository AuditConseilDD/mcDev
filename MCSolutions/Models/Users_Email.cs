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
    using System.Collections.Generic;
    
    public partial class Users_Email
    {
        public int UsersId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int AccountType { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
