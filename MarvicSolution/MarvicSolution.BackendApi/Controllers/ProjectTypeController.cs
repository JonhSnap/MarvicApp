using MarvicSolution.DATA.Entities;
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
    public class ProjectTypeController : ControllerBase
    {
        // Must declare DI in startup
        private readonly IProjectType_Service _service;
        public ProjectTypeController(IProjectType_Service service)
        {
            _service = service;
        }

        // /api/ProjectType/
        [HttpGet]
        [Route("/api/ProjectType/Get")]// remember to check this route
        public async Task<IActionResult> Get()
        {
            if (_service == null)
            {
                return BadRequest();
            }
            var prjTypes = await _service.GetAlls();
            return Ok(prjTypes);
        }

        /// <summary>
        /// DateTime format: 3/29/2022
        /// </summary>
        /// <param name="rq">Request from client</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/ProjectType/Create")]// remember to check this route
        public async Task<IActionResult> Create([FromForm]ProjectType_CreateRequest rq)
        {
            var prjTypeId = await _service.Create(rq);
            if (prjTypeId.Equals(Guid.Empty))
                return BadRequest();

            //return Created(nameof(GetAlls), prjTypeId);
            return Ok();
        }

        [HttpPut]
        [Route("/api/ProjectType/Update")]// remember to check this route
        public async Task<IActionResult> Update([FromForm]ProjectType_UpdateRequest rq)
        {
            var affectedResutl = await _service.Update(rq);
            if (affectedResutl.Equals(Guid.Empty))
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{projTypeId}")]// remember to check this route
        public async Task<IActionResult> Delete(Guid projTypeId)
        {
            var affectedResutl = await _service.Delete(projTypeId);
            if (affectedResutl.Equals(Guid.Empty))
                return BadRequest();

            return Ok();
        }
    }
}
