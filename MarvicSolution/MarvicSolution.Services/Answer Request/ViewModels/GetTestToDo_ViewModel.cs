using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Answer_Request.ViewModels
{
    public class GetTestToDo_ViewModel
    {
        public List<Question_ViewModel> ListQuestion { get; set; }
        public GetTestToDo_ViewModel()
        {
            ListQuestion = new List<Question_ViewModel>();
        }
    }
}
