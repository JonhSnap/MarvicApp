using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Archive
{
    public class IssueArchive_ViewModel
    {
        public Guid SprintId { get; set; }
        public string SprintName { get; set; }
        public string EndDate { get; set; }
        public List<Issue_ViewModel> Issues { get; set; }
    }
}
