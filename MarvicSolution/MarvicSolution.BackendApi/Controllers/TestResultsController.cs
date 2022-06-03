using MarvicSolution.BackendApi.Constants;
using MarvicSolution.DATA.EF;
using MarvicSolution.Services.Answer_Request.Requests;
using MarvicSolution.Services.Answer_Request.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultsController : ControllerBase
    {
        // Must declare DI in startup
        private readonly ITest_Service _test_Service;
        public TestResultsController(ITest_Service test_Service)
        {
            _test_Service = test_Service;
        }

        [HttpPost]
        [Route("SubmitTest")]
        public async Task<IActionResult> SubmitTest([FromBody] SubmitTest_Request rq)
        {
            var score = await _test_Service.GetTestScore(UserLogin.Id, rq);
            return Ok(score);
        }

        [HttpGet("GetTestResult")]
        public IActionResult GetTestResult()
        {
            var score = _test_Service.GetTestResult(UserLogin.Id);
            return Ok(score);
        }
    }
}
