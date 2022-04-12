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
    public class MarvicDbContext : DbContext
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
            modelBuilder.ApplyConfiguration(new Issue_Configurations());
            modelBuilder.ApplyConfiguration(new Member_Configurations());

            //base.OnModelCreating(modelBuilder);
        }

        // Cac table của db
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<App_User> App_Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
