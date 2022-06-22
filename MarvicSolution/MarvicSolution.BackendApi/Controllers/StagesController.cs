using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MarvicSolution.Services.Stage_Request.Services;
using MarvicSolution.Services.Stage_Request.Requests;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using System.Linq;
using MarvicSolution.BackendApi.Constants;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        private readonly IStage_Service _stage_Service;
        public StagesController(IStage_Service stage_Service)
        {
            _stage_Service = stage_Service;
        }

        [HttpGet("project/{id_project}")]
        public async Task<IActionResult> GetStagesByProjectId(Guid id_project)
        {
            var stages = await _stage_Service.GetStageByProjectId(id_project);
            if (stages == null)
            {
                return NotFound(new { message = $"{id_project} not found!" });
            }
            return Ok(stages);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStage([FromBody] Create_Stage_Request model)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                if (!await _stage_Service.CheckExistName(model.Stage_Name))
                {
                    var stageInProject = await _stage_Service.GetStageByProjectId(model.Id_Project);
                    if (stageInProject != null)
                    {
                        var stage = new Stage(model.Id_Project, model.Stage_Name, model.Id_Creator, stageInProject.Max(stage => stage.Order) + 1);
                        if (await _stage_Service.AddStage(stage))
                            return Ok();

                        return BadRequest(new { messgae = "Create faild!" });
                    }

                    return NotFound(new { messgae = $"{model.Id_Project} not found!" });
                }
                return BadRequest(new { messgae = $"{model.Stage_Name} is existed!" });
            }
            else
                return Content("You do not have permission to perform this function");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStage(Guid id, [FromBody] Update_Stage_Request model)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                if (id != Guid.Empty)
                {
                    var stage = await _stage_Service.GetStageById(id);
                    if (stage != null)
                    {
                        stage.Stage_Name = model.Stage_Name;
                        stage.Id_Updator = model.Id_Updator;
                        stage.UpdateDate = DateTime.Now;
                        if (await _stage_Service.UpdateStage(stage))
                        {
                            return Ok();
                        }
                        return BadRequest(new { messgae = "Update fail!" });
                    }
                    return NotFound(new { message = $"{id} not exists!" });
                }
                return BadRequest("Id is empty!");
            }
            else
                return Content("You do not have permission to perform this function");
        }

        [HttpPost("draganddrop")]
        public async Task<IActionResult> DragAndDrop([FromBody] Drop_Stage_Request model)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                if (!await _stage_Service.DragAndDrop(model.CurrentPos, model.NewPos, model.Id_Project))
                    return BadRequest(new { message = "Fail" });
                return Ok(new { message = "Success!" });
            }
            else
                return Content("You do not have permission to perform this function");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStage(Guid id, [FromBody] Remove_Stage_Request modelRequest)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                if (id != Guid.Empty)
                {
                    var stage = await _stage_Service.GetStageById(id);
                    if (stage != null)
                    {
                        stage.isDeleted = EnumStatus.True;
                        if (await _stage_Service.DeleteStage(stage, modelRequest, UserLogin.Id))
                            return Ok();
                        return BadRequest(new { messgae = "Delete fail!" });
                    }
                    return NotFound(new { message = $"{id} not exists!" });
                }
                return BadRequest("Id is empty!");
            }
            else
                return Content("You do not have permission to perform this function");
        }
    }
}
