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
        public Guid Id { get; set; }
        public Guid Id_Project { get; set; }
        public EnumIssueType Id_IssueType { get; set; } = EnumIssueType.Epic;
        public Guid? Id_Stage { get; set; }
        public Guid? Id_Sprint { get; set; }
        public Guid? Id_Label { get; set; }
        [Required(ErrorMessage ="Summary must be filled in")]
        public string Summary { get; set; }
        public string? Description { get; set; }
        public Guid? Id_Assignee { get; set; } = Guid.Empty;
        public EnumPoint? Story_Point_Estimate { get; set; } = EnumPoint.One;
        public Guid? Id_Reporter { get; set; } = Guid.Empty;
        public string? Attachment_Path { get; set; } = string.Empty;
        public Guid? Id_Linked_Issue { get; set; } = Guid.Empty;
        public Guid? Id_Parent_Issue { get; set; } = Guid.Empty;
        public EnumPriority? Priority { get; set; } = EnumPriority.Lowest;
        public Guid? Id_Restrict { get; set; } = Guid.Empty;
        public EnumStatus? IsFlagged { get; set; } = EnumStatus.False;
        public EnumStatus? IsWatched { get; set; } = EnumStatus.False;
        public Guid Id_Creator { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }
        public Guid? Id_Updator { get; set; }
        public DateTime? UpdateDate { get; set; }
        public EnumStatus IsDeleted { get; set; } = EnumStatus.False;
    }
}
