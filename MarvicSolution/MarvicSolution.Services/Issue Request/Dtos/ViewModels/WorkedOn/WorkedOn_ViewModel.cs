using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.WorkedOn
{
    public class WorkedOn_ViewModel : Issue_ViewModel
    {
        // base prop
        public string ProjectName { get; set; }
        public List<User_ViewModel> Users { get; set; }
        public string Status { get; set; }
        public WorkedOn_ViewModel() : base()
        {
            Users = new List<User_ViewModel>();
            ProjectName = string.Empty;
            Status = "Created";
        }
    }
}
