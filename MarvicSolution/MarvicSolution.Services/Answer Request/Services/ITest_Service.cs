using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Answer_Request.Requests;
using MarvicSolution.Services.Answer_Request.ViewModels;

namespace MarvicSolution.Services.Answer_Request.Services
{
    public interface ITest_Service
    {
        Task<double> GetTestScore(Guid idUser, SubmitTest_Request rq);
        List<TestResult_ViewModel> GetTestResult(Guid idUser);
        List<Test> GetTests();
        GetTestToDo_ViewModel GetTestById(Guid idTest);
    }
}
