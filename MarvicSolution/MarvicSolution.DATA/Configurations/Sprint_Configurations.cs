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
                    Create_Date = DateTime.Parse("2021-7-21"),
                    Update_Date = new DateTime(),
                    Start_Date = DateTime.Parse("2021-7-21"),
                    End_Date = DateTime.Parse("2021-7-28"),
                    Is_Archieved=EnumStatus.False,
                    Is_Started= EnumStatus.False

                }, new Sprint()
                {
                    Id = new Guid("87038CA8-11A7-4392-9C3E-86FD04F75223"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project D
                    SprintName = "Sprint First PD",
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Update_Date = DateTime.Parse("2022-6-27"),
                    Create_Date = DateTime.Parse("2022-6-22"),
                    End_Date = DateTime.Parse("2022-6-29"),
                    Start_Date = DateTime.Parse("2022-6-22"),
                    Is_Archieved = EnumStatus.False,
                    Is_Started = EnumStatus.False

                }, new Sprint()
                {
                    Id = new Guid("79F4FE9F-028F-4C2D-AFA8-28601272B031"),
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"), // Project Editor Super
                    SprintName = "Project Editor Super",
                    Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Update_Date = new DateTime(),
                    Create_Date = DateTime.Parse("2022-6-22"),
                    End_Date = DateTime.Parse("2022-6-29"),
                    Start_Date = DateTime.Parse("2022-6-22"),
                    Is_Archieved = EnumStatus.False,
                    Is_Started = EnumStatus.False
                }
            );
        }
    }
}
