using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Answer_Request.Requests;
using MarvicSolution.Services.Answer_Request.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultsController : ControllerBase
    {
        // Must declare DI in startup
        private readonly MarvicDbContext _context;
        private readonly ITest_Service _test_Service;
        public TestResultsController(MarvicDbContext context, ITest_Service test_Service)
        {
            _context = context;
            _test_Service = test_Service;
        }

        [HttpPost]
        [Route("SubmitTest")]
        public async Task<IActionResult> SubmitTest([FromBody] SubmitTest_Request rq)
        {
            var score = await _test_Service.GetTestScore(rq);
            return Ok(score);
        }

        [HttpGet("GetTestResult")]
        public async Task<IActionResult> GetTestResult()
        {
            var score = _test_Service.GetTestResult(UserLogin.Id);
            return Ok(score);
        }
    }
}
