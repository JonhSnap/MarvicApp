using MarvicSolution.Services.Project_Request.Project_Resquest;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos;
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
        private readonly IProject_Service _service;
        public ProjectController(IProject_Service service)
        {
            _service = service;
        }

        // /api/Project/GetAlls
        [HttpGet]
        [Route("/api/Project/GetAlls")] // remember to check this route
        public async Task<IActionResult> GetAlls()
        {
            if (_service == null)
            {
                return BadRequest();
            }
            var project = await _service.GetAlls_Linq();
            return Ok(project);
        }

        // /api/Project/GetAllsTscript
        //[HttpGet]
        //[Route("/api/Project/GetAllsProc")]// remember to check this route
        //public async Task<IActionResult> GetAllsProc()
        //{
        //    if (_service == null)
        //    {
        //        return BadRequest();
        //    }
        //    var project = await _service.GetAlls_Proc();
        //    return Ok(project);
        //}

        //[HttpGet]
        //[Route("/api/Project/GetAllsTscript")]// remember to check this route
        //public async Task<IActionResult> GetAllsTscript()
        //{
        //    if (_service == null)
        //    {
        //        return BadRequest();
        //    }
        //    var project = await _service.GetAlls_Tscript();
        //    return Ok(project);
        //}

        // /api/Project/GetGroupbyProjectTypeTscript
        //[HttpGet("{projType_Id}")]
        //[Route("/api/Project/Groupby_ProjectType_Tscript")] // remember to check this route
        //public async Task<IActionResult> Get_Groupby_ProjectType_Tscript(Guid projType_Id)
        //{
        //    if (_service == null)
        //    {
        //        return BadRequest();
        //    }
        //    var project = await _service.Groupby_ProjectType_Tscript(projType_Id);
        //    return Ok(project);
        //}

        /// <summary>
        /// DateTime format: 3/29/2022
        /// </summary>
        /// <param name="rq">Request from client</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Project/Create")]// remember to check this route
        public async Task<IActionResult> Create([FromBody] Project_CreateRequest rq)
        {
            var proj_Id = await _service.Create(rq);
            if (proj_Id.Equals(Guid.Empty))
                return BadRequest();

            return Ok("Create project success");
        }

        [HttpPut]
        [Route("/api/Project/Update")]// remember to check this route
        public async Task<IActionResult> Update([FromBody] Project_UpdateRequest rq)
        {
            var affectedResutl = await _service.Update(rq);
            if (affectedResutl.Equals(Guid.Empty))
                return BadRequest();

            return Ok("Update project success");
        }

        [HttpDelete("{proj_Id}")]
        public async Task<IActionResult> Delete(Guid proj_Id)
        {
            var affectedResutl = await _service.Delete(proj_Id);
            if (affectedResutl.Equals(Guid.Empty))
                return BadRequest();

            return Ok("Delete project success");
        }
    }
}
