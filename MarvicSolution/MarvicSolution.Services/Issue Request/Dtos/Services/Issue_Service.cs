﻿using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
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
                    Id_Creator = UserLogin.Id,
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
                issue.Id_Assignee = rq.Id_Assignee.Equals(Guid.Empty) ? issue.Id_Assignee : rq.Id;
                issue.Story_Point_Estimate = rq.Story_Point_Estimate;
                issue.Id_Reporter = rq.Id_Reporter.Equals(Guid.Empty) ? issue.Id_Reporter : rq.Id;
                issue.Attachment_Path = rq.Attachment_Path;
                issue.Id_Linked_Issue = rq.Id_Linked_Issue.Equals(Guid.Empty) ? issue.Id_Linked_Issue : rq.Id_Linked_Issue;
                issue.Id_Parent_Issue = rq.Id_Parent_Issue.Equals(Guid.Empty) ? issue.Id_Parent_Issue : rq.Id_Parent_Issue;
                issue.Priority = rq.Priority == null ? issue.Priority : rq.Priority;
                issue.Id_Restrict = rq.Id_Restrict.Equals(Guid.Empty) ? issue.Id_Restrict : rq.Id_Restrict;
                issue.IsFlagged = rq.IsFlagged == null ? issue.IsFlagged : rq.IsFlagged;
                issue.IsWatched = rq.IsWatched == null ? issue.IsWatched : rq.IsWatched;
                issue.DateStarted = rq.DateStarted == null ? issue.DateStarted : rq.DateStarted;
                issue.DateEnd = rq.DateEnd == null ? issue.DateEnd : rq.DateEnd;
                issue.Id_Updator = UserLogin.Id;
                issue.UpdateDate = DateTime.Now;

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
                issue.IsDeleted = EnumStatus.True;
                await _context.SaveChangesAsync();
                return Id;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }


        public List<Issue_ViewModel> Get_Issues_By_IdProject(Guid idProject)
        {
            var issues = (_context.Issues.Where(i => i.Id_Project.Equals(idProject))
                                        .Select(x => new Issue_ViewModel()
                                        {
                                            Id = x.Id,
                                            Id_Project = x.Id_Project,
                                            Id_Stage = x.Id_Stage,
                                            Id_Sprint = x.Id_Sprint,
                                            Id_IssueType = x.Id_IssueType,
                                            Summary = x.Summary,
                                            Description = x.Description,
                                            Id_Assignee = x.Id_Assignee,
                                            Story_Point_Estimate = x.Story_Point_Estimate,
                                            Id_Reporter = x.Id_Reporter,
                                            Attachment_Path = x.Attachment_Path,
                                            Id_Linked_Issue = x.Id_Linked_Issue,
                                            Id_Parent_Issue = x.Id_Parent_Issue,
                                            Priority = x.Priority,
                                            Id_Restrict = x.Id_Restrict,
                                            IsFlagged = x.IsFlagged,
                                            IsWatched = x.IsWatched,
                                            Id_Creator = x.Id_Creator,
                                            DateCreated = x.DateCreated,
                                            DateStarted = x.DateStarted,
                                            DateEnd = x.DateEnd,
                                            Id_Updator = x.Id_Updator
                                        })).ToList();
            return issues;
        }

        public List<GroupByAssignee_ViewModel> Group_By_Assignee(Guid IdProject)
        {
            try
            {
                var groupIdAssignee = from i in _context.Issues.ToList()
                                      where i.Id_Project.Equals(IdProject)
                                      group i by i.Id_Assignee;
                List<GroupByAssignee_ViewModel> listGroupVM = new List<GroupByAssignee_ViewModel>();
                foreach (var i_group in groupIdAssignee)
                {
                    GroupByAssignee_ViewModel groupVM = new GroupByAssignee_ViewModel();
                    groupVM.Id_Assignee = i_group.Key;
                    var item = i_group.Select(g => new Issue_ViewModel()
                    {
                        Id = g.Id,
                        Id_Project = g.Id_Project,
                        Id_IssueType = g.Id_IssueType,
                        Id_Stage = g.Id_Stage,
                        Id_Sprint = g.Id_Sprint,
                        Id_Label = g.Id_Label,
                        Summary = g.Summary,
                        Description = g.Description,
                        Id_Assignee = g.Id_Assignee,
                        Story_Point_Estimate = g.Story_Point_Estimate,
                        Id_Reporter = g.Id_Reporter,
                        Attachment_Path = g.Attachment_Path,
                        Id_Linked_Issue = g.Id_Linked_Issue,
                        Id_Parent_Issue = g.Id_Parent_Issue,
                        Priority = g.Priority,
                        Id_Restrict = g.Id_Restrict,
                        IsFlagged = g.IsFlagged,
                        IsWatched = g.IsWatched,
                        Id_Creator = g.Id_Creator,
                        DateCreated = g.DateCreated,
                        DateStarted = g.DateStarted,
                        DateEnd = g.DateEnd,
                        Id_Updator = g.Id_Updator,
                        UpdateDate = g.UpdateDate,
                        IsDeleted = g.IsDeleted

                    });
                    groupVM.ListIssue.AddRange(item);
                    listGroupVM.Add(groupVM);
                }

                return listGroupVM;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public List<GroupByIssueType_ViewModel> Group_By_IssueType(Guid IdProject)
        {
            try
            {
                var groupIssueType = from i in _context.Issues.ToList()
                                     where i.Id_Project.Equals(IdProject)
                                     group i by i.Id_IssueType;
                List<GroupByIssueType_ViewModel> listGroupVM = new List<GroupByIssueType_ViewModel>();
                foreach (var i_group in groupIssueType)
                {
                    GroupByIssueType_ViewModel groupVM = new GroupByIssueType_ViewModel();
                    groupVM.IdType = i_group.Key;
                    var item = i_group.Select(g => new Issue_ViewModel()
                    {
                        Id = g.Id,
                        Id_Project = g.Id_Project,
                        Id_IssueType = g.Id_IssueType,
                        Id_Stage = g.Id_Stage,
                        Id_Sprint = g.Id_Sprint,
                        Id_Label = g.Id_Label,
                        Summary = g.Summary,
                        Description = g.Description,
                        Id_Assignee = g.Id_Assignee,
                        Story_Point_Estimate = g.Story_Point_Estimate,
                        Id_Reporter = g.Id_Reporter,
                        Attachment_Path = g.Attachment_Path,
                        Id_Linked_Issue = g.Id_Linked_Issue,
                        Id_Parent_Issue = g.Id_Parent_Issue,
                        Priority = g.Priority,
                        Id_Restrict = g.Id_Restrict,
                        IsFlagged = g.IsFlagged,
                        IsWatched = g.IsWatched,
                        Id_Creator = g.Id_Creator,
                        DateCreated = g.DateCreated,
                        DateStarted = g.DateStarted,
                        DateEnd = g.DateEnd,
                        Id_Updator = g.Id_Updator,
                        UpdateDate = g.UpdateDate,
                        IsDeleted = g.IsDeleted

                    });
                    groupVM.ListIssue.AddRange(item);
                    listGroupVM.Add(groupVM);
                }

                return listGroupVM;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public List<GroupByPriority_ViewModel> Group_By_Priority(Guid IdProject)
        {
            try
            {
                var groupPriority = from i in _context.Issues.ToList()
                                    where i.Id_Project.Equals(IdProject)
                                    group i by i.Priority;
                List<GroupByPriority_ViewModel> listGroupVM = new List<GroupByPriority_ViewModel>();
                foreach (var i_group in groupPriority)
                {
                    GroupByPriority_ViewModel groupVM = new GroupByPriority_ViewModel();
                    groupVM.Priority = i_group.Key;
                    var item = i_group.Select(g => new Issue_ViewModel()
                    {
                        Id = g.Id,
                        Id_Project = g.Id_Project,
                        Id_IssueType = g.Id_IssueType,
                        Id_Stage = g.Id_Stage,
                        Id_Sprint = g.Id_Sprint,
                        Id_Label = g.Id_Label,
                        Summary = g.Summary,
                        Description = g.Description,
                        Id_Assignee = g.Id_Assignee,
                        Story_Point_Estimate = g.Story_Point_Estimate,
                        Id_Reporter = g.Id_Reporter,
                        Attachment_Path = g.Attachment_Path,
                        Id_Linked_Issue = g.Id_Linked_Issue,
                        Id_Parent_Issue = g.Id_Parent_Issue,
                        Priority = g.Priority,
                        Id_Restrict = g.Id_Restrict,
                        IsFlagged = g.IsFlagged,
                        IsWatched = g.IsWatched,
                        Id_Creator = g.Id_Creator,
                        DateCreated = g.DateCreated,
                        DateStarted = g.DateStarted,
                        DateEnd = g.DateEnd,
                        Id_Updator = g.Id_Updator,
                        UpdateDate = g.UpdateDate,
                        IsDeleted = g.IsDeleted

                    });
                    groupVM.ListIssue.AddRange(item);
                    listGroupVM.Add(groupVM);
                }

                return listGroupVM;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        public List<Issue_ViewModel> Get_Issue_By_IdParent(Guid IdProject, Guid IdParent)
        {
            var issues = (_context.Issues.Where(i => i.Id_Project.Equals(IdProject) && i.Id_Parent_Issue.Equals(IdParent))
                                        .Select(x => new Issue_ViewModel()
                                        {
                                            Id = x.Id,
                                            Id_Project = x.Id_Project,
                                            Id_Stage = x.Id_Stage,
                                            Id_Sprint = x.Id_Sprint,
                                            Id_IssueType = x.Id_IssueType,
                                            Summary = x.Summary,
                                            Description = x.Description,
                                            Id_Assignee = x.Id_Assignee,
                                            Story_Point_Estimate = x.Story_Point_Estimate,
                                            Id_Reporter = x.Id_Reporter,
                                            Attachment_Path = x.Attachment_Path,
                                            Id_Linked_Issue = x.Id_Linked_Issue,
                                            Id_Parent_Issue = x.Id_Parent_Issue,
                                            Priority = x.Priority,
                                            Id_Restrict = x.Id_Restrict,
                                            IsFlagged = x.IsFlagged,
                                            IsWatched = x.IsWatched,
                                            Id_Creator = x.Id_Creator,
                                            DateCreated = x.DateCreated,
                                            DateStarted = x.DateStarted,
                                            DateEnd = x.DateEnd,
                                            Id_Updator = x.Id_Updator
                                        })).ToList();

            return issues;
        }

        public List<Issue_ViewModel> Get_Issues_By_IdUser(Guid idProject, Guid idUser)
        {
            var issues = (_context.Issues.Where(i => i.Id_Project.Equals(idProject) && (i.Id_Assignee.Equals(idUser) || i.Id_Reporter.Equals(idUser)))
                                        .Select(x => new Issue_ViewModel()
                                        {
                                            Id = x.Id,
                                            Id_Project = x.Id_Project,
                                            Id_Stage = x.Id_Stage,
                                            Id_Sprint = x.Id_Sprint,
                                            Id_IssueType = x.Id_IssueType,
                                            Summary = x.Summary,
                                            Description = x.Description,
                                            Id_Assignee = x.Id_Assignee,
                                            Story_Point_Estimate = x.Story_Point_Estimate,
                                            Id_Reporter = x.Id_Reporter,
                                            Attachment_Path = x.Attachment_Path,
                                            Id_Linked_Issue = x.Id_Linked_Issue,
                                            Id_Parent_Issue = x.Id_Parent_Issue,
                                            Priority = x.Priority,
                                            Id_Restrict = x.Id_Restrict,
                                            IsFlagged = x.IsFlagged,
                                            IsWatched = x.IsWatched,
                                            Id_Creator = x.Id_Creator,
                                            DateCreated = x.DateCreated,
                                            DateStarted = x.DateStarted,
                                            DateEnd = x.DateEnd,
                                            Id_Updator = x.Id_Updator
                                        })).ToList();

            return issues;
        }

        public List<Issue_ViewModel> Get_Issue_By_IdLabel(Guid IdProject, Guid IdLabel)
        {
            try
            {
                var issues = (_context.Issues.Where(i => i.Id_Project.Equals(IdProject) && i.Id_Label.Equals(IdLabel))
                                        .Select(x => new Issue_ViewModel()
                                        {
                                            Id = x.Id,
                                            Id_Project = x.Id_Project,
                                            Id_Stage = x.Id_Stage,
                                            Id_Sprint = x.Id_Sprint,
                                            Id_IssueType = x.Id_IssueType,
                                            Summary = x.Summary,
                                            Description = x.Description,
                                            Id_Assignee = x.Id_Assignee,
                                            Story_Point_Estimate = x.Story_Point_Estimate,
                                            Id_Reporter = x.Id_Reporter,
                                            Attachment_Path = x.Attachment_Path,
                                            Id_Linked_Issue = x.Id_Linked_Issue,
                                            Id_Parent_Issue = x.Id_Parent_Issue,
                                            Priority = x.Priority,
                                            Id_Restrict = x.Id_Restrict,
                                            IsFlagged = x.IsFlagged,
                                            IsWatched = x.IsWatched,
                                            Id_Creator = x.Id_Creator,
                                            DateCreated = x.DateCreated,
                                            DateStarted = x.DateStarted,
                                            DateEnd = x.DateEnd,
                                            Id_Updator = x.Id_Updator
                                        })).ToList();
                return issues;
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
    }
}
