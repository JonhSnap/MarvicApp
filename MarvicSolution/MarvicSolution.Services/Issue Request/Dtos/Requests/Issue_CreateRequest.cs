using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Issue_Request.Dtos
{
    public class Issue_CreateRequest
    {
        public Guid Id_Project { get; set; }
        public EnumIssueType Id_IssueType { get; set; }
        public Guid? Id_Stage { get; set; }
        public Guid? Id_Sprint { get; set; }
        public Guid? Id_Label { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public Guid? Id_Assignee { get; set; }
        public EnumPoint? Story_Point_Estimate { get; set; }
        public Guid? Id_Reporter { get; set; }
        public string Attachment_Path { get; set; }
        public Guid? Id_Linked_Issue { get; set; }
        public Guid? Id_Parent_Issue { get; set; }
        public EnumPriority? Priority { get; set; }
        public Guid? Id_Restrict { get; set; }
        public EnumStatus? IsFlagged { get; set; }
        public EnumStatus? IsWatched { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }
        public EnumStatus IsDeleted { get; set; }

        public Issue_CreateRequest()
        {
            Id_Project = Guid.Empty;
            Id_IssueType =  EnumIssueType.Task;
            Id_Stage = Guid.Empty;
            Id_Sprint = Guid.Empty;
            Id_Label = Guid.Empty;
            Summary = string.Empty;
            Description = string.Empty;
            Id_Assignee = Guid.Empty;
            Story_Point_Estimate =  EnumPoint.One;
            Id_Reporter = Guid.Empty;
            Attachment_Path = string.Empty;
            Id_Linked_Issue = Guid.Empty;
            Id_Parent_Issue = Guid.Empty;
            Priority = EnumPriority.Lowest;
            Id_Restrict = Guid.Empty;
            IsFlagged =  EnumStatus. False;
            IsWatched =  EnumStatus.False;
            DateStarted = new DateTime();
            DateEnd = new DateTime();
            IsDeleted =  EnumStatus.False;
        }

        public Issue_CreateRequest(Guid id_Project, EnumIssueType id_IssueType, Guid? id_Stage, Guid? id_Sprint, Guid? id_Label, string summary, string description, Guid? id_Assignee, EnumPoint? story_Point_Estimate, Guid? id_Reporter, string attachment_Path, Guid? id_Linked_Issue, Guid? id_Parent_Issue, EnumPriority? priority, Guid? id_Restrict, EnumStatus? isFlagged, EnumStatus? isWatched, Guid id_Creator, DateTime? dateCreated, DateTime? dateStarted, DateTime? dateEnd, Guid? id_Updator, DateTime? updateDate, EnumStatus isDeleted)
        {
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
            Attachment_Path = attachment_Path;
            Id_Linked_Issue = id_Linked_Issue;
            Id_Parent_Issue = id_Parent_Issue;
            Priority = priority;
            Id_Restrict = id_Restrict;
            IsFlagged = isFlagged;
            IsWatched = isWatched;
            DateStarted = dateStarted;
            DateEnd = dateEnd;
            IsDeleted = isDeleted;
        }
    }
}
