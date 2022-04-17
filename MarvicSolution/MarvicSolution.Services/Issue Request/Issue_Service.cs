using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Issue_Request
{
    public class Issue_Service : IIssue_Service
    {
        private readonly MarvicDbContext _context;
        public Issue_Service(MarvicDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(Issue_CreateRequest rq)
        {
            try
            {
                var issue = new Issue()
                {
                    Id = Guid.NewGuid(),
                    Id_Project = rq.Id_Project,
                    Id_IssueType = rq.Id_IssueType,
                    Id_Stage = rq.Id_Stage.Equals(Guid.Empty) ? Guid.Empty : rq.Id_Stage,
                    Id_Sprint = rq.Id_Sprint.Equals(Guid.Empty) ? Guid.Empty : rq.Id_Sprint,
                    Id_Label = rq.Id_Label,
                    Summary = rq.Summary,
                    Description = rq.Description,
                    Id_Assignee = rq.Id_Assignee.Equals(Guid.Empty) ? UserLogin.Id : rq.Id,
                    Story_Point_Estimate = rq.Story_Point_Estimate,
                    Id_Reporter = rq.Id_Reporter.Equals(Guid.Empty) ? UserLogin.Id : rq.Id,
                    Attachment_Path = rq.Attachment_Path,
                    Id_Linked_Issue = rq.Id_Linked_Issue,
                    Id_Parent_Issue = rq.Id_Parent_Issue,
                    Priority = rq.Priority == null ? EnumPriority.Lowest : rq.Priority,
                    Id_Restrict = rq.Id_Restrict,
                    IsFlagged = rq.IsFlagged,
                    IsWatched = rq.IsWatched,
                    Id_Creator = rq.Id_Creator,
                    DateCreated = DateTime.Now,
                    DateStarted = rq.DateStarted,
                    DateEnd = rq.DateEnd,
                    Id_Updator = rq.Id_Updator,
                    UpdateDate = rq.UpdateDate
                };

                _context.Issues.Add(issue);
                await _context.SaveChangesAsync();
                return issue.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<Guid> Update(Issue_UpdateRequest rq)
        {
            try
            {
                var issue = _context.Issues.Find(rq.Id);
                if (issue == null)
                    throw new MarvicException($"Cannot find the issue with id: {rq.Id}");
                issue.Id_Project = rq.Id_Project;
                issue.Id_IssueType = rq.Id_IssueType;
                issue.Id_Stage = rq.Id_Stage.Equals(Guid.Empty) ? Guid.Empty : rq.Id_Stage;
                issue.Id_Sprint = rq.Id_Sprint.Equals(Guid.Empty) ? Guid.Empty : rq.Id_Sprint;
                issue.Id_Label = rq.Id_Label;
                issue.Summary = rq.Summary;
                issue.Description = rq.Description;
                issue.Id_Assignee = rq.Id_Assignee.Equals(Guid.Empty) ? UserLogin.Id : rq.Id;
                issue.Story_Point_Estimate = rq.Story_Point_Estimate;
                issue.Id_Reporter = rq.Id_Reporter.Equals(Guid.Empty) ? UserLogin.Id : rq.Id;
                issue.Attachment_Path = rq.Attachment_Path;
                issue.Id_Linked_Issue = rq.Id_Linked_Issue;
                issue.Id_Parent_Issue = rq.Id_Parent_Issue;
                issue.Priority = rq.Priority == null ? EnumPriority.Lowest : rq.Priority;
                issue.Id_Restrict = rq.Id_Restrict;
                issue.IsFlagged = rq.IsFlagged;
                issue.IsWatched = rq.IsWatched;
                issue.Id_Creator = rq.Id_Creator;
                issue.DateCreated = DateTime.Now;
                issue.DateStarted = rq.DateStarted;
                issue.DateEnd = rq.DateEnd;
                issue.Id_Updator = rq.Id_Updator;
                issue.UpdateDate = rq.UpdateDate;

                await _context.SaveChangesAsync();
                return rq.Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<Guid> Delete(Guid Id)
        {
            try
            {
                var issue = _context.Issues.Find(Id);
                _context.Remove(issue);
                await _context.SaveChangesAsync();
                return Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }


        public async Task<List<Issue_ViewModel>> GetAlls()
        {
            throw new NotImplementedException();
        }

    }
}
