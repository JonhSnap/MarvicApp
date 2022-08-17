using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
                    Name = "Create by voice.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("4A69753C-F865-404F-ABD8-43C350222189"),
                    Id_Question = new Guid("DA1969F2-3008-49D3-8281-030B4C343C5D"),
                    Name = "Create with Gestures.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("4E257BA8-35D3-45F0-BAAC-F2B0B98FBEDD"),
                    Id_Question = new Guid("DA1969F2-3008-49D3-8281-030B4C343C5D"),
                    Name = "Click the create project button at the top of the toolbar.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("146980C0-F9A3-4457-8B03-E8511FDFDBC1"),
                    Id_Question = new Guid("DA1969F2-3008-49D3-8281-030B4C343C5D"),
                    Name = "Go to your personal account and select the create project button.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("4C9B7CDA-859B-4C26-B2DF-2002073BBD84"),
                    Id_Question = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "Go to the project and have the button label on the screen.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("944115D0-9566-4E58-B711-23F8869DF029"),
                    Id_Question = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "Search \"label\" in the search box.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("2ADAD43F-5CC2-48D9-97AF-51AD79E41160"),
                    Id_Question = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "Go to the task details to create.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("1616A299-6B7B-4573-ABFA-2C3D40641AB1"),
                    Id_Question = new Guid("5570F4EE-0F7D-4A48-BE63-BC011555DDD2"),
                    Name = "New project will be available and no need to create more.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("A906E299-85D6-4FA9-9138-95083438F304"),
                    Id_Question = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "Click on the list of team members and type the names of the members to add to the project, select and press the add button.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("7AFCCD26-5F50-4810-AAD8-AE0F53B93B0B"),
                    Id_Question = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "Share the link to the project for new members.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("2B8F753C-FDA8-43FA-B5E8-883852367E56"),
                    Id_Question = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "Ans A3-3",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("535050BE-932A-4B9B-A9D7-DBB2EB2CCB25"),
                    Id_Question = new Guid("A8B3AF9F-BAE9-4B1A-89D0-808F7B8B4E56"),
                    Name = "The new project will default to all members as users in the Marvic.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("53C26C0E-944C-4B4D-98A6-48BFABFB484B"),
                    Id_Question = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "The person whose title is Product and Project Manager.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("C4709E72-98C1-4A46-89E1-971DE4143D25"),
                    Id_Question = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "Everyone",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("74FE3EBC-3381-4E9F-A2F4-A6C20114D3D5"),
                    Id_Question = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "Member can add members to Project",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("64D5AD49-DD7D-467F-8A8C-932D00DF8BAB"),
                    Id_Question = new Guid("D60E8B27-D139-40D4-9CC8-3E8D09752A6A"),
                    Name = "Member and Project Manager can add members to Project",
                    IsCorrect = EnumStatus.False
                },
                ////////////////////////
                new Answer
                {
                    Id = new Guid("271542E1-1849-4B92-A7A7-D09B7FBE8651"), // Question A1
                    Id_Question = new Guid("544DE6F8-24F5-444D-AFF5-B5C61DFD7290"),
                    Name = "Create by voice.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("98A24454-5DFF-4C26-A3D4-DCA9A22FA6E8"),
                    Id_Question = new Guid("544DE6F8-24F5-444D-AFF5-B5C61DFD7290"),
                    Name = "Create with Gestures.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("501CD87C-AA20-49E6-9320-1CD3AA032E50"),
                    Id_Question = new Guid("544DE6F8-24F5-444D-AFF5-B5C61DFD7290"),
                    Name = "Click the create project button at the top of the toolbar.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("401A0F4F-EE94-4321-897A-7139EE266F89"),
                    Id_Question = new Guid("544DE6F8-24F5-444D-AFF5-B5C61DFD7290"),
                    Name = "Go to your personal account and select the create project button.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("2D85A9EE-1C2D-4CE7-A1A0-1A64A5B4CD3D"),
                    Id_Question = new Guid("97CF87A9-3FA8-4BC7-AD70-F746AA674922"),
                    Name = "Go to the project and have the button label on the screen.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("16A5239E-493B-4A6F-98FA-88D81941E7FB"),
                    Id_Question = new Guid("97CF87A9-3FA8-4BC7-AD70-F746AA674922"),
                    Name = "Search \"label\" in the search box.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("6F5116B5-FB99-4432-AEE6-DFB8310A31FA"),
                    Id_Question = new Guid("97CF87A9-3FA8-4BC7-AD70-F746AA674922"),
                    Name = "Go to the task details to create.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("17E047B6-7C69-41FA-9F8D-EA562F27FB4A"),
                    Id_Question = new Guid("97CF87A9-3FA8-4BC7-AD70-F746AA674922"),
                    Name = "New project will be available and no need to create more.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("715CD83D-6BDA-4E54-82DB-28021314E02B"),
                    Id_Question = new Guid("0357191A-6A6F-4D9D-9C67-C48AC0653C45"),
                    Name = "Click on the list of team members and type the names of the members to add to the project, select and press the add button.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("D2ED91B4-416B-47C7-A0DD-4C1B5D501206"),
                    Id_Question = new Guid("0357191A-6A6F-4D9D-9C67-C48AC0653C45"),
                    Name = "Share the link to the project for new members.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("EC79BCB5-A5EF-4698-8A85-422EDEC25A5A"),
                    Id_Question = new Guid("0357191A-6A6F-4D9D-9C67-C48AC0653C45"),
                    Name = "Ans A3-3",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("74903595-849B-4BF9-A891-09855138B402"),
                    Id_Question = new Guid("0357191A-6A6F-4D9D-9C67-C48AC0653C45"),
                    Name = "The new project will default to all members as users in the Marvic.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("4B99F606-D718-48EA-8DEF-66B62D08F11B"),
                    Id_Question = new Guid("A066492A-3596-4DD0-B39E-A890FD56EDBB"),
                    Name = "The person whose title is Product and Project Manager.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("28FE3EED-B0A5-4A44-8AD5-EA15D6FF1720"),
                    Id_Question = new Guid("A066492A-3596-4DD0-B39E-A890FD56EDBB"),
                    Name = "Everyone",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("AE1D6690-10DF-4812-9D58-596BD42071F4"),
                    Id_Question = new Guid("A066492A-3596-4DD0-B39E-A890FD56EDBB"),
                    Name = "Member can add members to Project",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("3CF13BB1-707B-4AEC-8409-15105D525861"),
                    Id_Question = new Guid("A066492A-3596-4DD0-B39E-A890FD56EDBB"),
                    Name = "Member and Project Manager can add members to Project",
                    IsCorrect = EnumStatus.False
                },
                //////////////////////////////
                new Answer
                {
                    Id = new Guid("11E48F83-6458-4101-A2AC-A4FBA23B1501"),
                    Id_Question = new Guid("95F5C0DC-D2E6-470E-A45A-BFE0A60D0C13"),
                    Name = "Create by voice.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("84C4E8CD-2AF0-4100-9370-14D79F85FCB4"),
                    Id_Question = new Guid("95F5C0DC-D2E6-470E-A45A-BFE0A60D0C13"),
                    Name = "Create with Gestures.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("B2221EBA-ACA3-4202-AC5E-32969DBA77EE"),
                    Id_Question = new Guid("95F5C0DC-D2E6-470E-A45A-BFE0A60D0C13"),
                    Name = "Click the create project button at the top of the toolbar.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("65D11EA6-0818-4AB7-B383-04912E083FF4"),
                    Id_Question = new Guid("95F5C0DC-D2E6-470E-A45A-BFE0A60D0C13"),
                    Name = "Go to your personal account and select the create project button.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("FBD8360B-D84B-46A4-94D3-E6DC495F7CFF"),
                    Id_Question = new Guid("1151154C-453C-4871-A5EA-C712DCD1BF77"),
                    Name = "Go to the project and have the button label on the screen.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("118A94B6-12BA-44D2-B00C-068071DB9615"),
                    Id_Question = new Guid("1151154C-453C-4871-A5EA-C712DCD1BF77"),
                    Name = "Search \"label\" in the search box.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("B4EDBF20-63E0-421B-95AA-190991BDAA8E"),
                    Id_Question = new Guid("1151154C-453C-4871-A5EA-C712DCD1BF77"),
                    Name = "Go to the task details to create.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("0F5267AF-F206-437D-ADE4-9322D0BE3E02"),
                    Id_Question = new Guid("1151154C-453C-4871-A5EA-C712DCD1BF77"),
                    Name = "New project will be available and no need to create more.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("96A4DEDB-1137-47F1-A4A4-A27252C5E301"),
                    Id_Question = new Guid("E83932FC-11F4-459E-A899-2BDEC7098EC3"),
                    Name = "Click on the list of team members and type the names of the members to add to the project, select and press the add button.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("9F4036C5-F482-4359-99EF-E4066228F0DE"),
                    Id_Question = new Guid("E83932FC-11F4-459E-A899-2BDEC7098EC3"),
                    Name = "Share the link to the project for new members.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("9B2B0D96-1AB2-423D-A360-762DAC62D489"),
                    Id_Question = new Guid("E83932FC-11F4-459E-A899-2BDEC7098EC3"),
                    Name = "Ans A3-3",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("9B854DD6-7371-474E-BE2B-4F4595D7083E"),
                    Id_Question = new Guid("E83932FC-11F4-459E-A899-2BDEC7098EC3"),
                    Name = "The new project will default to all members as users in the Marvic.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("ABFE24C2-FD66-4D53-9B70-1F3428E2AA2F"),
                    Id_Question = new Guid("D77A4A2D-D886-4658-9438-C800157423E0"),
                    Name = "The person whose title is Product and Project Manager.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("09DC1B06-6122-42BA-8901-60B41CDCC091"),
                    Id_Question = new Guid("D77A4A2D-D886-4658-9438-C800157423E0"),
                    Name = "Everyone",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("5376D548-6BD2-4060-9131-5DC69198C090"),
                    Id_Question = new Guid("D77A4A2D-D886-4658-9438-C800157423E0"),
                    Name = "Member can add members to Project",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("1C7778DF-9394-4F07-BE1E-E7C609957762"),
                    Id_Question = new Guid("D77A4A2D-D886-4658-9438-C800157423E0"),
                    Name = "Member and Project Manager can add members to Project",
                    IsCorrect = EnumStatus.False
                },
                //////////////////////////////
                new Answer
                {
                    Id = new Guid("99AE313F-3574-4A8A-9C3B-A98E8F203517"),
                    Id_Question = new Guid("5021B34F-F093-4441-9D5F-1487DCE2B20D"),
                    Name = "Create by voice.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("475C96BA-340D-4C35-8AB1-CBBDCC793EB8"),
                    Id_Question = new Guid("5021B34F-F093-4441-9D5F-1487DCE2B20D"),
                    Name = "Create with Gestures.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("2E490B99-1EC7-426E-9A41-3B2A4F35B0B1"),
                    Id_Question = new Guid("5021B34F-F093-4441-9D5F-1487DCE2B20D"),
                    Name = "Click the create project button at the top of the toolbar.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("61A45BC1-9F5C-499B-B174-EE25235DEAEE"),
                    Id_Question = new Guid("5021B34F-F093-4441-9D5F-1487DCE2B20D"),
                    Name = "Go to your personal account and select the create project button.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("14814AA9-F3B1-4306-A5DF-614D1D8CBAB0"),
                    Id_Question = new Guid("03C09F4A-DC07-4CF5-BE51-37FDDEB25E4F"),
                    Name = "Go to the project and have the button label on the screen.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("1D654A07-70DC-4448-B7F9-45BEE8243681"),
                    Id_Question = new Guid("03C09F4A-DC07-4CF5-BE51-37FDDEB25E4F"),
                    Name = "Search \"label\" in the search box.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("1665FA6D-0E51-45B5-997D-E91EC5222AE7"),
                    Id_Question = new Guid("03C09F4A-DC07-4CF5-BE51-37FDDEB25E4F"),
                    Name = "Go to the task details to create.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("4D9B2045-1B58-45C8-BBDF-DFB29987E9BF"),
                    Id_Question = new Guid("03C09F4A-DC07-4CF5-BE51-37FDDEB25E4F"),
                    Name = "New project will be available and no need to create more.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("F9166320-6570-4F4B-9D52-CAACACD0D516"),
                    Id_Question = new Guid("1D948868-D023-4382-9863-7C001B41EE1C"),
                    Name = "Click on the list of team members and type the names of the members to add to the project, select and press the add button.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("103D612E-C33B-4547-A870-058EC754B649"),
                    Id_Question = new Guid("1D948868-D023-4382-9863-7C001B41EE1C"),
                    Name = "Share the link to the project for new members.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("72A19E19-CA79-46B7-8943-87B17163A434"),
                    Id_Question = new Guid("1D948868-D023-4382-9863-7C001B41EE1C"),
                    Name = "Ans A3-3",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("E5CB5DAA-061C-4B2C-8A0F-DC9D086A6A3D"),
                    Id_Question = new Guid("1D948868-D023-4382-9863-7C001B41EE1C"),
                    Name = "The new project will default to all members as users in the Marvic.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("87245F60-D837-418F-9CE6-2BF2222E5F89"),
                    Id_Question = new Guid("731C2158-9F8E-4152-BB34-F90B971186E0"),
                    Name = "The person whose title is Product and Project Manager.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("D19CAEDA-4FCA-4A40-A978-30549C1FBF6A"),
                    Id_Question = new Guid("731C2158-9F8E-4152-BB34-F90B971186E0"),
                    Name = "Everyone",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("EFEC4C11-043C-432A-8D25-065C8570E707"),
                    Id_Question = new Guid("731C2158-9F8E-4152-BB34-F90B971186E0"),
                    Name = "Member can add members to Project",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("B4FF1F9B-9A8C-498E-A263-41EEBAD51FEE"),
                    Id_Question = new Guid("731C2158-9F8E-4152-BB34-F90B971186E0"),
                    Name = "Member and Project Manager can add members to Project",
                    IsCorrect = EnumStatus.False
                }
                ,
                //////////////////////////////
                new Answer
                {
                    Id = new Guid("F471DCA0-9DB0-45CC-9B4E-C81888D032F6"),
                    Id_Question = new Guid("2AFD5688-B140-4822-969E-A3FDC1C49F78"),
                    Name = "Create by voice.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("B67D88CC-EED4-453C-B0F8-DEC34A458EBF"),
                    Id_Question = new Guid("2AFD5688-B140-4822-969E-A3FDC1C49F78"),
                    Name = "Create with Gestures.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("3FBA83E0-233C-437C-9799-08DAE77206AA"),
                    Id_Question = new Guid("2AFD5688-B140-4822-969E-A3FDC1C49F78"),
                    Name = "Click the create project button at the top of the toolbar.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("76E9348E-23B1-4370-8237-577FB7263164"),
                    Id_Question = new Guid("2AFD5688-B140-4822-969E-A3FDC1C49F78"),
                    Name = "Go to your personal account and select the create project button.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("59185D89-3D6E-4443-9BF3-7505A6A40234"),
                    Id_Question = new Guid("B1EBC5FD-FE91-44D7-87CE-603277F50BA3"),
                    Name = "Go to the project and have the button label on the screen.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("CD095240-04FA-42BE-AFC6-5A36EE16EFD6"),
                    Id_Question = new Guid("B1EBC5FD-FE91-44D7-87CE-603277F50BA3"),
                    Name = "Search \"label\" in the search box.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("A62E2B01-EF2D-4709-9A96-CCAAF6BCB8ED"),
                    Id_Question = new Guid("B1EBC5FD-FE91-44D7-87CE-603277F50BA3"),
                    Name = "Go to the task details to create.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("291AF3AF-F41F-429E-8CC7-4C4D37319328"),
                    Id_Question = new Guid("B1EBC5FD-FE91-44D7-87CE-603277F50BA3"),
                    Name = "New project will be available and no need to create more.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("62EA5ED4-4637-4FAF-965F-A14B69670407"),
                    Id_Question = new Guid("3EB6F523-9CAD-4B1F-8BCF-27FE2296826C"),
                    Name = "Click on the list of team members and type the names of the members to add to the project, select and press the add button.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("CE39D815-5B17-46C2-8A9E-0CD469C9955F"),
                    Id_Question = new Guid("3EB6F523-9CAD-4B1F-8BCF-27FE2296826C"),
                    Name = "Share the link to the project for new members.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("99E392F8-A48E-49BE-9DAD-D21524616564"),
                    Id_Question = new Guid("3EB6F523-9CAD-4B1F-8BCF-27FE2296826C"),
                    Name = "Ans A3-3",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("1E0426AB-3547-48FB-8E32-974639FBBBCD"),
                    Id_Question = new Guid("3EB6F523-9CAD-4B1F-8BCF-27FE2296826C"),
                    Name = "The new project will default to all members as users in the Marvic.",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("3397C55E-8745-4CB9-8F6D-5E47398D65C0"),
                    Id_Question = new Guid("A3CECC3E-D9E8-465F-A41C-1780AFDA4FE6"),
                    Name = "The person whose title is Product and Project Manager.",
                    IsCorrect = EnumStatus.True
                },
                new Answer
                {
                    Id = new Guid("8D0133C8-FFAB-4282-A80A-D83C556B4F63"),
                    Id_Question = new Guid("A3CECC3E-D9E8-465F-A41C-1780AFDA4FE6"),
                    Name = "Everyone",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("8FF204B6-7BE9-4421-AEA1-CC435E00F13F"),
                    Id_Question = new Guid("A3CECC3E-D9E8-465F-A41C-1780AFDA4FE6"),
                    Name = "Member can add members to Project",
                    IsCorrect = EnumStatus.False
                },
                new Answer
                {
                    Id = new Guid("6EED64DF-DEAD-4EE0-A679-89C2DF0D6362"),
                    Id_Question = new Guid("A3CECC3E-D9E8-465F-A41C-1780AFDA4FE6"),
                    Name = "Member and Project Manager can add members to Project",
                    IsCorrect = EnumStatus.False
                }
                );
        }
    }
}
