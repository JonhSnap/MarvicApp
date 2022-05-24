using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MarvicSolution.Services.Stage_Request.Services;
using MarvicSolution.Services.Stage_Request.Requests;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.DATA.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MarvicSolution.BackendApi.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        private readonly IStage_Service _stage_Service;
        private readonly MarvicDbContext _context;
        private readonly IHubContext<ActionHub, IActionHub> _actionHub;
        public StagesController(MarvicDbContext marvicDbContext,IStage_Service stage_Service, IHubContext<ActionHub, IActionHub> actionHub)
        {
            _stage_Service = stage_Service;
            _context = marvicDbContext;
            _actionHub = actionHub;
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
        public async Task<IActionResult>CreateStage([FromBody] Create_Stage_Request model)
        {
            if (!await _stage_Service.CheckExistName(model.Stage_Name))
            {
                var stageInProject = await _stage_Service.GetStageByProjectId(model.Id_Project);
                if (stageInProject!=null)
                {
                    var stage = new Stage(model.Id_Project, model.Stage_Name, model.Id_Creator, stageInProject.Max(stage=>stage.Order)+1);
                    if (await _stage_Service.AddStage(stage))
                    {
                        await _actionHub.Clients.All.Stage();
                        return Ok();
                    }
                    return BadRequest(new { messgae = "Create faild!" });
                }

                return NotFound(new { messgae = $"{model.Id_Project} not found!" });
            }
            return BadRequest(new { messgae = $"{model.Stage_Name} is existed!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStage(Guid id,[FromBody] Update_Stage_Request model)
        {
            if (id!=Guid.Empty)
            {
                var stage = await _stage_Service.GetStageById(id);
                if (stage!=null)
                {
                    if (!await _stage_Service.CheckExistName(model.Stage_Name,id,"edit"))
                    {
                        stage.Stage_Name = model.Stage_Name;
                        stage.Id_Updator = model.Id_Updator;
                        stage.UpdateDate = DateTime.Now;
                        if (await _stage_Service.UpdateStage(stage))
                        {
                            await _actionHub.Clients.All.Stage();
                            return Ok();
                        }
                        return BadRequest(new { messgae = "Update fail!" });
                    }
                    return BadRequest(new { messgae = $"{model.Stage_Name} is existed!" });
                }
                return NotFound(new { message = $"{id} not exists!" });
            }
            return BadRequest("Id is empty!");
        }

        [HttpPost("draganddrop")]
        public async Task<IActionResult> DragAndDrop([FromBody] Drop_Stage_Request model)
        {
            if (!await _stage_Service.DragAndDrop(model.CurrentPos, model.NewPos, model.Id_Project))
            {
                return BadRequest(new { message = "Fail" });
            }
            await _actionHub.Clients.All.Stage();
            return Ok(new { message = "Success!" }); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStage(Guid id, [FromBody] Remove_Stage_Request modelRequest)
        {
            if (id != Guid.Empty)
            {
                var stage = await _stage_Service.GetStageById(id);
                if (stage != null)
                {
                    stage.isDeleted = EnumStatus.True;
                    if (await _stage_Service.DeleteStage(stage, modelRequest))
                    {
                        await _actionHub.Clients.All.Stage();
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
