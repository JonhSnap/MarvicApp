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
                    Role = EnumRole.ProductOwner,
                    IsActive = EnumStatus.True
                },
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_User = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD pass ThangVD@123
                    Role = EnumRole.ProjectManager,
                    IsActive = EnumStatus.True
                },
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_User = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT pass NhanNT@123
                    Role = EnumRole.ProjectManager,
                    IsActive = EnumStatus.True
                },
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_User = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ pass ThinhLQ@123
                    Role = EnumRole.Developer,
                    IsActive = EnumStatus.True
                },
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_User = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV pass TungNV@123
                    Role = EnumRole.Developer,
                    IsActive = EnumStatus.True
                }
                );
        }
    }
}
