using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MarvicSolution.DATA.Configurations
{
    class Issue_Configurations : IEntityTypeConfiguration<Issue>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issue");
            builder.HasKey(o => new { o.Id });

            // Data Seeding
            builder.HasData(
                // ===Project ABC===
                new Issue
                {
                    Id = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary A",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = Guid.Empty,
                    FileName = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                }, new Issue
                {
                    Id = new Guid("D8F5E8B0-2D90-47BA-A034-D68CA52674C8"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary B",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = Guid.Empty,
                    FileName = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 1,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story Legendary A1",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Seven,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    FileName = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue // -3
                {
                    Id = new Guid("E77D319E-0E2C-4278-98B1-F359576A5CE8"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("5dab4090-30ea-4179-4978-08da5ccf5393"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story Legendary A2",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Seven,
                    Id_Reporter = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    FileName = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 1,
                    IsDeleted = EnumStatus.False
                },
            #region Group Task Who Reporter is KhietPT
                new Issue
                {
                    Id = new Guid("EDFF3F58-7640-4F5A-ADA0-DC017F602501"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("2fba8381-f39d-4061-8efa-71c45269a80a"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.1",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 2,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("DF2E4C8C-36D7-4448-96FC-5FE36363E1D6"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("c7577e61-ce8e-4e2c-4976-08da5ccf5393"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.2",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 3,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("8A30F816-24BD-4FD3-89B3-A0AA3D79D7FF"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("5dab4090-30ea-4179-4978-08da5ccf5393"), // Sprint xxx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.3",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), // NhanTT
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 4,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("0997489F-597E-43F9-AECB-4F55ADBA143E"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.4",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 5,
                    IsDeleted = EnumStatus.False
                },
            #endregion
            #region Group Task Who Reporter is NhanTT
                new Issue
                {
                    Id = new Guid("70E335FC-759D-45E8-826E-8A42B5802633"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.5",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("0B27000F-27E9-4081-A208-29DFF8D3A7AF"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.6",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 1,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("6D6BB4BB-523A-4F79-85A9-6D0A5E85C658"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("6c6b8d2b-9d38-4d9a-4977-08da5ccf5393"), // Sprint xx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.7",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 2,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("4B9A6895-4467-453E-8915-5ED19312FB54"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.8",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 3,
                    IsDeleted = EnumStatus.False
                },
            #endregion
            #region Group Task Who Reporter is TungNV
                new Issue
                {
                    Id = new Guid("B11F2822-BC9A-4C50-9642-2E18B63F298D"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // // Stage xxx
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.9",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Id_Assignee = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.High,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 4,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("0B931EE5-6FAB-4EDD-9725-3F744D837324"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("5dab4090-30ea-4179-4978-08da5ccf5393"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.10",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.High,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 5,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("1645F209-E53F-4D09-840E-2D290D527A01"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.11",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.High,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 6,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("17EA08D6-9C12-4ED9-B83A-3CCDDD7C5911"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage Inprogress
                    Id_Sprint = new Guid("2FBA8381-F39D-4061-8EFA-71C45269A80A"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.12",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Id_Assignee = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.High,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
            #endregion
            #region Group Task Who Reporter is ThinhLQ
                new Issue
                {
                    Id = new Guid("5C8B3016-9C9D-4EBB-8C63-EB241A4A5EBC"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A2.1",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Id_Assignee = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("D8F5E8B0-2D90-47BA-A034-D68CA52674C8"), // Epic Legendary B
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("E10797AE-1FDD-4E89-8DC2-8B88FA822027"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("2FBA8381-F39D-4061-8EFA-71C45269A80A"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A2.2",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Id_Assignee = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("D8F5E8B0-2D90-47BA-A034-D68CA52674C8"), // Epic Legendary B
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 1,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("58112BCE-A689-43A5-B04D-0AD61FF6D071"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("2FBA8381-F39D-4061-8EFA-71C45269A80A"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A2.3",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("D8F5E8B0-2D90-47BA-A034-D68CA52674C8"), // Epic Legendary B
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 2,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("C9047FBC-6472-4802-A01D-3D64E098BC0D"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("c7577e61-ce8e-4e2c-4976-08da5ccf5393"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A2.4",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // User TungNV
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("D8F5E8B0-2D90-47BA-A034-D68CA52674C8"), // Epic Legendary B
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 3,
                    IsDeleted = EnumStatus.False
                },
            #endregion
            #region Group Task Who Reporter is ThangVD
                new Issue
                {
                    Id = new Guid("D7B1F77B-67CC-44EF-96D5-3A38C2085F85"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("6c6b8d2b-9d38-4d9a-4977-08da5ccf5393"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A2.5",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("D8F5E8B0-2D90-47BA-A034-D68CA52674C8"), // Epic Legendary B
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 4,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("9123B434-F70A-4EE6-B0BB-38BDBCB61798"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("6c6b8d2b-9d38-4d9a-4977-08da5ccf5393"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A2.6",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("D8F5E8B0-2D90-47BA-A034-D68CA52674C8"), // Epic Legendary B
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 5,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("90C14ABD-1AC5-4515-8889-24B5950E3E4E"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("c7577e61-ce8e-4e2c-4976-08da5ccf5393"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A2.7",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // User TungNV
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("D8F5E8B0-2D90-47BA-A034-D68CA52674C8"), // Epic Legendary B
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 6,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("F411818D-3735-4A1A-883B-5353FB160B8F"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("c7577e61-ce8e-4e2c-4976-08da5ccf5393"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A2.8",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    FileName = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("D8F5E8B0-2D90-47BA-A034-D68CA52674C8"), // Epic Legendary B
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 4, 22),
                    DateStarted = new DateTime(2022, 4, 23),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 7,
                    IsDeleted = EnumStatus.False
                });
            #endregion
        }
    }
}
