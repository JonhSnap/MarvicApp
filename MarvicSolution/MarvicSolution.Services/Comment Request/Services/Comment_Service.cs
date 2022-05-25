using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Comment_Request.ViewModels;
using MarvicSolution.Services.Issue_Request.Issue_Request;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Comment_Request.Services
{
    public class Comment_Service : IComment_Service
    {
        private readonly MarvicDbContext _context;
        private readonly ILogger<Comment_Service> _logger;

        public Comment_Service(MarvicDbContext context, ILogger<Comment_Service> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddComment(Comment model)
        {
            try
            {
                _context.Comments.Add(model);
                var result = await _context.SaveChangesAsync() > 0;
                return result;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Comment. Method: AddComment. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Comment. Method: DeleteComment. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Comment. Method: UpdateComment. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<Comment> GetCommentById(Guid id, Guid id_User)
        {
            try
            {
                return await _context.Comments.FirstOrDefaultAsync(cmt => cmt.Id == id && cmt.Id_User == id_User && cmt.Is_Delete == EnumStatus.False);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Comment. Method: GetCommentById. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
            
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Comment. Method: GetCommentsById_Issue. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Comment. Method: GetCommentsByParentId. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        private async Task<IList<CommentVM>> CountChildComment(IList<CommentVM> commments)
        {
            try
            {
                if (commments != null)
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
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
            
        }
    }
}
