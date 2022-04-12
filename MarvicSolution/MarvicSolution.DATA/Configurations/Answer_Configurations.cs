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
    class Answer_Configurations : IEntityTypeConfiguration<Answer>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answer");
            builder.HasKey(o => new { o.Id });

            // Data Seeding
            builder.HasData(
                new Answer
                {
                    Id = new Guid("69A58C4B-C2E1-455D-9559-4169162C1BBF"), // Question A1
                    Id_Question = new Guid("DA1969F2-3008-49D3-8281-030B4C343C5D"),
                    Name = "Ans A1-1",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("4A69753C-F865-404F-ABD8-43C350222189"),
                    Id_Question = new Guid("DA1969F2-3008-49D3-8281-030B4C343C5D"),
                    Name = "Ans A1-2",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("4E257BA8-35D3-45F0-BAAC-F2B0B98FBEDD"),
                    Id_Question = new Guid("DA1969F2-3008-49D3-8281-030B4C343C5D"),
                    Name = "Ans A1-3",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("146980C0-F9A3-4457-8B03-E8511FDFDBC1"),
                    Id_Question = new Guid("DA1969F2-3008-49D3-8281-030B4C343C5D"),
                    Name = "Ans A1-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("4C9B7CDA-859B-4C26-B2DF-2002073BBD84"), // Question A2
                    Id_Question = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "Ans A2-1",
                    IsAnswer = EnumStatus.True,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("944115D0-9566-4E58-B711-23F8869DF029"),
                    Id_Question = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "Ans A2-2",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("2ADAD43F-5CC2-48D9-97AF-51AD79E41160"),
                    Id_Question = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "Ans A2-3",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("1616A299-6B7B-4573-ABFA-2C3D40641AB1"),
                    Id_Question = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "Ans A2-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("A906E299-85D6-4FA9-9138-95083438F304"), // Question A3
                    Id_Question = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "Ans A3-1",
                    IsAnswer = EnumStatus.True,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("7AFCCD26-5F50-4810-AAD8-AE0F53B93B0B"),
                    Id_Question = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "Ans A3-2",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("2B8F753C-FDA8-43FA-B5E8-883852367E56"),
                    Id_Question = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "Ans A3-3",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("535050BE-932A-4B9B-A9D7-DBB2EB2CCB25"),
                    Id_Question = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "Ans A3-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("53C26C0E-944C-4B4D-98A6-48BFABFB484B"),  // Question A4
                    Id_Question = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "Ans A4-1",
                    IsAnswer = EnumStatus.True,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("C4709E72-98C1-4A46-89E1-971DE4143D25"),
                    Id_Question = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "Ans A4-2",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("74FE3EBC-3381-4E9F-A2F4-A6C20114D3D5"),
                    Id_Question = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "Ans A4-3",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("64D5AD49-DD7D-467F-8A8C-932D00DF8BAB"),
                    Id_Question = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "Ans A4-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("1FF50D10-DD8E-4DA1-BB11-1FCBBC1E3C10"),  // Question B1
                    Id_Question = new Guid("1D641D48-F550-481B-ADFF-440ED5AA6F65"),
                    Name = "Ans B1-1",
                    IsAnswer = EnumStatus.True,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("BC8EACEC-EFA8-4288-B97D-D2D61BE430FE"),
                    Id_Question = new Guid("1D641D48-F550-481B-ADFF-440ED5AA6F65"),
                    Name = "Ans B1-2",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("77F88EC5-4F24-45CF-9655-3C7931E33507"),
                    Id_Question = new Guid("1D641D48-F550-481B-ADFF-440ED5AA6F65"),
                    Name = "Ans B1-3",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("5CE3DE4E-E51A-40DE-983F-A15207DA423E"),
                    Id_Question = new Guid("1D641D48-F550-481B-ADFF-440ED5AA6F65"),
                    Name = "Ans B1-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("08139B92-015C-47E1-8F8A-50134C2E7A89"),  // Question B2
                    Id_Question = new Guid("B776EF62-50A5-4998-AA13-A6D3F4CA35E4"),
                    Name = "Ans B2-1",
                    IsAnswer = EnumStatus.True,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("C666592A-6D7D-4A54-9CCF-E0D866167F39"),
                    Id_Question = new Guid("B776EF62-50A5-4998-AA13-A6D3F4CA35E4"),
                    Name = "Ans B2-2",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("315B2B1E-F044-418C-841D-027F89432209"),
                    Id_Question = new Guid("B776EF62-50A5-4998-AA13-A6D3F4CA35E4"),
                    Name = "Ans B2-3",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("6409DB52-2B3C-45FB-AC46-91D050D57EB0"),
                    Id_Question = new Guid("B776EF62-50A5-4998-AA13-A6D3F4CA35E4"),
                    Name = "Ans B2-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("8F737006-062B-4B5A-BA2A-35EECF3A5F95"), // Question B3
                    Id_Question = new Guid("7CF4E8F0-9DD9-438D-8581-57D33AD90B78"),
                    Name = "Ans B3-1",
                    IsAnswer = EnumStatus.True,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("AD954FC8-9344-40E9-8D1F-3B08490F7A7F"),
                    Id_Question = new Guid("7CF4E8F0-9DD9-438D-8581-57D33AD90B78"),
                    Name = "Ans B3-2",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("4987BE92-0627-4AC3-87D3-3771DC83BCF5"),
                    Id_Question = new Guid("7CF4E8F0-9DD9-438D-8581-57D33AD90B78"),
                    Name = "Ans B3-3",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("FE4B0FB6-CC5C-4F1B-B617-977D76497B40"),
                    Id_Question = new Guid("7CF4E8F0-9DD9-438D-8581-57D33AD90B78"),
                    Name = "Ans B3-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("2A9BC99A-F323-4002-B6AF-7DE602692EC4"), // Question B4
                    Id_Question = new Guid("5D6E0EC4-CBD9-43D9-8330-4B76405808AE"),
                    Name = "Ans B4-1",
                    IsAnswer = EnumStatus.True,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("91BBFE96-D736-4B9D-B592-009DD0A28801"),
                    Id_Question = new Guid("5D6E0EC4-CBD9-43D9-8330-4B76405808AE"),
                    Name = "Ans B4-2",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("804E778F-EEEB-4375-8486-E9991E0DD8B3"),
                    Id_Question = new Guid("5D6E0EC4-CBD9-43D9-8330-4B76405808AE"),
                    Name = "Ans B4-3",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("9E213971-75F6-48CD-B948-A3390C767EB7"),
                    Id_Question = new Guid("5D6E0EC4-CBD9-43D9-8330-4B76405808AE"),
                    Name = "Ans B4-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("1BF39DBF-863E-42D9-94AE-3BA9745B5C84"), // Question B5
                    Id_Question = new Guid("F0869FF6-3127-4714-A75D-720D198C59E5"),
                    Name = "Ans B4-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("3EABB060-8923-468B-B530-D5B68E544B58"),
                    Id_Question = new Guid("F0869FF6-3127-4714-A75D-720D198C59E5"),
                    Name = "Ans B4-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("9C4201BA-E32D-4E33-9514-12023D843C48"),
                    Id_Question = new Guid("F0869FF6-3127-4714-A75D-720D198C59E5"),
                    Name = "Ans B4-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("9A2A82A3-B504-487E-A302-B293AC9921FC"),
                    Id_Question = new Guid("F0869FF6-3127-4714-A75D-720D198C59E5"),
                    Name = "Ans B4-4",
                    IsAnswer = EnumStatus.False,
                    IsDeleted = EnumStatus.False
                }
                );
        }
    }
}
