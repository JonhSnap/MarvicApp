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
                Name = "Project ABC",
                Key = "PA",
                Access = EnumAccess.Public,
                Id_Lead = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                DateCreated = DateTime.Parse("2021-2-25"),
                DateStarted = DateTime.Parse("2021-7-21"),
                DateEnd = DateTime.Parse("2021-8-1"),
                Id_Updator = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
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
            },
            new Project
            {
                Id = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"),
                Name = "Project D",
                Key = "PD",
                Access = EnumAccess.Public,
                Id_Lead = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                DateCreated = DateTime.Parse("2022-5-14"),
                DateStarted = DateTime.Parse("2022-6-21"),
                DateEnd = DateTime.Parse("2023-6-1"),
                Id_Updator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                UpdateDate = DateTime.Parse("2022-7-26"),
                IsStared = EnumStatus.True,
                IsDeleted = EnumStatus.False
            },
            new Project
            {
                Id = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"),
                Name = "Project Editor Super",
                Key = "PES",
                Access = EnumAccess.Public,
                Id_Lead = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                Id_Creator = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                DateCreated = DateTime.Parse("2022-5-14"),
                DateStarted = DateTime.Parse("2022-6-21"),
                DateEnd = DateTime.Parse("2023-6-1"),
                Id_Updator = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
                UpdateDate = DateTime.Parse("2022-7-26"),
                IsStared = EnumStatus.True,
                IsDeleted = EnumStatus.False
            },
            new Project
            {
                Id = new Guid("7C50EED0-4083-46E2-9C2C-65AE53FE4D88"),
                Name = "Project Dior Champange",
                Key = "PDC",
                Access = EnumAccess.Limited,
                Id_Lead = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
                Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                DateCreated = DateTime.Parse("2022-5-14"),
                DateStarted = DateTime.Parse("2022-6-21"),
                DateEnd = DateTime.Parse("2023-6-1"),
                Id_Updator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                UpdateDate = DateTime.Parse("2022-7-26"),
                IsStared = EnumStatus.True,
                IsDeleted = EnumStatus.False
            },
            new Project
            {
                Id = new Guid("CF0A0FE2-F1CA-4941-B691-6BABE389DF99"),
                Name = "Project Efferent Tower",
                Key = "PET",
                Access = EnumAccess.Limited,
                Id_Lead = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                Id_Creator = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                DateCreated = DateTime.Parse("2022-5-14"),
                DateStarted = DateTime.Parse("2022-6-21"),
                DateEnd = DateTime.Parse("2023-6-1"),
                Id_Updator = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                UpdateDate = DateTime.Parse("2022-7-26"),
                IsStared = EnumStatus.True,
                IsDeleted = EnumStatus.False
            }
            );
        }
    }
}
