using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.WorkedOn
{
    public class GroupWorkedOn_ViewModel
    {
        public string Title { get; set; }
        public List<WorkedOn_ViewModel> Items { get; set; }
        public GroupWorkedOn_ViewModel()
        {
            Items = new List<WorkedOn_ViewModel>();
            Title = string.Empty;
        }
    }
}
