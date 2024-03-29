﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Label_Request.Services;
using MarvicSolution.Services.Label_Request.Requests;
using MarvicSolution.BackendApi.Constants;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly ILabel_Service _label_Service;
        public LabelsController(ILabel_Service label_Service)
        {
            _label_Service = label_Service;
        }

        [HttpGet("project/{id_project}")]
        public async Task<IActionResult> GetLabelsByProjectId(Guid id_project)
        {
            var labels = await _label_Service.GetLabelByProjectId(id_project);
            if (labels.Count == 0)
            {
                return NotFound(new { message = $"{id_project} not exists!" });
            }
            return Ok(labels);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create_Label_Request model)
        {
            if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
            {
                var label = new Label(model.Id_Project, model.Name, model.Id_Creator);
                if (await _label_Service.AddLabel(label))
                {
                    return Ok();
                }
                return BadRequest(new { messgae = "Add faild!" });
            }
            else
                return Content("You do not have permission to perform this function");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Update_Label_Request model)
        {
            if (id != Guid.Empty)
            {
                if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
                {
                    var label = await _label_Service.GetLabelById(id);
                    if (label != null)
                    {
                        label.Name = model.Name;
                        label.Id_Updator = model.Id_Updator;
                        label.UpdateDate = DateTime.Now;
                        if (await _label_Service.UpdateLabel(label))
                        {
                            return Ok();
                        }
                        return BadRequest(new { messgae = "Update faild!" });
                    }
                    return NotFound(new { message = $"{id} not exists!" });
                }
                else
                    return Content("You do not have permission to perform this function");
            }
            return BadRequest(new { message = "Id is empty!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                if (UserLogin.Role.Equals(2) || UserLogin.Role.Equals(1))
                {
                    var label = await _label_Service.GetLabelById(id);
                    if (label != null)
                    {
                        label.isDeleted = EnumStatus.True;
                        if (await _label_Service.UpdateLabel(label))
                        {
                            return Ok();
                        }
                        return BadRequest(new { messgae = "Delete faild!" });
                    }
                    return NotFound(new { message = $"{id} not exists!" });
                }
                else
                    return Content("You do not have permission to perform this function");
            }
            return BadRequest("Id is empty!");
        }
    }
}
