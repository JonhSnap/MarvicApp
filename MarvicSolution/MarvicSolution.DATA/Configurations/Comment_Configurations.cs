using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MarvicSolution.DATA.Configurations
{
    class Comment_Configurations : IEntityTypeConfiguration<Comment>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(o => new { o.Id });
            builder.Property(prop => prop.Id_Issue).IsRequired();
            builder.Property(prop => prop.Id_User).IsRequired();
            builder.Property(prop => prop.Content).IsRequired();

            // Data Seeding
            builder.HasData(
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Id_User = Guid.Parse("7A370BAC-B796-454D-84CF-18C603102CA2"),
                    Id_Issue = Guid.Parse("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"),
                    Content = "NhanTTT1 comment",
                    Create_Date = DateTime.Now,
                    Update_Date = DateTime.Now,
                    Is_Delete = EnumStatus.False,
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Id_User = Guid.Parse("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"),
                    Id_Issue = Guid.Parse("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"),
                    Content = "KhanhND comment",
                    Create_Date = DateTime.Now.AddHours(1),
                    Update_Date = DateTime.Now.AddHours(1),
                    Is_Delete = EnumStatus.False,
                }
                );
        }
    }
}
