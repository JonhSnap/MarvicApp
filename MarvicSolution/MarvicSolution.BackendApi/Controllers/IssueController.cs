using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Issue_Request.Issue_Request;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        // Must declare DI in startup
        private readonly IIssue_Service _issueService;
        public IssueController(IIssue_Service issueService)
        {
            _issueService = issueService;
        }

        //// /api/Issue/
        //[HttpGet]
        //[Route("/api/Issue/Get")]// remember to check this route
        //public async Task<IActionResult> Get()
        //{
        //    if (_issueService == null)
        //    {
        //        return BadRequest();
        //    }
        //    var prjTypes = await _issueService.GetAlls();
        //    return Ok(prjTypes);
        //}

        /// <summary>
        /// DateTime format: 3/29/2022
        /// </summary>
        /// <param name="rq">Request from client</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Issue/Create")]// remember to check this route
        public async Task<IActionResult> Create([FromBody]Issue_CreateRequest rq)
        {
            var id_Issue = await _issueService.Create(rq);
            if (id_Issue.Equals(Guid.Empty))
                return BadRequest();

            return Ok(id_Issue);
        }

        [HttpPut]
        [Route("/api/Issue/Update")]// remember to check this route
        public async Task<IActionResult> Update([FromForm] Issue_UpdateRequest rq)
        {
            var idIssue = await _issueService.Update(rq);
            if (idIssue.Equals(Guid.Empty))
                return BadRequest();

            return Ok(idIssue);
        }

        [HttpDelete("{IdIssue}")]// remember to check this route
        public async Task<IActionResult> Delete(Guid IdIssue)
        {
            var idIssue = await _issueService.Delete(IdIssue);
            if (idIssue.Equals(Guid.Empty))
                return BadRequest();

            return Ok(idIssue);
        }
    }
}
