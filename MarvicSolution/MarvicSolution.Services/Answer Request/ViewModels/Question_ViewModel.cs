using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Answer_Request.ViewModels
{
    public class Question_ViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnumPoint Scores { get; set; }
        public List<Answer_ViewModel> ListAnswer { get; set; }
        public Question_ViewModel()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Scores = EnumPoint.One;
            ListAnswer = new List<Answer_ViewModel>();
        }
    }
}
