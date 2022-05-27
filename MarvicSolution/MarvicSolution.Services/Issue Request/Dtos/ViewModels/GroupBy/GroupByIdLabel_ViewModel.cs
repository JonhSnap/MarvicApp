using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.GroupBy
{
    public class GroupByIdLabel_ViewModel
    {
        public Guid? Id_Label { get; set; }
        public List<Issue_ViewModel> ListIssue { get; set; }

        public GroupByIdLabel_ViewModel()
        {
            this.Id_Label = Guid.Empty;
            this.ListIssue = new List<Issue_ViewModel>();
        }
    }
}
