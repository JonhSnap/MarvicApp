using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Issue_Request.Dtos.Requests;
using MarvicSolution.Services.Issue_Request.Issue_Request;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos.ViewModels;
using MarvicSolution.Utilities.Exceptions;
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

        // /api/Issue/GetIssuesByIdProject
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdProject")]// remember to check this route
        public IActionResult GetIssuesByIdProject(Guid idProject)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var issues = _issueService.Get_Issues_By_IdProject(idProject);
                if (issues == null)
                    return BadRequest($"Cannot get issue by IdProject = {idProject}");
                return Ok(issues);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        // /api/Issue/GetIssuesByIdUserLogin
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdUserLogin")]// remember to check this route
        public IActionResult GetIssuesByIdUserLogin(Guid idProject)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var issues = _issueService.Get_Issues_By_IdUser(idProject, UserLogin.Id);
                if (issues == null)
                    return BadRequest($"Cannot get issue by IdProject = {idProject}");
                return Ok(issues);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        // /api/Issue/GroupByAssignee
        [HttpGet]
        [Route("/api/Issue/GroupByAssignee")]// remember to check this route
        public IActionResult GroupByAssignee(Guid idProject)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var groupIssues = _issueService.Group_By_Assignee(idProject);
                if (groupIssues == null)
                    return BadRequest($"Cannot get group issue by IdAssignee from IdProject = {idProject}");
                return Ok(groupIssues);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        // /api/Issue/GroupByIssueType
        [HttpGet]
        [Route("/api/Issue/GroupByIssueType")]// remember to check this route
        public IActionResult GroupByIssueType(Guid idProject)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var groupIssues = _issueService.Group_By_IssueType(idProject);
                if (groupIssues == null)
                    return BadRequest($"Cannot get group issue by issue type from IdProject = {idProject}");
                return Ok(groupIssues);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        // /api/Issue/GroupByPriority
        [HttpGet]
        [Route("/api/Issue/GroupByPriority")]// remember to check this route
        public IActionResult GroupByPriority(Guid idProject)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var groupIssues = _issueService.Group_By_Priority(idProject);
                if (groupIssues == null)
                    return BadRequest($"Cannot get group issue by issue priority from IdProject = {idProject}");
                return Ok(groupIssues);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        // /api/Issue/GetIssueByIdParent
        [HttpGet]
        [Route("/api/Issue/GetIssueByIdParent")]// remember to check this route
        public IActionResult GetIssueByIdParent([FromQuery] GetIssueByParentRequest rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var groupIssues = _issueService.Get_Issue_By_IdParent(rq.IdProject, rq.IdParent);
                if (groupIssues == null)
                    return BadRequest($"Cannot get group issue by IdParent = {rq.IdParent} from IdProject = {rq.IdProject}");
                return Ok(groupIssues);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        // /api/Issue/GetIssuesByIdLabel
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdLabel")]// remember to check this route
        public IActionResult GetIssuesByIdLabel([FromQuery] GetIssueByLabelRequest rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var groupIssues = _issueService.Get_Issue_By_IdLabel(rq.IdProject, rq.IdLabel);
                if (groupIssues == null)
                    return BadRequest($"Cannot get group issue by Idlabel = {rq.IdLabel} from IdProject = {rq.IdProject}");
                return Ok(groupIssues);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        /// <summary>
        /// DateTime format: 3/29/2022
        /// </summary>
        /// <param name="rq">Request from client</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Issue/Create")]// remember to check this route
        public async Task<IActionResult> Create([FromBody] Issue_CreateRequest rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var id_Issue = await _issueService.Create(rq);
                if (id_Issue.Equals(Guid.Empty))
                    return BadRequest("Cannot create a Issue");
                return Ok(id_Issue);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        [HttpPut]
        [Route("/api/Issue/Update")]// remember to check this route
        public async Task<IActionResult> Update([FromBody] Issue_UpdateRequest rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var idIssue = await _issueService.Update(rq);
                if (idIssue.Equals(Guid.Empty))
                    return BadRequest();
                return Ok(idIssue);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }

        [HttpDelete("{IdIssue}")]// remember to check this route
        public async Task<IActionResult> Delete(Guid IdIssue)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var idIssue = await _issueService.Delete(IdIssue);
                if (idIssue.Equals(Guid.Empty))
                    return BadRequest();
                return Ok(idIssue);
            }
            catch (Exception e) { throw new MarvicException($"Error: {e}"); }
        }
    }
}
