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
                    Create_Date = DateTime.Parse("2022-07-03"),
                    Update_Date = DateTime.Parse("2022-07-10"),
                    Start_Date = DateTime.Parse("2022-07-03"),
                    End_Date = DateTime.Parse("2022-07-10"),
                    Is_Archieved=EnumStatus.True,
                    Is_Started= EnumStatus.True
                }, new Sprint()
                {
                    // ===Project ABC===
                    Id = new Guid("2FBA8381-F39D-4061-8EFA-71C45269A80A"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    SprintName = "Sprint A2",
                    Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Create_Date = DateTime.Parse("2022-07-09"),
                    Update_Date = DateTime.Parse("2022-07-18"),
                    Start_Date = DateTime.Parse("2022-07-09"),
                    End_Date = DateTime.Parse("2022-07-18"),
                    Is_Archieved = EnumStatus.True,
                    Is_Started = EnumStatus.True
                }////////////////////////////////////////
                , new Sprint()
                {
                    // ===Project ABC===
                    Id = new Guid("5dab4090-30ea-4179-4978-08da5ccf5393"),
                    Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                    SprintName = "Sprint 1",
                    Id_Creator = new Guid("ec32bffd-121f-405f-b7c5-5e2ab4ba7e27"), // KhietPT
                    Create_Date = DateTime.Parse("2022-07-03"),
                    Update_Date = DateTime.Parse("2022-07-18"),
                    Start_Date = DateTime.Parse("2022-07-03"),
                    End_Date = DateTime.Parse("0001-01-01"),
                    Is_Archieved = EnumStatus.True,
                    Is_Started = EnumStatus.True
                }, new Sprint()
                {
                    // ===Project ABC===
                    Id = new Guid("6c6b8d2b-9d38-4d9a-4977-08da5ccf5393"),
                    Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                    SprintName = "Sprint 3",
                    Id_Creator = new Guid("ec32bffd-121f-405f-b7c5-5e2ab4ba7e27"), // KhietPT
                    Create_Date = DateTime.Parse("2022-07-19"),
                    Update_Date = DateTime.Parse("2022-08-03"),
                    Start_Date = DateTime.Parse("2022-07-19"),
                    End_Date = DateTime.Parse("2022-08-03"),
                    Is_Archieved = EnumStatus.True,
                    Is_Started = EnumStatus.True
                }, new Sprint()
                {
                    // ===Project ABC===
                    Id = new Guid("c7577e61-ce8e-4e2c-4976-08da5ccf5393"),
                    Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                    SprintName = "Sprint 4",
                    Id_Creator = new Guid("ec32bffd-121f-405f-b7c5-5e2ab4ba7e27"), // KhietPT
                    Create_Date = DateTime.Parse("2022-07-18"),
                    Update_Date = DateTime.Parse("2022-07-26"),
                    Start_Date = DateTime.Parse("2022-07-18"),
                    End_Date = DateTime.Parse("2022-07-26"),
                    Is_Archieved = EnumStatus.True,
                    Is_Started = EnumStatus.True
                }
            );
        }
    }
}
