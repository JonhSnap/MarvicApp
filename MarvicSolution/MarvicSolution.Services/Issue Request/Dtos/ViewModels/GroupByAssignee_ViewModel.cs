using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels
{
    public class GroupByAssignee_ViewModel
    {
        public Guid? Id_Assignee { get; set; }
        public List<Issue_ViewModel> ListIssue { get; set; } = new List<Issue_ViewModel>();
    }
}
