using MarvicSolution.BackendApi.Hubs;
using Microsoft.AspNetCore.SignalR;
using MarvicSolution.DATA.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MarvicSolution.Services.Comment_Request.Services;
using MarvicSolution.Services.Comment_Request.Requests;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IComment_Service _comment_Service;
        private readonly IHubContext<ActionHub, IActionHub> _actionHub;
        public CommentsController(IComment_Service comment_Service, IHubContext<ActionHub, IActionHub> actionHub)
        {
            _comment_Service = comment_Service;
            _actionHub = actionHub;
        }
       
        [HttpGet("issue/{Id_Issue}")]
        public async Task<IActionResult> GetComments(Guid Id_Issue)
        {
            var comments= await _comment_Service.GetCommentsById_Issue(Id_Issue);
            if (comments.Count==0)
            {
                return NotFound();
            }
            return Ok(comments);
        }

        [HttpGet("{parentId}")]
        public async Task<IActionResult> GetCommentsByParentId(Guid parentId)
        {
            var comments = await _comment_Service.GetCommentsByParentId(parentId);
            if (comments.Count == 0)
            {
                return NotFound();
            }
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create_Comment_Request commentRequest)
        {
            var model = new Comment(commentRequest.Id_User, commentRequest.Id_Issue, commentRequest.Content, commentRequest.Id_ParentComment);
            if (await _comment_Service.AddComment(model))
            {
                await _actionHub.Clients.All.Comment();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] Edit_Comment_Request commentRequest)
        {
            var model = _comment_Service.GetCommentById(Id, commentRequest.Id_User);
            if (model!=null)
            {
                model.Result.Content = commentRequest.Content;
                model.Result.Update_Date = DateTime.Now;
                if (await _comment_Service.UpdateComment(model.Result))
                {
                    await _actionHub.Clients.All.Comment();
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id,[FromBody] Delete_Comment_Request commentRequest)
        {
            var model = _comment_Service.GetCommentById(Id, commentRequest.Id_User);
            if (model!=null && await _comment_Service.DeleteComment(model.Result))
            {
                await _actionHub.Clients.All.Comment();
                return Ok();
            }
            return BadRequest();
        }
    }
}
