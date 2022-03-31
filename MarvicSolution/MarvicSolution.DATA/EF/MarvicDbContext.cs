using MarvicSolution.DATA.Configurations;
using MarvicSolution.DATA.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.EF
{
    public class MarvicDbContext : IdentityDbContext<App_User, App_Role, Guid>
    {
        public MarvicDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Su dung Fluent Api cai dat cac thuoc tinh cho Table va cac Fields
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectType_Configurations());
            modelBuilder.ApplyConfiguration(new Project_Configurations());
            modelBuilder.ApplyConfiguration(new App_User_Configurations());
            modelBuilder.ApplyConfiguration(new App_Role_Configurations());

            modelBuilder.Entity<IdentityUserLogin<Guid>>(
            eb =>
            {
                //eb.HasKey(o => o.UserId);
                eb.HasNoKey();
                eb.ToTable("App_UserLogin");
            });
            modelBuilder.Entity<IdentityUserToken<Guid>>(
            eb =>
            {
                eb.HasNoKey();
                eb.ToTable("App_UserToken");
            });

            modelBuilder.Entity<IdentityRoleClaim<Guid>>(
            eb =>
            {
                //eb.HasKey(o => o.Id);
                eb.HasNoKey();
                eb.ToTable("App_RoleClaim");
            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(
            eb =>
            {
                //eb.HasKey(o => o.Id);
                eb.HasNoKey();
                eb.ToTable("App_UserClaim");
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>(
            eb =>
            {
                //eb.HasKey(o => new { o.UserId, o.RoleId });
                eb.HasNoKey();
                eb.ToTable("App_UserRole");
            });


            //base.OnModelCreating(modelBuilder);
        }

        // Cac table của db
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<App_User> App_Users { get; set; }
        public DbSet<App_Role> App_Roles { get; set; }
    }
}
