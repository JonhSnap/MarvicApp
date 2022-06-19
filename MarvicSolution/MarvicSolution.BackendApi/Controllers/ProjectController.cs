using MarvicSolution.BackendApi.Constants;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Project_Request.Project_Resquest;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos;
using MarvicSolution.Services.Project_Resquest.Dtos.Requests;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        // Must declare DI in startup
        private readonly IProject_Service _projectService;
        public ProjectController(IProject_Service projectService)
        {
            _projectService = projectService;
        }

        // /api/Project/GetAlls
        [HttpGet]
        [Route("/api/Project/GetAlls")] // remember to check this route
        public async Task<IActionResult> GetAlls()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var project = await _projectService.GetAlls();
            if (project == null)
                return BadRequest("Cannot get all projects");
            return Ok(project);
        }

        // api/Project/GetProjectByIdUser/Id
        [HttpGet]
        [Route("/api/Project/GetProjectByIdUser/Id")]
        public IActionResult GetProjectByIdUser(Guid IdUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // get project by user has login
            var projects = _projectService.GetProjectByIdUser(IdUser);
            if (projects == null)
                return BadRequest($"Cannot get projects of idUser = {IdUser}");
            return Ok(projects);
        }

        // api/Project/GetByLoginUser
        [HttpGet]
        [Route("/api/Project/GetByLoginUser")]
        public IActionResult GetByLoginUser()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // get project by user has login
            var projects = _projectService.GetProjectByIdUser(UserLogin.Id);
            if (projects == null)
                return BadRequest($"Cannot get projects of idUser = {UserLogin.Id}");
            return Ok(projects);
        }

        // api/Project/UserCanAdded
        [HttpGet]
        [Route("/api/Project/UserCanAdded")]
        public IActionResult UserCanAdded(Guid IdProject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var listUserName = _projectService.Get_List_UserName_Can_Added_By_IdProject(IdProject);
            if (!listUserName.Any()) // Kiem tra list ko rong
                return BadRequest($"Cannot get list username by IdProject = {IdProject}");
            return Ok(listUserName);
        }

        // api/Project/GetAllMemberByIdProject
        [HttpGet]
        [Route("/api/Project/GetAllMemberByIdProject")]
        public IActionResult GetAllMemberByIdProject(Guid IdProject)
        {
            RequestVM rqVM = new RequestVM(Request.Scheme, Request.Host, Request.PathBase);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var members = _projectService.Get_AllMembers_By_IdProject(IdProject, rqVM);
            if (!members.Any())
                return BadRequest($"Cannot find any member from IdProject = {IdProject}");
            return Ok(members);
        }

        /// <summary>
        /// DateTime format: 3/29/2022
        /// </summary>
        /// <param name="rq">Request from client</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Project/Create")]// remember to check this route
        public async Task<IActionResult> Create([FromBody] Project_CreateRequest rq)
        {
            // Check model state
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // Create a project
            var IdProj = await _projectService.Create(UserLogin.Id, rq);
            if (IdProj.Equals(Guid.Empty))
                return BadRequest();
            return Ok("Create project success");
        }

        // api/Project/AddMember?IdProject=xxx-xxx-xx
        [HttpPost]
        [Route("/api/Project/AddMember")]
        public IActionResult AddMember([FromBody] AddMember_Request rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var idProject = _projectService.AddMembers(rq.IdProject, rq.UserNames, UserLogin.Id);
            if (idProject.Equals(Guid.Empty))
                return BadRequest($"Cannot get projects = {rq.IdProject}");
            return Ok(idProject);
        }

        // api/Project/RemoveMember
        [HttpPost]
        [Route("/api/Project/RemoveMember")]
        public IActionResult RemoveMember([FromBody] RemoveMember_Request rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = _projectService.Remove_Member_From_Project(rq.IdProject, rq.IdUser, UserLogin.Id);
                if (result.Equals(Guid.Empty))
                    return BadRequest($"Cannot remove idUser = {rq.IdUser} from IdProject = {rq.IdProject}");
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }

        }
        [HttpPut]
        [Route("/api/Project/Update")]// remember to check this route
        public async Task<IActionResult> Update([FromBody] Project_UpdateRequest rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _projectService.Update(UserLogin.Id, rq);
            if (result.Equals(Guid.Empty))
                return BadRequest();
            return Ok("Update project success");
        }
        [HttpPatch]
        [Route("/api/Project/UpdateStarredProject")]// remember to check this route
        public async Task<IActionResult> UpdateStarredProject([FromBody] UpdateStarredProject_Request rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _projectService.UpdateStarredProject(rq);
            if (result.Equals(Guid.Empty))
                return BadRequest();
            return Ok(result);
        }
        [HttpPatch]
        [Route("/api/Project/DisableMember")]// remember to check this route
        public IActionResult DisableMember([FromBody] DisableMember_Request rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = _projectService.DisableMember(rq);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{proj_Id}")]
        public async Task<IActionResult> Delete(Guid proj_Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var affectedResutl = await _projectService.Delete(proj_Id, UserLogin.Id);
            if (affectedResutl.Equals(Guid.Empty))
                return BadRequest();
            return Ok("Delete project success");
        }

        // api/Project/GetStarredProject
        [HttpGet]
        [Route("/api/Project/GetStarredProject")]
        public IActionResult GetStarredProject()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var project = _projectService.GetStarredProject(UserLogin.Id);
            //if (!project.Any()) // Kiem tra list ko rong
            //    return BadRequest($"Cannot get list username by IdProject = {UserLogin.Id}");
            return Ok(project);
        }
    }
}
