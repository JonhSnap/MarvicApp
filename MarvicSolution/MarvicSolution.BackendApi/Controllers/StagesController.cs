using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MarvicSolution.Services.Stage_Request.Services;
using MarvicSolution.Services.Stage_Request.Requests;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;

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
            if (stages.Count == 0)
            {
                return NotFound(new { message = $"{id_project} not exists!" });
            }
            return Ok(stages);
        }

        [HttpPost]
        public async Task<IActionResult>CreateStage([FromBody] Create_Stage_Request model)
        {
            var stage = new Stage(model.Id_Project,model.Stage_Name,model.Id_Creator);
            if (await _stage_Service.AddStage(stage))
            {
                return Ok();
            }
            return BadRequest(new { messgae = "Create faild!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStage(Guid id,[FromBody] Update_Stage_Request model)
        {
            if (id!=Guid.Empty)
            {
                var stage = await _stage_Service.GetStageById(id);
                if (stage!=null)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStage(Guid id)
        {
            if (id != Guid.Empty)
            {
                var stage = await _stage_Service.GetStageById(id);
                if (stage != null)
                {
                    stage.isDeleted = EnumStatus.True;
                    if (await _stage_Service.UpdateStage(stage))
                    {
                        return Ok();
                    }
                    return BadRequest(new { messgae = "Delete fail!" });
                }
                return NotFound(new { message = $"{id} not exists!" });
            }
            return BadRequest("Id is empty!");
        }
    }
}
