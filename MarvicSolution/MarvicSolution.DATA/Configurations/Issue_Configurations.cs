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
                new Issue
                {
                    Id = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project A
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The epic of Project A",
                    Description = "Des epic Project A",
                    Story_Point_Estimate = EnumPoint.Eight,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), //KhanhND
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.NewGuid(),
                    Id_Parent_Issue = new Guid(),
                    Priority = EnumPriority.Highest,
                    Id_Restrict = new Guid(),
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 6, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project A
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story of Project A",
                    Description = "Des Story of Project A",
                    Story_Point_Estimate = EnumPoint.Nine,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), //KhanhND
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid(),
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), //The epic of Project A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = new Guid(),
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 7, 12),
                    DateEnd = new DateTime(2022, 8, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("EDFF3F58-7640-4F5A-ADA0-DC017F602501"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project A
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task1 of Project A",
                    Description = "Des Task1 of Project A",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), //KhanhND
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), //The Story of Project A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), //The epic of Project A
                    Priority = EnumPriority.Medium,
                    Id_Restrict = new Guid(),
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("24C577BB-002D-4A31-A855-CA22F0C7CA69"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project A
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("D2DA18BC-3F2D-4558-ACC8-480DF6D770F4"), // Sprint A
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task2 of Project A",
                    Description = "Des Task2 of Project A",
                    Story_Point_Estimate = EnumPoint.Two,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), //KhanhND
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"), // The Story of Project A
                    Id_Parent_Issue = new Guid("BB2B349B-1075-45CA-96DE-9F709A678EB0"), // The Story of Project B
                    Priority = EnumPriority.High,
                    Id_Restrict = new Guid(),
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 1, 12),
                    DateStarted = new DateTime(2022, 2, 12),
                    DateEnd = new DateTime(2022, 9, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("BBBE8F8E-A735-4A4C-BDED-E4CE2405E8E1"),
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"), // Project B
                    Id_IssueType = EnumIssueType.Epic,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("87038CA8-11A7-4392-9C3E-86FD04F75223"), // Sprint A
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The epic of Project B",
                    Description = "Des epic of Project B",
                    Story_Point_Estimate = EnumPoint.Six,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), //KhanhND
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid(),
                    Id_Parent_Issue = new Guid("BBBE8F8E-A735-4A4C-BDED-E4CE2405E8E1"), // The Story of Project B
                    Priority = EnumPriority.Low,
                    Id_Restrict = new Guid(),
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 6, 12),
                    DateEnd = new DateTime(2022, 11, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("BFFC9087-DE0D-4BF8-97A1-F97A26D6FDA4"),
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"), // Project B
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("87038CA8-11A7-4392-9C3E-86FD04F75223"), // Sprint A
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story of Project B",
                    Description = "Des Story of Project B",
                    Story_Point_Estimate = EnumPoint.One,
                    Id_Reporter = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"), //NhanTT
                    Id_Assignee = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"), //KhanhND
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid(),
                    Id_Parent_Issue = new Guid("BBBE8F8E-A735-4A4C-BDED-E4CE2405E8E1"), // The Story of Project B
                    Priority = EnumPriority.Highest,
                    Id_Restrict = new Guid(),
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = EnumStatus.False
                },
                // =======Project D=======
                new Issue
                {
                    Id = new Guid("76B20622-AD82-4D0D-9719-7B0CF5F33B58"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project D
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("87038CA8-11A7-4392-9C3E-86FD04F75223"), // Sprint First PD
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story of Project D",
                    Description = "Des Story of Project D",
                    Story_Point_Estimate = EnumPoint.One,
                    Id_Reporter = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // User KhietPT
                    Id_Assignee = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // ThangVD
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = Guid.Empty,
                    Id_Parent_Issue = Guid.Empty,
                    Priority = EnumPriority.Highest,
                    Id_Restrict = Guid.Empty,
                    IsFlagged = EnumStatus.False,
                    IsWatched = EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = Guid.Empty,
                    UpdateDate = new DateTime(),
                    IsDeleted = EnumStatus.False
                },
                // Task Project D
                // 1-2 
                new Issue
                {
                    Id = new Guid("461F25E5-E68C-4947-842B-F924C4786624"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project D
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
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("FD1ED50A-53FB-43E5-9536-5E6AE641636C"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project D
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
                    IsDeleted = EnumStatus.False
                }
                // 3 - 4
                ,
                new Issue
                {
                    Id = new Guid("128495FB-FF10-4D63-BAF0-AFE3E9B9BD6B"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project D
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
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("82E2D2A6-B8E4-417A-8883-A8C7790EC45F"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project D
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
                    IsDeleted = EnumStatus.False
                },
                // =====Project Editor Super======
                new Issue
                {
                    Id = new Guid("F56CDF9A-2E07-4DE1-8D5F-A3D8C19E7628"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project Editor Super
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
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("73454F75-A16B-464E-99DC-4891086CB81F"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project Editor Super
                    Id_IssueType = EnumIssueType.Story,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("79F4FE9F-028F-4C2D-AFA8-28601272B031"), // Sprint Project Editor Super
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Story of Project Editor Super",
                    Description = "Des Story of Project Editor Super",
                    Story_Point_Estimate = EnumPoint.Five,
                    Id_Reporter = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"), // User ThangVD
                    Id_Assignee = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"), // User ThinhLQ
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
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("92BAF164-333F-49C7-B5DF-6C91BD9F405E"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project Editor Super
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
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("BBBD307D-CBDC-41D0-BE8A-7E7BC0A0D1F9"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project Editor Super
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("79F4FE9F-028F-4C2D-AFA8-28601272B031"), // Sprint Project Editor Super
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task of Project Editor Super 2",
                    Description = "Des Task of Project Editor Super 2",
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
                    IsDeleted = EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("5B9382F3-CCCD-412B-A6E3-B26BEC2A97AB"),
                    Id_Project = new Guid("FCAFF326-620B-4B6C-96AB-BDFE7B2DD952"), // Project Editor Super
                    Id_IssueType = EnumIssueType.Task,
                    Id_Stage = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"), // Stage To do
                    Id_Sprint = new Guid("79F4FE9F-028F-4C2D-AFA8-28601272B031"), // Sprint Project Editor Super
                    Id_Label = new Guid("EE7D776C-4C13-4CB9-A4FA-79B2D096A267"), // Label A
                    Summary = "The Task of Project Editor Super 3",
                    Description = "Des Task of Project Editor Super 3",
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
                    IsDeleted = EnumStatus.False
                }
                );
        }
    }
}
