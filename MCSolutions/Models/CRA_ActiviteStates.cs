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
    
    public partial class CRA_ActiviteStates
    {
        public int CRAActiviteId { get; set; }
        public int CRAActiviteStateId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string CreationBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
    
        public virtual CRA_Activite CRA_Activite { get; set; }
        public virtual CRA_ActiviteState CRA_ActiviteState { get; set; }
    }
}