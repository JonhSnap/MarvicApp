using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.AssignedToMe
{
    public class GroupAssignedTM_ViewModel
    {
        public string Title { get; set; }
        public List<AssignedToMe_ViewModel> Items { get; set; }
        public GroupAssignedTM_ViewModel()
        {
            Title = string.Empty;
            Items = new List<AssignedToMe_ViewModel>();
        }
    }
}
