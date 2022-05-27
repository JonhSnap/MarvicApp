using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Answer_Request.Requests;
using MarvicSolution.Services.Answer_Request.ViewModels;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Answer_Request.Services
{
    public class Test_Service : ITest_Service
    {
        private readonly MarvicDbContext _context;
        private readonly ILogger<Test_Service> _logger;
        public Test_Service(MarvicDbContext context, ILogger<Test_Service> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<double> GetTestScore(SubmitTest_Request rq)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    // lọc ra những answer đúng từ ds input
                    var answerCorrect = await (from ans in _context.Answers
                                               join qus in _context.Questions on ans.Id_Question equals qus.Id
                                               where qus.Id_Test == rq.IdTest && ans.IsCorrect.Equals(EnumStatus.True)
                                               select new { id_ans = ans.Id, Scores = qus.Scores })
                                           .ToListAsync();
                    // compute score for test
                    var score = (from ans in answerCorrect
                               .AsEnumerable()
                                 join ansed in rq.listId on ans.id_ans equals ansed
                                 group ans.Scores by ans.Scores into g
                                 select g).Sum(a => (long)a.Key);
                    var testResult = new TestResut(Guid.NewGuid(), UserLogin.Id, rq.IdTest, DateTime.Now, score);
                    await _context.TestResuts.AddAsync(testResult);
                    await _context.SaveChangesAsync();
                    tran.Commit();
                    return score;
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"Controller: TestResult. Method: SubmitTest. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                    await tran.RollbackAsync();
                }
            }

        }

        public List<TestResult_ViewModel> GetTestResult(Guid idUser)
        {
            var results = (from tr in _context.TestResuts
                                 .AsEnumerable()
                           join tst in _context.Tests on tr.Id_Test equals tst.Id
                           orderby tst.Name
                           where tr.Id_User.Equals(idUser)
                           group tr by tst.Name into g
                           select new TestResult_ViewModel()
                           {
                               TestName = g.Key,
                               Items = g.Select(gr => new Result()
                               {
                                   CreateDate = gr.CreateDate.ToString("dd'/'MM'/'yyyy HH:mm:ss"),
                                   Score = gr.TotalPoint
                               }).OrderByDescending(tr => tr.CreateDate).ToList()
                           }).ToList();

            return results;
        }
    }
}
