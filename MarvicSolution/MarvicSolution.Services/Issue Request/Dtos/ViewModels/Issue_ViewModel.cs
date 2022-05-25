using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels
{
    public class Issue_ViewModel
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
        public string? FileName { get; set; }
        public string? Attachment_Path { get; set; }
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
        public IList<App_User> Users { get; set; }

        public Issue_ViewModel()
        {
            Id = Guid.Empty;
            Id_Project = Guid.Empty;
            Id_IssueType = EnumIssueType.Task;
            Id_Stage = Guid.Empty;
            Id_Sprint = Guid.Empty;
            Id_Label = Guid.Empty;
            Summary = string.Empty;
            Description = string.Empty;
            Id_Assignee = Guid.Empty;
            Story_Point_Estimate = EnumPoint.One;
            Id_Reporter = Guid.Empty;
            FileName = string.Empty;
            Id_Linked_Issue = Guid.Empty;
            Id_Parent_Issue = Guid.Empty;
            Priority = EnumPriority.Lowest;
            Id_Restrict = Guid.Empty;
            IsFlagged = EnumStatus.False;
            IsWatched = EnumStatus.False;
            Id_Creator = Guid.Empty;
            DateCreated = new DateTime();
            DateStarted = new DateTime();
            DateEnd = new DateTime();
            Id_Updator = Guid.Empty;
            UpdateDate = new DateTime();
            Order = 0;
        }
    }
}
