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
        [Route("/api/Issue/GetIssuesByIdProject")]
        public IActionResult GetIssuesByIdProject(Guid idProject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.Get_Issues_By_IdProject(idProject);
            if (issues == null)
                return BadRequest($"Cannot get issue by IdProject = {idProject}");
            return Ok(issues);
        }
        // /api/Issue/GetIssuesByIdSprint
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdSprint")]
        public IActionResult GetIssuesByIdSprint(Guid idSprint)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.Get_Issues_By_IdSprint(idSprint);
            if (issues == null)
                return BadRequest($"Cannot get issue by IdSprint = {idSprint}");
            return Ok(issues);
        }
        // /api/Issue/GetListIssueNotInSprintByIdProject
        [HttpGet]
        [Route("/api/Issue/GetListIssueNotInSprintByIdProject")]
        public IActionResult GetListIssueNotInSprintByIdProject(Guid idProject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.Get_Issues_NotInSprint_By_IdProject(idProject);
            if (issues == null)
                return BadRequest($"Cannot get issue by IdProject = {idProject}");
            return Ok(issues);
        }
        // /api/Issue/GetIssuesByIdUserLogin
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdUserLogin")]
        public IActionResult GetIssuesByIdUserLogin()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.Group_By_IdUser(UserLogin.Id);
            if (issues == null)
                return BadRequest($"Cannot get issue by user id = {UserLogin.Id}");
            return Ok(issues);
        }
        // /api/Issue/GroupByAssignee
        [HttpGet]
        [Route("/api/Issue/GroupByAssignee")]
        public IActionResult GroupByAssignee(Guid idProject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Group_By_Assignee(idProject);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by IdAssignee from IdProject = {idProject}");
            return Ok(groupIssues);
        }
        // /api/Issue/GroupByIssueType
        [HttpGet]
        [Route("/api/Issue/GroupByIssueType")]
        public IActionResult GroupByIssueType(Guid idProject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Group_By_IssueType(idProject);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by issue type from IdProject = {idProject}");
            return Ok(groupIssues);
        }
        // /api/Issue/GroupByPriority
        [HttpGet]
        [Route("/api/Issue/GroupByPriority")]
        public IActionResult GroupByPriority(Guid idProject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Group_By_Priority(idProject);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by issue priority from IdProject = {idProject}");
            return Ok(groupIssues);
        }
        // /api/Issue/GetIssueByIdParent
        [HttpGet]
        [Route("/api/Issue/GetIssueByIdParent")]
        public IActionResult GetIssueByIdParent([FromQuery] GetIssueByParentRequest rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Get_Issue_By_IdParent(rq.IdProject, rq.IdParent);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by IdParent = {rq.IdParent} from IdProject = {rq.IdProject}");
            return Ok(groupIssues);
        }
        // /api/Issue/GetIssuesByIdLabel
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdLabel")] 
        public IActionResult GetIssuesByIdLabel([FromQuery] GetIssueByLabelRequest rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Get_Issue_By_IdLabel(rq.IdProject, rq.IdLabel);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by Idlabel = {rq.IdLabel} from IdProject = {rq.IdProject}");
            return Ok(groupIssues);
        }
        [HttpPost]
        [Route("/api/Issue/Create")]
        public async Task<IActionResult> Create([FromBody] Issue_CreateRequest rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var id_Issue = await _issueService.Create(rq);
            if (id_Issue.Equals(Guid.Empty))
                return BadRequest("Cannot create a Issue");
            return Ok(id_Issue);
        }
        [HttpPut]
        [Route("/api/Issue/Update")]
        public async Task<IActionResult> Update([FromBody] Issue_UpdateRequest rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var idIssue = await _issueService.Update(rq);
            if (idIssue.Equals(Guid.Empty))
                return BadRequest();
            return Ok(idIssue);
        }
        [HttpDelete("{IdIssue}")]
        public async Task<IActionResult> Delete(Guid IdIssue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var idIssue = await _issueService.Delete(IdIssue);
            if (idIssue.Equals(Guid.Empty))
                return BadRequest();
            return Ok(idIssue);
        }
        [HttpGet]
        [Route("/api/Issue/GetIssueForBoard")]
        public IActionResult GetIssueForBoard(Guid idSprint)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.GetInforBoardByIdSprint(idSprint);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by issue priority from idSprint = {idSprint}");
            return Ok(groupIssues);
        }
    }
}
