using MarvicSolution.DATA.Common;
using MarvicSolution.Services.Project_Request.Project_Resquest;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos;
using MarvicSolution.Services.System.Helpers;
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
            if (_projectService == null)
            {
                return BadRequest();
            }
            var project = await _projectService.GetAlls();
            return Ok(project);
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
            var proj_Id = await _projectService.Create(rq);
            if (proj_Id.Equals(Guid.Empty))
                return BadRequest();

            return Ok("Create project success");
        }

        [HttpPut]
        [Route("/api/Project/Update")]// remember to check this route
        public async Task<IActionResult> Update([FromBody] Project_UpdateRequest rq)
        {
            var affectedResutl = await _projectService.Update(rq);
            if (affectedResutl.Equals(Guid.Empty))
                return BadRequest();

            return Ok("Update project success");
        }

        [HttpDelete("{proj_Id}")]
        public async Task<IActionResult> Delete(Guid proj_Id)
        {
            var affectedResutl = await _projectService.Delete(proj_Id);
            if (affectedResutl.Equals(Guid.Empty))
                return BadRequest();

            return Ok("Delete project success");
        }

        // api/Project/GetByIdUser/Id
        [HttpGet]
        [Route("/api/Project/GetByIdUser/Id")]
        public IActionResult GetByIdUser(Guid IdUser)
        {
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
            // get project by user has login
            var projects = _projectService.GetProjectByIdUser(UserLogin.Id);
            if (projects == null)
                return BadRequest($"Cannot get projects of idUser = {UserLogin.Id}");
            return Ok(projects);
        }

        // api/Project/AddMember?IdProject=xxx-xxx-xx
        [HttpPost]
        [Route("/api/Project/AddMember")]
        public IActionResult AddMember(Guid IdProject, params string[] UserName)
        {
            var idProject = _projectService.AddMembers(IdProject, UserName);
            if (idProject.Equals(Guid.Empty))
                return BadRequest($"Cannot get projects of idUser = {UserLogin.Id}");
            return Ok(idProject);
        }

        // api/Project/UserCanAdded
        [HttpGet]
        [Route("/api/Project/UserCanAdded")]
        public IActionResult UserCanAdded(Guid IdProject)
        {
            var listUserName = _projectService.Get_List_UserName_Can_Added_By_IdProject(IdProject);
            if (!listUserName.Any()) // Kiem tra list ko rong
                return BadRequest($"Cannot get list username by IdProject = {IdProject}");
            return Ok(listUserName);
        }
    }
}
