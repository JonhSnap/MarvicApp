using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels
{
    public class IssueStatistic_ViewModel
    {
        public string Label { get; set; }
        public int y { get; set; }
        public IssueStatistic_ViewModel()
        {
            Label = string.Empty;
            y = 0;
        }
    }
}
