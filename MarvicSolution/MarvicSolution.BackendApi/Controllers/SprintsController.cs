﻿using MarvicSolution.DATA.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MarvicSolution.Services.Sprint_Request.Services;
using MarvicSolution.Services.Sprint_Request.Requests;
using MarvicSolution.DATA.Enums;
using MarvicSolution.BackendApi.Constants;

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
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                var sprint = new Sprint(model.Id_Project, model.Sprint_Name, model.Id_Creator);
                if (await _sprint_Service.AddSprint(sprint, UserLogin.Id))
                {
                    return Ok();
                }
                return BadRequest();
            }
            else
                return Content("You do not have permission to perform this function");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Update_Sprint_Request model)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                if (DateTime.Compare(model.Start_Date, model.End_Date) > 0)
                {
                    return BadRequest(new { message = model.End_Date + " is earlier than " + model.Start_Date });
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
                    if (await _sprint_Service.UpdateSprint(sprint, UserLogin.Id))
                    {
                        return Ok();
                    }
                    return BadRequest();
                }
                return NotFound();
            }
            else
                return Content("You do not have permission to perform this function");
        }

        [HttpPut("start-print/{id}")]
        public async Task<IActionResult> StartPrint(Guid id, [FromBody] Start_Sprint_Request model)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                if (DateTime.Compare(model.Start_Date, model.End_Date) > 0)
                {
                    return BadRequest(new { message = model.End_Date + " is earlier than " + model.Start_Date });
                }
                var sprint = await _sprint_Service.GetSprintById(id);
                if (sprint != null && sprint.Is_Started == EnumStatus.False)
                {
                    sprint.Start_Date = model.Start_Date;
                    sprint.End_Date = model.End_Date;
                    sprint.Is_Started = EnumStatus.True;
                    if (await _sprint_Service.UpdateSprint(sprint, UserLogin.Id))
                    {
                        return Ok(new { message = sprint.SprintName + " is started!" });
                    }
                }
                return NotFound(new { message = id + " not found!" });
            }
            else
                return Content("You do not have permission to perform this function");
        }


        [HttpPost("complete-sprint")]
        public async Task<IActionResult> CompleteSprint([FromBody] Complete_Sprint_Request model)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                var sprintCurrent = await _sprint_Service.GetSprintById(model.CurrentSprintId);
                if (sprintCurrent != null && sprintCurrent.Is_Started == EnumStatus.True)
                {
                    if (await _sprint_Service.CompleteSprint(sprintCurrent, model, UserLogin.Id))
                        return Ok();
                    return BadRequest(new { message = "Complete sprint faild!" });
                }
                return NotFound(new { message = model.CurrentSprintId + " not found!" });
            }
            else
                return Content("You do not have permission to perform this function");
        }


        [HttpPut]
        [Route("/api/Sprints/AddIssuesToSprint")]
        public IActionResult AddIssuesToSprint([FromBody] AddIssue_Request rq)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                var idSprint = _sprint_Service.AddIssuesToSprint(rq);
                if (idSprint == Guid.Empty)
                    return BadRequest($"Cannot add issues to Sprint = {rq.IdSprint}");
                return Ok(idSprint);
            }
            else
                return Content("You do not have permission to perform this function");
        }

        [HttpPut]
        [Route("/api/Sprints/RemoveIssuesFromSprint")]
        public IActionResult RemoveIssuesFromSprint([FromBody] RemoveIssue_Request rq)
        {
            var result = _sprint_Service.RemoveIssuesFromSprint(rq);
            if (result == false)
                return BadRequest($"Cannot find one or more id in ListIdIssue");
            return Ok(result);
        }

        [HttpDelete]
        [Route("/api/Sprints/Delete")]
        public async Task<IActionResult> Delete([FromBody] Delete_ViewModel rq)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                var result = await _sprint_Service.Delete(rq, UserLogin.Id);
                if (result == false)
                    return BadRequest($"Cannot delete Sprint {rq.idSprintDelete}");
                return Ok(result);
            }
            else
                return Content("You do not have permission to perform this function");
        }
    }
}
