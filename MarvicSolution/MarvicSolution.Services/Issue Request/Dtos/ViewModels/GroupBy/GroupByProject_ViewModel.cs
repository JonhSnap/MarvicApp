using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.GroupBy
{
    public class GroupByProject_ViewModel
    {
        public string ProjectName { get; set; }
        public List<Issue_ViewModel> ListIssue { get; set; }

        public GroupByProject_ViewModel()
        {
            this.ProjectName = string.Empty;
            this.ListIssue = new List<Issue_ViewModel>();
        }
    }
}
