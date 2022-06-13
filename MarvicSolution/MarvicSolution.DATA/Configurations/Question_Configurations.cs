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
    class Question_Configurations : IEntityTypeConfiguration<Question>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");
            builder.HasKey(o => new { o.Id });
            // Data Seeding

            builder.HasData(
                new Question
                {
                    Id = new Guid("DA1969F2-3008-49D3-8281-030B4C343C5D"), // Test A
                    Name = "Question A1",
                    Id_Test = new Guid("43D27FB9-CDF2-4A42-AEAC-30D551AD7334"),
                    Scores = EnumPoint.Two                    
                },
                new Question
                {
                    Id = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "Question A2",
                    Id_Test = new Guid("43D27FB9-CDF2-4A42-AEAC-30D551AD7334"),
                    Scores = EnumPoint.Three                    
                },
                new Question
                {
                    Id = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "Question A3",
                    Id_Test = new Guid("43D27FB9-CDF2-4A42-AEAC-30D551AD7334"),
                    Scores = EnumPoint.Four                    
                },
                new Question
                {
                    Id = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "Question A4",
                    Id_Test = new Guid("43D27FB9-CDF2-4A42-AEAC-30D551AD7334"),
                    Scores = EnumPoint.One                    
                },
                new Question
                {
                    Id = new Guid("1D641D48-F550-481B-ADFF-440ED5AA6F65"),
                    Name = "Question B1",
                    Id_Test = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"), // Test B
                    Scores = EnumPoint.Six                    
                },
                new Question
                {
                    Id = new Guid("B776EF62-50A5-4998-AA13-A6D3F4CA35E4"),
                    Name = "Question B2",
                    Id_Test = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"),
                    Scores = EnumPoint.Two                    
                }, new Question
                {
                    Id = new Guid("7CF4E8F0-9DD9-438D-8581-57D33AD90B78"),
                    Name = "Question B3",
                    Id_Test = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"),
                    Scores = EnumPoint.One                    
                }, new Question
                {
                    Id = new Guid("5D6E0EC4-CBD9-43D9-8330-4B76405808AE"),
                    Name = "Question B4",
                    Id_Test = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"),
                    Scores = EnumPoint.One                    
                }, new Question
                {
                    Id = new Guid("F0869FF6-3127-4714-A75D-720D198C59E5"),
                    Name = "Question B5",
                    Id_Test = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"),
                    Scores = EnumPoint.One                    
                }
                );
        }
    }
}
