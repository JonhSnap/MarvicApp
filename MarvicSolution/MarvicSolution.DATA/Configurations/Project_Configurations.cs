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
                Name = "Marvic Academy",
                Key = "PA",
                Access = EnumAccess.Public,
                Id_Lead = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                DateCreated = DateTime.Parse("2022-4-20"),
                DateStarted = DateTime.Parse("2022-4-21"),
                DateEnd = DateTime.Parse("2023-9-21"),
                Id_Updator = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
                UpdateDate = DateTime.Parse("2022-7-21"),
                IsStared = EnumStatus.True,
                IsDeleted = EnumStatus.False
            },
             new Project
             {
                 Id = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                 Name = "Natashin Khan",
                 Key = "NKHAN",
                 Access = EnumAccess.Public,
                 Id_Lead = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                 Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                 DateCreated = DateTime.Parse("2022-6-30"),
                 DateStarted = DateTime.Parse("2022-6-30"),
                 DateEnd = DateTime.Parse("2023-6-30"),
                 Id_Updator = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhNQ
                 UpdateDate = DateTime.Parse("2022-7-21"),
                 IsStared = EnumStatus.False,
                 IsDeleted = EnumStatus.False
             },
             new Project
             {
                 Id = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                 Name = "Morgan Football",
                 Key = "MFB",
                 Access = EnumAccess.Public,
                 Id_Lead = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                 Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // KhietPT
                 DateCreated = DateTime.Parse("2022-7-20"),
                 DateStarted = DateTime.Parse("2022-7-21"),
                 DateEnd = DateTime.Parse("2023-9-21"),
                 Id_Updator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                 UpdateDate = DateTime.Parse("2022-8-16"),
                 IsStared = EnumStatus.True,
                 IsDeleted = EnumStatus.False
             }
             ///
             ,
             new Project
             {
                 Id = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                 Name = "Herashen Academy",
                 Key = "HA",
                 Access = EnumAccess.Public,
                 Id_Lead = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                 Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // KhietPT
                 DateCreated = DateTime.Parse("2022-8-15"),
                 DateStarted = DateTime.Parse("2022-8-15"),
                 DateEnd = DateTime.Parse("2023-8-19"),
                 Id_Updator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                 UpdateDate = DateTime.Parse("2022-8-16"),
                 IsStared = EnumStatus.False,
                 IsDeleted = EnumStatus.False
             },
             new Project
             {
                 Id = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                 Name = "Sealink Hope",
                 Key = "SH",
                 Access = EnumAccess.Public,
                 Id_Lead = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                 Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // KhietPT
                 DateCreated = DateTime.Parse("2022-3-20"),
                 DateStarted = DateTime.Parse("2022-3-21"),
                 DateEnd = DateTime.Parse("2023-9-21"),
                 Id_Updator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                 UpdateDate = DateTime.Parse("2022-8-16"),
                 IsStared = EnumStatus.False,
                 IsDeleted = EnumStatus.False
             },
             new Project
             {
                 Id = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                 Name = "BentaSteam",
                 Key = "BS",
                 Access = EnumAccess.Public,
                 Id_Lead = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                 Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // KhietPT
                 DateCreated = DateTime.Parse("2022-10-10"),
                 DateStarted = DateTime.Parse("2022-10-10"),
                 DateEnd = DateTime.Parse("2023-9-21"),
                 Id_Updator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                 UpdateDate = DateTime.Parse("2022-8-16"),
                 IsStared = EnumStatus.False,
                 IsDeleted = EnumStatus.False
             }
            );
        }
    }
}
