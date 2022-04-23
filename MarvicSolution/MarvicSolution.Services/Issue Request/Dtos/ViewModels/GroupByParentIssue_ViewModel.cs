using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels
{
     public class GroupByParentIssue_ViewModel
    {
        public Guid? Id_Parent { get; set; }
        public List<Issue_ViewModel> ListIssue { get; set; }

        public GroupByParentIssue_ViewModel()
        {
            this.Id_Parent = Guid.Empty;
            this.ListIssue = new List<Issue_ViewModel>();
        }
    }
}
