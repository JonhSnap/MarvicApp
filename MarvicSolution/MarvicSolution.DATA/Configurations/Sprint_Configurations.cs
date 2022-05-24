using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MarvicSolution.DATA.Configurations
{
    class Sprint_Configurations : IEntityTypeConfiguration<Sprint>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            builder.ToTable("Sprint");
            builder.HasKey(o => new { o.Id });
            builder.Property(prop => prop.Id_Project).IsRequired();
            builder.Property(prop => prop.SprintName).IsRequired();

            builder.HasData(
                new Sprint()
                {
                    // ===Project ABC===
                    Id = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), 
                    SprintName = "Sprint A1",
                    Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Create_Date = DateTime.Parse("2022-4-21"),
                    Update_Date = new DateTime(),
                    Start_Date = DateTime.Parse("2022-4-22"),
                    End_Date = DateTime.Parse("2022-5-23"),
                    Is_Archieved=EnumStatus.False,
                    Is_Started= EnumStatus.False

                }, new Sprint()
                {
                    // ===Project ABC===
                    Id = new Guid("2FBA8381-F39D-4061-8EFA-71C45269A80A"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    SprintName = "Sprint A2",
                    Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Create_Date = DateTime.Parse("2022-4-21"),
                    Update_Date = new DateTime(),
                    Start_Date = new DateTime(),
                    End_Date = new DateTime(),
                    Is_Archieved = EnumStatus.False,
                    Is_Started = EnumStatus.False

                }
            );
        }
    }
}
