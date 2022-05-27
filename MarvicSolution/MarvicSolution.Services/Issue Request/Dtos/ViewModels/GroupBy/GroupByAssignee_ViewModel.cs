using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.GroupBy
{
    public class GroupByAssignee_ViewModel
    {
        public string AssigneeName { get; set; }
        public List<Issue_ViewModel> ListIssue { get; set; }

        public GroupByAssignee_ViewModel()
        {
            this.AssigneeName = string.Empty;
            this.ListIssue = new List<Issue_ViewModel>();
        }
    }
}
