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
        public async Task<IActionResult> Get()
        {
            if (_service == null)
            {
                return BadRequest();
            }
            var prjTypes = await _service.GetAlls();
            return Ok(prjTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProjectType_CreateRequest rq)
        {
            var prjTypeId = await _service.Create(rq);
            if (prjTypeId.Equals("00000000-0000-0000-0000-000000000000"))
                return BadRequest();

            return Created(nameof(Get), prjTypeId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProjectType_UpdateRequest rq)
        {
            var affectedResutl = await _service.Update(rq);
            if (affectedResutl.Equals("00000000-0000-0000-0000-000000000000"))
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{prjTypeId}")]
        public async Task<IActionResult> Delete(Guid prjTypeId)
        {
            var affectedResutl = await _service.Delete(prjTypeId);
            if (affectedResutl.Equals("00000000-0000-0000-0000-000000000000"))
                return BadRequest();

            return Ok();
        }
    }
}
