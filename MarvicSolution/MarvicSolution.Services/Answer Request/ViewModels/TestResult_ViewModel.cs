using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Answer_Request.ViewModels
{
    public class TestResult_ViewModel
    {
        public string TestName { get; set; }
        public List<Result> Items { get; set; }

        public TestResult_ViewModel()
        {
            TestName = string.Empty;
            Items = new List<Result>();
        }
    }
}
