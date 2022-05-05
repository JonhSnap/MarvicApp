using MarvicSolution.DATA.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MarvicSolution.Services.Sprint_Request.Services;
using MarvicSolution.Services.Sprint_Request.Requests;
using MarvicSolution.DATA.Enums;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintsController : ControllerBase
    {
        private readonly ISprint_Service _sprint_Service;
       
        public SprintsController(ISprint_Service sprint_Service)
        {
            _sprint_Service = sprint_Service;
        }
       
        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetSprintById_Project(Guid id)
        {
            try
            {
                var sprints = await _sprint_Service.GetSprintsById_Project(id);
                if (sprints.Count == 0)
                {
                    return NotFound();
                }
                return Ok(sprints);
            }
            catch (Exception)
            {
                //log here,,,
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create_Sprint_Request model)
        {
            try
            {
                var sprint = new Sprint(model.Id_Project,model.Sprint_Name, model.Id_Creator);
                if (await _sprint_Service.AddSprint(sprint))
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                //log here,,,
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var sprint = await _sprint_Service.GetSprintById(id);
                if (sprint!=null)
                {
                    sprint.Is_Delete = EnumStatus.True;
                    if (await _sprint_Service.DeleteSprint(sprint))
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
                return NotFound();
            }
            catch (Exception)
            {
                //log here,,,
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] Update_Sprint_Request model)
        {
            try
            {
                if (DateTime.Compare(model.Start_Date,model.End_Date)>0)
                {
                    return BadRequest(new { message=model.End_Date + " is earlier than " + model.Start_Date });
                }
                var sprint = await _sprint_Service.GetSprintById(id);
                if (sprint != null)
                {
                    sprint.Id_Project = model.Id_Project;
                    sprint.SprintName = model.Sprint_Name;
                    sprint.Id_Creator = model.Id_Creator;
                    sprint.Start_Date = model.Start_Date;
                    sprint.End_Date = model.End_Date;
                    sprint.Update_Date = DateTime.Now;
                    if (await _sprint_Service.UpdateSprint(sprint))
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
                return NotFound();
            }
            catch (Exception)
            {
                //log here,,,
                throw;
            }
        }
    }
}
