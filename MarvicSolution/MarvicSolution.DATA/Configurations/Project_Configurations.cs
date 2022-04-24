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
                Access = EnumAccess.Public,
                Id_Lead = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), // NhanTTT1
                Id_Creator = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), // NhanTTT1
                DateCreated = DateTime.Parse("2021-2-25"),
                DateStarted = DateTime.Parse("2021-7-21"),
                DateEnd = DateTime.Parse("2021-8-1"),
                Id_Updator = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), // NhanTTT1
                UpdateDate = DateTime.Parse("2021-7-21"),
                IsStared = EnumStatus.False,
                IsDeleted = EnumStatus.False
            },
            new Project
            {
                Id = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"),
                Name = "Project B",
                Key = "PB",
                Access = EnumAccess.Private,
                Id_Lead = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), // NhanTTT1
                Id_Creator = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), // NhanTTT1
                DateCreated = DateTime.Parse("2021-3-2"),
                DateStarted = DateTime.Parse("2021-4-21"),
                DateEnd = DateTime.Parse("2021-8-1"),
                Id_Updator = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), // NhanTTT1
                UpdateDate = DateTime.Parse("2021-6-21"),
                IsStared = EnumStatus.True,
                IsDeleted = EnumStatus.False
            },
            new Project
            {
                Id = new Guid("A5329D06-9D32-4A54-B816-906DFBBD288C"),
                Name = "Project C",
                Key = "PC",
                Access = EnumAccess.Limited,
                Id_Lead = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), // NhanTTT1
                Id_Creator = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), // NhanTTT1
                DateCreated = DateTime.Parse("2021-4-25"),
                DateStarted = DateTime.Parse("2021-5-21"),
                DateEnd = DateTime.Parse("2021-6-1"),
                Id_Updator = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), // NhanTTT1
                UpdateDate = DateTime.Parse("2021-4-26"),
                IsStared = EnumStatus.True,
                IsDeleted = EnumStatus.False
            }
            );
        }
    }
}
