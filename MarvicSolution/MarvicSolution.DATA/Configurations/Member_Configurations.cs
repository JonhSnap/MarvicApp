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
    class Member_Configurations : IEntityTypeConfiguration<Member>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");
            builder.HasKey(o => new { o.Id_Project, o.Id_User });
            // Data Seeding
            builder.HasData(
                // ===Project ABC===
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_User = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT pass KhietPT@123
                    Role = EnumRole.ProductOwner
                },
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_User = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD pass ThangVD@123
                    Role = EnumRole.ProjectManager
                },
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_User = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT pass NhanNT@123
                    Role = EnumRole.ProjectManager
                },
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_User = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ pass ThinhLQ@123
                    Role = EnumRole.Developer
                },
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_User = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV pass TungNV@123
                    Role = EnumRole.Developer
                },
                // ===Project B===
                new Member
                {
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"), // Project B
                    Id_User = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), // KhanhND
                    Role = EnumRole.ProductOwner
                },
                new Member
                {
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"), // Project B
                    Id_User = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), // User NhanTT
                    Role = EnumRole.ProjectManager
                },
                // ===Project C===
                new Member
                {
                    Id_Project = new Guid("A5329D06-9D32-4A54-B816-906DFBBD288C"), // Project C
                    Id_User = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), // User KhanhND
                    Role = EnumRole.Developer
                },
                // =======Group 2=======
                // #####Project D#####
                new Member
                {
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project D
                    Id_User = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    Role = EnumRole.ProductOwner
                },
                new Member
                {
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project D
                    Id_User = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // User ThangVD
                    Role = EnumRole.Developer
                },
                // #####Project Editor Super#####
                new Member
                {
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"), // Project Editor Super
                    Id_User = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // User ThangVD
                    Role = EnumRole.ProductOwner
                },
                new Member
                {
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"), // Project Editor Super
                    Id_User = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // User ThinhLQ
                    Role = EnumRole.ProjectManager
                },
                new Member
                {
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"), // Project Editor Super
                    Id_User = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // User NhanNT
                    Role = EnumRole.Developer
                }, new Member
                {
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"), // Project Editor Super
                    Id_User = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // User TungNV
                    Role = EnumRole.Developer
                },
                // #####Project Dior Champange#####
                new Member
                {
                    Id_Project = new Guid("7C50EED0-4083-46E2-9C2C-65AE53FE4D88"), // Project Dior Champange
                    Id_User = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // User NhanNT
                    Role = EnumRole.ProjectManager
                },
                new Member
                {
                    Id_Project = new Guid("7C50EED0-4083-46E2-9C2C-65AE53FE4D88"), // Project Dior Champange
                    Id_User = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    Role = EnumRole.Developer
                }
                ,
                // #####Project Efferent Tower#####
                new Member
                {
                    Id_Project = new Guid("CF0A0FE2-F1CA-4941-B691-6BABE389DF99"), // Project Efferent Tower
                    Id_User = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // User ThangVD
                    Role = EnumRole.ProductOwner
                },
                new Member
                {
                    Id_Project = new Guid("CF0A0FE2-F1CA-4941-B691-6BABE389DF99"), // Project Efferent Tower
                    Id_User = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // User ThinhLQ
                    Role = EnumRole.ProjectManager
                },
                new Member
                {
                    Id_Project = new Guid("CF0A0FE2-F1CA-4941-B691-6BABE389DF99"), // Project Efferent Tower
                    Id_User = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // User TungNV
                    Role = EnumRole.Developer
                }
                );
        }
    }
}
