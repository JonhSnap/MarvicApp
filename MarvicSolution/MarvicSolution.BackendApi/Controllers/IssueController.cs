using MarvicSolution.BackendApi.Hubs;
using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Dtos.Requests;
using MarvicSolution.Services.Issue_Request.Dtos.Requests.Board;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Issue_Request.Issue_Request;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        // Must declare DI in startup
        private readonly IIssue_Service _issueService;
        private readonly MarvicDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHubContext<ActionHub, IActionHub> _actionHub;

        public IssueController(IIssue_Service issueService, IWebHostEnvironment webHostEnvironment, MarvicDbContext context, IHubContext<ActionHub, IActionHub> actionHub)
        {
            _issueService = issueService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _actionHub = actionHub;
        }
        // /api/Issue/GetIssuesByIdProject
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdProject")]
        public IActionResult GetIssuesByIdProject(Guid idProject)
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.Get_Issues_By_IdProject(idProject, rq);
            if (issues == null)
                return BadRequest($"Cannot get issue by IdProject = {idProject}");
            
            return Ok(issues);
        }
        // /api/Issue/GetIssuesByIdSprint
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdSprint")]
        public IActionResult GetIssuesByIdSprint(Guid idSprint)
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.Get_Issues_By_IdSprint(idSprint, rq);
            if (issues == null)
                return BadRequest($"Cannot get issue by IdSprint = {idSprint}");
            return Ok(issues);
        }
        // /api/Issue/GetListIssueNotInSprintByIdProject
        [HttpGet]
        [Route("/api/Issue/GetListIssueNotInSprintByIdProject")]
        public IActionResult GetListIssueNotInSprintByIdProject(Guid idProject)
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.Get_Issues_NotInSprint_By_IdProject(idProject, rq);
            if (issues == null)
                return BadRequest($"Cannot get issue by IdProject = {idProject}");
            return Ok(issues);
        }
        // /api/Issue/GetIssuesByIdUserLogin
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdUserLogin")]
        public IActionResult GetIssuesByIdUserLogin()
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.Group_By_IdUser(UserLogin.Id, rq);
            if (issues == null)
                return BadRequest($"Cannot get issue by user id = {UserLogin.Id}");
            return Ok(issues);
        }
        // /api/Issue/GroupByAssignee
        [HttpGet]
        [Route("/api/Issue/GroupByAssignee")]
        public IActionResult GroupByAssignee(Guid idProject)
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Group_By_Assignee(idProject, rq);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by IdAssignee from IdProject = {idProject}");
            return Ok(groupIssues);
        }
        // /api/Issue/GroupByIssueType
        [HttpGet]
        [Route("/api/Issue/GroupByIssueType")]
        public IActionResult GroupByIssueType(Guid idProject)
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Group_By_IssueType(idProject, rq);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by issue type from IdProject = {idProject}");
            return Ok(groupIssues);
        }
        // /api/Issue/GroupByPriority
        [HttpGet]
        [Route("/api/Issue/GroupByPriority")]
        public IActionResult GroupByPriority(Guid idProject)
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Group_By_Priority(idProject, rq);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by issue priority from IdProject = {idProject}");
            return Ok(groupIssues);
        }
        // /api/Issue/GetIssueByIdParent
        [HttpGet]
        [Route("/api/Issue/GetIssueByIdParent")]
        public IActionResult GetIssueByIdParent([FromQuery] GetIssueByParentRequest rq)
        {
            RequestVM rqVM = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Get_Issue_By_IdParent(rq.IdProject, rq.IdParent, rqVM);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by IdParent = {rq.IdParent} from IdProject = {rq.IdProject}");
            return Ok(groupIssues);
        }
        // /api/Issue/GetIssuesByIdLabel
        [HttpGet]
        [Route("/api/Issue/GetIssuesByIdLabel")]
        public IActionResult GetIssuesByIdLabel([FromQuery] GetIssueByLabelRequest rq)
        {
            RequestVM rqVM = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Get_Issue_By_IdLabel(rq.IdProject, rq.IdLabel, rqVM);
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

            await _actionHub.Clients.All.Issue();
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
            await _actionHub.Clients.All.Issue();
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
            await _actionHub.Clients.All.Issue();
            return Ok(idIssue);
        }
        [HttpGet]
        [Route("/api/Issue/GetIssueForBoard")]
        public IActionResult GetIssueForBoard(Guid idSprint, Guid? idEpic, EnumIssueType? type)
        {
            RequestVM rqVM = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            GetBoardIssue_Request rq = new GetBoardIssue_Request(idSprint, idEpic, type);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var boardIssues = _issueService.GetInforBoardByIdSprint(rq, rqVM);
            if (boardIssues == null)
                return BadRequest($"Cannot get Board's issue by idSprint = {rq.IdSprint}");
            return Ok(boardIssues);
        }
        [HttpGet]
        [Route("/api/Issue/GroupIssueForBoardByAssignee")]
        public IActionResult GroupIssueForBoardByAssignee(Guid idSprint, Guid? idEpic, EnumIssueType? type)
        {
            RequestVM rqVM = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            GetBoardIssue_Request rq = new GetBoardIssue_Request(idSprint, idEpic, type);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.GroupIssueForBoardByAssignee(rq, rqVM);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by issue priority from idSprint = {rq.IdSprint}");
            return Ok(groupIssues);
        }
        [HttpGet("download")]
        public FileResult DownloadFile([FromQuery] string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(_webHostEnvironment.WebRootPath, $"upload files//{fileName}");

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
        [HttpPost]
        [Route("DeleteFile")]
        public async Task<IActionResult> DeleteFileAsync([FromBody] DeleteFile_Request rq)
        {
            // delete file in wwwroot/upload files
            string path = Path.Combine(_webHostEnvironment.WebRootPath, $"upload files\\{rq.FileName}");
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            // update attachment_path of issue
            var result = _issueService.DeleteFileIssue(rq);
            if (result)
            {
                await _actionHub.Clients.All.Issue();
                return Ok("Delete file success");
            }
            else return BadRequest($"Cannot delete file in issue {rq.IdIssue}");
        }
        // Test bang Swagger co the bi loi CORS, hay test voi post man
        [HttpPost]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFileAsync([FromForm] UploadFile_Request rq)
        {
            // replace file exist
            // delete file in wwwroot/upload files
            var issue = _issueService.Get_Issues_By_Id(rq.IdIssue);
            string path = Path.Combine(_webHostEnvironment.WebRootPath, $"upload files\\{issue.FileName}");
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            if (rq.File != null)
            {
                _issueService.DeleteFileIssue(new DeleteFile_Request(rq.IdIssue, rq.File.FileName));
                // update file for issue
                _issueService.UploadedFile(rq.IdIssue, rq.File);
            }

            await _actionHub.Clients.All.Issue();
            return Ok($"Upload file success for issue = {rq.IdIssue}");
        }

        // /api/Issue/GroupByEpic
        [HttpGet]
        [Route("/api/Issue/GroupByEpic")]
        public IActionResult GroupByEpic(Guid idProject)
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var groupIssues = _issueService.Group_By_Epic(idProject, rq);
            if (groupIssues == null)
                return BadRequest($"Cannot get group issue by IdAssignee from IdProject = {idProject}");
            return Ok(groupIssues);
        }
        // /api/Issue/GetIssuesAssignedToMe
        [HttpGet]
        [Route("/api/Issue/GetIssuesAssignedToMe")]
        public IActionResult GetIssuesAssignedToMe()
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.GetIssueAssignedToMe(UserLogin.Id, rq);
            if (issues == null)
                return BadRequest($"Cannot get issue assigned to user {UserLogin.Id}");
            return Ok(issues);
        }

        // /api/Issue/GetIssuesArchive
        [HttpGet]
        [Route("/api/Issue/GetIssuesArchive")]
        public IActionResult GetIssuesArchive(Guid idProject)
        {
            RequestVM rq = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var issues = _issueService.GetIssuesArchive(idProject, rq);
            if (issues == null)
                return BadRequest($"Cannot get issue assigned to user {UserLogin.Id}");
            return Ok(issues);
        }
        // /api/WorkedOn
        [HttpGet]
        [Route("/api/WorkedOn")]
        public IActionResult WorkedOn()
        {
            RequestVM rqVM = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var wo = _issueService.GetIssueForWorkedOn(UserLogin.Id, rqVM);
            if (wo == null)
                return BadRequest($"Cannot get issue by UserID = {UserLogin.Id}");

            _context.SaveChanges();
            return Ok(wo);
        }
    }
}
