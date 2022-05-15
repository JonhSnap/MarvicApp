using MarvicSolution.DATA.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Issue_Request.Dtos
{
    public class Issue_UpdateRequest
    {
        public Guid Id { get; set; }
        public Guid Id_Project { get; set; }
        public EnumIssueType Id_IssueType { get; set; }
        public Guid? Id_Stage { get; set; }
        public Guid? Id_Sprint { get; set; }
        public Guid? Id_Label { get; set; }
        public string Summary { get; set; }
        public string? Description { get; set; }
        public Guid? Id_Assignee { get; set; }
        public EnumPoint? Story_Point_Estimate { get; set; }
        public Guid? Id_Reporter { get; set; }
        public string FileName { get; set; }
        public Guid? Id_Linked_Issue { get; set; }
        public Guid? Id_Parent_Issue { get; set; }
        public EnumPriority? Priority { get; set; }
        public Guid? Id_Restrict { get; set; }
        public EnumStatus? IsFlagged { get; set; }
        public EnumStatus? IsWatched { get; set; }
        public Guid Id_Creator { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }
        public Guid? Id_Updator { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Order { get; set; }
        public EnumStatus IsDeleted { get; set; }

        public Issue_UpdateRequest()
        {
            Id = new Guid();
            Id_Project = new Guid();
            Id_IssueType =  EnumIssueType.Task;
            Id_Stage = new Guid();
            Id_Sprint = new Guid();
            Id_Label = new Guid();
            Summary = string.Empty;
            Description = string.Empty;
            Id_Assignee = new Guid();
            Story_Point_Estimate =  EnumPoint.One;
            Id_Reporter = new Guid();
            FileName = null;
            Id_Linked_Issue = new Guid();
            Id_Parent_Issue = new Guid();
            Priority =  EnumPriority.Lowest;
            Id_Restrict = new Guid();
            IsFlagged =  EnumStatus.False;
            IsWatched =  EnumStatus.False;
            Id_Creator = new Guid();
            DateCreated = new DateTime();
            DateStarted = new DateTime();
            DateEnd = new DateTime();
            Id_Updator = new Guid();
            UpdateDate = new DateTime();
            Order = 0;
            IsDeleted =  EnumStatus.False;
        }
        public Issue_UpdateRequest(Guid id, Guid id_Project, EnumIssueType id_IssueType, Guid? id_Stage, Guid? id_Sprint, Guid? id_Label, string summary, string description, Guid? id_Assignee, EnumPoint? story_Point_Estimate, Guid? id_Reporter, string fileName, Guid? id_Linked_Issue, Guid? id_Parent_Issue, EnumPriority? priority, Guid? id_Restrict, EnumStatus? isFlagged, EnumStatus? isWatched, Guid id_Creator, DateTime? dateCreated, DateTime? dateStarted, DateTime? dateEnd, Guid? id_Updator, DateTime? updateDate, int order, EnumStatus isDeleted)
        {
            Id = id;
            Id_Project = id_Project;
            Id_IssueType = id_IssueType;
            Id_Stage = id_Stage;
            Id_Sprint = id_Sprint;
            Id_Label = id_Label;
            Summary = summary ?? throw new ArgumentNullException(nameof(summary));
            Description = description;
            Id_Assignee = id_Assignee;
            Story_Point_Estimate = story_Point_Estimate;
            Id_Reporter = id_Reporter;
            FileName = fileName;
            Id_Linked_Issue = id_Linked_Issue;
            Id_Parent_Issue = id_Parent_Issue;
            Priority = priority;
            Id_Restrict = id_Restrict;
            IsFlagged = isFlagged;
            IsWatched = isWatched;
            Id_Creator = id_Creator;
            DateCreated = dateCreated;
            DateStarted = dateStarted;
            DateEnd = dateEnd;
            Id_Updator = id_Updator;
            UpdateDate = updateDate;
            Order = order;
            IsDeleted = isDeleted;
        }
    }
}
