using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class Notifications
    {
        public Guid Id { get; set; }
        public Guid IdItemRef { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int IsProject { get; set; }
        public int IsIssue { get; set; }
        public Notifications()
        {
            Id = Guid.Empty;
            IdItemRef = Guid.Empty;
            Message = string.Empty;
            Date = new DateTime();
        }
        public Notifications(Guid idItemRef, string mess, int isProject, int isIssue)
        {
            Id = Guid.NewGuid();
            IdItemRef = idItemRef;
            Message = mess;
            Date = DateTime.Now;
            IsProject = isProject;
            IsIssue = isIssue;
        }
    }
}
