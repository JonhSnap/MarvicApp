using MarvicSolution.DATA.Configurations;
using MarvicSolution.DATA.Entities;
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

            //base.OnModelCreating(modelBuilder);
        }

        // Cac table của db
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
