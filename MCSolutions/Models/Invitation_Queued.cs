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
    
    public partial class Invitation_Queued
    {
        public int Id { get; set; }
        public int UsersId_from_ { get; set; }
        public Nullable<int> UsersId_to_ { get; set; }
        public string Email_to_ { get; set; }
        public int InvitationTypeId { get; set; }
        public int InvitationStateId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual Invitation_State Invitation_State { get; set; }
        public virtual Invitation_Type Invitation_Type { get; set; }
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
