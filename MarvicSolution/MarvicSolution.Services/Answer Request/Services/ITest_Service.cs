using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarvicSolution.Services.Answer_Request.Requests;
using MarvicSolution.Services.Answer_Request.ViewModels;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;

namespace MarvicSolution.Services.Answer_Request.Services
{
    public interface ITest_Service
    {
        Task<double> GetTestScore(Guid idUser, SubmitTest_Request rq);
        List<TestResult_ViewModel> GetTestResult(Guid idUser);
    }
}
