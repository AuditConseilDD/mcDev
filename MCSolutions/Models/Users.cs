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
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.CRA_Activite = new HashSet<CRA_Activite>();
            this.Email_SendListe = new HashSet<Email_SendListe>();
            this.Invitation_Queued = new HashSet<Invitation_Queued>();
            this.Invitation_Queued1 = new HashSet<Invitation_Queued>();
            this.Invitation_Type = new HashSet<Invitation_Type>();
            this.Invitation_Type1 = new HashSet<Invitation_Type>();
            this.LNK_Users_CRAActivite = new HashSet<LNK_Users_CRAActivite>();
            this.LNK_Users_CRAType = new HashSet<LNK_Users_CRAType>();
            this.LNK_Users_Mission = new HashSet<LNK_Users_Mission>();
            this.LNK_Users_UserRole = new HashSet<LNK_Users_UserRole>();
            this.Users_Adresse = new HashSet<Users_Adresse>();
            this.Users_Email = new HashSet<Users_Email>();
            this.Users_Password = new HashSet<Users_Password>();
            this.Users_Tel = new HashSet<Users_Tel>();
        }
    
        public int UserId { get; set; }
        public Nullable<int> Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public bool CGU_CGV { get; set; }
        public bool Robot { get; set; }
        public bool PartnersInfos { get; set; }
        public bool MonCRAInfos { get; set; }
        public System.Guid ActivationCode { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IAmARobot { get; set; }
        public bool WouldRecievePartnersInfos { get; set; }
        public bool WouldRecieveMonCRAInfos { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRA_Activite> CRA_Activite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Email_SendListe> Email_SendListe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invitation_Queued> Invitation_Queued { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invitation_Queued> Invitation_Queued1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invitation_Type> Invitation_Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invitation_Type> Invitation_Type1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LNK_Users_CRAActivite> LNK_Users_CRAActivite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LNK_Users_CRAType> LNK_Users_CRAType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LNK_Users_Mission> LNK_Users_Mission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LNK_Users_UserRole> LNK_Users_UserRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_Adresse> Users_Adresse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_Email> Users_Email { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_Password> Users_Password { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_Tel> Users_Tel { get; set; }
    }
}