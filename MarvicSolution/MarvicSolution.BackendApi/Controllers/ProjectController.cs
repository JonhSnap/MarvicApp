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
        [Route("/api/Project/GetAlls")]
        public async Task<IActionResult> GetAlls()
        {
            if (_service == null)
            {
                return BadRequest();
            }
            var project = await _service.GetAlls();
            return Ok(project);
        }

        /// <summary>
        /// DateTime format: 3/29/2022
        /// </summary>
        /// <param name="rq">Request from client</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Project/Create")]
        public async Task<IActionResult> Create([FromForm] Project_CreateRequest rq)
        {
            var proj_Id = await _service.Create(rq);
            if (proj_Id.Equals("00000000-0000-0000-0000-000000000000"))
                return BadRequest();

            //return Created(nameof(GetAlls), proj_Id);
            return Ok();
        }

        [HttpPut]
        [Route("/api/Project/Update")]
        public async Task<IActionResult> Update([FromForm] Project_UpdateRequest rq)
        {
            var affectedResutl = await _service.Update(rq);
            if (affectedResutl.Equals("00000000-0000-0000-0000-000000000000"))
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{proj_Id}")]
        public async Task<IActionResult> Delete(Guid proj_Id)
        {
            var affectedResutl = await _service.Delete(proj_Id);
            if (affectedResutl.Equals("00000000-0000-0000-0000-000000000000"))
                return BadRequest();

            return Ok();
        }
    }
}
