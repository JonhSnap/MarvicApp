using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Answer_Request.ViewModels
{
    public class Result
    {
        public double Score { get; set; }
        public string CreateDate { get; set; }
        public Result()
        {
            Score = 0;
            CreateDate = string.Empty;
        }
    }
}
