using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
                    Name = "How to create a project?",
                    Id_Test = new Guid("43D27FB9-CDF2-4A42-AEAC-30D551AD7334"),
                    Scores = EnumPoint.Two
                },
                new Question
                {
                    Id = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "How to create a label?",
                    Id_Test = new Guid("43D27FB9-CDF2-4A42-AEAC-30D551AD7334"),
                    Scores = EnumPoint.Three
                },
                new Question
                {
                    Id = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "How to add members to the project",
                    Id_Test = new Guid("43D27FB9-CDF2-4A42-AEAC-30D551AD7334"),
                    Scores = EnumPoint.Four
                },
                new Question
                {
                    Id = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "Who has the right to add members and create tasks for the project?",
                    Id_Test = new Guid("43D27FB9-CDF2-4A42-AEAC-30D551AD7334"),
                    Scores = EnumPoint.One
                },
                ///
                new Question
                {
                    Id = new Guid("544DE6F8-24F5-444D-AFF5-B5C61DFD7290"),
                    Name = "How to create a project?",
                    Id_Test = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"),
                    Scores = EnumPoint.Two
                },
                new Question
                {
                    Id = new Guid("97CF87A9-3FA8-4BC7-AD70-F746AA674922"),
                    Name = "How to create a label?",
                    Id_Test = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"),
                    Scores = EnumPoint.Three
                },
                new Question
                {
                    Id = new Guid("0357191A-6A6F-4D9D-9C67-C48AC0653C45"),
                    Name = "How to add members to the project",
                    Id_Test = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"),
                    Scores = EnumPoint.Four
                },
                new Question
                {
                    Id = new Guid("A066492A-3596-4DD0-B39E-A890FD56EDBB"),
                    Name = "Who has the right to add members and create tasks for the project?",
                    Id_Test = new Guid("24B1C442-53A2-49BE-A146-C2147540C645"),
                    Scores = EnumPoint.One
                },
                ///
                new Question
                {
                    Id = new Guid("95F5C0DC-D2E6-470E-A45A-BFE0A60D0C13"),
                    Name = "How to create a project?",
                    Id_Test = new Guid("D77A4A2D-D886-4658-9438-C800157423E0"),
                    Scores = EnumPoint.Two
                },
                new Question
                {
                    Id = new Guid("1151154C-453C-4871-A5EA-C712DCD1BF77"),
                    Name = "How to create a label?",
                    Id_Test = new Guid("D77A4A2D-D886-4658-9438-C800157423E0"),
                    Scores = EnumPoint.Three
                },
                new Question
                {
                    Id = new Guid("E83932FC-11F4-459E-A899-2BDEC7098EC3"),
                    Name = "How to add members to the project",
                    Id_Test = new Guid("D77A4A2D-D886-4658-9438-C800157423E0"),
                    Scores = EnumPoint.Four
                },
                new Question
                {
                    Id = new Guid("8AE4ADC0-EA34-44F8-A8D8-5B029E261649"),
                    Name = "Who has the right to add members and create tasks for the project?",
                    Id_Test = new Guid("D77A4A2D-D886-4658-9438-C800157423E0"),
                    Scores = EnumPoint.One
                },
                ///
                new Question
                {
                    Id = new Guid("5021B34F-F093-4441-9D5F-1487DCE2B20D"),
                    Name = "How to create a project?",
                    Id_Test = new Guid("32661992-AAA1-49D6-ADBA-CB55EBBF0C04"),
                    Scores = EnumPoint.Two
                },
                new Question
                {
                    Id = new Guid("03C09F4A-DC07-4CF5-BE51-37FDDEB25E4F"),
                    Name = "How to create a label?",
                    Id_Test = new Guid("32661992-AAA1-49D6-ADBA-CB55EBBF0C04"),
                    Scores = EnumPoint.Three
                },
                new Question
                {
                    Id = new Guid("1D948868-D023-4382-9863-7C001B41EE1C"),
                    Name = "How to add members to the project",
                    Id_Test = new Guid("32661992-AAA1-49D6-ADBA-CB55EBBF0C04"),
                    Scores = EnumPoint.Four
                },
                new Question
                {
                    Id = new Guid("731C2158-9F8E-4152-BB34-F90B971186E0"),
                    Name = "Who has the right to add members and create tasks for the project?",
                    Id_Test = new Guid("32661992-AAA1-49D6-ADBA-CB55EBBF0C04"),
                    Scores = EnumPoint.One
                },
                ///
                new Question
                {
                    Id = new Guid("2AFD5688-B140-4822-969E-A3FDC1C49F78"),
                    Name = "How to create a project?",
                    Id_Test = new Guid("C475D804-0122-4B2B-AF41-F6C53D22BA74"),
                    Scores = EnumPoint.Two
                },
                new Question
                {
                    Id = new Guid("B1EBC5FD-FE91-44D7-87CE-603277F50BA3"),
                    Name = "How to create a label?",
                    Id_Test = new Guid("C475D804-0122-4B2B-AF41-F6C53D22BA74"),
                    Scores = EnumPoint.Three
                },
                new Question
                {
                    Id = new Guid("3EB6F523-9CAD-4B1F-8BCF-27FE2296826C"),
                    Name = "How to add members to the project",
                    Id_Test = new Guid("C475D804-0122-4B2B-AF41-F6C53D22BA74"),
                    Scores = EnumPoint.Four
                },
                new Question
                {
                    Id = new Guid("A3CECC3E-D9E8-465F-A41C-1780AFDA4FE6"),
                    Name = "Who has the right to add members and create tasks for the project?",
                    Id_Test = new Guid("C475D804-0122-4B2B-AF41-F6C53D22BA74"),
                    Scores = EnumPoint.One
                }
                );
        }
    }
}
