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
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project A
                    Id_User = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), // User KhanhND
                    IsDeleted = EnumStatus.False
                },
                new Member
                {
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project A
                    Id_User = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), // User NhanTT
                    IsDeleted = EnumStatus.False
                },
                new Member
                {
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"), // Project B
                    Id_User = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), // User KhanhND
                    IsDeleted = EnumStatus.False
                },
                new Member
                {
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"), // Project B
                    Id_User = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), // User NhanTT
                    IsDeleted = EnumStatus.False
                },
                new Member
                {
                    Id_Project = new Guid("A5329D06-9D32-4A54-B816-906DFBBD288C"), // Project C
                    Id_User = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), // User KhanhND
                    IsDeleted = EnumStatus.False
                }
                );
        }
    }
}
