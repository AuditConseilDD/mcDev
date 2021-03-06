﻿using MCSolutions.DataAccess;
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
                    m.ToTable("LNK_Users_UserRole");
                    m.MapLeftKey("UsersId");
                    m.MapRightKey("UsersRolesId");
                });



            modelBuilder.Entity<CRA>().HasKey<int>(l => l.CRAId).Map(m => m.ToTable("CRA"));
            modelBuilder.Entity<CRA_Activite_old>().HasKey<int>(l => l.ActiviteId);

            modelBuilder.Entity<UsersMODEL>().HasKey<int>(l => l.Id).Map(m => m.ToTable("Users"));
            modelBuilder.Entity<Users_RolesMODEL>().HasKey<int>(l => l.Id).Map(m => m.ToTable("Users_Roles"));
        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        
        public DbSet<CRA> CRAs { get; set; }
        public DbSet<CRA_Activite_old> CRAs_Activite { get; set; }

        public DbSet<UsersMODEL> Users { get; set; }
        public DbSet<Users_RolesMODEL> Roles { get; set; }
    }
}