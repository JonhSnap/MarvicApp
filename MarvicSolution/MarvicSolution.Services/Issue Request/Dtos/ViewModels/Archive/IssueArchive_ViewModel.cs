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
        public string Title { get; set; }
        public List<Issue_ViewModel> Items { get; set; }
        public IssueArchive_ViewModel()
        {
            Title = string.Empty;
            Items = new List<Issue_ViewModel>();
        }
    }
}
