using MarvicSolution.BackendApi.Constants;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Dtos.Requests;
using MarvicSolution.Services.Issue_Request.Dtos.Requests.Board;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Issue_Request.Issue_Request;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

        public IssueController(IIssue_Service issueService,
                                IWebHostEnvironment webHostEnvironment,
                                MarvicDbContext context)
        {
            _issueService = issueService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        #region Get method
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
        [Route("/api/Issue/GetIssuesArchive/{idProject}")]
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
        // /api/Issue/WorkedOn
        [HttpGet]
        [Route("/api/Issue/WorkedOn")]
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

        #endregion
        #region Group api
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
        #endregion
        #region Post method
        [HttpPost]
        [Route("/api/Issue/Create")]
        public async Task<IActionResult> Create([FromBody] Issue_CreateRequest rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var id_Issue = await _issueService.Create(UserLogin.Id, rq);
            if (id_Issue.Equals(Guid.Empty))
                return BadRequest("Cannot create a Issue");
            return Ok(id_Issue);
        }
        [HttpPost]
        [Route("DeleteFile")]
        public IActionResult DeleteFileAsync([FromBody] DeleteFile_Request rq)
        {
            // delete file in wwwroot/upload files
            string path = Path.Combine(_webHostEnvironment.WebRootPath, $"upload files\\{rq.FileName}");
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            // update attachment_path of issue
            var result = _issueService.DeleteFileIssue(rq);
            if (result)
            {
                return Ok("Delete file success");
            }
            else return BadRequest($"Cannot delete file in issue {rq.IdIssue}");
        }
        // Test bang Swagger co the bi loi CORS, hay test voi post man
        [HttpPost]
        [Route("UploadFile")]
        public IActionResult UploadFileAsync([FromForm] UploadFile_Request rq)
        {
            try
            {
                // replace file exist
                // delete file in wwwroot/upload files
                var issue = _issueService.Get_Issues_By_Id(rq.IdIssue);
                // check container folder exist
                string pathFolder = Path.Combine(_webHostEnvironment.WebRootPath, "upload files");
                if (!Directory.Exists(pathFolder))
                    Directory.CreateDirectory(pathFolder);
                // check file exist
                string pathFile = Path.Combine($"{pathFolder}\\{issue.FileName}");
                if (System.IO.File.Exists(pathFile))
                    System.IO.File.Delete(pathFile);
                if (rq.File != null)
                {
                    _issueService.DeleteFileIssue(new DeleteFile_Request(rq.IdIssue, rq.File.FileName));
                    // upload file for issue
                    _issueService.UploadedFile(rq.IdIssue, rq.File, UserLogin.Id);
                }
                var proj = _context.Projects.Find(issue.Id_Project);
                //return Redirect($"{SystemConstant.BaseUrl}/projects/backlog/{proj.Key}");
                return Redirect(rq.Url);
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        // /api/Issue/ChangeStage
        [HttpPost]
        [Route("ChangeStage")]
        public async Task<IActionResult> ChangeStage([FromBody] ChangeStage_Request rq)
        {
            if (await _issueService.ChangeStage(rq))
            {
                return Ok();
            }
            return BadRequest();
        }
        #endregion

        [HttpPut]
        [Route("/api/Issue/Update")]
        public async Task<IActionResult> Update([FromBody] Issue_UpdateRequest rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var idIssue = await _issueService.Update(UserLogin.Id, rq);
            if (idIssue.Equals(Guid.Empty))
                return BadRequest();
            return Ok(idIssue);
        }
        [HttpPut]
        [Route("/api/Issue/AddLabel")]
        public async Task<IActionResult> AddLabel([FromBody] IssueLabel_Request rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _issueService.AddLabel(rq);
            if (!result)
                return BadRequest("Fail");
            return Ok("Success");
        }
        [HttpPut("RemoveLabel/{idIssue}")]
        public async Task<IActionResult> RemoveLabel(Guid idIssue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _issueService.RemoveLabel(idIssue);
            if (!result)
                return BadRequest("Fail");
            return Ok("Success");
        }

        [HttpDelete("{IdIssue}")]
        public async Task<IActionResult> Delete(Guid IdIssue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var idIssue = await _issueService.Delete(IdIssue, UserLogin.Id);
            if (idIssue.Equals(Guid.Empty))
                return BadRequest();
            return Ok(idIssue);
        }

        [HttpGet("StatisticIssue")]
        public IActionResult StatisticIssue(Guid idProject, DateTime dateStarted, DateTime dateEnd)
        {
            var result =  _issueService.StatisticIssue(idProject, dateStarted, dateEnd);            
            return Ok(result);
        }

        [HttpGet("StatisticIssueArchived")]
        public IActionResult StatisticIssueArchived(Guid idProject, DateTime dateStarted, DateTime dateEnd)
        {
            var result = _issueService.StatisticIssueArchived(idProject, dateStarted, dateEnd);
            return Ok(result);
        }


    }
}
