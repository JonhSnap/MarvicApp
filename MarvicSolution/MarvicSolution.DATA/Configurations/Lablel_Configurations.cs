using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MarvicSolution.DATA.Configurations
{
    class Lablel_Configurations : IEntityTypeConfiguration<Label>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("Label");
            builder.HasKey(o => new { o.Id });
            builder.Property(prop => prop.Id_Project).IsRequired();
            builder.Property(prop => prop.Id_Creator).IsRequired();
            builder.Property(prop => prop.Name).IsRequired();
            builder.HasData(
                new Label()
                {
                    Id = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"),
                    Id_Project= new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Name = "BE",
                    Id_Creator = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
                    DateCreated = DateTime.Parse("2021-7-22"),
                    UpdateDate = new DateTime(),
                    Id_Updator = Guid.Empty,
                    isDeleted =  EnumStatus.False
                },
                new Label()
                {
                    Id = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Name = "FE",
                    Id_Creator = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
                    DateCreated = DateTime.Parse("2021-7-23"),
                    UpdateDate = new DateTime(),
                    Id_Updator = Guid.Empty,
                    isDeleted = EnumStatus.False
                }
                );
        }
    }
}
