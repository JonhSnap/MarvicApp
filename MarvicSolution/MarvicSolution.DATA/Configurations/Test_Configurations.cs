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
    class Test_Configurations : IEntityTypeConfiguration<Test>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable("Test");
            builder.HasKey(o => new { o.Id });
            // Data Seeding
            builder.HasData(
                new Test
                {
                    Id = new Guid("43D27FB9-CDF2-4A42-AEAC-30D551AD7334"),
                    Name = "Test A",
                    IsDeleted = EnumStatus.False
                },
                new Test
                {
                    Id = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"),
                    Name = "Test B",
                    IsDeleted = EnumStatus.False
                },
                new Test
                {
                    Id = new Guid("D77A4A2D-D886-4658-9438-C800157423E0"),
                    Name = "Test C",
                    IsDeleted = EnumStatus.False
                },
                new Test
                {
                    Id = new Guid("32661992-AAA1-49D6-ADBA-CB55EBBF0C04"),
                    Name = "Test D",
                    IsDeleted = EnumStatus.False
                },
                new Test
                {
                    Id = new Guid("C475D804-0122-4B2B-AF41-F6C53D22BA74"),
                    Name = "Test E",
                    IsDeleted = EnumStatus.False
                },
                new Test
                {
                    Id = new Guid("C7B0D387-AFC8-423D-8218-A3FD83CC850E"),
                    Name = "Test F",
                    IsDeleted = EnumStatus.False
                }
                );
        }
    }
}
