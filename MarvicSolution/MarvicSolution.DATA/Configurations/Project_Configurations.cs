using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Configurations
{
    class Project_Configurations : IEntityTypeConfiguration<Project>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.HasKey(o => new { o.Id });

            // Data Seeding
            builder.HasData(
            new Project
            {
                Id = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                Name = "Project A",
                Key = "PA",
                Id_ProjectType = new Guid("77B88991-F823-4301-B452-1B14CA44D5CB"), // P_Type_Marketing
                Id_Lead = new Guid(),
                Id_Creator = new Guid(),
                DateCreated = DateTime.Parse("2021-2-25"),
                DateStarted = DateTime.Parse("2021-7-21"),
                DateEnd = DateTime.Parse("2021-8-1"),
                Id_Updator = new Guid(),
                UpdateDate = DateTime.Parse("2021-7-21"),
                IsDeleted = EnumStatus.False
            },
            new Project
            {
                Id = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"),
                Name = "Project B",
                Key = "PB",
                Id_ProjectType = new Guid("77B88991-F823-4301-B452-1B14CA44D5CB"), // P_Type_Marketing
                Id_Lead = new Guid(),
                Id_Creator = new Guid(),
                DateCreated = DateTime.Parse("2021-3-2"),
                DateStarted = DateTime.Parse("2021-4-21"),
                DateEnd = DateTime.Parse("2021-8-1"),
                Id_Updator = new Guid(),
                UpdateDate = DateTime.Parse("2021-6-21"),
                IsDeleted = EnumStatus.False
            },
            new Project
            {
                Id = new Guid("A5329D06-9D32-4A54-B816-906DFBBD288C"),
                Name = "Project C",
                Key = "PC",
                Id_ProjectType = new Guid("21C68955-EA3E-4B41-8EC5-EF816C912F1A"), // P_Type_Development Program
                Id_Lead = new Guid(),
                Id_Creator = new Guid(),
                DateCreated = DateTime.Parse("2021-4-25"),
                DateStarted = DateTime.Parse("2021-5-21"),
                DateEnd = DateTime.Parse("2021-6-1"),
                Id_Updator = new Guid(),
                UpdateDate = DateTime.Parse("2021-4-26"),
                IsDeleted = EnumStatus.False
            }
            );
        }
    }
}
