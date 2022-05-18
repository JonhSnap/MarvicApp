using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels
{
    public class GroupByEpic_ViewModel
    {
        public string EpicName { get; set; }
        public List<Issue_ViewModel> ListIssue { get; set; }

        public GroupByEpic_ViewModel()
        {
            this.EpicName = string.Empty;
            this.ListIssue = new List<Issue_ViewModel>();
        }
    }
}
