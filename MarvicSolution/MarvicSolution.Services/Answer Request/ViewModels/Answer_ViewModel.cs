using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Answer_Request.ViewModels
{
    public class Answer_ViewModel
    {
        public Guid Id { get; set; }
        public string strAnswer { get; set; }

        public Answer_ViewModel()
        {
            Id = Guid.Empty;
            strAnswer = string.Empty;
        }
    }
}
