using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Comment_Request.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Comment_Request.Services
{
    public interface IComment_Service
    {
        Task<bool> AddComment(Comment model);
        Task<bool> DeleteComment(Comment model);
        Task<bool> UpdateComment(Comment model);
        Task<Comment> GetCommentById(Guid id, Guid id_User);
        Task<IList<CommentVM>>GetCommentsById_Issue(Guid id_Issue);
        Task<IList<CommentVM>> GetCommentsByParentId(Guid parentId);
    }
}
