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
                new Issue // -1
                {
                    Id = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "Epic Legendary A",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Ten,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = Guid.Empty,
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 4, 1),
                    DateEnd = new DateTime(2022, 6, 15),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue // -2
                {
                    Id = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story Legendary A1",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Seven,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 7, 12),
                    DateEnd = new DateTime(2022, 8, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 1,
                    IsDeleted = EnumStatus.False
                },
                new Issue // -3
                {
                    Id = new Guid("E77D319E-0E2C-4278-98B1-F359576A5CE8"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story Legendary A2",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Seven,
                    Id_Reporter = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // NhanNT
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 7, 12),
                    DateEnd = new DateTime(2022, 8, 12),
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
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.1",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("DF2E4C8C-36D7-4448-96FC-5FE36363E1D6"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.1",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("8A30F816-24BD-4FD3-89B3-A0AA3D79D7FF"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.1",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), // NhanTT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("0997489F-597E-43F9-AECB-4F55ADBA143E"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.1",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
            #endregion
            #region Group Task Who Reporter is NhanTT
                new Issue
                {
                    Id = new Guid("70E335FC-759D-45E8-826E-8A42B5802633"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.2",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
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
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.2",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("6D6BB4BB-523A-4F79-85A9-6D0A5E85C658"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.2",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("4B9A6895-4467-453E-8915-5ED19312FB54"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("1A578D31-1AA0-45E7-BC1A-F6683C5853A5"), // Label BE
                    Summary = "The Task Legendary A1.2",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A1
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
            #endregion
            #region Group Task Who Reporter is TungNV
                new Issue
                {
                    Id = new Guid("B11F2822-BC9A-4C50-9642-2E18B63F298D"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.3",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Id_Assignee = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.High,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("0B931EE5-6FAB-4EDD-9725-3F744D837324"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.3",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.High,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("1645F209-E53F-4D09-840E-2D290D527A01"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.3",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.High,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("17EA08D6-9C12-4ED9-B83A-3CCDDD7C5911"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.3",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // TungNV
                    Id_Assignee = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.High,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
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
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.4",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Id_Assignee = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
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
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.4",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Id_Assignee = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("58112BCE-A689-43A5-B04D-0AD61FF6D071"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.4",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("C9047FBC-6472-4802-A01D-3D64E098BC0D"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A1
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.4",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // User TungNV
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
            #endregion
            #region Group Task Who Reporter is ThangVD
                new Issue
                {
                    Id = new Guid("D7B1F77B-67CC-44EF-96D5-3A38C2085F85"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = Guid.Empty,
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.5",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("9123B434-F70A-4EE6-B0BB-38BDBCB61798"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = Guid.Empty,
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.5",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("90C14ABD-1AC5-4515-8889-24B5950E3E4E"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = Guid.Empty,
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.5",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // User TungNV
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("F411818D-3735-4A1A-883B-5353FB160B8F"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = Guid.Empty,
                    Id_Label = new Guid("F8B58FDB-15BB-4336-B9D4-7D2CF9D4BC07"), // Label FE
                    Summary = "The Task Legendary A1.5",
                    Description = "In publishing and graphic design, Lorem ipsum is a placeholder text commonly used to demonstrate the visual form of a document or a typeface without relying on meaningful content. Lorem ipsum may be used as a placeholder before final copy is available.",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story Legendary A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // Epic Legendary A
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    UpdateDate = new DateTime(),
                    Order = 0,
                    IsDeleted = EnumStatus.False
                },
            #endregion
                // = Note: 2x "order : 0"
            #region Other Task
                // ===Project B===
                new Issue
                {
                    Id = new Guid("BBBE8F8E-A735-4A4C-BDED-E4CE2405E8E1"),
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"),
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("AED1AB4D-D742-47D8-8400-E86B13C009E2"), // Sprint B
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The epic of Project B",
                    Description = "Des epic of Project B",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), //KhanhND
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty, // The Story of Project B
                    Priority = EnumPriority.Low,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 6, 12),
                    DateEnd = new DateTime(2022, 11, 12),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 1,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("BFFC9087-DE0D-4BF8-97A1-F97A26D6FDA4"),
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("AED1AB4D-D742-47D8-8400-E86B13C009E2"), // Sprint B
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story of Project B",
                    Description = "Des Story of Project B",
                    Story_Point_Estimate = EnumPoint.One,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), //KhanhND
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = new Guid("BBBE8F8E-A735-4A4C-BDED-E4CE2405E8E1"), // The Story of Project B
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 2,
                    IsDeleted = EnumStatus.False
                },
                // =======Project D=======
                new Issue
                {
                    Id = new Guid("76B20622-AD82-4D0D-9719-7B0CF5F33B58"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("87038CA8-11A7-4392-9C3E-86FD04F75223"), // Sprint First PD
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story of Project D",
                    Description = "Des Story of Project D",
                    Story_Point_Estimate = EnumPoint.One,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = Guid.Empty,
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 3,
                    IsDeleted = EnumStatus.False
                }, // = Note: "order : 1,2,3"

                // Task Project D
                // 1-2 
                new Issue
                {
                    Id = new Guid("461F25E5-E68C-4947-842B-F924C4786624"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("87038CA8-11A7-4392-9C3E-86FD04F75223"), // Sprint First PD
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task of Project D 1",
                    Description = "Des Task of Project D 1",
                    Story_Point_Estimate = EnumPoint.One,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = new Guid("76B20622-AD82-4D0D-9719-7B0CF5F33B58"),
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 2,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("FD1ED50A-53FB-43E5-9536-5E6AE641636C"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("87038CA8-11A7-4392-9C3E-86FD04F75223"), // Sprint First PD
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task of Project D 2",
                    Description = "Des Task of Project D 2",
                    Story_Point_Estimate = EnumPoint.One,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = new Guid("76B20622-AD82-4D0D-9719-7B0CF5F33B58"),
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 1,
                    IsDeleted = EnumStatus.False
                }
                // 3 - 4
                ,
                new Issue
                {
                    Id = new Guid("128495FB-FF10-4D63-BAF0-AFE3E9B9BD6B"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("87038CA8-11A7-4392-9C3E-86FD04F75223"), // Sprint First PD
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task of Project D 3",
                    Description = "Des Task of Project D 3",
                    Story_Point_Estimate = EnumPoint.Nine,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = new Guid("76B20622-AD82-4D0D-9719-7B0CF5F33B58"),
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 1,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("82E2D2A6-B8E4-417A-8883-A8C7790EC45F"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("87038CA8-11A7-4392-9C3E-86FD04F75223"), // Sprint First PD
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task of Project D 4",
                    Description = "Des Task of Project D 4",
                    Story_Point_Estimate = EnumPoint.Seven,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = new Guid("76B20622-AD82-4D0D-9719-7B0CF5F33B58"),
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.True,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 3,
                    IsDeleted = EnumStatus.False
                }, // = Note: 2x "order : 1", 2x "order : 2"

                // =====Project Editor Super======
                new Issue
                {
                    Id = new Guid("F56CDF9A-2E07-4DE1-8D5F-A3D8C19E7628"),
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"),
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("79F4FE9F-028F-4C2D-AFA8-28601272B031"), // Sprint Project Editor Super
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Epic of Project Editor Super",
                    Description = "Des Epic of Project Editor Super",
                    Story_Point_Estimate = EnumPoint.Seven,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // User ThangVD
                    Id_Assignee = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // User NhanNT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // User ThangVD
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 3,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("73454F75-A16B-464E-99DC-4891086CB81F"),
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"),
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("79F4FE9F-028F-4C2D-AFA8-28601272B031"), // Sprint Project Editor Super
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story of Project Editor Super",
                    Description = "Des Story of Project Editor Super",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // ThinhLQ
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 4,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("92BAF164-333F-49C7-B5DF-6C91BD9F405E"),
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("79F4FE9F-028F-4C2D-AFA8-28601272B031"), // Sprint Project Editor Super
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task of Project Editor Super 1",
                    Description = "Des Task of Project Editor Super 1",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // User ThinhLQ
                    Id_Assignee = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // User NhanNT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // User ThinhLQ
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 2,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("BBBD307D-CBDC-41D0-BE8A-7E7BC0A0D1F9"),
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("79F4FE9F-028F-4C2D-AFA8-28601272B031"), // Sprint Project Editor Super
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task of Project Editor Super 2",
                    Description = "Des Task of Project Editor Super 2",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // User TungNV
                    Id_Assignee = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"), // User NhanNT
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // User ThinhLQ
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 1,
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("5B9382F3-CCCD-412B-A6E3-B26BEC2A97AB"),
                    Id_Project = new Guid("1A24B90F-2585-404B-9E93-7128D96F8A93"),
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("79F4FE9F-028F-4C2D-AFA8-28601272B031"), // Sprint Project Editor Super
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task of Project Editor Super 3",
                    Description = "Des Task of Project Editor Super 3",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // User ThinhLQ
                    Id_Assignee = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"), // User TungNV
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Medium,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // User ThinhLQ
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    Order = 5,
                    IsDeleted = EnumStatus.False
                }// "order : 4215" missing "3"
                );
            #endregion
        }
    }
}
