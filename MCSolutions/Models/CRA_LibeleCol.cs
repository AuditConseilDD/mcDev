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
    
    public partial class CRA_LibeleCol
    {
        public int Id { get; set; }
        public string LibShort { get; set; }
        public string LibLong { get; set; }
        public string Type { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
    }
}
