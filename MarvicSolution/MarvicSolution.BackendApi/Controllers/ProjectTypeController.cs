using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest;
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
    }
}
