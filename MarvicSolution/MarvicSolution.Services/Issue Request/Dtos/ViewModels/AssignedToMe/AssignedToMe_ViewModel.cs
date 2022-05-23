using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.AssignedToMe
{
    public class AssignedToMe_ViewModel : Issue_ViewModel
    {
        // base prop
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public AssignedToMe_ViewModel()
        {
            ProjectName = string.Empty;
            Status = string.Empty;
        }
    }
}
