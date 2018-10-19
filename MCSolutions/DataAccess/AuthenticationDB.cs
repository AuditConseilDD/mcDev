using MCSolutions.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MCSolutions.DataAccess
{
    public class AuthenticationDB : DbContext
    {
        public AuthenticationDB()
            :base("AuthenticationDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });



            modelBuilder.Entity<CRA>().HasKey<int>(l => l.CRAId).Map(m => m.ToTable("CRA"));
            modelBuilder.Entity<CRA_Activite>().HasKey<int>(l => l.ActiviteId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<CRA> CRAs { get; set; }
        public DbSet<CRA_Activite> CRAs_Activite { get; set; }
    }
}