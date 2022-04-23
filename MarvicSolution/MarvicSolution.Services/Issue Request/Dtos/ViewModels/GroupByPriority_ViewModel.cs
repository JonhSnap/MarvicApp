using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels
{
    public class GroupByPriority_ViewModel
    {
        public EnumPriority? Priority { get; set; }
        public List<Issue_ViewModel> ListIssue { get; set; }

        public GroupByPriority_ViewModel()
        {
            this.Priority = EnumPriority.Lowest;
            this.ListIssue = new List<Issue_ViewModel>();
        }
    }
}
