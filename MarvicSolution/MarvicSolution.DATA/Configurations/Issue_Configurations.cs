using MarvicSolution.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Id_IssueType = Enums.EnumIssueType.Epic,
                    Id_Stage = new Guid(),
                    Id_Sprint = new Guid(),
                    Id_Label = new Guid(),
                    Summary = "The epic of Project A",
                    Description = "Des epic Project A",
                    Story_Point_Estimate = Enums.EnumPoint.Eight,
                    Id_Reporter = new Guid(),
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid(),
                    Id_Parent_Issue = new Guid(),
                    Priority = Enums.EnumPriority.Highest,
                    Id_Restrict = new Guid(),
                    IsFlagged = Enums.EnumStatus.False,
                    IsWatched = Enums.EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 6, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = Enums.EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("7C2CC804-4AAE-4AF2-9191-4268FC02EDC0"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project A
                    Id_IssueType = Enums.EnumIssueType.Story,
                    Id_Stage = new Guid(),
                    Id_Sprint = new Guid(),
                    Id_Label = new Guid(),
                    Summary = "The Story of Project A",
                    Description = "Des Story of Project A",
                    Story_Point_Estimate = Enums.EnumPoint.Nine,
                    Id_Reporter = new Guid(),
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid(),
                    Id_Parent_Issue = new Guid(),
                    Priority = Enums.EnumPriority.Medium,
                    Id_Restrict = new Guid(),
                    IsFlagged = Enums.EnumStatus.False,
                    IsWatched = Enums.EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 7, 12),
                    DateEnd = new DateTime(2022, 8, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = Enums.EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("EDFF3F58-7640-4F5A-ADA0-DC017F602501"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project A
                    Id_IssueType = Enums.EnumIssueType.Task,
                    Id_Stage = new Guid(),
                    Id_Sprint = new Guid(),
                    Id_Label = new Guid(),
                    Summary = "The Task1 of Project A",
                    Description = "Des Task1 of Project A",
                    Story_Point_Estimate = Enums.EnumPoint.Five,
                    Id_Reporter = new Guid(),
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid(),
                    Id_Parent_Issue = new Guid(),
                    Priority = Enums.EnumPriority.Medium,
                    Id_Restrict = new Guid(),
                    IsFlagged = Enums.EnumStatus.False,
                    IsWatched = Enums.EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 2, 12),
                    DateStarted = new DateTime(2022, 4, 12),
                    DateEnd = new DateTime(2022, 5, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = Enums.EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("24C577BB-002D-4A31-A855-CA22F0C7CA69"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project A
                    Id_IssueType = Enums.EnumIssueType.Task,
                    Id_Stage = new Guid(),
                    Id_Sprint = new Guid(),
                    Id_Label = new Guid(),
                    Summary = "The Task2 of Project A",
                    Description = "Des Task2 of Project A",
                    Story_Point_Estimate = Enums.EnumPoint.Two,
                    Id_Reporter = new Guid(),
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid(),
                    Id_Parent_Issue = new Guid(),
                    Priority = Enums.EnumPriority.High,
                    Id_Restrict = new Guid(),
                    IsFlagged = Enums.EnumStatus.False,
                    IsWatched = Enums.EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 1, 12),
                    DateStarted = new DateTime(2022, 2, 12),
                    DateEnd = new DateTime(2022, 9, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = Enums.EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("BBBE8F8E-A735-4A4C-BDED-E4CE2405E8E1"),
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"), // Project B
                    Id_IssueType = Enums.EnumIssueType.Epic,
                    Id_Stage = new Guid(),
                    Id_Sprint = new Guid(),
                    Id_Label = new Guid(),
                    Summary = "The epic of Project B",
                    Description = "Des epic of Project B",
                    Story_Point_Estimate = Enums.EnumPoint.Six,
                    Id_Reporter = new Guid(),
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid(),
                    Id_Parent_Issue = new Guid(),
                    Priority = Enums.EnumPriority.Low,
                    Id_Restrict = new Guid(),
                    IsFlagged = Enums.EnumStatus.False,
                    IsWatched = Enums.EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 3, 12),
                    DateStarted = new DateTime(2022, 6, 12),
                    DateEnd = new DateTime(2022, 11, 12),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = Enums.EnumStatus.False
                },
                new Issue
                {
                    Id = new Guid("BFFC9087-DE0D-4BF8-97A1-F97A26D6FDA4"),
                    Id_Project = new Guid("89FAD9A0-690D-46E8-A2FE-C6CC50350EAF"), // Project B
                    Id_IssueType = Enums.EnumIssueType.Story,
                    Id_Stage = new Guid(),
                    Id_Sprint = new Guid(),
                    Id_Label = new Guid(),
                    Summary = "The Story of Project B",
                    Description = "Des Story of Project B",
                    Story_Point_Estimate = Enums.EnumPoint.One,
                    Id_Reporter = new Guid(),
                    Attachment_Path = string.Empty,
                    Id_Linked_Issue = new Guid(),
                    Id_Parent_Issue = new Guid(),
                    Priority = Enums.EnumPriority.Highest,
                    Id_Restrict = new Guid(),
                    IsFlagged = Enums.EnumStatus.False,
                    IsWatched = Enums.EnumStatus.False,
                    Id_Creator = new Guid(),
                    DateCreated = new DateTime(2022, 9, 12),
                    DateStarted = new DateTime(2022, 10, 12),
                    DateEnd = new DateTime(2022, 12, 1),
                    Id_Updator = new Guid(),
                    UpdateDate = new DateTime(),
                    IsDeleted = Enums.EnumStatus.False
                }
                );
        }
    }
}
