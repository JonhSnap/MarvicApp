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
            return await _context.Comments.FirstOrDefaultAsync(cmt => cmt.Id == id && cmt.Id_User == id_User && cmt.Is_Delete == EnumStatus.False);
        }

        public async Task<IList<CommentVM>> GetCommentsById_Issue(Guid id_Issue)
        {
            try
            {
                //load only parent comment
                var commments = await (from user in _context.App_Users
                                      join comt in _context.Comments on user.Id equals comt.Id_User
                                      where comt.Id_Issue == id_Issue && comt.Is_Delete==0 && comt.Id_ParentComment==Guid.Empty
                                      select new CommentVM(comt.Id, comt.Id_User, comt.Id_Issue, user.UserName, comt.Content, comt.Update_Date, comt.Create_Date, comt.Id_ParentComment))
                                      .ToListAsync();
                return await CountChildComment(commments);
            }
            catch (Exception ex)
            {
                //log here....
                throw;
            }
        }
        public async Task<IList<CommentVM>> GetCommentsByParentId(Guid parentId)
        {
            try
            {
                var commments = await (from user in _context.App_Users
                                       join comt in _context.Comments on user.Id equals comt.Id_User
                                       where comt.Id_ParentComment == parentId && comt.Is_Delete == 0
                                       select new CommentVM(comt.Id, comt.Id_User, comt.Id_Issue, user.UserName, comt.Content, comt.Update_Date, comt.Create_Date, comt.Id_ParentComment))
                                      .ToListAsync();
               /* var commments = await _context.Comments
                    .Where(cmt => cmt.Id_ParentComment == parentId && cmt.Is_Delete == EnumStatus.False)
                    .Select(comt =>
                       new CommentVM(comt.Id, comt.Id_User, comt.Id_Issue, comt.Content, comt.Update_Date, comt.Create_Date, comt.Id_ParentComment)
                    )
                    .ToListAsync();*/
                return await CountChildComment(commments);
            }
            catch (Exception ex)
            {
                //log here....
                throw;
            }
        }

        private async Task<IList<CommentVM>> CountChildComment(IList<CommentVM> commments)
        {
            if (commments!=null)
            {
                foreach (var parent in commments)
                {
                    parent.CountChild = await _context.Comments
                        .Where(cmt => cmt.Id_ParentComment == parent.Id)
                        .OrderBy(comt => comt.Create_Date)
                        .Select(comt => new CommentVM(comt.Id, comt.Id_User, comt.Id_Issue, comt.Content, comt.Update_Date, comt.Create_Date, comt.Id_ParentComment))
                        .CountAsync();
                }
            }
            return commments;
        }
    }
}
