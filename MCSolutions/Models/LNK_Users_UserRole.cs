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
    
    public partial class LNK_Users_UserRole
    {
        public int UsersId { get; set; }
        public int UsersRolesId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Users_Roles Users_Roles { get; set; }
        public virtual Users Users { get; set; }
    }
}