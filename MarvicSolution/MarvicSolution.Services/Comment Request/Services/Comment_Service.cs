using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Comment_Request.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Comment_Request.Services
{
    public class Comment_Service : IComment_Service
    {
        private readonly MarvicDbContext _context;

        public Comment_Service(MarvicDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddComment(Comment model)
        {
            try
            {
                _context.Comments.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //log here....
                return true;
            }
        }

        public async Task<bool> DeleteComment(Comment comment)
        {
            try
            {
                comment.Is_Delete = EnumStatus.True;
                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //log here....
                return true;
            }
        }

        public async Task<bool> UpdateComment(Comment model)
        {
            try
            {
                _context.Comments.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //log here....
                return true;
            }
        }

        public async Task<Comment> GetCommentById(Guid id, Guid id_User)
        {
            return await _context.Comments.FirstOrDefaultAsync(cmt => cmt.Id == id && cmt.Id_User == id_User && cmt.Is_Delete == EnumStatus.False); ;
        }

        public async Task<IList<CommentVM>> GetCommentsById_Issue(Guid id_Issue)
        {
            //load only parent comment
            var commments = await _context.Comments
                .Where(cmt => cmt.Id_Issue == id_Issue && cmt.Is_Delete == EnumStatus.False && cmt.Id_ParentComment == Guid.Empty)
                .OrderBy(comt => comt.Create_Date)
                .Select(comt => new CommentVM(comt.Id, comt.Id_User, comt.Id_Issue, comt.Content, comt.Update_Date, comt.Create_Date, comt.Id_ParentComment))
                .ToListAsync();
            return await CountChildComment(commments);
        }
        public async Task<IList<CommentVM>> GetCommentsByParentId(Guid parentId)
        {
            var commments = await _context.Comments
                .Where(cmt => cmt.Id_ParentComment == parentId && cmt.Is_Delete == EnumStatus.False)
                .Select(comt =>
                   new CommentVM(comt.Id, comt.Id_User, comt.Id_Issue, comt.Content, comt.Update_Date, comt.Create_Date, comt.Id_ParentComment)
                )
                .ToListAsync();
            return await CountChildComment(commments);
        }

        private async Task<IList<CommentVM>> CountChildComment(IList<CommentVM> commments)
        {
            foreach (var parent in commments)
            {
                parent.CountChild = await _context.Comments
                    .Where(cmt => cmt.Id_ParentComment == parent.Id)
                    .OrderBy(comt => comt.Create_Date)
                    .Select(comt => new CommentVM(comt.Id, comt.Id_User, comt.Id_Issue, comt.Content, comt.Update_Date, comt.Create_Date, comt.Id_ParentComment))
                    .CountAsync();
            }
            return commments;

        }


    }
}
