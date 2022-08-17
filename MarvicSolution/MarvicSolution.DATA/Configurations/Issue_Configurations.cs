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
                // ===Marvic Academy===
                new Issue
                {
                    Id = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Marvic Academy
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary A",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Marvic Academy
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary B",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Summary = "Design Front-end Legendary",
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
                new Issue
                {
                    Id = new Guid("E77D319E-0E2C-4278-98B1-F359576A5CE8"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("5dab4090-30ea-4179-4978-08da5ccf5393"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Design database for Back-end Legendary",
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
                new Issue
                {
                    Id = new Guid("EDFF3F58-7640-4F5A-ADA0-DC017F602501"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("2fba8381-f39d-4061-8efa-71c45269a80a"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Draft design database Legendary",
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
                    Summary = "Select database technology Legendary",
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
                    Summary = "Using Entity Framework to connect database SQL Legendary",
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
                    Summary = "Implement api login Legendary",
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
                new Issue
                {
                    Id = new Guid("70E335FC-759D-45E8-826E-8A42B5802633"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement CRUD api Project Legendary",
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
                    Summary = "Implement api CRUD issue Legendary",
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
                    Summary = "Implement api CRUD User Legendary",
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
                    Summary = "Implement api CRUD Stage Legendary",
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
                new Issue
                {
                    Id = new Guid("B11F2822-BC9A-4C50-9642-2E18B63F298D"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // // Stage xxx
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Implement api CRUD User Legendary",
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
                    Summary = "Using api User to render interface Legendary",
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
                    Summary = "Using api Project to render interface Legendary",
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
                    Summary = "Using api Project to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("5C8B3016-9C9D-4EBB-8C63-EB241A4A5EBC"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Issue to render interface Legendary",
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
                //////////////////////////
                new Issue
                {
                    Id = new Guid("8489F7C5-AED8-4AAA-9ABB-ED6339737E59"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Implement CRUD api Project Legendary",
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
                    Id = new Guid("27E278E1-7F9B-48BE-90E9-69B20167624A"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Implement api login Legendary",
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
                    Id = new Guid("4EE83919-9019-471B-8DEA-0D3637163184"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using Entity Framework to connect database SQL Legendary",
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
                    Id = new Guid("38B17589-AD0F-4080-B944-11749C58BDDF"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Select database technology Legendary",
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
                    Id = new Guid("A6E73D1E-0921-43D2-8E42-3041BC038CC2"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design database Legendary",
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
                    Id = new Guid("2962D271-20A9-4D8B-BDA7-041D80727059"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design database for Back-end Legendary",
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
                    Id = new Guid("B2BD199A-4B69-4224-8832-81F44C1F6331"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design Front-end Legendary",
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
                    Id = new Guid("FD0EA8CD-D66D-4A8D-BAE8-5BA491775692"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design Front-end Legendary",
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
                    Id = new Guid("E0532702-FC32-427A-B93F-DAC8FE4B0D39"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Implement api CRUD Stage Legendary",
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
                    Id = new Guid("85068DC1-BF2E-4B5C-AF99-B0F4F7C281AD"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage to do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Implement api login Legendary",
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
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("32B6BA3C-D26E-4D7A-B8E9-BA26C36CCB1C"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design a default page",
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
                    Id = new Guid("A7D26D48-D0B8-4D5A-BC24-5D8AB1621EDF"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Research techniques",
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
                    Id = new Guid("E6C202A2-5FF6-4DD5-9A08-2821384542DB"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Create a user guide page",
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
                    Id = new Guid("2A9952F3-BE32-4676-8621-A43C47B8CC69"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Make loading animation",
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
                    Id = new Guid("8E2AB412-9A35-4D13-9C17-9C1B75183FDA"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Set default date for a new task",
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
                    Id = new Guid("8FC7EC60-8CC7-4271-B20A-B8C582F48122"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate point for user",
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
                    Id = new Guid("B49EB431-698A-45BC-81AF-64A65A0E8C41"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate statistical data",
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
                    Id = new Guid("873B6BFD-F3AD-45E2-A625-5C5F0B868F0D"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Apply redux to project",
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
                    Id = new Guid("6BB84824-F1C2-48E6-A3C2-BFD1909A059D"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design using Figma",
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
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Archive to render interface Legendary",
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
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Comment to render interface Legendary",
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
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Member to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("D7B1F77B-67CC-44EF-96D5-3A38C2085F85"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Question to render interface Legendary",
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
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Answer to render interface Legendary",
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
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Stage to render interface Legendary",
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
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Test all functions of FE",
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
                },
                new Issue
                {
                    Id = new Guid("32CEC038-9515-4417-BE4F-8BE8476E6F33"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"), // Marvic Academy
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary A",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Id = new Guid("AF2A08D1-6E4C-46DA-8C85-25E280A696BC"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary B",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Id = new Guid("3703EEBF-C82B-45CB-9673-0853B3F1F576"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Design Front-end Legendary",
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
                    Id = new Guid("1870677F-7EF4-4161-9846-606009AD4ECC"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Design database for Back-end Legendary",
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
                new Issue
                {
                    Id = new Guid("CDAF4340-59C6-4076-B36E-A0DF83BC84D0"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Draft design database Legendary",
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
                    Id = new Guid("B2370686-07E7-4DE6-98F4-D89849426A99"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Select database technology Legendary",
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
                    Id = new Guid("0AF9C166-0866-4E95-8A05-81E4A075749D"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Using Entity Framework to connect database SQL Legendary",
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
                    Id = new Guid("B2DA4C1F-E759-41F4-BB71-FE07E98DFC09"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api login Legendary",
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
                new Issue
                {
                    Id = new Guid("B82D8F53-D40E-4C63-96E1-4A6FE448C956"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement CRUD api Project Legendary",
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
                    Id = new Guid("177C237B-7C28-4C32-9748-F4241BE03AE6"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD issue Legendary",
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
                    Id = new Guid("CC46D7EE-C83F-4126-8109-9470CAC9C17C"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD User Legendary",
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
                    Id = new Guid("B17A95FF-F1F0-44C9-8F48-72FA082DF114"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD Stage Legendary",
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
                new Issue
                {
                    Id = new Guid("96331EFA-2216-46D5-B654-17D5363F35DA"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Implement api CRUD User Legendary",
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
                    Id = new Guid("EE321AE1-CD4A-4430-9EE9-0E70C23783FB"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api User to render interface Legendary",
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
                    Id = new Guid("75A5F2B0-AEA9-4B5D-941F-84FFE7262D1B"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Project to render interface Legendary",
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
                    Id = new Guid("B988AEF7-66BC-43D1-85B9-31FFEDFFC15B"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Project to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("71327E94-0AAE-4B91-98F8-BC9F72150CB3"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Issue to render interface Legendary",
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
                    Id = new Guid("8DEB78F8-E612-420A-AC91-54F92B64D4B0"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design a default page",
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
                    Id = new Guid("C0CD1759-605A-4212-881A-EF10400B16ED"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Research techniques",
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
                    Id = new Guid("E1E336D4-FA62-4245-A7FE-FA72EA21E192"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Create a user guide page",
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
                    Id = new Guid("AA539EDF-6791-4E53-B5F6-6212C18C3664"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Make loading animation",
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
                    Id = new Guid("23C23F98-1897-4266-B800-82048621FA26"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Set default date for a new task",
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
                    Id = new Guid("53E721C2-6CC5-4913-9EE1-9F3081D7AFD9"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate point for user",
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
                    Id = new Guid("83B0DB7C-CB02-4152-B8EB-AF995C7A14EA"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate statistical data",
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
                    Id = new Guid("0E95915A-7259-4E97-9851-64D7B796635B"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Apply redux to project",
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
                    Id = new Guid("04C2723C-D383-4A2C-B37C-0A517FC30FAE"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design using Figma",
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
                    Id = new Guid("C37F8070-9A7F-4259-AC98-7F9063822D93"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Archive to render interface Legendary",
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
                    Id = new Guid("367F7E6F-9AB3-4812-A0B2-4429930E4304"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Comment to render interface Legendary",
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
                    Id = new Guid("0B4A6E3D-6C4A-4FB7-B920-4DB84D6242C5"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Member to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("8BB0298F-E8A7-460F-8F30-BB0A87EDC6F7"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Question to render interface Legendary",
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
                    Id = new Guid("E77B3CB9-9341-4841-A46B-835B7F3AD8B9"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Answer to render interface Legendary",
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
                    Id = new Guid("AB998709-A8BC-4968-8F13-936E1429BAE3"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Stage to render interface Legendary",
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
                    Id = new Guid("A466716E-BC49-4377-B88A-D542EC2DB7AB"),
                    Id_Project = new Guid("1C843CDE-0BAA-47FB-ABFA-926E816BDABA"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = Guid.Empty, // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Test all functions of FE",
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
                },
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("4941BAE0-CEC7-46AB-8C8A-7AD5DEAEAEDB"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design a default page",
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
                    Id = new Guid("2CEA815A-B649-4BD7-9371-DE9F60627A32"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Research techniques",
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
                    Id = new Guid("423924E6-2137-4943-B846-08E91EB7874F"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Create a user guide page",
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
                    Id = new Guid("05C7193B-A03E-455C-97A2-4135FA9A376E"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Make loading animation",
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
                    Id = new Guid("29740E69-2C05-4D23-BE0B-B19BA0DFDF4D"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Set default date for a new task",
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
                    Id = new Guid("24AF94FD-D0C4-4201-88C8-FA62FB97CACA"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate point for user",
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
                    Id = new Guid("24526922-B51D-4DE9-9CEF-1C85F0672480"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate statistical data",
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
                    Id = new Guid("32E195E2-3E32-448F-A6E7-C06F3BD895CF"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Apply redux to project",
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
                    Id = new Guid("C4814A04-39F6-4DAC-B64A-1B898A88A68B"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design using Figma",
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
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("E11E9688-9157-455B-AED2-34176B8B826F"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Archive to render interface Legendary",
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
                    Id = new Guid("5A39C91D-BA5E-46DC-8F7D-68E8BBE421BD"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Comment to render interface Legendary",
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
                    Id = new Guid("A647AC71-B7AE-48B6-BEB0-39A7946C69F3"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Member to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("FDFB07AB-15F4-46FB-9142-E4AA60C4E288"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Question to render interface Legendary",
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
                    Id = new Guid("51B109F0-AA0F-4227-8445-1789A5A636F7"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Answer to render interface Legendary",
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
                    Id = new Guid("4C30AFC7-4BB8-40B4-B54B-8A127DE1CA0E"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Stage to render interface Legendary",
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
                    Id = new Guid("EB036C1B-7955-4B17-B673-9EB1D5804901"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Test all functions of FE",
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
                },
                ///////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("7C2702CE-4F03-4076-901C-EAA00DFC42BF"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"), // Marvic Academy
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary A",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Id = new Guid("7031A34B-92CE-4897-B0E3-201D9FEB59DE"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary B",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Id = new Guid("AF0F7697-ACF5-4B73-811D-665F52D7B58C"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Design Front-end Legendary",
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
                    Id = new Guid("2B25EC90-5605-4F11-8729-D4040085B88C"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Design database for Back-end Legendary",
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
                new Issue
                {
                    Id = new Guid("89EF02C9-8D41-4CC2-A15C-E69624E49A65"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Draft design database Legendary",
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
                    Id = new Guid("8ED5D8DE-902D-41B5-9631-95703E7FDE62"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Select database technology Legendary",
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
                    Id = new Guid("048C681C-3EE7-482E-B605-1F0B501D379B"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Using Entity Framework to connect database SQL Legendary",
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
                    Id = new Guid("FABF77C0-B032-46CC-8FAB-BD3C23C09E88"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api login Legendary",
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
                new Issue
                {
                    Id = new Guid("FCD341E6-3FEC-45AC-9ACD-11A7FCF9AF20"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement CRUD api Project Legendary",
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
                    Id = new Guid("3DCDF650-EB83-495E-BBD7-CE27562F91DC"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD issue Legendary",
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
                    Id = new Guid("FDEEB299-A7C3-4511-AAF5-C1B40993AACD"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD User Legendary",
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
                    Id = new Guid("698B2E95-0F45-4C74-893D-BF52A0C562D6"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD Stage Legendary",
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
                new Issue
                {
                    Id = new Guid("1CF9147D-4CEC-42FA-8551-D978BDBE2D01"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Implement api CRUD User Legendary",
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
                    Id = new Guid("D8D8AF41-3AA2-4EB7-9AE9-B8A20D9BCB72"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api User to render interface Legendary",
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
                    Id = new Guid("0611FEFF-3A40-46C6-A45E-69D9D2941CCC"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Project to render interface Legendary",
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
                    Id = new Guid("BA40C130-7C08-4343-86C7-0949B24169A9"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Project to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("D10C3F1F-FADB-4749-9BE2-0B05DB68AD3D"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Issue to render interface Legendary",
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
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("42498BC7-CA78-4B7D-B2BB-263933344FBB"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design a default page",
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
                    Id = new Guid("D94239ED-B039-49B6-AAB4-EFAF947A4CBF"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Research techniques",
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
                    Id = new Guid("30165471-687D-4728-96A4-76775FAF144B"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Create a user guide page",
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
                    Id = new Guid("5F551B1B-F529-462A-BED0-29C8BCBDF35F"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Make loading animation",
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
                    Id = new Guid("E9286238-86C1-4EC4-BCE6-9268E38FED9D"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Set default date for a new task",
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
                    Id = new Guid("46A564F8-28D3-47FD-A815-0695CD9DD351"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate point for user",
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
                }
                // =========================================================================================================OK
                ,
                new Issue
                {
                    Id = new Guid("B6CCC395-EB0D-4A85-A9C8-314E4BA67476"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate statistical data",
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
                    Id = new Guid("51249447-FC6F-447F-979E-46DEA8143481"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Apply redux to project",
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
                    Id = new Guid("E14574A9-62B7-4C66-80BE-EE3B7B6BB6A4"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design using Figma",
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
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("89830745-202C-447B-A3DB-2D76B74B6219"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Archive to render interface Legendary",
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
                    Id = new Guid("94BC5E07-E2A4-4E66-8544-1D2EA72D5EC8"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Comment to render interface Legendary",
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
                    Id = new Guid("70C2C334-CC0F-4CA0-9800-EAABF63D60E7"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Member to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("CF611BFF-1E15-47F8-A357-1E0AEE686074"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Question to render interface Legendary",
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
                    Id = new Guid("CB1ECE7B-EF9E-4D2A-B07C-C28BA336B83C"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Answer to render interface Legendary",
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
                    Id = new Guid("42E765FF-FEC0-4A5E-981E-CC9B2A869D3E"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Stage to render interface Legendary",
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
                    Id = new Guid("C0E1A455-138C-4915-B125-8F25925F2985"),
                    Id_Project = new Guid("5BAE647F-C584-4292-BFF2-C6CBEA7117A4"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Test all functions of FE",
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
                },
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("E5D08DB6-8164-46A8-A7B8-629A2D53998E"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design a default page",
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
                    Id = new Guid("F41670E7-C973-4ADF-B1C0-20BB599B1804"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Research techniques",
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
                    Id = new Guid("60D1440E-69BB-4108-9B60-A6CFF48B779D"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Create a user guide page",
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
                    Id = new Guid("1ED946B5-B26E-4740-B0B0-6144454BAC69"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Make loading animation",
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
                    Id = new Guid("7FCB12F4-BED1-47F6-A2A0-DAB71D775D00"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Set default date for a new task",
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
                    Id = new Guid("BB277C55-2315-4EE6-BA1E-4F5D7944025F"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate point for user",
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
                    Id = new Guid("5441C521-7B4D-4CF1-9CD4-3D1EF3B3FCE3"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate statistical data",
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
                    Id = new Guid("96CFE064-F5FE-4A8F-AB69-7CC805E377AC"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Apply redux to project",
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
                    Id = new Guid("6C236117-2716-4AA9-BB68-D6678D6F221B"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design using Figma",
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
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("10A11BEB-C207-474A-8BF8-A6B487C12290"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Archive to render interface Legendary",
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
                    Id = new Guid("0CDA029E-96E4-48C8-93DF-FCCDE39DF135"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Comment to render interface Legendary",
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
                    Id = new Guid("DC51287D-6ACD-480F-ADBA-E30F901CDDF1"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Member to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("7F78938C-E7C2-44B9-91C2-FC6E52E68D27"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Question to render interface Legendary",
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
                    Id = new Guid("361D16E2-072F-44D7-A889-41ED3C620691"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Answer to render interface Legendary",
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
                    Id = new Guid("948D662D-B334-47A5-BFFB-D99ECD5E516C"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Stage to render interface Legendary",
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
                    Id = new Guid("69B3A95C-1964-4548-807A-DC2ED3D23963"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Test all functions of FE",
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
                },
                ///////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("CF388168-A299-42F2-B101-98039BCFF7CB"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"), // Marvic Academy
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary A",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Id = new Guid("66964CA1-4AA4-461E-8B85-2FD23264271C"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary B",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Id = new Guid("E2009416-3487-44AF-8300-65C8B3CAF5E9"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Design Front-end Legendary",
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
                    Id = new Guid("5877CB3F-76C9-4B6E-A32E-3517AD1738DE"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Design database for Back-end Legendary",
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
                new Issue
                {
                    Id = new Guid("BA580A5A-100E-4ACA-89B9-122077F7EA9D"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Draft design database Legendary",
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
                    Id = new Guid("B4388E5D-320C-4EFE-890D-BB2F24A484DD"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Select database technology Legendary",
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
                    Id = new Guid("F8AAFEAB-E150-49D3-84EE-D12A053433DA"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Using Entity Framework to connect database SQL Legendary",
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
                    Id = new Guid("E91885D0-2435-49C0-A522-0999A45674E8"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api login Legendary",
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
                new Issue
                {
                    Id = new Guid("CD6264E5-4E8D-4B49-853A-9A686D80EE64"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement CRUD api Project Legendary",
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
                    Id = new Guid("76EF5E8D-E450-4301-8DCE-66BD886450AE"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD issue Legendary",
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
                    Id = new Guid("9E8FB587-B5EA-4753-BE30-323CFC014410"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD User Legendary",
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
                    Id = new Guid("6F5D1D85-EEA1-476A-BE2F-FE4D0CC0B16C"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD Stage Legendary",
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
                new Issue
                {
                    Id = new Guid("B380AA43-B71C-4003-9BE4-4FB9A5BDEC09"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Implement api CRUD User Legendary",
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
                    Id = new Guid("10DC2513-2412-46F2-A1D7-D14C757620A1"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api User to render interface Legendary",
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
                    Id = new Guid("83630C28-5593-4A93-8F96-8F0FEDE5DE88"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Project to render interface Legendary",
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
                    Id = new Guid("9AC0DA88-581B-4C4A-A239-B64684F5B6CC"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Project to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("AD86D901-2E96-4E55-9554-BB0110ABEA52"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Issue to render interface Legendary",
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
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("D5C18000-A02A-4CF9-906C-24E7723B17E1"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design a default page",
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
                    Id = new Guid("1B3FA93C-82FD-4821-821D-A438F34E15D6"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Research techniques",
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
                    Id = new Guid("2732AD49-DC9D-48DE-A4FD-75E2093EC511"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Create a user guide page",
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
                    Id = new Guid("8C23E45D-E46A-4146-BE8D-444CEBABB49C"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Make loading animation",
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
                    Id = new Guid("E9FE91B3-F2FF-4224-83D8-ED0979B46B7C"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Set default date for a new task",
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
                    Id = new Guid("762D6FE2-0FC7-4602-AAA0-44B924FC8A6A"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate point for user",
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
                    Id = new Guid("9238A9D8-2E96-4D19-97EB-C5492494A8A9"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate statistical data",
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
                    Id = new Guid("F4999AA9-1172-4C11-A968-9A490066A487"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Apply redux to project",
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
                    Id = new Guid("BB6D2BC9-BD37-434C-9CAA-56244CB86679"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design using Figma",
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
                }
                ////////////////////////////////////////////////////////////////
                ,
                new Issue
                {
                    Id = new Guid("850586DC-E767-497C-BF47-AF466FAD6254"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Archive to render interface Legendary",
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
                    Id = new Guid("63732E12-3FDB-4E4E-992B-A499A9A5FF3F"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Comment to render interface Legendary",
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
                    Id = new Guid("0BEE7B62-8AC1-4DA2-A2AB-44EDE43BDCAA"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Member to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("840FFAB4-60D2-454F-B393-70D446F683B0"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Question to render interface Legendary",
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
                    Id = new Guid("0D362602-E605-4C6A-B121-DAD707074AA6"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Answer to render interface Legendary",
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
                    Id = new Guid("BE085A5B-FFF5-4E44-87F6-D4B523592DC4"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Stage to render interface Legendary",
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
                    Id = new Guid("8BBD5A2E-1211-4CE0-A184-C0AC3BCB554F"),
                    Id_Project = new Guid("0A77A086-8CEC-477E-BB86-076AE2D3C877"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Test all functions of FE",
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
                },
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("CD7DFC34-F34D-4660-B4E7-408E310AC76D"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design a default page",
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
                    Id = new Guid("B727B330-343A-417A-A6CF-E9E76316BF8C"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Research techniques",
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
                    Id = new Guid("1A203683-ADB7-42C5-A4B4-49DD65DF3B18"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Create a user guide page",
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
                    Id = new Guid("29D4F4DC-EDC8-43E4-AE31-53A8159CFABC"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Make loading animation",
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
                    Id = new Guid("4FB7DB21-01F7-467C-A06F-82F3960ACE30"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Set default date for a new task",
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
                    Id = new Guid("5A832501-D4C8-41D2-A7A1-B63951356429"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate point for user",
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
                    Id = new Guid("1BE9A532-AE40-483C-9F02-A7D2265D96AE"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate statistical data",
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
                    Id = new Guid("8A980545-1C25-4F33-8AF1-F6E0A3951F7B"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Apply redux to project",
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
                    Id = new Guid("C278497D-2360-45FE-B5F4-F6C4A1BBAB02"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design using Figma",
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
                }
                ////////////////////////////////////////////////////////////////
                ,
                new Issue
                {
                    Id = new Guid("EC1ACC6A-71E6-4103-A593-F5C8216519AA"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Archive to render interface Legendary",
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
                    Id = new Guid("F58B8EDE-5808-4493-B3BD-48E7CBF3F9AE"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Comment to render interface Legendary",
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
                    Id = new Guid("1411FA78-CF25-4B0E-8286-7C1DE5D0E17C"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Member to render interface Legendary",
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
                }
                // ===================================================================================================================OK
                ,
                new Issue
                {
                    Id = new Guid("22BBA4F2-311C-4E17-95D7-4D3D62E4565C"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Question to render interface Legendary",
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
                    Id = new Guid("1A36CCCF-5459-4EEC-92FD-46F1B98417D6"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Answer to render interface Legendary",
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
                    Id = new Guid("A148DFF5-FC45-4CF9-81BC-2FB66B26AD11"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Stage to render interface Legendary",
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
                    Id = new Guid("C9D54177-CD6E-4BCD-829C-826474DBEC24"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Test all functions of FE",
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
                },
                ///////////////////////////////////////////////////////////////

                new Issue
                {
                    Id = new Guid("F6A13A68-7068-4664-8CD6-91C6352D8E52"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"), // Marvic Academy
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary A",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Id = new Guid("8019C9D3-DE78-4295-A37B-76F5CAF23409"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary B",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
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
                    Id = new Guid("C327FD41-A2F6-4F7F-B6BE-E917EFB883F5"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Design Front-end Legendary",
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
                    Id = new Guid("EC902934-25C3-4E72-B9BA-2D0E3A821A5E"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Design database for Back-end Legendary",
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
                new Issue
                {
                    Id = new Guid("A91E45DB-189C-4CC7-BFA2-E2EBA70EFBD2"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Draft design database Legendary",
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
                    Id = new Guid("48D21F75-D742-40DF-9799-27CF5CB65F6D"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Select database technology Legendary",
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
                    Id = new Guid("DBFD93ED-866E-403A-86F5-D8EA6440C5BE"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Using Entity Framework to connect database SQL Legendary",
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
                    Id = new Guid("DF356296-84AB-4C78-BE79-6820E17F6516"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api login Legendary",
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
                new Issue
                {
                    Id = new Guid("D4062BA6-7768-45EF-940D-E0C5E2F236F2"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement CRUD api Project Legendary",
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
                    Id = new Guid("F1B0FA46-F04E-4AC3-BE43-19F0782D989E"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD issue Legendary",
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
                    Id = new Guid("3288D486-A68E-4DD7-AED3-C9EB86102806"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xx
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD User Legendary",
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
                    Id = new Guid("97B5040A-4E52-4C12-8A2D-C4AC0747D4C8"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "Implement api CRUD Stage Legendary",
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
                new Issue
                {
                    Id = new Guid("8C4D45D6-9817-465E-96E7-E21D30A69595"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Implement api CRUD User Legendary",
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
                    Id = new Guid("C90FEB47-9EE6-4B05-B19C-C1900DAB5A9C"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api User to render interface Legendary",
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
                    Id = new Guid("418361F4-D057-4C34-A9C4-D109E9DCED32"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage xxx
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Project to render interface Legendary",
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
                    Id = new Guid("A265E13E-6567-43CC-97A1-484204415492"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("da3d7685-bb11-4681-b7f3-ffbc9ed54353"), // Stage Inprogress
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Project to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("6D49889A-685D-4D8A-BE9C-F82135C913ED"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Issue to render interface Legendary",
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
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("8F71511A-2208-41CC-A187-3C44D19CC8C0"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design a default page",
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
                    Id = new Guid("B1A2E2CC-A7C5-4A03-8100-5012BAB3574D"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Research techniques",
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
                    Id = new Guid("9D5CA283-6980-4AAA-B58C-1BDE4ABDF83E"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Create a user guide page",
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
                    Id = new Guid("EFC04AE7-45A8-4CDC-B802-E057753E5A12"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Make loading animation",
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
                    Id = new Guid("A9AF35AC-5982-4D58-903C-E478204D500B"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Set default date for a new task",
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
                    Id = new Guid("15EF22E6-0BDC-4088-95AF-F3BAD3697FFD"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate point for user",
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
                    Id = new Guid("E7F408A0-39C2-4095-877F-BC0256EECDEB"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate statistical data",
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
                    Id = new Guid("993A3735-CB0C-4531-877B-5B33454FC4AE"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Apply redux to project",
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
                    Id = new Guid("426906BB-6AD4-4D1A-9FC8-2C3E444D341A"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design using Figma",
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
                }
                ////////////////////////////////////////////////////////////////
                ,
                new Issue
                {
                    Id = new Guid("1EA236B0-AECB-4C43-98BA-C7885797A6AD"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Archive to render interface Legendary",
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
                    Id = new Guid("C5B0B2C3-4BDE-48FD-9E21-1964910E6C07"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Comment to render interface Legendary",
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
                    Id = new Guid("E2C3207E-697E-49A0-88FA-AC6283CCE190"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Member to render interface Legendary",
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
                new Issue
                {
                    Id = new Guid("B8119ECC-7443-480A-A56E-827A699378D5"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Question to render interface Legendary",
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
                    Id = new Guid("23501683-A4F9-4B76-8827-8D1C715D9EC5"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Answer to render interface Legendary",
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
                    Id = new Guid("7916560E-05EC-4AA1-BBB0-52962F2E0622"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Stage to render interface Legendary",
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
                }
                //==================================================================================OK
                ,
                new Issue
                {
                    Id = new Guid("AB4D6822-F62B-4094-ACAD-B304D561452A"),
                    Id_Project = new Guid("A9BB6DE5-9093-44CA-B406-927ADDC2790F"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Test all functions of FE",
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
                },
                ////////////////////////////////////////////////////////////////
                new Issue
                {
                    Id = new Guid("B9838997-5AA4-41DC-9298-B3E6DA29B379"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Design a default page",
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
                    Id = new Guid("F7AF5939-08C0-4DE5-9D0C-AEA6BB3D8982"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Research techniques",
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
                    Id = new Guid("2922FAF2-C30D-4D45-8F19-8B40FC6B671A"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Create a user guide page",
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
                    Id = new Guid("6413E4A4-CCFA-41F0-959F-3B10BDDCDA7E"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Make loading animation",
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
                    Id = new Guid("41B5F64E-980D-458B-8728-FF864ED44384"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Set default date for a new task",
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
                    Id = new Guid("B8721265-77E5-4EFA-92E5-3A45492CFA6B"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate point for user",
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
                    Id = new Guid("85B0EE30-7CC5-4F0F-A74B-ACC3F785B359"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Calculate statistical data",
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
                    Id = new Guid("2606E770-5331-4661-A43C-DC9BC38F4F4D"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Apply redux to project",
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
                    Id = new Guid("80B5E25A-FB46-40CB-9098-60C583E9AFD9"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Draft design using Figma",
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
                }
                ////////////////////////////////////////////////////////////////
                ,
                new Issue
                {
                    Id = new Guid("6598B051-721F-4B26-8DBE-01EA220111FE"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint xxx
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Archive to render interface Legendary",
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
                    Id = new Guid("AC63BB83-28A3-4607-9078-6C66918E1D1D"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Comment to render interface Legendary",
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
                    Id = new Guid("9F7C5748-41EE-484E-AD29-1DF7B005AB5D"),
                    Id_Project = new Guid("DC48AF74-2747-4FB5-936C-DDCDACBDC738"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"), // Stage Done
                    Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"), // Sprint A2
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "Using api Member to render interface Legendary",
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
                }
                );
        }
    }
}