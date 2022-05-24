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

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        private readonly IStage_Service _stage_Service;
        private readonly MarvicDbContext _context;
        public StagesController(MarvicDbContext marvicDbContext,IStage_Service stage_Service )
        {
            _stage_Service = stage_Service;
            _context = marvicDbContext;
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

        [HttpGet("draganddrop/{currentPos}/{newPos}")]
        public async Task<IActionResult> DragAndDrop(int currentPos,int newPos, Guid id_Project)
        {
            if (!await _stage_Service.DragAndDrop(currentPos, newPos, id_Project))
            {
                return BadRequest(new { message = "Fail" });
            }
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
